using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/pedidosProveedor")]
    public class PedidosProveedorController : ApiController
    {
        
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar(PedidoProveedor pedido)
        {
            var cls = new clsPedidoProveedor { pedido = pedido };
            return Ok(cls.Insertar());
        }

        
        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var cls = new clsPedidoProveedor();
            return Ok(cls.Consultar(id));
        }

        
        [HttpGet]
        [Route("consultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsPedidoProveedor();
            return Ok(cls.ConsultarTodos());
        }
    }
}