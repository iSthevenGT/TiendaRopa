
using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsVenta
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Venta venta { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Ventas.Add(venta);
                DBTienda.SaveChanges();
                return "Venta registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar la venta: " + ex.Message;
            }
        }

        public Venta Consultar(int id)
        {
            return DBTienda.Ventas.FirstOrDefault(venta => venta.IdVenta == id);
        }

        public List<Venta> ConsultarTodos()
        {
            return DBTienda.Ventas.OrderByDescending(venta => venta.Fecha).ToList();
        }
    }
}