using DAL.DAOBase;
using Microsoft.EntityFrameworkCore;
using Models.Cadastros;
using System.Threading.Tasks;

namespace DAL.Cadastros.CentroCustos.Interfaces
{
    public interface ICentroCustoDAO
    {
        Task<bool> AddSysnc<TSource>(TSource item);
        Task<bool> UpdateAsync<TSource>(TSource item);
        Task<bool> DeleteAsync<TSource>(TSource item);
        DbSet<CentroCusto> GetAll();
    }
}
