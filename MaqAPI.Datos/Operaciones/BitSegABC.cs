using MaqAPI.Datos.Interfaz;
using MaqAPI.Datos.Models;
using MaqAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Datos.Operaciones
{
    public class BitSegABC<T> : IConexion<T>
    {
        private bitseg _bitSegEntity;

        public bool Delete(T pItem)
        {
            var _Item = pItem as BitSegEntidad;

            throw new NotImplementedException();
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
                    var _filtros = (FiltrosEntidad)filtro;

                    _filtros.idUsuario = _filtros.idUsuario == null ? "0" : _filtros.idUsuario;
                    var _todos = (_filtros.idEconomico == null && _filtros.idOperador == null && _filtros.idObra == null);

                    var _obraByID = db.bitseg
                        .Where(x =>
                            (
                                (x.idEconomico == _filtros.idEconomico || _todos)
                             || (x.idObra == _filtros.idObra || _todos)
                             || (x.idOperador == _filtros.idOperador || _todos)
                            )
                            && (
                            x.fecha.Year == _filtros.fecha_alta.Year
                                      && x.fecha.Month == _filtros.fecha_alta.Month
                                      && x.fecha.Day == _filtros.fecha_alta.Day
                                      )
                            && (x.idUsuario == _filtros.idUsuario || _filtros.idUsuario == "0")
                                    )
                        .OrderBy(y => new { y.docBitacora })
                        .GroupBy(g => new { g.docBitacora, g.fecha, g.idOperador, g.idObra, g.area, g.hora_inicio, g.hora_termino, g.actividad, g.pto_exacto })
                        .Select(x => new { x.Key.docBitacora, x.Key.fecha, x.Key.idOperador, x.Key.idObra, x.Key.area, x.Key.hora_inicio, x.Key.hora_termino, x.Key.actividad, x.Key.pto_exacto }).ToList();

                    return _obraByID;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Insert()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _docBitacora = 0;
                    //var _valor = db.parametros.Where(x => x.nombre == "docBitacora").Select(x=> x.valor).FirstOrDefault();
                    //if (!string.IsNullOrEmpty(_valor))
                    //    _docBitacora++;

                    //foreach (var item in this.bitSegEntidad)
                    //{
                    //    this._bitSegEntity = new bitseg
                    //    {
                    //        docBitacora = _docBitacora,
                    //        fecha = item.fecha,
                    //        idOperador = item.idOperador,
                    //        idEconomico = item.idEconomico,
                    //        idObra = item.idObra,
                    //        area = item.area,
                    //        hora_inicio = item.hora_inicio,
                    //        hora_termino = item.hora_termino,
                    //        actividad = item.actividad,
                    //        pto_exacto = item.pto_exacto,
                    //        chequeo_medico = item.chequeo_medico,
                    //        chequeo_medico_obs = item.chequeo_medico_obs,
                    //        checklist_maq_equip = item.checklist_maq_equip,
                    //        checklist_maq_equip_obs = item.checklist_maq_equip_obs,
                    //        apr = item.apr,
                    //        apr_obs = item.apr_obs,
                    //        permiso_instancia = item.permiso_instancia,
                    //        permiso_instancia_obs = item.permiso_instancia_obs,
                    //        dc3 = item.dc3,
                    //        dc3_obs = item.dc3_obs,
                    //        extintor = item.extintor,
                    //        extintor_obs = item.extintor_obs,
                    //        kit_antiderrames = item.kit_antiderrames,
                    //        kit_antiderrames_obs = item.kit_antiderrames_obs,
                    //        platica_5min = item.platica_5min,
                    //        platica_5min_obs = item.platica_5min_obs,
                    //        epp = item.epp,
                    //        epp_obs = item.epp_obs,
                    //        otro = item.otro,
                    //        otro_descrip = item.otro_descrip,
                    //        otro_obs = item.otro_obs,
                    //        idUsuario = item.idUsuario
                    //    };

                    //    db.bitseg.Add(this._bitSegEntity);
                    //}


                    //db.SaveChanges();
                    return true;
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
            throw new NotImplementedException();
        }

        public bool Update()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    //this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == this.bitSegEntidad.idBitacora).FirstOrDefault();

                    //this._bitSegEntity.docBitacora = this._bitSegEntity.docBitacora;
                    //this._bitSegEntity.fecha = this._bitSegEntity.fecha;
                    //this._bitSegEntity.idOperador = this._bitSegEntity.idOperador;
                    //this._bitSegEntity.idEconomico = this._bitSegEntity.idEconomico;
                    //this._bitSegEntity.idObra = this._bitSegEntity.idObra;
                    //this._bitSegEntity.area = this._bitSegEntity.area;
                    //this._bitSegEntity.hora_inicio = this._bitSegEntity.hora_inicio;
                    //this._bitSegEntity.hora_termino = this._bitSegEntity.hora_termino;
                    //this._bitSegEntity.actividad = this._bitSegEntity.actividad;
                    //this._bitSegEntity.pto_exacto = this._bitSegEntity.pto_exacto;
                    //this._bitSegEntity.chequeo_medico = this._bitSegEntity.chequeo_medico;
                    //this._bitSegEntity.chequeo_medico_obs = this._bitSegEntity.chequeo_medico_obs;
                    //this._bitSegEntity.checklist_maq_equip = this._bitSegEntity.checklist_maq_equip;
                    //this._bitSegEntity.checklist_maq_equip_obs = this._bitSegEntity.checklist_maq_equip_obs;
                    //this._bitSegEntity.apr = this._bitSegEntity.apr;
                    //this._bitSegEntity.apr_obs = this._bitSegEntity.apr_obs;
                    //this._bitSegEntity.permiso_instancia = this._bitSegEntity.permiso_instancia;
                    //this._bitSegEntity.permiso_instancia_obs = this._bitSegEntity.permiso_instancia_obs;
                    //this._bitSegEntity.dc3 = this._bitSegEntity.dc3;
                    //this._bitSegEntity.dc3_obs = this._bitSegEntity.dc3_obs;
                    //this._bitSegEntity.extintor = this._bitSegEntity.extintor;
                    //this._bitSegEntity.extintor_obs = this._bitSegEntity.extintor_obs;
                    //this._bitSegEntity.kit_antiderrames = this._bitSegEntity.kit_antiderrames;
                    //this._bitSegEntity.kit_antiderrames_obs = this._bitSegEntity.kit_antiderrames_obs;
                    //this._bitSegEntity.platica_5min = this._bitSegEntity.platica_5min;
                    //this._bitSegEntity.platica_5min_obs = this._bitSegEntity.platica_5min_obs;
                    //this._bitSegEntity.epp = this._bitSegEntity.epp;
                    //this._bitSegEntity.epp_obs = this._bitSegEntity.epp_obs;
                    //this._bitSegEntity.otro = this._bitSegEntity.otro;
                    //this._bitSegEntity.otro_descrip = this._bitSegEntity.otro_descrip;
                    //this._bitSegEntity.otro_obs = this._bitSegEntity.otro_obs;
                    //this._bitSegEntity.idUsuario = this._bitSegEntity.idUsuario;

                    //db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Update(T pItem)
        {
            throw new NotImplementedException();
        }

        public bool Update(List<T> pList)
        {
            throw new NotImplementedException();
        }

        /*
        public bool Delete(List<BitSegEntidad> pList)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    pList.ForEach(item =>
                    {
                        
                        // this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == item.).FirstOrDefault();
                        // db.bitseg.Remove(this._bitSegEntity);
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
        */
    }
}
