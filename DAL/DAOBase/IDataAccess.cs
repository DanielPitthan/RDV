using System.Threading.Tasks;

namespace DAL.DAOBase
{
    public interface IDataAccess
    {
        Task<bool> AddSysnc<TSource>(TSource item);
        Task<bool> UpdateAsync<TSource>(TSource item);
        Task<bool> DeleteAsync<TSource>(TSource item);
    }
}
