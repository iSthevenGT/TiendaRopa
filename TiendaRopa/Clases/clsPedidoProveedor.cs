using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsPedidoProveedor
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public PedidoProveedor pedido { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.PedidoProveedors.Add(pedido);
                DBTienda.SaveChanges();
                return "Pedido a proveedor insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el pedido: " + ex.Message;
            }
        }

        public PedidoProveedor Consultar(int id)
        {
            return DBTienda.PedidoProveedors.FirstOrDefault(pp => pp.IdPedidoProveedor == id);
        }

        public List<PedidoProveedor> ConsultarTodos()
        {
            return DBTienda.PedidoProveedors.OrderByDescending(pp => pp.Fecha).ToList();
        }
    }
}