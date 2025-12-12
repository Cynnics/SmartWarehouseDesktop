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
            
            if (idRuta > 0)
                await CargarUbicacionesPorRutaAsync(idRuta);
            else
                await CargarUbicacionesAsync();

            dgvUbicaciones.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
           
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

       
    }
}