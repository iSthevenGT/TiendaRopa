using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar(Producto producto)
        {
            var cls = new clsProducto { producto = producto };
            return Ok(cls.Insertar());
        }

        
        [HttpPut]
        [Route("actualizar")]
        public IHttpActionResult Actualizar(Producto producto)
        {
            var cls = new clsProducto { producto = producto };
            return Ok(cls.Actualizar());
        }

        
        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var cls = new clsProducto();
            return Ok(cls.Consultar(id));
        }

        
        [HttpGet]
        [Route("consultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsProducto();
            return Ok(cls.ConsultarTodos());
        }

        
        [HttpDelete]
        [Route("eliminar")]
        public IHttpActionResult Eliminar(int id)
        {
            var cls = new clsProducto { producto = new Producto { IdProducto = id } };
            return Ok(cls.Eliminar());
        }
    }
}