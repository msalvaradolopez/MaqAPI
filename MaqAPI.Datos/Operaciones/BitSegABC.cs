﻿using MaqAPI.Datos.Interfaz;
using MaqAPI.Datos.Models;
using MaqAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.DTO;
using MaqAPI.Interface;
using MaqAPI.Utilerias;
using System.Data;
using MaqAPI.Entidades;

namespace MaqAPI.Datos.Operaciones
{
    public class BitSegABC<T> : IConexion<T>, IFormats, IExportaXLSX<BitSegEntidad>
    {

        public string FormatBASE64(object pItem)
        {
            BitSegDTO _item = pItem as BitSegDTO;
            string _html = getFormatoHTML(_item);

            generaPDF _generaPDF = new generaPDF();
            return _generaPDF.createPDFtoBASE64(_html);
        }

        private string getFormatoHTML(BitSegDTO pItem)
        {

            string _headerHTML = getHeaderHTML(pItem);
            string _detailHTML = getDetailHTML(pItem.ListadoBitSeg);
            // string _detailHTML = "<p>&nbsp;</p><table border='1' cellpadding='5' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td colspan='1' rowspan='3' style='text-align:center;width:85px'><span style='font-size:8px'>_consecutivo</span></td><td style='background-color:#ccc;text-align:center;width:430px'><span style='font-size:8px'>MAQUINARIA O EQUIPO</span></td><td style='background-color:#ccc;text-align:center;width:137px'><span style='font-size:8px'>NUMERO</span></td><td style='background-color:#ccc;text-align:center;width:594px'><span style='font-size:8px'>OPERADOR</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>_equipoNom</span></td><td style='width:137px'><span style='font-size:8px'>_idEconomico</span></td><td style='width:594px'><span style='font-size:8px'>_operadorNom</span></td></tr><tr><td colspan='2' rowspan='1' style='width:516px'><table border='0' cellpadding='0' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td style='background-color:#ccc;width:82px'><span style='font-size:8px'>ACTIVIDAD</span></td><td style='width:436px'><span style='font-size:8px'>_actividad</span></td></tr></tbody></table></td><td style='width:594px'><table border='0' cellpadding='1' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td style='background-color:#ccc;width:118px'><span style='font-size:8px'>PUNTO EXACTO</span></td><td style='width:420px'><span style='font-size:8px'>_pto_exacto</span></td></tr></tbody></table></td></tr><tr><td colspan='1' rowspan='11' style='width:85px'>&nbsp;</td><td style='background-color:#ccc;text-align:center;width:430px'><span style='font-size:8px'>DOCUMENTO</span></td><td style='background-color:#ccc;text-align:center;width:137px'><span style='font-size:8px'>CUENTA CON EL ?</span></td><td style='background-color:#ccc;text-align:center;width:594px'><span style='font-size:8px'>OBSERVACIONES</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>CHEQUEO MEDICO</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_chequeo_medico</span></td><td style='width:594px'><span style='font-size:8px'>_chequeo_medico_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>CHECK LIST DE MAQUINARIA O EQUIPO</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_checklist_maq_equip</span></td><td style='width:594px'><span style='font-size:8px'>_checklist_maq_equip_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>A P R</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_apr</span></td><td style='width:594px'><span style='font-size:8px'>_apr_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>PERMISO DE INSTANCIA</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_permiso_instancia</span></td><td style='width:594px'><span style='font-size:8px'>_permiso_instancia_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>CD3</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_dc3</span></td><td style='width:594px'><span style='font-size:8px'>_dc3_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>EXTINTOR&nbsp;</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_extintor</span></td><td style='width:594px'><span style='font-size:8px'>_extintor_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>KIT ANTIDERRAMES</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_kit_antiderrames</span></td><td style='width:594px'><span style='font-size:8px'>_kit_antiderrames_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>PLATICA 5 MINUTOS</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_platica_5min</span></td><td style='width:594px'><span style='font-size:8px'>_platica_5min_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>EPP</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_epp</span></td><td style='width:594px'><span style='font-size:8px'>_epp_obs</span></td></tr><tr><td style='width:109px'><span style='font-size:8px'>OTRO</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_otro</span></td><td style='width:594px'><span style='font-size:8px'>?otro_obs</span></td></tr></tbody></table>";
            string _footerHTML = "<p>&nbsp;</p><p>&nbsp;</p><table border='0' cellpadding='0' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td style='height:10px;text-align:center;white-space:nowrap'><span style='font-size:8px'>NOMBRE Y FIRMA DEL RESPONSABLE DEL AREA</span></td><td style='height:10px;white-space:nowrap'><p style='text-align:center'><span style='font-size:8px'>NOMBRE Y FIRMA DEL SUPERVISOR DE SEGURIDAD</span></p></td></tr></tbody></table><p>&nbsp;</p>";
            return _headerHTML + _detailHTML + _footerHTML;
        }

