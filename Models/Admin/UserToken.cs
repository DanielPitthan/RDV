using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Admin
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime? Expiration { get; set; }

        [Required]
        public string Issuer { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required]
        public virtual int UsuarioId { get; set; }
    }
}
