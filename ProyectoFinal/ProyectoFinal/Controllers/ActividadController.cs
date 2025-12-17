using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Http;
using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Controllers
{
    [RoutePrefix("api/actividad")] 
    public class ActividadController : ApiController
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LaborSocialDB"].ConnectionString;

        [HttpGet]
        [Route("")] 
        public IHttpActionResult GetActividades()
        {
            List<Actividad> actividades = new List<Actividad>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, Nombre, Descripcion, Fecha, CupoMaximo, Lugar, Estado 
                               FROM Actividades 
                               ORDER BY Fecha";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    actividades.Add(new Actividad
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        CupoMaximo = (int)reader["CupoMaximo"],
                        Lugar = reader["Lugar"].ToString(),
                        Estado = reader["Estado"].ToString()
                    });
                }
                reader.Close();
            }

            return Ok(actividades);
        }

        [HttpGet]
        [Route("disponibles")] 
        public IHttpActionResult GetActividadesDisponibles()
        {
            List<Actividad> actividades = new List<Actividad>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT a.Id, a.Nombre, a.Descripcion, a.Fecha, a.CupoMaximo, a.Lugar, a.Estado,
                               (a.CupoMaximo - ISNULL((SELECT COUNT(*) FROM Inscripciones i WHERE i.ActividadId = a.Id AND i.Estado = 'Activa'), 0)) as CuposDisponibles
                               FROM Actividades a
                               WHERE a.Estado = 'Disponible' 
                               AND a.Fecha > GETDATE()
                               ORDER BY a.Fecha";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    actividades.Add(new Actividad
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        CupoMaximo = (int)reader["CupoMaximo"],
                        Lugar = reader["Lugar"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        CuposDisponibles = Convert.ToInt32(reader["CuposDisponibles"])
                    });
                }
                reader.Close();
            }

            return Ok(actividades);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetActividad(int id)
        {
            Actividad actividad = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, Nombre, Descripcion, Fecha, CupoMaximo, Lugar, Estado 
                               FROM Actividades 
                               WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    actividad = new Actividad
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        CupoMaximo = (int)reader["CupoMaximo"],
                        Lugar = reader["Lugar"].ToString(),
                        Estado = reader["Estado"].ToString()
                    };
                }
                reader.Close();
            }

            if (actividad == null)
                return NotFound();

            return Ok(actividad);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostActividad([FromBody] Actividad actividad)
        {
            try
            {
                if (actividad == null)
                    return BadRequest("Los datos de la actividad son requeridos");

                if (string.IsNullOrEmpty(actividad.Nombre))
                    return BadRequest("El nombre es requerido");

                if (actividad.CupoMaximo <= 0)
                    return BadRequest("El cupo máximo debe ser mayor a 0");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Actividades (Nombre, Descripcion, Fecha, CupoMaximo, Lugar, Estado) 
                                   VALUES (@Nombre, @Descripcion, @Fecha, @CupoMaximo, @Lugar, @Estado);
                                   SELECT SCOPE_IDENTITY();"; // <- Obtener el ID generado

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", actividad.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", actividad.Descripcion ?? "");
                    command.Parameters.AddWithValue("@Fecha", actividad.Fecha);
                    command.Parameters.AddWithValue("@CupoMaximo", actividad.CupoMaximo);
                    command.Parameters.AddWithValue("@Lugar", actividad.Lugar ?? "");
                    command.Parameters.AddWithValue("@Estado", actividad.Estado ?? "Disponible");

                    connection.Open();
                    var nuevoId = command.ExecuteScalar();

                    return Ok(new
                    {
                        success = true,
                        message = "Actividad creada exitosamente",
                        id = nuevoId
                    });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id:int}")] 
        public IHttpActionResult PutActividad(int id, [FromBody] Actividad actividad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Actividades 
                                   SET Nombre = @Nombre, 
                                       Descripcion = @Descripcion, 
                                       Fecha = @Fecha, 
                                       CupoMaximo = @CupoMaximo, 
                                       Lugar = @Lugar, 
                                       Estado = @Estado
                                   WHERE Id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", actividad.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", actividad.Descripcion ?? "");
                    command.Parameters.AddWithValue("@Fecha", actividad.Fecha);
                    command.Parameters.AddWithValue("@CupoMaximo", actividad.CupoMaximo);
                    command.Parameters.AddWithValue("@Lugar", actividad.Lugar ?? "");
                    command.Parameters.AddWithValue("@Estado", actividad.Estado ?? "Disponible");

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return NotFound();

                    return Ok(new { success = true, message = "Actividad actualizada exitosamente" });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")] 
        public IHttpActionResult DeleteActividad(int id)
        {
            try
            {
    
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
           
                    string checkQuery = @"SELECT COUNT(*) FROM Inscripciones 
                                        WHERE ActividadId = @Id AND Estado = 'Activa'";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    int inscripcionesActivas = (int)checkCommand.ExecuteScalar();

                    if (inscripcionesActivas > 0)
                    {
                        return BadRequest("No se puede eliminar la actividad porque tiene inscripciones activas. Cambie el estado a 'Cancelada' en su lugar.");
                    }

                    string query = @"DELETE FROM Actividades WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return NotFound();

                    return Ok(new { success = true, message = "Actividad eliminada exitosamente" });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}