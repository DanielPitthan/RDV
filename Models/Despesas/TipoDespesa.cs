using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Despesas
{
    public class TipoDespesa
    {
    

        public int Id { get; set; }
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        [Display(Name ="Ativo")]
        public bool Ativo { get; set; }
        [Display(Name ="Data de Inclusão")]
        public DateTime DataInclusao { get; set; }
    }
}
