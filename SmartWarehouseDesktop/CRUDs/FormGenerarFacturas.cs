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

        public FormGenerarFactura()
        {
            InitializeComponent();
        }

        private async void FormGenerarFactura_Load(object sender, EventArgs e)
        {

            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblPedido);
            UIHelper.EstilizarLabel(lblFecha);
            UIHelper.EstilizarLabel(lblSubtotal);
            UIHelper.EstilizarLabel(lblIVA);
            UIHelper.EstilizarLabel(lblTotal);
            UIHelper.EstilizarBoton(btnGenerar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGenerar);
            UIHelper.EstiloHover(btnCancelar);

            var pedidos = await _pedidoService.GetEntregados();

            cmbPedidos.DataSource = pedidos;
            cmbPedidos.DisplayMember = "IdPedido";
            cmbPedidos.ValueMember = "IdPedido";

            dtpFecha.Value = DateTime.Now;
            nudIVA.Value = 21;

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
                // 1️⃣ Crear la factura en la base de datos
                var factura = new FacturaApiModel
                {
                    IdPedido = (int)cmbPedidos.SelectedValue,
                    Subtotal = nudSubtotal.Value,
                    IVA = nudIVA.Value,
                    Total = nudTotal.Value,
                    FechaEmision = DateTime.Now
                };

                bool ok = await _facturaService.Create(factura);

                if (!ok)
                {
                    MessageBox.Show("Error al generar factura en la base de datos.");
                    return;
                }

                // 2️⃣ Obtener los datos completos del pedido y factura
                var pedidoService = new PedidoService();
                var pedido = await pedidoService.GetById(factura.IdPedido);

                if (pedido == null)
                {
                    MessageBox.Show("No se pudo obtener el pedido asociado a la factura.");
                    return;
                }

                // 3️⃣ Generar el PDF de la factura
                var pdfGenerator = new PdfGenerator();
                string rutaPdf = await pdfGenerator.GenerarFacturaPdf(factura, pedido);

                // 4️⃣ Abrir automáticamente el PDF
                PdfGenerator.AbrirPdf(rutaPdf);

                MessageBox.Show("Factura generada correctamente y PDF creado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura/PDF: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void cmbPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pedido = cmbPedidos.SelectedItem as PedidoApiModel;
            if (pedido == null)
                return;

            try
            {
                var totales = await _pedidoService.GetTotales(pedido.IdPedido);

                nudSubtotal.Value = totales.Subtotal;
                nudIVA.Value = totales.IVA;
                nudTotal.Value = totales.Total;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los totales: " + ex.Message);
            }
        }


    }
}
