using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTO
{
    public class DesvioDTO
    {
        public int idDesvio { get; set; }
        public string numTabulador { get; set; }
        public string area { get; set; }
        public DateTime fecha { get; set; }
        public string idSupervisor { get; set; }
        public string idObra { get; set; }
        public string idOperador { get; set; }
        public string evento { get; set; }
        public bool? estado_prisa { get; set; }
        public bool? estado_frustacion { get; set; }
        public bool? estado_fatiga { get; set; }
        public bool? estado_complacencia { get; set; }
        public bool? error_ojos_no_tarea { get; set; }
        public bool? error_mente_no_tarea { get; set; }
        public bool? error_mala_colocacion { get; set; }
        public bool? error_perdida_equilibrio { get; set; }
        public string observaciones { get; set; }
        public bool? caidas { get; set; }
        public bool? golpes { get; set; }
        public bool? quemaduras { get; set; }
        public bool? asfixia { get; set; }
        public bool? eletrocucion { get; set; }
        public bool? objetos_que_golpean { get; set; }
        public bool? accidentes_vehiculares { get; set; }
        public bool? actitud { get; set; }
        public bool? procedimiento_de_trabajo { get; set; }
        public bool? permiso_de_trabajo { get; set; }
        public bool? e_p_p { get; set; }
        public bool? herremientas_y_equipos { get; set; }
        public bool? posicion_de_las_personas { get; set; }
        public bool? orden_y_limpieza { get; set; }
        public bool? reaccion_de_la_persona { get; set; }
        public string compromiso_establecido { get; set; }
        public string nomSupervisor { get; set; }
        public string nomOperador { get; set; }
        public string nomObra { get; set; }
    }
}
