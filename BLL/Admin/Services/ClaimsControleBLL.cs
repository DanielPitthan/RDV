using BLL.Admin.Interfaces;
using DAL.Admin.Interfaces;
using Factorys.AccountFactorys;
using Microsoft.AspNetCore.Identity;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AccountsBLL
{
    public class ClaimsControleBLL : ClaimControle, IClaimsControleBLL
    {
        private IUsuarioDAO _usuarioDAO;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserClaimDAO _claimsDAO;
        private ITokenGeradorBLL _tokenGeradorBLL;

        public ClaimsControleBLL(IUsuarioDAO usuarioDAO,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                IUserClaimDAO claimsDAO,
                ITokenGeradorBLL tokenGeradorBLL)
        {
            this._usuarioDAO = usuarioDAO;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._claimsDAO = claimsDAO;
            this._tokenGeradorBLL = tokenGeradorBLL;
        }

        /// <summary>
        /// Inclui uma nova regra 
        /// </summary>
        /// <param name="json"></param>
        public async Task<bool> IncluirClaimsByJson(string json)
        {

            var regras = base.GeraListaClaims(json);
            var usuario = this._usuarioDAO.GetById(base.ListaDeClaims.FirstOrDefault().UserId);

            var aspNetUser = await this._userManager.FindByEmailAsync(usuario.Email);

            await this._userManager.AddClaimsAsync(aspNetUser, regras);

            this._claimsDAO.InsertClaims(UserClaimFactory.TransformInClaimByList(regras, true));

            await _tokenGeradorBLL.GetTokenByEmail(usuario.Email);

            return true;
        }

        /// <summary>
        /// Exclui uma regra da base de dados
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<bool> ExcluirClaimsByJson(string json)
        {
            var regras = base.GeraListaClaims(json);
            var usuario = this._usuarioDAO.GetById(base.ListaDeClaims.FirstOrDefault().UserId);

            var aspNetUser = await this._userManager.FindByEmailAsync(usuario.Email);

            await this._userManager.RemoveClaimsAsync(aspNetUser, regras);
            this._claimsDAO.DeleteClaims(UserClaimFactory.TransformInClaimByList(regras, false));
            await _tokenGeradorBLL.GetTokenByEmail(usuario.Email);

            return true;
        }

        /// <summary>
        /// Bloquea uma regra para ser usada
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<bool> BloquearClaimsByJson(string json)
        {
            var listaDeClaims = base.GeraListaClaims(json);
            var usuario = this._usuarioDAO.GetById(base.ListaDeClaims.FirstOrDefault().UserId);
            var listaDeUserClaims = base.GeraListaDeUserClaims(false);

            this._claimsDAO.UpdateClaims(listaDeUserClaims);

            await _tokenGeradorBLL.GetTokenByEmail(usuario.Email);
            return true;
        }

        /// <summary>
        /// Liberar uma regra 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<bool> LiberarClaimsByJson(string json)
        {
            var regras = base.GeraListaClaims(json);
            var usuario = this._usuarioDAO.GetById(base.ListaDeClaims.FirstOrDefault().UserId);
            var listaDeUserClaims = base.GeraListaDeUserClaims(true);
            this._claimsDAO.UpdateClaims(listaDeUserClaims);

            await _tokenGeradorBLL.GetTokenByEmail(usuario.Email);
            return true;
        }



    }
}

