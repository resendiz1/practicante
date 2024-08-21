namespace SistemaDeCalidadPABSA
{
    partial class EspeciesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvEspecies;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnAgregarEspecie;

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
            dgvEspecies = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnAgregarEspecie = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEspecies).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(531, 69);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Especies";
            // 
            // dgvEspecies
            // 
            dgvEspecies.AllowUserToAddRows = false;
            dgvEspecies.AllowUserToDeleteRows = false;
            dgvEspecies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEspecies.Dock = DockStyle.Bottom;
            dgvEspecies.Location = new Point(0, 157);
            dgvEspecies.Name = "dgvEspecies";
            dgvEspecies.ReadOnly = true;
            dgvEspecies.Size = new Size(531, 335);
            dgvEspecies.TabIndex = 1;
            dgvEspecies.CellClick += dgvEspecies_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(82, 84);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(167, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(23, 88);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar:";
            // 
            // btnAgregarEspecie
            // 
            btnAgregarEspecie.BackColor = Color.Orange;
            btnAgregarEspecie.FlatAppearance.BorderSize = 0;
            btnAgregarEspecie.FlatStyle = FlatStyle.Flat;
            btnAgregarEspecie.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarEspecie.ForeColor = Color.White;
            btnAgregarEspecie.Location = new Point(365, 84);
            btnAgregarEspecie.Name = "btnAgregarEspecie";
            btnAgregarEspecie.Size = new Size(149, 34);
            btnAgregarEspecie.TabIndex = 4;
            btnAgregarEspecie.Text = "Agregar Especie";
            btnAgregarEspecie.UseVisualStyleBackColor = false;
            btnAgregarEspecie.Click += btnAgregarEspecie_Click;
            // 
            // EspeciesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 492);
            Controls.Add(btnAgregarEspecie);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvEspecies);
            Controls.Add(panelHeader);
            Name = "EspeciesForm";
            Text = "Especies";
            Load += EspeciesForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEspecies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
