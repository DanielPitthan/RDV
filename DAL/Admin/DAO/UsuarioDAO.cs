using ContexBinds.EntityCore;
using ContextBinds;
using DAL.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private ContextBind contexto;

        public UsuarioDAO(ContextBind context)
        {
            this.contexto = context;
        }

        public IList<Usuario> List()
        {
            var lista = contexto.Usuario.ToList();
            return lista;

        }

        /// <summary>
        /// Salva um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool Save(Usuario usuario)
        {
            contexto.Usuario.Add(usuario);
            contexto.SaveChanges();
            return true;
        }
        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public bool Update(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Modified;
            contexto.SaveChanges();
            return true;
        }

        /// <summary>
        /// Atualiza os Tokens
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool UpdateToken(UserToken token)
        {
            this.contexto.Entry(token).State = EntityState.Modified;
            this.contexto.SaveChanges();
            return true;
        }



        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public bool Delete(Usuario usuario)
        {
            contexto.Usuario.Remove(usuario);
            contexto.SaveChanges();
            return true;
        }

        public Usuario GetById(int id)
        {

            Usuario usuario = contexto.Usuario
                                    .Where(u => u.Id == id)
                                     .Include(u => u.UserToken)
                                     .Include(t => t.UserClaims)
                                     .Include(e => e.Empresa)
                                    .SingleOrDefault();
            return usuario;
        }

        public Usuario GetByAspNetId(string id)
        {
            Usuario usuario = contexto.Usuario
                                    .Where(u => u.AspNetUsersId == id)
                                     .Include(u => u.UserToken)
                                     .Include(t => t.UserClaims)
                                     .Include(e => e.Empresa)
                                    .SingleOrDefault();

            return usuario;
        }


        /// <summary>
        /// Faz o bloqueio de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> bool</returns>
        public bool LockUnlock(Usuario usuario, bool isLocked)
        {
            usuario.Ativo = isLocked;
            return this.Update(usuario);
        }


        /// <summary>
        /// Obtem o Id do usuário pelo Token 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int GetUsuarioIdByToken(string token)
        {
            var usuario = this.contexto.Usuario
                                       .Where(u => u.UserToken.Token == token)
                                       .SingleOrDefault();
            return usuario.Id;
        }
    }
}
