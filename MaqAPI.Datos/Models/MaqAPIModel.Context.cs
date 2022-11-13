﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
    
        public virtual DbSet<diesel> diesels { get; set; }
        public virtual DbSet<maquinaria> maquinarias { get; set; }
        public virtual DbSet<obra> obras { get; set; }
        public virtual DbSet<operadore> operadores { get; set; }
        public virtual DbSet<ubicacion> ubicacions { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<parametro> parametros { get; set; }
    
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
