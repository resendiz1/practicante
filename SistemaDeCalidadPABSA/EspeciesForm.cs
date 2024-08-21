using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class EspeciesForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public EspeciesForm()
        {
            InitializeComponent();
        }

        private void EspeciesForm_Load(object sender, EventArgs e)
        {
            CargarEspecies();
            AgregarBotonesAccion();
        }

        private void CargarEspecies()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EspecieID, Nombre, Descripcion FROM Especies";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvEspecies.DataSource = dataTable;
            }
        }

        private void AgregarBotonesAccion()
        {
            // Verificar y agregar el botón de Editar si no existe
            if (!dgvEspecies.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                {
                    Name = "btnEditar",
                    HeaderText = "",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = { BackColor = Color.Green, ForeColor = Color.White }
                };
                dgvEspecies.Columns.Add(btnEditar);
            }

            // Verificar y agregar el botón de Eliminar si no existe
            if (!dgvEspecies.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                {
                    Name = "btnEliminar",
                    HeaderText = "",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = { BackColor = Color.Red, ForeColor = Color.White }
                };
                dgvEspecies.Columns.Add(btnEliminar);
            }
        }

        private void btnAgregarEspecie_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de agregar especie
            using (AgregarEspecieForm form = new AgregarEspecieForm())
            {
                form.ShowDialog();
                CargarEspecies(); // Recargar la lista de especies después de agregar una nueva
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrar la lista de especies basada en la búsqueda
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EspecieID, Nombre, Descripcion FROM Especies " +
                               "WHERE Nombre LIKE @Buscar";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Buscar", "%" + txtBuscar.Text + "%");
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvEspecies.DataSource = dataTable;
            }
        }

        private void dgvEspecies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int especieID = Convert.ToInt32(dgvEspecies.Rows[e.RowIndex].Cells["EspecieID"].Value);

                if (e.ColumnIndex == dgvEspecies.Columns["btnEditar"].Index)
                {
                    // Abrir el formulario de edición
                    using (EspecieEditForm form = new EspecieEditForm(especieID))
                    {
                        form.ShowDialog();
                        CargarEspecies(); // Recargar la lista de especies después de editar una
                    }
                }
                else if (e.ColumnIndex == dgvEspecies.Columns["btnEliminar"].Index)
                {
                    // Confirmar y eliminar la especie
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta especie?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EliminarEspecie(especieID);
                    }
                }
            }
        }

        private void EliminarEspecie(int especieID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Especies WHERE EspecieID = @EspecieID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EspecieID", especieID);
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Especie eliminada exitosamente.");
                CargarEspecies(); // Recargar la lista de especies después de eliminar una
            }
        }
    }
}
