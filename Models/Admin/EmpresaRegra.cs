using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Admin
{
    public class EmpresaRegra
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string Regra { get; set; }

        [MinLength(1)]
        [Required]
        public string Valor { get; set; }

        public int EmpresaId { get; set; }
    }
}
