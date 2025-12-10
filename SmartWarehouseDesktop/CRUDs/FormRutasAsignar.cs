using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormRutasAsignar : Form
    {
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly UserService _usuarioService = new UserService();

        public FormRutasAsignar()
        {
            InitializeComponent();
        }

        private async void FormRutasAsignar_Load(object sender, EventArgs e)
        {
            // Estilos
            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblPedido);
            UIHelper.EstilizarLabel(lblIDRepartidor);

            UIHelper.EstilizarComboBox(cmbPedidos);
            UIHelper.EstilizarComboBox(cmbRepartidor);

            UIHelper.EstilizarBoton(btnAsignar);
            UIHelper.EstiloHover(btnAsignar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnCancelar);

            // 1️⃣ Cargar pedidos pendientes
            var pedidos = await _pedidoService.GetAll();
            var pedidosPendiente = pedidos
                .Where(p => p.Estado == "pendiente" || p.Estado == "preparado")
                .Where(p => p.IdRepartidor == null || p.IdRepartidor == 0)
                .ToList();

            cmbPedidos.DataSource = pedidosPendiente;
            cmbPedidos.DisplayMember = "IdPedido";
            cmbPedidos.ValueMember = "IdPedido";

            // 2️⃣ Cargar repartidores
            var usuarios = await _usuarioService.GetAll();
            var repartidores = usuarios
                .Where(u => u.Rol.ToLower() == "repartidor")
                .ToList();

            cmbRepartidor.DataSource = repartidores;
            cmbRepartidor.DisplayMember = "Nombre";     // puedes usar Nombre + Apellido si quieres
            cmbRepartidor.ValueMember = "IdUsuario";
        }

        private async void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un pedido.");
                return;
            }

            if (cmbRepartidor.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un repartidor.");
                return;
            }

            var pedidoSeleccionado = (PedidoApiModel)cmbPedidos.SelectedItem;
            var repartidorSeleccionado = (UserApiModel)cmbRepartidor.SelectedItem;

            // Llamar al nuevo método que solo actualiza IdRepartidor y Estado
            bool ok = await _pedidoService.UpdateRepartidor(
                pedidoSeleccionado.IdPedido,
                repartidorSeleccionado.IdUsuario,
                "ruta_asignada"
            );

            if (!ok)
            {
                MessageBox.Show("Error al asignar la ruta.");
                return;
            }

            MessageBox.Show("Ruta asignada correctamente.");
            this.DialogResult = DialogResult.OK;
            Close();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
