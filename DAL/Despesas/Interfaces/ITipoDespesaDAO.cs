using Microsoft.EntityFrameworkCore;
using Models.Despesas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Despesas.Interfaces
{
    public interface ITipoDespesaDAO
    {
        DbSet<TipoDespesa> GetAll();
        Task<bool> UpdateAsync(TipoDespesa empresa);
        Task<bool> SaveAsync(TipoDespesa empresa);
        Task<bool> DeleteAsync(TipoDespesa empresa);
    }
}
