using MaqAPI.Datos.Interfaz;
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
            return this._objCRUD.Update(pItem);
        }

        public bool Actualizar(List<T> pListado)
        {
            return this._objCRUD.Update(pListado);
        }

        public bool Eliminar(T pItem)
        {
            return this._objCRUD.Delete(pItem);
        }

        public bool Eliminar(List<T> pListado)
        {
            return this._objCRUD.Delete(pListado);
        }

        public bool Insertar(T pItem)
        {
            return this._objCRUD.Insert(pItem);
        }

        public bool insertar(List<T> pListado)
        {
            return this._objCRUD.Insert(pListado);
        }

        public object ItemPorId(object id)
        {
            return this._objCRUD.GetListById(id);
        }

        public IEnumerable<object> Listado()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ListadoFiltro(object filtro)
        {
            return this._objCRUD.GetListFilter(filtro);
        }

        public IEnumerable<object> TableroList(int pagina)
        {
            try
            {

                var _tableroDTOMap = new TableroDTOMap();

                return _tableroDTOMap.createTableroList(pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
