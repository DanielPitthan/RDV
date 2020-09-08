using BLL.Despesas.Interfaces;
using DAL.Despesas.Interfaces;
using Models.Despesas;
using System.Threading.Tasks;

namespace BLL.Despesas.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaDAO despesaDAO;

        public DespesaService(IDespesaDAO _despesaDAO)
        {
            this.despesaDAO = _despesaDAO;
        }

        public async Task<bool> AlterarDespesaAsync(Despesa despesa)
        {
            return await this.despesaDAO.UpdateAsync<Despesa>(despesa);
        }

        public async Task<bool> CriarDespesaAsync(Despesa despesa)
        {
            return await this.despesaDAO.AddSysnc<Despesa>(despesa);
        }

        public async Task<bool> ExcluirDespesaAsync(Despesa despesa)
        {
            return await this.despesaDAO.DeleteAsync<Despesa>(despesa);
        }
    }
}
