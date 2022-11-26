using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaqAPI.Migracion;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/migracion")]
    public class MigracionController : ApiController
    {
        private srvMigracion _srvMigracion = new srvMigracion();

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("Catalogos")]
        public string Catalogos()
        {
            if (_srvMigracion.MigrarObras() == false)
                return "Migracion cat Obras fallo.";

            if (_srvMigracion.MigrarOperadores() == false)
                return "Migracion cat Operadores fallo.";


            if (_srvMigracion.MigrarMaquinaria() == false)
                return "Migracion cat Equipos fallo.";

            return "Migracion catalogos OK.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("Ubicaciones")]
        public string Ubicaciones()
        {

            if (_srvMigracion.MigrarUbicaciones() == false)
                return "Migracion cat Ubicaciones fallo.";

            return "Migracion Ubicaciones OK.";
        }
    }
}
