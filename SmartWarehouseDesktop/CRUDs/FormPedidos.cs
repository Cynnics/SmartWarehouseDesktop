using SmartWarehouseDesktop.DAOs;
using SmartWarehouseDesktop.Entity;
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
    public partial class FormPedidos: Form
    {
        private PedidoDAO pedidoDAO = new PedidoDAO();
        private UsuarioDAO usuarioDAO = new UsuarioDAO(); // Para obtener clientes/repartidores

        public FormPedidos()
        {
            InitializeComponent();
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            //CargarPedidos();
            BackColor = TemaApp.AzulIntermedio;
            dgvPedidos.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEditar);
            UIHelper.EstiloHover(btnEditar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
            UIHelper.EstilizarBoton(btnForm);
            UIHelper.EstiloHover(btnForm);
        }

        private void CargarPedidos()
        {
            dgvPedidos.DataSource = null;
            List<Pedido> pedidos = pedidoDAO.ObtenerPedidos();
            dgvPedidos.DataSource = pedidos;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = Convert.ToInt32(Prompt.ShowDialog("ID del cliente:", "Nuevo pedido"));
                string estado = Prompt.ShowDialog("Estado (Pendiente/En curso/Entregado):", "Nuevo pedido");

                Pedido nuevo = new Pedido
                {
                    FechaPedido = DateTime.Now,
                    Estado = estado,
                    IdCliente = idCliente,
                    IdRepartidor = null
                };

                if (pedidoDAO.InsertarPedido(nuevo))
                {
                    MessageBox.Show("Pedido agregado correctamente.");
                    CargarPedidos();
                }
            }
            catch
            {
                MessageBox.Show("Error al agregar pedido.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;

            Pedido p = (Pedido)dgvPedidos.CurrentRow.DataBoundItem;

            try
            {
                p.Estado = Prompt.ShowDialog("Estado:", "Editar pedido", p.Estado);
                string idRep = Prompt.ShowDialog("ID Repartidor (dejar vacío si ninguno):", "Editar pedido", p.IdRepartidor?.ToString() ?? "");
                p.IdRepartidor = string.IsNullOrEmpty(idRep) ? (int?)null : int.Parse(idRep);

                if (pedidoDAO.ActualizarPedido(p))
                {
                    MessageBox.Show("Pedido actualizado correctamente.");
                    CargarPedidos();
                }
            }
            catch
            {
                MessageBox.Show("Error al editar pedido.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;

            Pedido p = (Pedido)dgvPedidos.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Eliminar pedido #{p.IdPedido}?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (pedidoDAO.EliminarPedido(p.IdPedido))
                {
                    MessageBox.Show("Pedido eliminado correctamente.");
                    CargarPedidos();
                }
            }
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            /*
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un pedido para ver su detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdPedido"].Value);

            // Abre modal con el detalle del pedido
            using (FormDetallesPedido formDetalle = new FormDetallesPedido(idPedido))
            {
                formDetalle.StartPosition = FormStartPosition.CenterParent;
                formDetalle.ShowDialog(this);
            }*/
            FormDetallesPedido formDetalles = new FormDetallesPedido();
            formDetalles.ShowDialog(); 
        }
    }
}