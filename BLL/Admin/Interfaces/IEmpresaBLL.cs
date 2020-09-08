using Models.Admin;
using Models.Admin.Json.Outputs;
using Models.Admin.Outputs.HttpResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface IEmpresaBLL
    {
        IList<Empresa> ListarEmpresas();
        Task<HttpResposta> CriarEmpresa(EmpresaJson empresaJson);
        Task<HttpResposta> BloquearEmpresa(int id);
        Task<HttpResposta> LiberarEmpresa(int id);
        Task<HttpResposta> AdcionarRegra(EmpresaRegra empresaRegra);
        Task<HttpResposta> ExcluirRegra(EmpresaRegra empresaRegra);
    }
}
