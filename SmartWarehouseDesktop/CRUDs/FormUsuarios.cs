using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using SmartWarehouseDesktop.DAOs;
using SmartWarehouseDesktop.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormUsuarios: Form
    {
        private readonly UserService _service = new UserService();
        private readonly BindingSource _bs = new BindingSource();

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private async void FormUsuarios_Load(object sender, EventArgs e)
        {

            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = _bs;

            await CargarUsuarios();
            BackColor = TemaApp.AzulIntermedio;
            dgvUsuarios.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEditar);
            UIHelper.EstiloHover(btnEditar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private async Task CargarUsuarios()
        {
            try
            {
                var lista = await _service.GetAll();

                if (lista == null)
                {
                    MessageBox.Show("No se pudieron cargar los usuarios.");
                    return;
                }

                _bs.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando usuarios: " + ex.Message);
            }
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new FormUsuarioEditar(null);
            if (frm.ShowDialog() == DialogResult.OK)
                await CargarUsuarios();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            var usuario = dgvUsuarios.CurrentRow.DataBoundItem as UserApiModel;
            if (usuario == null) return;

            var frm = new FormUsuarioEditar(usuario);
            if (frm.ShowDialog() == DialogResult.OK)
                await CargarUsuarios();
        }



        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            var u = dgvUsuarios.CurrentRow.DataBoundItem as UserApiModel;
            if (u == null) return;

            var confirm = MessageBox.Show($"¿Eliminar usuario '{u.Nombre}'?",
                                          "Confirmar", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes) return;

            var ok = await _service.Delete(u.IdUsuario);

            if (ok)
                MessageBox.Show("Usuario eliminado.");
            else
                MessageBox.Show("No se pudo eliminar el usuario.");

            await CargarUsuarios();
        }

    }
}