using Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Despesas
{
    public class DespesaHeader
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public decimal Total { get; set; }
        public bool Aprovado { get; set; }
        public string Motivo { get; set; }

        public Usuario UsuarioInclusao { get; set; }
        public Usuario UsuarioAprovacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAprovacao { get; set; }

        public virtual IList<Despesa> Despesas { get; set; }
    }
}
