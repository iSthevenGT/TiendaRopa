using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsUsuario
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Usuario usuario { get; set; }

        public string CrearUsuario()
        {
            try
            {
                if (usuario == null)
                    return "El usuario no puede ser nulo";

                if (string.IsNullOrEmpty(usuario.NombreUsuario))
                    return "El nombre de usuario es requerido";

                if (string.IsNullOrEmpty(usuario.Clave))
                    return "La clave es requerida";

                if (usuario.IdEmpleado == null)
                    return "Debe asociar el usuario a un empleado";

                var empleado = DBTienda.Empleadoes.FirstOrDefault(e => e.IdEmpleado == usuario.IdEmpleado);
                if (empleado == null)
                    return "El empleado no existe";

                if (DBTienda.Usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario))
                    return "El nombre de usuario ya existe";

                clsCypher cypher = new clsCypher();
                cypher.Password = usuario.Clave;
                if (!cypher.CifrarClave())
                    return "Error al cifrar la clave";

                usuario.Clave = cypher.PasswordCifrado;
                usuario.Salt = cypher.Salt;
                DBTienda.Usuarios.Add(usuario);
                DBTienda.SaveChanges();

                return "Se creó el usuario exitosamente";
            }
            catch (Exception ex)
            {
                return "Error al crear el usuario: " + ex.Message;
            }
        }

        public Usuario ConsultarUsuario(string nombreUsuario)
        {
            return DBTienda.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }

        public List<Usuario> ConsultarTodos()
        {
            return DBTienda.Usuarios.ToList();
        }
    }
}