using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

public class SucursalesController : ApiController
{
    [HttpPost]
    [Route("insertar")]
    public IHttpActionResult Insertar(Sucursal sucursal)
    {
        var cls = new clsSucursal { sucursal = sucursal };
        return Ok(cls.Insertar());
    }

    [HttpGet]
    [Route("consultar")]
    public IHttpActionResult Consultar(int id)
    {
        var cls = new clsSucursal();
        return Ok(cls.Consultar(id));
    }

    [HttpGet]
    [Route("consultarTodos")]
    public IHttpActionResult ConsultarTodos()
    {
        var cls = new clsSucursal();
        return Ok(cls.ConsultarTodos());
    }
}