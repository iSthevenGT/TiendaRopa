using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsSucursal
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Sucursal sucursal { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Sucursals.Add(sucursal);
                DBTienda.SaveChanges();
                return "Sucursal insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la sucursal: " + ex.Message;
            }
        }

        public Sucursal Consultar(int id)
        {
            return DBTienda.Sucursals.FirstOrDefault(suc => suc.IdSucursal == id);
        }

        public List<Sucursal> ConsultarTodos()
        {
            return DBTienda.Sucursals.OrderBy(suc => suc.Nombre).ToList();
        }
    }
}