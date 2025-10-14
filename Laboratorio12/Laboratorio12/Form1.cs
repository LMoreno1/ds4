using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double v = double.Parse(textBox1.Text);
            double t = double.Parse(textBox2.Text);
            Recorrido r = new Recorrido();
            double distancia = r.CalcularDistancia(v, t);
            textBox3.Text = $"{distancia}";
        }
    }
}
