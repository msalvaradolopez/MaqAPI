using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Entidades
{
    public class MaquinariaEntidad
    {
        public string idEconomico { get; set; }
        public string Tipo { get; set; }
        public string estatus { get; set; }
        public DateTime fecha_alta { get; set; }
    }
}
