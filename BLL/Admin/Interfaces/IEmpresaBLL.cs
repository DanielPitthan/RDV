using Models.Admin;
using Models.Admin.Json;
using Models.Admin.Json.Outputs;
using Models.Admin.Outputs;
using Models.Admin.Outputs.HttpResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface IEmpresaBLL
    {
        IList<Empresa> ListarEmpresas();
        Task<HttpResponse> CriarEmpresa(EmpresaJson empresaJson);
        Task<HttpResponse> BloquearEmpresa(int id);
        Task<HttpResponse> LiberarEmpresa(int id);
        Task<HttpResponse> AdcionarRegra(EmpresaRegra empresaRegra);
        Task<HttpResponse> ExcluirRegra(EmpresaRegra empresaRegra);
    }
}
