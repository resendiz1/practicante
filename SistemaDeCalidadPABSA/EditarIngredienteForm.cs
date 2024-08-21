using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class EditarIngredienteForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public EditarIngredienteForm(int ingredienteID)
        {
            InitializeComponent();
            this.ingredienteID = ingredienteID;
        }

        private void EditarIngredienteForm_Load(object sender, EventArgs e)
        {
            CargarIngrediente();
        }

        private void CargarIngrediente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre, Descripcion FROM Ingredientes WHERE IngredienteID = @IngredienteID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredienteID", ingredienteID);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ingredientes SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IngredienteID = @IngredienteID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                command.Parameters.AddWithValue("@IngredienteID", ingredienteID);

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Ingrediente actualizado exitosamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
