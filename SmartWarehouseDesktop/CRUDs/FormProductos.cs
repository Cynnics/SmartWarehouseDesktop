using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
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
    public partial class FormProductos: Form
    {
        private readonly ProductService _service = new ProductService();

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            dgvProductos.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
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

        // Método para llenar el DataGridView
        private async void CargarProductos()
        {
            try
            {
                var productos = await _service.GetAll();
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos:\n" + ex.Message);
            }
        }
        // Botón: Recargar lista
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            var prod = (ProductApiModel)dgvProductos.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar '{prod.Nombre}'?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _service.Delete(prod.IdProducto);
                await CargarProductos();
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new FormProductoEditar();
            if (form.ShowDialog() == DialogResult.OK)
                await CargarProductos();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            var prod = (ProductApiModel)dgvProductos.CurrentRow.DataBoundItem;

            var form = new FormProductoEditar(prod);
            if (form.ShowDialog() == DialogResult.OK)
                await CargarProductos();
        }


    }
}