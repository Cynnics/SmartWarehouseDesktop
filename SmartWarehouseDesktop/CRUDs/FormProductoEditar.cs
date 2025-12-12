using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormProductoEditar : Form
    {
        private readonly ProductoService _service = new ProductoService();
        private readonly ProductApiModel producto; 

        public FormProductoEditar(ProductApiModel producto = null)
        {
            InitializeComponent();
            this.producto = producto;
            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo,true);
            UIHelper.EstilizarLabel(lblNombre);
            UIHelper.EstilizarLabel(lblDescripcion);
            UIHelper.EstilizarLabel(lblPrecio);
            UIHelper.EstilizarLabel(lblStock);
            UIHelper.EstilizarLabel(lblCategoria);
            UIHelper.EstilizarBoton(btnGuardar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGuardar);
            UIHelper.EstiloHover(btnCancelar);

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

            if (producto == null)
            {
                var nuevo = new ProductApiModel
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Stock = stock,
                    Categoria = txtCategoria.Text
                };

                var ok = await _service.Create(nuevo);

                if (ok)
                {
                    MessageBox.Show("Producto creado con éxito");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al crear el producto");
                }

                return;
            }

            var cambios = new Dictionary<string, object>();

            if (txtNombre.Text != producto.Nombre)
                cambios["nombre"] = txtNombre.Text;

            if (txtDescripcion.Text != producto.Descripcion)
                cambios["descripcion"] = txtDescripcion.Text;

            if (precio != producto.Precio)
                cambios["precio"] = precio;

            if (stock != producto.Stock)
                cambios["stock"] = stock;

            if (txtCategoria.Text != producto.Categoria)
                cambios["categoria"] = txtCategoria.Text;

            var okEdit = await _service.PatchProducto(producto.IdProducto, cambios);

            if (okEdit)
            {
                MessageBox.Show("Producto modificado correctamente.");
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Error al modificar el producto.");
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

            
    }
}
