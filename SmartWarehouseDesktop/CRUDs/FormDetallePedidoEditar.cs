using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormDetallePedidoEditar : Form
    {
        private readonly DetallePedidoService _service = new DetallePedidoService();
        private readonly DetallePedidoApiModel _detalle;
        private readonly bool _esNuevo;

        public FormDetallePedidoEditar(DetallePedidoApiModel detalle = null)
        {
            InitializeComponent();
            _detalle = detalle;
            _esNuevo = detalle == null;
        }

        private void FormDetallePedidoEditar_Load(object sender, EventArgs e)
        {
            if (!_esNuevo)
            {
                nudIDPedido.Value = _detalle.IdPedido;
                nudIDProducto.Value = _detalle.IdProducto;
                nudCantidad.Value = _detalle.Cantidad;
                nudSubtotal.Value = _detalle.Subtotal;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var model = new DetallePedidoApiModel
            {
                IdDetalle = _detalle?.IdDetalle ?? 0,
                IdPedido = (int)nudIDPedido.Value,
                IdProducto = (int)nudIDProducto.Value,
                Cantidad = (int)nudCantidad.Value,
                Subtotal = nudSubtotal.Value
            };

            bool ok;

            if (_esNuevo)
                ok = await _service.Create(model);
            else
                ok = await _service.Update(model.IdDetalle, model);

            if (ok)
            {
                MessageBox.Show("Detalle guardado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error al guardar detalle.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}