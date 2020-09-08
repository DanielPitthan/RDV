using Models.Admin;
using Models.Admin.Json.Outputs;

namespace Factorys.AccountFactorys
{
    public static class EmpresaFactory
    {
        public static Empresa GeraEmpresa(EmpresaJson empresaJson)
        {
            Empresa empresa = new Empresa()
            {
                Cnpj = empresaJson.Cnpj,
                NomeFantasia = empresaJson.NomeFantasia,
                RazaoSocial = empresaJson.RazaoSocial
            };
            return empresa;
        }

        public static EmpresaRegra GeraEmpresaRegra(EmpresaRegraJson empresRegraJson)
        {
            EmpresaRegra empresaRegra = new EmpresaRegra()
            {
                EmpresaId = empresRegraJson.EmpresaId,
                Regra = empresRegraJson.Regra,
                Valor = empresRegraJson.Valor,
                Id = empresRegraJson.Id
            };
            return empresaRegra;
        }
    }
}
