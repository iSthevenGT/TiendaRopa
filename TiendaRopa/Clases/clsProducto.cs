using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsProducto
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Producto producto { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Productoes.Add(producto);
                DBTienda.SaveChanges();
                return "Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el producto: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            var prod = Consultar(producto.IdProducto);
            if (prod == null) return "Producto no encontrado";
            DBTienda.Entry(producto).State = System.Data.Entity.EntityState.Modified;
            DBTienda.SaveChanges();
            return "Producto actualizado correctamente";
        }

        public Producto Consultar(int id)
        {
            return DBTienda.Productoes.FirstOrDefault(prod => prod.IdProducto == id);
        }

        public List<Producto> ConsultarTodos()
        {
            return DBTienda.Productoes.OrderBy(prod => prod.Nombre).ToList();
        }

        public string Eliminar()
        {
            var prod = Consultar(producto.IdProducto);
            if (prod == null) return "Producto no encontrado";
            DBTienda.Productoes.Remove(prod);
            DBTienda.SaveChanges();
            return "Producto eliminado correctamente";
        }
    }
}