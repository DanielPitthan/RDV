using ContexBinds.EntityCore;
using DAL.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Admin.DAO
{
    public class EmpresaDAO : IEmpresaDAO
    {
        private ContextBind _contexto;

        public EmpresaDAO(ContextBind contexto)
        {
            this._contexto = contexto;
        }
        public Empresa GetByCnpj(string cnpj)
        {
            var empresa = this._contexto.Empresa
                          .Where(x => x.Cnpj == cnpj)
                          .SingleOrDefault();
            return empresa;
        }

        public Empresa GetById(int id)
        {
            var empresa = this._contexto.Empresa
                          .Where(x => x.Id == id)
                          .SingleOrDefault();
            return empresa;
        }

        public IList<Empresa> List()
        {
            var empresa = this._contexto.Empresa.ToList();
            return empresa;
        }

        public async Task<bool> SaveAsync(Empresa empresa)
        {
            _contexto.Empresa.Add(empresa);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Empresa empresa)
        {
            _contexto.Entry(empresa).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Empresa empresa)
        {
            _contexto.Empresa.Remove(empresa);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
