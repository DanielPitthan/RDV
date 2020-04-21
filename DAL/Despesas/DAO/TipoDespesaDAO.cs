using ContexBinds.EntityCore;
using DAL.Despesas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Despesas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Despesas.DAO
{
    public class TipoDespesaDAO : ITipoDespesaDAO
    {
        private readonly ContextBind contexto;

        public TipoDespesaDAO(ContextBind _contexto)
        {
            this.contexto = _contexto;
        }

        public async Task<bool> DeleteAsync(TipoDespesa tipoDespesa)
        {
            this.contexto.TipoDespesa.Remove(tipoDespesa);
            var rowsAffecteds = await this.contexto.SaveChangesAsync().ConfigureAwait(false);
            return rowsAffecteds > 0;
        }

        public DbSet<TipoDespesa> GetAll()
        {
            return this.contexto.TipoDespesa;
        }

        public async Task<bool> SaveAsync(TipoDespesa tipoDespesa)
        {
            this.contexto.TipoDespesa.Add(tipoDespesa);
            var rowsAffecteds = await this.contexto.SaveChangesAsync().ConfigureAwait(false);
            return rowsAffecteds > 0;
        }

        public async Task<bool> UpdateAsync(TipoDespesa tipoDespesa)
        {
            this.contexto.Entry(tipoDespesa).State = EntityState.Modified;
            var rowsAffecteds = await contexto.SaveChangesAsync().ConfigureAwait(false);
            return rowsAffecteds > 0;
        }
    }
}
