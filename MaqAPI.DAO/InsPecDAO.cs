using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Interface;
using MaqAPI.DTO;
using MaqAPI.Datos.Models;
using MaqAPI.Utilerias;
using System.Data.SqlClient;
using System.Data;

namespace MaqAPI.DAO
{
    public class InsPecDAO : ICatalogoItem<InsPecDTO>, IConsultaItem<InsPecDTO>, IFormatos<InsPecDTO>, IExportaXLSX<InsPecDTO>
    {
        public bool DeleteItem(InsPecDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.inspec.Where(x => x.idInspeccion == pItem.idInspeccion).FirstOrDefault();


                    db.inspec.Remove(_ItemModel);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public InsPecDTO GetItemById(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = db.inspec
                        .Where(x => x.docInspeccion == pFiltros.docInspeccion)
                        .Select(x => new InsPecDTO {
                            idInspeccion = x.idInspeccion,
                            docInspeccion = x.docInspeccion,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idEconomico = x.idEconomico,
                            idOperador = x.idOperador,
                            turno = x.turno,
                            horometro = x.horometro,
                            idResponsableMtto = x.idResponsableMtto,
                            frenos = x.frenos,
                            frenos_obs = x.frenos_obs,
                            alarma_rev = x.alarma_rev,
                            alarma_rev_obs = x.alarma_rev_obs,
                            nivel_aceite = x.nivel_aceite,
                            nivel_aceite_obs = x.nivel_aceite_obs,
                            motor = x.motor,
                            motor_obs = x.motor,
                            transmision = x.transmision,
                            transmision_obs = x.transmision_obs,
                            fugas_aceite = x.fugas_aceite,
                            fugas_aceite_obs = x.fugas_aceite_obs,
                            nivel_agua = x.nivel_agua,
                            nivel_agua_obs = x.nivel_agua_obs,
                            extinguidor = x.extinguidor,
                            extinguidor_obs = x.extinguidor_obs,
                            luces = x.luces,
                            luces_obs = x.luces_obs,
                            torreta = x.torreta,
                            torreta_obs = x.torreta_obs,
                            neumaticos = x.neumaticos,
                            neumaticos_obs = x.neumaticos_obs,
                            pernos_bujes = x.pernos_bujes,
                            pernos_bujes_obs = x.pernos_bujes_obs,
                            direccion = x.direccion,
                            direccion_obs = x.direccion_obs,
                            espejos_retrovisores = x.espejos_retrovisores,
                            espejos_retrovisores_obs = x.espejos_retrovisores_obs,
                            claxon = x.claxon,
                            claxon_obs = x.claxon_obs,
                            cinturon_seguridad = x.cinturon_seguridad,
                            cinturon_seguridad_obs = x.cinturon_seguridad_obs,
                            nomSupervisor = x.operadores2.Nombre,
                            nomOperador = x.operadores.Nombre,
                            nomResponsableMtto = x.operadores1.Nombre,
                            nomEquipo = x.maquinaria.Tipo

                        })
                        .FirstOrDefault();

                    /*
                     (x.idObra.Contains(_filtros.buscar)
                                        || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                    */
                    return _item;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<InsPecDTO> GetItemList(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _list = db.inspec
                        .Where(x => 
                        (x.idSupervisor == pFiltros.idSupervisor || pFiltros.idSupervisor == "0")
                        && (x.idOperador == pFiltros.idOperador || pFiltros.idOperador == "0")
                        && (x.idEconomico == pFiltros.idEconomico || pFiltros.idEconomico == "0")
                        && (x.idResponsableMtto == pFiltros.idResponsableMtto || pFiltros.idResponsableMtto == "0")
                        && (x.fecha.Year == pFiltros.anno && x.fecha.Month == pFiltros.mes && (x.fecha.Day == pFiltros.dia ||  pFiltros.dia == 0))
                        )
                        .Select(x => new InsPecDTO
                        {
                            idInspeccion = x.idInspeccion,
                            docInspeccion = x.docInspeccion,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idEconomico = x.idEconomico,
                            idOperador = x.idOperador,
                            turno = x.turno,
                            horometro = x.horometro,
                            idResponsableMtto = x.idResponsableMtto,
                            frenos = x.frenos,
                            frenos_obs = x.frenos_obs,
                            alarma_rev = x.alarma_rev,
                            alarma_rev_obs = x.alarma_rev_obs,
                            nivel_aceite = x.nivel_aceite,
                            nivel_aceite_obs = x.nivel_aceite_obs,
                            motor = x.motor,
                            motor_obs = x.motor,
                            transmision = x.transmision,
                            transmision_obs = x.transmision_obs,
                            fugas_aceite = x.fugas_aceite,
                            fugas_aceite_obs = x.fugas_aceite_obs,
                            nivel_agua = x.nivel_agua,
                            nivel_agua_obs = x.nivel_agua_obs,
                            extinguidor = x.extinguidor,
                            extinguidor_obs = x.extinguidor_obs,
                            luces = x.luces,
                            luces_obs = x.luces_obs,
                            torreta = x.torreta,
                            torreta_obs = x.torreta_obs,
                            neumaticos = x.neumaticos,
                            neumaticos_obs = x.neumaticos_obs,
                            pernos_bujes = x.pernos_bujes,
                            pernos_bujes_obs = x.pernos_bujes_obs,
                            direccion = x.direccion,
                            direccion_obs = x.direccion_obs,
                            espejos_retrovisores = x.espejos_retrovisores,
                            espejos_retrovisores_obs = x.espejos_retrovisores_obs,
                            claxon = x.claxon,
                            claxon_obs = x.claxon_obs,
                            cinturon_seguridad = x.cinturon_seguridad,
                            cinturon_seguridad_obs = x.cinturon_seguridad_obs,
                            nomSupervisor = x.operadores2.Nombre,
                            nomOperador = x.operadores.Nombre,
                            nomResponsableMtto = x.operadores1.Nombre,
                            nomEquipo = x.maquinaria.Tipo
                        })
                        .ToList();

                    /*
                     (x.idObra.Contains(_filtros.buscar)
                                        || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                    */

                    if(pFiltros.buscar != "")
                        _list = _list.Where(x => x.nomSupervisor.Contains(pFiltros.buscar)
                        || x.nomOperador.Contains(pFiltros.buscar)
                        || x.nomResponsableMtto.Contains(pFiltros.buscar)
                        || x.nomEquipo.Contains(pFiltros.buscar)
                        ).ToList();

                    return _list;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string getPDF(InsPecDTO pItem)
        {
            try
            {
                var _html = getHTML(pItem);
                
                generaPDF _generaPDF = new generaPDF();
                return _generaPDF.createPDFtoBASE64(_html);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getHTML(InsPecDTO pItem) {
            try
            {

                var _headerHTML = getHeaderHTML(pItem);
                var _detailHTML = getDetailHTML(pItem);
                var _footerHTML = getFooterHTML();
                return _headerHTML + _detailHTML + _footerHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getHeaderHTML(InsPecDTO pItem) {
            try
            {
                var _docInspreccion = pItem.docInspeccion;
                var _fecha = pItem.fecha;
                var _supervisorNom = pItem.nomSupervisor;
                var _idEconomico = pItem.idEconomico;
                var _nomUnidad = pItem.nomEquipo;
                var _nomOperador = pItem.nomOperador;
                var _nomResponsableMtto = pItem.nomResponsableMtto;
                var _turno = pItem.turno;
                var _horometro = pItem.horometro;

                var _nomTurno = "";

                if (_turno == "M")
                    _nomTurno = "Matutino";

                if (_turno == "V")
                    _nomTurno = "Vespertino";

                if (_turno == "N")
                    _nomTurno = "Nocturno";

                string stringHTMLaux = "<table align='center' border='0' cellpadding='1' cellspacing='1' style='height:10px;width:100%'><tbody><tr><td style='text-align:center'><p><span style='font-size:22px'><strong>GRUPO BITESA</strong></span></p><p><span style='font-size:14px'><strong><u>LISTA DE INSPECCI&Oacute;N ANTES DE INICIO DE TURNO A LA UNIDAD M&Oacute;VIL</u></strong></span></p><p>&nbsp;</p><p style='text-align:right'><span style='font-size:10px'><strong># Inspecci&oacute;n: _docInspeccion</strong></span></p></td></tr></tbody></table><table border='0' cellpadding='5' cellspacing='1' style='height:30px;width:100%'><tbody><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>FECHA</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_fecha</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>SUPERVISOR:</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_supervisorNom</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>UNIDAD:</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_nomEquipo</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>OPERADOR</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_nomOperador</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>TURNO:</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_turno</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>RESPONSABLE MTTO:</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_nomResponsableMtto</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>Hor&oacute;metro</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_horometro</span></td><td style='text-align:right;width:175px'>&nbsp;</td><td style='background-color:#ccc;width:508px'>&nbsp;</td></tr></tbody></table>";

                string stringHTML = stringHTMLaux.Replace("_docInspeccion", _docInspreccion.ToString())
                    .Replace("_fecha", _fecha.ToString())
                    .Replace("_supervisorNom", _supervisorNom)
                    .Replace("_nomEquipo", _nomUnidad)
                    .Replace("_nomOperador", _nomOperador)
                    .Replace("_turno", _nomTurno)
                    .Replace("_nomResponsableMtto", _nomResponsableMtto)
                    .Replace("_horometro", _horometro.ToString());

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getDetailHTML(InsPecDTO pItem) {
            using (var db = new MaquinariaEntities())
            {

                try
                {
                    var _List = new List<InsPecSemanaDTO>();


                    var IntInspeccion = new SqlParameter("@idInspeccion", pItem.idInspeccion);

                    _List = db.Database
                   .SqlQuery<InsPecSemanaDTO>("spInsPecSemana @idInspeccion", IntInspeccion)
                   .ToList();

                    var stringHTML = "<p>&nbsp;</p><table border='1' cellpadding='5' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>No</span></td><td style='background-color:#ccc;text-align:center;width:200px'><span style='font-size:8px'>DESCRIPCION</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>L</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>M</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>M</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>J</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>V</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>S</span></td><td style='background-color:#ccc;text-align:center;width:70px'><span style='font-size:8px'>D</span></td><td style='background-color:#ccc;text-align:center;width:250px'><span style='font-size:8px'>OBSERVACIONES</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>1</span></td><td style='width:134px'><span style='font-size:8px'>FRENOS</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_frenos_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_frenos_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_frenos_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_frenos_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_frenos_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_frenos_S</span></td><td style='text-align:center;width:150px'><span style='font-size:8px'>_frenos_D</span></td><td style='width:558px'><span style='font-size:8px'>_frenos_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>2</span></td><td style='width:134px'><span style='font-size:8px'>ALARMA/REV</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_alarma_rev_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_alarma_rev_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_alarma_rev_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_alarma_rev_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_alarma_rev_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_alarma_rev_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_alarma_rev_D</span></td><td style='width:558px'><span style='font-size:8px'>_alarma_rev_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>3</span></td><td style='width:134px'><span style='font-size:8px'>NIVEL/ACEITE</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_nivel_aceite_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_aceite_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_aceite_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_nivel_aceite_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_nivel_aceite_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_aceite_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_aceite_D</span></td><td style='width:558px'><span style='font-size:8px'>_nivel_aceite_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>4</span></td><td style='width:134px'><span style='font-size:8px'>MOTOR</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_motor_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_motor_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_motor_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_motor_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_motor_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_motor_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_motor_D</span></td><td style='width:558px'><span style='font-size:8px'>_motor_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>5</span></td><td style='width:134px'><span style='font-size:8px'>TRANSMISI&Oacute;N</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_transmision_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_transmision_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_transmision_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_transmision_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_transmision_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_transmision_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_transmision_D</span></td><td style='width:558px'><span style='font-size:8px'>_transmision_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>6</span></td><td style='width:134px'><span style='font-size:8px'>FUGAS DE ACEITE</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_fugas_aceite_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_fugas_aceite_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_fugas_aceite_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_fugas_aceite_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_fugas_aceite_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_fugas_aceite_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_fugas_aceite_D</span></td><td style='width:558px'><span style='font-size:8px'>_fugas_aceite_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>7</span></td><td style='width:134px'><span style='font-size:8px'>NIVEL/AGUA</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_nivel_agua_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_agua_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_agua_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_nivel_agua_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_nivel_agua_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_agua_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_nivel_agua_D</span></td><td style='width:558px'><span style='font-size:8px'>_nivel_agua_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>8</span></td><td style='width:134px'><span style='font-size:8px'>EXTINGUIDOR</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_extinguidor_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_extinguidor_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_extinguidor_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_extinguidor_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_extinguidor_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_extinguidor_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_extinguidor_D</span></td><td style='width:558px'><span style='font-size:8px'>_extinguidor_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>9</span></td><td style='width:134px'><span style='font-size:8px'>LUCES</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_luces_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_luces_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_luces_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_luces_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_luces_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_luces_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_luces_D</span></td><td style='width:558px'><span style='font-size:8px'>_luces_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>10</span></td><td style='width:134px'><span style='font-size:8px'>TORRETA</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_torreta_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_torreta_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_torreta_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_torreta_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_torreta_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_torreta_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_torreta_D</span></td><td style='width:558px'><span style='font-size:8px'>_torreta_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>11</span></td><td style='width:134px'><span style='font-size:8px'>NEUM&Aacute;TICOS</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_neumaticos_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_neumaticos_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_neumaticos_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_neumaticos_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_neumaticos_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_neumaticos_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_neumaticos_D</span></td><td style='width:558px'><span style='font-size:8px'>_neumaticos_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>12</span></td><td style='width:134px'><span style='font-size:8px'>PERNOS/BUJES</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_pernos_bujes_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_pernos_bujes_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_pernos_bujes_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_pernos_bujes_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_pernos_bujes_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_pernos_bujes_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_pernos_bujes_D</span></td><td style='width:558px'><span style='font-size:8px'>_pernos_bujes_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>13</span></td><td style='width:134px'><span style='font-size:8px'>DIRECCI&Oacute;N</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_direccion_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_direccion_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_direccion_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_direccion_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_direccion_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_direccion_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_direccion_D</span></td><td style='width:558px'><span style='font-size:8px'>_direccion_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>14</span></td><td style='width:134px'><span style='font-size:8px'>ESPEJOS RETROVISORES</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_espejos_retrovisores_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_espejos_retrovisores_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_espejos_retrovisores_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_espejos_retrovisores_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_espejos_retrovisores_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_espejos_retrovisores_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_espejos_retrovisores_D</span></td><td style='width:558px'><span style='font-size:8px'>_espejos_retrovisores_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>15</span></td><td style='width:134px'><span style='font-size:8px'>CLAXON</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_claxon_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_claxon_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_claxon_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_claxon_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_claxon_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_claxon_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_claxon_D</span></td><td style='width:558px'><span style='font-size:8px'>_claxon_obs</span></td></tr><tr><td colspan='1' style='text-align:center;width:85px'><span style='font-size:8px'>16</span></td><td style='width:134px'><span style='font-size:8px'>CONTURON DE SEGURIDAD</span></td><td style='text-align:center;width:46px'><span style='font-size:8px'>_cinturon_seguridad_L</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_cinturon_seguridad_M</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_cinturon_seguridad_X</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_cinturon_seguridad_J</span></td><td style='text-align:center;width:53px'><span style='font-size:8px'>_cinturon_seguridad_V</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_cinturon_seguridad_S</span></td><td style='text-align:center;width:37px'><span style='font-size:8px'>_cinturon_seguridad_D</span></td><td style='width:558px'><span style='font-size:8px'>_cinturon_seguridad_obs</span></td></tr></tbody></table>";

                    _List.ForEach(item =>
                    {
                        if (item.concepto == "frenos")
                            stringHTML = stringHTML.Replace("_frenos_L", item.lunes)
                            .Replace("_frenos_M", item.martes)
                            .Replace("_frenos_X", item.miercoles)
                            .Replace("_frenos_J", item.jueves)
                            .Replace("_frenos_V", item.viernes)
                            .Replace("_frenos_S", item.sabado)
                            .Replace("_frenos_D", item.domingo)
                            .Replace("_frenos_obs", item.observaciones);

                        if (item.concepto == "alarma_rev")
                            stringHTML = stringHTML.Replace("_alarma_rev_L", item.lunes)
                            .Replace("_alarma_rev_M", item.martes)
                            .Replace("_alarma_rev_X", item.miercoles)
                            .Replace("_alarma_rev_J", item.jueves)
                            .Replace("_alarma_rev_V", item.viernes)
                            .Replace("_alarma_rev_S", item.sabado)
                            .Replace("_alarma_rev_D", item.domingo)
                            .Replace("_alarma_rev_obs", item.observaciones);

                        if (item.concepto == "nivel_aceite")
                            stringHTML = stringHTML.Replace("_nivel_aceite_L", item.lunes)
                            .Replace("_nivel_aceite_M", item.martes)
                            .Replace("_nivel_aceite_X", item.miercoles)
                            .Replace("_nivel_aceite_J", item.jueves)
                            .Replace("_nivel_aceite_V", item.viernes)
                            .Replace("_nivel_aceite_S", item.sabado)
                            .Replace("_nivel_aceite_D", item.domingo)
                            .Replace("_nivel_aceite_obs", item.observaciones);

                        if (item.concepto == "motor")
                            stringHTML = stringHTML.Replace("_motor_L", item.lunes)
                            .Replace("_motor_M", item.martes)
                            .Replace("_motor_X", item.miercoles)
                            .Replace("_motor_J", item.jueves)
                            .Replace("_motor_V", item.viernes)
                            .Replace("_motor_S", item.sabado)
                            .Replace("_motor_D", item.domingo)
                            .Replace("_motor_obs", item.observaciones);

                        if (item.concepto == "transmision")
                            stringHTML = stringHTML.Replace("_transmision_L", item.lunes)
                            .Replace("_transmision_M", item.martes)
                            .Replace("_transmision_X", item.miercoles)
                            .Replace("_transmision_J", item.jueves)
                            .Replace("_transmision_V", item.viernes)
                            .Replace("_transmision_S", item.sabado)
                            .Replace("_transmision_D", item.domingo)
                            .Replace("_transmision_obs", item.observaciones);

                        if (item.concepto == "fugas_aceite")
                            stringHTML = stringHTML.Replace("_fugas_aceite_L", item.lunes)
                            .Replace("_fugas_aceite_M", item.martes)
                            .Replace("_fugas_aceite_X", item.miercoles)
                            .Replace("_fugas_aceite_J", item.jueves)
                            .Replace("_fugas_aceite_V", item.viernes)
                            .Replace("_fugas_aceite_S", item.sabado)
                            .Replace("_fugas_aceite_D", item.domingo)
                            .Replace("_fugas_aceite_obs", item.observaciones);

                        if (item.concepto == "nivel_agua")
                            stringHTML = stringHTML.Replace("_nivel_agua_L", item.lunes)
                            .Replace("_nivel_agua_M", item.martes)
                            .Replace("_nivel_agua_X", item.miercoles)
                            .Replace("_nivel_agua_J", item.jueves)
                            .Replace("_nivel_agua_V", item.viernes)
                            .Replace("_nivel_agua_S", item.sabado)
                            .Replace("_nivel_agua_D", item.domingo)
                            .Replace("_nivel_agua_obs", item.observaciones);

                        if (item.concepto == "extinguidor")
                            stringHTML = stringHTML.Replace("_extinguidor_L", item.lunes)
                            .Replace("_extinguidor_M", item.martes)
                            .Replace("_extinguidor_X", item.miercoles)
                            .Replace("_extinguidor_J", item.jueves)
                            .Replace("_extinguidor_V", item.viernes)
                            .Replace("_extinguidor_S", item.sabado)
                            .Replace("_extinguidor_D", item.domingo)
                            .Replace("_extinguidor_obs", item.observaciones);

                        if (item.concepto == "luces")
                            stringHTML = stringHTML.Replace("_luces_L", item.lunes)
                            .Replace("_luces_M", item.martes)
                            .Replace("_luces_X", item.miercoles)
                            .Replace("_luces_J", item.jueves)
                            .Replace("_luces_V", item.viernes)
                            .Replace("_luces_S", item.sabado)
                            .Replace("_luces_D", item.domingo)
                            .Replace("_luces_obs", item.observaciones);

                        if (item.concepto == "torreta")
                            stringHTML = stringHTML.Replace("_torreta_L", item.lunes)
                            .Replace("_torreta_M", item.martes)
                            .Replace("_torreta_X", item.miercoles)
                            .Replace("_torreta_J", item.jueves)
                            .Replace("_torreta_V", item.viernes)
                            .Replace("_torreta_S", item.sabado)
                            .Replace("_torreta_D", item.domingo)
                            .Replace("_torreta_obs", item.observaciones);

                        if (item.concepto == "neumaticos")
                            stringHTML = stringHTML.Replace("_neumaticos_L", item.lunes)
                            .Replace("_neumaticos_M", item.martes)
                            .Replace("_neumaticos_X", item.miercoles)
                            .Replace("_neumaticos_J", item.jueves)
                            .Replace("_neumaticos_V", item.viernes)
                            .Replace("_neumaticos_S", item.sabado)
                            .Replace("_neumaticos_D", item.domingo)
                            .Replace("_neumaticos_obs", item.observaciones);

                        if (item.concepto == "pernos_bujes")
                            stringHTML = stringHTML.Replace("_pernos_bujes_L", item.lunes)
                            .Replace("_pernos_bujes_M", item.martes)
                            .Replace("_pernos_bujes_X", item.miercoles)
                            .Replace("_pernos_bujes_J", item.jueves)
                            .Replace("_pernos_bujes_V", item.viernes)
                            .Replace("_pernos_bujes_S", item.sabado)
                            .Replace("_pernos_bujes_D", item.domingo)
                            .Replace("_pernos_bujes_obs", item.observaciones);

                        if (item.concepto == "direccion")
                            stringHTML = stringHTML.Replace("_direccion_L", item.lunes)
                            .Replace("_direccion_M", item.martes)
                            .Replace("_direccion_X", item.miercoles)
                            .Replace("_direccion_J", item.jueves)
                            .Replace("_direccion_V", item.viernes)
                            .Replace("_direccion_S", item.sabado)
                            .Replace("_direccion_D", item.domingo)
                            .Replace("_direccion_obs", item.observaciones);

                        if (item.concepto == "espejos_retrovisores")
                            stringHTML = stringHTML.Replace("_espejos_retrovisores_L", item.lunes)
                            .Replace("_espejos_retrovisores_M", item.martes)
                            .Replace("_espejos_retrovisores_X", item.miercoles)
                            .Replace("_espejos_retrovisores_J", item.jueves)
                            .Replace("_espejos_retrovisores_V", item.viernes)
                            .Replace("_espejos_retrovisores_S", item.sabado)
                            .Replace("_espejos_retrovisores_D", item.domingo)
                            .Replace("_espejos_retrovisores_obs", item.observaciones);

                        if (item.concepto == "claxon")
                            stringHTML = stringHTML.Replace("_claxon_L", item.lunes)
                            .Replace("_claxon_M", item.martes)
                            .Replace("_claxon_X", item.miercoles)
                            .Replace("_claxon_J", item.jueves)
                            .Replace("_claxon_V", item.viernes)
                            .Replace("_claxon_S", item.sabado)
                            .Replace("_claxon_D", item.domingo)
                            .Replace("_claxon_obs", item.observaciones);

                        if (item.concepto == "cinturon_seguridad")
                            stringHTML = stringHTML.Replace("_cinturon_seguridad_L", item.lunes)
                            .Replace("_cinturon_seguridad_M", item.martes)
                            .Replace("_cinturon_seguridad_X", item.miercoles)
                            .Replace("_cinturon_seguridad_J", item.jueves)
                            .Replace("_cinturon_seguridad_V", item.viernes)
                            .Replace("_cinturon_seguridad_S", item.sabado)
                            .Replace("_cinturon_seguridad_D", item.domingo)
                            .Replace("_cinturon_seguridad_obs", item.observaciones);



                    });

                    
                    return stringHTML;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private string getFooterHTML() {
            try
            {
                var stringHTML = "<p>&nbsp;</p><table border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='width:481px'><span style='font-size:8px'>FIRMA DEL OPERADOR</span></td><td rowspan='6' style='width:53px'>&nbsp;</td><td style='width:633px'><span style='font-size:8px'>FIRMA DE MANTENIMIENTO</span></td></tr><tr><td style='width:481px'><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p></td><td style='width:633px'>&nbsp;</td></tr><tr><td style='width:481px'><span style='font-size:8px'>FECHA</span></td><td style='width:633px'><span style='font-size:8px'>FECHA</span></td></tr><tr><td style='width:481px'><span style='font-size:8px'>FIRMA DEL SUPERVISOR</span></td><td style='width:633px'><span style='font-size:8px'>FIRMA DE SEGURIDAD</span></td></tr><tr><td style='width:481px'><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p></td><td style='width:633px'>&nbsp;</td></tr><tr><td style='width:481px'><span style='font-size:8px'>FECHA</span></td><td style='width:633px'><span style='font-size:8px'>FECHA</span></td></tr></tbody></table><p>&nbsp;</p>";

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public InsPecDTO InsertItem(InsPecDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _docInspreccion = 0;
                    int _idInspreccion = 0;

                    _idInspreccion = pItem.idInspeccion;
                    if (_idInspreccion != 0)
                        throw new Exception("El registro ya existe.");

                    _docInspreccion = pItem.docInspeccion;
                    if (_docInspreccion == 0)
                    {
                        var _params = db.parametros.Where(x => x.nombre == "docInspeccion").Select(x => x).FirstOrDefault();
                        if (!string.IsNullOrEmpty(_params.valor))
                            _docInspreccion = Convert.ToInt32(_params.valor);

                        _docInspreccion++;
                        pItem.docInspeccion = _docInspreccion;
                        _params.valor = _docInspreccion.ToString();
                    }


                    var _ItemModel = new inspec();

                    _ItemModel.docInspeccion = pItem.docInspeccion;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idEconomico = pItem.idEconomico;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.turno = pItem.turno;
                    _ItemModel.horometro = pItem.horometro;
                    _ItemModel.idResponsableMtto = pItem.idResponsableMtto;
                    _ItemModel.frenos = pItem.frenos;
                    _ItemModel.frenos_obs = pItem.frenos_obs;
                    _ItemModel.alarma_rev = pItem.alarma_rev;
                    _ItemModel.alarma_rev_obs = pItem.alarma_rev_obs;
                    _ItemModel.nivel_aceite = pItem.nivel_aceite;
                    _ItemModel.nivel_aceite_obs = pItem.nivel_aceite_obs;
                    _ItemModel.motor = pItem.motor;
                    _ItemModel.motor_obs = pItem.motor_obs;
                    _ItemModel.transmision = pItem.transmision;
                    _ItemModel.transmision_obs = pItem.transmision_obs;
                    _ItemModel.fugas_aceite = pItem.fugas_aceite;
                    _ItemModel.fugas_aceite_obs = pItem.fugas_aceite_obs;
                    _ItemModel.nivel_agua = pItem.nivel_agua;
                    _ItemModel.nivel_agua_obs = pItem.nivel_agua_obs;
                    _ItemModel.extinguidor = pItem.extinguidor;
                    _ItemModel.extinguidor_obs = pItem.extinguidor_obs;
                    _ItemModel.luces = pItem.luces;
                    _ItemModel.luces_obs = pItem.luces_obs;
                    _ItemModel.torreta = pItem.torreta;
                    _ItemModel.torreta_obs = pItem.torreta_obs;
                    _ItemModel.neumaticos = pItem.neumaticos;
                    _ItemModel.neumaticos_obs = pItem.neumaticos_obs;
                    _ItemModel.pernos_bujes = pItem.pernos_bujes;
                    _ItemModel.pernos_bujes_obs = pItem.pernos_bujes_obs;
                    _ItemModel.direccion = pItem.direccion;
                    _ItemModel.direccion_obs = pItem.direccion_obs;
                    _ItemModel.espejos_retrovisores = pItem.espejos_retrovisores;
                    _ItemModel.espejos_retrovisores_obs = pItem.espejos_retrovisores_obs;
                    _ItemModel.claxon = pItem.claxon;
                    _ItemModel.claxon_obs = pItem.claxon_obs;
                    _ItemModel.cinturon_seguridad = pItem.cinturon_seguridad;
                    _ItemModel.cinturon_seguridad_obs = pItem.cinturon_seguridad_obs;


                    db.inspec.Add(_ItemModel);
                    db.SaveChanges();

                    pItem.idInspeccion = _ItemModel.idInspeccion;
                    return pItem;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public bool UpdateItem(InsPecDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                   
                    var _ItemModel = db.inspec.Where(x => x.idInspeccion == pItem.idInspeccion).FirstOrDefault();

                    _ItemModel.idInspeccion = pItem.idInspeccion;
                    _ItemModel.docInspeccion = pItem.docInspeccion;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idEconomico = pItem.idEconomico;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.turno = pItem.turno;
                    _ItemModel.horometro = pItem.horometro;
                    _ItemModel.idResponsableMtto = pItem.idResponsableMtto;
                    _ItemModel.frenos = pItem.frenos;
                    _ItemModel.frenos_obs = pItem.frenos_obs;
                    _ItemModel.alarma_rev = pItem.alarma_rev;
                    _ItemModel.alarma_rev_obs = pItem.alarma_rev_obs;
                    _ItemModel.nivel_aceite = pItem.nivel_aceite;
                    _ItemModel.nivel_aceite_obs = pItem.nivel_aceite_obs;
                    _ItemModel.motor = pItem.motor;
                    _ItemModel.motor_obs = pItem.motor_obs;
                    _ItemModel.transmision = pItem.transmision;
                    _ItemModel.transmision_obs = pItem.transmision_obs;
                    _ItemModel.fugas_aceite = pItem.fugas_aceite;
                    _ItemModel.fugas_aceite_obs = pItem.fugas_aceite_obs;
                    _ItemModel.nivel_agua = pItem.nivel_agua;
                    _ItemModel.nivel_agua_obs = pItem.nivel_agua_obs;
                    _ItemModel.extinguidor = pItem.extinguidor;
                    _ItemModel.extinguidor_obs = pItem.extinguidor_obs;
                    _ItemModel.luces = pItem.luces;
                    _ItemModel.luces_obs = pItem.luces_obs;
                    _ItemModel.torreta = pItem.torreta;
                    _ItemModel.torreta_obs = pItem.torreta_obs;
                    _ItemModel.neumaticos = pItem.neumaticos;
                    _ItemModel.neumaticos_obs = pItem.neumaticos_obs;
                    _ItemModel.pernos_bujes = pItem.pernos_bujes;
                    _ItemModel.pernos_bujes_obs = pItem.pernos_bujes_obs;
                    _ItemModel.direccion = pItem.direccion;
                    _ItemModel.direccion_obs = pItem.direccion_obs;
                    _ItemModel.espejos_retrovisores = pItem.espejos_retrovisores;
                    _ItemModel.espejos_retrovisores_obs = pItem.espejos_retrovisores_obs;
                    _ItemModel.claxon = pItem.claxon;
                    _ItemModel.claxon_obs = pItem.claxon_obs;
                    _ItemModel.cinturon_seguridad = pItem.cinturon_seguridad;
                    _ItemModel.cinturon_seguridad_obs = pItem.cinturon_seguridad_obs;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string getXLSX(List<InsPecDTO> pList)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Documento", typeof(string)));
                dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
                dt.Columns.Add(new DataColumn("Supervisor", typeof(string)));
                dt.Columns.Add(new DataColumn("Equipo", typeof(string)));
                dt.Columns.Add(new DataColumn("Operador", typeof(string)));
                dt.Columns.Add(new DataColumn("Turno", typeof(string)));
                dt.Columns.Add(new DataColumn("Horometro", typeof(double)));
                dt.Columns.Add(new DataColumn("Mantenimiento", typeof(string)));
                dt.Columns.Add(new DataColumn("Frenos", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Frenos", typeof(string)));
                dt.Columns.Add(new DataColumn("Alarma/Rev", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Alarma/Rev", typeof(string)));
                dt.Columns.Add(new DataColumn("Nivel aceite", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs nivel aceite", typeof(string)));
                dt.Columns.Add(new DataColumn("Motor", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs motor", typeof(string)));
                dt.Columns.Add(new DataColumn("Transmision", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Transmision", typeof(string)));
                dt.Columns.Add(new DataColumn("Fugas aceite", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs fugas aceite", typeof(string)));
                dt.Columns.Add(new DataColumn("Nivel agua", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs nivel agua", typeof(string)));
                dt.Columns.Add(new DataColumn("Extinguidor", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs extinguidor", typeof(string)));
                dt.Columns.Add(new DataColumn("Luces", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs luces", typeof(string)));
                dt.Columns.Add(new DataColumn("Torreta", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs torreta", typeof(string)));
                dt.Columns.Add(new DataColumn("Neumaticos", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs neumaticos", typeof(string)));
                dt.Columns.Add(new DataColumn("Pernos/bujes", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Pernos/bujes", typeof(string)));
                dt.Columns.Add(new DataColumn("Direccion", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs direccion", typeof(string)));
                dt.Columns.Add(new DataColumn("Espejos retrovisores", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs espejso retrovisores", typeof(string)));
                dt.Columns.Add(new DataColumn("Claxon", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs claxon", typeof(string)));
                dt.Columns.Add(new DataColumn("Cinturon seguridad", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs cinturon seguridad", typeof(string)));

                pList.ForEach(x => {
                    dt.Rows.Add(x.docInspeccion, x.fecha.ToString("dd-MM-yyyy"), x.idSupervisor + "|" + x.nomSupervisor, x.idEconomico + "|" + x.nomEquipo,
                        x.idOperador + "|" + x.nomOperador, valorTurno(x.turno), x.horometro, x.idResponsableMtto + "|" + x.nomResponsableMtto, valorCampos(x.frenos), x.frenos_obs,
                        valorCampos(x.alarma_rev), x.alarma_rev_obs, valorCampos(x.nivel_aceite), x.nivel_aceite_obs, valorCampos(x.motor), x.motor_obs, valorCampos(x.transmision), x.transmision_obs,
                        valorCampos(x.fugas_aceite), x.fugas_aceite_obs, valorCampos(x.nivel_agua), x.nivel_agua_obs, valorCampos(x.extinguidor), x.extinguidor_obs, valorCampos(x.luces), x.luces_obs,
                        valorCampos(x.torreta), x.torreta_obs, valorCampos(x.neumaticos), x.neumaticos_obs, valorCampos(x.pernos_bujes), x.pernos_bujes_obs, valorCampos(x.direccion), x.direccion_obs,
                        valorCampos(x.espejos_retrovisores), x.espejos_retrovisores_obs, valorCampos(x.claxon), x.claxon_obs, valorCampos(x.cinturon_seguridad), x.cinturon_seguridad_obs);
                });

                generaPDF _generaPDF = new generaPDF();
                return _generaPDF.createXLSXtoBase64(dt);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string valorTurno(string pData) => pData == "M" ? "Matutino" : pData == "V" ? "Vespertino" : "Nocturno";

        private string valorCampos(string pData) => pData == "O" ? "OK" : "FALLA";
        
    }
}

