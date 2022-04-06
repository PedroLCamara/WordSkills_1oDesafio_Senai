using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Genero
    {
        public Genero()
        {
            Participantes = new HashSet<Participante>();
        }

        public int Id { get; set; }
        public string Genero1 { get; set; }

        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
