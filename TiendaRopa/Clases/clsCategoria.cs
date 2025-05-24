using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsCategoria
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();

        public Categoria categoria { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Categorias.Add(categoria);
                DBTienda.SaveChanges();
                return "Categoria creada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al crear la categoria" + ex.Message;
            }
        }

        public Categoria Consultar(string nombre)
        {
            return DBTienda.Categorias.FirstOrDefault(e => e.Nombre.ToLower() == nombre.ToLower());
        }

        public Categoria ConsultarPorId(int id)
        {
            return DBTienda.Categorias.FirstOrDefault(e => e.IdCategoria == id);
        }

        public List<Categoria> ConsultarTodos()
        {
            return DBTienda.Categorias.OrderBy(e => e.Nombre).ToList();
        }

        public string Eliminar()
        {
            var cat = ConsultarPorId(categoria.IdCategoria);
            if (cat == null) return "Id de la categoria incorrecta";
            DBTienda.Categorias.Remove(cat);
            DBTienda.SaveChanges();
            return "Categoria eliminada con exito";
        }


        public string Actualizar()
        {
            var cat = ConsultarPorId(categoria.IdCategoria);
            if (cat == null) return "Categoria no encontrada";

            cat.Nombre = categoria.Nombre;
            DBTienda.SaveChanges();
            return "Categoria actualizada correctamente";
            ;
        }
    }
}