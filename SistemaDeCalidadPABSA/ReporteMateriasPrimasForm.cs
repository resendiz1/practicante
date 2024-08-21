using System.Data;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;

namespace SistemaDeCalidadPABSA
{
    public partial class ReporteMateriasPrimasForm : Form
    {
        private readonly string _connectionString;
        private DataTable _currentDataTable;

        public ReporteMateriasPrimasForm()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            dgvResultados.CellEndEdit += dgvResultados_CellEndEdit;
            dgvResultados.CellClick += dgvResultados_CellClick;
        }

        private async void ReporteMateriasPrimasForm_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(CargarProveedoresAsync(), CargarIngredientesAsync());
        }

        private async void btnFiltrarInformacion_Click(object sender, EventArgs e)
        {
            await FiltrarResultadosAsync();
        }

        private async Task CargarDatosAsync(string query, ComboBox comboBox, string displayMember, string valueMember)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                await con.OpenAsync();
                using var cmd = new SqlCommand(query, con);
                using var reader = await cmd.ExecuteReaderAsync();
                var dt = new DataTable();
                dt.Load(reader);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar datos", ex);
            }
        }

        private Task CargarProveedoresAsync() =>
            CargarDatosAsync("SELECT ProveedorID, Nombre FROM Proveedores", cmbProveedores, "Nombre", "ProveedorID");

        private Task CargarIngredientesAsync() =>
            CargarDatosAsync("SELECT IngredienteID, Nombre FROM Ingredientes", cmbIngredientes, "Nombre", "IngredienteID");

        private async Task FiltrarResultadosAsync()
        {
            int? proveedorID = cmbProveedores.SelectedValue as int?;
            int? ingredienteID = cmbIngredientes.SelectedValue as int?;
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            string busqueda = txtBusqueda.Text.Trim();

            var queryBuilder = new StringBuilder(@"
SELECT 
    MatPrimID, 
    ProveedorNombre, 
    IngredienteNombre,
    Fecha,
    ProteinaNIR, ProteinaLAB, ProteinaPROM,
    GrasaNIR, GrasaLAB, GrasaPROM,
    FibraNIR, FibraLAB, FibraPROM,
    CenizasNIR, CenizasLAB, CenizasPROM,
    HumedadNIR, HumedadLAB, HumedadPROM,
    CalcioNIR, CalcioLAB, CalcioPROM,
    FosforoNIR, FosforoLAB, FosforoPROM
FROM 
    VistaMateriasPrimas
WHERE 1 = 1");

            if (proveedorID.HasValue)
                queryBuilder.Append(" AND ProveedorID = @ProveedorID");

            if (ingredienteID.HasValue)
                queryBuilder.Append(" AND IngredienteID = @IngredienteID");

            queryBuilder.Append(" AND Fecha BETWEEN @FechaInicio AND @FechaFin");

            if (!string.IsNullOrEmpty(busqueda))
                queryBuilder.Append(" AND (ProteinaPROM LIKE @Busqueda OR GrasaPROM LIKE @Busqueda OR FibraPROM LIKE @Busqueda OR CenizasPROM LIKE @Busqueda OR HumedadPROM LIKE @Busqueda)");

            string query = queryBuilder.ToString();

            try
            {
                using var con = new SqlConnection(_connectionString);
                await con.OpenAsync();
                using var cmd = new SqlCommand(query, con);
                if (proveedorID.HasValue)
                    cmd.Parameters.AddWithValue("@ProveedorID", proveedorID.Value);

                if (ingredienteID.HasValue)
                    cmd.Parameters.AddWithValue("@IngredienteID", ingredienteID.Value);

                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");

                using var reader = await cmd.ExecuteReaderAsync();
                _currentDataTable = new DataTable();
                _currentDataTable.Load(reader);

                // Realiza los cálculos para cada fila y agrega las columnas calculadas
                _currentDataTable.Columns.Add("ProteinaPromedio", typeof(decimal));
                _currentDataTable.Columns.Add("ProteinaDesvEstandar", typeof(decimal));
                _currentDataTable.Columns.Add("ProteinaPromedioCorregido", typeof(decimal));
                _currentDataTable.Columns.Add("ProteinaPromMasMedDesvEstandar", typeof(decimal));

                // Asegúrate de agregar las columnas antes de realizar cálculos
                if (!_currentDataTable.Columns.Contains("ProteinaPromedio"))
                    _currentDataTable.Columns.Add("ProteinaPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("ProteinaDesvEstandar"))
                    _currentDataTable.Columns.Add("ProteinaDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("ProteinaPromedioCorregido"))
                    _currentDataTable.Columns.Add("ProteinaPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("ProteinaPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("ProteinaPromMasMedDesvEstandar", typeof(decimal));

                // Repite para las demás columnas
                if (!_currentDataTable.Columns.Contains("GrasaPromedio"))
                    _currentDataTable.Columns.Add("GrasaPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("GrasaDesvEstandar"))
                    _currentDataTable.Columns.Add("GrasaDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("GrasaPromedioCorregido"))
                    _currentDataTable.Columns.Add("GrasaPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("GrasaPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("GrasaPromMasMedDesvEstandar", typeof(decimal));

                if (!_currentDataTable.Columns.Contains("FibraPromedio"))
                    _currentDataTable.Columns.Add("FibraPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("FibraDesvEstandar"))
                    _currentDataTable.Columns.Add("FibraDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("FibraPromedioCorregido"))
                    _currentDataTable.Columns.Add("FibraPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("FibraPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("FibraPromMasMedDesvEstandar", typeof(decimal));

                if (!_currentDataTable.Columns.Contains("CenizasPromedio"))
                    _currentDataTable.Columns.Add("CenizasPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("CenizasDesvEstandar"))
                    _currentDataTable.Columns.Add("CenizasDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("CenizasPromedioCorregido"))
                    _currentDataTable.Columns.Add("CenizasPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("CenizasPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("CenizasPromMasMedDesvEstandar", typeof(decimal));

                if (!_currentDataTable.Columns.Contains("HumedadPromedio"))
                    _currentDataTable.Columns.Add("HumedadPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("HumedadDesvEstandar"))
                    _currentDataTable.Columns.Add("HumedadDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("HumedadPromedioCorregido"))
                    _currentDataTable.Columns.Add("HumedadPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("HumedadPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("HumedadPromMasMedDesvEstandar", typeof(decimal));

                if (!_currentDataTable.Columns.Contains("CalcioPromedio"))
                    _currentDataTable.Columns.Add("CalcioPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("CalcioDesvEstandar"))
                    _currentDataTable.Columns.Add("CalcioDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("CalcioPromedioCorregido"))
                    _currentDataTable.Columns.Add("CalcioPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("CalcioPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("CalcioPromMasMedDesvEstandar", typeof(decimal));

                if (!_currentDataTable.Columns.Contains("FosforoPromedio"))
                    _currentDataTable.Columns.Add("FosforoPromedio", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("FosforoDesvEstandar"))
                    _currentDataTable.Columns.Add("FosforoDesvEstandar", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("FosforoPromedioCorregido"))
                    _currentDataTable.Columns.Add("FosforoPromedioCorregido", typeof(decimal));
                if (!_currentDataTable.Columns.Contains("FosforoPromMasMedDesvEstandar"))
                    _currentDataTable.Columns.Add("FosforoPromMasMedDesvEstandar", typeof(decimal));



                foreach (DataRow row in _currentDataTable.Rows)
                {
                    // Convertir los valores a decimal si es posible
                    decimal proteinaNIR = Convert.ToDecimal(row["ProteinaNIR"] is DBNull ? 0 : row["ProteinaNIR"]);
                    decimal proteinaLAB = Convert.ToDecimal(row["ProteinaLAB"] is DBNull ? 0 : row["ProteinaLAB"]);
                    decimal proteinaPROM = Convert.ToDecimal(row["ProteinaPROM"] is DBNull ? 0 : row["ProteinaPROM"]);

                    decimal grasaNIR = Convert.ToDecimal(row["GrasaNIR"] is DBNull ? 0 : row["GrasaNIR"]);
                    decimal grasaLAB = Convert.ToDecimal(row["GrasaLAB"] is DBNull ? 0 : row["GrasaLAB"]);
                    decimal grasaPROM = Convert.ToDecimal(row["GrasaPROM"] is DBNull ? 0 : row["GrasaPROM"]);

                    decimal fibraNIR = Convert.ToDecimal(row["FibraNIR"] is DBNull ? 0 : row["FibraNIR"]);
                    decimal fibraLAB = Convert.ToDecimal(row["FibraLAB"] is DBNull ? 0 : row["FibraLAB"]);
                    decimal fibraPROM = Convert.ToDecimal(row["FibraPROM"] is DBNull ? 0 : row["FibraPROM"]);

                    decimal cenizasNIR = Convert.ToDecimal(row["CenizasNIR"] is DBNull ? 0 : row["CenizasNIR"]);
                    decimal cenizasLAB = Convert.ToDecimal(row["CenizasLAB"] is DBNull ? 0 : row["CenizasLAB"]);
                    decimal cenizasPROM = Convert.ToDecimal(row["CenizasPROM"] is DBNull ? 0 : row["CenizasPROM"]);

                    decimal humedadNIR = Convert.ToDecimal(row["HumedadNIR"] is DBNull ? 0 : row["HumedadNIR"]);
                    decimal humedadLAB = Convert.ToDecimal(row["HumedadLAB"] is DBNull ? 0 : row["HumedadLAB"]);
                    decimal humedadPROM = Convert.ToDecimal(row["HumedadPROM"] is DBNull ? 0 : row["HumedadPROM"]);

                    decimal calcioNIR = Convert.ToDecimal(row["CalcioNIR"] is DBNull ? 0 : row["CalcioNIR"]);
                    decimal calcioLAB = Convert.ToDecimal(row["CalcioLAB"] is DBNull ? 0 : row["CalcioLAB"]);
                    decimal calcioPROM = Convert.ToDecimal(row["CalcioPROM"] is DBNull ? 0 : row["CalcioPROM"]);

                    decimal fosforoNIR = Convert.ToDecimal(row["FosforoNIR"] is DBNull ? 0 : row["FosforoNIR"]);
                    decimal fosforoLAB = Convert.ToDecimal(row["FosforoLAB"] is DBNull ? 0 : row["FosforoLAB"]);
                    decimal fosforoPROM = Convert.ToDecimal(row["FosforoPROM"] is DBNull ? 0 : row["FosforoPROM"]);

                    // Cálculos para Proteína
                    decimal proteinaPromedio = (proteinaNIR + proteinaLAB + proteinaPROM) / 3;
                    row["ProteinaPromedio"] = proteinaPromedio;

                    decimal proteinaDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(proteinaNIR - proteinaPromedio), 2)
                        + Math.Pow((double)(proteinaLAB - proteinaPromedio), 2)
                        + Math.Pow((double)(proteinaPROM - proteinaPromedio), 2)) / 3);

                    row["ProteinaDesvEstandar"] = proteinaDesvEstandar;
                    row["ProteinaPromedioCorregido"] = proteinaPROM - proteinaDesvEstandar;
                    row["ProteinaPromMasMedDesvEstandar"] = proteinaPROM + (proteinaDesvEstandar / 2);

                    // Cálculos para Grasa
                    decimal grasaPromedio = (grasaNIR + grasaLAB + grasaPROM) / 3;
                    row["GrasaPromedio"] = grasaPromedio;

                    decimal grasaDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(grasaNIR - grasaPromedio), 2)
                        + Math.Pow((double)(grasaLAB - grasaPromedio), 2)
                        + Math.Pow((double)(grasaPROM - grasaPromedio), 2)) / 3);

                    row["GrasaDesvEstandar"] = grasaDesvEstandar;
                    row["GrasaPromedioCorregido"] = grasaPROM - grasaDesvEstandar;
                    row["GrasaPromMasMedDesvEstandar"] = grasaPROM + (grasaDesvEstandar / 2);

                    // Cálculos para Fibra
                    decimal fibraPromedio = (fibraNIR + fibraLAB + fibraPROM) / 3;
                    row["FibraPromedio"] = fibraPromedio;

                    decimal fibraDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(fibraNIR - fibraPromedio), 2)
                        + Math.Pow((double)(fibraLAB - fibraPromedio), 2)
                        + Math.Pow((double)(fibraPROM - fibraPromedio), 2)) / 3);

                    row["FibraDesvEstandar"] = fibraDesvEstandar;
                    row["FibraPromedioCorregido"] = fibraPROM - fibraDesvEstandar;
                    row["FibraPromMasMedDesvEstandar"] = fibraPROM + (fibraDesvEstandar / 2);

                    // Cálculos para Cenizas
                    decimal cenizasPromedio = (cenizasNIR + cenizasLAB + cenizasPROM) / 3;
                    row["CenizasPromedio"] = cenizasPromedio;

                    decimal cenizasDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(cenizasNIR - cenizasPromedio), 2)
                        + Math.Pow((double)(cenizasLAB - cenizasPromedio), 2)
                        + Math.Pow((double)(cenizasPROM - cenizasPromedio), 2)) / 3);

                    row["CenizasDesvEstandar"] = cenizasDesvEstandar;
                    row["CenizasPromedioCorregido"] = cenizasPROM - cenizasDesvEstandar;
                    row["CenizasPromMasMedDesvEstandar"] = cenizasPROM + (cenizasDesvEstandar / 2);

                    // Cálculos para Humedad
                    decimal humedadPromedio = (humedadNIR + humedadLAB + humedadPROM) / 3;
                    row["HumedadPromedio"] = humedadPromedio;

                    decimal humedadDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(humedadNIR - humedadPromedio), 2)
                        + Math.Pow((double)(humedadLAB - humedadPromedio), 2)
                        + Math.Pow((double)(humedadPROM - humedadPromedio), 2)) / 3);

                    row["HumedadDesvEstandar"] = humedadDesvEstandar;
                    row["HumedadPromedioCorregido"] = humedadPROM - humedadDesvEstandar;
                    row["HumedadPromMasMedDesvEstandar"] = humedadPROM + (humedadDesvEstandar / 2);

                    // Cálculos para Calcio
                    decimal calcioPromedio = (calcioNIR + calcioLAB + calcioPROM) / 3;
                    row["CalcioPromedio"] = calcioPromedio;

                    decimal calcioDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(calcioNIR - calcioPromedio), 2)
                        + Math.Pow((double)(calcioLAB - calcioPromedio), 2)
                        + Math.Pow((double)(calcioPROM - calcioPromedio), 2)) / 3);

                    row["CalcioDesvEstandar"] = calcioDesvEstandar;
                    row["CalcioPromedioCorregido"] = calcioPROM - calcioDesvEstandar;
                    row["CalcioPromMasMedDesvEstandar"] = calcioPROM + (calcioDesvEstandar / 2);

                    // Cálculos para Fósforo
                    decimal fosforoPromedio = (fosforoNIR + fosforoLAB + fosforoPROM) / 3;
                    row["FosforoPromedio"] = fosforoPromedio;

                    decimal fosforoDesvEstandar = (decimal)Math.Sqrt(
                        (Math.Pow((double)(fosforoNIR - fosforoPromedio), 2)
                        + Math.Pow((double)(fosforoLAB - fosforoPromedio), 2)
                        + Math.Pow((double)(fosforoPROM - fosforoPromedio), 2)) / 3);

                    row["FosforoDesvEstandar"] = fosforoDesvEstandar;
                    row["FosforoPromedioCorregido"] = fosforoPROM - fosforoDesvEstandar;
                    row["FosforoPromMasMedDesvEstandar"] = fosforoPROM + (fosforoDesvEstandar / 2);
                }

                // Asignar los resultados al DataGridView
                dgvResultados.DataSource = _currentDataTable;

                // Añadir una columna de botón si no existe
                if (!dgvResultados.Columns.Contains("Eliminar"))
                {
                    var btnEliminar = new DataGridViewButtonColumn
                    {
                        Name = "Eliminar",
                        HeaderText = "Eliminar",
                        Text = "Eliminar",
                        UseColumnTextForButtonValue = true,
                        Width = 75,
                        FlatStyle = FlatStyle.Flat,
                        DefaultCellStyle = { ForeColor = Color.White, BackColor = Color.Red }
                    };
                    dgvResultados.Columns.Add(btnEliminar);
                }

                // Ocultar columnas de IDs si es necesario
                OcultarColumnasDeIDs();

                // Generar gráficos si es necesario
                GenerarGraficos(_currentDataTable);
            }
            catch (Exception ex)
            {
                MostrarError("Error al filtrar resultados", ex);
            }
        }

        private async void dgvResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en una celda válida y en la columna de "Eliminar"
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvResultados.Columns["Eliminar"].Index)
            {
                // Obtén el ID del registro para eliminar
                var id = dgvResultados.Rows[e.RowIndex].Cells["MatPrimID"].Value;

                // Llama al método para eliminar el registro de la base de datos
                await EliminarRegistroAsync(id);

                // Elimina la fila del DataGridView
                dgvResultados.Rows.RemoveAt(e.RowIndex);
            }
        }


        private async Task EliminarRegistroAsync(object id)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                await con.OpenAsync();
                var query = "DELETE FROM MateriasPrimas WHERE MatPrimID = @MatPrimID";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MatPrimID", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                // Verifica si el registro se eliminó
                if (rowsAffected == 0)
                {
                    MessageBox.Show("No se encontró el registro para eliminar.");
                }
                else
                {
                    MessageBox.Show("Registro eliminado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                // Muestra el error detallado
                MostrarError("Error al eliminar el registro", ex);
            }
        }




        private void OcultarColumnasDeIDs()
        {
            foreach (var column in new[] { "MatPrimID","ProveedorID", "IngredienteID" })
            {
                if (dgvResultados.Columns.Contains(column))
                    dgvResultados.Columns[column].Visible = false;
            }
        }

        private async Task ActualizarDatosAsync(int matPrimID, string columna, object nuevoValor)
        {
            string query = $"UPDATE MateriasPrimas SET {columna} = @NuevoValor WHERE MatPrimID = @MatPrimID";

            try
            {
                using var con = new SqlConnection(_connectionString);
                await con.OpenAsync();
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NuevoValor", nuevoValor ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MatPrimID", matPrimID);

                await cmd.ExecuteNonQueryAsync();
                await FiltrarResultadosAsync();
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar datos", ex);
            }
        }

        private async void dgvResultados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgvResultados.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    try
                    {
                        if (_currentDataTable != null && _currentDataTable.Columns.Contains("MatPrimID"))
                        {
                            int matPrimID = Convert.ToInt32(dgvResultados.Rows[e.RowIndex].Cells["MatPrimID"].Value);
                            string columna = dgvResultados.Columns[e.ColumnIndex].Name;

                            object nuevoValor = Convert.ChangeType(cell.Value, dgvResultados.Columns[e.ColumnIndex].ValueType);
                            await ActualizarDatosAsync(matPrimID, columna, nuevoValor);
                        }
                        else
                        {
                            MessageBox.Show("La columna MatPrimID no está presente en el DataGridView.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MostrarError("Error al actualizar datos", ex);
                    }
                }
            }
        }

        private void GenerarGraficos(DataTable dataTable)
        {
            panelCharts.Controls.Clear();

            // Configuración para cada tipo de gráfico
            CrearGrafico("Humedad", "HumedadNIR", "HumedadLAB", "HumedadPROM", dataTable);
            CrearGrafico("Cenizas", "CenizasNIR", "CenizasLAB", "CenizasPROM", dataTable);
            CrearGrafico("Fibra", "FibraNIR", "FibraLAB", "FibraPROM", dataTable);
            CrearGrafico("Grasa", "GrasaNIR", "GrasaLAB", "GrasaPROM", dataTable);
            CrearGrafico("Proteína", "ProteinaNIR", "ProteinaLAB", "ProteinaPROM", dataTable);
        }

        private void CrearGrafico(string titulo, string columna1, string columna2, string columna3, DataTable dataTable)
        {
            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            chart.Legends.Add(new Legend());
            chart.Dock = DockStyle.Top;
            chart.Height = 300;  // Tamaño aumentado
            chart.Width = panelCharts.Width;  // Ajusta al ancho del panel
            chart.Titles.Add(new Title
            {
                Text = titulo,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black
            });

            // Configura las series
            AgregarSerie(chart, $"{titulo} NIR", Color.Blue, columna1, dataTable);
            AgregarSerie(chart, $"{titulo} LAB", Color.Red, columna2, dataTable);
            AgregarSerie(chart, $"{titulo} PROM", Color.Green, columna3, dataTable);

            // Agrega el gráfico al panel
            panelCharts.Controls.Add(chart);
        }

        private void AgregarSerie(Chart chart, string nombreSerie, Color color, string columna, DataTable dataTable)
        {
            Series serie = new Series
            {
                Name = nombreSerie,
                ChartType = SeriesChartType.Line,
                Color = color,
                BorderWidth = 3,  // Ancho de línea aumentado
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8  // Tamaño de los puntos aumentado
            };

            foreach (DataRow row in dataTable.Rows)
            {
                DateTime fecha = Convert.ToDateTime(row["Fecha"]);
                double valor = Convert.IsDBNull(row[columna]) ? 0 : Convert.ToDouble(row[columna]);
                serie.Points.AddXY(fecha, valor);
            }

            chart.Series.Add(serie);
        }

        private void AddSeriesToChart(Chart chart, string serie1, string serie2, string serie3, DataTable dataTable, string column1, string column2, string column3)
        {
            AddSeries(chart, serie1, SeriesChartType.Line, dataTable, column1);
            AddSeries(chart, serie2, SeriesChartType.Line, dataTable, column2);
            AddSeries(chart, serie3, SeriesChartType.Line, dataTable, column3);
        }

        private void AddSeries(Chart chart, string seriesName, SeriesChartType chartType, DataTable dataTable, string columnName)
        {
            Series series = new Series
            {
                Name = seriesName,
                ChartType = chartType,
                BorderWidth = 3,  // Ancho de línea aumentado
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8  // Tamaño de los puntos aumentado
            };

            foreach (DataRow row in dataTable.Rows)
            {
                DateTime fecha = Convert.ToDateTime(row["Fecha"]);
                double valor = Convert.IsDBNull(row[columnName]) ? 0 : Convert.ToDouble(row[columnName]);
                series.Points.AddXY(fecha, valor);
            }

            chart.Series.Add(series);
        }

        private void ConfigureChart(Chart chart, string title)
        {
            chart.Titles.Clear();
            chart.Titles.Add(new Title
            {
                Text = title,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black
            });
            chart.Series.Clear();
            chart.Series.Add(new Series
            {
                Name = title,
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,  // Ancho de línea aumentado
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8  // Tamaño de los puntos aumentado
            });
        }

        private Table CreateHorizontalTableFromDataTable(DataTable dataTable)
        {
            // Crea una tabla con tantas columnas como el DataTable (menos la columna MatPrimID)
            int columnCount = dataTable.Columns.Count - 1;
            Table table = new Table(columnCount);

            // Agrega los encabezados de las columnas, omitiendo MatPrimID
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName != "MatPrimID")
                {
                    Cell headerCell = new Cell().Add(new Paragraph(column.ColumnName));
                    table.AddHeaderCell(headerCell);
                }
            }

            // Agrega las filas de datos, omitiendo la columna MatPrimID
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ColumnName != "MatPrimID")
                    {
                        Cell cell = new Cell().Add(new Paragraph(row[column].ToString()));
                        table.AddCell(cell);
                    }
                }
            }

            return table;
        }

        private void CreateTablesFromDataTable(DataTable dataTable, out Table mainTable, out Table detailsTable)
        {
            // Crear tabla principal sin columna MatPrimID
            mainTable = new Table(UnitValue.CreatePercentArray(dataTable.Columns.Count - 1));
            mainTable.SetWidth(UnitValue.CreatePercentValue(100)); // Ajustar ancho de la tabla al 100%

            // Crear tabla de detalles adicionales (para MatPrimID y otros detalles)
            detailsTable = new Table(UnitValue.CreatePercentArray(4)); // Ajusta según el número de columnas en la tabla de detalles
            detailsTable.SetWidth(UnitValue.CreatePercentValue(100)); // Ajustar ancho de la tabla al 100%

            // Estilo para las celdas
            var cellStyle = new Style().SetFontSize(8);

            // Agregar encabezados de columnas a la tabla principal (sin la columna MatPrimID)
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName != "MatPrimID") // Omitir la columna MatPrimID
                {
                    mainTable.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName).SetBold()).AddStyle(cellStyle));
                }
            }

            // Agregar filas a la tabla principal
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ColumnName != "MatPrimID") // Omitir la columna MatPrimID
                    {
                        mainTable.AddCell(new Cell().Add(new Paragraph(row[column].ToString())).AddStyle(cellStyle));
                    }
                }
            }

            // Agregar encabezados de columnas a la tabla de detalles
            detailsTable.AddHeaderCell(new Cell().Add(new Paragraph("MatPrimID").SetBold()).AddStyle(cellStyle));
            detailsTable.AddHeaderCell(new Cell().Add(new Paragraph("Promedio").SetBold()).AddStyle(cellStyle));
            detailsTable.AddHeaderCell(new Cell().Add(new Paragraph("Desviación").SetBold()).AddStyle(cellStyle));
            detailsTable.AddHeaderCell(new Cell().Add(new Paragraph("Otro Detalle").SetBold()).AddStyle(cellStyle)); // Ajusta según sea necesario

            // Agregar detalles a la tabla de detalles
            foreach (DataRow row in dataTable.Rows)
            {
                detailsTable.AddCell(new Cell().Add(new Paragraph(row["MatPrimID"].ToString())).AddStyle(cellStyle));
                detailsTable.AddCell(new Cell().Add(new Paragraph(row["Promedio"].ToString())).AddStyle(cellStyle));
                detailsTable.AddCell(new Cell().Add(new Paragraph(row["Desviación"].ToString())).AddStyle(cellStyle));
                detailsTable.AddCell(new Cell().Add(new Paragraph(row["Otro Detalle"].ToString())).AddStyle(cellStyle)); // Ajusta según sea necesario
            }
        }


        private async void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Define la ruta completa del archivo PDF en el escritorio con fecha actual
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"ResultadosMateriasPrimas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = System.IO.Path.Combine(desktopPath, fileName); // Usa System.IO.Path

                // Crea el documento PDF con orientación horizontal
                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, PageSize.A2.Rotate()); // Establece la página en modo paisaje (horizontal)

                    // Agrega el encabezado principal
                    Paragraph mainHeader = new Paragraph("Reporte de Materias Primas")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16)
                        .SetBold();
                    document.Add(mainHeader);

                    // Configuración para la paginación de gráficos
                    int chartCounter = 0;
                    int chartsPerRow = 5; // Número de gráficos por fila
                    Table chartTable = new Table(UnitValue.CreatePercentArray(chartsPerRow)); // Crea una tabla con 5 columnas

                    foreach (Control control in panelCharts.Controls)
                    {
                        if (control is Chart chart)
                        {
                            // Guarda el gráfico como imagen temporalmente
                            string chartImagePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".png"); // Usa System.IO.Path
                            SaveChartAsImage(chart, chartImagePath);

                            // Crea una imagen y ajusta su tamaño
                            iText.Layout.Element.Image chartImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(chartImagePath));
                            chartImage.SetAutoScale(true); // Ajusta la imagen al tamaño disponible

                            // Añade la imagen a una celda de la tabla
                            Cell cell = new Cell().Add(chartImage);
                            chartTable.AddCell(cell);

                            // Elimina la imagen temporal
                            File.Delete(chartImagePath);

                            // Si se han añadido 5 gráficos a la fila, añade la tabla al documento y crea una nueva tabla
                            if (++chartCounter % chartsPerRow == 0)
                            {
                                document.Add(chartTable);
                                chartTable = new Table(UnitValue.CreatePercentArray(chartsPerRow)); // Reinicia la tabla para la siguiente fila
                            }
                        }
                    }

                    // Añade cualquier gráfico restante que no haya llenado una fila completa
                    if (chartCounter % chartsPerRow != 0)
                    {
                        document.Add(chartTable);
                    }

                    // Agrega el encabezado de la tabla de resultados
                    Paragraph resultsHeader = new Paragraph("Tabla de Resultados")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(12);
                    document.Add(resultsHeader);

                    // Crea y añade la tabla de resultados
                    Table resultsTable = CreateHorizontalTableFromDataTable(_currentDataTable); // Usa el DataTable proporcionado
                    resultsTable.SetWidth(UnitValue.CreatePercentValue(100)); // Ajusta el ancho de la tabla para que ocupe el 100% del ancho de la página

                    document.Add(resultsTable);

                    // Cierra el documento
                    document.Close();
                }

                MessageBox.Show($"PDF creado exitosamente en el escritorio: {filePath}");
            }
            catch (Exception ex)
            {
                MostrarError("Error creando el PDF", ex);
            }
        }


        private void SaveChartAsImage(Chart chart, string filePath)
        {
            // Guarda el gráfico como imagen PNG
            chart.SaveImage(filePath, ChartImageFormat.Png);
        }
        private void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show($"{mensaje}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
