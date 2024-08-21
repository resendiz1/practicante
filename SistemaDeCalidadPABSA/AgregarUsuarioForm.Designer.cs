namespace SistemaDeCalidadPABSA
{
    partial class AgregarUsuarioForm
    {
       // private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitle;
        private TextBox txtNombre;
        private TextBox txtApellidos;
        private TextBox txtUsuario;
        private TextBox txtContrasena; 
        private ComboBox cmbRol;
        private Button btnGuardar;
        private Button btnCancelar;

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.txtNombre = new TextBox();
            this.txtApellidos = new TextBox();
            this.txtUsuario = new TextBox();
            this.txtContrasena = new TextBox();
            this.cmbRol = new ComboBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.Green;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(372, 80);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(3, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(224, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Agregar Usuario";

            // txtNombre
            this.txtNombre.ForeColor = Color.Black;
            this.txtNombre.Location = new Point(80, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Nombre";
            this.txtNombre.Size = new Size(200, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextAlign = HorizontalAlignment.Center;

            // txtApellidos
            this.txtApellidos.ForeColor = Color.Black;
            this.txtApellidos.Location = new Point(80, 140);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.PlaceholderText = "Apellidos";
            this.txtApellidos.Size = new Size(200, 23);
            this.txtApellidos.TabIndex = 2;
            this.txtApellidos.TextAlign = HorizontalAlignment.Center;

            // txtUsuario
            this.txtUsuario.ForeColor = Color.Black;
            this.txtUsuario.Location = new Point(80, 180);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceholderText = "Usuario";
            this.txtUsuario.Size = new Size(200, 23);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.TextAlign = HorizontalAlignment.Center;

            // txtContrasena
            this.txtContrasena.ForeColor = Color.Black;
            this.txtContrasena.Location = new Point(80, 220);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PlaceholderText = "Contraseña";
            this.txtContrasena.Size = new Size(200, 23);
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.TabIndex = 4;
            this.txtContrasena.TextAlign = HorizontalAlignment.Center;

            // cmbRol
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.ForeColor = Color.Black;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] { "Administrador", "Trabajador" });
            this.cmbRol.Location = new Point(80, 260);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new Size(200, 23);
            this.cmbRol.TabIndex = 5;

            // btnGuardar
            this.btnGuardar.BackColor = Color.Orange;
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(80, 300);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(90, 30);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.BackColor = Color.Orange;
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(190, 300);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(90, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // AgregarUsuarioForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(372, 350);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AgregarUsuarioForm";
            this.Text = "Agregar Usuario";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
