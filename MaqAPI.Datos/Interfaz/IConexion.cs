using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Datos.Interfaz
{
    public interface IConexion<T>
    {
        object Insert(T pItem);

        Boolean Insert(List<T> pList);

        Boolean Update(T pItem);
        Boolean Update(List<T> pList);

        Boolean Delete(T pItem);
        Boolean Delete(List<T> pList);

        IEnumerable<object> GetListAll();

        object GetListById(object id);

        IEnumerable<object> GetListFilter(object filtro);
    }
}
