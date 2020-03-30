using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Admin.Interfaces;
using Factorys.AccountFactorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Admin;
using Models.Admin.Json.Outputs;

namespace RDV.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private IEmpresaBLL _empresaBLL;

        public EmpresaController(IEmpresaBLL empresaBLL)
        {
            this._empresaBLL = empresaBLL;
        }

        /// <summary>
        /// retorna uma lista de empresas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarEmpresas")]
        public JsonResult List()
        {
            var result = this._empresaBLL.ListarEmpresas();
            return new JsonResult(result);
        }

        /// <summary>
        /// Faz o cadastro de uma nova empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] EmpresaJson empresa)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = ModelState.Values.SelectMany(e => e.Errors)
                });
            }
            var resultado = await this._empresaBLL.CriarEmpresa(empresa);

            return new JsonResult(resultado);
        }

        /// <summary>
        /// Faz o bloqueio de uma empresa pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Bloquear")]
        public async Task<JsonResult> Bloquear([FromHeader] int id)
        {
            var resultado = await this._empresaBLL.BloquearEmpresa(id);
            return new JsonResult(resultado);
        }

        /// <summary>
        /// Faz a liberação de uma empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Liberar")]
        public async Task<JsonResult> Liberar([FromHeader] int id)
        {
            var resultado = await this._empresaBLL.LiberarEmpresa(id);
            return new JsonResult(resultado);
        }

        /// <summary>
        /// Adiciona uma nova regra a empresa
        /// </summary>
        /// <param name="empresaRegra"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IncluirRegra")]
        public async Task<JsonResult> IncluirRegra([FromBody] EmpresaRegraJson empresaRegraJson)
        {
            if (!ModelState.IsValid)
            {
                new JsonResult(new { success = false, message = ModelState.Values.SelectMany(e => e.Errors) });
            }

            EmpresaRegra empresaRegra = EmpresaFactory.GeraEmpresaRegra(empresaRegraJson);

            var resultado = await this._empresaBLL.AdcionarRegra(empresaRegra);
            return new JsonResult(new { resultado });
        }

        /// <summary>
        /// Adiciona uma nova regra a empresa
        /// </summary>
        /// <param name="empresaRegra"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("excluirRegra")]
        public async Task<JsonResult> ExcluirRegra([FromBody] EmpresaRegraJson empresaRegraJson)
        {
            if (!ModelState.IsValid)
            {
                new JsonResult(new { success = false, message = ModelState.Values.SelectMany(e => e.Errors) });
            }

            EmpresaRegra empresaRegra = EmpresaFactory.GeraEmpresaRegra(empresaRegraJson);

            var resultado = await this._empresaBLL.ExcluirRegra(empresaRegra);
            return new JsonResult(new { resultado });
        }
    }
}