using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio17
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosProcedimiento();
            }
        }

        private void CargarDatosProcedimiento()
        {
            ConnectionStringSettings conString = ConfigurationManager.ConnectionStrings["ConexionNorthwind"];

            using (SqlConnection conexion = new SqlConnection(conString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SalesByCategory", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = "Seafood";

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        GridV.DataSource = reader;
                        GridV.DataBind();
                    }
                }
            }
        }
    }
}