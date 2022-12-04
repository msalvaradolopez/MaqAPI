using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Entidades;
using MaqAPI.Datos.Catalogos;
using MaqAPI.Datos;


namespace MaqAPI.Servicios
{
    public class srvMaquinaria : IServicios
    {
        public MaquinariaEntidad maquinariaEntidad { get; set; }
        public bool Actualizar()
        {
            try
            {
                var _MaquinariaABC = new MaquinariaABC
                {
                    MaquinariaEntidad = this.maquinariaEntidad
                };
                var _catalogosABC = new CatalogosABC(_MaquinariaABC);
                _catalogosABC.Actualizar();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar()
        {
            try
            {
                this.maquinariaEntidad.fecha_alta = DateTime.Now;
                var _MaquinariaABC = new MaquinariaABC
                {
                    MaquinariaEntidad = this.maquinariaEntidad
                };
                var _catalogosABC = new CatalogosABC(_MaquinariaABC);
                _catalogosABC.Nuevo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar()
        {
            try
            {
                var _MaquinariaABC = new MaquinariaABC
                {
                    MaquinariaEntidad = this.maquinariaEntidad
                };
                var _catalogosABC = new CatalogosABC(_MaquinariaABC);
                _catalogosABC.Eliminar();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<object> Listado()
        {
            try
            {
                var _maquinariaABC = new MaquinariaABC();
                var _catalogosABC = new CatalogosABC(_maquinariaABC);
                return _catalogosABC.Listado();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<object> ListadoFiltro(object filtro)
        {
            try
            {
                var _maquinariaABC = new MaquinariaABC();
                var _catalogosABC = new CatalogosABC(_maquinariaABC);
                return _catalogosABC.ListadoFiltro(filtro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object ListadoPorId(object id)
        {
            try
            {
                var _maquinariaABC = new MaquinariaABC();
                var _catalogosABC = new CatalogosABC(_maquinariaABC);
                return _catalogosABC.ListadoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
