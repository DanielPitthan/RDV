using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.Admin
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("E-Mail")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Senha")]
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        public bool Ativo { get; set; }

        [DisplayName("CPF")]
        public string Cpf { get; set; }



        [AllowNull]
        public virtual UserToken? UserToken { get; set; }

        [AllowNull]
        public virtual IList<UserClaims>? UserClaims { get; set; }

        [AllowNull]
        public virtual Empresa? Empresa { get; set; }


        public DateTime DataCriacao { get; set; }
        public DateTime? LastAcess { get; set; }
        public bool? IsAdmin { get; set; }

        public string AspNetUsersId { get; set; }
        public bool IsLogged { get; set; }
        [AllowNull]
        public DateTime? ExpirationDateLogged { get; set; }

    }
}
