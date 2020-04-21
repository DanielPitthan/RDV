using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

    }
}
