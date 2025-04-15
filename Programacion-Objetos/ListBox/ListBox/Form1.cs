namespace ListBox
{
    public partial class ListBox : Form
    {
        public ListBox()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Otra forma de agregar elementos es por codigo:
            lstAnimales.Items.Add("Conejo");
            lstAnimales.Items.Add("Toro");
        }

        private void lstAnimales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            lstAnimales.Items.Add(txtAnimal.Text);

            txtAnimal.Text = String.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Comprueba si el elemento esta seleccionado, si es asi, lo quita
            if (lstAnimales.SelectedIndex != -1)
                lstAnimales.Items.RemoveAt(lstAnimales.SelectedIndex);

        }

        private void btnBorrarLista_Click(object sender, EventArgs e)
        {
            lstAnimales.Items.Clear();
        }
    }
}