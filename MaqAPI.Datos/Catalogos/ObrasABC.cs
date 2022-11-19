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
    public class ObrasABC : IConexion
    {
        public ObraEntidad obraEntidad { get; set; }
        private obra _obraEntity;
      
        public bool Insert()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    _obraEntity = new obra();
                    this._obraEntity.idObra = this.obraEntidad.idObra;
                    this._obraEntity.Nombre = this.obraEntidad.Nombre;
                    this._obraEntity.estatus = this.obraEntidad.estatus;
                    this._obraEntity.fecha_alta = this.obraEntidad.fecha_alta;

                    db.obras.Add(this._obraEntity);
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

                    this._obraEntity = db.obras.Where(x => x.idObra == this.obraEntidad.idObra).FirstOrDefault();
                    
                    this._obraEntity.Nombre = this.obraEntidad.Nombre;
                    this._obraEntity.estatus = this.obraEntidad.estatus;
                    this._obraEntity.fecha_alta = this.obraEntidad.fecha_alta;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Delete()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    this._obraEntity = db.obras.Where(x => x.idObra == this.obraEntidad.idObra).FirstOrDefault();

                    db.obras.Remove(this._obraEntity);

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

                    var _obraByID = db.obras.Where(x => x.idObra == id.ToString()).FirstOrDefault();

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
                    var _filtros = (FiltrosEntidad)filtro;

                    var _obraByID = db.obras
                        .Where(x => (x.idObra.Contains(_filtros.buscar) 
                                        || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                        .OrderBy(x => x.Nombre)
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
