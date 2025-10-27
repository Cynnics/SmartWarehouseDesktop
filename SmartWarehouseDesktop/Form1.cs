using SmartWarehouseDesktop.Conexion;
using SmartWarehouseDesktop.CRUDs;
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

namespace SmartWarehouseDesktop
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }


        private void btnCargarProductos_Click(object sender, EventArgs e)
        {
            ProductoDAO dao = new ProductoDAO();
            List<Producto> productos = dao.ObtenerProductos();

            string lista = "";
            foreach (Producto p in productos)
            {
                lista += p.ToString() + "\n";
            }

            MessageBox.Show(lista == "" ? "No hay productos." : lista);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos f = new FormProductos();
            f.ShowDialog();
        }

        private void btnDetallesPedido_Click(object sender, EventArgs e)
        {
            FormDetallesPedido f = new FormDetallesPedido();
            f.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FormPedidos f = new FormPedidos();
            f.ShowDialog();
        }

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {
            FormUbicaciones f = new FormUbicaciones();
            f.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios f = new FormUsuarios();
            f.ShowDialog();
        }
    }
}
