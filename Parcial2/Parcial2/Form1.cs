using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class Form1 : Form
    {
        private double kglb = 2.2046;
        private double lbAkg = 0.4535;
        string connectionString = @"Server=.\sqlexpress;Database=Conversor;TrustServerCertificate=true;Integrated Security=SSPI;";
        public Form1()
        {
            InitializeComponent();
        }

        private void txtLibras_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLibras_Click(object sender, EventArgs e)
        {
            try
            {
                double libras = double.Parse(txtLibras.Text);
                double kilogramos = libras / lbAkg;
                txtLb.Text = kilogramos.ToString("F4");

                GuardarConversion("Libras a Kilogramos", libras, kilogramos);
                CargarConversiones();
            }
            catch
            {
                txtLb.Text = "Error";
            }

        }

        private void txtLb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKilogramos_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKilogramos_Click(object sender, EventArgs e)
        {
            try
            {
                double kilogramos = double.Parse(txtKilogramos.Text);
                double libras = kilogramos * kglb;
                txtKg.Text = libras.ToString("F4");

                GuardarConversion("Kilogramos a Libras", kilogramos, libras);
                CargarConversiones();
            }
            catch
            {
                txtKg.Text = "Error";
            }
        }

        private void txtKg_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarConversiones();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GuardarConversion(string tipo, double entrada, double salida)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Conversiones (TipoConversion, ValorEntrada, ValorSalida) VALUES (@Tipo, @Entrada, @Salida)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tipo", tipo);
                        cmd.Parameters.AddWithValue("@Entrada", entrada);
                        cmd.Parameters.AddWithValue("@Salida", salida);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void CargarConversiones()
        {
            try
            {
                listBox1.Items.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, TipoConversion, ValorEntrada, ValorSalida FROM Conversiones ORDER BY Id ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string tipo = reader.GetString(1);
                                double entrada = reader.GetDouble(2);
                                double salida = reader.GetDouble(3);

                                string texto = $"{id} - {tipo}: {entrada:F4} = {salida:F4}";
                                listBox1.Items.Add(texto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }
    }
}
