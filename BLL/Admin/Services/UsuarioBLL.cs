using BLL.Admin.Interfaces;
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
using Microsoft.EntityFrameworkCore;

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
                            IEmpresaRegraDAO empresaRegraDAO
                            )
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
        public async Task<HttpResponse> CriarUsuario(Login registerUser)
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
                                                    .GetTokenByEmail(registerUser.Email, claimsPersonalizadas);

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

            await _usuarioDAO.SaveAsync(usuario);

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
        public async Task<HttpResponse> EfetuarLogin(Login userInfo)
        {
            //tenta  Autentica o usuário
            SignInResult signInResult;
            try
            {

                signInResult = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                                      isPersistent: true, lockoutOnFailure: false).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new HttpResponse()
                {
                    Succeeded = false,
                    Message = new string[] { "Erro ao efetuar o login" },
                    body = new string[] { "{succeeded:false}" },
                    statusText = "Login inválido",
                    RedirectTo = ""

                };
            }



            if (!signInResult.Succeeded)
            {
                return new HttpResponse()
                {
                    Succeeded = false,
                    Message = new string[] { "Erro ao efetuar o login" },
                    body = new string[] { "{succeeded:false}" },
                    statusText = "Login inválido",
                    RedirectTo = ""

                };
            }
            //Recupera o usuário AspNet
            var userCreated = await _userManager.FindByEmailAsync(userInfo.Email);

            //Recupera o cadastro do usuário
            Usuario usuario = await _usuarioDAO.GetByAspNetIdAsync(userCreated.Id);

            //Validação se efetuou o login com sucesso
            if (userCreated.LockoutEnabled)
            {

                return new HttpResponse()
                {
                    Succeeded = signInResult.Succeeded,
                    Message = new string[] { "Erro ao efetuar o login" },
                    body = new string[] { "{succeeded:false}" },
                    statusText = "Login inválido",
                    RedirectTo = ""

                };
            }


            usuario.ExpirationDateLogged = DateTime.Now.AddHours(48);
            usuario.IsLogged = true;
            await this._usuarioDAO.UpdateAsync(usuario);


            //Monta a lista de Claims personalizadas por empresa
            IList<EmpresaRegra> regrasEmpresa = await this._empresaRegraDAO
                                                           .GetByEmpresaIdAsync(userInfo.IdEmpresa);

            IList<Claim> claimsDaEmpresa = EmpresaRegraFactory.GenerateByEmpresaRegraList(regrasEmpresa);



            //Gera o Token com as Claims personalizdas
            UserTokenResult resultToken = await this._tokenGeradorBLL
                                                    .GetTokenByEmail(userInfo.Email, claimsDaEmpresa, userCreated);

            //Atualiza o usuário com o novo Token e Claims 
            if (resultToken.UserClaims.Count > 0)
            {
                _userClaim.UpdateClaims(resultToken.UserClaims);
            }


            var userToken = this._tokenGeradorBLL
                                        .ListAll()
                                        .Where(x => x.UsuarioId == usuario.Id)
                                        .SingleOrDefault();


            userToken.Token = resultToken.Token.Token;
            await _usuarioDAO.UpdateToken(userToken);
            resultToken.succeeded = true;




            return new HttpResponse()
            {
                Succeeded = signInResult.Succeeded,
                Message = new string[] { "Login efetuado com sucesso." },
                body = resultToken,
                statusText = "Login efetuado com sucesso.",
                Identities = resultToken.ClaimsIdentity,
                ClaimsPrincipal = new ClaimsPrincipal(resultToken.ClaimsIdentity),
                RedirectTo = "/mainApp"

            };

        }


        public async Task<bool> UsuarioEstaLogado(Usuario usuario)
        {
            var ultimoLogin = await (from u in this._usuarioDAO.ListAll()
                                     where u.Id == usuario.Id
                                     select new
                                     {
                                         u.ExpirationDateLogged,
                                         u.IsLogged
                                     }).SingleOrDefaultAsync();

            return ultimoLogin.ExpirationDateLogged >= DateTime.Now && ultimoLogin.IsLogged;
        }


        public async Task Logout(Usuario usuario)
        {

            usuario.IsLogged = false;
            usuario.ExpirationDateLogged = DateTime.Now;
            await this._usuarioDAO.UpdateAsync(usuario);

        }

        /// <summary>
        /// Faz a aexclusão do usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirUsuario(Login userInfo)
        {
            var userAspNet = await _userManager.FindByEmailAsync(userInfo.Email);
            await _userManager.DeleteAsync(userAspNet);
            await _usuarioDAO.DeleteAsync(await _usuarioDAO.GetByAspNetIdAsync(userAspNet.Id));
            return true;
        }

        /// <summary>
        /// Lista os usuários do sistema, retornando um modelo para formato Json
        /// </summary>
        /// <returns></returns>
        public async Task<IList<UsuarioJsonResult>> ListarUsuariosJson()
        {
            IList<Usuario> usuarios = this._usuarioDAO.ListAll().ToList();

            var result = UsuarioFactory
                          .GeraUsuarioJsonByList(usuarios);
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

            Usuario usuario = await this._usuarioDAO.GetByAspNetIdAsync(userAspNet.Id);

            await _usuarioDAO.LockUnlock(usuario, !userAspNet.LockoutEnabled);

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
            var usuario = await this._usuarioDAO.GetByIdAsync(userId);
            return await UnlockLockUser(usuario.Email);
        }

        public async Task<Usuario> GetUsuarioPeloEmail(string email)
        {
            var usuario = await this._usuarioDAO.ListAll()
                                            .Where(u => u.Email == email)
                                            .SingleOrDefaultAsync();
            return usuario;


        }
    }
}
