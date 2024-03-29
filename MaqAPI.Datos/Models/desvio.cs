//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaqAPI.Datos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class desvio
    {
        public int idDesvio { get; set; }
        public string numTabulador { get; set; }
        public string area { get; set; }
        public System.DateTime fecha { get; set; }
        public string idSupervisor { get; set; }
        public string idObra { get; set; }
        public string idOperador { get; set; }
        public string evento { get; set; }
        public Nullable<bool> estado_prisa { get; set; }
        public Nullable<bool> estado_frustacion { get; set; }
        public Nullable<bool> estado_fatiga { get; set; }
        public Nullable<bool> estado_complacencia { get; set; }
        public Nullable<bool> error_ojos_no_tarea { get; set; }
        public Nullable<bool> error_mente_no_tarea { get; set; }
        public Nullable<bool> error_mala_colocacion { get; set; }
        public Nullable<bool> error_perdida_equilibrio { get; set; }
        public string observaciones { get; set; }
        public Nullable<bool> caidas { get; set; }
        public Nullable<bool> golpes { get; set; }
        public Nullable<bool> quemaduras { get; set; }
        public Nullable<bool> asfixia { get; set; }
        public Nullable<bool> eletrocucion { get; set; }
        public Nullable<bool> objetos_que_golpean { get; set; }
        public Nullable<bool> accidentes_vehiculares { get; set; }
        public Nullable<bool> actitud { get; set; }
        public Nullable<bool> procedimiento_de_trabajo { get; set; }
        public Nullable<bool> permiso_de_trabajo { get; set; }
        public Nullable<bool> e_p_p { get; set; }
        public Nullable<bool> herremientas_y_equipos { get; set; }
        public Nullable<bool> posicion_de_las_personas { get; set; }
        public Nullable<bool> orden_y_limpieza { get; set; }
        public Nullable<bool> reaccion_de_la_persona { get; set; }
        public string compromiso_establecido { get; set; }
    
        public virtual obras obras { get; set; }
        public virtual operadores operadores { get; set; }
        public virtual operadores operadores1 { get; set; }
    }
}
