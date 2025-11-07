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
        private ProductoDAO productoDAO = new ProductoDAO();

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            //CargarProductos();
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
        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            List<Producto> productos = productoDAO.ObtenerProductos();
            dgvProductos.DataSource = productos;
        }
        // Botón: Recargar lista
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        // Botón: Agregar producto
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevo = new Producto
                {
                    Nombre = Prompt.ShowDialog("Nombre del producto:", "Agregar"),
                    Descripcion = Prompt.ShowDialog("Descripción:", "Agregar"),
                    Precio = Convert.ToDecimal(Prompt.ShowDialog("Precio:", "Agregar")),
                    Stock = Convert.ToInt32(Prompt.ShowDialog("Stock:", "Agregar")),
                    Categoria = Prompt.ShowDialog("Categoría:", "Agregar")
                };

                if (productoDAO.InsertarProducto(nuevo))
                {
                    MessageBox.Show("Producto agregado correctamente.");
                    CargarProductos();
                }
            }
            catch
            {
                MessageBox.Show("Error al agregar producto. Revisa los datos.");
            }
        }

        // Botón: Editar producto
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            Producto p = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            try
            {
                p.Nombre = Prompt.ShowDialog("Nombre:", "Editar", p.Nombre);
                p.Descripcion = Prompt.ShowDialog("Descripción:", "Editar", p.Descripcion);
                p.Precio = Convert.ToDecimal(Prompt.ShowDialog("Precio:", "Editar", p.Precio.ToString()));
                p.Stock = Convert.ToInt32(Prompt.ShowDialog("Stock:", "Editar", p.Stock.ToString()));
                p.Categoria = Prompt.ShowDialog("Categoría:", "Editar", p.Categoria);

                if (productoDAO.ActualizarProducto(p))
                {
                    MessageBox.Show("Producto actualizado correctamente.");
                    CargarProductos();
                }
            }
            catch
            {
                MessageBox.Show("Error al editar producto.");
            }
        }

        // Botón: Eliminar producto
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            Producto p = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Eliminar '{p.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (productoDAO.EliminarProducto(p.IdProducto))
                {
                    MessageBox.Show("Producto eliminado.");
                    CargarProductos();
                }
            }
        }

       
    }
}