using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Models.Admin
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
       
        public string Email { get; set; }
      
        public string Nome { get; set; }
      
        public string Password { get; set; }

        
        public bool Ativo { get; set; }
     
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
