using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class UsuariosForm : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            AgregarBotonesAccion();
        }

        private void CargarUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, Nombre, Apellidos, Usuario, Rol FROM Usuarios";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvUsuarios.DataSource = dataTable;
            }
        }

        private void AgregarBotonesAccion()
        {
            // Verificar y agregar el botón de Editar si no existe
            if (!dgvUsuarios.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                {
                    Name = "btnEditar",
                    HeaderText = "",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = { BackColor = Color.Green, ForeColor = Color.White }
                };
                dgvUsuarios.Columns.Add(btnEditar);
            }

            // Verificar y agregar el botón de Eliminar si no existe
            if (!dgvUsuarios.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                {
                    Name = "btnEliminar",
                    HeaderText = "",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = { BackColor = Color.Red, ForeColor = Color.White }
                };
                dgvUsuarios.Columns.Add(btnEliminar);
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de agregar usuario
            using (AgregarUsuarioForm form = new AgregarUsuarioForm())
            {
                form.ShowDialog();
                CargarUsuarios(); // Recargar la lista de usuarios después de agregar uno nuevo
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrar la lista de usuarios basada en la búsqueda
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, Nombre, Apellidos, Usuario, Rol FROM Usuarios " +
                               "WHERE Nombre LIKE @Buscar OR Apellidos LIKE @Buscar OR Usuario LIKE @Buscar";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Buscar", "%" + txtBuscar.Text + "%");
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvUsuarios.DataSource = dataTable;
            }
        }


        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int usuarioID = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["UsuarioID"].Value);

                if (e.ColumnIndex == dgvUsuarios.Columns["btnEditar"].Index)
                {
                    // Abrir el formulario de edición
                    using (EditarUsuarioForm form = new EditarUsuarioForm(usuarioID))
                    {
                        form.ShowDialog();
                        CargarUsuarios(); // Recargar la lista de usuarios después de editar uno
                    }
                }
                else if (e.ColumnIndex == dgvUsuarios.Columns["btnEliminar"].Index)
                {
                    // Confirmar y eliminar el usuario
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EliminarUsuario(usuarioID);
                    }
                }
            }
        }

        private void EliminarUsuario(int usuarioID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Usuario eliminado exitosamente.");
                CargarUsuarios(); // Recargar la lista de usuarios después de eliminar uno
            }
        }
    }
}