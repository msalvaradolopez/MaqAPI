using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.DTO;

namespace MaqAPI.Interface
{
    public interface IConsultaItem<T>
    {
        T GetItemById(FiltrosDTO pFiltros);
        List<T> GetItemList(FiltrosDTO pFiltros);


    }
}
