using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Datos.Interfaz
{
    public interface IConexion
    {
        Boolean Insert();

        Boolean Update();

        Boolean Delete();

        IEnumerable<object> GetListAll();

        object GetListById(object id);
    }
}
