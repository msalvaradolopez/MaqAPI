﻿using MaqAPI.Entidades;
using MaqAPI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaqAPI.Interface;
using MaqAPI.DTO;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/ubicaciones")]
    public class UbicacionesController : ApiController
    {

        private srvCRUD<UbicacionEntidad> _srvCRUD;
        private IExportaXLSX<UbicacionesDTO> _objExportaXLSX;
        private srvFactoryCRUD _srvFactoryCRUD = new srvFactoryCRUD();

        public UbicacionesController()
        {
            _srvCRUD = new srvCRUD<UbicacionEntidad>(tipoCRUD.UBICACION);
            _objExportaXLSX = _srvFactoryCRUD.srvFabrica(tipoCRUD.UBICACION) as IExportaXLSX<UbicacionesDTO>;
        }
        
        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public object insItem([FromBody] UbicacionEntidad pItem) => _srvCRUD.Insertar(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public object updItem([FromBody] UbicacionEntidad pItem) => _srvCRUD.Actualizar(pItem);
        
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

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getXLSX")]
        public string getXLSX([FromBody] List<UbicacionesDTO> pList) => _objExportaXLSX.getXLSX(pList);
    }
}
