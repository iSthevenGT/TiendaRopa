using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

public class DevolucionesController : ApiController
{
    [HttpPost]
    [Route("insertar")]
    public IHttpActionResult Insertar(Devolucion devolucion)
    {
        var cls = new clsDevolucion { devolucion = devolucion };
        return Ok(cls.Insertar());
    }

    [HttpGet]
    [Route("consultar")]
    public IHttpActionResult Consultar(int id)
    {
        var cls = new clsDevolucion();
        return Ok(cls.Consultar(id));
    }

    [HttpGet]
    [Route("consultarTodos")]
    public IHttpActionResult ConsultarTodos()
    {
        var cls = new clsDevolucion();
        return Ok(cls.ConsultarTodos());
    }
}