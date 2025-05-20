using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/proveedores")]
    public class ProveedoresController : ApiController
    {
        
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar(Proveedor proveedor)
        {
            var cls = new clsProveedor { proveedor = proveedor };
            return Ok(cls.Insertar());
        }

        
        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var cls = new clsProveedor();
            return Ok(cls.Consultar(id));
        }

        
        [HttpGet]
        [Route("consultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsProveedor();
            return Ok(cls.ConsultarTodos());
        }

        
        [HttpDelete]
        [Route("eliminar")]
        public IHttpActionResult Eliminar(int id)
        {
            var cls = new clsProveedor { proveedor = new Proveedor { IdProveedor = id } };
            return Ok(cls.Eliminar());
        }
    }
}