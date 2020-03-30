
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin.Interfaces
{
    public interface IEmpresaRegraDAO
    {
        Task<bool> Save(EmpresaRegra regra);

        Task<bool> Update(EmpresaRegra regra);

        Task<bool> Delete(EmpresaRegra regra);

        Task<IList<EmpresaRegra>> GetByUsuarioIdAsync(int id);
        Task<IList<EmpresaRegra>> GetByEmpresaIdAsync(int id);
    }
}
