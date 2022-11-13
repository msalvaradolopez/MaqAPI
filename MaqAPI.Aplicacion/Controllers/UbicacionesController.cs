using MaqAPI.Entidades;
using MaqAPI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/ubicaciones")]
    public class UbicacionesController : ApiController
    {
        public class Params
        {
            public string idUbicacion { get; set; }
        }

        private srvUbicaciones _srvUbicaciones = new srvUbicaciones();

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insUbicacion")]
        public string insUbicacion([FromBody] UbicacionEntidad pUbicacion)
        {

            _srvUbicaciones.ubicacionEntidad = pUbicacion;
            if (_srvUbicaciones.Agregar())
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updUbicacion")]
        public string updUbicacion([FromBody] UbicacionEntidad pUbicacion)
        {

            _srvUbicaciones.ubicacionEntidad = pUbicacion;
            if (_srvUbicaciones.Actualizar())
                return "Registro Actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delUbicacion")]
        public string delUbicacion([FromBody] UbicacionEntidad pUbicacion)
        {

            _srvUbicaciones.ubicacionEntidad = pUbicacion;
            if (_srvUbicaciones.Eliminar())
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        
        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getUbicacionById")]
        public object getUbicacionById([FromBody] Params _param)
        {
            return _srvUbicaciones.ListadoPorId(_param.idUbicacion);

        }
    }
}
