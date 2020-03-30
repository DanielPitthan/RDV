using Models.Admin;
using Models.Admin.Json.Outputs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Factorys.AccountFactorys
{
    public static class UserClaimFactory
    {
        /// <summary>
        /// Transforma uma UserClaim em Claim
        /// </summary>
        /// <param name="claim"></param>
        /// <returns></returns>
        public static UserClaims TransformInClaim(Claim claim,bool ativo)
        {
            UserClaims claims = new UserClaims()
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value                ,
                Ativo = ativo
            };
            return claims;
        }

        /// <summary>
        /// Gera uma lista de UserClaim com base em uma lista de Claims
        /// </summary>
        /// <param name="claimsList"></param>
        /// <returns></returns>
        public static IList<UserClaims> TransformInClaimByList (ICollection<Claim> claimsList,bool ativo)
        {
            IList<UserClaims> claims = new List<UserClaims>();
            foreach (var item in claimsList)
            {
                claims.Add(TransformInClaim(item,ativo));
            }
            return claims;
        }

        /// <summary>
        /// Cria uma lista de Claims com base em um lista de UserClaimJson
        /// </summary>
        /// <param name="listaClaims"></param>
        /// <returns></returns>
        public static ICollection<Claim> CriaListaClaim(ICollection<UserClaimJson> listaClaims)
        {
            ICollection<Claim> factory = new List<Claim>();
            foreach (var item in listaClaims)
            {
                factory.Add(new Claim(item.ClaimType, item.ClaimValue));
            }
            return factory;
        }


    }
}
