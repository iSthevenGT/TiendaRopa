//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaRopa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public int Stock { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
