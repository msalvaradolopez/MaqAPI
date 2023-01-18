using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTO
{
    public class InsPecDTO
    {
        public int idInspeccion { get; set; }
        public int docInspeccion { get; set; }
        public DateTime fecha { get; set; }
        public string idSupervisor { get; set; }
        public string idEconomico { get; set; }
        public string idOperador { get; set; }
        public string turno { get; set; }
        public int? horometro { get; set; }
        public string idResponsableMtto { get; set; }
        public string frenos { get; set; }
        public string frenos_obs { get; set; }
        public string alarma_rev { get; set; }
        public string alarma_rev_obs { get; set; }
        public string nivel_aceite { get; set; }
        public string nivel_aceite_obs { get; set; }
        public string motor { get; set; }
        public string motor_obs { get; set; }
        public string transmision { get; set; }
        public string transmision_obs { get; set; }
        public string fugas_aceite { get; set; }
        public string fugas_aceite_obs { get; set; }
        public string nivel_agua { get; set; }
        public string nivel_agua_obs { get; set; }
        public string extinguidor { get; set; }
        public string extinguidor_obs { get; set; }
        public string luces { get; set; }
        public string luces_obs { get; set; }
        public string torreta { get; set; }
        public string torreta_obs { get; set; }
        public string neumaticos { get; set; }
        public string neumaticos_obs { get; set; }
        public string pernos_bujes { get; set; }
        public string pernos_bujes_obs { get; set; }
        public string direccion { get; set; }
        public string direccion_obs { get; set; }
        public string espejos_retrovisores { get; set; }
        public string espejos_retrovisores_obs { get; set; }
        public string claxon { get; set; }
        public string claxon_obs { get; set; }
        public string cinturon_seguridad { get; set; }
        public string cinturon_seguridad_obs { get; set; }
    }
}
