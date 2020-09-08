using Microsoft.EntityFrameworkCore;
using Models.Despesas;
using System.Threading.Tasks;

namespace DAL.Despesas.Interfaces
{
    public interface ITipoDespesaDAO
    {
        DbSet<TipoDespesa> GetAll();
        Task<bool> AddSysnc<TSource>(TSource item);
        Task<bool> UpdateAsync<TSource>(TSource item);
        Task<bool> DeleteAsync<TSource>(TSource item);
    }
}
