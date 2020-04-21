using Models.Admin;
using Models.Admin.Json;
using Models.Admin.Json.Outputs;
using Models.Admin.ModelView;
using Models.Admin.Outputs;
using Models.Admin.Outputs.HttpResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface IUsuarioBLL
    {
        Task<IList<UsuarioJsonResult>> ListarUsuariosJson();
        Task<bool> UnlockLockUser(string email);
        Task<bool> UnlockLockUserById(int userId);
        Task<HttpResponse> EfetuarLogin(Login user);

        Task<HttpResponse> CriarUsuario(Login registerUser);

        Task<bool> ExcluirUsuario(Login registerUser);
     
        Task<bool> UsuarioEstaLogado(Usuario usuario);
        Task Logout(Usuario usuario);
        Task<Usuario> GetUsuarioPeloEmail(string email);
        Task<HttpResponse> CriarUsuarioSimplificado(Login registerUser);
    }
}
