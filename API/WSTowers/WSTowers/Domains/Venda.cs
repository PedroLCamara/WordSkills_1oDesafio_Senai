using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Venda
    {
        public int Id { get; set; }
        public int? Participante { get; set; }
        public int? Produto { get; set; }
        public int? Quantidade { get; set; }
        public int? Loja { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public int? Transação { get; set; }

        public virtual Loja LojaNavigation { get; set; }
        public virtual Participante ParticipanteNavigation { get; set; }
        public virtual Produto ProdutoNavigation { get; set; }
    }
}
