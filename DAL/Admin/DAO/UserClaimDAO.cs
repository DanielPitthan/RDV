using ContexBinds.EntityCore;
using DAL.Admin.Interfaces;
using Models.Admin;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Admin.DAO

{
    public class UserClaimDAO : IUserClaimDAO
    {
        private ContextBind _contexto;

        public UserClaimDAO(ContextBind contexto)
        {
            this._contexto = contexto;
        }

        /// <summary>
        /// Atualiza uma Claim do usuário 
        /// Exclui as Claims atuais e insere novas e atualizadas
        /// </summary>
        /// <param name="idToken"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public bool UpdateClaims(IList<UserClaims> claims)
        {
            if (!DeleteClaims(claims))
            {
                return false;
            }

            foreach (var claim in claims)
            {
                InsertClaim(claim);
            }

            return true;
        }
        public bool InsertClaim(UserClaims claim)
        {

            this._contexto.UserClaims.Add(claim);
            this._contexto.SaveChanges();

            return true;
        }
        /// <summary>
        /// Insere multiplas claims 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public bool InsertClaims(IList<UserClaims> claims)
        {
            foreach (var item in claims)
            {
                InsertClaim(item);
            }
            return true;
        }

        /// <summary>
        /// Faz a exclusão de uma Claim 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public bool DeleteClaim(UserClaims claim)
        {

            this._contexto.UserClaims.Remove(claim);
            _contexto.SaveChanges();
            return true;
        }

        /// <summary>
        /// Faz a exclusão das Claims
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public bool DeleteClaims(IList<UserClaims> claims)
        {
            foreach (var claim in claims)
            {
                DeleteClaim(claim);
            }
            return true;
        }

        public IList<UserClaims> GetByUser(Usuario usuario)
        {
            var usersClaims = this._contexto.Usuario
                        .Where(u => u.Id == usuario.Id)
                        .SingleOrDefault();

            return usersClaims.UserClaims;
        }

    }
}

