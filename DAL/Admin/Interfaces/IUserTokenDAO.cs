using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
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
