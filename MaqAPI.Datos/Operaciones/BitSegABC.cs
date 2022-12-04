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
    public class BitSegABC : IConexion
    {
        public BitSegEntidad bitSegEntidad { get; set; }
        private bitseg _bitSegEntity;

        public bool Delete()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == this.bitSegEntidad.idBitacora).FirstOrDefault();

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
                        .OrderBy(x => x.idEconomico)
                        .Select(x => x).ToList();

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
                    this._bitSegEntity = new bitseg
                    {
                        docBitacora = this._bitSegEntity.docBitacora,
                        fecha = this._bitSegEntity.fecha,
                        idOperador = this._bitSegEntity.idOperador,
                        idEconomico = this._bitSegEntity.idEconomico,
                        idObra = this._bitSegEntity.idObra,
                        area = this._bitSegEntity.area,
                        hora_inicio = this._bitSegEntity.hora_inicio,
                        hora_termino = this._bitSegEntity.hora_termino,
                        actividad = this._bitSegEntity.actividad,
                        pto_exacto = this._bitSegEntity.pto_exacto,
                        chequeo_medico = this._bitSegEntity.chequeo_medico,
                        chequeo_medico_obs = this._bitSegEntity.chequeo_medico_obs,
                        checklist_maq_equip = this._bitSegEntity.checklist_maq_equip,
                        checklist_maq_equip_obs = this._bitSegEntity.checklist_maq_equip_obs,
                        apr = this._bitSegEntity.apr,
                        apr_obs = this._bitSegEntity.apr_obs,
                        permiso_instancia = this._bitSegEntity.permiso_instancia,
                        permiso_instancia_obs = this._bitSegEntity.permiso_instancia_obs,
                        dc3 = this._bitSegEntity.dc3,
                        dc3_obs = this._bitSegEntity.dc3_obs,
                        extintor = this._bitSegEntity.extintor,
                        extintor_obs = this._bitSegEntity.extintor_obs,
                        kit_antiderrames = this._bitSegEntity.kit_antiderrames,
                        kit_antiderrames_obs = this._bitSegEntity.kit_antiderrames_obs,
                        platica_5min = this._bitSegEntity.platica_5min,
                        platica_5min_obs = this._bitSegEntity.platica_5min_obs,
                        epp = this._bitSegEntity.epp,
                        epp_obs = this._bitSegEntity.epp_obs,
                        otro = this._bitSegEntity.otro,
                        otro_descrip = this._bitSegEntity.otro_descrip,
                        otro_obs = this._bitSegEntity.otro_obs,
                        idUsuario = this._bitSegEntity.idUsuario
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

        public bool Update()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    this._bitSegEntity = db.bitseg.Where(x => x.idBitacora == this.bitSegEntidad.idBitacora).FirstOrDefault();

                    this._bitSegEntity.docBitacora = this._bitSegEntity.docBitacora;
                    this._bitSegEntity.fecha = this._bitSegEntity.fecha;
                    this._bitSegEntity.idOperador = this._bitSegEntity.idOperador;
                    this._bitSegEntity.idEconomico = this._bitSegEntity.idEconomico;
                    this._bitSegEntity.idObra = this._bitSegEntity.idObra;
                    this._bitSegEntity.area = this._bitSegEntity.area;
                    this._bitSegEntity.hora_inicio = this._bitSegEntity.hora_inicio;
                    this._bitSegEntity.hora_termino = this._bitSegEntity.hora_termino;
                    this._bitSegEntity.actividad = this._bitSegEntity.actividad;
                    this._bitSegEntity.pto_exacto = this._bitSegEntity.pto_exacto;
                    this._bitSegEntity.chequeo_medico = this._bitSegEntity.chequeo_medico;
                    this._bitSegEntity.chequeo_medico_obs = this._bitSegEntity.chequeo_medico_obs;
                    this._bitSegEntity.checklist_maq_equip = this._bitSegEntity.checklist_maq_equip;
                    this._bitSegEntity.checklist_maq_equip_obs = this._bitSegEntity.checklist_maq_equip_obs;
                    this._bitSegEntity.apr = this._bitSegEntity.apr;
                    this._bitSegEntity.apr_obs = this._bitSegEntity.apr_obs;
                    this._bitSegEntity.permiso_instancia = this._bitSegEntity.permiso_instancia;
                    this._bitSegEntity.permiso_instancia_obs = this._bitSegEntity.permiso_instancia_obs;
                    this._bitSegEntity.dc3 = this._bitSegEntity.dc3;
                    this._bitSegEntity.dc3_obs = this._bitSegEntity.dc3_obs;
                    this._bitSegEntity.extintor = this._bitSegEntity.extintor;
                    this._bitSegEntity.extintor_obs = this._bitSegEntity.extintor_obs;
                    this._bitSegEntity.kit_antiderrames = this._bitSegEntity.kit_antiderrames;
                    this._bitSegEntity.kit_antiderrames_obs = this._bitSegEntity.kit_antiderrames_obs;
                    this._bitSegEntity.platica_5min = this._bitSegEntity.platica_5min;
                    this._bitSegEntity.platica_5min_obs = this._bitSegEntity.platica_5min_obs;
                    this._bitSegEntity.epp = this._bitSegEntity.epp;
                    this._bitSegEntity.epp_obs = this._bitSegEntity.epp_obs;
                    this._bitSegEntity.otro = this._bitSegEntity.otro;
                    this._bitSegEntity.otro_descrip = this._bitSegEntity.otro_descrip;
                    this._bitSegEntity.otro_obs = this._bitSegEntity.otro_obs;
                    this._bitSegEntity.idUsuario = this._bitSegEntity.idUsuario;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
