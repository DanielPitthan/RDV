﻿using System.ComponentModel.DataAnnotations;

namespace Models.Admin.ModelView
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Nome { get; set; }

        public string ConfirmPassword { get; set; }

        public int IdEmpresa { get; set; }
    }
}
