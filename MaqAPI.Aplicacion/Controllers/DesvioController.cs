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
    [RoutePrefix("api/desvio")]
    public class DesvioController : ApiController
    {
        private ICatalogoItem<DesvioDTO> _objCRUD;
        private IConsultaItem<DesvioDTO> _objConsultas;
        private IFormatos<DesvioDTO> _objFormatos;
        private srvFactoryCRUD _srvFactoryCRUD = new srvFactoryCRUD();

        public DesvioController()
        {
            _objCRUD = _srvFactoryCRUD.srvFabrica(tipoCRUD.DESVIO) as ICatalogoItem<DesvioDTO>;
            _objConsultas = _srvFactoryCRUD.srvFabrica(tipoCRUD.DESVIO) as IConsultaItem<DesvioDTO>;
            _objFormatos = _srvFactoryCRUD.srvFabrica(tipoCRUD.DESVIO) as IFormatos<DesvioDTO>;
        }

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public DesvioDTO insItem([FromBody] DesvioDTO pItem) => _objCRUD.InsertItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public bool updItem([FromBody] DesvioDTO pItem) => _objCRUD.UpdateItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public bool delItem([FromBody] DesvioDTO pItem) => _objCRUD.DeleteItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getItemById")]
        public DesvioDTO getItemById([FromBody] FiltrosDTO pFiltro) => _objConsultas.GetItemById(pFiltro);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public List<DesvioDTO> getListFilter([FromBody] FiltrosDTO pFiltro) => _objConsultas.GetItemList(pFiltro);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getPDF")]
        public string getPDF([FromBody] DesvioDTO pItem) => _objFormatos.getPDF(pItem);

    }
}
