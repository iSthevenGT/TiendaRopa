﻿using System.Web.Http;
using TiendaRopa.Clases;

namespace TiendaRopa.Controllers
{
    [Authorize]
    [RoutePrefix("api/inventario")]
    public class InventarioController : ApiController
    {
        
        [HttpGet]
        [Route("consultarPorSucursal")]
        public IHttpActionResult ConsultarPorSucursal(int idSucursal)
        {
            var cls = new clsInventario();
            return Ok(cls.ConsultarPorSucursal(idSucursal));
        }

        
        [HttpGet]
        [Route("consultarPorProducto")]
        public IHttpActionResult ConsultarPorProducto(int idProducto)
        {
            var cls = new clsInventario();
            return Ok(cls.ConsultarPorProducto(idProducto));
        }
    }
}