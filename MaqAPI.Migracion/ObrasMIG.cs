using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Datos;
using MaqAPI.Datos.Catalogos;
using MaqAPI.Servicios;
using MaqAPI.Entidades;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MaqAPI.Migracion
{
    public class ObrasMIG : ICatalogosMig
    {

        string strConnPROD = "";
        string strConnDEV = "";

        public ObrasMIG() {
            strConnPROD = ConfigurationManager.ConnectionStrings["connPROD"].ConnectionString;
            strConnDEV = ConfigurationManager.ConnectionStrings["connDEV"].ConnectionString;
        }

        public bool MigrarCatalogo()
        {

            var _Listado = new List<ObraEntidad>();

            using (SqlConnection connPROD = new SqlConnection(strConnPROD)) {

                try
                {
                    // OBTENER REGISTROS DE PROD

                    SqlCommand strSql = new SqlCommand("SELECT * FROM obras WITH(NOLOCK)", connPROD);
                    strSql.CommandType = CommandType.Text;
                    connPROD.Open();
                    SqlDataReader resultado = strSql.ExecuteReader();

                    while (resultado.Read())
                    {
                        var item = new ObraEntidad
                        {
                            idObra = resultado["idObra"] as string,
                            Nombre = resultado["Nombre"] as string,
                            estatus = resultado["estatus"] as string,
                            fecha_alta = Convert.ToDateTime(resultado["fecha_alta"])
                        };

                        _Listado.Add(item);
                    }
                    resultado.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            using (SqlConnection connDEV = new SqlConnection(strConnDEV))
            {

                try
                {
                    // INSERTAR REGISTROS DEV
                    SqlCommand strSqlDEV = new SqlCommand("INSERT INTO  BITESA.obras (idObra, Nombre, estatus, fecha_alta)" +
                                                       "VALUES(@idObra, @Nombre, @estatus, @fecha_alta)", connDEV);
                    strSqlDEV.CommandType = CommandType.Text;

                    connDEV.Open();
                    using (SqlTransaction trans = connDEV.BeginTransaction())
                    {
                        try
                        {

                            strSqlDEV.Transaction = trans;

                            _Listado.ForEach(item =>
                            {
                                strSqlDEV.Parameters.Clear();
                                strSqlDEV.Parameters.Add(new SqlParameter("@idObra", item.idObra));
                                strSqlDEV.Parameters.Add(new SqlParameter("@Nombre", item.Nombre));
                                strSqlDEV.Parameters.Add(new SqlParameter("@estatus", item.estatus));
                                strSqlDEV.Parameters.Add(new SqlParameter("@fecha_alta", item.fecha_alta));
                                strSqlDEV.ExecuteNonQuery();
                            });
                            
                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                        
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return true;

        }    
                
    }
}