        private string getHeaderHTML(BitSegDTO pItem)
        {
            var _docBitacora = pItem.docBitacora;
            var _fecha = pItem.fecha;
            var _idSupervisor = pItem.idSupervisor;
            var _supervisorNom = pItem.supervisorNom;
            var _idObra = pItem.idObra;
            var _obraNom = pItem.obraNom;
            var _area = pItem.area;
            var _horaInicio = pItem.horaInicio;
            var _horaTermino = pItem.horaTermino;

            string stringHTMLaux = "<p>&nbsp;</p><table align='center' border='0' cellpadding='1' cellspacing='1' style='height:10px;width:100%'><tbody><tr><td style='text-align:center'><p><span style='font-size:20px'><strong><u><span style='background-color:#bdc3c7'>BITACORA DE SUPERVISOR DE SEGURIDAD</span></u></strong></span></p><p>&nbsp;</p><p style='text-align:right'><span style='font-size:10px'><strong># Bitacora : _docBitacora</strong></span></p></td></tr></tbody></table><table border='0' cellpadding='5' cellspacing='1' style='height:30px;width:100%'><tbody><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>FECHA</span></td><td style='background-color:#ccc;width:388px'><span style='font-size:8px'>_fecha</span></td><td style='text-align:right;width:141px'><span style='font-size:8px'>SUPERVISOR:</span></td><td style='background-color:#ccc;width:549px'><span style='font-size:8px'>_supervisorNom</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>PLANTA:</span></td><td style='background-color:#ccc;width:388px'><span style='font-size:8px'>_obraNom</span></td><td style='text-align:right;width:141px'><span style='font-size:8px'>AREA</span></td><td style='background-color:#ccc;width:549px'><span style='font-size:8px'>_area</span></td></tr><tr><td style='text-align:right;width:85px'><span style='font-size:8px'>HORA INICIO:</span></td><td style='background-color:#ccc;width:388px'><span style='font-size:8px'>_horaInicio</span></td><td style='text-align:right;width:141px'><span style='font-size:8px'>HORA TERMINO:</span></td><td style='background-color:#ccc;width:549px'><span style='font-size:8px'>_horaTermino</span></td></tr></tbody></table><p>&nbsp;</p>";

            string stringHTML = stringHTMLaux.Replace("_docBitacora", _docBitacora.ToString())
                .Replace("_fecha", _fecha.ToString())
                .Replace("_supervisorNom", _supervisorNom)
                .Replace("_obraNom", _obraNom)
                .Replace("_area", _area)
                .Replace("_horaInicio", _horaInicio)
                .Replace("_horaTermino", _horaTermino);

            return stringHTML;
        }

