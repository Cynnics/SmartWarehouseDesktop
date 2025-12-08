using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
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
    public partial class FormRutasEntregaEditar : Form
    {
        private readonly RepartidorService _repService = new RepartidorService();
        private readonly RutaEntregaService _service = new RutaEntregaService();
        private RutaEntregaApiModel _ruta;
        private bool _esNuevo;

        public FormRutasEntregaEditar(RutaEntregaApiModel ruta = null)
        {
            InitializeComponent();
            _ruta = ruta;
            _esNuevo = ruta == null;
        }

        private async void FormRutasEntregaEditar_Load(object sender, EventArgs e)
        {
            var repartidores = await _repService.GetAll();

            cmbRepartidor.DataSource = repartidores;
            cmbRepartidor.DisplayMember = "Nombre";
            cmbRepartidor.ValueMember = "IdUsuario";

            cmbEstado.Items.AddRange(new[] { "planificada", "en_proceso", "completada", "cancelada" });

            if (!_esNuevo)
            {
                cmbRepartidor.SelectedValue = _ruta.IdRepartidor;
                dtpFechaRuta.Value = _ruta.FechaRuta;
                nudDistancia.Value = _ruta.DistanciaEstimadaKm ?? 0;
                nudDuracion.Value = _ruta.DuracionEstimadaMin ?? 0;
                cmbEstado.SelectedItem = _ruta.Estado;
            }
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var modelo = new RutaEntregaApiModel
            {
                IdRuta = _ruta?.IdRuta ?? 0,
                IdRepartidor = (int)cmbRepartidor.SelectedValue,
                FechaRuta = dtpFechaRuta.Value,
                DistanciaEstimadaKm = nudDistancia.Value,
                DuracionEstimadaMin = (int)nudDuracion.Value,
                Estado = cmbEstado.SelectedItem.ToString()
            };

            bool ok = _esNuevo
                ? await _service.Create(modelo)
                : await _service.Update(modelo);

            if (ok)
            {
                MessageBox.Show("Ruta guardada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la ruta.");
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
