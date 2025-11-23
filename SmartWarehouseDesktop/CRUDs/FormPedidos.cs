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
using SmartWarehouseDesktop.ApiServices;
using SmartWarehouseDesktop.ApiModels;

using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormPedidos: Form
    {
        private readonly PedidoService _service = new PedidoService();


        public FormPedidos()
        {
            InitializeComponent();
        }

        private async void FormPedidos_Load(object sender, EventArgs e)
        {
            await CargarPedidos();
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

        private async Task CargarPedidos()
        {
            var lista = await _service.GetAll();
            dgvPedidos.DataSource = lista;
        }


        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarPedidos();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new FormPedidoEditar();
            if (form.ShowDialog() == DialogResult.OK)
                await CargarPedidos();
        }



        private async Task btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;

            var pedido = dgvPedidos.CurrentRow.DataBoundItem as PedidoApiModel;

            var form = new FormPedidoEditar(pedido);
            if (form.ShowDialog() == DialogResult.OK)
               await CargarPedidos();
        }



        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;

            var p = (PedidoApiModel)dgvPedidos.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar pedido #{p.IdPedido}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _service.Delete(p.IdPedido))
                {
                    MessageBox.Show("Pedido eliminado.");
                    await CargarPedidos();
                }
            }
        }


        private void btnForm_Click(object sender, EventArgs e)
        {
            
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
            }
            FormDetallesPedido formDetalles = new FormDetallesPedido();
            formDetalles.ShowDialog(); 
        }

        private void btnEditar_Click_Sync(object sender, EventArgs e)
        {
            // Llama al método asíncrono y maneja la excepción si es necesario
            btnEditar_Click(sender, e).GetAwaiter().GetResult();
        }
    }
}