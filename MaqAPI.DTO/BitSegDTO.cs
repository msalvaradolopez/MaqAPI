using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Entidades;

namespace MaqAPI.DTO
{
    public class BitSegDTO
    {
        public long idBitacora { get; set; }
        public long docBitacora { get; set; }
        public DateTime fecha { get; set; }
        public string idOperador { get; set; }
        public string idObra { get; set; }
        public string area { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_termino { get; set; }
        public List<BitSegEntidad> ListadoBitSeg { get; set; }
    }
}
