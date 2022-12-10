using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Datos.Interfaz;
using MaqAPI.Datos.Models;
using MaqAPI.Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MaqAPI.Datos.Operaciones
{
    public class UbicacionesABC<T> : IConexion<T>
    {
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
                    var _ubucacionById = db.ubicacions.Where(x => x.idUbicacion == idUbicacion)
                        .Select(x => new {
                            x.idUbicacion,
                            x.idEconomico,
                            x.idOperador,
                            x.idObra,
                            x.fecha_alta,
                            x.comentarios,
                            x.idUsuario,
                            x.fecha_ingreso,
                            x.hodometro,
                            x.odometro,
                            x.sello,
                            x.litros,
                            x.horometro,
                            x.ventana,
                            equipoNom = x.maquinaria.Tipo,
                            operadorNom = x.operadores.Nombre,
                            obraNom = x.obras.Nombre
                        })
                        .FirstOrDefault();

                    return _ubucacionById;
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

                    var _obraByID = db.ubicacions
                        .Where(x =>
                            (
                                (x.idEconomico == _filtros.idEconomico || _todos)
                             || (x.idObra == _filtros.idObra || _todos)
                             || (x.idOperador == _filtros.idOperador || _todos)
                            )
                            && (
                            x.fecha_alta.Year == _filtros.fecha_alta.Year
                                      && x.fecha_alta.Month == _filtros.fecha_alta.Month
                                      && x.fecha_alta.Day == _filtros.fecha_alta.Day
                                      )
                            && ( x.idUsuario == _filtros.idUsuario || _filtros.idUsuario == "0" )
                                    )
                        .OrderBy(x => x.idEconomico)
                        .Select(x => new { 
                            x.idUbicacion, 
                            x.idEconomico, 
                            x.idOperador, 
                            x.idObra, 
                            x.fecha_alta, 
                            x.comentarios,
                            x.idUsuario,
                            x.fecha_ingreso,
                            x.hodometro,
                            x.odometro,
                            x.sello,
                            x.litros,
                            x.horometro,
                            x.ventana,
                            equipoNom = x.maquinaria.Tipo,
                            operadorNom = x.operadores.Nombre,
                            obraNom = x.obras.Nombre
                        })
                        .ToList();

                    // var _listado = new List<UbicacionEntidad>();
                    // _listado = JsonConvert.DeserializeObject<List<UbicacionEntidad>>(JsonConvert.SerializeObject(_obraByID, Newtonsoft.Json.Formatting.None));
                    return _obraByID;
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
                try
                {
                    var _item = pItem as UbicacionEntidad;

                    var _ubicacionEntity = new ubicacion
                    {
                        idEconomico = _item.idEconomico,
                        idOperador = _item.idOperador,
                        idObra = _item.idObra,
                        fecha_alta = _item.fecha_alta,
                        comentarios = _item.comentarios,
                        idUsuario = _item.idUsuario,
                        fecha_ingreso = _item.fecha_ingreso,
                        hodometro = 0,
                        odometro = _item.odometro,
                        sello = _item.sello,
                        litros = _item.litros,
                        horometro = _item.horometro,
                        ventana = _item.ventana
                    };

                    db.ubicacions.Add(_ubicacionEntity);
                    db.SaveChanges();
                    return _item;
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

        public bool Update(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = pItem as UbicacionEntidad;

                    var _ubicacionEntity = db.ubicacions.Where(x => x.idUbicacion == _item.idUbicacion).FirstOrDefault();

                    _ubicacionEntity.idOperador = _item.idOperador;
                    _ubicacionEntity.idObra = _item.idObra;
                    _ubicacionEntity.fecha_alta = _item.fecha_alta;
                    _ubicacionEntity.comentarios = _item.comentarios;
                    _ubicacionEntity.idUsuario = _item.idUsuario;
                    _ubicacionEntity.fecha_ingreso = _item.fecha_ingreso;
                    _ubicacionEntity.hodometro = 0;
                    _ubicacionEntity.odometro = _item.odometro;
                    _ubicacionEntity.sello = _item.sello;
                    _ubicacionEntity.litros = _item.litros;
                    _ubicacionEntity.horometro = _item.horometro;
                    _ubicacionEntity.ventana = _item.ventana;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Update(List<T> pList)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = pItem as UbicacionEntidad;
                    var _ubicacionEntity = db.ubicacions.Where(x => x.idUbicacion == _item.idUbicacion).FirstOrDefault();

                    db.ubicacions.Remove(_ubicacionEntity);

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
            throw new NotImplementedException();
        }
    }
}
