using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SistemaDeCalidadPABSA
{
    public partial class ProveedoresForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ProveedoresForm()
        {
            InitializeComponent();
        }

        private void ProveedoresForm_Load(object sender, EventArgs e)
        {
            LoadProveedores();
            ConfigurarDataGridView();
        }

        private void LoadProveedores()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProveedorID, Nombre, Descripcion FROM Proveedores";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    dgvProveedores.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            // Configurar las columnas de edición y eliminación
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Name = "btnEditar",
                Width = 80,
                DefaultCellStyle = { BackColor = Color.Green, ForeColor = Color.White }
            };

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Name = "btnEliminar",
                Width = 80,
                DefaultCellStyle = { BackColor = Color.Red, ForeColor = Color.White }
            };

            if (!dgvProveedores.Columns.Contains("btnEditar"))
            {
                dgvProveedores.Columns.Add(btnEditar);
            }

            if (!dgvProveedores.Columns.Contains("btnEliminar"))
            {
                dgvProveedores.Columns.Add(btnEliminar);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBuscar.Text.Trim();
            (dgvProveedores.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", filter);
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar un nuevo proveedor
            using (AgregarProveedorForm addForm = new AgregarProveedorForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProveedores(); // Recargar proveedores después de agregar uno nuevo
                }
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int proveedorID = Convert.ToInt32(dgvProveedores.Rows[e.RowIndex].Cells["ProveedorID"].Value);

                if (e.ColumnIndex == dgvProveedores.Columns["btnEditar"].Index)
                {
                    // Abrir el formulario de edición
                    using (EditarProveedorForm editForm = new EditarProveedorForm(proveedorID))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadProveedores(); // Recargar proveedores después de editar uno
                        }
                    }
                }
                else if (e.ColumnIndex == dgvProveedores.Columns["btnEliminar"].Index)
                {
                    // Confirmar y eliminar el proveedor
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este proveedor?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DeleteProveedor(proveedorID);
                    }
                }
            }
        }

        private void DeleteProveedor(int proveedorID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Proveedores WHERE ProveedorID = @ProveedorID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProveedorID", proveedorID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Proveedor eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProveedores(); // Recargar proveedores después de eliminar uno
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
