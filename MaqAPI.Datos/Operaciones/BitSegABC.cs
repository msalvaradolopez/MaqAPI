using MaqAPI.Datos.Interfaz;
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

namespace MaqAPI.Datos.Operaciones
{
    public class BitSegABC<T> : IConexion<T>
    {
        private bitseg _bitSegEntity;

        public bool Delete(T pItem)
        {
            var _Item = pItem as BitSegEntidad;

            using (var db = new MaquinariaEntities())
            {
                try
                {
                    this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == _Item.idBitacora).FirstOrDefault();
                    db.bitseg.Remove(this._bitSegEntity);
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
                        this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == item.idBitacora).FirstOrDefault();
                        db.bitseg.Remove(this._bitSegEntity);
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
                    var _todos = (_filtros.idEconomico == null && _filtros.idOperador == null && _filtros.idObra == null);

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
                        .Select(x => new BitSegEntidad {
                            idBitacora = x.idBitacora,
                            docBitacora =x.docBitacora,
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
                            supervisorNom = x.operadores11.Nombre
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

        public bool Insert(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _Item = pItem as BitSegEntidad;

                    int _docBitacora = 0;
                    var _valor = db.parametros.Where(x => x.nombre == "docBitacora").Select(x => x.valor).FirstOrDefault();
                    if (!string.IsNullOrEmpty(_valor))
                        _docBitacora++;

                    this._bitSegEntity = new bitseg
                    {
                        docBitacora = _docBitacora,
                        fecha = _Item.fecha,
                        idOperador = _Item.idOperador,
                        idEconomico = _Item.idEconomico,
                        idObra = _Item.idObra,
                        area = _Item.area,
                        hora_inicio = _Item.hora_inicio,
                        hora_termino = _Item.hora_termino,
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
                        idUsuario = _Item.idUsuario
                    };

                    db.bitseg.Add(this._bitSegEntity);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
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
                            this._bitSegEntity = new bitseg
                            {
                                docBitacora = _docBitacora,
                                fecha = _Item.fecha,
                                idOperador = _Item.idOperador,
                                idEconomico = _Item.idEconomico,
                                idObra = _Item.idObra,
                                area = _Item.area,
                                hora_inicio = _Item.hora_inicio,
                                hora_termino = _Item.hora_termino,
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
                                idUsuario = _Item.idUsuario
                            };

                            db.bitseg.Add(this._bitSegEntity);

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

        public bool Update(T pItem)
        {
            throw new NotImplementedException();
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
                            this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == item.idBitacora).FirstOrDefault();

                            this._bitSegEntity.fecha = item.fecha;
                            this._bitSegEntity.idOperador = item.idOperador;
                            this._bitSegEntity.idEconomico = item.idEconomico;
                            this._bitSegEntity.idObra = item.idObra;
                            this._bitSegEntity.area = item.area;
                            this._bitSegEntity.hora_inicio = item.hora_inicio;
                            this._bitSegEntity.hora_termino = item.hora_termino;
                            this._bitSegEntity.actividad = item.actividad;
                            this._bitSegEntity.pto_exacto = item.pto_exacto;
                            this._bitSegEntity.chequeo_medico = item.chequeo_medico;
                            this._bitSegEntity.chequeo_medico_obs = item.chequeo_medico_obs;
                            this._bitSegEntity.checklist_maq_equip = item.checklist_maq_equip;
                            this._bitSegEntity.checklist_maq_equip_obs = item.checklist_maq_equip_obs;
                            this._bitSegEntity.apr = item.apr;
                            this._bitSegEntity.apr_obs = item.apr_obs;
                            this._bitSegEntity.permiso_instancia = item.permiso_instancia;
                            this._bitSegEntity.permiso_instancia_obs = item.permiso_instancia_obs;
                            this._bitSegEntity.dc3 = item.dc3;
                            this._bitSegEntity.dc3_obs = item.dc3_obs;
                            this._bitSegEntity.extintor = item.extintor;
                            this._bitSegEntity.extintor_obs = item.extintor_obs;
                            this._bitSegEntity.kit_antiderrames = item.kit_antiderrames;
                            this._bitSegEntity.kit_antiderrames_obs = item.kit_antiderrames_obs;
                            this._bitSegEntity.platica_5min = item.platica_5min;
                            this._bitSegEntity.platica_5min_obs = item.platica_5min_obs;
                            this._bitSegEntity.epp = item.epp;
                            this._bitSegEntity.epp_obs = item.epp_obs;
                            this._bitSegEntity.otro = item.otro;
                            this._bitSegEntity.otro_descrip = item.otro_descrip;
                            this._bitSegEntity.otro_obs = item.otro_obs;
                            this._bitSegEntity.idUsuario = item.idUsuario;

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
                .GroupBy(g => new { g.docBitacora, g.fecha, g.idSupervisor, g.idObra, g.area, g.hora_inicio, g.hora_termino, g.supervisorNom, g.obraNom })
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
                    obraNom = x.Key.obraNom
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
                _ListadoBitSeg.ForEach(x =>
                {
                    itemBitSegEncabezado.ListadoBitSeg.Add(x);
                });
            });

            return pBitSegEncabezadosDTO;
        }
        #endregion

    }
}
