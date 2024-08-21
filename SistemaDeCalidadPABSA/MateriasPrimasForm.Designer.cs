namespace SistemaDeCalidadPABSA
{
    partial class MateriasPrimasForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnIngredientes;
        private System.Windows.Forms.Button btnAgregarAnalisis;
        private System.Windows.Forms.Button btnReporteMateriasPrimas;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnIngredientes = new System.Windows.Forms.Button();
            this.btnAgregarAnalisis = new System.Windows.Forms.Button();
            this.btnReporteMateriasPrimas = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Green;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(213, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Materias Primas";
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.Orange;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Location = new System.Drawing.Point(100, 120);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(400, 40);
            this.btnProveedores.TabIndex = 1;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.BackColor = System.Drawing.Color.Orange;
            this.btnIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredientes.ForeColor = System.Drawing.Color.White;
            this.btnIngredientes.Location = new System.Drawing.Point(100, 180);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Size = new System.Drawing.Size(400, 40);
            this.btnIngredientes.TabIndex = 2;
            this.btnIngredientes.Text = "Ingredientes";
            this.btnIngredientes.UseVisualStyleBackColor = false;
            this.btnIngredientes.Click += new System.EventHandler(this.btnIngredientes_Click);
            // 
            // btnAgregarAnalisis
            // 
            this.btnAgregarAnalisis.BackColor = System.Drawing.Color.Orange;
            this.btnAgregarAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAnalisis.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAnalisis.Location = new System.Drawing.Point(100, 240);
            this.btnAgregarAnalisis.Name = "btnAgregarAnalisis";
            this.btnAgregarAnalisis.Size = new System.Drawing.Size(400, 40);
            this.btnAgregarAnalisis.TabIndex = 3;
            this.btnAgregarAnalisis.Text = "Agregar Análisis de Materias Primas";
            this.btnAgregarAnalisis.UseVisualStyleBackColor = false;
            this.btnAgregarAnalisis.Click += new System.EventHandler(this.btnAgregarAnalisis_Click);
            // 
            // btnReporteMateriasPrimas
            // 
            this.btnReporteMateriasPrimas.BackColor = System.Drawing.Color.Orange;
            this.btnReporteMateriasPrimas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteMateriasPrimas.ForeColor = System.Drawing.Color.White;
            this.btnReporteMateriasPrimas.Location = new System.Drawing.Point(100, 300);
            this.btnReporteMateriasPrimas.Name = "btnReporteMateriasPrimas";
            this.btnReporteMateriasPrimas.Size = new System.Drawing.Size(400, 40);
            this.btnReporteMateriasPrimas.TabIndex = 4;
            this.btnReporteMateriasPrimas.Text = "Reporte de Materias Primas";
            this.btnReporteMateriasPrimas.UseVisualStyleBackColor = false;
            this.btnReporteMateriasPrimas.Click += new System.EventHandler(this.btnReporteMateriasPrimas_Click);
            // 
            // MateriasPrimasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnReporteMateriasPrimas);
            this.Controls.Add(this.btnAgregarAnalisis);
            this.Controls.Add(this.btnIngredientes);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MateriasPrimasForm";
            this.Text = "Materias Primas";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
