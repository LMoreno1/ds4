using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio20
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumero.Text, out int numero))
            {
                string tabla = $"<h2>Tabla de multiplicar del {numero}</h2>";
                tabla += "<table border='1'>";

                for (int i = 1; i <= 25; i++)
                {
                    tabla += $"<tr><td>{numero} x {i}</td><td>= {numero * i}</td></tr>";
                }

                tabla += "</table>";
                lblResultado.Text = tabla;
            }
            else
            {
                lblResultado.Text = "Por favor, ingrese un número válido.";
            }
        }
    }
}