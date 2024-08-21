using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class IngredientesForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IngredientesForm()
        {
            InitializeComponent();
        }

        private void IngredientesForm_Load(object sender, EventArgs e)
        {
            CargarIngredientes();
            AgregarBotonesAccion();
        }

        private void CargarIngredientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IngredienteID, Nombre, Descripcion FROM Ingredientes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvIngredientes.DataSource = dataTable;
            }
        }

        private void AgregarBotonesAccion()
        {
            // Verificar y agregar el botón de Editar si no existe
            if (!dgvIngredientes.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                {
                    Name = "btnEditar",
                    HeaderText = "",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = { BackColor = Color.Green, ForeColor = Color.White }
                };
                dgvIngredientes.Columns.Add(btnEditar);
            }

            // Verificar y agregar el botón de Eliminar si no existe
            if (!dgvIngredientes.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                {
                    Name = "btnEliminar",
                    HeaderText = "",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = { BackColor = Color.Red, ForeColor = Color.White }
                };
                dgvIngredientes.Columns.Add(btnEliminar);
            }
        }

        private void btnAgregarIngrediente_Click(object sender, EventArgs e)
        {
            using (var form = new AgregarIngredienteForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarIngredientes(); // Recargar la lista después de agregar
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBuscar.Text.Trim();
            (dgvIngredientes.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", filter);
        }

        private void dgvIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ingredienteID = Convert.ToInt32(dgvIngredientes.Rows[e.RowIndex].Cells["IngredienteID"].Value);

                if (e.ColumnIndex == dgvIngredientes.Columns["btnEditar"].Index)
                {
                    // Abrir el formulario de edición
                    using (var form = new EditarIngredienteForm(ingredienteID))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            CargarIngredientes(); // Recargar la lista después de editar
                        }
                    }
                }
                else if (e.ColumnIndex == dgvIngredientes.Columns["btnEliminar"].Index)
                {
                    // Confirmar y eliminar el ingrediente
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este ingrediente?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EliminarIngrediente(ingredienteID);
                    }
                }
            }
        }

        private void EliminarIngrediente(int ingredienteID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ingredientes WHERE IngredienteID = @IngredienteID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredienteID", ingredienteID);
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Ingrediente eliminado exitosamente.");
                CargarIngredientes(); // Recargar la lista después de eliminar
            }
        }
    }
}
