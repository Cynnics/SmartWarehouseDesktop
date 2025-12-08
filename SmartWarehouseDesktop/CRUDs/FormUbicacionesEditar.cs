using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormUbicacionesEditar : Form
    {
        private readonly UbicacionRepartidorService _service = new UbicacionRepartidorService();
        private readonly RepartidorService _repService = new RepartidorService();
        private UbicacionRepartidorApiModel _ubicacion;
        private bool _esNuevo;

        public FormUbicacionesEditar(UbicacionRepartidorApiModel ubic = null)
        {
            InitializeComponent();
            _ubicacion = ubic;
            _esNuevo = ubic == null;
        }

        private async void FormUbicacionesEditar_Load(object sender, EventArgs e)
        {
            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblRepartidor);
            UIHelper.EstilizarLabel(lblLatitud);
            UIHelper.EstilizarLabel(lblLongitud);
            UIHelper.EstilizarLabel(lblFecha);
            UIHelper.EstilizarNumeric(nudLatitud);
            UIHelper.EstilizarNumeric(nudLongitud);
            UIHelper.EstilizarComboBox(cmbRepartidor);
            UIHelper.EstilizarDate(dtpFecha);
            UIHelper.EstilizarBoton(btnGuardar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGuardar);
            UIHelper.EstiloHover(btnCancelar);


            // cargar repartidores
            var reps = await _repService.GetAll();

            cmbRepartidor.DataSource = reps;
            cmbRepartidor.DisplayMember = "Nombre";
            cmbRepartidor.ValueMember = "IdUsuario";

            if (!_esNuevo)
            {
                cmbRepartidor.SelectedValue = _ubicacion.IdRepartidor;
                nudLatitud.Value = _ubicacion.Latitud;
                nudLongitud.Value = _ubicacion.Longitud;
                dtpFecha.Value = _ubicacion.FechaHora;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbRepartidor.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un repartidor.");
                return;
            }

            var modelo = new UbicacionRepartidorApiModel
            {
                IdUbicacion = _ubicacion?.IdUbicacion ?? 0,
                IdRepartidor = (int)cmbRepartidor.SelectedValue,
                Latitud = nudLatitud.Value,
                Longitud = nudLongitud.Value,
                FechaHora = dtpFecha.Value
            };

            bool ok = _esNuevo
                ? await _service.Create(modelo)
                : await _service.Update(modelo);

            if (ok)
            {
                MessageBox.Show("Ubicación guardada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la ubicación.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
