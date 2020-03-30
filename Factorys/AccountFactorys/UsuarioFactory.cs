using Models.Admin;
using Models.Admin.Json.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factorys.AccountFactorys
{
    public static class UsuarioFactory
    {
        /// <summary>
        /// Gera um usuário Json 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static UsuarioJsonResult GeraUsuarioJson(Usuario usuario)
        {
            UsuarioJsonResult usuarioJsonResult = new UsuarioJsonResult()
            {                
                Ativo = usuario.Ativo,
                Id = usuario.Id,
                Email = usuario.Email
                
            };
            return usuarioJsonResult;
        }


        /// <summary>
        /// Gera a lista de usuárioJson com base em uma lista de usuário 
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public static IList<UsuarioJsonResult> GeraUsuarioJsonByList(IList<Usuario> usuarios)
        {
            IList<UsuarioJsonResult> usuarioJsonResults = new List<UsuarioJsonResult>();

            foreach (var item in usuarios)
            {
                usuarioJsonResults.Add(GeraUsuarioJson(item));
            }
            return usuarioJsonResults;
        }
    }
}
