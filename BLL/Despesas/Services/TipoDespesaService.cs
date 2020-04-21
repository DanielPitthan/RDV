using BLL.Despesas.Interfaces;
using DAL.Despesas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Despesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Despesas.Services
{
    public class TipoDespesaService : ITipoDespesaService
    {

        private readonly ITipoDespesaDAO tipoDespesa;

        public TipoDespesaService(ITipoDespesaDAO _tipoDespesaDAO)
        {
            this.tipoDespesa = _tipoDespesaDAO;
        }
        public async Task<bool> AlterarTipoDespesa(TipoDespesa tipoDespesa)
        {
            return await this.tipoDespesa.UpdateAsync(tipoDespesa)
                                         .ConfigureAwait(false);
        }

        public async Task<bool> CriarTipoDespesa(TipoDespesa tipoDespesa)
        {
            return await this.tipoDespesa.SaveAsync(tipoDespesa)
                                          .ConfigureAwait(false);
        }

        public async Task<bool> ExcluirTipoDespesa(TipoDespesa tipoDespesa)
        {
            return await this.tipoDespesa.DeleteAsync(tipoDespesa)
                                            .ConfigureAwait(false);
        }

        public async Task<TipoDespesa> GetByIdAsync(int id)
        {
            var tipo = await this.tipoDespesa.GetAll().Where(x => x.Id == id).SingleOrDefaultAsync();
            return tipo;
        }

     
        public async Task<IList<TipoDespesa>> ListarTudo()
        {
            var despesas = await this.tipoDespesa.GetAll().ToListAsync();
            return despesas;
        }

        public TipoDespesa GetById(int id)
        {
            var tipo = this.tipoDespesa.GetAll()
                            .Where(x => x.Id == id)
                            .SingleOrDefault();
            return tipo;
        }
    }
}
