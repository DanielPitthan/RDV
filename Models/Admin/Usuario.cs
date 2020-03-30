using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Admin
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AspNetUsersId { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual UserToken UserToken { get; set; }
        public virtual IList<UserClaims> UserClaims { get; set; }
        public virtual Empresa Empresa { get; set; }

        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime LastAcess { get; set; }

    }
}
