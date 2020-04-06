using BLL.Admin.Interfaces;
using ContexBinds.EntityCore;
using Models.Admin.ModelView;
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
            CryptographyHelper.CryptographyText(login.Password);


            return Task<bool>.FromResult(true);
        }
    }
}
