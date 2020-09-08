using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System.Threading.Tasks;

namespace DAL.Admin.Interfaces
{
    public interface IUserTokenDAO
    {
        DbSet<UserToken> ListAll();
        Task<bool> UpdateAsync(UserToken empresa);
        Task<bool> SaveAsync(UserToken empresa);
        Task<bool> DeleteAsync(UserToken empresa);
    }
}
