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
    [RoutePrefix("api/operadores")]
    public class OperadoresController : ApiController
    {
        private srvOperadores _svrOPeradores = new srvOperadores();

        public class Params
        {
            public string idOperador { get; set; }
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insOperador")]
        public string insOperador([FromBody] OperadorEntidad pOperador)
        {

            _svrOPeradores.operadorEntidad = pOperador;
            if (_svrOPeradores.Agregar())
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updOperador")]
        public string updOperador([FromBody] OperadorEntidad pOperador)
        {

            _svrOPeradores.operadorEntidad = pOperador;
            if (_svrOPeradores.Actualizar())
                return "Registro Actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delOperador")]
        public string delOperador([FromBody] OperadorEntidad pOperador)
        {

            _svrOPeradores.operadorEntidad = pOperador;
            if (_svrOPeradores.Eliminar())
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getOperadores")]
        public IEnumerable<object> getOperadores()
        {
            return this._svrOPeradores.Listado();

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getOperadorById")]
        public object getOperadorById([FromBody] Params _param)
        {
            return _svrOPeradores.ListadoPorId(_param.idOperador);

        }
    }
}
