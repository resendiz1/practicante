using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeCalidadPABSA
{
    public partial class AgregarAnalisisForm : Form
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private List<TextBox> _folioTextBoxes = new List<TextBox>();
        private List<TextBox> _folioExternoTextBoxes = new List<TextBox>();

        public AgregarAnalisisForm()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Cargar Proveedores e Ingredientes
                    LoadComboBoxData(cmbProveedor, "SELECT ProveedorID, Nombre FROM Proveedores", "Nombre", "ProveedorID");
                    LoadComboBoxData(cmbIngrediente, "SELECT IngredienteID, Nombre FROM Ingredientes", "Nombre", "IngredienteID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    comboBox.DataSource = dataTable;
                    comboBox.DisplayMember = displayMember;
                    comboBox.ValueMember = valueMember;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del combo box: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones iniciales
            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un proveedor.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbIngrediente.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un ingrediente.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFolInt.Text))
            {
                MessageBox.Show("El campo Folio Interno no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de TextBox numéricos
            bool validData = true;

            validData &= ValidateDecimal(txtProteinaNIR, "Proteína NIR");
            validData &= ValidateDecimal(txtProteinaLAB, "Proteína LAB");
            validData &= ValidateDecimal(txtProteinaPROM, "Proteína PROM");

            validData &= ValidateDecimal(txtGrasaNIR, "Grasa NIR");
            validData &= ValidateDecimal(txtGrasaLAB, "Grasa LAB");
            validData &= ValidateDecimal(txtGrasaPROM, "Grasa PROM");

            validData &= ValidateDecimal(txtFibraNIR, "Fibra NIR");
            validData &= ValidateDecimal(txtFibraLAB, "Fibra LAB");
            validData &= ValidateDecimal(txtFibraPROM, "Fibra PROM");

            validData &= ValidateDecimal(txtCenizasNIR, "Cenizas NIR");
            validData &= ValidateDecimal(txtCenizasLAB, "Cenizas LAB");
            validData &= ValidateDecimal(txtCenizasPROM, "Cenizas PROM");

            validData &= ValidateDecimal(txtHumedadNIR, "Humedad NIR");
            validData &= ValidateDecimal(txtHumedadLAB, "Humedad LAB");
            validData &= ValidateDecimal(txtHumedadPROM, "Humedad PROM");

            validData &= ValidateDecimal(txtCalcioNIR, "Calcio NIR");
            validData &= ValidateDecimal(txtCalcioLAB, "Calcio LAB");
            validData &= ValidateDecimal(txtCalcioPROM, "Calcio PROM");

            validData &= ValidateDecimal(txtFosforoNIR, "Fósforo NIR");
            validData &= ValidateDecimal(txtFosforoLAB, "Fósforo LAB");
            validData &= ValidateDecimal(txtFosforoPROM, "Fósforo PROM");

            if (!validData)
            {
                // Si alguna validación falla, salir del método
                return;
            }

            try
            {
                // Recolectar valores después de las validaciones
                int proveedorID = Convert.ToInt32(cmbProveedor.SelectedValue);
                int ingredienteID = Convert.ToInt32(cmbIngrediente.SelectedValue);
                DateTime fecha = dtpFecha.Value;

                decimal proteinaNIR = Convert.ToDecimal(txtProteinaNIR.Text);
                decimal proteinaLAB = Convert.ToDecimal(txtProteinaLAB.Text);
                decimal proteinaPROM = Convert.ToDecimal(txtProteinaPROM.Text);

                decimal grasaNIR = Convert.ToDecimal(txtGrasaNIR.Text);
                decimal grasaLAB = Convert.ToDecimal(txtGrasaLAB.Text);
                decimal grasaPROM = Convert.ToDecimal(txtGrasaPROM.Text);

                decimal fibraNIR = Convert.ToDecimal(txtFibraNIR.Text);
                decimal fibraLAB = Convert.ToDecimal(txtFibraLAB.Text);
                decimal fibraPROM = Convert.ToDecimal(txtFibraPROM.Text);

                decimal cenizasNIR = Convert.ToDecimal(txtCenizasNIR.Text);
                decimal cenizasLAB = Convert.ToDecimal(txtCenizasLAB.Text);
                decimal cenizasPROM = Convert.ToDecimal(txtCenizasPROM.Text);

                decimal humedadNIR = Convert.ToDecimal(txtHumedadNIR.Text);
                decimal humedadLAB = Convert.ToDecimal(txtHumedadLAB.Text);
                decimal humedadPROM = Convert.ToDecimal(txtHumedadPROM.Text);

                decimal calcioNIR = Convert.ToDecimal(txtCalcioNIR.Text);
                decimal calcioLAB = Convert.ToDecimal(txtCalcioLAB.Text);
                decimal calcioPROM = Convert.ToDecimal(txtCalcioPROM.Text);

                decimal fosforoNIR = Convert.ToDecimal(txtFosforoNIR.Text);
                decimal fosforoLAB = Convert.ToDecimal(txtFosforoLAB.Text);
                decimal fosforoPROM = Convert.ToDecimal(txtFosforoPROM.Text);

                string folioInterno = txtFolInt.Text;
                string foliosExternos = txtFolExt.Text;

                foreach (TextBox textBox in _folioTextBoxes)
                {
                    foliosExternos += "," + textBox.Text;
                }

                // Llamar a la función que ejecuta el INSERT
                InsertarMateriasPrimas(proveedorID, ingredienteID, fecha, proteinaNIR, proteinaLAB, proteinaPROM,
                                       grasaNIR, grasaLAB, grasaPROM, fibraNIR, fibraLAB, fibraPROM,
                                       cenizasNIR, cenizasLAB, cenizasPROM, humedadNIR, humedadLAB,
                                       humedadPROM, calcioNIR, calcioLAB, calcioPROM, fosforoNIR, fosforoLAB,
                                       fosforoPROM, folioInterno, foliosExternos);

                // Mostrar mensaje de éxito
                MessageBox.Show("Los datos se han agregado correctamente.", "Agregado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cerrar la ventana
                this.Close();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MessageBox.Show($"Ocurrió un error al intentar guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateDecimal(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"El campo {fieldName} no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(textBox.Text, out decimal value) || value < 0)
            {
                MessageBox.Show($"El valor del campo {fieldName} debe ser un número decimal válido mayor o igual a cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }



        private void InsertarMateriasPrimas(int proveedorID, int ingredienteID, DateTime fecha, decimal proteinaNIR, decimal proteinaLAB, decimal proteinaPROM, decimal grasaNIR, decimal grasaLAB, decimal grasaPROM, decimal fibraNIR, decimal fibraLAB, decimal fibraPROM, decimal cenizasNIR, decimal cenizasLAB, decimal cenizasPROM, decimal humedadNIR, decimal humedadLAB, decimal humedadPROM, decimal calcioNIR, decimal calcioLAB, decimal calcioPROM, decimal FosforoNIR, decimal FosforoLAB, decimal FosforoPROM, string folioInterno, string foliosExternos)
        {
           
            string query = @"INSERT INTO MateriasPrimas 
                        (ProveedorID, IngredienteID, Fecha, 
                         ProteinaNIR, ProteinaLAB, ProteinaPROM, 
                         GrasaNIR, GrasaLAB, GrasaPROM, 
                         FibraNIR, FibraLAB, FibraPROM, 
                         CenizasNIR, CenizasLAB, CenizasPROM, 
                         HumedadNIR, HumedadLAB, HumedadPROM, 
                         CalcioNIR, CalcioLAB, CalcioPROM, 
                         FosforoNIR, FosforoLAB, FosforoPROM, 
                         FolioInterno, FolioExterno) 
                     VALUES 
                        (@ProveedorID, @IngredienteID, @Fecha, 
                         @ProteinaNIR, @ProteinaLAB, @ProteinaPROM, 
                         @GrasaNIR, @GrasaLAB, @GrasaPROM, 
                         @FibraNIR, @FibraLAB, @FibraPROM, 
                         @CenizasNIR, @CenizasLAB, @CenizasPROM, 
                         @HumedadNIR, @HumedadLAB, @HumedadPROM, 
                         @CalcioNIR, @CalcioLAB, @CalcioPROM, 
                         @FosforoNIR, @FosforoLAB, @FosforoPROM, 
                         @FolioInterno, @FolioExterno)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProveedorID", proveedorID);
                command.Parameters.AddWithValue("@IngredienteID", ingredienteID);
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.Parameters.AddWithValue("@ProteinaNIR", proteinaNIR);
                command.Parameters.AddWithValue("@ProteinaLAB", proteinaLAB);
                command.Parameters.AddWithValue("@ProteinaPROM", proteinaPROM);
                command.Parameters.AddWithValue("@GrasaNIR", grasaNIR);
                command.Parameters.AddWithValue("@GrasaLAB", grasaLAB);
                command.Parameters.AddWithValue("@GrasaPROM", grasaPROM);
                command.Parameters.AddWithValue("@FibraNIR", fibraNIR);
                command.Parameters.AddWithValue("@FibraLAB", fibraLAB);
                command.Parameters.AddWithValue("@FibraPROM", fibraPROM);
                command.Parameters.AddWithValue("@CenizasNIR", cenizasNIR);
                command.Parameters.AddWithValue("@CenizasLAB", cenizasLAB);
                command.Parameters.AddWithValue("@CenizasPROM", cenizasPROM);
                command.Parameters.AddWithValue("@HumedadNIR", humedadNIR);
                command.Parameters.AddWithValue("@HumedadLAB", humedadLAB);
                command.Parameters.AddWithValue("@HumedadPROM", humedadPROM);
                command.Parameters.AddWithValue("@CalcioNIR", calcioNIR);
                command.Parameters.AddWithValue("@CalcioLAB", calcioLAB);
                command.Parameters.AddWithValue("@CalcioPROM", calcioPROM);
                command.Parameters.AddWithValue("@FosforoNIR", FosforoNIR);
                command.Parameters.AddWithValue("@FosforoLAB", FosforoLAB);
                command.Parameters.AddWithValue("@FosforoPROM", FosforoPROM);
                command.Parameters.AddWithValue("@FolioInterno", folioInterno);
                command.Parameters.AddWithValue("@FolioExterno", foliosExternos);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int GetValueOrDefault(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : 0;
        }

        private float GetFloatValue(string value)
        {
            return float.TryParse(value, out float result) ? result : 0f;
        }

        private void AddFolioEx_Click(object sender, EventArgs e)
        {
            // Altura que separa cada conjunto de Label y TextBox
            int spacing = 30;

            // Definir el yOffset inicial basado en el último TextBox estático
            int initialYOffset = lblFolioExt.Location.Y + spacing; // Punto inicial por debajo del primer conjunto de Folio

            // Calcular la nueva posición en base al número de folios dinámicos ya agregados
            int currentFolioIndex = _folioTextBoxes.Count + 2; // Empieza desde "Folio 2"
            int yOffset = initialYOffset + (spacing * _folioTextBoxes.Count); // Aumentar el desplazamiento vertical

            // Crear un nuevo Label para el siguiente TextBox
            Label newLabel = new Label();
            newLabel.Text = $"Folio Externo {currentFolioIndex}:"; // Ejemplo: "Folio Externo 2:"
            newLabel.Size = new Size(79, 15); // Tamaño del label
            newLabel.Location = new Point(26, yOffset); // Posición del nuevo Label
            newLabel.AutoSize = true;

            // Crear un nuevo TextBox
            TextBox newTextBox = new TextBox();
            newTextBox.Name = $"txtFolioExt_{currentFolioIndex}"; // Nombre dinámico
            newTextBox.Size = new Size(150, 23); // Tamaño del TextBox
            newTextBox.Location = new Point(115, yOffset); // Posición del nuevo TextBox
            newTextBox.TabIndex = 100 + _folioTextBoxes.Count; // TabIndex dinámico

            // Agregar el nuevo Label y TextBox al formulario
            this.Controls.Add(newLabel);
            this.Controls.Add(newTextBox);

            // Agregar el nuevo TextBox a la lista
            _folioTextBoxes.Add(newTextBox);

            // Reubicar los botones de Guardar y Cancelar hacia abajo
            btnGuardar.Location = new Point(btnGuardar.Location.X, newTextBox.Location.Y + spacing);
            btnCancelar.Location = new Point(btnCancelar.Location.X, newTextBox.Location.Y + spacing);

            // Ajustar el tamaño del formulario si es necesario para evitar desbordes
            this.ClientSize = new Size(this.ClientSize.Width, btnGuardar.Location.Y + btnGuardar.Height + 20);

            // Forzar una actualización del formulario
            this.Invalidate();
            this.Refresh();
        }
        private void btnDltFolio_Click(object sender, EventArgs e)
        {
            // Verificar que haya al menos un TextBox dinámico para eliminar
            if (_folioTextBoxes.Count > 0)
            {
                // Obtener el índice del último TextBox agregado
                int currentFolioIndex = _folioTextBoxes.Count + 1;

                // Obtener el último TextBox agregado
                TextBox lastTextBox = _folioTextBoxes[_folioTextBoxes.Count - 1];

                // Buscar el Label correspondiente al TextBox dinámico
                Label lastLabel = this.Controls.OfType<Label>().FirstOrDefault(l => l.Text == $"Folio Externo {currentFolioIndex}:");

                // Eliminar el TextBox y el Label del formulario
                if (lastLabel != null)
                {
                    this.Controls.Remove(lastLabel); // Eliminar el Label
                }
                this.Controls.Remove(lastTextBox); // Eliminar el TextBox

                // Eliminar el TextBox de la lista
                _folioTextBoxes.RemoveAt(_folioTextBoxes.Count - 1);

                // Reubicar los botones de Guardar y Cancelar hacia arriba
                if (_folioTextBoxes.Count > 0)
                {
                    TextBox previousTextBox = _folioTextBoxes[_folioTextBoxes.Count - 1];
                    btnGuardar.Location = new Point(btnGuardar.Location.X, previousTextBox.Location.Y + 30);
                    btnCancelar.Location = new Point(btnCancelar.Location.X, previousTextBox.Location.Y + 30);
                }
                else
                {
                    // Reubicar a la posición original si no quedan folios dinámicos
                    btnGuardar.Location = new Point(btnGuardar.Location.X, 439);
                    btnCancelar.Location = new Point(btnCancelar.Location.X, 439);
                }

                // Ajustar el tamaño del formulario si es necesario para evitar espacios vacíos
                this.ClientSize = new Size(this.ClientSize.Width, btnGuardar.Location.Y + btnGuardar.Height + 20);

                // Forzar una actualización del formulario
                this.Invalidate();
                this.Refresh();
            }
        }

       
    }
}
