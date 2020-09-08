using Models.Admin;
using Models.Admin.Json.Outputs;
using Models.Admin.ModelView;
using Models.Admin.Outputs.HttpResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface IUsuarioBLL
    {
        Task<IList<UsuarioJsonResult>> ListarUsuariosJson();
        Task<bool> UnlockLockUser(string email);
        Task<bool> UnlockLockUserById(int userId);
        Task<HttpResposta> EfetuarLoginApi(Login user);
        Task<HttpResposta> EfetuarLoginApp(Login user);

        Task<HttpResposta> CriarUsuario(Login registerUser);

        Task<bool> ExcluirUsuario(Login registerUser);

        Task<bool> UsuarioEstaLogado(Usuario usuario);
        Task Logout(Usuario usuario);
        Task<Usuario> GetUsuarioPeloEmailAsync(string email);
        Usuario GetUsuarioPeloEmail(string email);
        Task<HttpResposta> CriarUsuarioSimplificado(Login registerUser);
    }
}
