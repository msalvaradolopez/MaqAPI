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
    public class srvOperadores: IServiciosCatalogos
    {
        public OperadorEntidad operadorEntidad { get; set; }

        public bool Actualizar()
        {
            try
            {
                var _operadoresABC = new OperadoresABC
                {
                    OperadorEntidad = this.operadorEntidad
                };
                var _catalogosABC = new CatalogosABC(_operadoresABC);
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
                this.operadorEntidad.fecha_alta = DateTime.Now;
                var _operadoresABC = new OperadoresABC
                {
                    OperadorEntidad = this.operadorEntidad
                };
                var _catalogosABC = new CatalogosABC(_operadoresABC);
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
                var _operadoresABC = new OperadoresABC
                {
                    OperadorEntidad = this.operadorEntidad
                };
                var _catalogosABC = new CatalogosABC(_operadoresABC);
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
                var _operadoresABC = new OperadoresABC();
                var _catalogosABC = new CatalogosABC(_operadoresABC);
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
                var _operadoresABC = new OperadoresABC();
                var _catalogosABC = new CatalogosABC(_operadoresABC);
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
                var _operadoresABC = new OperadoresABC();
                var _catalogosABC = new CatalogosABC(_operadoresABC);
                return _catalogosABC.ListadoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
