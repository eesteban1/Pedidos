//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int Id_prod { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> IdAfectoIGV { get; set; }
        public Nullable<int> IdMedida { get; set; }
        public Nullable<decimal> PesoKilos { get; set; }
        public Nullable<decimal> PComprasS { get; set; }
        public Nullable<decimal> PCompraD { get; set; }
        public Nullable<decimal> PVentaS { get; set; }
        public Nullable<decimal> PVentaD { get; set; }
        public Nullable<int> StockMin { get; set; }
        public Nullable<int> StockMax { get; set; }
        public Nullable<int> StockAct { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IdMarca { get; set; }
        public Nullable<int> Id_Familia { get; set; }
    }
}
