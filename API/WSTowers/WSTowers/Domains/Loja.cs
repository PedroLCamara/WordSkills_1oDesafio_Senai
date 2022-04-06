using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Loja
    {
        public Loja()
        {
            Estoques = new HashSet<Estoque>();
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string Loja1 { get; set; }

        public virtual ICollection<Estoque> Estoques { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
