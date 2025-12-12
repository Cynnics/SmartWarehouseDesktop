using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using SmartWarehouseDesktop.Utils;  
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormGenerarAlbaran : Form
    {

        private readonly AlbaranService _service = new AlbaranService();
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly PdfGenerator _pdfGenerator = new PdfGenerator();
        private readonly AlbaranService _albaranService = new AlbaranService();


        public FormGenerarAlbaran()
        {
            InitializeComponent();
          
        }
            
        private async void FormAlbaranEditar_Load(object sender, EventArgs e)
        {
            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblPedido);
          
            UIHelper.EstilizarComboBox(cmbPedidos);

            UIHelper.EstilizarBoton(btnGenerar);
            UIHelper.EstiloHover(btnGenerar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnCancelar);

            var pedidos = await _pedidoService.GetAll();
            
            var pedidosEntregados = pedidos.Where(p => p.Estado == "entregado").ToList();
            cmbPedidos.DataSource = pedidosEntregados;
            cmbPedidos.DisplayMember = "IdPedido";
            cmbPedidos.ValueMember = "IdPedido";
        }


        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un pedido.");
                return;
            }

            var pedidoSeleccionado = (PedidoApiModel)cmbPedidos.SelectedItem;

            bool existeAlbaran = await _albaranService.ExisteAlbaran(pedidoSeleccionado.IdPedido);
            if (existeAlbaran)
            {
                MessageBox.Show("Ya existe un albarán para este pedido.");
                return;
            }

            var albaran = new AlbaranApiModel
            {
                IdPedido = pedidoSeleccionado.IdPedido,
                FechaGeneracion = DateTime.Now,
                EntregadoPor = (int)pedidoSeleccionado.IdRepartidor,
                RecibidoPor = "",  
                Estado = "generado"
            };

            bool ok = await _service.Create(albaran);

            if (!ok)
            {
                MessageBox.Show("Error al guardar el albarán.");
                return;
            }

            try
            {
                string rutaPdf = await _pdfGenerator.GenerarAlbaranPdf(pedidoSeleccionado);
                PdfGenerator.AbrirPdf(rutaPdf);
                MessageBox.Show("Albarán generado correctamente.");
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
