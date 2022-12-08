using MaqAPI.Datos.Interfaz;
using MaqAPI.Datos.Operaciones;
using MaqAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public class srvCRUD<T> : IServicios<T>
    {
        private IConexion<T> _objCRUD;
        public srvCRUD(tipoCRUD pCRUDS)
        {
            var srvFactoryCRUD = new srvFactoryCRUD();
            this._objCRUD = srvFactoryCRUD.srvFabrica(pCRUDS) as IConexion<T>;
        }

        public bool Actualizar(T pItem)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(List<T> pListado)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(T pItem)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(List<T> pListado)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(T pItem)
        {
            this._objCRUD.Insert(pItem);
            return true;
        }

        public bool insertar(List<T> pListado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Listado()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ListadoFiltro(object filtro)
        {
            throw new NotImplementedException();
        }

        public object ListadoPorId(object id)
        {
            throw new NotImplementedException();
        }
    }
}
