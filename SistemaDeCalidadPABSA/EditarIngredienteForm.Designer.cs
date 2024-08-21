namespace SistemaDeCalidadPABSA
{
    partial class EditarIngredienteForm
    {
        private System.ComponentModel.IContainer components = null;
        private int ingredienteID;

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
            lblNombre = new Label();
            lblDescripcion = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // Panel Header
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(400, 60);
            panelHeader.TabIndex = 0;

            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Editar Ingrediente";

            // Label Nombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(30, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(60, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";

            // TextBox Nombre
            txtNombre.Location = new Point(130, 77);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 27);
            txtNombre.TabIndex = 1;

            // Label Descripción
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(30, 120);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción:";

            // TextBox Descripción
            txtDescripcion.Location = new Point(130, 117);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(240, 27);
            txtDescripcion.TabIndex = 2;

            // Button Guardar
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(130, 160);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // Button Cancelar
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(270, 160);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += new EventHandler(btnCancelar_Click);

            // EditarIngredienteForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 210);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(panelHeader);
            Name = "EditarIngredienteForm";
            Text = "Editar Ingrediente";
            Load += new EventHandler(EditarIngredienteForm_Load);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblDescripcion;
        private Panel panelHeader;
        private Label lblTitle;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
