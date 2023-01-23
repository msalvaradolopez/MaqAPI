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
    [RoutePrefix("api/inspec")]
    public class InsPecController : ApiController
    {
        private ICatalogoItem<InsPecDTO> _objCRUD;
        private IConsultaItem<InsPecDTO> _objConsultas;
        private IFormatos<InsPecDTO> _objFormatos;
        private srvFactoryCRUD _srvFactoryCRUD = new srvFactoryCRUD();

        public InsPecController() {
            _objCRUD = _srvFactoryCRUD.srvFabrica(tipoCRUD.INSPEC) as ICatalogoItem<InsPecDTO>;
            _objConsultas = _srvFactoryCRUD.srvFabrica(tipoCRUD.INSPEC) as IConsultaItem<InsPecDTO>;
            _objFormatos = _srvFactoryCRUD.srvFabrica(tipoCRUD.INSPEC) as IFormatos<InsPecDTO>;
        } 

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("insItem")]
        public InsPecDTO insItem([FromBody] InsPecDTO pItem) => _objCRUD.InsertItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("updItem")]
        public bool updItem([FromBody] InsPecDTO pItem) => _objCRUD.UpdateItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("delItem")]
        public bool delItem([FromBody] InsPecDTO pItem) => _objCRUD.DeleteItem(pItem);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getItemById")]
        public InsPecDTO getItemById([FromBody] FiltrosDTO pFiltro) => _objConsultas.GetItemById(pFiltro);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getListFilter")]
        public List<InsPecDTO> getListFilter([FromBody] FiltrosDTO pFiltro) => _objConsultas.GetItemList(pFiltro);

        [AcceptVerbs("POST")]
        [HttpPost()]
        [Route("getPDF")]
        public string getPDF([FromBody] InsPecDTO pItem) => _objFormatos.getPDF(pItem);
    }
}
