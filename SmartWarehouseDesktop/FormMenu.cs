using SmartWarehouseDesktop.CRUDs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            pnlTop.BackColor = TemaApp.AzulOscuro;
            pnlMenu.BackColor = TemaApp.AzulOscuro;
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
            AbrirFormulario(new FormRutas());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir?", "Confirmar salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
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

    }
}