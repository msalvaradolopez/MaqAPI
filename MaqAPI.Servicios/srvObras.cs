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
    public class srvObras : IServiciosCatalogos
    {
        public ObraEntidad obraEntidad { get; set; }

        public bool Agregar() 
        {
            try
            {
                var _obrasABC = new ObrasABC
                {
                    obraEntidad = this.obraEntidad
                };
                var _catalogosABC = new CatalogosABC(_obrasABC);
                _catalogosABC.Nuevo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Actualizar()
        {
            try
            {
                var _obrasABC = new ObrasABC
                {
                    obraEntidad = this.obraEntidad
                };
                var _catalogosABC = new CatalogosABC(_obrasABC);
                _catalogosABC.Actualizar();
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
                var _obrasABC = new ObrasABC
                {
                    obraEntidad = this.obraEntidad
                };
                var _catalogosABC = new CatalogosABC(_obrasABC);
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
                var _obrasABC = new ObrasABC();
                var _catalogosABC = new CatalogosABC(_obrasABC);
                return _catalogosABC.Listado();
                 
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
                var _obrasABC = new ObrasABC();
                var _catalogosABC = new CatalogosABC(_obrasABC);
                return _catalogosABC.ListadoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
