
using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsDevolucion
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Devolucion devolucion { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Devolucions.Add(devolucion);
                DBTienda.SaveChanges();
                return "Devolución registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar la devolución: " + ex.Message;
            }
        }

        public Devolucion Consultar(int id)
        {
            return DBTienda.Devolucions.FirstOrDefault(dev => dev.IdDevolucion == id);
        }

        public List<Devolucion> ConsultarTodos()
        {
            return DBTienda.Devolucions.OrderByDescending(dev => dev.Fecha).ToList();
        }
    }
}