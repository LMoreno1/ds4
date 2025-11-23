using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio202
{
    public partial class Default : Page
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=productos;Trusted_Connection=True;";
        private bool Nuevo
        {
            get { return ViewState["Nuevo"] != null && (bool)ViewState["Nuevo"]; }
            set { ViewState["Nuevo"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigurarEstadoInicial();
            }
        }

        private void ConfigurarEstadoInicial()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            txtBuscarId.Enabled = true;
            btnBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            LimpiarCampos();
            OcultarMensaje();
            Nuevo = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            txtBuscarId.Enabled = false;
            btnBuscar.Enabled = false;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtNombre.Focus();
            Nuevo = true;
            LimpiarCampos();
            OcultarMensaje();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (Nuevo)
                {
                    InsertarRegistro();
                }
                else
                {
                    ActualizarRegistro();
                }
                ConfigurarEstadoInicial();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ConfigurarEstadoInicial();
            MostrarMensaje("Operación cancelada.", "success");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                EliminarRegistro();
                ConfigurarEstadoInicial();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarId.Text))
            {
                BuscarRegistro();
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private void InsertarRegistro()
        {
            string sql = @"INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK) 
                  VALUES (@Nombre, @Precio, @Stock);
                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int nuevoId = Convert.ToInt32(result);
                        MostrarMensaje($"Registro ingresado correctamente ID: {nuevoId}", "success");
                        txtId.Text = nuevoId.ToString();
                    }
                    else
                    {
                        MostrarMensaje("Registro ingresado pero no se pudo obtener el ID", "success");
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al insertar: " + ex.Message, "error");
                }
            }
        }

        private void ActualizarRegistro()
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MostrarMensaje("Error: ID no válido para actualizar", "error");
                return;
            }

            string sql = @"UPDATE LAPTOPS SET NOMBRE=@Nombre, PRECIO=@Precio, STOCK=@Stock 
                  WHERE ID=@Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MostrarMensaje("Registro actualizado correctamente", "success");
                    else
                        MostrarMensaje("No se encontró el registro para actualizar", "error");
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al actualizar: " + ex.Message, "error");
                }
            }
        }

        private void EliminarRegistro()
        {
            string sql = "DELETE FROM LAPTOPS WHERE ID=@Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MostrarMensaje("Registro eliminado correctamente", "success");
                    else
                        MostrarMensaje("No se encontró el registro para eliminar", "error");
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al eliminar: " + ex.Message, "error");
                }
            }
        }

        private void BuscarRegistro()
        {
            string sql = "SELECT * FROM LAPTOPS WHERE ID=@Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtBuscarId.Text));

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnEliminar.Enabled = true;
                        txtBuscarId.Enabled = false;
                        btnBuscar.Enabled = false;
                        txtNombre.Enabled = true;
                        txtPrecio.Enabled = true;
                        txtStock.Enabled = true;

                        txtId.Text = reader["ID"].ToString();
                        txtNombre.Text = reader["NOMBRE"].ToString();
                        txtPrecio.Text = reader["PRECIO"].ToString();
                        txtStock.Text = reader["STOCK"].ToString();
                        Nuevo = false;
                        OcultarMensaje();
                    }
                    else
                    {
                        MostrarMensaje("Ningún registro encontrado con el ID ingresado", "error");
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al buscar: " + ex.Message, "error");
                }
            }
            txtBuscarId.Text = "";
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(txtStock.Text))
            {
                MostrarMensaje("Todos los campos son obligatorios", "error");
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MostrarMensaje("El precio debe ser un número válido mayor a 0", "error");
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MostrarMensaje("El stock debe ser un número entero válido", "error");
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            pnlMessage.Visible = true;
            lblMessage.Text = mensaje;
            pnlMessage.CssClass = "message " + tipo;
        }

        private void OcultarMensaje()
        {
            pnlMessage.Visible = false;
        }
    }
}