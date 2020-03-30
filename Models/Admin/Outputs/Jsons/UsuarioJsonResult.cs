using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Admin.Json.Outputs
{
    public class UsuarioJsonResult
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
    }
}
