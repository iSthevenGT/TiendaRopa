using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    [Authorize]
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar(Cliente cliente)
        {
            var cls = new clsCliente { cliente = cliente };
            return Ok(cls.Insertar());
        }

        
        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var cls = new clsCliente();
            return Ok(cls.Consultar(id));
        }

        
        [HttpGet]
        [Route("consultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsCliente();
            return Ok(cls.ConsultarTodos());
        }
    }
}