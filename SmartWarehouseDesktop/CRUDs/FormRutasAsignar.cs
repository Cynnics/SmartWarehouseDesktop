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
        private readonly RutaEntregaService _rutaEntregaService = new RutaEntregaService();
        private readonly RutaPedidoService _rutaPedidoService = new RutaPedidoService();

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
            if (cmbPedidos.SelectedItem == null || cmbRepartidor.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar pedido y repartidor.");
                return;
            }

            int idPedido = (int)cmbPedidos.SelectedValue;
            int idRepartidor = (int)cmbRepartidor.SelectedValue;

            // 1️⃣ Crear la ruta nueva
            var nuevaRuta = new RutaEntregaApiModel
            {
                IdRepartidor = idRepartidor,
                FechaRuta = DateTime.Now,
                DistanciaEstimadaKm = 0,
                DuracionEstimadaMin = 0,
                Estado = "pendiente"
            };

            int? idRutaCreada = await _rutaEntregaService.CreateAndReturnId(nuevaRuta);

            if (idRutaCreada == null)   
            {
                MessageBox.Show("Error al crear la ruta.");
                return;
            }

            // 2️⃣ Asignar pedido a esa ruta
            bool asignado = await _rutaPedidoService.AsignarPedido(idRutaCreada.Value, idPedido);

            if (!asignado)
            {
                MessageBox.Show("La ruta se creó pero no se pudo asignar el pedido.");
                return;
            }

            MessageBox.Show("Ruta creada y pedido asignado correctamente.");
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
