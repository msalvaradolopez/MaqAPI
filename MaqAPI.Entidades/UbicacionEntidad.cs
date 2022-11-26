using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Entidades
{
    public class UbicacionEntidad
    {
        public int? idUbicacion { get; set; }
        public string idEconomico { get; set; }
        public string idOperador { get; set; }
        public string idObra { get; set; }
        public DateTime fecha_alta { get; set; }
        public string comentarios { get; set; }
        public string idUsuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public decimal? hodometro { get; set; }
        public int? odometro { get; set; }
        public string sello { get; set; }
        public int? litros { get; set; }
        public int? horometro { get; set; }
        public string ventana { get; set; }

    }
}
