using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/empleados")]
    public class EmpleadosController : ApiController
    {

        
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult Insertar([FromBody] Empleado empleado)
        {
            var cls = new clsEmpleado { empleado = empleado };
            return Ok(cls.Insertar());
        }

        
        [HttpPut]
        [Route("actualizar")]
        public IHttpActionResult Actualizar([FromBody] Empleado empleado)
        {
            var cls = new clsEmpleado { empleado = empleado };
            return Ok(cls.Actualizar());
        }

        
        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var cls = new clsEmpleado();
            return Ok(cls.Consultar(id));
        }

        
        [HttpGet]
        [Route("consutarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsEmpleado();
            return Ok(cls.ConsultarTodos());
        }

        
        [HttpDelete]
        [Route("eliminar")]
        public IHttpActionResult Eliminar(int id)
        {
            var cls = new clsEmpleado { empleado = new Empleado { IdEmpleado = id } };
            return Ok(cls.Eliminar());
        }
    }
}