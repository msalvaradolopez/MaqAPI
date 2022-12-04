using MaqAPI.Datos;
using MaqAPI.Datos.Operaciones;
using MaqAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public class srvBitSeg : IServicios
    {
        public BitSegEntidad bitSegEntidad { get; set; }
        public bool Actualizar()
        {
            try
            {
                var _BitSegABC = new BitSegABC
                {
                    bitSegEntidad = this.bitSegEntidad
                };
                var _catalogosABC = new CatalogosABC(_BitSegABC);
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
                var _srvObras = new srvObras();
                var _svrOPeradores = new srvOperadores();
                var _svrMaquinaria = new srvMaquinaria();

                if (_svrMaquinaria.ListadoPorId(this.bitSegEntidad.idEconomico) == null)
                    throw new Exception("Id Obra no existe.");

                if (_srvObras.ListadoPorId(this.bitSegEntidad.idObra) == null)
                    throw new Exception("Id Equipo no existe.");

                if (_svrOPeradores.ListadoPorId(this.bitSegEntidad.idOperador) == null)
                    throw new Exception("Id operador no existe.");

                this.bitSegEntidad.fecha = DateTime.Now;

                var _BitSegABC = new BitSegABC
                {
                    bitSegEntidad = this.bitSegEntidad
                };
                var _catalogosABC = new CatalogosABC(_BitSegABC);
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
                var _BitSegABC = new BitSegABC
                {
                    bitSegEntidad = this.bitSegEntidad
                };
                var _catalogosABC = new CatalogosABC(_BitSegABC);
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
            throw new NotImplementedException();
        }

        public IEnumerable<object> ListadoFiltro(object filtro)
        {
            try
            {
                var _BitSegABC = new BitSegABC();
                var _catalogosABC = new CatalogosABC(_BitSegABC);

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
                var _BitSegABC = new BitSegABC();
                var _catalogosABC = new CatalogosABC(_BitSegABC);
                return _catalogosABC.ListadoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
