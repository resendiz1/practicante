namespace SistemaDeCalidadPABSA
{
    partial class IngredientesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnAgregarIngrediente;

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
            panelHeader = new Panel();
            lblTitle = new Label();
            dgvIngredientes = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnAgregarIngrediente = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredientes).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(514, 69);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(176, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ingredientes";
            // 
            // dgvIngredientes
            // 
            dgvIngredientes.columns['nombre_columna'].headerText = "Nombre corto"
            dgvIngredientes.AllowUserToAddRows = false;
            dgvIngredientes.AllowUserToDeleteRows = false;
            dgvIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredientes.Dock = DockStyle.Bottom;
            dgvIngredientes.Location = new Point(0, 157);
            dgvIngredientes.Name = "dgvIngredientes";
            dgvIngredientes.ReadOnly = true;
            dgvIngredientes.Size = new Size(514, 293);
            dgvIngredientes.TabIndex = 1;
            dgvIngredientes.CellClick += dgvIngredientes_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(82, 84);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(165, 23);
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
            // btnAgregarIngrediente
            // 
            btnAgregarIngrediente.BackColor = Color.Orange;
            btnAgregarIngrediente.FlatAppearance.BorderSize = 0;
            btnAgregarIngrediente.FlatStyle = FlatStyle.Flat;
            btnAgregarIngrediente.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarIngrediente.ForeColor = Color.White;
            btnAgregarIngrediente.Location = new Point(339, 84);
            btnAgregarIngrediente.Name = "btnAgregarIngrediente";
            btnAgregarIngrediente.Size = new Size(163, 32);
            btnAgregarIngrediente.TabIndex = 4;
            btnAgregarIngrediente.Text = "Agregar Ingrediente";
            btnAgregarIngrediente.UseVisualStyleBackColor = false;
            btnAgregarIngrediente.Click += btnAgregarIngrediente_Click;
            // 
            // IngredientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 450);
            Controls.Add(btnAgregarIngrediente);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvIngredientes);
            Controls.Add(panelHeader);
            Name = "IngredientesForm";
            Text = "Ingredientes";
            Load += IngredientesForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
