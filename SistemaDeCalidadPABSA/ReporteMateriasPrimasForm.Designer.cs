using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaDeCalidadPABSA
{
    partial class ReporteMateriasPrimasForm
    {

        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitle;
        private DataGridView dgvResultados;
        private Button btnFiltrarInformacion;
        private ComboBox cmbProveedores;
        private ComboBox cmbIngredientes;
        private Label lblProveedor;
        private Label lblEspecie;
        private Label lblFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label lblBusqueda;
        private TextBox txtBusqueda;
        private Panel panelCharts;
        private FlowLayoutPanel flowLayoutPanelGraficas;
        private Chart chartProteina;
        private Chart chartGrasa;
        private Chart chartFibra;
        private Chart chartCeniza;
        private Chart chartHumedad;
        private Button btnPDF;

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            dgvResultados = new DataGridView();
            btnFiltrarInformacion = new Button();
            cmbProveedores = new ComboBox();
            cmbIngredientes = new ComboBox();
            lblProveedor = new Label();
            lblEspecie = new Label();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            lblBusqueda = new Label();
            txtBusqueda = new TextBox();
            panelCharts = new Panel();
            flowLayoutPanelGraficas = new FlowLayoutPanel();
            btnPDF = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            panelCharts.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Green;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(875, 75);
            panelHeader.TabIndex = 12;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(10, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(341, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Resultados de Análisis";
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(0, 188);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(875, 234);
            dgvResultados.TabIndex = 11;
            // 
            // btnFiltrarInformacion
            // 
            btnFiltrarInformacion.BackColor = Color.Orange;
            btnFiltrarInformacion.FlatAppearance.BorderSize = 0;
            btnFiltrarInformacion.FlatStyle = FlatStyle.Popup;
            btnFiltrarInformacion.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrarInformacion.ForeColor = Color.White;
            btnFiltrarInformacion.Location = new Point(548, 140);
            btnFiltrarInformacion.Name = "btnFiltrarInformacion";
            btnFiltrarInformacion.Size = new Size(140, 27);
            btnFiltrarInformacion.TabIndex = 10;
            btnFiltrarInformacion.Text = "Filtrar Información";
            btnFiltrarInformacion.UseVisualStyleBackColor = false;
            btnFiltrarInformacion.Click += btnFiltrarInformacion_Click;
            // 
            // cmbProveedores
            // 
            cmbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(98, 108);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(176, 23);
            cmbProveedores.TabIndex = 9;
            // 
            // cmbIngredientes
            // 
            cmbIngredientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIngredientes.FormattingEnabled = true;
            cmbIngredientes.Location = new Point(98, 141);
            cmbIngredientes.Name = "cmbIngredientes";
            cmbIngredientes.Size = new Size(176, 23);
            cmbIngredientes.TabIndex = 8;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(32, 111);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(63, 15);
            lblProveedor.TabIndex = 6;
            lblProveedor.Text = "Proveedor";
            // 
            // lblEspecie
            // 
            lblEspecie.AutoSize = true;
            lblEspecie.Location = new Point(26, 143);
            lblEspecie.Name = "lblEspecie";
            lblEspecie.Size = new Size(69, 15);
            lblEspecie.TabIndex = 4;
            lblEspecie.Text = "Ingrediente";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(301, 111);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(90, 15);
            lblFechaInicio.TabIndex = 7;
            lblFechaInicio.Text = "Fecha de inicio";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(301, 143);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(74, 15);
            lblFechaFin.TabIndex = 3;
            lblFechaFin.Text = "Fecha de fin";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(393, 108);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(132, 21);
            dtpFechaInicio.TabIndex = 5;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(393, 141);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(132, 21);
            dtpFechaFin.TabIndex = 1;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(557, 111);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(63, 15);
            lblBusqueda.TabIndex = 0;
            lblBusqueda.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(622, 108);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(176, 21);
            txtBusqueda.TabIndex = 2;
            // 
            // panelCharts
            // 
            panelCharts.AutoScroll = true;
            panelCharts.Controls.Add(flowLayoutPanelGraficas);
            panelCharts.Dock = DockStyle.Bottom;
            panelCharts.Location = new Point(0, 421);
            panelCharts.Name = "panelCharts";
            panelCharts.Size = new Size(875, 281);
            panelCharts.TabIndex = 13;
            // 
            // flowLayoutPanelGraficas
            // 
            flowLayoutPanelGraficas.AutoScroll = true;
            flowLayoutPanelGraficas.Dock = DockStyle.Fill;
            flowLayoutPanelGraficas.Location = new Point(0, 0);
            flowLayoutPanelGraficas.Name = "flowLayoutPanelGraficas";
            flowLayoutPanelGraficas.Size = new Size(875, 281);
            flowLayoutPanelGraficas.TabIndex = 0;
            // 
            // btnPDF
            // 
            btnPDF.BackColor = Color.ForestGreen;
            btnPDF.FlatAppearance.BorderSize = 0;
            btnPDF.FlatStyle = FlatStyle.Popup;
            btnPDF.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPDF.ForeColor = Color.White;
            btnPDF.Location = new Point(703, 141);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(140, 27);
            btnPDF.TabIndex = 14;
            btnPDF.Text = "Generar PDF";
            btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);

            // 
            // ReporteMateriasPrimasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 702);
            Controls.Add(btnPDF);
            Controls.Add(panelCharts);
            Controls.Add(lblBusqueda);
            Controls.Add(txtBusqueda);
            Controls.Add(lblFechaFin);
            Controls.Add(lblFechaInicio);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblEspecie);
            Controls.Add(lblProveedor);
            Controls.Add(cmbIngredientes);
            Controls.Add(cmbProveedores);
            Controls.Add(btnFiltrarInformacion);
            Controls.Add(dgvResultados);
            Controls.Add(panelHeader);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReporteMateriasPrimasForm";
            Text = "Resultados de Materias Primas";
            Load += ReporteMateriasPrimasForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            panelCharts.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }

}