        private string getDetailHTML(List<BitSegEntidad> pList)
        {

            string stringHTML = "";

            var _consecutivo = 0;
            pList.ForEach(item =>
            {
                string stringHTMLaux = "<p>&nbsp;</p><table border='1' cellpadding='5' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td colspan='1' rowspan='3' style='text-align:center;width:85px'><span style='font-size:8px'>_consecutivo</span></td><td style='background-color:#ccc;text-align:center;width:430px'><span style='font-size:8px'>MAQUINARIA O EQUIPO</span></td><td style='background-color:#ccc;text-align:center;width:137px'><span style='font-size:8px'>NUMERO</span></td><td style='background-color:#ccc;text-align:center;width:594px'><span style='font-size:8px'>OPERADOR</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>_equipoNom</span></td><td style='width:137px'><span style='font-size:8px'>_idEconomico</span></td><td style='width:594px'><span style='font-size:8px'>_operadorNom</span></td></tr><tr><td colspan='2' rowspan='1' style='width:516px'><table border='0' cellpadding='0' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td style='background-color:#ccc;width:82px'><span style='font-size:8px'>ACTIVIDAD</span></td><td style='width:436px'><span style='font-size:8px'>_actividad</span></td></tr></tbody></table></td><td style='width:594px'><table border='0' cellpadding='1' cellspacing='0' style='height:30px;width:100%'><tbody><tr><td style='background-color:#ccc;width:118px'><span style='font-size:8px'>PUNTO EXACTO</span></td><td style='width:420px'><span style='font-size:8px'>_pto_exacto</span></td></tr></tbody></table></td></tr><tr><td colspan='1' rowspan='11' style='width:85px'>&nbsp;</td><td style='background-color:#ccc;text-align:center;width:430px'><span style='font-size:8px'>DOCUMENTO</span></td><td style='background-color:#ccc;text-align:center;width:137px'><span style='font-size:8px'>CUENTA CON EL ?</span></td><td style='background-color:#ccc;text-align:center;width:594px'><span style='font-size:8px'>OBSERVACIONES</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>CHEQUEO MEDICO</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_chequeo_medico</span></td><td style='width:594px'><span style='font-size:8px'>@chequeo_medico_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>CHECK LIST DE MAQUINARIA O EQUIPO</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_checklist_maq_equip</span></td><td style='width:594px'><span style='font-size:8px'>@checklist_maq_equip_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>A P R</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_apr</span></td><td style='width:594px'><span style='font-size:8px'>@apr_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>PERMISO DE INSTANCIA</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_permiso_instancia</span></td><td style='width:594px'><span style='font-size:8px'>@permiso_instancia_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>CD3</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_dc3</span></td><td style='width:594px'><span style='font-size:8px'>@dc3_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>EXTINTOR&nbsp;</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_extintor</span></td><td style='width:594px'><span style='font-size:8px'>@extintor_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>KIT ANTIDERRAMES</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_kit_antiderrames</span></td><td style='width:594px'><span style='font-size:8px'>@kit_antiderrames_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>PLATICA 5 MINUTOS</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_platica_5min</span></td><td style='width:594px'><span style='font-size:8px'>@platica_5min_obs</span></td></tr><tr><td style='width:430px'><span style='font-size:8px'>EPP</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_epp</span></td><td style='width:594px'><span style='font-size:8px'>@epp_obs</span></td></tr><tr><td style='width:109px'><span style='font-size:8px'>OTRO</span></td><td style='text-align:center;width:137px'><span style='font-size:8px'>_otro</span></td><td style='width:594px'><span style='font-size:8px'>*otro_obs</span></td></tr></tbody></table>";
                _consecutivo++;

                var _idEconomico = item.idEconomico;
                var _idOperador = item.idOperador;
                var _actividad = item.actividad;
                var _pto_exacto = item.pto_exacto;
                string _chequeo_medico = item.chequeo_medico == "X" ? "N/A" : item.chequeo_medico == "S" ? "SI" : "NO";
                var _chequeo_medico_obs = item.chequeo_medico_obs;
                string _checklist_maq_equip = item.checklist_maq_equip == "X" ? "N/A" : item.checklist_maq_equip == "S" ? "SI" : "NO";
                var _checklist_maq_equip_obs = item.checklist_maq_equip_obs;
                string _apr = item.apr == "X" ? "N/A" : item.apr == "S" ? "SI" : "NO";
                var _apr_obs = item.apr_obs;
                string _permiso_instancia = item.permiso_instancia == "X" ? "N/A" : item.permiso_instancia == "S" ? "SI" : "NO";
                var _permiso_instancia_obs = item.permiso_instancia_obs;
                string _dc3 = item.dc3 == "X" ? "N/A" : item.dc3 == "S" ? "SI" : "NO";
                var _dc3_obs = item.dc3_obs;
                string _extintor = item.extintor == "X" ? "N/A" : item.extintor == "S" ? "SI" : "NO";
                var _extintor_obs = item.extintor_obs;
                string _kit_antiderrames = item.kit_antiderrames == "X" ? "N/A" : item.kit_antiderrames == "S" ? "SI" : "NO";
                var _kit_antiderrames_obs = item.kit_antiderrames_obs;
                string _platica_5min = item.platica_5min == "X" ? "N/A" : item.platica_5min == "S" ? "SI" : "NO";
                var _platica_5min_obs = item.platica_5min_obs;
                string _epp = item.epp == "X" ? "N/A" : item.epp == "S" ? "SI" : "NO";
                var _epp_obs = item.epp_obs;
                string _otro = item.otro == "X" ? "N/A" : item.otro == "S" ? "SI" : "NO";
                var _otro_descrip = item.otro_descrip;
                var _otro_obs = item.otro_obs;
                var _equipoNom = item.equipoNom;
                var _operadorNom = item.operadorNom;

                // stringHTML = stringHTML + stringHTMLaux;
                stringHTML = stringHTML + stringHTMLaux.Replace("_consecutivo", _consecutivo.ToString())
                .Replace("_idEconomico", _idEconomico)
                .Replace("_idOperador", _idOperador)
                .Replace("_actividad", _actividad)
                .Replace("_pto_exacto", _pto_exacto)
                .Replace("_chequeo_medico", _chequeo_medico)
                .Replace("@chequeo_medico_obs", _chequeo_medico_obs)
               .Replace("_checklist_maq_equip", _checklist_maq_equip)
               .Replace("@checklist_maq_equip_obs", _checklist_maq_equip_obs)
               .Replace("_apr", _apr)
               .Replace("@apr_obs", _apr_obs)
               .Replace("_permiso_instancia", _permiso_instancia)
               .Replace("@permiso_instancia_obs", _permiso_instancia_obs)
               .Replace("_dc3", _dc3)
               .Replace("@dc3_obs", _dc3_obs)
               .Replace("_extintor", _extintor)
               .Replace("@extintor_obs", _extintor_obs)
               .Replace("_kit_antiderrames", _kit_antiderrames)
               .Replace("@kit_antiderrames_obs", _kit_antiderrames_obs)
               .Replace("_platica_5min", _platica_5min)
               .Replace("@platica_5min_obs", _platica_5min_obs)
               .Replace("_epp", _epp)
               .Replace("@epp_obs", _epp_obs)
               .Replace("_otro", _otro)
               .Replace("@otro_descrip", _otro_descrip)
               .Replace("*otro_obs", _otro_obs)
               .Replace("_equipoNom", _equipoNom)
                .Replace("_operadorNom", _operadorNom);
            });

            return stringHTML;


        }

