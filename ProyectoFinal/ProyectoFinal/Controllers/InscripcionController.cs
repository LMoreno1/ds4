using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Http;
using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Controllers
{
    public class InscripcionController : ApiController
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LaborSocialDB"].ConnectionString;

        [HttpGet]
        public IHttpActionResult GetInscripciones()
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT i.Id, i.EstudianteId, i.ActividadId, i.FechaInscripcion, i.Estado,
                               e.Nombre as EstudianteNombre, a.Nombre as ActividadNombre
                               FROM Inscripciones i
                               INNER JOIN Estudiantes e ON i.EstudianteId = e.Id
                               INNER JOIN Actividades a ON i.ActividadId = a.Id
                               ORDER BY i.FechaInscripcion DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    inscripciones.Add(new Inscripcion
                    {
                        Id = (int)reader["Id"],
                        EstudianteId = (int)reader["EstudianteId"],
                        ActividadId = (int)reader["ActividadId"],
                        Estado = reader["Estado"].ToString(),
                        Estudiante = new Estudiante { Nombre = reader["EstudianteNombre"].ToString() },
                        Actividad = new Actividad { Nombre = reader["ActividadNombre"].ToString() }
                    });
                }
                reader.Close();
            }

            return Ok(inscripciones);
        }

        // POST: api/Inscripcion
        [HttpPost]
        public IHttpActionResult PostInscripcion([FromBody] Inscripcion inscripcion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = @"SELECT COUNT(*) FROM Inscripciones 
                                        WHERE EstudianteId = @EstudianteId 
                                        AND ActividadId = @ActividadId 
                                        AND Estado = 'Activa'";

                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@EstudianteId", inscripcion.EstudianteId);
                    checkCommand.Parameters.AddWithValue("@ActividadId", inscripcion.ActividadId);

                    connection.Open();
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                        return BadRequest("El estudiante ya está inscrito en esta actividad");

                    string cuposQuery = @"SELECT (a.CupoMaximo - ISNULL((SELECT COUNT(*) FROM Inscripciones i 
                                      WHERE i.ActividadId = a.Id AND i.Estado = 'Activa'), 0)) as CuposDisponibles
                                      FROM Actividades a WHERE a.Id = @ActividadId";

                    SqlCommand cuposCommand = new SqlCommand(cuposQuery, connection);
                    cuposCommand.Parameters.AddWithValue("@ActividadId", inscripcion.ActividadId);
                    int cuposDisponibles = (int)cuposCommand.ExecuteScalar();

                    if (cuposDisponibles <= 0)
                        return BadRequest("No hay cupos disponibles para esta actividad");

                    string insertQuery = @"INSERT INTO Inscripciones (EstudianteId, ActividadId, FechaInscripcion, Estado) 
                                         VALUES (@EstudianteId, @ActividadId, @FechaInscripcion, @Estado)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@EstudianteId", inscripcion.EstudianteId);
                    insertCommand.Parameters.AddWithValue("@ActividadId", inscripcion.ActividadId);
                    insertCommand.Parameters.AddWithValue("@FechaInscripcion", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@Estado", "Activa");

                    insertCommand.ExecuteNonQuery();

                    return Ok("Inscripción realizada exitosamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteInscripcion(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Inscripciones SET Estado = 'Cancelada' WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                    return NotFound();

                return Ok("Inscripción cancelada exitosamente");
            }
        }

        [HttpGet]
        [Route("api/Inscripcion/Estudiante/{estudianteId}")]
        public IHttpActionResult GetInscripcionesPorEstudiante(int estudianteId)
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT i.Id, i.EstudianteId, i.ActividadId, i.FechaInscripcion, i.Estado,
                               a.Nombre as ActividadNombre, a.Fecha, a.Lugar
                               FROM Inscripciones i
                               INNER JOIN Actividades a ON i.ActividadId = a.Id
                               WHERE i.EstudianteId = @EstudianteId AND i.Estado = 'Activa'
                               ORDER BY a.Fecha";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EstudianteId", estudianteId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    inscripciones.Add(new Inscripcion
                    {
                        Id = (int)reader["Id"],
                        EstudianteId = (int)reader["EstudianteId"],
                        ActividadId = (int)reader["ActividadId"],
                        Estado = reader["Estado"].ToString(),
                        Actividad = new Actividad
                        {
                            Nombre = reader["ActividadNombre"].ToString(),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Lugar = reader["Lugar"].ToString()
                        }
                    });
                }
                reader.Close();
            }

            return Ok(inscripciones);
        }
    }
}