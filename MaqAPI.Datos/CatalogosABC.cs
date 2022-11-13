using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Datos.Catalogos;
using MaqAPI.Datos.Interfaz;

namespace MaqAPI.Datos
{
    public class CatalogosABC
    {
        private IConexion _conexion;

        public CatalogosABC(IConexion conexion)
        {
            this._conexion = conexion;
        }

        public void Nuevo()
        {
            try
            {
                _conexion.Insert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Actualizar()
        {
            try
            {
                _conexion.Update();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                _conexion.Delete();
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
                return _conexion.GetListAll();
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
                return _conexion.GetListById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
