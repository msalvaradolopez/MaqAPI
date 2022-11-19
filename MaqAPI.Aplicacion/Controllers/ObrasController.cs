using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaqAPI.Entidades;
using MaqAPI.Servicios;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/obras")]
    public class ObrasController : ApiController
    {

        private srvObras _srvObras = new srvObras();

        public class Params
        {
            public string idObra { get; set; }
            public string filtro { get; set; }
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insObra")]
        public string insObra([FromBody] ObraEntidad pObra)
        {

            _srvObras.obraEntidad = pObra;
            if (_srvObras.Agregar())
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updObra")]
        public string updObra([FromBody] ObraEntidad pObra)
        {

            _srvObras.obraEntidad = pObra;
            if (_srvObras.Actualizar())
                return "Registro Actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delObra")]
        public string delObra([FromBody] ObraEntidad pObra)
        {

            _srvObras.obraEntidad = pObra;
            if (_srvObras.Eliminar())
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getObras")]
        public IEnumerable<object> getObras()
        {
            return _srvObras.Listado();

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getObraById")]
        public object getObraById([FromBody] FiltrosEntidad filtro)
        {
            return _srvObras.ListadoPorId(filtro.idObra);

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getObrasFiltro")]
        public object getObrasFiltro([FromBody] FiltrosEntidad filtro)
        {
            return _srvObras.ListadoFiltro(filtro);

        }
    }
}
