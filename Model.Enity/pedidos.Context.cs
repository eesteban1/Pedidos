﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Enity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ventas2Entities : DbContext
    {
        public ventas2Entities()
            : base("name=ventas2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accesos> Accesos { get; set; }
        public virtual DbSet<cargos> cargos { get; set; }
        public virtual DbSet<Encabezado> Encabezado { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<mercados> mercados { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<UniMed> UniMed { get; set; }
        public virtual DbSet<zonas> zonas { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Denominacion> Denominacion { get; set; }
        public virtual DbSet<UBIGEO> UBIGEO { get; set; }
        public virtual DbSet<AsignaZona> AsignaZona { get; set; }
        public virtual DbSet<Detalles> Detalles { get; set; }
        public virtual DbSet<IGV> IGV { get; set; }
        public virtual DbSet<v_Acc> v_Acc { get; set; }
        public virtual DbSet<v_AcEn> v_AcEn { get; set; }
        public virtual DbSet<v_AsignaZona> v_AsignaZona { get; set; }
        public virtual DbSet<v_Clientes> v_Clientes { get; set; }
        public virtual DbSet<v_ComboClientes> v_ComboClientes { get; set; }
        public virtual DbSet<v_EncabDet> v_EncabDet { get; set; }
        public virtual DbSet<v_ListarMercado> v_ListarMercado { get; set; }
        public virtual DbSet<v_ListarPedidoFecha> v_ListarPedidoFecha { get; set; }
        public virtual DbSet<v_ListarProductos> v_ListarProductos { get; set; }
        public virtual DbSet<v_ListarZonas> v_ListarZonas { get; set; }
        public virtual DbSet<v_Mer> v_Mer { get; set; }
        public virtual DbSet<v_Per> v_Per { get; set; }
        public virtual DbSet<v_Pro> v_Pro { get; set; }
        public virtual DbSet<v_Zon> v_Zon { get; set; }
        public virtual DbSet<Producto> Producto1 { get; set; }
        public virtual DbSet<v_ListarCliente> v_ListarCliente { get; set; }
        public virtual DbSet<v_MercadoxZona> v_MercadoxZona { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<FormasPago> FormasPago { get; set; }
    }
}
