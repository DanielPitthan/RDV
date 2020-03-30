using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Admin.Json.Outputs
{
    public class UserTokenResult
    {

        public virtual UserToken Token { get; set; }
        public virtual IList<UserClaims> UserClaims { get; set; }
    }
}
