using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Cadastros.CentroCustos.Interfaces
{
    public interface ICentroCustoService
    {
        Task<bool> CriarCentroCustoAsync(CentroCusto centroCusto);
        Task<bool> AlterarCentroCustoAsync(CentroCusto centroCusto);
        Task<bool> ExcluirCentroCustoAsync(CentroCusto centroCusto);

        Task<IList<CentroCusto>> ListarTudoAsync();


    }
}
