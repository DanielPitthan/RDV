using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDV.Filters;

namespace RDV.Areas.ApisTeste
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTesteController : ControllerBase
    {


        // GET api/values
        [HttpGet]
        //Todos os usuários que pertencem a regra Admin e tem valor igual a ALL       
        //Podem acessar esse método
        [ClaimsAuthorize("Admin", "All")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [ClaimsAuthorize("ValueApi", "Post")]
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return "Success!";
        }

        // PUT api/values/5        
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<string>> Put(int id, [FromBody] string value)
        {
            return new string[] { "Produto 01", "Produto 02", "Produtos Alterados com sucesso" };
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}