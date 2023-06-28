using MaqAPI.Entidades;
using MaqAPI.Servicios;
using MaqAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaqAPI.Entidades;
using MaqAPI.Interface;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/bitSeg")]
    public class BitSegController : ApiController
    {

        private srvCRUD<BitSegEntidad> _srvCRUD;
        private IExportaXLSX<BitSegEntidad> _objExportaXLSX;
        private srvFactoryCRUD _srvFactoryCRUD = new srvFactoryCRUD();
        public BitSegController()
        {
            _srvCRUD = new srvCRUD<BitSegEntidad>(tipoCRUD.BITSEG);
            _objExportaXLSX = _srvFactoryCRUD.srvFabrica(tipoCRUD.BITSEG) as IExportaXLSX<BitSegEntidad>;
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getPDF")]
        public string getPDF([FromBody] BitSegDTO pItem) => _srvCRUD.FormatoBASE64(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public object insItem([FromBody] BitSegEntidad pItem) => _srvCRUD.Insertar(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public object updItem([FromBody] BitSegEntidad pItem) => _srvCRUD.Actualizar(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insList")]
        public string insList([FromBody] List<BitSegEntidad> pList)
        {

            if (_srvCRUD.insertar(pList))
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updList")]
        public string updList([FromBody] List<BitSegEntidad> pList)
        {

            if (_srvCRUD.Actualizar(pList))
                return "Registro insertado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public string delItem([FromBody] BitSegEntidad pItem)
        {
            if (_srvCRUD.Eliminar(pItem))
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delList")]
        public string delList([FromBody] List<BitSegEntidad> pList)
        {
            if (_srvCRUD.Eliminar(pList))
                return "Registro eliminado.";
            else
                return "Fallo.";
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public IEnumerable<object> getListFilter([FromBody] FiltrosEntidad _filtros)
        {
            return _srvCRUD.ListadoFiltro(_filtros);

        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getXLSX")]
        public string getXLSX([FromBody] List<BitSegEntidad> pList) => _objExportaXLSX.getXLSX(pList);
    }
}
