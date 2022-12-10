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
        private srvCRUD<OperadorEntidad> _srvCRUD;

        public OperadoresController()
        {
            _srvCRUD = new srvCRUD<OperadorEntidad>(tipoCRUD.OPERADORES);
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public object insItem([FromBody] OperadorEntidad pItem)
        {
            return _srvCRUD.Insertar(pItem);
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public string updItem([FromBody] OperadorEntidad pItem)
        {

            if (_srvCRUD.Actualizar(pItem))
                return "Registro actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public string delItem([FromBody] OperadorEntidad pItem)
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
        public object getItemById([FromBody] FiltrosEntidad filtro)
        {
            return _srvCRUD.ItemPorId(filtro.idOperador);
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public object getListFilter([FromBody] FiltrosEntidad filtro)
        {
            return _srvCRUD.ListadoFiltro(filtro);

        }
    }
}
