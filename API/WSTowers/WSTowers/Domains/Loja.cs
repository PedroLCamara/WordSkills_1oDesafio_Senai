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
        }

        public int Id { get; set; }
        public string Loja1 { get; set; }

        public virtual ICollection<Estoque> Estoques { get; set; }
    }
}
