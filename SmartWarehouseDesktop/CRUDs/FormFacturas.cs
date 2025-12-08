using SmartWarehouseDesktop.ApiServices;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormFacturas : Form
    {
        private readonly FacturaService _service = new FacturaService();

        public FormFacturas()
        {
            InitializeComponent();
        }

        private async void FormFacturas_Load(object sender, EventArgs e)
        {
            await CargarFacturas();
            dgvFacturas.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnGenerar);
            UIHelper.EstiloHover(btnGenerar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }
        private async Task CargarFacturas()
        {
            var data = await _service.GetAll();
            dgvFacturas.DataSource = data;
        }


        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarFacturas();
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            var frm = new FormGenerarFactura();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await CargarFacturas();
            }
        }



        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null) return;

            var factura = (FacturaApiModel)dgvFacturas.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar factura #{factura.IdFactura}?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool ok = await _service.Delete(factura.IdFactura);

                if (ok)
                    MessageBox.Show("Factura eliminada");
                else
                    MessageBox.Show("No se pudo eliminar la factura");

                await CargarFacturas();
            }
        }

    }
}