using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using SmartWarehouseDesktop.Utils;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormGenerarFactura : Form
    {
        private readonly FacturaService _facturaService = new FacturaService();
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly UserService _userService = new UserService();
        
        public FormGenerarFactura()
        {
            InitializeComponent();
        }

        private async void FormGenerarFactura_Load(object sender, EventArgs e)
        {

            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblPedido);
            UIHelper.EstilizarBoton(btnGenerar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGenerar);
            UIHelper.EstiloHover(btnCancelar);

            var pedidos = await _pedidoService.GetEntregados();

            cmbPedidos.DataSource = pedidos;
            cmbPedidos.DisplayMember = "IdPedido";
            cmbPedidos.ValueMember = "IdPedido";

        }


        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un pedido entregado.");
                return;
            }

            try
            {
                var pedidoSeleccionado = (PedidoApiModel)cmbPedidos.SelectedItem;

                bool existeFactura = await _facturaService.ExisteFactura(pedidoSeleccionado.IdPedido);
                if (existeFactura)
                {
                    MessageBox.Show("Ya existe una factura para este pedido.");
                    return;
                }
                var totales = await _pedidoService.GetTotales(pedidoSeleccionado.IdPedido);

                if (totales == null)
                {
                    MessageBox.Show("No se pudieron obtener los totales del pedido.");
                    return;
                }
                MessageBox.Show($"Totales obtenidos:\nSubtotal: {totales.Subtotal}\nIVA: {totales.IVA}\nTotal: {totales.Total}");

                var nuevaFactura = new FacturaApiModel
                {
                    IdPedido = pedidoSeleccionado.IdPedido,
                    Subtotal = totales.Subtotal,
                    IVA = totales.IVA,
                    Total = totales.Total,
                    FechaEmision = DateTime.Now
                };

                bool ok = await _facturaService.Create(nuevaFactura);
                if (!ok)
                {
                    MessageBox.Show("Error al generar factura en la base de datos.");
                    return;
                }

                var facturasDelPedido = await _facturaService.GetByPedido(pedidoSeleccionado.IdPedido);
                if (facturasDelPedido == null || facturasDelPedido.Count == 0)
                {
                    MessageBox.Show("Error: No se pudo recuperar la factura creada.");
                    return;
                }

                var facturaCreada = facturasDelPedido[facturasDelPedido.Count - 1];

                var pedido = await _pedidoService.GetById(facturaCreada.IdPedido);
                if (pedido == null)
                {
                    MessageBox.Show("No se pudo obtener el pedido asociado a la factura.");
                    return;
                }
                var cliente = await _userService.GetById(pedido.IdCliente);
                if (cliente == null)
                {
                    MessageBox.Show("No se pudo obtener la información del cliente.");
                    return;
                }

                var pdfGenerator = new PdfGenerator();
                string rutaPdf = await pdfGenerator.GenerarFacturaPdf(facturaCreada, pedido, cliente);

                PdfGenerator.AbrirPdf(rutaPdf);

                MessageBox.Show($"Factura generada correctamente\n\nPDF creado en:\n{rutaPdf}",
                               "Éxito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Error al leer los datos JSON:\n{ex.Message}\n\nAsegúrate de que la API devuelve datos válidos.",
                               "Error de deserialización",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al generar la factura/PDF:\n{ex.Message}";

                if (ex.InnerException != null)
                {
                    mensaje += $"\n\nDetalles: {ex.InnerException.Message}";
                }

                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }



    }
}
