using System;
using System.Collections.Generic;

#nullable disable

namespace WSTowers.Domains
{
    public partial class Participante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public int? Cidade { get; set; }
        public int? Genero { get; set; }

        public virtual Cidade CidadeNavigation { get; set; }
        public virtual Genero GeneroNavigation { get; set; }
    }
}
