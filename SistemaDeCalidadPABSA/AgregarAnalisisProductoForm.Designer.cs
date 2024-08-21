namespace SistemaDeCalidadPABSA
{
    partial class AgregarAnalisisProductoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblProducto = new Label();
            lblEspecie = new Label();
            lblFecha = new Label();
            lblProteina = new Label();
            lblGrasa = new Label();
            lblFibra = new Label();
            lblCenizas = new Label();
            lblHumedad = new Label();
            lblPlanta = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            cmbProducto = new ComboBox();
            cmbEspecie = new ComboBox();
            cmbPlanta = new ComboBox();
            dtpFecha = new DateTimePicker();
            txtProteina = new TextBox();
            txtGrasa = new TextBox();
            txtFibra = new TextBox();
            txtCenizas = new TextBox();
            txtHumedad = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(23, 60);
            lblProducto.Margin = new Padding(2, 0, 2, 0);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 1;
            lblProducto.Text = "Producto:";
            // 
            // lblEspecie
            // 
            lblEspecie.AutoSize = true;
            lblEspecie.Location = new Point(23, 90);
            lblEspecie.Margin = new Padding(2, 0, 2, 0);
            lblEspecie.Name = "lblEspecie";
            lblEspecie.Size = new Size(49, 15);
            lblEspecie.TabIndex = 2;
            lblEspecie.Text = "Especie:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(23, 156);
            lblFecha.Margin = new Padding(2, 0, 2, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // lblProteina
            // 
            lblProteina.AutoSize = true;
            lblProteina.Location = new Point(23, 186);
            lblProteina.Margin = new Padding(2, 0, 2, 0);
            lblProteina.Name = "lblProteina";
            lblProteina.Size = new Size(54, 15);
            lblProteina.TabIndex = 4;
            lblProteina.Text = "Proteína:";
            // 
            // lblGrasa
            // 
            lblGrasa.AutoSize = true;
            lblGrasa.Location = new Point(23, 216);
            lblGrasa.Margin = new Padding(2, 0, 2, 0);
            lblGrasa.Name = "lblGrasa";
            lblGrasa.Size = new Size(39, 15);
            lblGrasa.TabIndex = 5;
            lblGrasa.Text = "Grasa:";
            // 
            // lblFibra
            // 
            lblFibra.AutoSize = true;
            lblFibra.Location = new Point(23, 246);
            lblFibra.Margin = new Padding(2, 0, 2, 0);
            lblFibra.Name = "lblFibra";
            lblFibra.Size = new Size(36, 15);
            lblFibra.TabIndex = 6;
            lblFibra.Text = "Fibra:";
            // 
            // lblCenizas
            // 
            lblCenizas.AutoSize = true;
            lblCenizas.Location = new Point(23, 276);
            lblCenizas.Margin = new Padding(2, 0, 2, 0);
            lblCenizas.Name = "lblCenizas";
            lblCenizas.Size = new Size(50, 15);
            lblCenizas.TabIndex = 7;
            lblCenizas.Text = "Cenizas:";
            // 
            // lblHumedad
            // 
            lblHumedad.AutoSize = true;
            lblHumedad.Location = new Point(23, 306);
            lblHumedad.Margin = new Padding(2, 0, 2, 0);
            lblHumedad.Name = "lblHumedad";
            lblHumedad.Size = new Size(63, 15);
            lblHumedad.TabIndex = 8;
            lblHumedad.Text = "Humedad:";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2, 2, 2, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(350, 45);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 15);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(242, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Agregar Análisis de Producto";
            // 
            // cmbProducto
            // 
            cmbProducto.Location = new Point(101, 58);
            cmbProducto.Margin = new Padding(2, 2, 2, 2);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(203, 23);
            cmbProducto.TabIndex = 1;
            // 
            // cmbEspecie
            // 
            cmbEspecie.Location = new Point(101, 88);
            cmbEspecie.Margin = new Padding(2, 2, 2, 2);
            cmbEspecie.Name = "cmbEspecie";
            cmbEspecie.Size = new Size(203, 23);
            cmbEspecie.TabIndex = 2;
            cmbEspecie.SelectedIndexChanged += cmbEspecie_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(101, 154);
            dtpFecha.Margin = new Padding(2, 2, 2, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(203, 23);
            dtpFecha.TabIndex = 3;
            // 
            // txtProteina
            // 
            txtProteina.Location = new Point(101, 184);
            txtProteina.Margin = new Padding(2, 2, 2, 2);
            txtProteina.Name = "txtProteina";
            txtProteina.Size = new Size(203, 23);
            txtProteina.TabIndex = 4;
            // 
            // txtGrasa
            // 
            txtGrasa.Location = new Point(101, 214);
            txtGrasa.Margin = new Padding(2, 2, 2, 2);
            txtGrasa.Name = "txtGrasa";
            txtGrasa.Size = new Size(203, 23);
            txtGrasa.TabIndex = 5;
            // 
            // txtFibra
            // 
            txtFibra.Location = new Point(101, 244);
            txtFibra.Margin = new Padding(2, 2, 2, 2);
            txtFibra.Name = "txtFibra";
            txtFibra.Size = new Size(203, 23);
            txtFibra.TabIndex = 6;
            // 
            // txtCenizas
            // 
            txtCenizas.Location = new Point(101, 274);
            txtCenizas.Margin = new Padding(2, 2, 2, 2);
            txtCenizas.Name = "txtCenizas";
            txtCenizas.Size = new Size(203, 23);
            txtCenizas.TabIndex = 7;
            // 
            // txtHumedad
            // 
            txtHumedad.Location = new Point(101, 304);
            txtHumedad.Margin = new Padding(2, 2, 2, 2);
            txtHumedad.Name = "txtHumedad";
            txtHumedad.Size = new Size(203, 23);
            txtHumedad.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(101, 336);
            btnGuardar.Margin = new Padding(2, 2, 2, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(78, 26);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(226, 336);
            btnCancelar.Margin = new Padding(2, 2, 2, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(78, 26);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblPlanta
            // 
            lblPlanta.AutoSize = true;
            lblPlanta.Location = new Point(23, 122);
            lblPlanta.Margin = new Padding(2, 0, 2, 0);
            lblPlanta.Name = "lblPlanta";
            lblPlanta.Size = new Size(43, 15);
            lblPlanta.TabIndex = 11;
            lblPlanta.Text = "Planta:";
            // 
            // cmbPlanta
            // 
            cmbPlanta.Location = new Point(101, 119);
            cmbPlanta.Margin = new Padding(2);
            cmbPlanta.Name = "cmbPlanta";
            cmbPlanta.Size = new Size(203, 23);
            cmbPlanta.TabIndex = 12;
            // 
            // AgregarAnalisisProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 390);
            Controls.Add(lblPlanta);
            Controls.Add(cmbPlanta);
            Controls.Add(panelHeader);
            Controls.Add(lblProducto);
            Controls.Add(cmbProducto);
            Controls.Add(lblEspecie);
            Controls.Add(cmbEspecie);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblProteina);
            Controls.Add(txtProteina);
            Controls.Add(lblGrasa);
            Controls.Add(txtGrasa);
            Controls.Add(lblFibra);
            Controls.Add(txtFibra);
            Controls.Add(lblCenizas);
            Controls.Add(txtCenizas);
            Controls.Add(lblHumedad);
            Controls.Add(txtHumedad);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Margin = new Padding(2, 2, 2, 2);
            Name = "AgregarAnalisisProductoForm";
            Text = "Agregar Análisis de Producto";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProducto;
        private Label lblEspecie;
        private Label lblFecha;
        private Label lblProteina;
        private Label lblGrasa;
        private Label lblFibra;
        private Label lblCenizas;
        private Label lblHumedad;
        private Panel panelHeader;
        private Label lblTitle;
        private ComboBox cmbProducto;
        private ComboBox cmbEspecie;
        private DateTimePicker dtpFecha;
        private TextBox txtProteina;
        private TextBox txtGrasa;
        private TextBox txtFibra;
        private TextBox txtCenizas;
        private TextBox txtHumedad;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblPlanta;
        private ComboBox cmbPlanta;
    }
}
