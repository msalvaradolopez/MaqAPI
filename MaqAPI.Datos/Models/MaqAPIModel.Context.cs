﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaqAPI.Datos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MaquinariaEntities : DbContext
    {
        public MaquinariaEntities()
            : base("name=MaquinariaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bitseg> bitseg { get; set; }
        public virtual DbSet<Demo> Demo { get; set; }
        public virtual DbSet<diesel> diesel { get; set; }
        public virtual DbSet<inspec> inspec { get; set; }
        public virtual DbSet<maquinaria> maquinaria { get; set; }
        public virtual DbSet<obras> obras { get; set; }
        public virtual DbSet<operadores> operadores { get; set; }
        public virtual DbSet<parametros> parametros { get; set; }
        public virtual DbSet<ubicacion> ubicacion { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    
        public virtual int spConsultaUbicacionPaginado(Nullable<int> intRenglones, Nullable<int> intPagina)
        {
            var intRenglonesParameter = intRenglones.HasValue ?
                new ObjectParameter("intRenglones", intRenglones) :
                new ObjectParameter("intRenglones", typeof(int));
    
            var intPaginaParameter = intPagina.HasValue ?
                new ObjectParameter("intPagina", intPagina) :
                new ObjectParameter("intPagina", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spConsultaUbicacionPaginado", intRenglonesParameter, intPaginaParameter);
        }
    }
}
