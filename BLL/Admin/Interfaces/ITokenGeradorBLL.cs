﻿using Models.Admin.Json;
using Models.Admin.Json.Outputs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface ITokenGeradorBLL
    {
        Task<UserTokenResult> GetTokenByEmail(string email, IList<Claim> claimsPersonalizadas=null);
    }
}
