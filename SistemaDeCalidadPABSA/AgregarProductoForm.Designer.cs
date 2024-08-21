namespace SistemaDeCalidadPABSA
{
    partial class AgregarProductoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtProteinaGarantia;
        private System.Windows.Forms.TextBox txtGrasaGarantia;
        private System.Windows.Forms.TextBox txtFibraGarantia;
        private System.Windows.Forms.TextBox txtCenizasGarantia;
        private System.Windows.Forms.TextBox txtHumedadGarantia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblProteinaGarantia;
        private System.Windows.Forms.Label lblGrasaGarantia;
        private System.Windows.Forms.Label lblFibraGarantia;
        private System.Windows.Forms.Label lblCenizasGarantia;
        private System.Windows.Forms.Label lblHumedadGarantia;
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
            panelHeader = new Panel();
            lblTitle = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtProteinaGarantia = new TextBox();
            txtGrasaGarantia = new TextBox();
            txtFibraGarantia = new TextBox();
            txtCenizasGarantia = new TextBox();
            txtHumedadGarantia = new TextBox();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblProteinaGarantia = new Label();
            lblGrasaGarantia = new Label();
            lblFibraGarantia = new Label();
            lblCenizasGarantia = new Label();
            lblHumedadGarantia = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(482, 69);
            panelHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(14, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(242, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Agregar Producto";

            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(163, 85);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(233, 23);
            txtNombre.TabIndex = 1;

            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new System.Drawing.Point(163, 114);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new System.Drawing.Size(233, 23);
            txtDescripcion.TabIndex = 2;

            // 
            // txtProteinaGarantia
            // 
            txtProteinaGarantia.Location = new System.Drawing.Point(163, 145);
            txtProteinaGarantia.Name = "txtProteinaGarantia";
            txtProteinaGarantia.Size = new System.Drawing.Size(233, 23);
            txtProteinaGarantia.TabIndex = 3;

            // 
            // txtGrasaGarantia
            // 
            txtGrasaGarantia.Location = new System.Drawing.Point(163, 174);
            txtGrasaGarantia.Name = "txtGrasaGarantia";
            txtGrasaGarantia.Size = new System.Drawing.Size(233, 23);
            txtGrasaGarantia.TabIndex = 4;

            // 
            // txtFibraGarantia
            // 
            txtFibraGarantia.Location = new System.Drawing.Point(163, 203);
            txtFibraGarantia.Name = "txtFibraGarantia";
            txtFibraGarantia.Size = new System.Drawing.Size(233, 23);
            txtFibraGarantia.TabIndex = 5;

            // 
            // txtCenizasGarantia
            // 
            txtCenizasGarantia.Location = new System.Drawing.Point(163, 232);
            txtCenizasGarantia.Name = "txtCenizasGarantia";
            txtCenizasGarantia.Size = new System.Drawing.Size(233, 23);
            txtCenizasGarantia.TabIndex = 6;

            // 
            // txtHumedadGarantia
            // 
            txtHumedadGarantia.Location = new System.Drawing.Point(163, 261);
            txtHumedadGarantia.Name = "txtHumedadGarantia";
            txtHumedadGarantia.Size = new System.Drawing.Size(233, 23);
            txtHumedadGarantia.TabIndex = 7;

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(50, 88);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(54, 15);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre:";

            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new System.Drawing.Point(50, 118);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new System.Drawing.Size(72, 15);
            lblDescripcion.TabIndex = 9;
            lblDescripcion.Text = "Descripción:";

            // 
            // lblProteinaGarantia
            // 
            lblProteinaGarantia.AutoSize = true;
            lblProteinaGarantia.Location = new System.Drawing.Point(50, 148);
            lblProteinaGarantia.Name = "lblProteinaGarantia";
            lblProteinaGarantia.Size = new System.Drawing.Size(101, 15);
            lblProteinaGarantia.TabIndex = 10;
            lblProteinaGarantia.Text = "Proteína Garantía:";

            // 
            // lblGrasaGarantia
            // 
            lblGrasaGarantia.AutoSize = true;
            lblGrasaGarantia.Location = new System.Drawing.Point(50, 177);
            lblGrasaGarantia.Name = "lblGrasaGarantia";
            lblGrasaGarantia.Size = new System.Drawing.Size(86, 15);
            lblGrasaGarantia.TabIndex = 11;
            lblGrasaGarantia.Text = "Grasa Garantía:";

            // 
            // lblFibraGarantia
            // 
            lblFibraGarantia.AutoSize = true;
            lblFibraGarantia.Location = new System.Drawing.Point(50, 206);
            lblFibraGarantia.Name = "lblFibraGarantia";
            lblFibraGarantia.Size = new System.Drawing.Size(83, 15);
            lblFibraGarantia.TabIndex = 12;
            lblFibraGarantia.Text = "Fibra Garantía:";

            // 
            // lblCenizasGarantia
            // 
            lblCenizasGarantia.AutoSize = true;
            lblCenizasGarantia.Location = new System.Drawing.Point(50, 236);
            lblCenizasGarantia.Name = "lblCenizasGarantia";
            lblCenizasGarantia.Size = new System.Drawing.Size(97, 15);
            lblCenizasGarantia.TabIndex = 13;
            lblCenizasGarantia.Text = "Cenizas Garantía:";

            // 
            // lblHumedadGarantia
            // 
            lblHumedadGarantia.AutoSize = true;
            lblHumedadGarantia.Location = new System.Drawing.Point(50, 265);
            lblHumedadGarantia.Name = "lblHumedadGarantia";
            lblHumedadGarantia.Size = new System.Drawing.Size(110, 15);
            lblHumedadGarantia.TabIndex = 14;
            lblHumedadGarantia.Text = "Humedad Garantía:";

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.Orange;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(130, 304);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(112, 27);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += new System.EventHandler(btnGuardar_Click);

            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = System.Drawing.Color.Red;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.ForeColor = System.Drawing.Color.White;
            btnCancelar.Location = new System.Drawing.Point(264, 304);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(112, 27);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += new System.EventHandler(btnCancelar_Click);

            // 
            // AgregarProductoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(482, 343);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblHumedadGarantia);
            Controls.Add(lblCenizasGarantia);
            Controls.Add(lblFibraGarantia);
            Controls.Add(lblGrasaGarantia);
            Controls.Add(lblProteinaGarantia);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(txtHumedadGarantia);
            Controls.Add(txtCenizasGarantia);
            Controls.Add(txtFibraGarantia);
            Controls.Add(txtGrasaGarantia);
            Controls.Add(txtProteinaGarantia);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarProductoForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Agregar Producto";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

       
    }
}
