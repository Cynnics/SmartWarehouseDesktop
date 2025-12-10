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
                var totales = await _pedidoService.GetTotales(pedidoSeleccionado.IdPedido);

                

                // 1️⃣ Crear la factura en la base de datos
                var factura = new FacturaApiModel
                {
                    IdPedido = pedidoSeleccionado.IdPedido,
                    Subtotal = totales.Subtotal,
                    IVA = totales.IVA,
                    Total = totales.Total,
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
                var cliente = await _userService.GetById(pedido.IdCliente);
                string rutaPdf = await pdfGenerator.GenerarFacturaPdf(factura, pedido, cliente);

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



    }
}
