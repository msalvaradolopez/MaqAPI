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
    [RoutePrefix("api/bitSeg")]
    public class BitSegController : ApiController
    {
        private srvBitSeg _srvBitSeg = new srvBitSeg();

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insBitSeg")]
        public string insBitSeg([FromBody] BitSegEntidad pBitSeg)
        {

            _srvBitSeg.bitSegEntidad = pBitSeg;
            if (_srvBitSeg.Agregar())
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updBitSeg")]
        public string updBitSeg([FromBody] BitSegEntidad pBitSeg)
        {

            _srvBitSeg.bitSegEntidad = pBitSeg;
            if (_srvBitSeg.Actualizar())
                return "Registro Actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delBitSeg")]
        public string delBitSeg([FromBody] BitSegEntidad pBitSeg)
        {
            _srvBitSeg.bitSegEntidad = pBitSeg;
            if (_srvBitSeg.Eliminar())
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getBitSeg")]
        public IEnumerable<object> getBitSeg()
        {
            var _listado = _srvBitSeg.Listado();
            return _listado;

        }


        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getBitSegById")]
        public object getBitSegById([FromBody] FiltrosEntidad _filtros)
        {
            return _srvBitSeg.ListadoPorId(_filtros.idUbicacion);

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getBitSegFiltro")]
        public object getBitSegFiltro([FromBody] FiltrosEntidad _filtros)
        {
            return _srvBitSeg.ListadoFiltro(_filtros);

        }

    }
}
