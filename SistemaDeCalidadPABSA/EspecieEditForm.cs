using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaDeCalidadPABSA
{
    public partial class EspecieEditForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private int especieId;

        public EspecieEditForm(int especieId)
        {
            InitializeComponent();
            this.especieId = especieId;
            LoadEspecieData();
        }

        private void LoadEspecieData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre, Descripcion FROM Especies WHERE EspecieID = @EspecieID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EspecieID", especieId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de la especie: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Actualizar la especie en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Especies SET Nombre = @Nombre, Descripcion = @Descripcion WHERE EspecieID = @EspecieID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@EspecieID", especieId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Especie actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicar que se guardó la información
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la especie: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
