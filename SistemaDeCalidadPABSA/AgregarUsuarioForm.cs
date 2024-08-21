using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeCalidadPABSA
{
    public partial class AgregarUsuarioForm : Form
    {
        public AgregarUsuarioForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            int rol = cmbRol.SelectedIndex + 1; // Asigna 1 para Administrador y 2 para Trabajador

            if (rol < 1 || rol > 2)
            {
                MessageBox.Show("Seleccione un rol válido.");
                return;
            }

            // Encriptar la contraseña
            string contrasenaEncriptada = EncriptarContrasena(contrasena);

            // Define la cadena de conexión
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Consulta SQL para insertar el nuevo usuario
            string query = "INSERT INTO Usuarios (Nombre, Apellidos, Usuario, Contrasena, Rol) VALUES (@Nombre, @Apellidos, @Usuario, @Contrasena, @Rol)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agrega los parámetros a la consulta
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellidos);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasenaEncriptada);
                    command.Parameters.AddWithValue("@Rol", rol);

                    try
                    {
                        // Abre la conexión y ejecuta la consulta
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario guardado exitosamente.");
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al guardar el usuario: " + ex.Message);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string EncriptarContrasena(string contrasena)
        {

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasena));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
