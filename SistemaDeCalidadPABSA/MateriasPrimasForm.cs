using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeCalidadPABSA
{
    public partial class MateriasPrimasForm : Form
    {
        public MateriasPrimasForm()
        {
            InitializeComponent();
        }

        // Evento para manejar el clic en el botón "Proveedores"
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario o vista correspondiente a los proveedores.
            ProveedoresForm proveedoresForm = new ProveedoresForm();
            proveedoresForm.Show();
        }

        // Evento para manejar el clic en el botón "Ingredientes"
        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario o vista correspondiente a los ingredientes.
            IngredientesForm ingredientesForm = new IngredientesForm();
            ingredientesForm.Show();
        }

        // Evento para manejar el clic en el botón "Agregar Análisis de Materias Primas"
        private void btnAgregarAnalisis_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario o vista correspondiente al análisis de materias primas.
            AgregarAnalisisForm agregarAnalisisForm = new AgregarAnalisisForm();
            agregarAnalisisForm.Show();
        }

        // Evento para manejar el clic en el botón "Reporte de Materias Primas"
        private void btnReporteMateriasPrimas_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir el formulario o vista correspondiente al reporte de materias primas.
            ReporteMateriasPrimasForm reporteMateriasPrimasForm = new ReporteMateriasPrimasForm();
            reporteMateriasPrimasForm.Show();
        }
    }
}
