using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface IClaimsControleBLL
    {
        Task<bool> IncluirClaimsByJson(string json);
        Task<bool> ExcluirClaimsByJson(string json);
        Task<bool> BloquearClaimsByJson(string json);
        Task<bool> LiberarClaimsByJson(string json);
    }
}