using Microsoft.EntityFrameworkCore;
using Models.Admin;
using Models.Admin.Json.Outputs;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface ITokenGeradorBLL
    {
        Task<UserTokenResult> GetTokenByEmail(string email, IList<Claim> claimsPersonalizadas = null, ApplicationUser user = null);
        Task<bool> AlterarTokenAsync(UserToken userToken);
        Task<bool> ExcluirTokenAsync(UserToken userToken);
        Task<bool> IncluirTokenAsync(UserToken userToken);
        DbSet<UserToken> ListAll();
    }
}
