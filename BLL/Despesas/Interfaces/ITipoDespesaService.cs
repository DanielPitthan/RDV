using Models.Despesas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Despesas.Interfaces
{
    public interface ITipoDespesaService
    {
        Task<bool> CriarTipoDespesa(TipoDespesa tipoDespesa);
        Task<bool> AlterarTipoDespesa(TipoDespesa tipoDespesa);
        Task<bool> ExcluirTipoDespesa(TipoDespesa tipoDespesa);

        Task<IList<TipoDespesa>> ListarTudo();

        Task<TipoDespesa> GetByIdAsync(int id);
        TipoDespesa GetById(int id);
    }
}
