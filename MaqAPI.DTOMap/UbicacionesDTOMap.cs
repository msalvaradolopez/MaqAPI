using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Entidades;
using MaqAPI.Datos.Catalogos;
using MaqAPI.Datos;
using MaqAPI.Datos.Models;
using MaqAPI.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MaqAPI.DTOMap
{
    public class UbicacionesDTOMap
    {

        public List<UbicacionesDTO> CreateUbicacionesList(IEnumerable<object> pUbicacionesEntity) {

            List<UbicacionesDTO> _ubicacionesDTOList = new List<UbicacionesDTO>();

            List<UbicacionEntidad> _ubicacionEntidadList = new List<UbicacionEntidad>();
            _ubicacionEntidadList = JsonConvert.DeserializeObject<List<UbicacionEntidad>>(JsonConvert.SerializeObject(pUbicacionesEntity, Newtonsoft.Json.Formatting.None));

            var _maquinariaABC = new MaquinariaABC();
            var _catalogosABCMaq = new CatalogosABC(_maquinariaABC);
            List<MaquinariaEntidad> _maquinariaList = JsonConvert.DeserializeObject<List<MaquinariaEntidad>>(JsonConvert.SerializeObject(_catalogosABCMaq.Listado(), Newtonsoft.Json.Formatting.None));

            var _operadoresABC = new OperadoresABC();
            var _catalogosABCOper = new CatalogosABC(_operadoresABC);
            List<OperadorEntidad> _operadoresList = JsonConvert.DeserializeObject<List<OperadorEntidad>>(JsonConvert.SerializeObject(_catalogosABCOper.Listado(), Newtonsoft.Json.Formatting.None));

            var _obrasABC = new ObrasABC();
            var _catalogosABCObras = new CatalogosABC(_obrasABC);
            List<ObraEntidad> _obrasList = JsonConvert.DeserializeObject<List<ObraEntidad>>(JsonConvert.SerializeObject(_catalogosABCObras.Listado(), Newtonsoft.Json.Formatting.None));


            _ubicacionEntidadList.ForEach(item =>
            {
                UbicacionesDTO _ubicacionesDTO = new UbicacionesDTO();

                string idEconomico = item.idEconomico;
                string idOperador = item.idOperador;
                string idObra = item.idObra;                

                _ubicacionesDTO.idUbicacion = item.idUbicacion;
                _ubicacionesDTO.idEconomico = idEconomico;
                _ubicacionesDTO.equipoNom = _maquinariaList.Where(x => x.idEconomico == idEconomico).Select(x => x.Tipo).FirstOrDefault(); // _maquinariaItem.Tipo;
                _ubicacionesDTO.idOperador = idOperador;
                _ubicacionesDTO.operadorNom = _operadoresList.Where(x => x.idOperador == idOperador).Select(x => x.Nombre).FirstOrDefault(); // _operadorItem.Nombre;
                _ubicacionesDTO.idObra = idObra;
                _ubicacionesDTO.obraNom = _obrasList.Where(x => x.idObra == idObra).Select(x => x.Nombre).FirstOrDefault(); // _obrasItem.Nombre;
                _ubicacionesDTO.fecha_alta = item.fecha_alta;
                _ubicacionesDTO.comentarios = item.comentarios;
                _ubicacionesDTO.idUsuario = item.idUsuario;
                _ubicacionesDTO.fecha_ingreso = item.fecha_ingreso;
                _ubicacionesDTO.hodometro = item.hodometro == null ? 0 : (int)item.hodometro;
                _ubicacionesDTO.odometro = item.odometro == null ? 0 : (int)item.odometro;
                _ubicacionesDTO.sello = item.sello;
                _ubicacionesDTO.litros = item.litros == null ? 0 : (int)item.litros;
                _ubicacionesDTO.horometro = item.horometro == null ? 0 : (int)item.horometro;
                _ubicacionesDTO.ventana = item.ventana;

                _ubicacionesDTOList.Add(_ubicacionesDTO);
            });

            return _ubicacionesDTOList;
        }
    }
}
