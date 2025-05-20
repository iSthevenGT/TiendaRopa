using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/ventas")]
    public class VentasController : ApiController
    {
        
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar(Venta venta)
        {
            var cls = new clsVenta { venta = venta };
            return Ok(cls.Insertar());
        }

        
        [HttpGet]
        [Route("insertar")]
        public IHttpActionResult Consultar(int id)
        {
            var cls = new clsVenta();
            return Ok(cls.Consultar(id));
        }

        
        [HttpGet]
        [Route("insertar")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsVenta();
            return Ok(cls.ConsultarTodos());
        }
    }
}