using Models.Despesas;
using System.Threading.Tasks;

namespace BLL.Despesas.Interfaces
{
    public interface IDespesaService
    {
        Task<bool> CriarDespesaAsync(Despesa despesa);
        Task<bool> AlterarDespesaAsync(Despesa despesa);
        Task<bool> ExcluirDespesaAsync(Despesa despesa);
    }
}
