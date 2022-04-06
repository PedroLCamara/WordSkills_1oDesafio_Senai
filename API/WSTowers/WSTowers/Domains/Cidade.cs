using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Cidade
    {
        public Cidade()
        {
            Participantes = new HashSet<Participante>();
        }

        public int Id { get; set; }
        public string Cidade1 { get; set; }
        public int? Estado { get; set; }

        public virtual Estado EstadoNavigation { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
