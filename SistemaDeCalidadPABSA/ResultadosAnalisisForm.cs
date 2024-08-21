using System;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Geom;

namespace SistemaDeCalidadPABSA
{
    public partial class ResultadosAnalisisForm : Form
    {
        private readonly string _connectionString;
        private readonly Dictionary<string, string> _columnMappings;
        private DataTable _currentDataTable; // Campo de clase para almacenar el DataTable actual

        public ResultadosAnalisisForm()
        {
            InitializeComponent();
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _columnMappings = InitializeColumnMappings();
        }

        private Dictionary<string, string> InitializeColumnMappings()
        {
            return new Dictionary<string, string>
            {
                { "Proteína", "Proteina" },
                { "Grasa", "Grasa" },
                { "Fibra", "Fibra" },
                { "Cenizas", "Cenizas" },
                { "Humedad", "Humedad" },
                { "Proteína Garantía", "ProteinaGarantia" },
                { "Grasa Garantía", "GrasaGarantia" },
                { "Fibra Garantía", "FibraGarantia" },
                { "Cenizas Garantía", "CenizasGarantia" },
                { "Humedad Garantía", "HumedadGarantia" }
            };
        }

        private async void ResultadosAnalisisForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync();
                SetInitialFilter();
            }
            catch (Exception ex)
            {
                ShowError("Error loading data", ex);
            }
        }

        private async Task LoadDataAsync()
        {
            await Task.WhenAll(LoadProductsAsync(), LoadSpeciesAsync(), LoadPlantaAsync());
        }

        private void SetInitialFilter()
        {
            if (cmbProductos.SelectedIndex != -1 && cmbEspecies.SelectedIndex != -1 && cmbPlanta.SelectedIndex != -1 )
            {
                _ = LoadResultsAsync(
                    cmbProductos.Text,
                    cmbEspecies.Text,
                    cmbPlanta.Text,
                    dtpFechaInicio.Value.Date,
                    GetEndOfDay(dtpFechaFin.Value),
                    txtBusqueda.Text);
            }
        }

        private async Task LoadProductsAsync()
        {
            await LoadComboBoxDataAsync("SELECT ProductoID, Nombre FROM Productos", cmbProductos, "ProductoID");
        }
        private async Task LoadPlantaAsync()
        {
            await LoadComboBoxDataAsync("SELECT PlantaID, Nombre FROM Planta", cmbPlanta, "PlantaID");
        }

        private async Task LoadSpeciesAsync()
        {
            await LoadComboBoxDataAsync("SELECT EspecieID, Nombre FROM Especies", cmbEspecies, "EspecieID");
        }

        private async Task LoadComboBoxDataAsync(string query, ComboBox comboBox, string valueMember)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    await Task.Run(() => dataAdapter.Fill(dataTable));
                    comboBox.DisplayMember = "Nombre";
                    comboBox.ValueMember = valueMember;
                    comboBox.DataSource = dataTable;
                    comboBox.SelectedIndex = dataTable.Rows.Count > 0 ? 0 : -1;
                }
            }
            catch (SqlException ex)
            {
                ShowError("Error loading data into comboBox", ex);
            }
        }

        private DateTime GetEndOfDay(DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }

        private async void btnFiltrarInformacion_Click(object sender, EventArgs e)
        {
            if (ValidateSelection())
            {
                await LoadResultsAsync(
                    cmbProductos.Text,
                    cmbEspecies.Text,
                    cmbPlanta.Text,
                    dtpFechaInicio.Value.Date,
                    GetEndOfDay(dtpFechaFin.Value),
                    txtBusqueda.Text);
            }
        }

        private bool ValidateSelection()
        {
            if (cmbProductos.SelectedIndex == -1 || cmbEspecies.SelectedIndex == -1 || cmbPlanta.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product and a species.");
                return false;
            }
            return true;
        }

      private async Task LoadResultsAsync(string product, string species, string plantaName, DateTime startDate, DateTime endDate, string searchTerm)
{
    const string query = @"
        SELECT *
        FROM vw_AnalisisProductoConGarantias
        WHERE 
            Producto = @Producto
            AND Especie = @Especie
            AND [Nombre Planta] = @PlantaNombre -- Asegúrate de usar el nombre correcto del campo
            AND Fecha >= @FechaInicio
            AND Fecha <= @FechaFin
            AND (Producto LIKE @Busqueda OR Especie LIKE @Busqueda)";

    try
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Producto", product);
            command.Parameters.AddWithValue("@Especie", species);
            command.Parameters.AddWithValue("@PlantaNombre", plantaName); // Cambia aquí a PlantaNombre
            command.Parameters.AddWithValue("@FechaInicio", startDate);
            command.Parameters.AddWithValue("@FechaFin", endDate);
            command.Parameters.AddWithValue("@Busqueda", $"%{searchTerm}%");

            _currentDataTable = new DataTable(); // Guarda el DataTable en un campo de clase
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                await Task.Run(() => dataAdapter.Fill(_currentDataTable));
            }
            dgvResultados.DataSource = _currentDataTable;
            UpdateCharts(_currentDataTable); // Actualiza los gráficos con los datos
        }
    }
    catch (SqlException ex)
    {
        ShowError("Error loading results", ex);
    }
}

        private void UpdateCharts(DataTable dataTable)
        {
            // Limpia los gráficos antes de agregar nuevos datos
            panelCharts.Controls.Clear();

            // Crea y configura gráficos para cada tipo de análisis, en orden inverso
            Chart chartHumedad = CreateChart("Humedad");
            Chart chartCeniza = CreateChart("Cenizas");
            Chart chartFibra = CreateChart("Fibra");
            Chart chartGrasa = CreateChart("Grasa");
            Chart chartProteina = CreateChart("Proteína");

            // Configura los gráficos
            ConfigureChart(chartHumedad, "Humedad");
            ConfigureChart(chartCeniza, "Cenizas");
            ConfigureChart(chartFibra, "Fibra");
            ConfigureChart(chartGrasa, "Grasa");
            ConfigureChart(chartProteina, "Proteína");

            // Llena los gráficos con los datos del DataTable, incluyendo las garantías
            FillChart(chartHumedad, dataTable, "Humedad", "Humedad Garantía", "Fecha");
            FillChart(chartCeniza, dataTable, "Cenizas", "Cenizas Garantía", "Fecha");
            FillChart(chartFibra, dataTable, "Fibra", "Fibra Garantía", "Fecha");
            FillChart(chartGrasa, dataTable, "Grasa", "Grasa Garantía", "Fecha");
            FillChart(chartProteina, dataTable, "Proteína", "Proteína Garantía", "Fecha");

            // Asigna los gráficos al panel en orden inverso
            panelCharts.Controls.Add(chartHumedad);
            panelCharts.Controls.Add(chartCeniza);
            panelCharts.Controls.Add(chartFibra);
            panelCharts.Controls.Add(chartGrasa);
            panelCharts.Controls.Add(chartProteina);
        }

        private void ConfigureChart(Chart chart, string title)
        {
            // Configurar el título del gráfico
            chart.Titles.Clear();
            chart.Titles.Add(new Title
            {
                Text = title,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Black
            });

            // Configurar los ejes X e Y
            chart.ChartAreas[0].AxisX.Title = "Fecha";
            chart.ChartAreas[0].AxisY.Title = "Valor";

            // Configurar las series del gráfico
            foreach (var series in chart.Series)
            {
                series.BorderWidth = 3; // Aumenta el grosor de la línea
                series.MarkerStyle = MarkerStyle.Circle; // Añade un marcador en cada punto de datos
                series.MarkerSize = 8; // Tamaño del marcador
                series.MarkerColor = Color.Black; // Color del marcador
            }
        }



        private Chart CreateChart(string title)
        {
            Chart chart = new Chart
            {
                Dock = DockStyle.Top,
                ChartAreas = { new ChartArea() },
                Legends = { new Legend() { Name = title } },
                Series = { new Series() { Name = title, ChartType = SeriesChartType.Line } }
            };

            chart.Titles.Add(title);
            return chart;
        }

        private void FillChart(Chart chart, DataTable dataTable, string valueColumn, string guaranteeColumn, string xColumn)
        {
            // Limpia las series antes de agregar nuevos datos
            chart.Series.Clear();

            // Crea y configura la serie para los valores reales
            Series valueSeries = new Series("Valor Real")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.Black
            };
            chart.Series.Add(valueSeries);

            // Crea y configura la serie para las garantías
            Series guaranteeSeries = new Series("Garantía")
            {
                ChartType = SeriesChartType.Line,
                BorderDashStyle = ChartDashStyle.Dash, // Líneas punteadas para las garantías
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.Red
            };
            chart.Series.Add(guaranteeSeries);

            // Crea y configura la serie para la desviación
            Series deviationSeries = new Series("Desviación")
            {
                ChartType = SeriesChartType.Line,
                BorderDashStyle = ChartDashStyle.Dot,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.Blue
            };
            chart.Series.Add(deviationSeries);

            // Llena las series con los datos del DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                double value = Convert.ToDouble(row[valueColumn]);
                double guarantee = Convert.ToDouble(row[guaranteeColumn]);
                double deviation = value - guarantee;

                valueSeries.Points.AddXY(row[xColumn], value);
                guaranteeSeries.Points.AddXY(row[xColumn], guarantee);
                deviationSeries.Points.AddXY(row[xColumn], deviation);
            }
        }



        private async void dgvResultados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow row = dgvResultados.Rows[e.RowIndex];
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    string visibleColumnName = dgvResultados.Columns[e.ColumnIndex].HeaderText;
                    object newValue = row.Cells[e.ColumnIndex].Value;

                    string columnName = _columnMappings.ContainsKey(visibleColumnName)
                        ? _columnMappings[visibleColumnName]
                        : visibleColumnName;

                    await UpdateProductAnalysisAsync(id, columnName, newValue);

                    // Recargar los datos y actualizar las gráficas después de la edición
                    await LoadResultsAsync(
                        cmbProductos.Text,
                        cmbEspecies.Text,
                        cmbPlanta.Text,
                        dtpFechaInicio.Value.Date,
                        GetEndOfDay(dtpFechaFin.Value),
                        txtBusqueda.Text);
                }
            }
            catch (Exception ex)
            {
                ShowError("Error updating value", ex);
            }
        }

        private async Task UpdateProductAnalysisAsync(int id, string columnName, object newValue)
        {
            string query = columnName.EndsWith("Garantia")
                ? $@"UPDATE Productos 
                     SET {columnName} = @Value 
                     WHERE ProductoID = (SELECT ProductoID FROM AnalisisProducto WHERE AnalisisProductoID = @ID)"
                : $@"UPDATE AnalisisProducto 
                     SET {columnName} = @Value 
                     WHERE AnalisisProductoID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", newValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ID", id);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex)
            {
                ShowError("Error updating database", ex);
            }
        }



        private async void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Define la ruta completa del archivo PDF en el escritorio con fecha actual
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"ResultadosAnalisis_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = System.IO.Path.Combine(desktopPath, fileName);

                // Crea el documento PDF con orientación horizontal (landscape)
                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, PageSize.A4.Rotate()); // Rotar la página para que sea horizontal

                    // Agrega el encabezado
                    Paragraph header = new Paragraph("Resultados de Análisis")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(24)
                        .SetBold();
                    document.Add(header);

                    // Agrega un espacio después del encabezado
                    document.Add(new Paragraph("\n"));

                    // Define una tabla con 5 columnas, cada una con un ancho igual
                    Table chartTable = new Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth();

                    foreach (Control control in panelCharts.Controls)
                    {
                        if (control is Chart chart)
                        {
                            // Guarda el gráfico como imagen temporalmente
                            string chartImagePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".png");
                            SaveChartAsImage(chart, chartImagePath);

                            // Crea una imagen y ajusta su tamaño para que se adapte a la celda de la tabla
                            iText.Layout.Element.Image chartImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(chartImagePath));
                            chartImage.SetAutoScale(true);

                            // Agrega la imagen a una celda de la tabla
                            Cell cell = new Cell().Add(chartImage);
                            chartTable.AddCell(cell);

                            // Elimina la imagen temporal
                            System.IO.File.Delete(chartImagePath);
                        }
                    }

                    // Agrega la tabla de gráficos al documento
                    document.Add(chartTable);

                    // Agrega un espacio entre las gráficas y la tabla
                    document.Add(new Paragraph("\n"));

                    // Crea la tabla horizontal a partir del DataTable
                    Table dataTable = CreateHorizontalTableFromDataTable(_currentDataTable);

                    // Agrega la tabla de datos al documento, justo debajo de las gráficas
                    document.Add(dataTable);

                    // Cierra el documento
                    document.Close();
                }

                MessageBox.Show($"PDF creado exitosamente en el escritorio: {filePath}");
            }
            catch (Exception ex)
            {
                ShowError("Error creando el PDF", ex);
            }
        }


        private Table CreateHorizontalTableFromDataTable(DataTable dataTable)
        {
            int columnCount = dataTable.Columns.Count;
            int rowCount = dataTable.Rows.Count;

            // Crea una tabla con el número de columnas del DataTable
            Table table = new Table(UnitValue.CreatePercentArray(columnCount)).UseAllAvailableWidth();

            // Añade los encabezados
            for (int i = 0; i < columnCount; i++)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(dataTable.Columns[i].ColumnName).SetBold()));
            }

            // Añade las filas correspondientes
            for (int j = 0; j < rowCount; j++)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    string cellValue = Convert.IsDBNull(dataTable.Rows[j][i]) ? string.Empty : dataTable.Rows[j][i].ToString();
                    table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                }
            }

            return table;
        }


        private void SaveChartAsImage(Chart chart, string filePath)
        {
            // Guarda el gráfico como imagen PNG
            chart.SaveImage(filePath, ChartImageFormat.Png);
        }



        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}