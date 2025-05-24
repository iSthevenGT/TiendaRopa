using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TiendaRopa.Clases;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/Categorias")]
    public class CategoriasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]

        public IHttpActionResult Insertar([FromBody] Categoria categoria)
        {
            var cls = new clsCategoria { categoria = categoria };
            return Ok(cls.Insertar());
        }

        [HttpPut]
        [Route("Actualizar")]

        public IHttpActionResult Actualizar([FromBody] Categoria categoria)
        {
            var cls = new clsCategoria { categoria = categoria };
            return Ok(cls.Actualizar());
        }

        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(string nombre)
        {
            var cls = new clsCategoria();
            return Ok(cls.Consultar(nombre));
        }

        [HttpGet]
        [Route("consultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var cls = new clsCategoria();
            return Ok(cls.ConsultarTodos());
        }


        [HttpDelete]
        [Route("eliminar")]
        public IHttpActionResult Eliminar(int id)
        {
            var cls = new clsCategoria { categoria = new Categoria { IdCategoria = id } };
            return Ok(cls.Eliminar());
        }
    }
}