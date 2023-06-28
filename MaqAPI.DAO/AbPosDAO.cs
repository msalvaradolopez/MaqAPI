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
    public class AbPosDAO : ICatalogoItem<AbPosDTO>, IConsultaItem<AbPosDTO>, IFormatos<AbPosDTO>, IExportaXLSX<AbPosDTO>
    {
        public bool DeleteItem(AbPosDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.abpos.Where(x => x.idAbordaje == pItem.idAbordaje).FirstOrDefault();


                    db.abpos.Remove(_ItemModel);
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

        public AbPosDTO GetItemById(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = db.abpos
                        .Where(x => x.idAbordaje == pFiltros.idAbordaje)
                        .Select(x => new AbPosDTO
                        {
                            idAbordaje = x.idAbordaje,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            riesgo = x.riesgo,
                            desvio = x.desvio,
                            casco = (bool)x.casco,
                            lentes= (bool)x.lentes,
                            guantes = (bool)x.guantes,
                            uniforme = (bool)x.uniforme,
                            zapatos = (bool)x.zapatos,
                            uni_fajado = (bool)x.zapatos,
                            tapones = (bool)x.tapones,
                            mascarilla = (bool)x.mascarilla,
                            careta = (bool)x.careta,
                            arnes = (bool)x.arnes,
                            polainas = (bool)x.polainas,
                            peto = (bool)x.peto,
                            gogles = (bool)x.gogles,
                            otros = (bool)x.otros,
                            otro_descrip = x.otro_descrip,
                            act_inseguros = x.act_inseguros,
                            acc_correctiva = x.acc_correctiva,
                            cond_inseguras = x.cond_inseguras,
                            compromisos = x.compromisos
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

        public List<AbPosDTO> GetItemList(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _list = db.abpos
                        .Where(x =>
                        (x.idSupervisor == pFiltros.idSupervisor || pFiltros.idSupervisor == "0")
                        && (x.idOperador == pFiltros.idOperador || pFiltros.idOperador == "0")
                        && (x.fecha.Year == pFiltros.anno && x.fecha.Month == pFiltros.mes && (x.fecha.Day == pFiltros.dia || pFiltros.dia == 0))
                        )
                        .Select(x => new AbPosDTO
                        {
                            idAbordaje = x.idAbordaje,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            riesgo = x.riesgo,
                            desvio = x.desvio,
                            casco = (bool)x.casco,
                            lentes = (bool)x.lentes,
                            guantes = (bool)x.guantes,
                            uniforme = (bool)x.uniforme,
                            zapatos = (bool)x.zapatos,
                            uni_fajado = (bool)x.zapatos,
                            tapones = (bool)x.tapones,
                            mascarilla = (bool)x.mascarilla,
                            careta = (bool)x.careta,
                            arnes = (bool)x.arnes,
                            polainas = (bool)x.polainas,
                            peto = (bool)x.peto,
                            gogles = (bool)x.gogles,
                            otros = (bool)x.otros,
                            otro_descrip = x.otro_descrip,
                            act_inseguros = x.act_inseguros,
                            acc_correctiva = x.acc_correctiva,
                            cond_inseguras = x.cond_inseguras,
                            compromisos = x.compromisos,
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

        public string getPDF(AbPosDTO pItem)
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

        private string getHTML(AbPosDTO pItem)
        {
            try
            {

                var _headerHTML = getHeaderHTML(pItem);
                var _detailHTML = getDetailHTML(pItem);
                var _footerHTML = getFooterHTML(pItem);
                return _headerHTML + _detailHTML + _footerHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getHeaderHTML(AbPosDTO pItem)
        {
            try
            {
                var _idAbordaje = pItem.idAbordaje;
                var _fecha = pItem.fecha;
                var _supervisorNom = pItem.nomSupervisor;
                var _nomObra = pItem.nomObra;
                var _nomOperador = pItem.nomOperador;
                var _riesgo = pItem.riesgo;
                var _desvio = pItem.desvio;
                
                string stringHTMLaux = "<table align='center' border='0' cellpadding='1' cellspacing='1' style='height:10px;width:100%'><tbody><tr><td style='text-align:center'><p><span style='font-size:22px'><strong>GRUPO BITESA</strong></span></p><p><span style='font-size:14px'><strong><u>ABORDAJE POSITIVO</u></strong></span></p><p>&nbsp;</p><p style='text-align:right'><span style='font-size:10px'><strong># Abordaje: _idAbordaje</strong></span></p></td></tr></tbody></table><table border='0' cellpadding='5' cellspacing='1' style='height:30px;width:100%'><tbody><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>FECHA</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_fecha</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>EMPRESA:</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_empresa</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>RESPONSABLE:</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_responsable</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>TRABAJADOR</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_trabajador</span></td></tr><tr><td style='text-align:right;width:85px'>&nbsp;</td><td style='width:365px'>&nbsp;</td><td style='text-align:right;width:175px'>&nbsp;</td><td style='width:508px'>&nbsp;</td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>RIESGO</span></td><td style='background-color:#ccc;width:365px'><span style='font-size:8px'>_riesgo</span></td><td style='text-align:right;width:175px'><span style='font-size:8px'>DESVIO</span></td><td style='background-color:#ccc;width:508px'><span style='font-size:8px'>_desvio</span></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux.Replace("_idAbordaje", _idAbordaje.ToString())
                    .Replace("_fecha", _fecha.ToString())
                    .Replace("_responsable", _supervisorNom)
                    .Replace("_empresa", _nomObra)
                    .Replace("_trabajador", _nomOperador)
                    .Replace("_riesgo", _riesgo)
                    .Replace("_desvio", _desvio);

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getDetailHTML(AbPosDTO pItem)
        {
            try
            {
                var _casco = pItem.casco;
                var _lentes = pItem.guantes;
                var _guantes = pItem.guantes;
                var _uniforme = pItem.uniforme;
                var _zapatos = pItem.zapatos;
                var _uni_fajado = pItem.uni_fajado;
                var _tapones = pItem.tapones;
                var _mascarilla = pItem.mascarilla;
                var _careta = pItem.careta;
                var _arnes = pItem.arnes;
                var _polainas = pItem.polainas;
                var _peto = pItem.peto;
                var _gogles = pItem.gogles;
                var _otros = pItem.otros;
                var _otro_descrip = pItem.otro_descrip;
                var _act_inseguros = pItem.act_inseguros;
                var _acc_correctiva = pItem.acc_correctiva;
                var _cond_inseguras = pItem.cond_inseguras;

                string stringHTMLaux = "<table align='center' border='0' cellpadding='0' cellspacing='0' style='width:100%'><tbody><tr><td style='width:572px'><table align='left' border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='width:207px'><span style='font-size:8px'>CASCO</span></td><td style='width:208px'><span style='font-size:8px'>_casco</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>LENTES</span></td><td style='width:208px'><span style='font-size:8px'>_lentes</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>GUANTES</span></td><td style='width:208px'><span style='font-size:8px'>_guantes</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>UNIFORME</span></td><td style='width:208px'><span style='font-size:8px'>_uniforme</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>ZAPATOS</span></td><td style='width:208px'><span style='font-size:8px'>_zapatos</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>UNIFORME FAJADO</span></td><td style='width:208px'><span style='font-size:8px'>_uni_fajado</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>TAPONES</span></td><td style='width:208px'><span style='font-size:8px'>_tapones</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>MASCARILLA</span></td><td style='width:208px'><span style='font-size:8px'>_mascarilla</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>CARETA FACIAL</span></td><td style='width:208px'><span style='font-size:8px'>_careta</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>ARNES</span></td><td style='width:208px'><span style='font-size:8px'>_arnes</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>POLAINAS</span></td><td style='width:208px'><span style='font-size:8px'>_polainas</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>PETO</span></td><td style='width:208px'><span style='font-size:8px'>_peto</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>GOGLES O CARETA PARA SOLDAR</span></td><td style='width:208px'><span style='font-size:8px'>_gogles</span></td></tr><tr><td style='width:207px'><span style='font-size:8px'>OTROS ESPECIFICAR</span></td><td style='width:208px'><span style='font-size:8px'>_otros</span></td></tr><tr><td colspan='2'><span style='font-size:8px'>_otro_descrip</span></td></tr></tbody></table><p>&nbsp;</p></td><td style='width:226px'>&nbsp;</td><td style='width:523px'><table align='right' border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='background-color:#ccc;width:501px'><span style='font-size:8px'>ACTOS INSEGUROS</span></td></tr><tr><td style='width:501px'><p><span style='font-size:8px'>_act_inseguros</span></p><p>&nbsp;</p></td></tr></tbody></table><p>&nbsp;</p><table align='right' border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='background-color:#ccc;width:522px'><span style='font-size:8px'>ACCION CORRECTIVA</span></td></tr><tr><td style='width:522px'><p><span style='font-size:8px'>_acc_correctiva</span></p><p>&nbsp;</p></td></tr></tbody></table><p>&nbsp;</p><table align='right' border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='background-color:#ccc'><span style='font-size:8px'>CONDICIONES INSEGURAS</span></td></tr><tr><td><p><span style='font-size:8px'>_cond_inseguras</span></p><p>&nbsp;</p></td></tr></tbody></table><p>&nbsp;</p></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux.Replace("_casco", _casco ? "Si" : "No")
                    .Replace("_lentes", _lentes ? "Si" : "No")
                    .Replace("_guantes", _guantes ? "Si" : "No")
                    .Replace("_uniforme", _uniforme ? "Si" : "No")
                    .Replace("_zapatos", _zapatos ? "Si" : "No")
                    .Replace("_uni_fajado", _uni_fajado ? "Si" : "No")
                    .Replace("_tapones", _tapones ? "Si" : "No")
                    .Replace("_mascarilla", _mascarilla ? "Si" : "No")
                    .Replace("_careta", _careta ? "Si" : "No")
                    .Replace("_arnes", _arnes ? "Si" : "No")
                    .Replace("_polainas", _polainas ? "Si" : "No")
                    .Replace("_peto", _peto ? "Si" : "No")
                    .Replace("_gogles", _gogles ? "Si" : "No")
                    .Replace("_otros", _otros ? "Si" : "No")
                    .Replace("_otro_descrip", _otro_descrip)
                    .Replace("_act_inseguros", _act_inseguros)
                    .Replace("_acc_correctiva", _acc_correctiva)
                    .Replace("_cond_inseguras", _cond_inseguras);

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getFooterHTML(AbPosDTO pItem)
        {
            try
            {
                var _compromisos = pItem.compromisos;
                

                string stringHTMLaux = "<table border='1' cellpadding='1' cellspacing='0' style='width:100%'><tbody><tr><td style='background-color:#ccc'><span style='font-size:8px'>COMPROMISOS</span></td></tr><tr><td style='vertical-align:top'><p><span style='font-size:8px'>_compromisos</span></p><p>&nbsp;</p><p>&nbsp;</p></td></tr><tr><td><p>&nbsp;</p><p style='text-align:right'>&nbsp;</p><p style='text-align:center'>&nbsp;</p><p style='text-align:center'>Firma del trabajador</p></td></tr></tbody></table><p>&nbsp;</p>";

                string stringHTML = stringHTMLaux.Replace("_compromisos", _compromisos);

                return stringHTML;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AbPosDTO InsertItem(AbPosDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _idAbordaje = 0;

                    _idAbordaje = pItem.idAbordaje;
                    if (_idAbordaje != 0)
                        throw new Exception("El registro ya existe.");

                    var _params = db.parametros.Where(x => x.nombre == "docAbPos").Select(x => x).FirstOrDefault();
                    if (!string.IsNullOrEmpty(_params.valor))
                        _idAbordaje = Convert.ToInt32(_params.valor);

                    _idAbordaje++;
                    pItem.idAbordaje = _idAbordaje;
                    _params.valor = _idAbordaje.ToString();


                    var _ItemModel = new abpos();

                    _ItemModel.idAbordaje = _idAbordaje;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.riesgo = pItem.riesgo;
                    _ItemModel.desvio = pItem.desvio;
                    _ItemModel.casco = pItem.casco;
                    _ItemModel.lentes = pItem.lentes;
                    _ItemModel.guantes = pItem.guantes;
                    _ItemModel.uniforme = pItem.uniforme;
                    _ItemModel.zapatos = pItem.zapatos;
                    _ItemModel.uni_fajado = pItem.uni_fajado;
                    _ItemModel.tapones = pItem.tapones;
                    _ItemModel.mascarilla = pItem.mascarilla;
                    _ItemModel.careta = pItem.careta;
                    _ItemModel.arnes = pItem.arnes;
                    _ItemModel.polainas = pItem.polainas;
                    _ItemModel.peto = pItem.peto;
                    _ItemModel.gogles = pItem.gogles;
                    _ItemModel.otros = pItem.otros;
                    _ItemModel.otro_descrip = pItem.otro_descrip;
                    _ItemModel.act_inseguros = pItem.act_inseguros;
                    _ItemModel.acc_correctiva = pItem.acc_correctiva;
                    _ItemModel.cond_inseguras = pItem.cond_inseguras;
                    _ItemModel.compromisos = pItem.compromisos;


                    db.abpos.Add(_ItemModel);
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

        public bool UpdateItem(AbPosDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.abpos.Where(x => x.idAbordaje == pItem.idAbordaje).FirstOrDefault();

                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.riesgo = pItem.riesgo;
                    _ItemModel.desvio = pItem.desvio;
                    _ItemModel.casco = pItem.casco;
                    _ItemModel.lentes = pItem.lentes;
                    _ItemModel.guantes = pItem.guantes;
                    _ItemModel.uniforme = pItem.uniforme;
                    _ItemModel.zapatos = pItem.zapatos;
                    _ItemModel.uni_fajado = pItem.uni_fajado;
                    _ItemModel.tapones = pItem.tapones;
                    _ItemModel.mascarilla = pItem.mascarilla;
                    _ItemModel.careta = pItem.careta;
                    _ItemModel.arnes = pItem.arnes;
                    _ItemModel.polainas = pItem.polainas;
                    _ItemModel.peto = pItem.peto;
                    _ItemModel.gogles = pItem.gogles;
                    _ItemModel.otros = pItem.otros;
                    _ItemModel.otro_descrip = pItem.otro_descrip;
                    _ItemModel.act_inseguros = pItem.act_inseguros;
                    _ItemModel.acc_correctiva = pItem.acc_correctiva;
                    _ItemModel.cond_inseguras = pItem.cond_inseguras;
                    _ItemModel.compromisos = pItem.compromisos;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string getXLSX(List<AbPosDTO> pList)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Documento", typeof(string)));
                dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
                dt.Columns.Add(new DataColumn("Empresa", typeof(string)));
                dt.Columns.Add(new DataColumn("Responsable", typeof(string)));
                dt.Columns.Add(new DataColumn("Trabajador", typeof(string)));
                dt.Columns.Add(new DataColumn("Riesgo", typeof(string)));
                dt.Columns.Add(new DataColumn("Desvio", typeof(string)));
                dt.Columns.Add(new DataColumn("Casco", typeof(string)));
                dt.Columns.Add(new DataColumn("Lentes", typeof(string)));
                dt.Columns.Add(new DataColumn("Guantes", typeof(string)));
                dt.Columns.Add(new DataColumn("Uniforme", typeof(string)));
                dt.Columns.Add(new DataColumn("Zapatos", typeof(string)));
                dt.Columns.Add(new DataColumn("Uniforme fajado", typeof(string)));
                dt.Columns.Add(new DataColumn("Tapones", typeof(string)));
                dt.Columns.Add(new DataColumn("Mascarilla", typeof(string)));
                dt.Columns.Add(new DataColumn("Careta facial", typeof(string)));
                dt.Columns.Add(new DataColumn("Arnes", typeof(string)));
                dt.Columns.Add(new DataColumn("Polainas", typeof(string)));
                dt.Columns.Add(new DataColumn("Peto", typeof(string)));
                dt.Columns.Add(new DataColumn("Gogles o Careta Soldar", typeof(string)));
                dt.Columns.Add(new DataColumn("Otros", typeof(string)));
                dt.Columns.Add(new DataColumn("Otros Comentarios", typeof(string)));
                dt.Columns.Add(new DataColumn("Actos Inseguros", typeof(string)));
                dt.Columns.Add(new DataColumn("Accion Correctiva", typeof(string)));
                dt.Columns.Add(new DataColumn("Condiciones Inseguras", typeof(string)));
                dt.Columns.Add(new DataColumn("Compromisos", typeof(string)));

                pList.ForEach(x => {
                    dt.Rows.Add(x.idAbordaje, x.fecha.ToString("dd-MM-yyyy"), x.idObra + "|" + x.nomObra, x.idSupervisor + "|" + x.nomSupervisor,
                        x.idOperador + "|" + x.nomOperador, x.riesgo, x.desvio, valorCampos(x.casco), valorCampos(x.lentes), valorCampos(x.guantes), valorCampos(x.uniforme),
                        valorCampos(x.zapatos), valorCampos(x.uni_fajado), valorCampos(x.tapones), valorCampos(x.mascarilla), valorCampos(x.careta), valorCampos(x.arnes),
                        valorCampos(x.polainas), valorCampos(x.peto), valorCampos(x.gogles), valorCampos(x.otros), x.otro_descrip, x.act_inseguros, x.acc_correctiva, x.cond_inseguras,
                        x.compromisos);
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
