using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormUbicaciones: Form
    {
        private readonly UbicacionRepartidorService _ubicacionService = new UbicacionRepartidorService();
        private int idRuta;  // 🔹 Guardamos el id de la ruta

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
            
            if (idRuta > 0)
                await CargarUbicacionesPorRutaAsync(idRuta);
            else
                await CargarUbicacionesAsync();

            dgvUbicaciones.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private async Task CargarUbicacionesAsync()
        {
            dgvUbicaciones.DataSource = null;
            List<UbicacionRepartidorApiModel> ubicaciones = await _ubicacionService.GetAll();
            dgvUbicaciones.DataSource = ubicaciones;
        }
        private async Task CargarUbicacionesPorRutaAsync(int idRuta)
        {
            dgvUbicaciones.DataSource = null;
            List<UbicacionRepartidorApiModel> ubicaciones = await _ubicacionService.GetByRuta(idRuta);
            dgvUbicaciones.DataSource = ubicaciones;
        }

        private async void btnCargar_ClickAsync(object sender, EventArgs e)
        {
            await CargarUbicacionesAsync();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idRep = Convert.ToInt32(Prompt.ShowDialog("ID del repartidor:", "Nueva ubicación"));
                decimal lat = Convert.ToDecimal(Prompt.ShowDialog("Latitud:", "Nueva ubicación"));
                decimal lon = Convert.ToDecimal(Prompt.ShowDialog("Longitud:", "Nueva ubicación"));
                DateTime fecha = DateTime.Now;

                var nueva = new UbicacionRepartidorApiModel
                {
                    IdRepartidor = idRep,
                    Latitud = lat,
                    Longitud = lon,
                    FechaHora = fecha
                };

                bool success = await _ubicacionService.Create(nueva);
                if (success)
                {
                    MessageBox.Show("Ubicación registrada correctamente.");
                    await CargarUbicacionesAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la ubicación.");
                }
            }
            catch
            {
                MessageBox.Show("Error al agregar ubicación.");
            }
        }

        private async Task btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUbicaciones.CurrentRow == null) return;

            var u = (UbicacionRepartidorApiModel)dgvUbicaciones.CurrentRow.DataBoundItem;
           
            var confirm = MessageBox.Show($"¿Eliminar ubicación #{u.IdUbicacion}?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool success = await _ubicacionService.Delete(u.IdUbicacion);
                if (success)
                {
                    MessageBox.Show("Ubicación eliminada correctamente.");
                    await CargarUbicacionesAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la ubicación.");
                }
            }
        }
    }
}