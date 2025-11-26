using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormUbicaciones : Form
    {
        private readonly UbicacionRepartidorService _service = new UbicacionRepartidorService();
        private int idRuta;

        public FormUbicaciones()
        {
            InitializeComponent();
        }

        public FormUbicaciones(int idRuta)
        {
            InitializeComponent();
            this.idRuta = idRuta;
        }

        private async void FormUbicaciones_Load(object sender, EventArgs e)
        {

            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstiloHover(btnEliminar);


            lblTitulo.Text = idRuta > 0
                ? $"Ubicaciones de la ruta #{idRuta}"
                : "Ubicaciones";

            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            dgvUbicaciones.DataSource = null;

            List<UbicacionRepartidorApiModel> ubicaciones;

            if (idRuta > 0)
                ubicaciones = await _service.GetByRuta(idRuta);
            else
                ubicaciones = await _service.GetAll();

            dgvUbicaciones.DataSource = ubicaciones;
        }

        // BTN CARGAR
        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarDatos();
        }

        // BTN AGREGAR
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var f = new FormUbicacionesEditar())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    await CargarDatos();
            }
        }


        // BTN ELIMINAR
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUbicaciones.CurrentRow == null) return;

            var u = (UbicacionRepartidorApiModel)dgvUbicaciones.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Eliminar ubicación #{u.IdUbicacion}?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool ok = await _service.Delete(u.IdUbicacion);

                if (ok)
                {
                    MessageBox.Show("Ubicación eliminada.");
                    await CargarDatos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la ubicación.");
                }
            }
        }
    }
}
