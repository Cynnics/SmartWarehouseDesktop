using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormProductos : Form
    {
        private ProductService _productService;

        private readonly BindingSource _bs = new BindingSource();

        public FormProductos()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private async void FormProductos_Load(object sender, EventArgs e)
        {
            // Estilos tuyos
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

            // Configurar DataGridView con BindingSource
            dgvProductos.AutoGenerateColumns = true; // o false si tienes columnas hechas
            dgvProductos.DataSource = _bs;

            await CargarProductos();
        }

        // Cargar desde API
        private async Task CargarProductos()
        {
            try
            {
               
                var productos = await _productService.GetAll();

                if (productos == null)
                {
                    MessageBox.Show("No se pudo obtener la lista de productos (respuesta nula).");
                    return;
                }

                // Asignar al BindingSource
                _bs.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarProductos();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new FormProductoEditar(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await CargarProductos();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            var producto = dgvProductos.CurrentRow.DataBoundItem as ProductApiModel;
            if (producto == null) return;

            var frm = new FormProductoEditar(producto);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await CargarProductos();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            var producto = dgvProductos.CurrentRow.DataBoundItem as ProductApiModel;
            if (producto == null) return;

            var confirm = MessageBox.Show($"¿Eliminar '{producto.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool ok = await _productService.Delete(producto.IdProducto);
                    if (ok) MessageBox.Show("Producto eliminado.");
                    else MessageBox.Show("No se pudo eliminar el producto.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
                await CargarProductos();
            }
        }
    }
}
