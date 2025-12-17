using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Http;
using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Controllers
{
    public class ReporteController : ApiController
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LaborSocialDB"].ConnectionString;

        [HttpGet]
        [Route("estudiantes")]
        public IHttpActionResult GetReporteEstudiantes()
        {
            try
            {
                var reporte = new List<object>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Estudiantes por carrera
                    string query = @"
                        SELECT 
                            Carrera,
                            COUNT(*) as Cantidad,
                            AVG(Semestre) as PromedioSemestre
                        FROM Estudiantes 
                        GROUP BY Carrera 
                        ORDER BY Cantidad DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reporte.Add(new
                            {
                                Carrera = reader["Carrera"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PromedioSemestre = Convert.ToDecimal(reader["PromedioSemestre"]).ToString("F1")
                            });
                        }
                    }
                }

                return Ok(reporte);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("inscripciones-mensuales")]
        public IHttpActionResult GetInscripcionesMensuales()
        {
            try
            {
                var datos = new List<object>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            MONTH(FechaRegistro) as Mes,
                            COUNT(*) as Cantidad
                        FROM Estudiantes
                        WHERE YEAR(FechaRegistro) = YEAR(GETDATE())
                        GROUP BY MONTH(FechaRegistro)
                        ORDER BY Mes";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datos.Add(new
                            {
                                Mes = Convert.ToInt32(reader["Mes"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"])
                            });
                        }
                    }
                }

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("estadisticas-generales")]
        public IHttpActionResult GetEstadisticasGenerales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            (SELECT COUNT(*) FROM Estudiantes) as TotalEstudiantes,
                            (SELECT COUNT(DISTINCT Carrera) FROM Estudiantes) as TotalCarreras,
                            (SELECT AVG(Semestre) FROM Estudiantes) as PromedioSemestre,
                            (SELECT COUNT(*) FROM Actividades WHERE Estado = 'Activa') as ActividadesActivas,
                            (SELECT COUNT(*) FROM Inscripciones WHERE YEAR(Fecha) = YEAR(GETDATE())) as InscripcionesAnuales";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var estadisticas = new
                            {
                                TotalEstudiantes = reader["TotalEstudiantes"] != DBNull.Value ? Convert.ToInt32(reader["TotalEstudiantes"]) : 0,
                                TotalCarreras = reader["TotalCarreras"] != DBNull.Value ? Convert.ToInt32(reader["TotalCarreras"]) : 0,
                                PromedioSemestre = reader["PromedioSemestre"] != DBNull.Value ? Convert.ToDecimal(reader["PromedioSemestre"]).ToString("F1") : "0.0",
                                ActividadesActivas = reader["ActividadesActivas"] != DBNull.Value ? Convert.ToInt32(reader["ActividadesActivas"]) : 0,
                                InscripcionesAnuales = reader["InscripcionesAnuales"] != DBNull.Value ? Convert.ToInt32(reader["InscripcionesAnuales"]) : 0
                            };

                            return Ok(estadisticas);
                        }
                    }
                }

                return Ok(new
                {
                    TotalEstudiantes = 0,
                    TotalCarreras = 0,
                    PromedioSemestre = "0.0",
                    ActividadesActivas = 0,
                    InscripcionesAnuales = 0
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}