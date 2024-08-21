using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SistemaDeCalidadPABSA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            VerificarUsuariosAdministradores();
        }

        private void VerificarUsuariosAdministradores()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Rol = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        btnAgregarAdmin.Visible = count == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar usuarios administradores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarAdmin_Click(object sender, EventArgs e)
        {
            using (AgregarUsuarioForm form = new AgregarUsuarioForm())
            {
                form.ShowDialog(); // Mostrar el formulario como modal
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rolUsuario = AutenticarYObtenerRol(usuario, contrasena); // Autenticar y obtener el rol del usuario

                if (rolUsuario != -1) // Si la autenticación fue exitosa
                {
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MenuPrincipal menuPrincipal = new MenuPrincipal(rolUsuario); // Pasa el rol al constructor
                    menuPrincipal.Show();
                    this.Hide(); // Ocultar el formulario de login
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el inicio de sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este método autentica al usuario y devuelve el rol si es exitoso, o -1 si falla.
        private int AutenticarYObtenerRol(string usuario, string contrasena)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Rol FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contrasena", ObtenerHash(contrasena)); // Comparar el hash de la contraseña

                        object result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la autenticación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Método para generar el hash de la contraseña.
        private string ObtenerHash(string contrasena)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                    return Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el hash de la contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Lógica adicional para cargar el formulario
        }
    }
}
