using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Admin.Interfaces
{
    public interface IUsuarioDAO
    {
        DbSet<Usuario> ListAll();

        Task<bool> SaveAsync(Usuario usuario);
        Task<bool> DeleteAsync(Usuario usuario);
        Task<bool> UpdateAsync(Usuario usuario);

        /// <summary>
        /// Faz o bloqueio de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> bool</returns>
        Task<bool> LockUnlock(Usuario usuario, bool isLocked);

        /// <summary>
        /// Retorna um usuário pelo o Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Usuario> GetByIdAsync(int id);
        /// <summary>
        /// Retorna um usuário pelo o Id do AspNet
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Usuario> GetByAspNetIdAsync(string id);

        /// <summary>
        /// Atualiza um token atravéz da proc
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> UpdateToken(UserToken token);

        /// <summary>
        /// Retorna o usuário através da chave do token 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        int GetUsuarioIdByToken(string token);

    }
}
