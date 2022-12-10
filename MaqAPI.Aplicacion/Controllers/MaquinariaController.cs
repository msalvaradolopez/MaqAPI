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
        private srvCRUD<MaquinariaEntidad> _srvCRUD;

        public MaquinariaController() => _srvCRUD = new srvCRUD<MaquinariaEntidad>(tipoCRUD.EQUIPOS);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public object insItem([FromBody] MaquinariaEntidad pItem) => _srvCRUD.Insertar(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public object updItem([FromBody] MaquinariaEntidad pItem) => _srvCRUD.Actualizar(pItem);
        

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public string delItem([FromBody] MaquinariaEntidad pItem)
        {

            if (_srvCRUD.Eliminar(pItem))
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getList")]
        public IEnumerable<object> getList()
        {
            return _srvCRUD.Listado();

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getItemById")]
        public object getItemById([FromBody] FiltrosEntidad filtro) => _srvCRUD.ItemPorId(filtro.idEconomico);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public object getListFilter([FromBody] FiltrosEntidad filtro) => _srvCRUD.ListadoFiltro(filtro);
    }
}
