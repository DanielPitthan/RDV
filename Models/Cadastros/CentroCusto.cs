using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Cadastros
{
    public class CentroCusto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("C. Custo")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public DateTime DataInclusao { get; set; }
        public bool Ativo { get; set; }

    }
}
