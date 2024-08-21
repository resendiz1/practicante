namespace SistemaDeCalidadPABSA
{
    partial class EditarProductoForm
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
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;

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
            dtpFechaCreacion = new DateTimePicker();
            label1 = new Label();
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
            panelHeader.Size = new Size(442, 69);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(216, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Editar Producto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(163, 85);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(233, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(163, 114);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(233, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtProteinaGarantia
            // 
            txtProteinaGarantia.Location = new Point(163, 143);
            txtProteinaGarantia.Name = "txtProteinaGarantia";
            txtProteinaGarantia.Size = new Size(233, 23);
            txtProteinaGarantia.TabIndex = 3;
            // 
            // txtGrasaGarantia
            // 
            txtGrasaGarantia.Location = new Point(163, 172);
            txtGrasaGarantia.Name = "txtGrasaGarantia";
            txtGrasaGarantia.Size = new Size(233, 23);
            txtGrasaGarantia.TabIndex = 4;
            // 
            // txtFibraGarantia
            // 
            txtFibraGarantia.Location = new Point(163, 201);
            txtFibraGarantia.Name = "txtFibraGarantia";
            txtFibraGarantia.Size = new Size(233, 23);
            txtFibraGarantia.TabIndex = 5;
            // 
            // txtCenizasGarantia
            // 
            txtCenizasGarantia.Location = new Point(163, 230);
            txtCenizasGarantia.Name = "txtCenizasGarantia";
            txtCenizasGarantia.Size = new Size(233, 23);
            txtCenizasGarantia.TabIndex = 6;
            // 
            // txtHumedadGarantia
            // 
            txtHumedadGarantia.Location = new Point(163, 259);
            txtHumedadGarantia.Name = "txtHumedadGarantia";
            txtHumedadGarantia.Size = new Size(233, 23);
            txtHumedadGarantia.TabIndex = 7;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(49, 93);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(49, 122);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 9;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblProteinaGarantia
            // 
            lblProteinaGarantia.AutoSize = true;
            lblProteinaGarantia.Location = new Point(49, 151);
            lblProteinaGarantia.Name = "lblProteinaGarantia";
            lblProteinaGarantia.Size = new Size(101, 15);
            lblProteinaGarantia.TabIndex = 10;
            lblProteinaGarantia.Text = "Proteína Garantía:";
            // 
            // lblGrasaGarantia
            // 
            lblGrasaGarantia.AutoSize = true;
            lblGrasaGarantia.Location = new Point(49, 180);
            lblGrasaGarantia.Name = "lblGrasaGarantia";
            lblGrasaGarantia.Size = new Size(86, 15);
            lblGrasaGarantia.TabIndex = 11;
            lblGrasaGarantia.Text = "Grasa Garantía:";
            // 
            // lblFibraGarantia
            // 
            lblFibraGarantia.AutoSize = true;
            lblFibraGarantia.Location = new Point(49, 209);
            lblFibraGarantia.Name = "lblFibraGarantia";
            lblFibraGarantia.Size = new Size(83, 15);
            lblFibraGarantia.TabIndex = 12;
            lblFibraGarantia.Text = "Fibra Garantía:";
            // 
            // lblCenizasGarantia
            // 
            lblCenizasGarantia.AutoSize = true;
            lblCenizasGarantia.Location = new Point(49, 238);
            lblCenizasGarantia.Name = "lblCenizasGarantia";
            lblCenizasGarantia.Size = new Size(97, 15);
            lblCenizasGarantia.TabIndex = 13;
            lblCenizasGarantia.Text = "Cenizas Garantía:";
            // 
            // lblHumedadGarantia
            // 
            lblHumedadGarantia.AutoSize = true;
            lblHumedadGarantia.Location = new Point(49, 267);
            lblHumedadGarantia.Name = "lblHumedadGarantia";
            lblHumedadGarantia.Size = new Size(110, 15);
            lblHumedadGarantia.TabIndex = 14;
            lblHumedadGarantia.Text = "Humedad Garantía:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(157, 323);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 27);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(275, 323);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 27);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dtpFechaCreacion
            // 
            dtpFechaCreacion.Format = DateTimePickerFormat.Short;
            dtpFechaCreacion.Location = new Point(163, 288);
            dtpFechaCreacion.Name = "dtpFechaCreacion";
            dtpFechaCreacion.Size = new Size(233, 23);
            dtpFechaCreacion.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 296);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 18;
            label1.Text = "Fecha de creación:";
            label1.Click += label1_Click;
            // 
            // EditarProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 362);
            Controls.Add(label1);
            Controls.Add(dtpFechaCreacion);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditarProductoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Producto";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}
