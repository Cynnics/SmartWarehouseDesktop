using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormProductoEditar : Form
    {
        private readonly ProductService _service = new ProductService();
        private readonly ProductApiModel producto; // null = agregar

        public FormProductoEditar(ProductApiModel producto = null)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void FormProductoEditar_Load(object sender, EventArgs e)
        {
            if (producto == null)
            {
                lblTitulo.Text = "Agregar Producto";
            }
            else
            {
                lblTitulo.Text = "Editar Producto";

                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                txtPrecio.Text = producto.Precio.ToString();
                txtStock.Text = producto.Stock.ToString();
                txtCategoria.Text = producto.Categoria;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación simple
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Los campos Nombre, Precio y Stock son obligatorios.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Stock inválido.");
                return;
            }

            // Crear o actualizar
            if (producto == null)
            {
                // Crear nuevo
                var nuevo = new ProductApiModel
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Stock = stock,
                    Categoria = txtCategoria.Text
                };

                await _service.Create(nuevo);
                MessageBox.Show("Producto agregado correctamente.");
            }
            else
            {
                // Editar existente
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Precio = precio;
                producto.Stock = stock;
                producto.Categoria = txtCategoria.Text;

                await _service.Update(producto);
                MessageBox.Show("Producto actualizado correctamente.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

            
    }
}
