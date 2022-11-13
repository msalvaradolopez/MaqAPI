using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Entidades
{
    public class OperadorEntidad
    {
        public string idOperador { get; set; }
        public string Nombre { get; set; }
        public string estatus { get; set; }
        public DateTime fecha_alta { get; set; }
        public string categoria { get; set; }
        public string passw { get; set; }
    }
}
