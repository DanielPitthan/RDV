using BLL.Despesas.Interfaces;
using DAL.Despesas.Interfaces;
using Models.Despesas;
using System.Threading.Tasks;

namespace BLL.Despesas.Services
{
    class DespesaHeaderService : IDespesaHeaderService
    {
        private readonly IDespesaHeaderDAO despesaHeaderDAO;

        public DespesaHeaderService(IDespesaHeaderDAO _despesaHeaderDAO)
        {
            this.despesaHeaderDAO = _despesaHeaderDAO;
        }

        public async Task<bool> AlterarItemAsync(DespesaHeader despesaHeader)
        {
            return await this.despesaHeaderDAO.UpdateAsync<DespesaHeader>(despesaHeader);
        }

        public async Task<bool> CriarItemAsync(DespesaHeader despesaHeader)
        {
            return await this.despesaHeaderDAO.AddSysnc<DespesaHeader>(despesaHeader);
        }

        public async Task<bool> ExcluirItemAsync(DespesaHeader despesaHeader)
        {
            return await this.despesaHeaderDAO.DeleteAsync<DespesaHeader>(despesaHeader);
        }
    }
}
