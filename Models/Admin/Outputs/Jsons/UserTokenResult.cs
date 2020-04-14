﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Models.Admin.Json.Outputs
{
    public class UserTokenResult
    {

        public  UserToken Token { get; set; }
        public  IList<UserClaims> UserClaims { get; set; }
        public  bool succeeded { get; set; }
        public  ClaimsIdentity ClaimsIdentity { get; set; }
    }
}
