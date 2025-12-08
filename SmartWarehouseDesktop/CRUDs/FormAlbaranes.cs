using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormAlbaranes : Form
    {
        private readonly AlbaranService _service = new AlbaranService();

        public FormAlbaranes()
        {
            InitializeComponent();
        }

        private async void FormAlbaranes_Load(object sender, EventArgs e)
        {
            await CargarAlbaranes();

            dgvAlbaranes.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private async Task CargarAlbaranes()
        {
            var data = await _service.GetAll();
            dgvAlbaranes.DataSource = data;
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarAlbaranes();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new FormAlbaranEditar(null);

            if (frm.ShowDialog() == DialogResult.OK)
                await CargarAlbaranes();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlbaranes.CurrentRow == null) return;

            var albaran = dgvAlbaranes.CurrentRow.DataBoundItem as AlbaranApiModel;

            if (MessageBox.Show($"¿Eliminar albarán #{albaran.IdAlbaran}?",
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (await _service.Delete(albaran.IdAlbaran))
            {
                MessageBox.Show("Albarán eliminado.");
                await CargarAlbaranes();
            }
            else
            {
                MessageBox.Show("Error al eliminar albarán.");
            }
        }
    }
}