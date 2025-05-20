using System;
using System.Linq;
using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IHttpActionResult Ingresar([FromBody] Login login)
        {
            clsLogin clsLogin = new clsLogin();
            clsLogin.login = login;
            var resultado = clsLogin.Ingresar().FirstOrDefault();
            return Ok(resultado);
        }
    }
}