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
    
    public partial class estoque
    {
        public int id { get; set; }
        public Nullable<int> produto { get; set; }
        public Nullable<int> loja { get; set; }
        public Nullable<int> quantidade { get; set; }
    
        public virtual loja loja1 { get; set; }
        public virtual produto produto1 { get; set; }
    }
}