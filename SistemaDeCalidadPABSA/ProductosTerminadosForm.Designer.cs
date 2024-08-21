namespace SistemaDeCalidadPABSA
{
    partial class ProductosTerminadosForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEspecies;
        private System.Windows.Forms.Button btnProductosTerminados;
        private System.Windows.Forms.Button btnAgregarAnalisisProducto;
        private System.Windows.Forms.Button btnResultadosAnalisis;

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
            this.btnEspecies = new System.Windows.Forms.Button();
            this.btnProductosTerminados = new System.Windows.Forms.Button();
            this.btnAgregarAnalisisProducto = new System.Windows.Forms.Button();
            this.btnResultadosAnalisis = new System.Windows.Forms.Button();
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
            this.lblTitle.Size = new System.Drawing.Size(335, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Productos Terminados";
            // 
            // btnEspecies
            // 
            this.btnEspecies.BackColor = System.Drawing.Color.Orange;
            this.btnEspecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecies.ForeColor = System.Drawing.Color.White;
            this.btnEspecies.Location = new System.Drawing.Point(100, 120);
            this.btnEspecies.Name = "btnEspecies";
            this.btnEspecies.Size = new System.Drawing.Size(400, 40);
            this.btnEspecies.TabIndex = 1;
            this.btnEspecies.Text = "Especies";
            this.btnEspecies.UseVisualStyleBackColor = false;
            this.btnEspecies.Click += new System.EventHandler(this.btnEspecies_Click);
            // 
            // btnProductosTerminados
            // 
            this.btnProductosTerminados.BackColor = System.Drawing.Color.Orange;
            this.btnProductosTerminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductosTerminados.ForeColor = System.Drawing.Color.White;
            this.btnProductosTerminados.Location = new System.Drawing.Point(100, 180);
            this.btnProductosTerminados.Name = "btnProductosTerminados";
            this.btnProductosTerminados.Size = new System.Drawing.Size(400, 40);
            this.btnProductosTerminados.TabIndex = 2;
            this.btnProductosTerminados.Text = "Productos Terminados";
            this.btnProductosTerminados.UseVisualStyleBackColor = false;
            this.btnProductosTerminados.Click += new System.EventHandler(this.btnProductosTerminados_Click);
            // 
            // btnAgregarAnalisisProducto
            // 
            this.btnAgregarAnalisisProducto.BackColor = System.Drawing.Color.Orange;
            this.btnAgregarAnalisisProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAnalisisProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAnalisisProducto.Location = new System.Drawing.Point(100, 240);
            this.btnAgregarAnalisisProducto.Name = "btnAgregarAnalisisProducto";
            this.btnAgregarAnalisisProducto.Size = new System.Drawing.Size(400, 40);
            this.btnAgregarAnalisisProducto.TabIndex = 3;
            this.btnAgregarAnalisisProducto.Text = "Agregar Análisis de Producto";
            this.btnAgregarAnalisisProducto.UseVisualStyleBackColor = false;
            this.btnAgregarAnalisisProducto.Click += new System.EventHandler(this.btnAgregarAnalisisProducto_Click);
            // 
            // btnResultadosAnalisis
            // 
            this.btnResultadosAnalisis.BackColor = System.Drawing.Color.Orange;
            this.btnResultadosAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResultadosAnalisis.ForeColor = System.Drawing.Color.White;
            this.btnResultadosAnalisis.Location = new System.Drawing.Point(100, 300);
            this.btnResultadosAnalisis.Name = "btnResultadosAnalisis";
            this.btnResultadosAnalisis.Size = new System.Drawing.Size(400, 40);
            this.btnResultadosAnalisis.TabIndex = 4;
            this.btnResultadosAnalisis.Text = "Ver Resultados de Análisis";
            this.btnResultadosAnalisis.UseVisualStyleBackColor = false;
            this.btnResultadosAnalisis.Click += new System.EventHandler(this.btnResultadosAnalisis_Click);
            // 
            // ProductosTerminadosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnResultadosAnalisis);
            this.Controls.Add(this.btnAgregarAnalisisProducto);
            this.Controls.Add(this.btnProductosTerminados);
            this.Controls.Add(this.btnEspecies);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProductosTerminadosForm";
            this.Text = "Productos Terminados";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
