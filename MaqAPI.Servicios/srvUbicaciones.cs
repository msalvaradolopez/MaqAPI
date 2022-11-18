using MaqAPI.Datos;
using MaqAPI.Datos.Operaciones;
using MaqAPI.Entidades;
using MaqAPI.DTOMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public class srvUbicaciones : IServiciosCatalogos
    {
        public UbicacionEntidad ubicacionEntidad { get; set; }
        public bool Actualizar()
        {
            try
            {
                var _UbicacionesABC = new UbicacionesABC
                {
                    ubicacionEntidad = this.ubicacionEntidad
                };
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
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
                var _UbicacionesABC = new UbicacionesABC
                {
                    ubicacionEntidad = this.ubicacionEntidad
                };
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
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
                var _UbicacionesABC = new UbicacionesABC
                {
                    ubicacionEntidad = this.ubicacionEntidad
                };
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
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
            throw new Exception("No implelentado.");
        }

        public IEnumerable<object> ListadoFiltro(object filtro)
        {
            try
            {
                var _UbicacionesABC = new UbicacionesABC();
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);

                var _ubicacionesDTOMap = new UbicacionesDTOMap();

                return _ubicacionesDTOMap.CreateUbicacionesList(_catalogosABC.ListadoFiltro(filtro), filtro);
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
                var _UbicacionesABC = new UbicacionesABC();
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
                return _catalogosABC.ListadoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
