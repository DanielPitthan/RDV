using System.ComponentModel.DataAnnotations;

namespace Models.Admin.Json.Outputs
{
    public class EmpresaRegraJson
    {
        public int Id { get; set; }

        private string regra;

        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string Regra
        {
            get
            {
                return this.regra;
            }
            set
            {
                this.regra = "E_" + value;
            }
        }



        [MinLength(1)]
        [Required]
        public string Valor { get; set; }

        public int EmpresaId { get; set; }
    }
}
