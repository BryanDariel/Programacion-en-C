using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Historial_de_Parchis
{
    public partial class Historial : Form
    {

        public int NJugada = 0;

        public Historial()
        {
            InitializeComponent();
        }

        private void btnRojo_Click(object sender, EventArgs e)
        {
            LanzarDados();
            NJugada++;
        }

        private void btnAmarillo_Click(object sender, EventArgs e)
        {
            LanzarDados();
            NJugada++;
        }

        private void btnVerde_Click(object sender, EventArgs e)
        {
            LanzarDados();
            NJugada++;
        }

        private void btnAzul_Click(object sender, EventArgs e)
        {
            LanzarDados();
            NJugada++;
        }

        public void LanzarDados()
        {
            Random rnd = new Random();

            int Num1 = rnd.Next(1, 7);
            int Num2 = rnd.Next(1, 7);
            int Pasos = 0;

            if(Num1 == 6)
            {
                Num1 = 12;
            }

            if(Num2 == 6)
            {
                Num2 = 12;
            }

            if (Num1 != Num2)
            {
                Pasos = Num1 + Num2;
                txtResultado.Text = "Se ha conesguido: " + Pasos;
            }

            if (Num1 == Num2)
            {
                Pasos = Num1 + Num2;
                txtResultado.Text = "Se ha conseguido un doble: " + Pasos;
            }
        }
    }
}
