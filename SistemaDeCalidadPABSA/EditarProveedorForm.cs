using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class EditarProveedorForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private int proveedorId;

        public EditarProveedorForm(int proveedorId)
        {
            InitializeComponent();
            this.proveedorId = proveedorId;
            CargarDatosProveedor();
        }

        private void CargarDatosProveedor()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre, Descripcion FROM Proveedores WHERE ProveedorID = @ProveedorID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProveedorID", proveedorId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
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

            // Actualizar proveedor en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Proveedores SET Nombre = @Nombre, Descripcion = @Descripcion WHERE ProveedorID = @ProveedorID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@ProveedorID", proveedorId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicar que se guardó la información
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
