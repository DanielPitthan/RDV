using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Admin
{
    public class UserClaims
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string ClaimType { get; set; }
        [Required]
        public string ClaimValue { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
