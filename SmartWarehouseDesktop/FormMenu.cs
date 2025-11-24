using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.CRUDs;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            if (Session.Token == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                this.Close();
                return;
            }

            
            ConfigurarPermisos();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            pnlTop.BackColor = TemaApp.AzulOscuro;
            pnlMenu.BackColor = TemaApp.AzulOscuro;
            lblUsuario.Text = $"{Session.UsuarioActual.Nombre} ({Session.UsuarioActual.Rol})"; 
            UIHelper.EstilizarLabel(lblTitulo, esTitulo : true);
            UIHelper.EstilizarLabel(lblUsuario);
            UIHelper.EstilizarBoton(btnProductos);
            UIHelper.EstilizarBoton(btnUsuarios);
            UIHelper.EstilizarBoton(btnPedidos);
            UIHelper.EstilizarBoton(btnFacturas);
            UIHelper.EstilizarBoton(btnAlbaranes);
            UIHelper.EstilizarBoton(btnRutas);
            UIHelper.EstilizarBoton(btnSalir);
            UIHelper.EstiloHover(btnProductos);
            UIHelper.EstiloHover(btnUsuarios);
            UIHelper.EstiloHover(btnPedidos);
            UIHelper.EstiloHover(btnFacturas);
            UIHelper.EstiloHover(btnAlbaranes);
            UIHelper.EstiloHover(btnRutas);
            UIHelper.EstiloHover(btnSalir);
            ConfigurarPermisos();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormProductos());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormUsuarios());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormPedidos());
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormFacturas());
        }

        private void btnAlbaranes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAlbaranes());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormRutasEntrega());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesión?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.Clear();
                this.Close();  // ← esto devuelve al login sin cerrar la app
            }
        }




        private void AbrirFormulario(Form formHijo)
        {
            pnlContenido.Controls.Clear();
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void ConfigurarPermisos()
        {
            var rol = Session.UsuarioActual.Rol;

            if (rol == "empleado")
            {
                btnUsuarios.Enabled = false;
            }
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}