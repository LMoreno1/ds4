using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Controllers
{
    [RoutePrefix("api/estudiante")]
    public class EstudianteController : ApiController
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LaborSocialDB"].ConnectionString;

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEstudiantes()
        {
            try
            {
                List<Estudiante> estudiantes = new List<Estudiante>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Codigo, Nombre, Email, Carrera, Semestre FROM Estudiantes ORDER BY Nombre";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        estudiantes.Add(new Estudiante
                        {
                            Id = (int)reader["Id"],
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Carrera = reader["Carrera"].ToString(),
                            Semestre = (int)reader["Semestre"],
                        });
                    }
                    reader.Close();
                }

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetEstudiante(int id)
        {
            try
            {
                Estudiante estudiante = null;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Codigo, Nombre, Email, Carrera, Semestre FROM Estudiantes WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        estudiante = new Estudiante
                        {
                            Id = (int)reader["Id"],
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Carrera = reader["Carrera"].ToString(),
                            Semestre = (int)reader["Semestre"],
                        };
                    }
                    reader.Close();
                }

                if (estudiante == null)
                    return NotFound();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("estadisticas")]
        public IHttpActionResult GetEstadisticas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            COUNT(*) as TotalEstudiantes,
                            COUNT(DISTINCT Carrera) as TotalCarreras,
                            AVG(Semestre) as PromedioSemestre
                        FROM Estudiantes";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var estadisticas = new
                        {
                            TotalEstudiantes = Convert.ToInt32(reader["TotalEstudiantes"]),
                            TotalCarreras = Convert.ToInt32(reader["TotalCarreras"]),
                            PromedioSemestre = reader["PromedioSemestre"] != DBNull.Value ?
                                             Convert.ToDouble(reader["PromedioSemestre"]).ToString("F1") : "0.0"
                        };

                        return Ok(estadisticas);
                    }

                    return Ok(new { TotalEstudiantes = 0, TotalCarreras = 0, PromedioSemestre = "0.0" });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                if (estudiante == null)
                    return BadRequest("El estudiante no puede ser nulo");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM Estudiantes WHERE Codigo = @Codigo";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@Codigo", estudiante.Codigo);

                    connection.Open();
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                        return BadRequest("Ya existe un estudiante con ese código");

                    string query = @"INSERT INTO Estudiantes (Codigo, Nombre, Email, Carrera, Semestre) 
                                   VALUES (@Codigo, @Nombre, @Email, @Carrera, @Semestre);
                                   SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Codigo", estudiante.Codigo);
                    command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    command.Parameters.AddWithValue("@Email", estudiante.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Carrera", estudiante.Carrera);
                    command.Parameters.AddWithValue("@Semestre", estudiante.Semestre);

                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    estudiante.Id = newId;

                    return CreatedAtRoute("DefaultApi", new { id = estudiante.Id }, estudiante);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult PutEstudiante(int id, [FromBody] Estudiante estudiante)
        {
            try
            {
                if (estudiante == null || estudiante.Id != id)
                    return BadRequest("ID inválido");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM Estudiantes WHERE Id = @Id";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                        return NotFound();

                    string checkCodigoQuery = "SELECT COUNT(*) FROM Estudiantes WHERE Codigo = @Codigo AND Id != @Id";
                    SqlCommand checkCodigoCmd = new SqlCommand(checkCodigoQuery, connection);
                    checkCodigoCmd.Parameters.AddWithValue("@Codigo", estudiante.Codigo);
                    checkCodigoCmd.Parameters.AddWithValue("@Id", id);

                    int codigoCount = (int)checkCodigoCmd.ExecuteScalar();
                    if (codigoCount > 0)
                        return BadRequest("Ya existe otro estudiante con ese código");

                    string query = @"UPDATE Estudiantes SET 
                                   Codigo = @Codigo,
                                   Nombre = @Nombre,
                                   Email = @Email,
                                   Carrera = @Carrera,
                                   Semestre = @Semestre
                                   WHERE Id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Codigo", estudiante.Codigo);
                    command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    command.Parameters.AddWithValue("@Email", estudiante.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Carrera", estudiante.Carrera);
                    command.Parameters.AddWithValue("@Semestre", estudiante.Semestre);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return Ok(estudiante);
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteEstudiante(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM Estudiantes WHERE Id = @Id";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                        return NotFound();

                    string query = "DELETE FROM Estudiantes WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return Ok(new { success = true, message = "Estudiante eliminado correctamente" });
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("buscar")]
        public IHttpActionResult BuscarEstudiantes([FromUri] string termino)
        {
            try
            {
                if (string.IsNullOrEmpty(termino))
                    return BadRequest("Término de búsqueda requerido");

                List<Estudiante> estudiantes = new List<Estudiante>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT Id, Codigo, Nombre, Email, Carrera, Semestre, FechaRegistro 
                                   FROM Estudiantes 
                                   WHERE Codigo LIKE @Termino OR 
                                         Nombre LIKE @Termino OR 
                                         Email LIKE @Termino OR 
                                         Carrera LIKE @Termino
                                   ORDER BY Nombre";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Termino", "%" + termino + "%");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        estudiantes.Add(new Estudiante
                        {
                            Id = (int)reader["Id"],
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Carrera = reader["Carrera"].ToString(),
                            Semestre = (int)reader["Semestre"],
                        });
                    }
                    reader.Close();
                }

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("carrera/{carrera}")]
        public IHttpActionResult GetEstudiantesPorCarrera(string carrera)
        {
            try
            {
                List<Estudiante> estudiantes = new List<Estudiante>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT Id, Codigo, Nombre, Email, Carrera, Semestre, FechaRegistro 
                                   FROM Estudiantes 
                                   WHERE Carrera = @Carrera
                                   ORDER BY Nombre";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carrera", carrera);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        estudiantes.Add(new Estudiante
                        {
                            Id = (int)reader["Id"],
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Carrera = reader["Carrera"].ToString(),
                            Semestre = (int)reader["Semestre"],
                        });
                    }
                    reader.Close();
                }

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}