using System.ComponentModel.DataAnnotations;

namespace Models.Admin.Json.Outputs
{
    public class EmpresaJson
    {
        [MaxLength(14)]
        [Required]
        public string Cnpj { get; set; }

        [MaxLength(50)]
        [Required]
        public string RazaoSocial { get; set; }

        [MaxLength(50)]
        public string NomeFantasia { get; set; }


    }
}
