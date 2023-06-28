using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Interface;
using MaqAPI.DTO;
using MaqAPI.Datos.Models;
using MaqAPI.Utilerias;
using System.Data;

namespace MaqAPI.DAO
{
    public class DesvioDAO : ICatalogoItem<DesvioDTO>, IConsultaItem<DesvioDTO>, IFormatos<DesvioDTO>, IExportaXLSX<DesvioDTO>
    {
        public bool DeleteItem(DesvioDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.desvio.Where(x => x.idDesvio == pItem.idDesvio).FirstOrDefault();


                    db.desvio.Remove(_ItemModel);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public DesvioDTO GetItemById(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = db.desvio
                        .Where(x => x.idDesvio == pFiltros.idDesvio)
                        .Select(x => new DesvioDTO
                        {
                            idDesvio = x.idDesvio,
                            numTabulador = x.numTabulador,
                            area = x.area,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            evento = x.evento,
                            estado_prisa = x.estado_prisa,
                            estado_frustacion = x.estado_frustacion,
                            estado_fatiga = x.estado_fatiga,
                            estado_complacencia = x.estado_complacencia,
                            error_ojos_no_tarea = x.error_ojos_no_tarea,
                            error_mente_no_tarea = x.error_mente_no_tarea,
                            error_mala_colocacion = x.error_mala_colocacion,
                            error_perdida_equilibrio = x.error_perdida_equilibrio,
                            observaciones = x.observaciones,
                            caidas = x.caidas,
                            golpes = x.golpes,
                            quemaduras = x.quemaduras,
                            asfixia = x.asfixia,
                            eletrocucion = x.eletrocucion,
                            objetos_que_golpean = x.objetos_que_golpean,
                            accidentes_vehiculares = x.accidentes_vehiculares,
                            actitud = x.actitud,
                            procedimiento_de_trabajo = x.procedimiento_de_trabajo,
                            permiso_de_trabajo = x.permiso_de_trabajo,
                            e_p_p = x.e_p_p,
                            herremientas_y_equipos = x.herremientas_y_equipos,
                            posicion_de_las_personas = x.posicion_de_las_personas,
                            orden_y_limpieza = x.orden_y_limpieza,
                            reaccion_de_la_persona = x.reaccion_de_la_persona,
                            compromiso_establecido = x.compromiso_establecido,
                            nomSupervisor = x.operadores.Nombre,
                            nomOperador = x.operadores1.Nombre,
                            nomObra = x.obras.Nombre
                        })
                        .FirstOrDefault();

                    return _item;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<DesvioDTO> GetItemList(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _list = db.desvio
                        .Where(x =>
                        (x.idSupervisor == pFiltros.idSupervisor || pFiltros.idSupervisor == "0")
                        && (x.idOperador == pFiltros.idOperador || pFiltros.idOperador == "0")
                        && (x.fecha.Year == pFiltros.anno && x.fecha.Month == pFiltros.mes && (x.fecha.Day == pFiltros.dia || pFiltros.dia == 0))
                        )
                        .Select(x => new DesvioDTO
                        {
                            idDesvio = x.idDesvio,
                            numTabulador = x.numTabulador,
                            area = x.area,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            evento = x.evento,
                            estado_prisa = x.estado_prisa,
                            estado_frustacion = x.estado_frustacion,
                            estado_fatiga = x.estado_fatiga,
                            estado_complacencia = x.estado_complacencia,
                            error_ojos_no_tarea = x.error_ojos_no_tarea,
                            error_mente_no_tarea = x.error_mente_no_tarea,
                            error_mala_colocacion = x.error_mala_colocacion,
                            error_perdida_equilibrio = x.error_perdida_equilibrio,
                            observaciones = x.observaciones,
                            caidas = x.caidas,
                            golpes = x.golpes,
                            quemaduras = x.quemaduras,
                            asfixia = x.asfixia,
                            eletrocucion = x.eletrocucion,
                            objetos_que_golpean = x.objetos_que_golpean,
                            accidentes_vehiculares = x.accidentes_vehiculares,
                            actitud = x.actitud,
                            procedimiento_de_trabajo = x.procedimiento_de_trabajo,
                            permiso_de_trabajo = x.permiso_de_trabajo,
                            e_p_p = x.e_p_p,
                            herremientas_y_equipos = x.herremientas_y_equipos,
                            posicion_de_las_personas = x.posicion_de_las_personas,
                            orden_y_limpieza = x.orden_y_limpieza,
                            reaccion_de_la_persona = x.reaccion_de_la_persona,
                            compromiso_establecido = x.compromiso_establecido,
                            nomSupervisor = x.operadores.Nombre,
                            nomOperador = x.operadores1.Nombre,
                            nomObra = x.obras.Nombre
                        })
                        .ToList();

                    if (pFiltros.buscar != "")
                        _list = _list.Where(x => x.nomSupervisor.Contains(pFiltros.buscar)
                        || x.nomOperador.Contains(pFiltros.buscar)
                        || x.nomObra.Contains(pFiltros.buscar)
                        ).ToList();

                    return _list;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public string getPDF(DesvioDTO pItem)
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

        private string getHTML(DesvioDTO pItem)
        {
            try
            {

                var _headerHTML = getHeaderHTML(pItem);
                var _detailHTML = getDetailHTML(pItem);
                var _detailAuxHTML = getDetailAuxHTML(pItem);
                var _footerHTML = getFooterHTML(pItem);
                return _headerHTML + _detailHTML + _detailAuxHTML + _footerHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getHeaderHTML(DesvioDTO pItem)
        {
            try
            {
                var _idDesvio = pItem.idDesvio;
                var _fecha = pItem.fecha;
                var _supervisorNom = pItem.nomSupervisor;
                var _nomObra = pItem.nomObra;
                var _nomOperador = pItem.nomOperador;
                var _numTabulador = pItem.numTabulador;
                var _area = pItem.area;
                var _evento = pItem.evento;

                string stringHTMLaux = "<table align='center' border='0' cellpadding='1' cellspacing='1' style='height:10px;width:100%'><tbody><tr><td style='text-align:center'><p><span style='font-size:22px'><strong>GRUPO BITESA</strong></span></p><p><span style='font-size:14px'><strong><u>DESVIOS</u></strong></span></p><p>&nbsp;</p><p style='text-align:right'><span style='font-size:10px'><strong># Desvio: _idDesvio</strong></span></p></td></tr></tbody></table><table border='0' cellpadding='5' cellspacing='1' style='height:30px;width:100%'><tbody><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>FECHA</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_fecha</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>OBRA:</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_nomObra</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>TABULADOR:</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_numTabulador</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>EVENTO</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_evento</span></td></tr><tr><td style='text-align:right;width:85px'>&nbsp;</td><td style='width:365px'>&nbsp;</td><td style='text-align:right;width:175px'><span style='font-size:8px'>AREA</span></td><td style='width:508px'><span style='font-size:8px'>_area</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>REALIZADO:</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_nomSupervisor</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>INVOLUCRADO</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_nomOperador</span></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux.Replace("_idDesvio", _idDesvio.ToString())
                    .Replace("_fecha", _fecha.ToString())
                    .Replace("_nomSupervisor", _supervisorNom)
                    .Replace("_nomObra", _nomObra)
                    .Replace("_nomOperador", _nomOperador)
                    .Replace("_numTabulador", _numTabulador)
                    .Replace("_area", _area)
                    .Replace("_evento", _evento);

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private string getDetailHTML(DesvioDTO pItem)
        {
            try
            {
                var _prisa = (bool)pItem.estado_prisa;
                var _frustracion = (bool)pItem.estado_frustacion;
                var _fatiga = (bool)pItem.estado_fatiga;
                var _complacencia = (bool)pItem.estado_complacencia;
                var _error_ojos_no_tarea = (bool)pItem.error_ojos_no_tarea;
                var _error_mente_no_tarea = (bool)pItem.error_mente_no_tarea;
                var _error_mala_colocacion = (bool)pItem.error_mala_colocacion;
                var _error_perdida_equilibrio = (bool)pItem.error_perdida_equilibrio;
                var _observaciones = pItem.observaciones;

                string stringHTMLaux = "<table align='center' border='0' cellpadding='0' cellspacing='0' style='width:80%'><tbody><tr><td style='background-color:#ccc;width:336px'><strong><span style='font-size:9px'>ESTADO</span></strong></td><td style='width:126px'>&nbsp;</td><td style='background-color:#ccc;width:481px'><span style='font-size:9px'><strong>ERROR</strong></span></td></tr><tr><td style='width:336px'><table align='left' border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='width:207px'><span style='font-size:8px'>PRISA</span></td><td style='width:208px'><span style='font-size:8px'>_prisa</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>FRUSTRACION</span></td><td style='width:208px'><span style='font-size:8px'>_frustracion</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>FATIGA</span></td><td style='width:208px'><span style='font-size:8px'>_fatiga</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>COMPLACENCIA</span></td><td style='width:208px'><span style='font-size:8px'>_complacencia</span></td></tr></tbody></table><p>&nbsp;</p></td><td style='width:126px'><p>&nbsp;</p></td><td style='width:481px'><table align='left' border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='width:207px'><span style='font-size:8px'>OJOS EN LA TAREA</span></td><td style='width:208px'><span style='font-size:8px'>_error_ojos_no_tarea</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>MENTE NO EN LA TAREA</span></td><td style='width:208px'><span style='font-size:8px'>_error_mente_no_tarea</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>COLOCARSE EN LA LINEA DE FUEGO</span></td><td style='width:208px'><span style='font-size:8px'>_error_mala_colocacion</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>PERDER EQUILIBRIO, TRACCION O AGARRE</span></td><td style='width:208px'><span style='font-size:8px'>_error_perdida_equilibrio</span></td></tr></tbody></table></td></tr><tr><td colspan='3' style='background-color:#ccc;height:20px;white-space:nowrap;width:572px'><span style='font-size:9px'><strong>OBERVACIONES</strong></span></td></tr><tr><td colspan='3' style='height:60px;width:572px'><span style='font-size:8px'><strong>_observaciones</strong></span></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux.Replace("_prisa", _prisa ? "Si" : "No")
                    .Replace("_frustracion", _frustracion ? "Si" : "No")
                    .Replace("_fatiga", _fatiga ? "Si" : "No")
                    .Replace("_complacencia", _complacencia ? "Si" : "No")
                    .Replace("_error_ojos_no_tarea", _error_ojos_no_tarea ? "Si" : "No")
                    .Replace("_error_mente_no_tarea", _error_mente_no_tarea ? "Si" : "No")
                    .Replace("_error_mala_colocacion", _error_mala_colocacion ? "Si" : "No")
                    .Replace("_error_perdida_equilibrio", _error_perdida_equilibrio ? "Si" : "No")
                    .Replace("_observaciones", _observaciones);

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getDetailAuxHTML(DesvioDTO pItem)
        {
            try
            {
                var _caidas = (bool)pItem.caidas;
                var _golpes = (bool)pItem.golpes;
                var _quemaduras = (bool)pItem.quemaduras;
                var _asfixia = (bool)pItem.asfixia;
                var _electrocucion = (bool)pItem.eletrocucion;
                var _objetos_que_golpean = (bool)pItem.objetos_que_golpean;
                var _accidentes_vehiculares = (bool)pItem.accidentes_vehiculares;
                var _actitud = (bool)pItem.actitud;
                var _procedimiento_de_trabajo = (bool)pItem.procedimiento_de_trabajo;
                var _permiso_de_trabajo = (bool)pItem.permiso_de_trabajo;
                var _epp = (bool)pItem.e_p_p;
                var _herremientas_y_equipos = (bool)pItem.herremientas_y_equipos;
                var _posicion_de_las_personas = (bool)pItem.posicion_de_las_personas;
                var _orden_y_limpieza = (bool)pItem.orden_y_limpieza;
                var _reaccion_de_la_persona = (bool)pItem.reaccion_de_la_persona;
                var _compromiso_establecido = pItem.compromiso_establecido;

                string stringHTMLaux = "<table align='center' border='0' cellpadding='0' cellspacing='0' style='width:500px'><tbody><tr><td style='background-color:#ccc;text-align:center'><u><strong><span style='font-size:9px'>CIRCULO DE SEGURIDAD - Identificaci&oacute;n de peligros</span></strong></u></td></tr><tr><td><table border='1' cellpadding='0' cellspacing='0' style='width:500px'><tbody><tr><td><span style='font-size:8px'>CAIDAS</span></td><td><span style='font-size:8px'>_caidas</span></td></tr><tr><td><span style='font-size:8px'>GOLPES</span></td><td><span style='font-size:8px'>_golpes</span></td></tr><tr><td><span style='font-size:8px'>QUEMADURAS</span></td><td><span style='font-size:8px'>_quemaduras</span></td></tr><tr><td><span style='font-size:8px'>ASFIXIA</span></td><td><span style='font-size:8px'>_asfixia</span></td></tr><tr><td><span style='font-size:8px'>ELECTROCUCION</span></td><td><span style='font-size:8px'>_electrocucion</span></td></tr><tr><td><span style='font-size:8px'>OBJETOS QUE GOLPEAN</span></td><td><span style='font-size:8px'>_objetos_que_golpean</span></td></tr><tr><td><span style='font-size:8px'>ACCIDENTES VEHICULARES</span></td><td><span style='font-size:8px'>_accidentes_vehiculares</span></td></tr><tr><td><span style='font-size:8px'>ACTITUD</span></td><td><span style='font-size:8px'>_actitud</span></td></tr><tr><td><span style='font-size:8px'>PROCEDIMIENTO DE TRABAJO</span></td><td><span style='font-size:8px'>_procedimiento_de_trabajo</span></td></tr><tr><td><span style='font-size:8px'>PERMISO DE TRABAJO</span></td><td><span style='font-size:8px'>_permiso_de_trabajo</span></td></tr><tr><td><span style='font-size:8px'>E.P.P</span></td><td><span style='font-size:8px'>_epp</span></td></tr><tr><td><span style='font-size:8px'>HERRAMIENTAS Y EQUIPO</span></td><td><span style='font-size:8px'>_herremientas_y_equipos</span></td></tr><tr><td><span style='font-size:8px'>POSICION DE LAS PERSONAS</span></td><td><span style='font-size:8px'>_posicion_de_las_personas</span></td></tr><tr><td><span style='font-size:8px'>ORDEN Y LIMPIEZA</span></td><td><span style='font-size:8px'>_orden_y_limpieza</span></td></tr><tr><td><span style='font-size:8px'>REACCION DE LA PERSONA</span></td><td><span style='font-size:8px'>_reaccion_de_la_persona</span></td></tr></tbody></table></td></tr><tr><td style='background-color:#ccc;text-align:center'><u><span style='font-size:9px'><strong>COMPROMISOS ESTABLECIDOS POR EL TRABAJADOR</strong></span></u></td></tr><tr><td><strong><span style='font-size:8px'>_compromiso_establecido</span></strong></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux.Replace("_caidas", _caidas ? "Si" : "No")
                    .Replace("_golpes", _golpes ? "Si" : "No")
                    .Replace("_quemaduras", _quemaduras ? "Si" : "No")
                    .Replace("_asfixia", _asfixia ? "Si" : "No")
                    .Replace("_electrocucion", _electrocucion ? "Si" : "No")
                    .Replace("_objetos_que_golpean", _objetos_que_golpean ? "Si" : "No")
                    .Replace("_accidentes_vehiculares", _accidentes_vehiculares ? "Si" : "No")
                    .Replace("_actitud", _actitud ? "Si" : "No")
                    .Replace("_procedimiento_de_trabajo", _procedimiento_de_trabajo ? "Si" : "No")
                    .Replace("_permiso_de_trabajo", _permiso_de_trabajo ? "Si" : "No")
                    .Replace("_epp", _epp ? "Si" : "No")
                    .Replace("_herremientas_y_equipos", _herremientas_y_equipos ? "Si" : "No")
                    .Replace("_posicion_de_las_personas", _posicion_de_las_personas ? "Si" : "No")
                    .Replace("_orden_y_limpieza", _orden_y_limpieza ? "Si" : "No")
                    .Replace("_reaccion_de_la_persona", _reaccion_de_la_persona ? "Si" : "No")
                    .Replace("_compromiso_establecido", _compromiso_establecido);

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private string getFooterHTML(DesvioDTO pItem)
        {
            try
            {
                // var _compromisos = pItem.compromisos;


                string stringHTMLaux = "<table border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td><p>&nbsp;</p><p style='text-align:right'>&nbsp;</p><p style='text-align:center'>&nbsp;</p><p style='text-align:center'><strong>Firma del trabajador</strong></p></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux;

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public DesvioDTO InsertItem(DesvioDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _idDesvio = 0;

                    _idDesvio = pItem.idDesvio;
                    if (_idDesvio != 0)
                        throw new Exception("El registro ya existe.");

                    var _params = db.parametros.Where(x => x.nombre == "docDesvio").Select(x => x).FirstOrDefault();
                    if (!string.IsNullOrEmpty(_params.valor))
                        _idDesvio = Convert.ToInt32(_params.valor);

                    _idDesvio++;
                    pItem.idDesvio = _idDesvio;
                    _params.valor = _idDesvio.ToString();


                    var _ItemModel = new desvio();

                    _ItemModel.idDesvio = _idDesvio;
                    _ItemModel.numTabulador = pItem.numTabulador;
                    _ItemModel.area = pItem.area;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.evento = pItem.evento;
                    _ItemModel.estado_prisa = pItem.estado_prisa;
                    _ItemModel.estado_frustacion = pItem.estado_frustacion;
                    _ItemModel.estado_fatiga = pItem.estado_fatiga;
                    _ItemModel.estado_complacencia = pItem.estado_complacencia;
                    _ItemModel.error_ojos_no_tarea = pItem.error_ojos_no_tarea;
                    _ItemModel.error_mente_no_tarea = pItem.error_mente_no_tarea;
                    _ItemModel.error_mala_colocacion = pItem.error_mala_colocacion;
                    _ItemModel.error_perdida_equilibrio = pItem.error_perdida_equilibrio;
                    _ItemModel.observaciones = pItem.observaciones;
                    _ItemModel.caidas = pItem.caidas;
                    _ItemModel.golpes = pItem.golpes;
                    _ItemModel.quemaduras = pItem.quemaduras;
                    _ItemModel.asfixia = pItem.asfixia;
                    _ItemModel.eletrocucion = pItem.eletrocucion;
                    _ItemModel.objetos_que_golpean = pItem.objetos_que_golpean;
                    _ItemModel.accidentes_vehiculares = pItem.accidentes_vehiculares;
                    _ItemModel.actitud = pItem.actitud;
                    _ItemModel.procedimiento_de_trabajo = pItem.procedimiento_de_trabajo;
                    _ItemModel.permiso_de_trabajo = pItem.permiso_de_trabajo;
                    _ItemModel.e_p_p = pItem.e_p_p;
                    _ItemModel.herremientas_y_equipos = pItem.herremientas_y_equipos;
                    _ItemModel.posicion_de_las_personas = pItem.posicion_de_las_personas;
                    _ItemModel.orden_y_limpieza = pItem.orden_y_limpieza;
                    _ItemModel.reaccion_de_la_persona = pItem.reaccion_de_la_persona;
                    _ItemModel.compromiso_establecido = pItem.compromiso_establecido;


                    db.desvio.Add(_ItemModel);
                    db.SaveChanges();

                    return pItem;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public bool UpdateItem(DesvioDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.desvio.Where(x => x.idDesvio == pItem.idDesvio).FirstOrDefault();

                    _ItemModel.numTabulador = pItem.numTabulador;
                    _ItemModel.area = pItem.area;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.evento = pItem.evento;
                    _ItemModel.estado_prisa = pItem.estado_prisa;
                    _ItemModel.estado_frustacion = pItem.estado_frustacion;
                    _ItemModel.estado_fatiga = pItem.estado_fatiga;
                    _ItemModel.estado_complacencia = pItem.estado_complacencia;
                    _ItemModel.error_ojos_no_tarea = pItem.error_ojos_no_tarea;
                    _ItemModel.error_mente_no_tarea = pItem.error_mente_no_tarea;
                    _ItemModel.error_mala_colocacion = pItem.error_mala_colocacion;
                    _ItemModel.error_perdida_equilibrio = pItem.error_perdida_equilibrio;
                    _ItemModel.observaciones = pItem.observaciones;
                    _ItemModel.caidas = pItem.caidas;
                    _ItemModel.golpes = pItem.golpes;
                    _ItemModel.quemaduras = pItem.quemaduras;
                    _ItemModel.asfixia = pItem.asfixia;
                    _ItemModel.eletrocucion = pItem.eletrocucion;
                    _ItemModel.objetos_que_golpean = pItem.objetos_que_golpean;
                    _ItemModel.accidentes_vehiculares = pItem.accidentes_vehiculares;
                    _ItemModel.actitud = pItem.actitud;
                    _ItemModel.procedimiento_de_trabajo = pItem.procedimiento_de_trabajo;
                    _ItemModel.permiso_de_trabajo = pItem.permiso_de_trabajo;
                    _ItemModel.e_p_p = pItem.e_p_p;
                    _ItemModel.herremientas_y_equipos = pItem.herremientas_y_equipos;
                    _ItemModel.posicion_de_las_personas = pItem.posicion_de_las_personas;
                    _ItemModel.orden_y_limpieza = pItem.orden_y_limpieza;
                    _ItemModel.reaccion_de_la_persona = pItem.reaccion_de_la_persona;
                    _ItemModel.compromiso_establecido = pItem.compromiso_establecido;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string getXLSX(List<DesvioDTO> pList)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Documento", typeof(string)));
                dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
                dt.Columns.Add(new DataColumn("Empresa", typeof(string)));
                dt.Columns.Add(new DataColumn("Responsable", typeof(string)));
                dt.Columns.Add(new DataColumn("Trabajador", typeof(string)));
                dt.Columns.Add(new DataColumn("Tabulador", typeof(string)));
                dt.Columns.Add(new DataColumn("Area", typeof(string)));
                dt.Columns.Add(new DataColumn("Evento", typeof(string)));
                dt.Columns.Add(new DataColumn("Estado Prisa", typeof(string)));
                dt.Columns.Add(new DataColumn("Estado Frustracion", typeof(string)));
                dt.Columns.Add(new DataColumn("Estado Fatiga", typeof(string)));
                dt.Columns.Add(new DataColumn("Estado Complacencia", typeof(string)));
                dt.Columns.Add(new DataColumn("Error Ojos en la tarea", typeof(string)));
                dt.Columns.Add(new DataColumn("Error mente no en la tarea", typeof(string)));
                dt.Columns.Add(new DataColumn("Error Colocarse en la linea de fuego", typeof(string)));
                dt.Columns.Add(new DataColumn("Error Perder Equilibrio", typeof(string)));
                dt.Columns.Add(new DataColumn("Observacioness", typeof(string)));
                dt.Columns.Add(new DataColumn("Caidas", typeof(string)));
                dt.Columns.Add(new DataColumn("Golpes", typeof(string)));
                dt.Columns.Add(new DataColumn("Quemaduras", typeof(string)));
                dt.Columns.Add(new DataColumn("Asfixia", typeof(string)));
                dt.Columns.Add(new DataColumn("Electrocucion", typeof(string)));
                dt.Columns.Add(new DataColumn("Objetos que golpean", typeof(string)));
                dt.Columns.Add(new DataColumn("Accidentes vehiculares", typeof(string)));
                dt.Columns.Add(new DataColumn("Actitud", typeof(string)));
                dt.Columns.Add(new DataColumn("Procedimiento de trabajo", typeof(string)));
                dt.Columns.Add(new DataColumn("Permiso de trabajo", typeof(string)));
                dt.Columns.Add(new DataColumn("E.P.P.", typeof(string)));
                dt.Columns.Add(new DataColumn("Herramientas y equipos", typeof(string)));
                dt.Columns.Add(new DataColumn("Posicion de las personas", typeof(string)));
                dt.Columns.Add(new DataColumn("Orden y limpieza", typeof(string)));
                dt.Columns.Add(new DataColumn("Reaccion de la persona", typeof(string)));
                dt.Columns.Add(new DataColumn("Compromisos del trabajador", typeof(string)));

                pList.ForEach(x => {
                    dt.Rows.Add(x.idDesvio, x.fecha.ToString("dd-MM-yyyy"), x.idObra + "|" + x.nomObra, x.idSupervisor + "|" + x.nomSupervisor,
                        x.idOperador + "|" + x.nomOperador, x.numTabulador, x.area, x.evento, valorCampos((bool)x.estado_prisa), valorCampos((bool)x.estado_frustacion),
                        valorCampos((bool)x.estado_fatiga), valorCampos((bool)x.estado_complacencia), valorCampos((bool)x.error_ojos_no_tarea), valorCampos((bool)x.error_mente_no_tarea),
                        valorCampos((bool)x.error_mala_colocacion), valorCampos((bool)x.error_perdida_equilibrio), x.observaciones, valorCampos((bool)x.caidas), valorCampos((bool)x.golpes),
                        valorCampos((bool)x.quemaduras), valorCampos((bool)x.asfixia), valorCampos((bool)x.eletrocucion), valorCampos((bool)x.objetos_que_golpean), valorCampos((bool)x.accidentes_vehiculares),
                        valorCampos((bool)x.actitud), valorCampos((bool)x.procedimiento_de_trabajo), valorCampos((bool)x.permiso_de_trabajo), valorCampos((bool)x.e_p_p),
                        valorCampos((bool)x.herremientas_y_equipos), valorCampos((bool)x.posicion_de_las_personas), valorCampos((bool)x.orden_y_limpieza), valorCampos((bool)x.reaccion_de_la_persona), 
                        x.compromiso_establecido);
                });

                generaPDF _generaPDF = new generaPDF();
                return _generaPDF.createXLSXtoBase64(dt);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string valorCampos(bool pDato) => pDato ? "SI" : "NO";
    }
}
