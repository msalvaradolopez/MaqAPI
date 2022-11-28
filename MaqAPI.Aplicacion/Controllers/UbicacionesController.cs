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
        [Route("getUbicaciones")]
        public IEnumerable<object> getUbicaciones()
        {
            var _listado = _srvUbicaciones.Listado();
            return _listado;

        }


        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getUbicacionById")]
        public object getUbicacionById([FromBody] FiltrosEntidad _filtros)
        {
            return _srvUbicaciones.ListadoPorId(_filtros.idUbicacion);

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getUbicacionesFiltro")]
        public object getUbicacionesFiltro([FromBody] FiltrosEntidad _filtros)
        {
            return _srvUbicaciones.ListadoFiltro(_filtros);

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getTableroList")]
        public object getTableroList([FromBody] FiltrosEntidad _filtros)
        {
            return _srvUbicaciones.TableroList(_filtros.pagina);

        }
    }
}
