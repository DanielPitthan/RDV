using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RDV.Filters
{
    public class ApiAuthorization
    {
        /// <summary>
        /// Valida o Claims do usuário contra o banco
        /// </summary>
        /// <param name="context"></param>
        /// <param name="claimName"></param>
        /// <param name="claimValue"></param>
        /// <returns></returns>
        public bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            var result = context.User.Identity.IsAuthenticated &&
                         context.User.Claims.Any(c => c.Type == claimName && c.Value.Split(',')
                         .Contains(claimValue));

            return result;

        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }


    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        private ApiAuthorization validador;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
            this.validador = new ApiAuthorization();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }
            var resultado = validador.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value);
            if (!resultado)
            {
                context.Result = new StatusCodeResult(403);
                return;
            }
        }
    }
}
