using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration; // Asegúrate de tener esta referencia

namespace SistemaDeCalidadPABSA
{
    public partial class AgregarProductoForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public AgregarProductoForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar la entrada
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                !decimal.TryParse(txtProteinaGarantia.Text, out decimal proteinaGarantia) ||
                !decimal.TryParse(txtGrasaGarantia.Text, out decimal grasaGarantia) ||
                !decimal.TryParse(txtFibraGarantia.Text, out decimal fibraGarantia) ||
                !decimal.TryParse(txtCenizasGarantia.Text, out decimal cenizasGarantia) ||
                !decimal.TryParse(txtHumedadGarantia.Text, out decimal humedadGarantia))
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Conectar a la base de datos y agregar el producto
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Productos (Nombre, Descripcion, ProteinaGarantia, GrasaGarantia, FibraGarantia, CenizasGarantia, HumedadGarantia) " +
                                   "VALUES (@Nombre, @Descripcion, @ProteinaGarantia, @GrasaGarantia, @FibraGarantia, @CenizasGarantia, @HumedadGarantia)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        command.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                        command.Parameters.AddWithValue("@ProteinaGarantia", proteinaGarantia);
                        command.Parameters.AddWithValue("@GrasaGarantia", grasaGarantia);
                        command.Parameters.AddWithValue("@FibraGarantia", fibraGarantia);
                        command.Parameters.AddWithValue("@CenizasGarantia", cenizasGarantia);
                        command.Parameters.AddWithValue("@HumedadGarantia", humedadGarantia);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Indicar que se guardó la información
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indicar que se canceló la operación
            Close();
        }
    }
}
