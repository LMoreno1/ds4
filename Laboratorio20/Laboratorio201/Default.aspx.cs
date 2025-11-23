using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio201
{
    public partial class Default : Page
    {
        public int Dimension { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGenerarMatriz_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDimension.Text, out int n) && n > 0 && n <= 20)
            {
                Dimension = n;
                GenerarMatriz(n);
                lblError.Text = "";
                pnlMatriz.Visible = true;
            }
            else
            {
                lblError.Text = "Por favor, ingrese un número válido entre 1 y 20.";
                pnlMatriz.Visible = false;
            }
        }

        private void GenerarMatriz(int n)
        {
            tblMatriz.Rows.Clear();

            for (int i = 0; i < n; i++)
            {
                TableRow row = new TableRow();

                for (int j = 0; j < n; j++)
                {
                    TableCell cell = new TableCell();

                    if (i + j == n - 1)
                    {
                        cell.Text = "1";
                        cell.CssClass = "numero-uno";
                    }
                    else
                    {
                        cell.Text = "0";
                        cell.CssClass = "numero-cero";
                    }

                    row.Cells.Add(cell);
                }

                tblMatriz.Rows.Add(row);
            }
        }
    }
}