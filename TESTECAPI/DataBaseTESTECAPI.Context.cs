﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TESTECAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TESTECAPIEntities : DbContext
    {
        public TESTECAPIEntities()
            : base("name=TESTECAPIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_Cliente> TB_Cliente { get; set; }
        public virtual DbSet<TB_Endereco> TB_Endereco { get; set; }
        public virtual DbSet<TB_Perfil> TB_Perfil { get; set; }
    }
}