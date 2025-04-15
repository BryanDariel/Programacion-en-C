namespace ListBox
{
    partial class ListBox
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstAnimales = new System.Windows.Forms.ListBox();
            this.txtAnimal = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBorrarLista = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblAnimales = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstAnimales
            // 
            this.lstAnimales.FormattingEnabled = true;
            this.lstAnimales.ItemHeight = 15;
            this.lstAnimales.Items.AddRange(new object[] {
            "Perro",
            "Gato",
            "Pollo",
            "Vaca"});
            this.lstAnimales.Location = new System.Drawing.Point(12, 61);
            this.lstAnimales.Name = "lstAnimales";
            this.lstAnimales.Size = new System.Drawing.Size(120, 199);
            this.lstAnimales.TabIndex = 0;
            this.lstAnimales.SelectedIndexChanged += new System.EventHandler(this.lstAnimales_SelectedIndexChanged);
            // 
            // txtAnimal
            // 
            this.txtAnimal.Location = new System.Drawing.Point(148, 18);
            this.txtAnimal.Name = "txtAnimal";
            this.txtAnimal.Size = new System.Drawing.Size(100, 23);
            this.txtAnimal.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(149, 61);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(148, 113);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBorrarLista
            // 
            this.btnBorrarLista.Location = new System.Drawing.Point(148, 164);
            this.btnBorrarLista.Name = "btnBorrarLista";
            this.btnBorrarLista.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarLista.TabIndex = 4;
            this.btnBorrarLista.Text = "Borrar";
            this.btnBorrarLista.UseVisualStyleBackColor = true;
            this.btnBorrarLista.Click += new System.EventHandler(this.btnBorrarLista_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(149, 214);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblAnimales
            // 
            this.lblAnimales.AutoSize = true;
            this.lblAnimales.Location = new System.Drawing.Point(12, 26);
            this.lblAnimales.Name = "lblAnimales";
            this.lblAnimales.Size = new System.Drawing.Size(38, 15);
            this.lblAnimales.TabIndex = 6;
            this.lblAnimales.Text = "label1";
            this.lblAnimales.Click += new System.EventHandler(this.label1_Click);
            // 
            // ListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 317);
            this.Controls.Add(this.lblAnimales);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrarLista);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtAnimal);
            this.Controls.Add(this.lstAnimales);
            this.Name = "ListBox";
            this.Text = "ListBox";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAnimales;
        private TextBox txtAnimal;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnBorrarLista;
        private Button button4;
        private Label lblAnimales;
        private Button btnSalir;
    }
}