using System;
using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
        public IHttpActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            clsUsuario clsUsuario = new clsUsuario();
            clsUsuario.usuario = usuario;
            string resultado = clsUsuario.CrearUsuario();
            return Ok(resultado);
        }
    }
}