        public bool Delete(T pItem)
        {
            var _Item = pItem as BitSegEntidad;

            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _bitSegEntity = db.bitseg.Where(x => x.idBitacora == _Item.idBitacora).FirstOrDefault();
                    db.bitseg.Remove(_bitSegEntity);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Delete(List<T> pList)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _List = pList as List<BitSegEntidad>;

                    _List.ForEach(item =>
                    {
                        var _bitSegEntity = db.bitseg.Where(x => x.idBitacora == item.idBitacora).FirstOrDefault();
                        db.bitseg.Remove(_bitSegEntity);
                    });

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public IEnumerable<object> GetListAll()
        {
            throw new NotImplementedException();
        }

        public object GetListById(object id)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    int docBitacora = Convert.ToInt32(id);
                    var _BitSeg = db.bitseg.Where(x => x.docBitacora == docBitacora).FirstOrDefault();

                    return _BitSeg;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public IEnumerable<object> GetListFilter(object filtro)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _filtros = filtro as FiltrosEntidad;

                    _filtros.idUsuario = _filtros.idUsuario == null ? "0" : _filtros.idUsuario;
                    var _todos = (_filtros.idEconomico == "" && _filtros.idOperador == "" && _filtros.idObra == "");

                    List<BitSegEntidad> _Listado = db.bitseg
                        .Where(x =>
                                (
                                    (x.idEconomico == _filtros.idEconomico || _todos)
                                 || (x.idObra == _filtros.idObra || _todos)
                                 || (x.idOperador == _filtros.idOperador || _todos)
                                )
                                &&
                                (
                                    x.fecha.Year == _filtros.fecha_alta.Year
                                          && x.fecha.Month == _filtros.fecha_alta.Month
                                          && x.fecha.Day == _filtros.fecha_alta.Day
                                )
                                && (x.idUsuario == _filtros.idUsuario || _filtros.idUsuario == "0")
                              )
                        .Select(x => new BitSegEntidad
                        {
                            idBitacora = x.idBitacora,
                            docBitacora = x.docBitacora,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            area = x.area,
                            hora_inicio = x.hora_inicio,
                            hora_termino = x.hora_termino,
                            idEconomico = x.idEconomico,
                            idOperador = x.idOperador,
                            actividad = x.actividad,
                            pto_exacto = x.pto_exacto,
                            chequeo_medico = x.chequeo_medico,
                            chequeo_medico_obs = x.chequeo_medico_obs,
                            checklist_maq_equip = x.checklist_maq_equip,
                            checklist_maq_equip_obs = x.checklist_maq_equip_obs,
                            apr = x.apr,
                            apr_obs = x.apr_obs,
                            permiso_instancia = x.permiso_instancia,
                            permiso_instancia_obs = x.permiso_instancia_obs,
                            dc3 = x.dc3,
                            dc3_obs = x.dc3_obs,
                            extintor = x.extintor,
                            extintor_obs = x.extintor_obs,
                            kit_antiderrames = x.kit_antiderrames,
                            kit_antiderrames_obs = x.kit_antiderrames_obs,
                            platica_5min = x.platica_5min,
                            platica_5min_obs = x.platica_5min_obs,
                            epp = x.epp,
                            epp_obs = x.epp_obs,
                            otro = x.otro,
                            otro_descrip = x.otro_descrip,
                            otro_obs = x.otro_obs,
                            idUsuario = x.idUsuario,
                            equipoNom = x.maquinaria.Tipo,
                            obraNom = x.obras.Nombre,
                            operadorNom = x.operadores.Nombre,
                            supervisorNom = x.operadores1.Nombre,
                            horaInicio = x.horaInicio,
                            horaTermino = x.horaTermino
                        })
                        .ToList();

                    var _BitSegEncabezadosDTO = this.getEncabezadoBitacoraSeguridad(_Listado);
                    var _ListBitSegDTO = this.getDetailBitacoraSeguridad(_BitSegEncabezadosDTO, _Listado);
                    return _ListBitSegDTO;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public object Insert(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        long _docBitacora = 0;
                        long _idBitacora = 0;
                        var _Item = pItem as BitSegEntidad;

                        _idBitacora = _Item.idBitacora;
                        if (_idBitacora != 0)
                            throw new Exception("El registro ya existe.");

                        _docBitacora = _Item.docBitacora;
                        if (_docBitacora == 0)
                        {
                            var _params = db.parametros.Where(x => x.nombre == "docBitacora").Select(x => x).FirstOrDefault();
                            if (!string.IsNullOrEmpty(_params.valor))
                                _docBitacora = Convert.ToInt32(_params.valor);

                            _docBitacora++;
                            _Item.docBitacora = _docBitacora;
                            _params.valor = _docBitacora.ToString();
                        }

                        var _bitSegEntity = new bitseg
                        {
                            docBitacora = _docBitacora,
                            fecha = _Item.fecha,
                            idSupervisor = _Item.idSupervisor,
                            idObra = _Item.idObra,
                            area = _Item.area,
                            hora_inicio = _Item.hora_inicio,
                            hora_termino = _Item.hora_termino,
                            idEconomico = _Item.idEconomico,
                            idOperador = _Item.idOperador,
                            actividad = _Item.actividad,
                            pto_exacto = _Item.pto_exacto,
                            chequeo_medico = _Item.chequeo_medico,
                            chequeo_medico_obs = _Item.chequeo_medico_obs,
                            checklist_maq_equip = _Item.checklist_maq_equip,
                            checklist_maq_equip_obs = _Item.checklist_maq_equip_obs,
                            apr = _Item.apr,
                            apr_obs = _Item.apr_obs,
                            permiso_instancia = _Item.permiso_instancia,
                            permiso_instancia_obs = _Item.permiso_instancia_obs,
                            dc3 = _Item.dc3,
                            dc3_obs = _Item.dc3_obs,
                            extintor = _Item.extintor,
                            extintor_obs = _Item.extintor_obs,
                            kit_antiderrames = _Item.kit_antiderrames,
                            kit_antiderrames_obs = _Item.kit_antiderrames_obs,
                            platica_5min = _Item.platica_5min,
                            platica_5min_obs = _Item.platica_5min_obs,
                            epp = _Item.epp,
                            epp_obs = _Item.epp_obs,
                            otro = _Item.otro,
                            otro_descrip = _Item.otro_descrip,
                            otro_obs = _Item.otro_obs,
                            idUsuario = _Item.idUsuario,
                            horaInicio = _Item.horaInicio,
                            horaTermino = _Item.horaTermino
                        };

                        db.bitseg.Add(_bitSegEntity);

                        db.SaveChanges();
                        transaction.Commit();
                        _Item.idBitacora = _bitSegEntity.idBitacora;
                        _Item.docBitacora = _bitSegEntity.docBitacora;
                        return _Item;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        var _error = ex.Message.ToString();
                        throw;
                    }
                }
            }
        }

        public bool Insert(List<T> pList)
        {
            using (var db = new MaquinariaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _List = pList as List<BitSegEntidad>;

                        int _docBitacora = 0;
                        var _valor = db.parametros.Where(x => x.nombre == "docBitacora").Select(x => x.valor).FirstOrDefault();
                        if (!string.IsNullOrEmpty(_valor))
                            _docBitacora++;

                        _List.ForEach(_Item =>
                        {
                            var _bitSegEntity = new bitseg
                            {
                                docBitacora = _docBitacora,
                                fecha = _Item.fecha,
                                idSupervisor = _Item.idSupervisor,
                                idObra = _Item.idObra,
                                area = _Item.area,
                                hora_inicio = _Item.hora_inicio,
                                hora_termino = _Item.hora_termino,
                                idEconomico = _Item.idEconomico,
                                idOperador = _Item.idOperador,
                                actividad = _Item.actividad,
                                pto_exacto = _Item.pto_exacto,
                                chequeo_medico = _Item.chequeo_medico,
                                chequeo_medico_obs = _Item.chequeo_medico_obs,
                                checklist_maq_equip = _Item.checklist_maq_equip,
                                checklist_maq_equip_obs = _Item.checklist_maq_equip_obs,
                                apr = _Item.apr,
                                apr_obs = _Item.apr_obs,
                                permiso_instancia = _Item.permiso_instancia,
                                permiso_instancia_obs = _Item.permiso_instancia_obs,
                                dc3 = _Item.dc3,
                                dc3_obs = _Item.dc3_obs,
                                extintor = _Item.extintor,
                                extintor_obs = _Item.extintor_obs,
                                kit_antiderrames = _Item.kit_antiderrames,
                                kit_antiderrames_obs = _Item.kit_antiderrames_obs,
                                platica_5min = _Item.platica_5min,
                                platica_5min_obs = _Item.platica_5min_obs,
                                epp = _Item.epp,
                                epp_obs = _Item.epp_obs,
                                otro = _Item.otro,
                                otro_descrip = _Item.otro_descrip,
                                otro_obs = _Item.otro_obs,
                                idUsuario = _Item.idUsuario,
                                horaInicio = _Item.horaInicio,
                                horaTermino = _Item.horaTermino
                            };

                            db.bitseg.Add(_bitSegEntity);

                            db.SaveChanges();
                        });

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
        }

        public object Update(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _Item = pItem as BitSegEntidad;

                        var _bitSegEntity = db.bitseg.Where(x => x.idBitacora == _Item.idBitacora).FirstOrDefault();

                        _bitSegEntity.fecha = _Item.fecha;
                        _bitSegEntity.idSupervisor = _Item.idSupervisor;
                        _bitSegEntity.idEconomico = _Item.idEconomico;
                        _bitSegEntity.idOperador = _Item.idOperador;
                        _bitSegEntity.idObra = _Item.idObra;
                        _bitSegEntity.area = _Item.area;
                        _bitSegEntity.hora_inicio = _Item.hora_inicio;
                        _bitSegEntity.hora_termino = _Item.hora_termino;
                        _bitSegEntity.actividad = _Item.actividad;
                        _bitSegEntity.pto_exacto = _Item.pto_exacto;
                        _bitSegEntity.chequeo_medico = _Item.chequeo_medico;
                        _bitSegEntity.chequeo_medico_obs = _Item.chequeo_medico_obs;
                        _bitSegEntity.checklist_maq_equip = _Item.checklist_maq_equip;
                        _bitSegEntity.checklist_maq_equip_obs = _Item.checklist_maq_equip_obs;
                        _bitSegEntity.apr = _Item.apr;
                        _bitSegEntity.apr_obs = _Item.apr_obs;
                        _bitSegEntity.permiso_instancia = _Item.permiso_instancia;
                        _bitSegEntity.permiso_instancia_obs = _Item.permiso_instancia_obs;
                        _bitSegEntity.dc3 = _Item.dc3;
                        _bitSegEntity.dc3_obs = _Item.dc3_obs;
                        _bitSegEntity.extintor = _Item.extintor;
                        _bitSegEntity.extintor_obs = _Item.extintor_obs;
                        _bitSegEntity.kit_antiderrames = _Item.kit_antiderrames;
                        _bitSegEntity.kit_antiderrames_obs = _Item.kit_antiderrames_obs;
                        _bitSegEntity.platica_5min = _Item.platica_5min;
                        _bitSegEntity.platica_5min_obs = _Item.platica_5min_obs;
                        _bitSegEntity.epp = _Item.epp;
                        _bitSegEntity.epp_obs = _Item.epp_obs;
                        _bitSegEntity.otro = _Item.otro;
                        _bitSegEntity.otro_descrip = _Item.otro_descrip;
                        _bitSegEntity.otro_obs = _Item.otro_obs;
                        _bitSegEntity.idUsuario = _Item.idUsuario;
                        _bitSegEntity.horaInicio = _Item.horaInicio;
                        _bitSegEntity.horaTermino = _Item.horaTermino;

                        db.SaveChanges();
                        transaction.Commit();
                        return _Item;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Update(List<T> pList)
        {
            using (var db = new MaquinariaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _List = pList as List<BitSegEntidad>;

                        _List.ForEach(item =>
                        {
                            var _bitSegEntity = db.bitseg.Where(x => x.idBitacora == item.idBitacora).FirstOrDefault();

                            _bitSegEntity.fecha = item.fecha;
                            _bitSegEntity.idSupervisor = item.idSupervisor;
                            _bitSegEntity.idObra = item.idObra;
                            _bitSegEntity.area = item.area;
                            _bitSegEntity.hora_inicio = item.hora_inicio;
                            _bitSegEntity.hora_termino = item.hora_termino;
                            _bitSegEntity.idEconomico = item.idEconomico;
                            _bitSegEntity.idOperador = item.idOperador;
                            _bitSegEntity.actividad = item.actividad;
                            _bitSegEntity.pto_exacto = item.pto_exacto;
                            _bitSegEntity.chequeo_medico = item.chequeo_medico;
                            _bitSegEntity.chequeo_medico_obs = item.chequeo_medico_obs;
                            _bitSegEntity.checklist_maq_equip = item.checklist_maq_equip;
                            _bitSegEntity.checklist_maq_equip_obs = item.checklist_maq_equip_obs;
                            _bitSegEntity.apr = item.apr;
                            _bitSegEntity.apr_obs = item.apr_obs;
                            _bitSegEntity.permiso_instancia = item.permiso_instancia;
                            _bitSegEntity.permiso_instancia_obs = item.permiso_instancia_obs;
                            _bitSegEntity.dc3 = item.dc3;
                            _bitSegEntity.dc3_obs = item.dc3_obs;
                            _bitSegEntity.extintor = item.extintor;
                            _bitSegEntity.extintor_obs = item.extintor_obs;
                            _bitSegEntity.kit_antiderrames = item.kit_antiderrames;
                            _bitSegEntity.kit_antiderrames_obs = item.kit_antiderrames_obs;
                            _bitSegEntity.platica_5min = item.platica_5min;
                            _bitSegEntity.platica_5min_obs = item.platica_5min_obs;
                            _bitSegEntity.epp = item.epp;
                            _bitSegEntity.epp_obs = item.epp_obs;
                            _bitSegEntity.otro = item.otro;
                            _bitSegEntity.otro_descrip = item.otro_descrip;
                            _bitSegEntity.otro_obs = item.otro_obs;
                            _bitSegEntity.idUsuario = item.idUsuario;
                            _bitSegEntity.horaInicio = item.horaInicio;
                            _bitSegEntity.horaTermino = item.horaTermino;

                            db.SaveChanges();
                        });

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        #region ESPECIAL PARA INSERTAR REGISTROS A DTO LISTADO DE BITACORA SEGURIDAD.
        private List<BitSegDTO> getEncabezadoBitacoraSeguridad(List<BitSegEntidad> pBitacoraSegFiltrada)
        {

            var _ListadoEncabezado = pBitacoraSegFiltrada
                .GroupBy(g => new { g.docBitacora, g.fecha, g.idSupervisor, g.idObra, g.area, g.hora_inicio, g.hora_termino, g.supervisorNom, g.obraNom, g.horaInicio, g.horaTermino })
                .Select(x => new BitSegDTO
                {
                    docBitacora = x.Key.docBitacora,
                    fecha = x.Key.fecha,
                    idSupervisor = x.Key.idSupervisor,
                    idObra = x.Key.idObra,
                    area = x.Key.area,
                    hora_inicio = x.Key.hora_inicio,
                    hora_termino = x.Key.hora_termino,
                    supervisorNom = x.Key.supervisorNom,
                    obraNom = x.Key.obraNom,
                    horaInicio = x.Key.horaInicio,
                    horaTermino = x.Key.horaTermino
                })
                .ToList();

            return _ListadoEncabezado;
        }

        private List<BitSegDTO> getDetailBitacoraSeguridad(List<BitSegDTO> pBitSegEncabezadosDTO, List<BitSegEntidad> pBitacoraSegFiltrada)
        {
            pBitSegEncabezadosDTO.ForEach(itemBitSegEncabezado =>
            {
                var _ListadoBitSeg = pBitacoraSegFiltrada.Where(x => x.docBitacora == itemBitSegEncabezado.docBitacora).ToList();
                itemBitSegEncabezado.ListadoBitSeg = new List<BitSegEntidad>();
                _ListadoBitSeg.ForEach(x => itemBitSegEncabezado.ListadoBitSeg.Add(x));
            });

            return pBitSegEncabezadosDTO;
        }

        public string getXLSX(List<BitSegEntidad> pList)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Documento", typeof(string)));
                dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
                dt.Columns.Add(new DataColumn("Planta", typeof(string)));
                dt.Columns.Add(new DataColumn("Supervisor", typeof(string)));
                dt.Columns.Add(new DataColumn("Area", typeof(string)));
                dt.Columns.Add(new DataColumn("Hora Inicio", typeof(string)));
                dt.Columns.Add(new DataColumn("Hora Termino", typeof(string)));
                dt.Columns.Add(new DataColumn("Equipo", typeof(string)));
                dt.Columns.Add(new DataColumn("Operador", typeof(string)));
                dt.Columns.Add(new DataColumn("Actividad", typeof(string)));
                dt.Columns.Add(new DataColumn("Punto Exacto", typeof(string)));
                dt.Columns.Add(new DataColumn("Chequeo Medico", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Chequeo Medico", typeof(string)));
                dt.Columns.Add(new DataColumn("Check List Equipo", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Check List Equipo", typeof(string)));
                dt.Columns.Add(new DataColumn("A.P.R", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs A.P.R", typeof(string)));
                dt.Columns.Add(new DataColumn("Permiso Instancia", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Permiso Instancia", typeof(string)));
                dt.Columns.Add(new DataColumn("DC3", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs DC3", typeof(string)));
                dt.Columns.Add(new DataColumn("Extintor", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Extintor", typeof(string)));
                dt.Columns.Add(new DataColumn("Kit Antiderrames", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Kit Antiderrames", typeof(string)));
                dt.Columns.Add(new DataColumn("Platica 5 minutos", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Platica 5 minutos", typeof(string)));
                dt.Columns.Add(new DataColumn("EPP", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs EPP", typeof(string)));
                dt.Columns.Add(new DataColumn("Otro", typeof(string)));
                dt.Columns.Add(new DataColumn("Descripcion Otro", typeof(string)));
                dt.Columns.Add(new DataColumn("Obs Otro", typeof(string)));

                pList.ForEach(x => {
                    dt.Rows.Add(x.docBitacora, x.fecha.ToString("dd-MM-yyyy"), x.idObra, x.idSupervisor, x.area, x.horaInicio, x.horaTermino, x.idEconomico, x.idOperador, x.actividad, x.pto_exacto,
                        valoresCampos(x.chequeo_medico), x.chequeo_medico_obs, valoresCampos(x.checklist_maq_equip), x.checklist_maq_equip_obs, valoresCampos(x.apr), x.apr_obs,
                        valoresCampos(x.permiso_instancia), x.permiso_instancia_obs, valoresCampos(x.dc3), x.dc3_obs,
                        valoresCampos(x.extintor), x.extintor_obs, valoresCampos(x.kit_antiderrames), x.kit_antiderrames_obs, valoresCampos(x.platica_5min), x.platica_5min_obs,
                        valoresCampos(x.epp), x.epp_obs, valoresCampos(x.otro), x.otro_descrip, x.otro_obs);
                });

                generaPDF _generaPDF = new generaPDF();
                return _generaPDF.createXLSXtoBase64(dt);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string valoresCampos(string pDato) => pDato == "X" ? "N/A" : pDato == "S" ? "SI" : "NO";
       


        #endregion

    }
}
