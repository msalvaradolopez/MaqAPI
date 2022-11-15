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
    public class OperadoresABC : IConexion
    {

        public OperadorEntidad OperadorEntidad { get; set; }
        private operadore _OperadorEntity;
        public bool Delete()
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    this._OperadorEntity = db.operadores.Where(x => x.idOperador == this.OperadorEntidad.idOperador).FirstOrDefault();

                    db.operadores.Remove(this._OperadorEntity);

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

                    var _operadorById = db.operadores.Where(x => x.idOperador == id.ToString()).FirstOrDefault();

                    return _operadorById;
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
                    this._OperadorEntity = new operadore
                    {
                        idOperador = this.OperadorEntidad.idOperador,
                        Nombre = this.OperadorEntidad.Nombre,
                        estatus = this.OperadorEntidad.estatus,
                        fecha_alta = this.OperadorEntidad.fecha_alta,
                        categoria = this.OperadorEntidad.categoria,
                        passw = this.OperadorEntidad.passw
                    };

                    db.operadores.Add(this._OperadorEntity);
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

                    this._OperadorEntity = db.operadores.Where(x => x.idOperador == this.OperadorEntidad.idOperador).FirstOrDefault();

                    this._OperadorEntity.Nombre = this.OperadorEntidad.Nombre;
                    this._OperadorEntity.estatus = this.OperadorEntidad.estatus;
                    this._OperadorEntity.fecha_alta = this.OperadorEntidad.fecha_alta;
                    this._OperadorEntity.categoria = this.OperadorEntidad.categoria;
                    this._OperadorEntity.passw = this.OperadorEntidad.passw;

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

                    var _obraByID = db.operadores
                        .Where(x => x.idOperador.Contains(filtro.ToString())
                                    || x.Nombre.Contains(filtro.ToString())
                                    || x.estatus.Contains(filtro.ToString()))
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
