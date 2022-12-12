//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaqAPI.Datos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bitseg
    {
        public long idBitacora { get; set; }
        public long docBitacora { get; set; }
        public System.DateTime fecha { get; set; }
        public string idSupervisor { get; set; }
        public string idObra { get; set; }
        public string area { get; set; }
        public System.DateTime hora_inicio { get; set; }
        public System.DateTime hora_termino { get; set; }
        public string idEconomico { get; set; }
        public string idOperador { get; set; }
        public string actividad { get; set; }
        public string pto_exacto { get; set; }
        public string chequeo_medico { get; set; }
        public string chequeo_medico_obs { get; set; }
        public string checklist_maq_equip { get; set; }
        public string checklist_maq_equip_obs { get; set; }
        public string apr { get; set; }
        public string apr_obs { get; set; }
        public string permiso_instancia { get; set; }
        public string permiso_instancia_obs { get; set; }
        public string dc3 { get; set; }
        public string dc3_obs { get; set; }
        public string extintor { get; set; }
        public string extintor_obs { get; set; }
        public string kit_antiderrames { get; set; }
        public string kit_antiderrames_obs { get; set; }
        public string platica_5min { get; set; }
        public string platica_5min_obs { get; set; }
        public string epp { get; set; }
        public string epp_obs { get; set; }
        public string otro { get; set; }
        public string otro_descrip { get; set; }
        public string otro_obs { get; set; }
        public string idUsuario { get; set; }
        public string horaInico { get; set; }
        public string minutosInicio { get; set; }
        public string horaTermino { get; set; }
        public string minutosTermino { get; set; }
        public string horaInicio { get; set; }
    
        public virtual maquinaria maquinaria { get; set; }
        public virtual obras obras { get; set; }
        public virtual operadores operadores { get; set; }
        public virtual operadores operadores1 { get; set; }
        public virtual operadores operadores2 { get; set; }
    }
}
