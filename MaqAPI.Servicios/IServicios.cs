using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public interface IServicios<T>
    {
        object Insertar(T pItem);
        bool insertar(List<T> pListado);
        object Actualizar(T pItem);
        bool Actualizar(List<T> pListado);
        bool Eliminar(T pItem);
        bool Eliminar(List<T> pListado);
        IEnumerable<object> Listado();
        object ItemPorId(object id);

        IEnumerable<object> ListadoFiltro(object filtro);

    }
}
