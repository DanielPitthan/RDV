using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Admin.Interfaces
{
    public interface IUsuarioDAO
    {
        IList<Usuario> List();

        bool Save(Usuario usuario);
        bool Delete(Usuario usuario);
        bool Update(Usuario usuario);

        /// <summary>
        /// Faz o bloqueio de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> bool</returns>
        bool LockUnlock(Usuario usuario,bool isLocked);       

        /// <summary>
        /// Retorna um usuário pelo o Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Usuario GetById(int id);
        /// <summary>
        /// Retorna um usuário pelo o Id do AspNet
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Usuario GetByAspNetId(string id);

        /// <summary>
        /// Atualiza um token atravéz da proc
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool UpdateToken(UserToken token);

        /// <summary>
        /// Retorna o usuário através da chave do token 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        int GetUsuarioIdByToken(string token);

    }
}
