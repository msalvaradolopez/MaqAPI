using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaqAPI.DTO;
using MaqAPI.Interface;
using MaqAPI.Servicios;

namespace MaqAPI.Aplicacion.Controllers
{
    [RoutePrefix("api/abpos")]
    public class AbPosController : ApiController
    {
        private ICatalogoItem<AbPosDTO> _objCRUD;
        private IConsultaItem<AbPosDTO> _objConsultas;
        private IFormatos<AbPosDTO> _objFormatos;
        private srvFactoryCRUD _srvFactoryCRUD = new srvFactoryCRUD();

        public AbPosController()
        {
            _objCRUD = _srvFactoryCRUD.srvFabrica(tipoCRUD.ABPOS) as ICatalogoItem<AbPosDTO>;
            _objConsultas = _srvFactoryCRUD.srvFabrica(tipoCRUD.ABPOS) as IConsultaItem<AbPosDTO>;
            _objFormatos = _srvFactoryCRUD.srvFabrica(tipoCRUD.ABPOS) as IFormatos<AbPosDTO>;
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public AbPosDTO insItem([FromBody] AbPosDTO pItem) => _objCRUD.InsertItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public bool updItem([FromBody] AbPosDTO pItem) => _objCRUD.UpdateItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public bool delItem([FromBody] AbPosDTO pItem) => _objCRUD.DeleteItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getItemById")]
        public AbPosDTO getItemById([FromBody] FiltrosDTO pFiltro) => _objConsultas.GetItemById(pFiltro);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public List<AbPosDTO> getListFilter([FromBody] FiltrosDTO pFiltro) => _objConsultas.GetItemList(pFiltro);

    }
}
