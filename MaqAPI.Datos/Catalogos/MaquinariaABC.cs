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
    public class MaquinariaABC<T> : IConexion<T>
    {
        public IEnumerable<object> GetListAll()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _maquinariaList = db.maquinarias
                        .OrderBy(x=>x.Tipo)
                        .Select(x => x).ToList();

                    return _maquinariaList;
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

                    var _maquinariaById = db.maquinarias.Where(x => x.idEconomico == id.ToString())
                        .Select(x => new {
                            x.idEconomico,
                            x.Tipo,
                            x.estatus,
                            x.fecha_alta
                        })
                        .FirstOrDefault();

                    return _maquinariaById;
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

                    var _obraByID = db.maquinarias
                        .Where(x => (x.idEconomico.Contains(_filtros.buscar)
                                    || x.Tipo.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus  || _filtros.estatus == "0"))
                        .OrderBy(x=> x.Tipo)
                        .Select(x => new { 
                            x.idEconomico,
                            x.Tipo,
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

        public bool Insert(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = pItem as MaquinariaEntidad;

                    var _maquinariaEntity = new maquinaria();
                    _maquinariaEntity.idEconomico = _item.idEconomico;
                    _maquinariaEntity.Tipo = _item.Tipo;
                    _maquinariaEntity.estatus = _item.estatus;
                    _maquinariaEntity.fecha_alta = _item.fecha_alta;

                    db.maquinarias.Add(_maquinariaEntity);
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

        public bool Update(T pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = pItem as MaquinariaEntidad;

                    var _maquinariaEntity = db.maquinarias.Where(x => x.idEconomico == _item.idEconomico).FirstOrDefault();

                    _maquinariaEntity.Tipo = _item.Tipo;
                    _maquinariaEntity.estatus = _item.estatus;
                    _maquinariaEntity.fecha_alta = _item.fecha_alta;

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
                    var _item = pItem as MaquinariaEntidad;

                    var _maquinariaEntity = db.maquinarias.Where(x => x.idEconomico == _item.idEconomico).FirstOrDefault();

                    db.maquinarias.Remove(_maquinariaEntity);

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
