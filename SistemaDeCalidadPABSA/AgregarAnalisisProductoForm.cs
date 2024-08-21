using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class AgregarAnalisisProductoForm : Form
    {
        private Dictionary<string, int> productosMap = new Dictionary<string, int>();
        private Dictionary<string, int> especiesMap = new Dictionary<string, int>();
        private Dictionary<string, int> plantaMap = new Dictionary<string, int>();

        public AgregarAnalisisProductoForm()
        {
            InitializeComponent();
            Load += AgregarAnalisisProductoForm_Load;
        }

        private void AgregarAnalisisProductoForm_Load(object sender, EventArgs e)
        {
            // Cargar datos en los comboboxes al iniciar el formulario
            CargarDatos("SELECT ProductoID, Nombre FROM Productos", cmbProducto, productosMap, "ProductoID", "Nombre");
            CargarDatos("SELECT EspecieID, Nombre FROM Especies", cmbEspecie, especiesMap, "EspecieID", "Nombre");
            CargarDatos("SELECT PlantaID, Nombre FROM Planta", cmbPlanta, plantaMap, "PlantaID", "Nombre");
        }

        // Método genérico para cargar datos en comboboxes y mapear IDs
        private void CargarDatos(string query, ComboBox comboBox, Dictionary<string, int> map, string idField, string nameField)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[idField]);
                    string nombre = reader[nameField].ToString();
                    comboBox.Items.Add(nombre);
                    map[nombre] = id;
                }
            }
        }

        // Método para guardar los análisis de producto
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de selección de producto, especie y planta
            if (!ValidarSeleccion(cmbProducto, productosMap, "producto") ||
                !ValidarSeleccion(cmbEspecie, especiesMap, "especie") ||
                !ValidarSeleccion(cmbPlanta, plantaMap, "planta"))
            {
                return;
            }

            int productoID = productosMap[cmbProducto.SelectedItem.ToString()];
            int especieID = especiesMap[cmbEspecie.SelectedItem.ToString()];
            int plantaID = plantaMap[cmbPlanta.SelectedItem.ToString()];
            DateTime fecha = dtpFecha.Value;

            // Validaciones de conversión de campos numéricos
            if (!double.TryParse(txtProteina.Text, out double proteina) ||
                !double.TryParse(txtGrasa.Text, out double grasa) ||
                !double.TryParse(txtFibra.Text, out double fibra) ||
                !double.TryParse(txtCenizas.Text, out double cenizas) ||
                !double.TryParse(txtHumedad.Text, out double humedad))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para los campos de análisis.");
                return;
            }

            // Inserción de datos en la base de datos
            GuardarAnalisisProducto(productoID, especieID, plantaID, fecha, proteina, grasa, fibra, cenizas, humedad);
        }

        // Método para validar la selección en un ComboBox y asegurarse de que existe en el mapa correspondiente
        private bool ValidarSeleccion(ComboBox comboBox, Dictionary<string, int> map, string nombreCampo)
        {
            if (comboBox.SelectedItem == null || !map.ContainsKey(comboBox.SelectedItem.ToString()))
            {
                MessageBox.Show($"Por favor, seleccione un {nombreCampo} válido.");
                return false;
            }
            return true;
        }

        // Método para guardar el análisis del producto en la base de datos
        private void GuardarAnalisisProducto(int productoID, int especieID, int plantaID, DateTime fecha, double proteina, double grasa, double fibra, double cenizas, double humedad)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO AnalisisProducto 
                                     (ProductoID, EspecieID, PlantaID, Fecha, Proteina, Grasa, Fibra, Cenizas, Humedad) 
                                     VALUES 
                                     (@ProductoID, @EspecieID, @PlantaID, @Fecha, @Proteina, @Grasa, @Fibra, @Cenizas, @Humedad)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductoID", productoID);
                    command.Parameters.AddWithValue("@EspecieID", especieID);
                    command.Parameters.AddWithValue("@PlantaID", plantaID);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.Parameters.AddWithValue("@Proteina", proteina);
                    command.Parameters.AddWithValue("@Grasa", grasa);
                    command.Parameters.AddWithValue("@Fibra", fibra);
                    command.Parameters.AddWithValue("@Cenizas", cenizas);
                    command.Parameters.AddWithValue("@Humedad", humedad);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Análisis de producto agregado exitosamente.");
                    this.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error de SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el análisis del producto: {ex.Message}");
            }
        }

        // Método para cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementación del evento si es necesario
        }
    }
}
