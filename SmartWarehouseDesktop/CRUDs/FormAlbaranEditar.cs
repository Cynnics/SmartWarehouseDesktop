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
    public partial class FormAlbaranEditar : Form
    {

        private readonly AlbaranService _service = new AlbaranService();
        private readonly PedidoService _pedidoService = new PedidoService();

        private AlbaranApiModel _albaran;
        private bool _esNuevo;

        public FormAlbaranEditar()
        {
            InitializeComponent();
            _esNuevo = true;
        }

        public FormAlbaranEditar(AlbaranApiModel albaran)
        {
            InitializeComponent();
            _albaran = albaran;
            _esNuevo = false;
        }

        private async void FormAlbaranEditar_Load(object sender, EventArgs e)
        {
            // Estilos
            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblPedido);
            UIHelper.EstilizarLabel(lblFecha);
            UIHelper.EstilizarLabel(lblEntregado);
            UIHelper.EstilizarLabel(lblRecibidoPor);
            UIHelper.EstilizarLabel(lblEstado);

            UIHelper.EstilizarComboBox(cmbPedidos);
            UIHelper.EstilizarDate(dtpFecha);
            UIHelper.EstilizarNumeric(nudEntregadoPor);
            UIHelper.EstilizarTextBox(txtRecibidoPor);
            UIHelper.EstilizarComboBox(cmbEstado);

            UIHelper.EstilizarBoton(btnGuardar);
            UIHelper.EstiloHover(btnGuardar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnCancelar);

            // 1. Cargar pedidos en el combo
            var pedidos = await _pedidoService.GetAll();
            cmbPedidos.DataSource = pedidos;
            cmbPedidos.DisplayMember = "IdPedido";
            cmbPedidos.ValueMember = "IdPedido";

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("generado");
            cmbEstado.Items.Add("entregado");
            cmbEstado.Items.Add("cancelado");

            // 2. Si es edición → cargar datos
            if (!_esNuevo && _albaran != null)
            {
                cmbPedidos.SelectedValue = _albaran.IdPedido;
                dtpFecha.Value = _albaran.FechaGeneracion;
                nudEntregadoPor.Value = _albaran.EntregadoPor;
                txtRecibidoPor.Text = _albaran.RecibidoPor;
                cmbEstado.SelectedItem = _albaran.Estado;
            }
            else
            {
                dtpFecha.Value = DateTime.Now;
                cmbEstado.SelectedItem = "generado";
            }
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var model = new AlbaranApiModel
            {
                IdPedido = (int)cmbPedidos.SelectedValue,
                FechaGeneracion = DateTime.Now,   // SIEMPRE ahora, no editable
                EntregadoPor = (int)nudEntregadoPor.Value,
                RecibidoPor = txtRecibidoPor.Text,
                Estado = "generado"
            };

            bool ok = await _service.Create(model);

            if (ok)
            {
                MessageBox.Show("Albarán creado correctamente.");
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el albarán.");
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
