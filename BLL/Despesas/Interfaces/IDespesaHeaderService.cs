using Models.Despesas;
using System.Threading.Tasks;

namespace BLL.Despesas.Interfaces
{
    public interface IDespesaHeaderService
    {
        Task<bool> CriarItemAsync(DespesaHeader despesaHeader);
        Task<bool> AlterarItemAsync(DespesaHeader despesaHeader);
        Task<bool> ExcluirItemAsync(DespesaHeader despesaHeader);
    }
}
