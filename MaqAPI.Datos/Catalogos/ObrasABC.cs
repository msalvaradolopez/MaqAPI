using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Datos.Interfaz;
using MaqAPI.Datos.Models;
using MaqAPI.Entidades;

namespace MaqAPI.Datos.Catalogos
{
    public class ObrasABC<T> : IConexion<T>
    {
        public IEnumerable<object> GetListAll()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ObrasListado = db.obras
                        .OrderBy(x => x.Nombre)
                        .Select(x => x).ToList();

                    return _ObrasListado;
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

                    var _obraByID = db.obras.Where(x => x.idObra == id.ToString())
                        .Select(x => new {
                            x.idObra,
                            x.Nombre,
                            x.estatus,
                            x.fecha_alta
                        })
                        .FirstOrDefault();

                    return _obraByID;
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

                    var _obraByID = db.obras
                        .Where(x => (x.idObra.Contains(_filtros.buscar) 
                                        || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                        .OrderBy(x => x.Nombre)
                        .Select(x => new { 
                            x.idObra,
                            x.Nombre,
                            x.estatus,
                            x.fecha_alta
                        })
                        .ToList();

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
                    var _item = pItem as ObraEntidad;

                    obras _obraEntity = new obras();
                    _obraEntity.idObra = _item.idObra;
                    _obraEntity.Nombre = _item.Nombre;
                    _obraEntity.estatus = _item.estatus;
                    _obraEntity.fecha_alta = _item.fecha_alta;

                    db.obras.Add(_obraEntity);
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

        public object Update(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = pItem as ObraEntidad;
                    var _obraEntity = db.obras.Where(x => x.idObra == _item.idObra).FirstOrDefault();

                    _obraEntity.Nombre = _item.Nombre;
                    _obraEntity.estatus = _item.estatus;
                    _obraEntity.fecha_alta = _item.fecha_alta;

                    db.SaveChanges();
                    return _item;
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
            throw new NotImplementedException();
        }

        public bool Delete(List<T> pList)
        {
            throw new NotImplementedException();
        }
    }
}
