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
    class UbicacionesMIG : ICatalogosMig
    {
        string strConnPROD = "";
        string strConnDEV = "";

        public UbicacionesMIG()
        {
            strConnPROD = ConfigurationManager.ConnectionStrings["connPROD"].ConnectionString;
            strConnDEV = ConfigurationManager.ConnectionStrings["connDEV"].ConnectionString;
        }
        public bool MigrarCatalogo()
        {
            var _Listado = new List<UbicacionEntidad>();

            using (SqlConnection connPROD = new SqlConnection(strConnPROD))
            {

                try
                {
                    // OBTENER REGISTROS DE PROD

                    SqlCommand strSql = new SqlCommand("SELECT * FROM ubicacion WITH(NOLOCK)", connPROD);
                    strSql.CommandType = CommandType.Text;
                    connPROD.Open();
                    SqlDataReader resultado = strSql.ExecuteReader();

                    while (resultado.Read())
                    {
                        var item = new UbicacionEntidad();
                        item.idEconomico = resultado["idEconomico"] as string;
                        item.idOperador = resultado["idOperador"] as string;
                        item.idObra = resultado["idObra"] as string;
                        item.fecha_alta = Convert.ToDateTime(resultado["fecha_alta"]);
                        item.comentarios = resultado["comentarios"] as string;
                        item.idUsuario = resultado["idUsuario"] as string;
                        item.fecha_ingreso = Convert.ToDateTime(resultado["fecha_ingreso"]);
                        item.hodometro = Convert.ToDecimal(resultado["hodometro"]);
                        if (resultado["odometro"] is string odometro)
                            item.odometro = Convert.ToInt32(odometro);
                        item.sello = resultado["sello"] as string;
                        if (resultado["litros"] is string litros)
                            item.litros = Convert.ToInt32(litros);

                        if (resultado["horometro"] is string horometro)
                            item.horometro = Convert.ToInt32(horometro);
                        item.ventana = resultado["ventana"] as string;
                        

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
                    SqlCommand strSqlDEV = new SqlCommand("INSERT INTO  BITESA.ubicacion (idEconomico, idOperador, idObra, fecha_alta, comentarios, idUsuario, fecha_ingreso, hodometro, odometro, sello, litros, horometro, ventana)" +
                                                       "VALUES(@idEconomico, @idOperador, @idObra, @fecha_alta, @comentarios, @idUsuario, @fecha_ingreso, @hodometro, @odometro, @sello, @litros, @horometro, @ventana)", connDEV);
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
                                strSqlDEV.Parameters.Add(new SqlParameter("@idOperador", item.idOperador));
                                strSqlDEV.Parameters.Add(new SqlParameter("@idObra", item.idObra));
                                strSqlDEV.Parameters.Add(new SqlParameter("@fecha_alta", item.fecha_alta));
                                strSqlDEV.Parameters.Add(new SqlParameter("@comentarios", item.comentarios ?? (object)DBNull.Value));
                                strSqlDEV.Parameters.Add(new SqlParameter("@idUsuario", item.idUsuario));
                                strSqlDEV.Parameters.Add(new SqlParameter("@fecha_ingreso", item.fecha_alta));
                                strSqlDEV.Parameters.Add(new SqlParameter("@hodometro", item.hodometro));
                                strSqlDEV.Parameters.Add(new SqlParameter("@odometro", item.odometro ?? (object)DBNull.Value));
                                strSqlDEV.Parameters.Add(new SqlParameter("@sello", item.sello ?? (object)DBNull.Value));
                                strSqlDEV.Parameters.Add(new SqlParameter("@litros", item.litros ?? (object)DBNull.Value));
                                strSqlDEV.Parameters.Add(new SqlParameter("@horometro", item.horometro ?? (object)DBNull.Value));
                                strSqlDEV.Parameters.Add(new SqlParameter("@ventana", item.ventana ?? (object)DBNull.Value));

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
