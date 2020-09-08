using Models.Admin.ModelView;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Validate(Login login);
    }
}
