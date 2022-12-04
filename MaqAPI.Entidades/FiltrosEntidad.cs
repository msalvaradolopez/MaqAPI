using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Entidades
{
    public class FiltrosEntidad
    {
        public int idUbicacion { get; set; }
        public string idEconomico { get; set; }
        public string idOperador { get; set; }
        public string idObra { get; set; }
        public DateTime fecha_alta { get; set; }
        public string estatus { get; set; }
        public string buscar { get; set; }
        public string idUsuario { get; set; }
        public int pagina { get; set; }
        public long idBitacora { get; set; }
        public long docBitacora { get; set; }
    }
}
