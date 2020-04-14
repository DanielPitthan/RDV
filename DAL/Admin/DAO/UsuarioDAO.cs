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

        public DbSet<Usuario> ListAll()
        {
            var lista = contexto.Usuario;
            return lista;

        }

        /// <summary>
        /// Salva um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(Usuario usuario)
        {
            await contexto.Usuario.AddAsync(usuario);
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }
        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Modified;
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Atualiza os Tokens
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> UpdateToken(UserToken token)
        {           
            this.contexto.Entry(token).State = EntityState.Modified;
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public async Task<bool> DeleteAsync(Usuario usuario)
        {
            contexto.Usuario.Remove(usuario);
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {

            Usuario usuario =await  contexto.Usuario
                                    .Where(u => u.Id == id)
                                     .Include(u => u.UserToken)
                                     .Include(t => t.UserClaims)
                                     .Include(e => e.Empresa)
                                    .SingleOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> GetByAspNetIdAsync(string id)
        {
            try
            {
                var usuario = await contexto.Usuario.Where(u => u.AspNetUsersId == id)
                                    .Include(u => u.UserToken)
                                    .Include(t => t.UserClaims)
                                    .Include(e => e.Empresa)                                    
                                    .SingleOrDefaultAsync();
                return usuario;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            return new Usuario();
        }


        /// <summary>
        /// Faz o bloqueio de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> bool</returns>
        public async Task<bool> LockUnlock(Usuario usuario, bool isLocked)
        {
            usuario.Ativo = isLocked;
            return await this.UpdateAsync(usuario);
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
