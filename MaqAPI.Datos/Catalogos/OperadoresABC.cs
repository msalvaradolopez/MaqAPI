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
    public class OperadoresABC<T> : IConexion<T>
    {
        public IEnumerable<object> GetListAll()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _operadoresListado = db.operadores
                        .OrderBy(x=> x.Nombre)
                        .Select(x => x).ToList();

                    return _operadoresListado;
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

                    var _operadorById = db.operadores.Where(x => x.idOperador == id.ToString())
                        .Select(x => new {
                            x.idOperador,
                            x.Nombre,
                            x.fecha_alta,
                            x.estatus,
                            x.categoria,
                            x.passw
                        })
                        .FirstOrDefault();

                    return _operadorById;
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

                    var _obraByID = db.operadores
                        .Where(x => (x.idOperador.Contains(_filtros.buscar)
                                    || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                        .OrderBy(x => x.Nombre)
                        .Select(x => new { 
                            x.idOperador, 
                            x.Nombre, 
                            x.fecha_alta, 
                            x.estatus, 
                            x.categoria, 
                            x.passw 
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
                    var _item = pItem as OperadorEntidad;

                    var _OperadorEntity = new operadore
                    {
                        idOperador = _item.idOperador,
                        Nombre = _item.Nombre,
                        estatus = _item.estatus,
                        fecha_alta = _item.fecha_alta,
                        categoria = _item.categoria,
                        passw = _item.passw
                    };

                    db.operadores.Add(_OperadorEntity);
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
                    var _item = pItem as OperadorEntidad;
                    var _OperadorEntity = db.operadores.Where(x => x.idOperador == _item.idOperador).FirstOrDefault();

                    _OperadorEntity.Nombre = _item.Nombre;
                    _OperadorEntity.estatus = _item.estatus;
                    _OperadorEntity.fecha_alta = _item.fecha_alta;
                    _OperadorEntity.categoria = _item.categoria;
                    _OperadorEntity.passw = _item.passw;

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
                    var _item = pItem as OperadorEntidad;

                    var _OperadorEntity = db.operadores.Where(x => x.idOperador == _item.idOperador).FirstOrDefault();

                    db.operadores.Remove(_OperadorEntity);

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
