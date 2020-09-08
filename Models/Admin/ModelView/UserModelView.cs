using System.ComponentModel.DataAnnotations;

namespace Models.Admin.ModelView
{
    public class UserModelView
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public int IdEmpresa { get; set; }
    }
}
