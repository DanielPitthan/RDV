using Factorys.AccountFactorys;
using Models.Admin;
using Models.Admin.Json.Outputs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.AccountsBLL
{
    public abstract class ClaimControle
    {
        public ICollection<UserClaimJson> ListaDeClaims { get; set; }
        public IList<UserClaims> Regras { get; set; }

        public ICollection<Claim> GeraListaClaims(string json)
        {
            ListaDeClaims = JsonConvert.DeserializeObject<ICollection<UserClaimJson>>(json);
            return UserClaimFactory.CriaListaClaim(ListaDeClaims);
        }

        public IList<UserClaims> GeraListaDeUserClaims(bool status)
        {
            ICollection<Claim> claim = UserClaimFactory.CriaListaClaim(this.ListaDeClaims);
            return UserClaimFactory.TransformInClaimByList(claim, status);
        }
    }
}
