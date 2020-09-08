using Models.Admin;
using System.Collections.Generic;
using System.Security.Claims;

namespace Factorys.AccountFactorys
{
    public static class EmpresaRegraFactory
    {
        /// <summary>
        /// Gerar uma lista de Claims com base nas regras da empresa
        /// </summary>
        /// <param name="regrasEmpresa"></param>
        /// <returns></returns>
        public static IList<Claim> GenerateByEmpresaRegraList(IList<EmpresaRegra> regrasEmpresa)
        {
            IList<Claim> claimsPersonalizadas = new List<Claim>();
            foreach (var r in regrasEmpresa)
            {
                claimsPersonalizadas.Add(new Claim(r.Regra, r.Valor));
            }
            return claimsPersonalizadas;
        }
    }
}
