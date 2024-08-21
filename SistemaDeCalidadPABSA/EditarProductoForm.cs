﻿using Microsoft.Data.SqlClient;
using System;
using System.Configuration; // Asegúrate de tener esta referencia
using System.Windows.Forms;

namespace SistemaDeCalidadPABSA
{
    public partial class EditarProductoForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private int productoId; // ID del producto a editar

        public EditarProductoForm(int id)
        {
            InitializeComponent();
            productoId = id;
            CargarDatosProducto();
        }

        private void CargarDatosProducto()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Nombre, Descripcion, ProteinaGarantia, GrasaGarantia, FibraGarantia, CenizasGarantia, HumedadGarantia, FechaCreacion " +
                                   "FROM Productos WHERE ProductoID = @ProductoID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductoID", productoId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtDescripcion.Text = reader["Descripcion"].ToString();
                                txtProteinaGarantia.Text = reader["ProteinaGarantia"].ToString();
                                txtGrasaGarantia.Text = reader["GrasaGarantia"].ToString();
                                txtFibraGarantia.Text = reader["FibraGarantia"].ToString();
                                txtCenizasGarantia.Text = reader["CenizasGarantia"].ToString();
                                txtHumedadGarantia.Text = reader["HumedadGarantia"].ToString();
                                dtpFechaCreacion.Value = Convert.ToDateTime(reader["FechaCreacion"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar la entrada
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                !decimal.TryParse(txtProteinaGarantia.Text, out decimal proteinaGarantia) ||
                !decimal.TryParse(txtGrasaGarantia.Text, out decimal grasaGarantia) ||
                !decimal.TryParse(txtFibraGarantia.Text, out decimal fibraGarantia) ||
                !decimal.TryParse(txtCenizasGarantia.Text, out decimal cenizasGarantia) ||
                !decimal.TryParse(txtHumedadGarantia.Text, out decimal humedadGarantia))
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Conectar a la base de datos y actualizar el producto
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, ProteinaGarantia = @ProteinaGarantia, " +
                                   "GrasaGarantia = @GrasaGarantia, FibraGarantia = @FibraGarantia, CenizasGarantia = @CenizasGarantia, " +
                                   "HumedadGarantia = @HumedadGarantia, FechaCreacion = @FechaCreacion " +
                                   "WHERE ProductoID = @ProductoID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        command.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                        command.Parameters.AddWithValue("@ProteinaGarantia", proteinaGarantia);
                        command.Parameters.AddWithValue("@GrasaGarantia", grasaGarantia);
                        command.Parameters.AddWithValue("@FibraGarantia", fibraGarantia);
                        command.Parameters.AddWithValue("@CenizasGarantia", cenizasGarantia);
                        command.Parameters.AddWithValue("@HumedadGarantia", humedadGarantia);
                        command.Parameters.AddWithValue("@FechaCreacion", dtpFechaCreacion.Value);
                        command.Parameters.AddWithValue("@ProductoID", productoId);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Indicar que se guardaron los cambios
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indicar que se canceló la operación
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
