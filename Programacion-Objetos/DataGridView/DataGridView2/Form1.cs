using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView2 {

    public partial class DataGridView : Form{

        private int  n = 0;
        public DataGridView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){

        }

        private void btnAdicionar_Click(object sender, EventArgs e){

            //Añadimos nuevo renglon
            int n = dgvProductos.Rows.Add();

            //Colocamos la informacion

            dgvProductos.Rows[n].Cells[0].Value = txtCodigo.Text;
            dgvProductos.Rows[n].Cells[1].Value = txtNombre.Text;
            dgvProductos.Rows[n].Cells[2].Value = txtPrecio.Text;

            //Limpiar los txt
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e){

            n = e.RowIndex;

            if (n != -1)
            {
                lblInformacion.Text = (string)dgvProductos.Rows[n].Cells[1].Value;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(n != -1){

                dgvProductos.Rows.RemoveAt(n);
            }
        }
    }
}
