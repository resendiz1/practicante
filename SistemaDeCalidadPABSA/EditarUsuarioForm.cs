using Microsoft.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace SistemaDeCalidadPABSA
{
    public partial class EditarUsuarioForm : Form
    {
        private int _usuarioId;

        public EditarUsuarioForm(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }

        private void EditarUsuarioForm_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Nombre, Apellidos, Usuario, Contrasena, Rol FROM Usuarios WHERE UsuarioID = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", _usuarioId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtApellidos.Text = reader["Apellidos"].ToString();
                    txtUsuario.Text = reader["Usuario"].ToString();
                    txtContrasena.Text = ""; // Mostrar un campo vacío para cambiar la contraseña
                    cmbRol.SelectedIndex = Convert.ToInt32(reader["Rol"]) - 1;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            int rol = cmbRol.SelectedIndex + 1; // 1 para Administrador, 2 para Trabajador

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(usuario) || rol == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Lógica para actualizar el usuario en la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellidos = @Apellidos, Usuario = @Usuario, Rol = @Rol";
                if (!string.IsNullOrEmpty(contrasena))
                {
                    query += ", Contrasena = @Contrasena";
                }
                query += " WHERE UsuarioID = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellidos", apellidos);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Rol", rol);
                command.Parameters.AddWithValue("@Id", _usuarioId);

                if (!string.IsNullOrEmpty(contrasena))
                {
                    command.Parameters.AddWithValue("@Contrasena", ObtenerHash(contrasena)); // Actualizar el hash de la contraseña si se proporciona
                }

                command.ExecuteNonQuery();
                MessageBox.Show("Usuario actualizado exitosamente.");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ObtenerHash(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
