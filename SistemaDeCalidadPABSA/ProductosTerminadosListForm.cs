using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SistemaDeCalidadPABSA
{
    public partial class ProductosTerminadosListForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ProductosTerminadosListForm()
        {
            InitializeComponent();
        }

        private void ProductosTerminadosListForm_Load(object sender, EventArgs e)
        {
            LoadProductos();
            ConfigurarDataGridView();
        }

        private void LoadProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductoID, Nombre, Descripcion, ProteinaGarantia, GrasaGarantia, FibraGarantia, CenizasGarantia, HumedadGarantia, FechaCreacion FROM Productos";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    dgvProductos.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!dgvProductos.Columns.Contains("btnEditar"))
            {
                dgvProductos.Columns.Add(btnEditar);
            }

            if (!dgvProductos.Columns.Contains("btnEliminar"))
            {
                dgvProductos.Columns.Add(btnEliminar);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBuscar.Text.Trim();
            (dgvProductos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", filter);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar un nuevo producto
            using (AgregarProductoForm addForm = new AgregarProductoForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProductos(); // Recargar productos después de agregar uno nuevo
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productoID = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["ProductoID"].Value);

                if (e.ColumnIndex == dgvProductos.Columns["btnEditar"].Index)
                {
                    // Abrir el formulario de edición
                    using (EditarProductoForm editForm = new EditarProductoForm(productoID))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadProductos(); // Recargar productos después de editar uno
                        }
                    }
                }
                else if (e.ColumnIndex == dgvProductos.Columns["btnEliminar"].Index)
                {
                    // Confirmar y eliminar el producto
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este producto?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DeleteProducto(productoID);
                    }
                }
            }
        }

        private void DeleteProducto(int productoID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Productos WHERE ProductoID = @ProductoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductoID", productoID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductos(); // Recargar productos después de eliminar uno
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
