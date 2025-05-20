using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsCliente
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Cliente cliente { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Clientes.Add(cliente);
                DBTienda.SaveChanges();
                return "Cliente insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el cliente: " + ex.Message;
            }
        }

        public Cliente Consultar(int id)
        {
            return DBTienda.Clientes.FirstOrDefault(cli => cli.IdCliente == id);
        }

        public List<Cliente> ConsultarTodos()
        {
            return DBTienda.Clientes.OrderBy(cli => cli.Nombre).ToList();
        }
    }
}