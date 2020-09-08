using System.ComponentModel.DataAnnotations;

namespace Models.Admin.Json.Outputs
{
    public class UserClaimJson
    {
        [Required]
        public string ClaimType { get; set; }
        [Required]
        public string ClaimValue { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool Ativo { get; set; }
    }
}
