
using Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Admin.Interfaces
{
    public interface IEmpresaDAO
    {
        Empresa GetById(int id);
        Empresa GetByCnpj(string cnpj);
        IList<Empresa> List();
        Task<bool> UpdateAsync(Empresa empresa);
        Task<bool> SaveAsync(Empresa empresa);
        Task<bool> DeleteAsync(Empresa empresa);
    }
}
