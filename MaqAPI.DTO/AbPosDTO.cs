using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTO
{
    public class AbPosDTO
    {
        public int idAbordaje { get; set; }
        public DateTime fecha { get; set; }
        public string idSupervisor { get; set; }
        public string idObra { get; set; }
        public string idOperador { get; set; }
        public string riesgo { get; set; }
        public string desvio { get; set; }
        public string casco { get; set; }
        public string lentes { get; set; }
        public string guantes { get; set; }
        public string uniforme { get; set; }
        public string zapatos { get; set; }
        public string uni_fajado { get; set; }
        public string tapones { get; set; }
        public string mascarilla { get; set; }
        public string careta { get; set; }
        public string arnes { get; set; }
        public string polainas { get; set; }
        public string peto { get; set; }
        public string gogles { get; set; }
        public string otros { get; set; }
        public string otro_descrip { get; set; }
        public string act_inseguros { get; set; }
        public string acc_correctiva { get; set; }
        public string cond_inseguras { get; set; }
        public string compromisos { get; set; }
        public string nomSupervisor { get; set; }
        public string nomOperador { get; set; }
        public string nomObra { get; set; }
    }
}
