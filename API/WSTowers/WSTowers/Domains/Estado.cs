using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int Id { get; set; }
        public string Estado1 { get; set; }
        public string Sigla { get; set; }
        public int? Regiao { get; set; }

        public virtual Regiao RegiaoNavigation { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
