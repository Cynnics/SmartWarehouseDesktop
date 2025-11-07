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
    public partial class FormFacturas : Form
    {
        private FacturaDAO facturaDAO = new FacturaDAO();
        public FormFacturas()
        {
            InitializeComponent();
        }

        private void FormFacturas_Load(object sender, EventArgs e)
        {
            //CargarFacturas();
            dgvFacturas.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnGenerar);
            UIHelper.EstiloHover(btnGenerar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }
        private void CargarFacturas()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = facturaDAO.ObtenerFacturas();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(Prompt.ShowDialog("ID del pedido entregado:", "Generar factura"));
                decimal subtotal = Convert.ToDecimal(Prompt.ShowDialog("Subtotal del pedido:", "Generar factura"));
                decimal iva = subtotal * 0.21m;
                decimal total = subtotal + iva;

                Factura f = new Factura
                {
                    IdPedido = idPedido,
                    FechaEmision = DateTime.Now,
                    Subtotal = subtotal,
                    IVA = iva,
                    Total = total
                };

                if (facturaDAO.InsertarFactura(f))
                {
                    MessageBox.Show("Factura generada correctamente.");
                    CargarFacturas();
                }
            }
            catch
            {
                MessageBox.Show("Error al generar la factura.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null) return;
            var f = (Factura)dgvFacturas.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar factura #{f.IdFactura}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (facturaDAO.EliminarFactura(f.IdFactura))
                {
                    MessageBox.Show("Factura eliminada.");
                    CargarFacturas();
                }
            }
        }
    }
}