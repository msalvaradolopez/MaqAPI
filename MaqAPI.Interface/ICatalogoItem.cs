using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.DTO;

namespace MaqAPI.Interface
{
    public interface ICatalogoItem<T>
    {
        T InsertItem(T pItem);
        bool UpdateItem(T pItem);
        bool DeleteItem(T pItem);


    }
}
