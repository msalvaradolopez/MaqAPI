using MaqAPI.Datos.Models;
using MaqAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.DTOMap
{
    public class TableroDTOMap
    {
        public List<TableroDTO> createTableroList(int pagina) {
            
            var _tableroDTO = new List<TableroDTO>();

            using (var db = new MaquinariaEntities()) {


                var renglones = db.parametros.Where(x => x.nombre == "MaxRenglones").Select(x => x.valor).FirstOrDefault();

                var intRenglones = new SqlParameter("@intRenglones", renglones);
                var intPagina = new SqlParameter("@intPagina", pagina);

                _tableroDTO = db.Database
               .SqlQuery<TableroDTO>("spConsultaUbicacionPaginado @intRenglones, @intPagina", intRenglones, intPagina)
               .ToList();
            }

            return _tableroDTO;
        }
    }
}
