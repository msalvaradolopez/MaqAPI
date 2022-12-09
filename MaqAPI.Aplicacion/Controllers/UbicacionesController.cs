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

        private srvCRUD<UbicacionEntidad> _srvCRUD;

        public UbicacionesController()
        {
            _srvCRUD = new srvCRUD<UbicacionEntidad>(tipoCRUD.UBICACION);
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public string insItem([FromBody] UbicacionEntidad pItem)
        {

            if (_srvCRUD.Insertar(pItem))
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public string updItem([FromBody] UbicacionEntidad pItem)
        {

            if (_srvCRUD.Actualizar(pItem))
                return "Registro actualizado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public string delItem([FromBody] UbicacionEntidad pItem)
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
        public object getItemById([FromBody] FiltrosEntidad filtro) => _srvCRUD.ItemPorId(filtro.idUbicacion);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public IEnumerable<object> getListFilter([FromBody] FiltrosEntidad filtro) => _srvCRUD.ListadoFiltro(filtro);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getTableroList")]
        public IEnumerable<object> getTableroList([FromBody] FiltrosEntidad _filtros)
        {
            return _srvCRUD.TableroList(_filtros.pagina);

        }
    }
}
