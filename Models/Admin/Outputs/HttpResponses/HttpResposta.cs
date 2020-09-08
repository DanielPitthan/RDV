using System.Collections.Generic;
using System.Security.Claims;

namespace Models.Admin.Outputs.HttpResponses
{
    public struct HttpResposta
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Message { get; set; }
        public dynamic body { get; set; }
        public string statusText { get; set; }
        public ClaimsIdentity Identities { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public string RedirectTo { get; set; }
    }
}
