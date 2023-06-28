using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Interface
{
    public interface IExportaXLSX<T>
    {
        string getXLSX(List<T> pList);
    }
}
