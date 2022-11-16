using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Datos.Interfaz;
using MaqAPI.Datos.Models;
using MaqAPI.Entidades;

namespace MaqAPI.Datos.Operaciones
{
    public class UbicacionesABC : IConexion
    {
        public UbicacionEntidad ubicacionEntidad { get; set; }
        private ubicacion _ubicacionEntity;
        public bool Delete()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    this._ubicacionEntity = db.ubicacions.Where(x => x.idUbicacion == this.ubicacionEntidad.idUbicacion).FirstOrDefault();

                    db.ubicacions.Remove(this._ubicacionEntity);

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
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _listado = db.ubicacions
                        .OrderBy(x => x.idEconomico)
                        .Select(x => x).ToList();

                    return _listado;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public object GetListById(object id)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    int idUbicacion = Convert.ToInt32(id);
                    var _ubucacionById = db.ubicacions.Where(x => x.idUbicacion == idUbicacion).FirstOrDefault();

                    return _ubucacionById;
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
                    this._ubicacionEntity = new ubicacion
                    {
                        idEconomico = this.ubicacionEntidad.idEconomico,
                        idOperador = this.ubicacionEntidad.idOperador,
                        idObra = this.ubicacionEntidad.idObra,
                        fecha_alta = this.ubicacionEntidad.fecha_alta,
                        comentarios = this.ubicacionEntidad.comentarios,
                        idUsuario = this.ubicacionEntidad.idUsuario,
                        fecha_ingreso = this.ubicacionEntidad.fecha_ingreso,
                        hodometro = 0,
                        odometro = this.ubicacionEntidad.odometro,
                        sello = this.ubicacionEntidad.sello,
                        litros = this.ubicacionEntidad.litros,
                        horometro = this.ubicacionEntidad.horometro,
                        ventana = this.ubicacionEntidad.ventana
                    };

                    db.ubicacions.Add(this._ubicacionEntity);
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

                    this._ubicacionEntity = db.ubicacions.Where(x => x.idUbicacion == this.ubicacionEntidad.idUbicacion).FirstOrDefault();

                    this._ubicacionEntity.idOperador = this.ubicacionEntidad.idOperador;
                    this._ubicacionEntity.idObra = this.ubicacionEntidad.idObra;
                    this._ubicacionEntity.fecha_alta = this.ubicacionEntidad.fecha_alta;
                    this._ubicacionEntity.comentarios = this.ubicacionEntidad.comentarios;
                    this._ubicacionEntity.idUsuario = this.ubicacionEntidad.idUsuario;
                    this._ubicacionEntity.fecha_ingreso = this.ubicacionEntidad.fecha_ingreso;
                    this._ubicacionEntity.hodometro = 0;
                    this._ubicacionEntity.odometro = this.ubicacionEntidad.odometro;
                    this._ubicacionEntity.sello = this.ubicacionEntidad.sello;
                    this._ubicacionEntity.litros = this.ubicacionEntidad.litros;
                    this._ubicacionEntity.horometro = this.ubicacionEntidad.horometro;
                    this._ubicacionEntity.ventana = this.ubicacionEntidad.ventana;

                    db.SaveChanges();
                    return true;
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

                    var _obraByID = db.ubicacions
                        .Where(x => x.idEconomico.Contains(_filtros.idEconomico)
                                    || x.idOperador.Contains(_filtros.idOperador)
                                    || x.idObra.Contains(_filtros.idObra)
                                    || (
                                        x.fecha_alta.Year == _filtros.fecha_alta.Year 
                                            && x.fecha_alta.Month == _filtros.fecha_alta.Month
                                            && x.fecha_alta.Day == _filtros.fecha_alta.Day
                                       )
                                )
                        .OrderBy(x=> x.idEconomico)
                        .Select(x => x).ToList();

                    return _obraByID;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
