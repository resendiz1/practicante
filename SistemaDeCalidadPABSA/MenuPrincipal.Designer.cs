namespace SistemaDeCalidadPABSA
{
    partial class MenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnProductosTerminados;
        private System.Windows.Forms.Button btnMateriasPrimas;
        private System.Windows.Forms.Button btnUsuarios;

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
            this.btnProductosTerminados = new System.Windows.Forms.Button();
            this.btnMateriasPrimas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
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
            this.lblTitle.Size = new System.Drawing.Size(183, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Menú Principal";
            // 
            // btnProductosTerminados
            // 
            this.btnProductosTerminados.BackColor = System.Drawing.Color.Orange;
            this.btnProductosTerminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductosTerminados.ForeColor = System.Drawing.Color.White;
            this.btnProductosTerminados.Location = new System.Drawing.Point(100, 120);
            this.btnProductosTerminados.Name = "btnProductosTerminados";
            this.btnProductosTerminados.Size = new System.Drawing.Size(400, 40);
            this.btnProductosTerminados.TabIndex = 1;
            this.btnProductosTerminados.Text = "Productos Terminados";
            this.btnProductosTerminados.UseVisualStyleBackColor = false;
            this.btnProductosTerminados.Click += new System.EventHandler(this.btnProductosTerminados_Click);
            // 
            // btnMateriasPrimas
            // 
            this.btnMateriasPrimas.BackColor = System.Drawing.Color.Orange;
            this.btnMateriasPrimas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMateriasPrimas.ForeColor = System.Drawing.Color.White;
            this.btnMateriasPrimas.Location = new System.Drawing.Point(100, 180);
            this.btnMateriasPrimas.Name = "btnMateriasPrimas";
            this.btnMateriasPrimas.Size = new System.Drawing.Size(400, 40);
            this.btnMateriasPrimas.TabIndex = 2;
            this.btnMateriasPrimas.Text = "Materias Primas";
            this.btnMateriasPrimas.UseVisualStyleBackColor = false;
            this.btnMateriasPrimas.Click += new System.EventHandler(this.btnMateriasPrimas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.Orange;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(100, 240);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(400, 40);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnMateriasPrimas);
            this.Controls.Add(this.btnProductosTerminados);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.Text = "Menú Principal";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
