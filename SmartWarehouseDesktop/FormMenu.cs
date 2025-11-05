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
            lblTitulo.Text = "SmartWarehouse - Panel Principal";
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new FormProductos().ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new FormUsuarios().ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            new FormPedidos().ShowDialog();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            new FormFacturas().ShowDialog();
        }

        private void btnAlbaranes_Click(object sender, EventArgs e)
        {
            new FormAlbaranes().ShowDialog();
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            new FormRutas().ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir?", "Confirmar salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}