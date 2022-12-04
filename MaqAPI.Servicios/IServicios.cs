using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public interface IServicios
    {
        bool Agregar();
        bool Actualizar();
        bool Eliminar();
        IEnumerable<object> Listado();
        object ListadoPorId(object id);

        IEnumerable<object> ListadoFiltro(object filtro);

    }
}
