using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Interface
{
    public interface IFormatos<T>
    {
        string getPDF(T pItem);
    }
}
