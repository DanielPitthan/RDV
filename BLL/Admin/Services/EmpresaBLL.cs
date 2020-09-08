using BLL.Admin.Interfaces;
using DAL.Admin.Interfaces;
using Factorys.AccountFactorys;
using Models.Admin;
using Models.Admin.Json.Outputs;
using Models.Admin.Outputs.HttpResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.AccountsBLL
{
    public class EmpresaBLL : IEmpresaBLL
    {
        private IEmpresaDAO _empresaDAO;
        private IEmpresaRegraDAO _empresaRegraDAO;

        public EmpresaBLL(IEmpresaDAO empresaDAO, IEmpresaRegraDAO empresaRegraDAO)
        {
            this._empresaDAO = empresaDAO;
            this._empresaRegraDAO = empresaRegraDAO;
        }

        /// <summary>
        /// Retorna a relação de empresas do sistema
        /// </summary>
        /// <returns></returns>
        public IList<Empresa> ListarEmpresas()
        {
            var resultado = this._empresaDAO.List();
            return resultado;
        }

        /// <summary>
        /// Faz a criação da Empresa
        /// </summary>
        /// <param name="empresaJson"></param>
        /// <returns></returns>
        public async Task<HttpResposta> CriarEmpresa(EmpresaJson empresaJson)
        {
            var located = this._empresaDAO.GetByCnpj(empresaJson.Cnpj);
            if (located != null)
            {
                return new HttpResposta()
                {
                    Message = new string[] { "Empresa já cadastrada" },
                    Succeeded = false
                };
            }

            Empresa empresa = EmpresaFactory.GeraEmpresa(empresaJson);
            empresa.Ativa = true;
            await this._empresaDAO.SaveAsync(empresa);
            return new HttpResposta()
            {
                Message = new string[] { "Empresa cadastrada com sucesso" },
                Succeeded = true
            };
        }

        /// <summary>
        /// Faz o bloqueia da Empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResposta> BloquearEmpresa(int id)
        {
            Empresa empresa = this._empresaDAO.GetById(id);
            empresa.Ativa = false;

            bool resultado = await this._empresaDAO.SaveAsync(empresa);

            return new HttpResposta()
            {
                Message = new string[] { "Empresa bloqueada" },
                Succeeded = resultado
            };
        }
        /// <summary>
        /// Faz a Liberação da Empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResposta> LiberarEmpresa(int id)
        {
            Empresa empresa = this._empresaDAO.GetById(id);
            empresa.Ativa = true;

            bool resultado = await this._empresaDAO.SaveAsync(empresa);

            return new HttpResposta()
            {
                Message = new string[] { "Empresa liberada" },
                Succeeded = resultado
            };
        }

        /// <summary>
        /// Inclui uma nova regra para a empresa em questão
        /// </summary>
        /// <param name="empresaRegra"></param>
        /// <returns></returns>
        public async Task<HttpResposta> AdcionarRegra(EmpresaRegra empresaRegra)
        {
            EmpresaRegra regra = new EmpresaRegra()
            {
                EmpresaId = empresaRegra.EmpresaId,
                Regra = empresaRegra.Regra,
                Valor = empresaRegra.Valor
            };

            await this._empresaRegraDAO.Save(empresaRegra);

            return new HttpResposta()
            {
                Message = new string[] { "Regra Adicionada" },
                Succeeded = true
            };
        }

        /// <summary>
        /// Exclui uma regra para empresa em questão
        /// </summary>
        /// <param name="empresaRegra"></param>
        /// <returns></returns>
        public async Task<HttpResposta> ExcluirRegra(EmpresaRegra empresaRegra)
        {
            EmpresaRegra regra = new EmpresaRegra()
            {
                EmpresaId = empresaRegra.EmpresaId,
                Regra = empresaRegra.Regra,
                Valor = empresaRegra.Valor
            };

            await this._empresaRegraDAO.Delete(empresaRegra);

            return new HttpResposta()
            {
                Message = new string[] { "Regra Excluida" },
                Succeeded = true
            };
        }



    }
}
