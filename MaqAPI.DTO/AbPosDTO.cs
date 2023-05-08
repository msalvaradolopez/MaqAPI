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
        public bool casco { get; set; }
        public bool lentes { get; set; }
        public bool guantes { get; set; }
        public bool uniforme { get; set; }
        public bool zapatos { get; set; }
        public bool uni_fajado { get; set; }
        public bool tapones { get; set; }
        public bool mascarilla { get; set; }
        public bool careta { get; set; }
        public bool arnes { get; set; }
        public bool polainas { get; set; }
        public bool peto { get; set; }
        public bool gogles { get; set; }
        public bool otros { get; set; }
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
