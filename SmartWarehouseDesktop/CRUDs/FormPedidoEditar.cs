using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormPedidoEditar : Form
    {
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly PedidoApiModel _pedido; // null si es nuevo
        private readonly bool _esNuevo;

        public FormPedidoEditar(PedidoApiModel pedido = null)
        {
            InitializeComponent();
            _pedido = pedido;
            _esNuevo = pedido == null;
        }

        private void FormPedidoEditar_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.AddRange(new string[] { "pendiente", "preparado", "en_reparto", "entregado" });

            if (!_esNuevo)
            {
                dtpFechaPedido.Value = _pedido.FechaPedido;
                cmbEstado.SelectedItem = _pedido.Estado;
                nudCliente.Value = _pedido.IdCliente;
                nudRepartidor.Value = _pedido.IdRepartidor ?? 0;
            }
            else
            {
                dtpFechaPedido.Value = DateTime.Now;
                cmbEstado.SelectedIndex = 0;
            }

            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblFechaPedido);
            UIHelper.EstilizarLabel(lblEstado);
            UIHelper.EstilizarLabel(lblCliente);
            UIHelper.EstilizarLabel(lblRepartidor);
            UIHelper.EstilizarDate(dtpFechaPedido);
            UIHelper.EstilizarComboBox(cmbEstado);
            UIHelper.EstilizarNumeric(nudCliente);
            UIHelper.EstilizarNumeric(nudRepartidor);
            UIHelper.EstilizarBoton(btnGuardar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGuardar);
            UIHelper.EstiloHover(btnCancelar);

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var model = new PedidoApiModel
            {
                IdPedido = _pedido?.IdPedido ?? 0,
                FechaPedido = dtpFechaPedido.Value,
                Estado = cmbEstado.SelectedItem.ToString(),
                IdCliente = (int)nudCliente.Value,
                IdRepartidor = (int)nudRepartidor.Value
            };

            bool ok;

            if (_esNuevo)
                ok = await _pedidoService.Create(model);
            else
                ok = await _pedidoService.Update(model);

            if (ok)
            {
                MessageBox.Show("Pedido guardado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error al guardar pedido.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}

