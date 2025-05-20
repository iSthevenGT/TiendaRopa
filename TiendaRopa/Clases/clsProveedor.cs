using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsProveedor
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Proveedor proveedor { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Proveedors.Add(proveedor);
                DBTienda.SaveChanges();
                return "Proveedor insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el proveedor: " + ex.Message;
            }
        }

        public Proveedor Consultar(int id)
        {
            return DBTienda.Proveedors.FirstOrDefault(prov => prov.IdProveedor == id);
        }

        public List<Proveedor> ConsultarTodos()
        {
            return DBTienda.Proveedors.OrderBy(prov => prov.Nombre).ToList();
        }

        public string Eliminar()
        {
            var prov = Consultar(proveedor.IdProveedor);
            if (prov == null) return "Proveedor no encontrado";
            DBTienda.Proveedors.Remove(prov);
            DBTienda.SaveChanges();
            return "Proveedor eliminado correctamente";
        }
    }
}