using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Admin;

namespace BLL.Admin.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Validate(Login login);
    }
}
