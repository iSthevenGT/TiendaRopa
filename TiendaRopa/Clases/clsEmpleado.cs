using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsEmpleado
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Empleado empleado { get; set; }

        public string Insertar()
        {
            try
            {
                DBTienda.Empleadoes.Add(empleado);
                DBTienda.SaveChanges();
                return "Empleado insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el empleado: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            var emp = Consultar(empleado.IdEmpleado);
            if (emp == null) return "Empleado no encontrado";
            DBTienda.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            DBTienda.SaveChanges();
            return "Empleado actualizado correctamente";
        }

        public Empleado Consultar(int id)
        {
            return DBTienda.Empleadoes.FirstOrDefault(emp => emp.IdEmpleado == id);
        }

        public List<Empleado> ConsultarTodos()
        {
            return DBTienda.Empleadoes.OrderBy(emp => emp.Nombre).ToList();
        }

        public string Eliminar()
        {
            var emp = Consultar(empleado.IdEmpleado);
            if (emp == null) return "Empleado no encontrado";
            DBTienda.Empleadoes.Remove(emp);
            DBTienda.SaveChanges();
            return "Empleado eliminado correctamente";
        }
    }
}