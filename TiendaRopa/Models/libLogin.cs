using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRopa.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }

    public class LoginRespuesta
    {
        public string Usuario { get; set; }
        public string Cargo { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdSucursal { get; set; }
    }
}