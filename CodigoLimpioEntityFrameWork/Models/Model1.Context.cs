﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodigoLimpioEntityFrameWork.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ColoriaEntitiesEn : DbContext
    {
        public ColoriaEntitiesEn()
            : base("name=ColoriaEntitiesEn")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<DepartamentoColor> DepartamentoColor { get; set; }
        public virtual DbSet<DesarrolloRegional> DesarrolloRegional { get; set; }
        public virtual DbSet<Herramienta> Herramienta { get; set; }
        public virtual DbSet<Idea> Idea { get; set; }
        public virtual DbSet<ideaColor> ideaColor { get; set; }
        public virtual DbSet<ideaHerramienta> ideaHerramienta { get; set; }
        public virtual DbSet<ideaMiembro> ideaMiembro { get; set; }
        public virtual DbSet<Miembro> Miembro { get; set; }
    }
}