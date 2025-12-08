using SmartWarehouseDesktop.ApiModels;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormDetallesPedido: Form
    {
        private readonly DetallePedidoService _service = new DetallePedidoService();


        public FormDetallesPedido()
        {
            InitializeComponent();
        }

        private int idPedidoSeleccionado = 0;

        public FormDetallesPedido(int idPedido)
        {
            InitializeComponent();
            idPedidoSeleccionado = idPedido;
        }

        private void FormDetallesPedido_Load(object sender, EventArgs e)
        {
            if (idPedidoSeleccionado > 0)
                 CargarDetallesPorPedido(idPedidoSeleccionado);
            else
                 CargarDetalles();


            dgvDetalles.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEditar);
            UIHelper.EstiloHover(btnEditar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private async void CargarDetalles()
        {
            dgvDetalles.DataSource = await _service.GetAll();
        }



        private async void CargarDetallesPorPedido(int idPedido)
        {
            dgvDetalles.DataSource = await _service.GetByPedido(idPedido);
        }



        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDetalles();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new FormDetallePedidoEditar();
            if (form.ShowDialog() == DialogResult.OK)
                CargarDetalles();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null) return;

            DetallePedidoApiModel d = (DetallePedidoApiModel)dgvDetalles.CurrentRow.DataBoundItem;

            using (var frm = new FormDetallePedidoEditar(d))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                     CargarDetalles(); // O cargar por pedido
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var d = (DetallePedidoApiModel)dgvDetalles.CurrentRow.DataBoundItem;

            if (await _service.Delete(d.IdDetalle))
            {
                MessageBox.Show("Detalle eliminado.");
                CargarDetalles();
            }
        }
    }
}