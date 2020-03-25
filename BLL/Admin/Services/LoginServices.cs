using BLL.Admin.Interfaces;
using ContexBinds.EntityCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Admin.Services
{
    public class LoginServices:ILoginService
    {
        private ContextBind contexto;

        public LoginServices(ContextBind context)
        {
            this.contexto = context;
        }
        public Task<bool> Validate(Login login)
        {
            CryptographyHelper.CryptographyText(login.Senha);
            return Task<bool>.FromResult(true);
        }
    }
}
