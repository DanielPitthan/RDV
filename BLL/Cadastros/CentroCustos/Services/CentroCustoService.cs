using BLL.Cadastros.CentroCustos.Interfaces;
using DAL.Cadastros.CentroCustos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Cadastros.CentroCustos.Services
{
    public class CentroCustoService : ICentroCustoService
    {
        private readonly ICentroCustoDAO centroCustoDAO;

        public CentroCustoService(ICentroCustoDAO _centroCustoDAO)
        {
            this.centroCustoDAO = _centroCustoDAO;
        }

        public async Task<bool> AlterarCentroCustoAsync(CentroCusto centroCusto)
        {
           return await this.centroCustoDAO.UpdateAsync(centroCusto);
        }

        public async Task<bool> CriarCentroCustoAsync(CentroCusto centroCusto)
        {
            return await this.centroCustoDAO.AddSysnc(centroCusto);
        }

        public async Task<bool> ExcluirCentroCustoAsync(CentroCusto centroCusto)
        {
            return await this.centroCustoDAO.DeleteAsync(centroCusto);
        }

        public async Task<IList<CentroCusto>> ListarTudoAsync()
        {
            var centroCustos = await this.centroCustoDAO.GetAll().ToListAsync();
            return centroCustos;
        }
    }
}
