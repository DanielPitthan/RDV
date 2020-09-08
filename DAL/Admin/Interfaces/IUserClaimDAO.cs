
using Models.Admin;
using System.Collections.Generic;

namespace DAL.Admin.Interfaces
{
    public interface IUserClaimDAO
    {
        bool InsertClaim(UserClaims claim);
        bool InsertClaims(IList<UserClaims> claim);
        bool UpdateClaims(IList<UserClaims> claims);

        bool DeleteClaim(UserClaims claim);
        bool DeleteClaims(IList<UserClaims> claim);

        IList<UserClaims> GetByUser(Usuario usuario);

    }
}
