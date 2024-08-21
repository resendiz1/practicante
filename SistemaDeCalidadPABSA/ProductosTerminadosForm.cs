using System;
using System.Windows.Forms;

namespace SistemaDeCalidadPABSA
{
    public partial class ProductosTerminadosForm : Form
    {
        public ProductosTerminadosForm()
        {
            InitializeComponent();
        }

        private void btnEspecies_Click(object sender, EventArgs e)
        {
            // Abre el formulario para gestionar especies
            EspeciesForm especiesForm = new EspeciesForm();
            especiesForm.Show();
        }

        private void btnProductosTerminados_Click(object sender, EventArgs e)
        {
            // Abre el formulario para gestionar productos terminados
            ProductosTerminadosListForm productosTerminadosForm = new ProductosTerminadosListForm();
            productosTerminadosForm.Show();
        }

        private void btnAgregarAnalisisProducto_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar análisis de producto
            AgregarAnalisisProductoForm agregarAnalisisProductoForm = new AgregarAnalisisProductoForm();
            agregarAnalisisProductoForm.Show();
        }

        private void btnResultadosAnalisis_Click(object sender, EventArgs e)
        {
            // Abre el formulario para ver resultados de análisis
            ResultadosAnalisisForm resultadosAnalisisForm = new ResultadosAnalisisForm();
            resultadosAnalisisForm.Show();
        }
    }
}
