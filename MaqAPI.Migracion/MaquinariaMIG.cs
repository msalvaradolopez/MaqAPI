using MaqAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Migracion
{
    public class MaquinariaMIG : ICatalogosMig
    {
        string strConnPROD = "";
        string strConnDEV = "";

        public MaquinariaMIG()
        {
            strConnPROD = ConfigurationManager.ConnectionStrings["connPROD"].ConnectionString;
            strConnDEV = ConfigurationManager.ConnectionStrings["connDEV"].ConnectionString;
        }

        public bool MigrarCatalogo()
        {
            var _Listado = new List<MaquinariaEntidad>();

            using (SqlConnection connPROD = new SqlConnection(strConnPROD))
            {

                try
                {
                    // OBTENER REGISTROS DE PROD

                    SqlCommand strSql = new SqlCommand("SELECT * FROM maquinaria WITH(NOLOCK)", connPROD);
                    strSql.CommandType = CommandType.Text;
                    connPROD.Open();
                    SqlDataReader resultado = strSql.ExecuteReader();

                    while (resultado.Read())
                    {
                        var item = new MaquinariaEntidad
                        {
                            idEconomico = resultado["idEconomico"] as string,
                            Tipo = resultado["Tipo"] as string,
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
                    SqlCommand strSqlDEV = new SqlCommand("INSERT INTO  BITESA.maquinaria (idEconomico, Tipo, estatus, fecha_alta)" +
                                                       "VALUES(@idEconomico, @Tipo, @estatus, @fecha_alta)", connDEV);
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
                                strSqlDEV.Parameters.Add(new SqlParameter("@idEconomico", item.idEconomico));
                                strSqlDEV.Parameters.Add(new SqlParameter("@Tipo", item.Tipo));
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
