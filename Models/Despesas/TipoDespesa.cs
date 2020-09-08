using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Despesas
{
    public class TipoDespesa
    {


        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime DataInclusao { get; set; }
    }
}
