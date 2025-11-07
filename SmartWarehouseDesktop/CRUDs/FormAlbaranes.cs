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
    public partial class FormAlbaranes : Form
    {
        private AlbaranDAO albaranDAO = new AlbaranDAO();

        public FormAlbaranes()
        {
            InitializeComponent();
        }

        private void FormAlbaranes_Load(object sender, EventArgs e)
        {
            //CargarAlbaranes();
            dgvAlbaranes.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private void CargarAlbaranes()
        {
            dgvAlbaranes.DataSource = null;
            dgvAlbaranes.DataSource = albaranDAO.ObtenerAlbaranes();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarAlbaranes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(Prompt.ShowDialog("ID del pedido:", "Nuevo albarán"));
                int entregadoPor = Convert.ToInt32(Prompt.ShowDialog("ID del repartidor:", "Nuevo albarán"));
                string recibidoPor = Prompt.ShowDialog("Recibido por:", "Nuevo albarán");

                Albaran a = new Albaran
                {
                    IdPedido = idPedido,
                    FechaGeneracion = DateTime.Now,
                    EntregadoPor = entregadoPor,
                    RecibidoPor = recibidoPor
                };

                if (albaranDAO.InsertarAlbaran(a))
                {
                    MessageBox.Show("Albarán creado correctamente.");
                    CargarAlbaranes();
                }
            }
            catch
            {
                MessageBox.Show("Error al crear el albarán.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlbaranes.CurrentRow == null) return;
            var a = (Albaran)dgvAlbaranes.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar albarán #{a.IdAlbaran}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (albaranDAO.EliminarAlbaran(a.IdAlbaran))
                {
                    MessageBox.Show("Albarán eliminado.");
                    CargarAlbaranes();
                }
            }
        }
    }
}