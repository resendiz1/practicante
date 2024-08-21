

namespace SistemaDeCalidadPABSA
{
    partial class AgregarAnalisisForm
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
            lblFecha = new Label();
            lblProteina = new Label();
            lblGrasa = new Label();
            lblFibra = new Label();
            lblCenizas = new Label();
            lblHumedad = new Label();
            lblProveedor = new Label();
            lblIngrediente = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            dtpFecha = new DateTimePicker();
            txtProteinaNIR = new TextBox();
            txtProteinaLAB = new TextBox();
            txtProteinaPROM = new TextBox();
            txtGrasaNIR = new TextBox();
            txtGrasaLAB = new TextBox();
            txtGrasaPROM = new TextBox();
            txtFibraNIR = new TextBox();
            txtFibraLAB = new TextBox();
            txtFibraPROM = new TextBox();
            txtCenizasNIR = new TextBox();
            txtCenizasLAB = new TextBox();
            txtCenizasPROM = new TextBox();
            txtHumedadNIR = new TextBox();
            txtHumedadLAB = new TextBox();
            txtHumedadPROM = new TextBox();
            txtCalcioPROM = new TextBox();
            txtCalcioLAB = new TextBox();
            txtCalcioNIR = new TextBox();
            txtFosforoPROM = new TextBox();
            txtFosforoLAB = new TextBox();
            txtFosforoNIR = new TextBox();
            cmbProveedor = new ComboBox();
            cmbIngrediente = new ComboBox();
            lblFosforo = new Label();
            lblCalcio = new Label();
            lblFolioInt = new Label();
            lblFolioExt = new Label();
            AddFolioEx = new Button();
            btnDltFolio = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtFolInt = new TextBox();
            txtFolExt = new TextBox();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(26, 126);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha:";
            // 
            // lblProteina
            // 
            lblProteina.AutoSize = true;
            lblProteina.Location = new Point(26, 156);
            lblProteina.Name = "lblProteina";
            lblProteina.Size = new Size(54, 15);
            lblProteina.TabIndex = 6;
            lblProteina.Text = "Proteína:";
            // 
            // lblGrasa
            // 
            lblGrasa.AutoSize = true;
            lblGrasa.Location = new Point(26, 186);
            lblGrasa.Name = "lblGrasa";
            lblGrasa.Size = new Size(39, 15);
            lblGrasa.TabIndex = 9;
            lblGrasa.Text = "Grasa:";
            // 
            // lblFibra
            // 
            lblFibra.AutoSize = true;
            lblFibra.Location = new Point(26, 216);
            lblFibra.Name = "lblFibra";
            lblFibra.Size = new Size(36, 15);
            lblFibra.TabIndex = 12;
            lblFibra.Text = "Fibra:";
            // 
            // lblCenizas
            // 
            lblCenizas.AutoSize = true;
            lblCenizas.Location = new Point(26, 246);
            lblCenizas.Name = "lblCenizas";
            lblCenizas.Size = new Size(50, 15);
            lblCenizas.TabIndex = 15;
            lblCenizas.Text = "Cenizas:";
            // 
            // lblHumedad
            // 
            lblHumedad.AutoSize = true;
            lblHumedad.Location = new Point(26, 276);
            lblHumedad.Name = "lblHumedad";
            lblHumedad.Size = new Size(63, 15);
            lblHumedad.TabIndex = 18;
            lblHumedad.Text = "Humedad:";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(26, 60);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 1;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblIngrediente
            // 
            lblIngrediente.AutoSize = true;
            lblIngrediente.Location = new Point(26, 90);
            lblIngrediente.Name = "lblIngrediente";
            lblIngrediente.Size = new Size(70, 15);
            lblIngrediente.TabIndex = 2;
            lblIngrediente.Text = "Ingrediente:";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(373, 45);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Agregar Análisis de Materia Prima";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(114, 124);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(227, 23);
            dtpFecha.TabIndex = 5;
            // 
            // txtProteinaNIR
            // 
            txtProteinaNIR.Location = new Point(114, 154);
            txtProteinaNIR.Margin = new Padding(3, 2, 3, 2);
            txtProteinaNIR.Name = "txtProteinaNIR";
            txtProteinaNIR.PlaceholderText = "NIR";
            txtProteinaNIR.Size = new Size(70, 23);
            txtProteinaNIR.TabIndex = 6;
            txtProteinaNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // txtProteinaLAB
            // 
            txtProteinaLAB.Location = new Point(192, 154);
            txtProteinaLAB.Margin = new Padding(3, 2, 3, 2);
            txtProteinaLAB.Name = "txtProteinaLAB";
            txtProteinaLAB.PlaceholderText = "LAB";
            txtProteinaLAB.Size = new Size(70, 23);
            txtProteinaLAB.TabIndex = 7;
            txtProteinaLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtProteinaPROM
            // 
            txtProteinaPROM.Location = new Point(271, 154);
            txtProteinaPROM.Margin = new Padding(3, 2, 3, 2);
            txtProteinaPROM.Name = "txtProteinaPROM";
            txtProteinaPROM.PlaceholderText = "PROM";
            txtProteinaPROM.Size = new Size(70, 23);
            txtProteinaPROM.TabIndex = 8;
            txtProteinaPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGrasaNIR
            // 
            txtGrasaNIR.Location = new Point(114, 184);
            txtGrasaNIR.Margin = new Padding(3, 2, 3, 2);
            txtGrasaNIR.Name = "txtGrasaNIR";
            txtGrasaNIR.PlaceholderText = "NIR";
            txtGrasaNIR.Size = new Size(70, 23);
            txtGrasaNIR.TabIndex = 9;
            txtGrasaNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGrasaLAB
            // 
            txtGrasaLAB.Location = new Point(192, 184);
            txtGrasaLAB.Margin = new Padding(3, 2, 3, 2);
            txtGrasaLAB.Name = "txtGrasaLAB";
            txtGrasaLAB.PlaceholderText = "LAB";
            txtGrasaLAB.Size = new Size(70, 23);
            txtGrasaLAB.TabIndex = 10;
            txtGrasaLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGrasaPROM
            // 
            txtGrasaPROM.Location = new Point(271, 184);
            txtGrasaPROM.Margin = new Padding(3, 2, 3, 2);
            txtGrasaPROM.Name = "txtGrasaPROM";
            txtGrasaPROM.PlaceholderText = "PROM";
            txtGrasaPROM.Size = new Size(70, 23);
            txtGrasaPROM.TabIndex = 11;
            txtGrasaPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFibraNIR
            // 
            txtFibraNIR.Location = new Point(114, 214);
            txtFibraNIR.Margin = new Padding(3, 2, 3, 2);
            txtFibraNIR.Name = "txtFibraNIR";
            txtFibraNIR.PlaceholderText = "NIR";
            txtFibraNIR.Size = new Size(70, 23);
            txtFibraNIR.TabIndex = 12;
            txtFibraNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFibraLAB
            // 
            txtFibraLAB.Location = new Point(192, 214);
            txtFibraLAB.Margin = new Padding(3, 2, 3, 2);
            txtFibraLAB.Name = "txtFibraLAB";
            txtFibraLAB.PlaceholderText = "LAB";
            txtFibraLAB.Size = new Size(70, 23);
            txtFibraLAB.TabIndex = 13;
            txtFibraLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFibraPROM
            // 
            txtFibraPROM.Location = new Point(271, 214);
            txtFibraPROM.Margin = new Padding(3, 2, 3, 2);
            txtFibraPROM.Name = "txtFibraPROM";
            txtFibraPROM.PlaceholderText = "PROM";
            txtFibraPROM.Size = new Size(70, 23);
            txtFibraPROM.TabIndex = 14;
            txtFibraPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCenizasNIR
            // 
            txtCenizasNIR.Location = new Point(114, 244);
            txtCenizasNIR.Margin = new Padding(3, 2, 3, 2);
            txtCenizasNIR.Name = "txtCenizasNIR";
            txtCenizasNIR.PlaceholderText = "NIR";
            txtCenizasNIR.Size = new Size(70, 23);
            txtCenizasNIR.TabIndex = 15;
            txtCenizasNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCenizasLAB
            // 
            txtCenizasLAB.Location = new Point(192, 244);
            txtCenizasLAB.Margin = new Padding(3, 2, 3, 2);
            txtCenizasLAB.Name = "txtCenizasLAB";
            txtCenizasLAB.PlaceholderText = "LAB";
            txtCenizasLAB.Size = new Size(70, 23);
            txtCenizasLAB.TabIndex = 16;
            txtCenizasLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCenizasPROM
            // 
            txtCenizasPROM.Location = new Point(271, 244);
            txtCenizasPROM.Margin = new Padding(3, 2, 3, 2);
            txtCenizasPROM.Name = "txtCenizasPROM";
            txtCenizasPROM.PlaceholderText = "PROM";
            txtCenizasPROM.Size = new Size(70, 23);
            txtCenizasPROM.TabIndex = 17;
            txtCenizasPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtHumedadNIR
            // 
            txtHumedadNIR.Location = new Point(114, 274);
            txtHumedadNIR.Margin = new Padding(3, 2, 3, 2);
            txtHumedadNIR.Name = "txtHumedadNIR";
            txtHumedadNIR.PlaceholderText = "NIR";
            txtHumedadNIR.Size = new Size(70, 23);
            txtHumedadNIR.TabIndex = 18;
            txtHumedadNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // txtHumedadLAB
            // 
            txtHumedadLAB.Location = new Point(192, 274);
            txtHumedadLAB.Margin = new Padding(3, 2, 3, 2);
            txtHumedadLAB.Name = "txtHumedadLAB";
            txtHumedadLAB.PlaceholderText = "LAB";
            txtHumedadLAB.Size = new Size(70, 23);
            txtHumedadLAB.TabIndex = 19;
            txtHumedadLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtHumedadPROM
            // 
            txtHumedadPROM.Location = new Point(271, 274);
            txtHumedadPROM.Margin = new Padding(3, 2, 3, 2);
            txtHumedadPROM.Name = "txtHumedadPROM";
            txtHumedadPROM.PlaceholderText = "PROM";
            txtHumedadPROM.Size = new Size(70, 23);
            txtHumedadPROM.TabIndex = 20;
            txtHumedadPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCalcioPROM
            // 
            txtCalcioPROM.Location = new Point(271, 304);
            txtCalcioPROM.Margin = new Padding(3, 2, 3, 2);
            txtCalcioPROM.Name = "txtCalcioPROM";
            txtCalcioPROM.PlaceholderText = "PROM";
            txtCalcioPROM.Size = new Size(70, 23);
            txtCalcioPROM.TabIndex = 26;
            txtCalcioPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCalcioLAB
            // 
            txtCalcioLAB.Location = new Point(192, 304);
            txtCalcioLAB.Margin = new Padding(3, 2, 3, 2);
            txtCalcioLAB.Name = "txtCalcioLAB";
            txtCalcioLAB.PlaceholderText = "LAB";
            txtCalcioLAB.Size = new Size(70, 23);
            txtCalcioLAB.TabIndex = 25;
            txtCalcioLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCalcioNIR
            // 
            txtCalcioNIR.Location = new Point(114, 304);
            txtCalcioNIR.Margin = new Padding(3, 2, 3, 2);
            txtCalcioNIR.Name = "txtCalcioNIR";
            txtCalcioNIR.PlaceholderText = "NIR";
            txtCalcioNIR.Size = new Size(70, 23);
            txtCalcioNIR.TabIndex = 23;
            txtCalcioNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFosforoPROM
            // 
            txtFosforoPROM.Location = new Point(271, 334);
            txtFosforoPROM.Margin = new Padding(3, 2, 3, 2);
            txtFosforoPROM.Name = "txtFosforoPROM";
            txtFosforoPROM.PlaceholderText = "PROM";
            txtFosforoPROM.Size = new Size(70, 23);
            txtFosforoPROM.TabIndex = 30;
            txtFosforoPROM.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFosforoLAB
            // 
            txtFosforoLAB.Location = new Point(192, 334);
            txtFosforoLAB.Margin = new Padding(3, 2, 3, 2);
            txtFosforoLAB.Name = "txtFosforoLAB";
            txtFosforoLAB.PlaceholderText = "LAB";
            txtFosforoLAB.Size = new Size(70, 23);
            txtFosforoLAB.TabIndex = 29;
            txtFosforoLAB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFosforoNIR
            // 
            txtFosforoNIR.Location = new Point(114, 334);
            txtFosforoNIR.Margin = new Padding(3, 2, 3, 2);
            txtFosforoNIR.Name = "txtFosforoNIR";
            txtFosforoNIR.PlaceholderText = "NIR";
            txtFosforoNIR.Size = new Size(70, 23);
            txtFosforoNIR.TabIndex = 27;
            txtFosforoNIR.TextAlign = HorizontalAlignment.Center;
            // 
            // cmbProveedor
            // 
            cmbProveedor.Location = new Point(114, 58);
            cmbProveedor.Margin = new Padding(3, 2, 3, 2);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(227, 23);
            cmbProveedor.TabIndex = 1;
            // 
            // cmbIngrediente
            // 
            cmbIngrediente.Location = new Point(114, 88);
            cmbIngrediente.Margin = new Padding(3, 2, 3, 2);
            cmbIngrediente.Name = "cmbIngrediente";
            cmbIngrediente.Size = new Size(227, 23);
            cmbIngrediente.TabIndex = 2;
            // 
            // lblFosforo
            // 
            lblFosforo.AutoSize = true;
            lblFosforo.Location = new Point(26, 336);
            lblFosforo.Name = "lblFosforo";
            lblFosforo.Size = new Size(50, 15);
            lblFosforo.TabIndex = 28;
            lblFosforo.Text = "Fosforo:";
            // 
            // lblCalcio
            // 
            lblCalcio.AutoSize = true;
            lblCalcio.Location = new Point(26, 306);
            lblCalcio.Name = "lblCalcio";
            lblCalcio.Size = new Size(43, 15);
            lblCalcio.TabIndex = 24;
            lblCalcio.Text = "Calcio:";
            // 
            // lblFolioInt
            // 
            lblFolioInt.AutoSize = true;
            lblFolioInt.Location = new Point(26, 368);
            lblFolioInt.Name = "lblFolioInt";
            lblFolioInt.Size = new Size(77, 15);
            lblFolioInt.TabIndex = 31;
            lblFolioInt.Text = "Folio Interno:";
            // 
            // lblFolioExt
            // 
            lblFolioExt.AutoSize = true;
            lblFolioExt.Location = new Point(26, 400);
            lblFolioExt.Name = "lblFolioExt";
            lblFolioExt.Size = new Size(79, 15);
            lblFolioExt.TabIndex = 33;
            lblFolioExt.Text = "Folio Externo:";
            // 
            // AddFolioEx
            // 
            AddFolioEx.BackColor = Color.Green;
            AddFolioEx.FlatStyle = FlatStyle.Flat;
            AddFolioEx.ForeColor = Color.White;
            AddFolioEx.Location = new Point(265, 397);
            AddFolioEx.Margin = new Padding(3, 2, 3, 2);
            AddFolioEx.Name = "AddFolioEx";
            AddFolioEx.Size = new Size(37, 23);
            AddFolioEx.TabIndex = 35;
            AddFolioEx.Text = "+";
            AddFolioEx.UseVisualStyleBackColor = false;
            AddFolioEx.Click += AddFolioEx_Click;
            // 
            // btnDltFolio
            // 
            btnDltFolio.BackColor = Color.Orange;
            btnDltFolio.FlatStyle = FlatStyle.Flat;
            btnDltFolio.ForeColor = Color.White;
            btnDltFolio.Location = new Point(304, 397);
            btnDltFolio.Margin = new Padding(3, 2, 3, 2);
            btnDltFolio.Name = "btnDltFolio";
            btnDltFolio.Size = new Size(37, 23);
            btnDltFolio.TabIndex = 36;
            btnDltFolio.Text = "-";
            btnDltFolio.UseVisualStyleBackColor = false;
            btnDltFolio.Click += btnDltFolio_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Green;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(114, 439);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 30);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(236, 439);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 30);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtFolInt
            // 
            txtFolInt.Location = new Point(114, 365);
            txtFolInt.Margin = new Padding(3, 2, 3, 2);
            txtFolInt.Name = "txtFolInt";
            txtFolInt.Size = new Size(227, 23);
            txtFolInt.TabIndex = 37;
            txtFolInt.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFolExt
            // 
            txtFolExt.Location = new Point(114, 397);
            txtFolExt.Margin = new Padding(3, 2, 3, 2);
            txtFolExt.Name = "txtFolExt";
            txtFolExt.Size = new Size(145, 23);
            txtFolExt.TabIndex = 38;
            txtFolExt.TextAlign = HorizontalAlignment.Center;
            // 
            // AgregarAnalisisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 480);
            Controls.Add(txtFolExt);
            Controls.Add(txtFolInt);
            Controls.Add(btnDltFolio);
            Controls.Add(AddFolioEx);
            Controls.Add(lblFolioExt);
            Controls.Add(lblFolioInt);
            Controls.Add(txtFosforoPROM);
            Controls.Add(txtFosforoLAB);
            Controls.Add(txtFosforoNIR);
            Controls.Add(lblFosforo);
            Controls.Add(txtCalcioPROM);
            Controls.Add(txtCalcioLAB);
            Controls.Add(txtCalcioNIR);
            Controls.Add(lblCalcio);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtHumedadPROM);
            Controls.Add(txtHumedadLAB);
            Controls.Add(txtHumedadNIR);
            Controls.Add(txtCenizasPROM);
            Controls.Add(txtCenizasLAB);
            Controls.Add(txtCenizasNIR);
            Controls.Add(txtFibraPROM);
            Controls.Add(txtFibraLAB);
            Controls.Add(txtFibraNIR);
            Controls.Add(txtGrasaPROM);
            Controls.Add(txtGrasaLAB);
            Controls.Add(txtGrasaNIR);
            Controls.Add(txtProteinaPROM);
            Controls.Add(txtProteinaLAB);
            Controls.Add(txtProteinaNIR);
            Controls.Add(dtpFecha);
            Controls.Add(cmbIngrediente);
            Controls.Add(cmbProveedor);
            Controls.Add(lblFecha);
            Controls.Add(lblIngrediente);
            Controls.Add(lblProveedor);
            Controls.Add(lblHumedad);
            Controls.Add(lblCenizas);
            Controls.Add(lblFibra);
            Controls.Add(lblGrasa);
            Controls.Add(lblProteina);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AgregarAnalisisForm";
            Text = "Agregar Análisis";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblFecha;
        private Label lblProteina;
        private Label lblGrasa;
        private Label lblFibra;
        private Label lblCenizas;
        private Label lblHumedad;
        private Label lblProveedor;
        private Label lblIngrediente;
        private Label lblCalcio;
        private Label lblFosforo;
        private Label lblFolioInt;
        private Label lblFolioExt;
        private Panel panelHeader;
        private Label lblTitle;
        private ComboBox cmbProveedor;
        private ComboBox cmbIngrediente;
        private DateTimePicker dtpFecha;
        private TextBox txtProteinaNIR;
        private TextBox txtProteinaLAB;
        private TextBox txtProteinaPROM;
        private TextBox txtGrasaNIR;
        private TextBox txtGrasaLAB;
        private TextBox txtGrasaPROM;
        private TextBox txtFibraNIR;
        private TextBox txtFibraLAB;
        private TextBox txtFibraPROM;
        private TextBox txtCenizasNIR;
        private TextBox txtCenizasLAB;
        private TextBox txtCenizasPROM;
        private TextBox txtHumedadNIR;
        private TextBox txtHumedadLAB;
        private TextBox txtHumedadPROM;
        private TextBox txtCalcioPROM;
        private TextBox txtCalcioLAB;
        private TextBox txtCalcioNIR;
        private TextBox txtFosforoPROM;
        private TextBox txtFosforoLAB;
        private TextBox txtFosforoNIR;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button AddFolioEx;
        private Button btnDltFolio;
        private TextBox txtFolInt;
        private TextBox txtFolExt;
    }
}
