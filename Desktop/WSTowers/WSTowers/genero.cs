//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSTowers
{
    using System;
    using System.Collections.Generic;
    
    public partial class genero
    {
        public genero()
        {
            this.participante = new HashSet<participante>();
        }
    
        public int id { get; set; }
        public string Genero1 { get; set; }
    
        public virtual ICollection<participante> participante { get; set; }
    }
}