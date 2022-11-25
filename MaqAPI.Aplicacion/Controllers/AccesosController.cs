using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaqAPI.Servicios;
using MaqAPI.Entidades;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/accesos")]
    public class AccesosController : ApiController
    {
        private srvAccesos _srvAccesos = new srvAccesos();

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("Login")]
        public object Login([FromBody] OperadorEntidad pOperador)
        {

            _srvAccesos.operadorEntidad = pOperador;
            return _srvAccesos.Login();
        }

    }
}
