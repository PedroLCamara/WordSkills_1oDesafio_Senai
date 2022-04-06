using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Categorium
    {
        public Categorium()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
