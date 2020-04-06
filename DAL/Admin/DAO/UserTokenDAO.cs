using ContexBinds.EntityCore;
using DAL.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin.DAO
{
    public class UserTokenDAO : IUserTokenDAO
    {
        private ContextBind contexto;

        public UserTokenDAO(ContextBind _context)
        {
            this.contexto = _context;
        }

        public async Task<bool> SaveAsync(UserToken userToken)
        {
            await contexto.UserToken.AddAsync(userToken);
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(UserToken userToken)
        {
            contexto.Entry(userToken).State = EntityState.Modified;
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> DeleteAsync(UserToken userToken)
        {
            contexto.UserToken.Remove(userToken);
            var result = await contexto.SaveChangesAsync();
            return result > 0;
        }

        public DbSet<UserToken> ListAll()
        {
            return contexto.UserToken;
        }
    }
}
