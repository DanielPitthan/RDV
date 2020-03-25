using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Admin
{
    public class Login
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
