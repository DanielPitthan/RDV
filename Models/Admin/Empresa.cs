using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Admin
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(14)]
        [Required]
        public string Cnpj { get; set; }

        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        [MaxLength(50)]
        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public bool Ativa { get; set; }
        public virtual IList<EmpresaRegra> Regra { get; set; }
        [Required]
        public string Filial { get; set; }
        public string IE { get; set; }
        [Required]
        public string UF { get; set; }
        public bool Centralizadora { get; set; }
        public string DescricaoResumida { get; set; }
    }
}
