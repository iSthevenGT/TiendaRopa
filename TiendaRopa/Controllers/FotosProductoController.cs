using System.Web.Http;
using TiendaRopa.Clases;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/fotosProducto")]
    public class FotosProductoController : ApiController
    {
        
        [HttpGet]
        [Route("consultarporProducto")]
        public IHttpActionResult ConsultarPorProducto(int idProducto)
        {
            var cls = new clsFotoProducto();
            return Ok(cls.ConsultarPorProducto(idProducto));
        }

        
        [HttpDelete]
        [Route("eliminar")]
        public IHttpActionResult Eliminar(int idFoto)
        {
            var cls = new clsFotoProducto();
            return Ok(cls.Eliminar(idFoto));
        }
    }
}