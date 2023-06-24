using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTO
{
    public class FiltrosDTO
    {
        public int idInspeccion { get; set; }
        public int docInspeccion { get; set; }
        public DateTime fecha { get; set; }
        public string idSupervisor { get; set; }
        public string idEconomico { get; set; }
        public string idOperador { get; set; }
        public string idResponsableMtto { get; set; }
        public string turno { get; set; }
        public string buscar { get; set; }
        public int mes { get; set; }
        public int anno { get; set; }
        public int dia { get; set; }
        public int idAbordaje { get; set; }
        public int idDesvio { get; set; }
    }
}
