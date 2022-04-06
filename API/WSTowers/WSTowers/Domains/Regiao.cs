using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Regiao
    {
        public Regiao()
        {
            Estados = new HashSet<Estado>();
        }

        public int Id { get; set; }
        public string Regiao1 { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
