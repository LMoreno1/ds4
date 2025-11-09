using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio153
{
    public partial class Suma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            TextBox txt1 = (TextBox)FindControl("txtNumero1");
            TextBox txt2 = (TextBox)FindControl("txtNumero2");
            Label lbl = (Label)FindControl("lblResultado");

            if (txt1 != null && txt2 != null && lbl != null)
            {
                if (double.TryParse(txt1.Text, out double num1) &&
                    double.TryParse(txt2.Text, out double num2))
                {
                    double resultado = num1 + num2;
                    lbl.Text = $"Resultado: {num1} + {num2} = {resultado}";
                }
                else
                {
                    lbl.Text = "Error: Ingrese números válidos";
                }
            }
        }
    }
}