using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsInventario
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();

        public List<Inventario> ConsultarPorSucursal(int idSucursal)
        {
            return DBTienda.Inventarios.Where(inv => inv.IdSucursal == idSucursal).ToList();
        }

        public List<Inventario> ConsultarPorProducto(int idProducto)
        {
            return DBTienda.Inventarios.Where(inv => inv.IdProducto == idProducto).ToList();
        }
    }
}