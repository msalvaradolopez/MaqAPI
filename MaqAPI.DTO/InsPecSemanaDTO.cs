using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTO
{
    public class InsPecSemanaDTO
    {
        public string concepto { get; set; }
        public string lunes { get; set; }
        public string martes { get; set; }
        public string miercoles { get; set; }
        public string jueves { get; set; }
        public string viernes { get; set; }
        public string sabado { get; set; }
        public string domingo { get; set; }
        public string observaciones { get; set; }
    }
}
