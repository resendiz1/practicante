namespace SistemaDeCalidadPABSA
{
    partial class EditarUsuarioForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            txtApellidos = new System.Windows.Forms.TextBox();
            txtUsuario = new System.Windows.Forms.TextBox();
            txtContrasena = new System.Windows.Forms.TextBox();
            lblNombre = new System.Windows.Forms.Label();
            lblApellidos = new System.Windows.Forms.Label();
            lblUsuario = new System.Windows.Forms.Label();
            lblContrasena = new System.Windows.Forms.Label();
            cmbRol = new System.Windows.Forms.ComboBox();
            lblRol = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            panelHeader.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(400, 69);
            panelHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Editar Usuario";

            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 84);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(233, 23);
            txtNombre.TabIndex = 1;

            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(130, 114);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(233, 23);
            txtApellidos.TabIndex = 2;

            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(130, 144);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(233, 23);
            txtUsuario.TabIndex = 3;

            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(130, 174);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(233, 23);
            txtContrasena.TabIndex = 4;

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(50, 88);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 15);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";

            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(50, 118);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 6;
            lblApellidos.Text = "Apellidos:";

            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(50, 148);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(53, 15);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Usuario:";

            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(50, 178);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(72, 15);
            lblContrasena.TabIndex = 8;
            lblContrasena.Text = "Contraseña:";

            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] {
            "Administrador",
            "Trabajador"});
            cmbRol.Location = new Point(130, 204);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(233, 23);
            cmbRol.TabIndex = 5;

            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(50, 208);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(29, 15);
            lblRol.TabIndex = 9;
            lblRol.Text = "Rol:";

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(130, 240);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(251, 240);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // 
            // EditarUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblRol);
            Controls.Add(cmbRol);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblApellidos);
            Controls.Add(txtApellidos);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(panelHeader);
            Name = "EditarUsuarioForm";
            Text = "Editar Usuario";
            Load += EditarUsuarioForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
