﻿using BLL.Admin.Interfaces;
using DAL.Admin.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Admin;
using Models.Admin.Json;
using Models.Admin.ModelView;
using Models.Admin.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Models.Admin.Outputs.HttpResponses;
using Models.Admin.Json.Outputs;
using Factorys.AccountFactorys;

namespace BLL.Admin.Services
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private IUsuarioDAO _usuarioDAO;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserClaimDAO _userClaim;
        private ITokenGeradorBLL _tokenGeradorBLL;
        private IEmpresaDAO _empresaDAO;
        private IEmpresaRegraDAO _empresaRegraDAO;

        public UsuarioBLL(IUsuarioDAO usuarioDAO,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserClaimDAO userClaim,
            ITokenGeradorBLL tokenGeradorBLL,
            IEmpresaDAO empresaDAO,
            IEmpresaRegraDAO empresaRegraDAO)
        {
            this._usuarioDAO = usuarioDAO;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._userClaim = userClaim;
            this._tokenGeradorBLL = tokenGeradorBLL;
            this._empresaDAO = empresaDAO;
            this._empresaRegraDAO = empresaRegraDAO;
        }

        /// <summary>
        /// Cria o usuário na Base
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        public async Task<HttpResponse> CriarUsuario(UserModelView registerUser)
        {
            //Cria o usuário
            var newUser = new ApplicationUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true, //Envio de e-mail de confirmação - muda para false
                LockoutEnabled = false
            };

            //Registra o usuário
            var result = await _userManager.CreateAsync(newUser, registerUser.Password);
            var userCreated = await _userManager.FindByEmailAsync(registerUser.Email);

            if (!result.Succeeded)
            {
                return new HttpResponse()
                {
                    Succeeded = result.Succeeded,
                    Message = result.Errors.Select(e => e.Description),
                    body = null
                };
            }

            IList<EmpresaRegra> regrasEmpresa = await this._empresaRegraDAO
                                                           .GetByEmpresaIdAsync(registerUser.IdEmpresa);

            IList<Claim> claimsPersonalizadas = EmpresaRegraFactory.GenerateByEmpresaRegraList(regrasEmpresa);
            

            //Gera o Token
            UserTokenResult resultToken = await this._tokenGeradorBLL
                                                    .GetTokenByEmail(registerUser.Email,claimsPersonalizadas);

            //Salva o usuário
            Usuario usuario = new Usuario()
            {
                UserToken = resultToken.Token,
                UserClaims = resultToken.UserClaims,
                Email = registerUser.Email,
                Password = userCreated.PasswordHash,
                AspNetUsersId = userCreated.Id,
                Ativo = true,
                Empresa = this._empresaDAO.GetById(registerUser.IdEmpresa),
                LastAcess = DateTime.Now
            };

            _usuarioDAO.Save(usuario);

            //Libera o usuário             
            await this.UnlockLockUser(registerUser.Email);


            //Autentica o usuário na aplicação
            await _signInManager.SignInAsync(newUser, false);

            return new HttpResponse()
            {
                Succeeded = result.Succeeded,
                Message = result.Errors.Select(e => e.Description),
                body = usuario.UserToken
            };
        }

        /// <summary>
        /// Efetua o login no sistema e retona o novo token válido 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<HttpResponse> EfetuarLogin(UserModelView userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                isPersistent: false, lockoutOnFailure: false);
            //lockoutOnFailure - Bloqueio temporário em caso de inúmeras tentativas
            var userCreated = await _userManager.FindByEmailAsync(userInfo.Email);

            //Validação se efetuou o login com sucesso
            if (!result.Succeeded)
            {
                return new HttpResponse()
                {
                    Succeeded = result.Succeeded,
                    Message = new string[] { "Erro ao efetuar o login" },
                    body = null,
                    statusText = "Login inválido"

                };
            }

            //Validação se o usuário não está block            
            if (userCreated.LockoutEnabled)
            {
                return new HttpResponse()
                {
                    Succeeded = !userCreated.LockoutEnabled,
                    Message = new string[] { "User is locked out" },
                    body = null,
                    statusText = "Login inválido"
                };
            }           

            IList<EmpresaRegra> regrasEmpresa = await this._empresaRegraDAO
                                                           .GetByEmpresaIdAsync(userInfo.IdEmpresa);

            IList<Claim> claimsPersonalizadas = EmpresaRegraFactory.GenerateByEmpresaRegraList(regrasEmpresa);

            //Gera o Token
            UserTokenResult resultToken = await this._tokenGeradorBLL
                                                    .GetTokenByEmail(userInfo.Email, claimsPersonalizadas);    

            //Atualiza o usuário com o novo Token e Claims  
            Usuario usuario = _usuarioDAO.GetByAspNetId(userCreated.Id);
            resultToken.Token.Id = usuario.UserToken.Id;

            _userClaim.UpdateClaims(resultToken.UserClaims);
            _usuarioDAO.UpdateToken(resultToken.Token);

            return new HttpResponse()
            {
                Succeeded = result.Succeeded,
                Message = new string[] { "Login efetuado com sucesso." },
                body = resultToken,
                statusText = "Login Aceito"
            };

        }

        /// <summary>
        /// Faz a aexclusão do usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirUsuario(UserModelView userInfo)
        {
            var userAspNet = await _userManager.FindByEmailAsync(userInfo.Email);
            await _userManager.DeleteAsync(userAspNet);
            _usuarioDAO.Delete(_usuarioDAO.GetByAspNetId(userAspNet.Id));
            return true;
        }

        /// <summary>
        /// Lista os usuários do sistema, retornando um modelo para formato Json
        /// </summary>
        /// <returns></returns>
        public async Task<IList<UsuarioJsonResult>> ListarUsuariosJson()
        {
            var result = UsuarioFactory
                          .GeraUsuarioJsonByList( this._usuarioDAO.List());
            return result;
        }

        /// <summary>
        /// Libera ou bloqueia os usuários do sistema pelo e-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> UnlockLockUser(string email)
        {
            var userAspNet = await _userManager.FindByEmailAsync(email);
            IdentityResult result = await _userManager
                                         .SetLockoutEnabledAsync(userAspNet, !userAspNet.LockoutEnabled);

            Usuario usuario = this._usuarioDAO.GetByAspNetId(userAspNet.Id);

            _usuarioDAO.LockUnlock(usuario,!userAspNet.LockoutEnabled);

            if (result.Succeeded) return true;

            return false;
        }

        /// <summary>
        /// Libera ou bloqueia os usuários do sistema pelo id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> UnlockLockUserById(int userId)
        {
            var email = this._usuarioDAO.GetById(userId).Email;
            return await UnlockLockUser(email);
        }


    }
}
