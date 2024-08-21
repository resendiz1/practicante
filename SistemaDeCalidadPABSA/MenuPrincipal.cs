using System;
using System.Windows.Forms;

namespace SistemaDeCalidadPABSA
{
    public partial class MenuPrincipal : Form
    {
        private readonly int _rolUsuario;
        private readonly ToolTip _toolTip = new ToolTip();

        public MenuPrincipal(int rolUsuario)
        {
            InitializeComponent();
            _rolUsuario = rolUsuario;
            ConfigurarAcceso(); // Verificar los permisos del usuario
        }

        private void ConfigurarAcceso()
        {
            ConfigurarAccesoASeccion(btnUsuarios, "Usuarios", _rolUsuario == 1);
        }

        private void ConfigurarAccesoASeccion(Button boton, string nombreSeccion, bool tieneAcceso)
        {
            if (!tieneAcceso)
            {
                boton.Enabled = false;
                _toolTip.SetToolTip(boton, $"No tienes permisos para acceder a {nombreSeccion}.");
            }
        }

        private void btnProductosTerminados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ProductosTerminadosForm());
        }

        private void btnMateriasPrimas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new MateriasPrimasForm());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new UsuariosForm());
        }

        private void AbrirFormulario(Form form)
        {
            using (form)
            {
                form.ShowDialog();
            }
        }
    }
}
