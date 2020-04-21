using Models.Admin;
using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Despesas
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Aprovado { get; set; }

        public virtual TipoDespesa TipoDespesa { get; set; }

        [DisplayName("C. Custo")]
        public virtual CentroCusto CentroCusto { get; set; }
        public string Motivo { get; set; }

        public virtual  Usuario UsuarioInclusao { get; set; }
        public virtual Usuario UsuarioAprovacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAprovacao { get; set; }

        

    }
}
