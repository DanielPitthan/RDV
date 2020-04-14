using BLL.Admin.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Admin;
using Models.Admin.ModelView;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RDV.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioBLL _usuarioBLL;
        private readonly ITokenGeradorBLL _tokenGeradorBLL;
        private readonly IClaimsControleBLL _claimControleBLL;

        public UsuariosController(
        IUsuarioBLL usuarioBLL,
        ITokenGeradorBLL tokenGeradorBLL,
        IClaimsControleBLL claimControleBLL)
        {
            this._usuarioBLL = usuarioBLL;
            this._tokenGeradorBLL = tokenGeradorBLL;
            this._claimControleBLL = claimControleBLL;
        }


        /// <summary>
        /// Lista os usuários do sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListaUsuarios")]
        [Produces("application/json")]
        public async Task<JsonResult> ListaUsuarios()
        {
            return new JsonResult(await this._usuarioBLL.ListarUsuariosJson());
        }


        /// <summary>
        /// Faz o bloqueio de um usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("Bloquear")]
        [Produces("application/json")]
        public async Task<JsonResult> BlockUser([FromHeader] int userId)
        {
            if (await this._usuarioBLL.UnlockLockUserById(userId))
            {
                return new JsonResult(new { success = true, menssager = "usuário bloqueado" });
            }
            return new JsonResult(new { success = false, menssager = "falha no bloqueio do usuário" });
        }

        /// <summary>
        /// Faz a liberação de um usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("Liberar")]
        [Produces("application/json")]
        public async Task<JsonResult> UnlockUser([FromHeader] int userId)
        {
            if (await this._usuarioBLL.UnlockLockUserById(userId))
            {
                return new JsonResult(new { success = true, menssager = "Usuário liberado." });
            }
            return new JsonResult(new { success = false, menssager = "Falha no bloqueio do usuário." });

        }

        /// <summary>
        /// Inclui um novo conjunto de regras para o usuário
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("IncluirRegra")]
        [Produces("application/json")]
        public async Task<JsonResult> AddClaim([FromBody] string json)
        {
            bool resultado = await this._claimControleBLL.IncluirClaimsByJson(json);
            if (resultado)
            {
                return new JsonResult(new
                {
                    success = true,
                    message = "Nova regra definada para o usuário"
                });
            }

            return new JsonResult(new
            {
                success = false,
                message = "Não foi possível definir uma regra para esse usuário"
            });
        }

        /// <summary>
        /// Faz a exclusão de uma regra específica
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("ExcluirRegra")]
        [Produces("application/json")]
        public async Task<JsonResult> RemoveClaim([FromBody] string json)
        {
            await this._claimControleBLL.ExcluirClaimsByJson(json);
            return new JsonResult(new { success = true, message = "Nova regra definada para o usuário" });
        }

        /// <summary>
        /// Faz a eclusão de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete("Excluir")]
        [Produces("application/json")]
        public async Task<JsonResult> DeleteUser([FromBody] Login registerUser)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, menssager = ModelState.Values.SelectMany(e => e.Errors) });
            }

            var result = await this._usuarioBLL.ExcluirUsuario(registerUser);
            return new JsonResult(new { success = result, menssager = "Usuário excluído com sucesso!" });

        }


        /// <summary>
        /// Cria um usuário na API
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        [HttpPost("Criar")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] Login registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var resultado = await this._usuarioBLL.CriarUsuario(registerUser);

            if (!resultado.Succeeded) return BadRequest(resultado.Message);

            return Ok(resultado.body);

        }

        /// <summary>
        /// Efetua o login no sistema
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [Produces("application/json")]
        [AllowAnonymous]

        public async Task<ActionResult<UserToken>> Login([FromBody] Login login)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var loginResult = await this._usuarioBLL.EfetuarLogin(login);
            this.HttpContext.Session.SetString("usuario", login.Email);

            if (!loginResult.Succeeded)
            {
                return BadRequest(loginResult);
            }
            else
            {
              
                return Ok(loginResult);
            }
        }
    }
}