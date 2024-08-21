namespace SistemaDeCalidadPABSA
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAgregarAdmin;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnLogin;

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
            panelHeader = new Panel();
            lblTitle = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnLogin = new Button();
            btnAgregarAdmin = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(372, 80);
            panelHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sistema de Calidad PABSA";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // txtUsuario
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Location = new Point(86, 100);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(200, 23);
            txtUsuario.TabIndex = 1;

            // txtContrasena
            txtContrasena.ForeColor = Color.Black;
            txtContrasena.Location = new Point(86, 150);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Contraseña";
            txtContrasena.Size = new Size(200, 23);
            txtContrasena.TabIndex = 2;
            txtContrasena.UseSystemPasswordChar = true;

            // btnLogin
            btnLogin.BackColor = Color.Orange;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(86, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 30);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            // btnAgregarAdmin
            btnAgregarAdmin.BackColor = Color.Orange;
            btnAgregarAdmin.ForeColor = Color.White;
            btnAgregarAdmin.Location = new Point(86, 250);
            btnAgregarAdmin.Name = "btnAgregarAdmin";
            btnAgregarAdmin.Size = new Size(200, 30);
            btnAgregarAdmin.TabIndex = 4;
            btnAgregarAdmin.Text = "Agregar Administrador";
            btnAgregarAdmin.UseVisualStyleBackColor = false;
            btnAgregarAdmin.Visible = false;
            btnAgregarAdmin.Click += btnAgregarAdmin_Click;

            // Login Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 320);
            Controls.Add(btnAgregarAdmin);
            Controls.Add(btnLogin);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
