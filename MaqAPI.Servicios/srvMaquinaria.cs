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
    public class srvMaquinaria : IServiciosCatalogos
    {
        public MaquinariaEntidad maquinariaEntidad { get; set; }
        public bool Actualizar()
        {
            throw new NotImplementedException();
        }

        public bool Agregar()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
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
