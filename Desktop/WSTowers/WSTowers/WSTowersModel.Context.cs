﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WSTowersEntities : DbContext
    {
        public WSTowersEntities()
            : base("name=WSTowersEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<categoria> categoria { get; set; }
        public DbSet<cidade> cidade { get; set; }
        public DbSet<estado> estado { get; set; }
        public DbSet<estoque> estoque { get; set; }
        public DbSet<genero> genero { get; set; }
        public DbSet<loja> loja { get; set; }
        public DbSet<participante> participante { get; set; }
        public DbSet<produto> produto { get; set; }
        public DbSet<regiao> regiao { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<vendas> vendas { get; set; }
    }
}
