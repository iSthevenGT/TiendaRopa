using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }

        private bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Usuario usuario = DBTienda.Usuarios.FirstOrDefault(u => u.NombreUsuario == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }

                byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = "Error al validar usuario: " + ex.Message;
                return false;
            }
        }

        private bool ValidarClave()
        {
            try
            {
                Usuario usuario = DBTienda.Usuarios.FirstOrDefault(u => u.NombreUsuario == login.Usuario && u.Clave == login.Clave);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = "Error al validar clave: " + ex.Message;
                return false;
            }
        }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                var usuario = DBTienda.Usuarios.FirstOrDefault(u => u.NombreUsuario == login.Usuario && u.Clave == login.Clave);
                var empleado = DBTienda.Empleadoes.FirstOrDefault(e => e.IdEmpleado == usuario.IdEmpleado);

                return new List<LoginRespuesta>
                {
                    new LoginRespuesta
                    {
                        Usuario = usuario.NombreUsuario,
                        Autenticado = true,
                        Cargo = empleado?.Cargo,
                        Token = token,
                        Mensaje = "Login exitoso",
                        IdEmpleado = empleado?.IdEmpleado,
                        IdSucursal = empleado?.IdSucursal
                    }
                }.AsQueryable();
            }
            else
            {
                return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
            }
        }
    }
}