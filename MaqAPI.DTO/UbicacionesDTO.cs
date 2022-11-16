using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTO
{
    public class UbicacionesDTO
    {
        public int idUbicacion { get; set; }
        public string idEconomico { get; set; }
        public string equipoNom { get; set; }
        public string idOperador { get; set; }
        public string operadorNom { get; set; }
        public string idObra { get; set; }
        public string obraNom { get; set; }
        public DateTime fecha_alta { get; set; }
        public string comentarios { get; set; }
        public string idUsuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public int hodometro { get; set; }
        public int odometro { get; set; }
        public string sello { get; set; }
        public int litros { get; set; }
        public int horometro { get; set; }
        public string ventana { get; set; }
    }
}
