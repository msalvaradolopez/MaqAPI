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
    [RoutePrefix("api/maquinaria")]
    public class MaquinariaController : ApiController
    {
        private  srvMaquinaria _svrMaquinaria = new srvMaquinaria();

        public class Params
        {
            public string idEconomico { get; set; }
            public string filtro { get; set; }
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insMaquinaria")]
        public string insMaquinaria([FromBody] MaquinariaEntidad pMaquinaria)
        {

            _svrMaquinaria.maquinariaEntidad = pMaquinaria;
            if (_svrMaquinaria.Agregar())
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updMaquinaria")]
        public string updMaquinaria([FromBody] MaquinariaEntidad pMaquinaria)
        {

            _svrMaquinaria.maquinariaEntidad = pMaquinaria;
            if (_svrMaquinaria.Actualizar())
                return "Registro Actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delMaquinaria")]
        public string delMaquinaria([FromBody] MaquinariaEntidad pMaquinaria)
        {

            _svrMaquinaria.maquinariaEntidad = pMaquinaria;
            if (_svrMaquinaria.Eliminar())
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getMaquinaria")]
        public IEnumerable<object> getMaquinaria()
        {
            return _svrMaquinaria.Listado();

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getMaquinariaById")]
        public object getMaquinariaById([FromBody] FiltrosEntidad filtro)
        {
            return _svrMaquinaria.ListadoPorId(filtro.idEconomico);

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getMaquinariaFiltro")]
        public object getMaquinariaFiltro([FromBody] FiltrosEntidad filtro)
        {
            return _svrMaquinaria.ListadoFiltro(filtro);

        }

    }
}
