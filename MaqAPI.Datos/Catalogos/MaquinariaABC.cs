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
    public class MaquinariaABC : IConexion
    {
        public MaquinariaEntidad MaquinariaEntidad { get; set; }
        private maquinaria _maquinariaEntity;
        public bool Delete()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    this._maquinariaEntity = db.maquinarias.Where(x => x.idEconomico == this.MaquinariaEntidad.idEconomico).FirstOrDefault();

                    db.maquinarias.Remove(this._maquinariaEntity);

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

                    var _maquinariaById = db.maquinarias.Where(x => x.idEconomico == id.ToString()).FirstOrDefault();

                    return _maquinariaById;
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
                    this._maquinariaEntity = new maquinaria();
                    this._maquinariaEntity.idEconomico = this.MaquinariaEntidad.idEconomico;
                    this._maquinariaEntity.Tipo = this.MaquinariaEntidad.Tipo;
                    this._maquinariaEntity.estatus = this.MaquinariaEntidad.estatus;
                    this._maquinariaEntity.fecha_alta = this.MaquinariaEntidad.fecha_alta;

                    db.maquinarias.Add(this._maquinariaEntity);
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

                    this._maquinariaEntity = db.maquinarias.Where(x => x.idEconomico == this.MaquinariaEntidad.idEconomico).FirstOrDefault();

                    this._maquinariaEntity.Tipo = this.MaquinariaEntidad.Tipo;
                    this._maquinariaEntity.estatus = this.MaquinariaEntidad.estatus;
                    this._maquinariaEntity.fecha_alta = this.MaquinariaEntidad.fecha_alta;

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

                    var _obraByID = db.maquinarias
                        .Where(x => x.idEconomico.Contains(filtro.ToString())
                                    || x.Tipo.Contains(filtro.ToString())
                                    || x.estatus.Contains(filtro.ToString()))
                        .OrderBy(x=> x.Tipo)
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
