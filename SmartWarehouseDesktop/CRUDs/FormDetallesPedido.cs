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
    public partial class FormDetallesPedido: Form
    {
        private DetallePedidoDAO detalleDAO = new DetallePedidoDAO();

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
            /*if (idPedidoSeleccionado > 0)
                CargarDetallesPorPedido(idPedidoSeleccionado);
            else
                CargarDetalles();*/
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

        private void CargarDetalles()
        {
            dgvDetalles.DataSource = null;
            List<DetallePedido> detalles = detalleDAO.ObtenerDetalles();
            dgvDetalles.DataSource = detalles;
        }

        private void CargarDetallesPorPedido(int idPedido)
        {
            dgvDetalles.DataSource = null;
            List<DetallePedido> detalles = detalleDAO.ObtenerDetallesPorPedido(idPedido);
            dgvDetalles.DataSource = detalles;
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDetalles();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(Prompt.ShowDialog("ID del pedido:", "Agregar detalle"));
                int idProducto = Convert.ToInt32(Prompt.ShowDialog("ID del producto:", "Agregar detalle"));
                int cantidad = Convert.ToInt32(Prompt.ShowDialog("Cantidad:", "Agregar detalle"));
                decimal subtotal = Convert.ToDecimal(Prompt.ShowDialog("Subtotal:", "Agregar detalle"));

                DetallePedido nuevo = new DetallePedido
                {
                    IdPedido = idPedido,
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    Subtotal = subtotal
                };

                if (detalleDAO.InsertarDetalle(nuevo))
                {
                    MessageBox.Show("Detalle agregado correctamente.");
                    CargarDetalles();
                }
            }
            catch
            {
                MessageBox.Show("Error al agregar detalle.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null) return;

            DetallePedido d = (DetallePedido)dgvDetalles.CurrentRow.DataBoundItem;

            try
            {
                d.Cantidad = Convert.ToInt32(Prompt.ShowDialog("Cantidad:", "Editar detalle", d.Cantidad.ToString()));
                d.Subtotal = Convert.ToDecimal(Prompt.ShowDialog("Subtotal:", "Editar detalle", d.Subtotal.ToString()));

                if (detalleDAO.ActualizarDetalle(d))
                {
                    MessageBox.Show("Detalle actualizado correctamente.");
                    CargarDetalles();
                }
            }
            catch
            {
                MessageBox.Show("Error al editar detalle.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null) return;

            DetallePedido d = (DetallePedido)dgvDetalles.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Eliminar detalle #{d.IdDetalle}?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (detalleDAO.EliminarDetalle(d.IdDetalle))
                {
                    MessageBox.Show("Detalle eliminado correctamente.");
                    CargarDetalles();
                }
            }
        }
    }
}