using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaDeCalidadPABSA
{
    partial class ResultadosAnalisisForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitle;
        private DataGridView dgvResultados;
        private Button btnFiltrarInformacion;
        private ComboBox cmbProductos;
        private ComboBox cmbEspecies;
        private ComboBox cmbPlanta;
        private Label lblProducto;
        private Label lblFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label lblBusqueda;
        private TextBox txtBusqueda;
        private Panel panelCharts; // Panel de graficas
        private FlowLayoutPanel flowLayoutPanelGraficas;
        private Chart chartProteina;
        private Chart chartGrasa;
        private Chart chartFibra;
        private Chart chartCeniza;
        private Chart chartHumedad;

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            dgvResultados = new DataGridView();
            btnFiltrarInformacion = new Button();
            cmbProductos = new ComboBox();
            cmbEspecies = new ComboBox();
            lblProducto = new Label();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            lblBusqueda = new Label();
            txtBusqueda = new TextBox();
            panelCharts = new Panel();
            flowLayoutPanelGraficas = new FlowLayoutPanel();
            btnPDF = new Button();
            lblEspecie = new Label();
            cmbPlanta = new ComboBox();
            lblPlanta = new Label();
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
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(0, 188);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(875, 234);
            dgvResultados.TabIndex = 11;
            dgvResultados.CellEndEdit += dgvResultados_CellEndEdit;
            // 
            // btnFiltrarInformacion
            // 
            btnFiltrarInformacion.BackColor = Color.Orange;
            btnFiltrarInformacion.FlatAppearance.BorderSize = 0;
            btnFiltrarInformacion.FlatStyle = FlatStyle.Popup;
            btnFiltrarInformacion.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrarInformacion.ForeColor = Color.White;
            btnFiltrarInformacion.Location = new Point(538, 140);
            btnFiltrarInformacion.Name = "btnFiltrarInformacion";
            btnFiltrarInformacion.Size = new Size(140, 27);
            btnFiltrarInformacion.TabIndex = 10;
            btnFiltrarInformacion.Text = "Filtrar Información";
            btnFiltrarInformacion.UseVisualStyleBackColor = false;
            btnFiltrarInformacion.Click += btnFiltrarInformacion_Click;
            // 
            // cmbProductos
            // 
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(88, 89);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(176, 23);
            cmbProductos.TabIndex = 9;
            // 
            // cmbEspecies
            // 
            cmbEspecies.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecies.FormattingEnabled = true;
            cmbEspecies.Location = new Point(88, 122);
            cmbEspecies.Name = "cmbEspecies";
            cmbEspecies.Size = new Size(176, 23);
            cmbEspecies.TabIndex = 8;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(26, 92);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(56, 15);
            lblProducto.TabIndex = 6;
            lblProducto.Text = "Producto";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(291, 111);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(86, 15);
            lblFechaInicio.TabIndex = 7;
            lblFechaInicio.Text = "Fecha de inicio";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(291, 143);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(71, 15);
            lblFechaFin.TabIndex = 3;
            lblFechaFin.Text = "Fecha de fin";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(383, 108);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(132, 23);
            dtpFechaInicio.TabIndex = 5;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(383, 141);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(132, 23);
            dtpFechaFin.TabIndex = 1;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(547, 111);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(59, 15);
            lblBusqueda.TabIndex = 0;
            lblBusqueda.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(612, 108);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(176, 23);
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
            btnPDF.Location = new Point(693, 141);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(140, 27);
            btnPDF.TabIndex = 14;
            btnPDF.Text = "Descargar PDF";
            btnPDF.UseVisualStyleBackColor = false;
            btnPDF.Click += btnPDF_Click;
            // 
            // lblEspecie
            // 
            lblEspecie.AutoSize = true;
            lblEspecie.Location = new Point(26, 124);
            lblEspecie.Name = "lblEspecie";
            lblEspecie.Size = new Size(46, 15);
            lblEspecie.TabIndex = 4;
            lblEspecie.Text = "Especie";
            // 
            // cmbPlanta
            // 
            cmbPlanta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlanta.FormattingEnabled = true;
            cmbPlanta.Location = new Point(88, 154);
            cmbPlanta.Name = "cmbPlanta";
            cmbPlanta.Size = new Size(176, 23);
            cmbPlanta.TabIndex = 15;
            // 
            // lblPlanta
            // 
            lblPlanta.AutoSize = true;
            lblPlanta.Location = new Point(26, 157);
            lblPlanta.Name = "lblPlanta";
            lblPlanta.Size = new Size(40, 15);
            lblPlanta.TabIndex = 16;
            lblPlanta.Text = "Planta";
            // 
            // ResultadosAnalisisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 702);
            Controls.Add(lblPlanta);
            Controls.Add(cmbPlanta);
            Controls.Add(btnPDF);
            Controls.Add(panelCharts);
            Controls.Add(lblBusqueda);
            Controls.Add(dtpFechaFin);
            Controls.Add(txtBusqueda);
            Controls.Add(lblFechaFin);
            Controls.Add(lblEspecie);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblProducto);
            Controls.Add(lblFechaInicio);
            Controls.Add(cmbEspecies);
            Controls.Add(cmbProductos);
            Controls.Add(btnFiltrarInformacion);
            Controls.Add(dgvResultados);
            Controls.Add(panelHeader);
            Name = "ResultadosAnalisisForm";
            Text = "Resultados de Análisis";
            Load += ResultadosAnalisisForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            panelCharts.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnPDF;
        private Label lblEspecie;
        private Label lblPlanta;
    }
}