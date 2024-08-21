using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class AgregarProveedorForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public AgregarProveedorForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            // Validar campos
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insertar nuevo proveedor en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Proveedores (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Proveedor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicar que se guardó la información
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indicar que se canceló la operación
            Close();
        }
    }
}
