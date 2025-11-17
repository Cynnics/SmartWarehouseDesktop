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
    public partial class FormUbicaciones: Form
    {
        private UbicacionRepartidorDAO ubicacionDAO = new UbicacionRepartidorDAO();
        private int idRuta;  // 🔹 Guardamos el id de la ruta

        public FormUbicaciones()
        {
            InitializeComponent();
        }

        public FormUbicaciones(int idRuta)
        {
            InitializeComponent();
            this.idRuta = idRuta;
        }

        private void FormUbicaciones_Load(object sender, EventArgs e)
        {
            
            if (idRuta > 0)
                CargarUbicacionesPorRuta(idRuta);
            else
                CargarUbicaciones();

            dgvUbicaciones.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private void CargarUbicaciones()
        {
            dgvUbicaciones.DataSource = null;
            List<UbicacionRepartidor> ubicaciones = ubicacionDAO.ObtenerUbicaciones();
            dgvUbicaciones.DataSource = ubicaciones;
        }
        private void CargarUbicacionesPorRuta(int idRuta)
        {
            dgvUbicaciones.DataSource = null;
            List<UbicacionRepartidor> ubicaciones = ubicacionDAO.ObtenerUbicacionesPorRuta(idRuta);
            dgvUbicaciones.DataSource = ubicaciones;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarUbicaciones();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idRep = Convert.ToInt32(Prompt.ShowDialog("ID del repartidor:", "Nueva ubicación"));
                decimal lat = Convert.ToDecimal(Prompt.ShowDialog("Latitud:", "Nueva ubicación"));
                decimal lon = Convert.ToDecimal(Prompt.ShowDialog("Longitud:", "Nueva ubicación"));
                DateTime fecha = DateTime.Now;

                UbicacionRepartidor nueva = new UbicacionRepartidor
                {
                    IdRepartidor = idRep,
                    Latitud = lat,
                    Longitud = lon,
                    FechaHora = fecha
                };

                if (ubicacionDAO.InsertarUbicacion(nueva))
                {
                    MessageBox.Show("Ubicación registrada correctamente.");
                    CargarUbicaciones();
                }
            }
            catch
            {
                MessageBox.Show("Error al agregar ubicación.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUbicaciones.CurrentRow == null) return;

            UbicacionRepartidor u = (UbicacionRepartidor)dgvUbicaciones.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Eliminar ubicación #{u.IdUbicacion}?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (ubicacionDAO.EliminarUbicacion(u.IdUbicacion))
                {
                    MessageBox.Show("Ubicación eliminada correctamente.");
                    CargarUbicaciones();
                }
            }
        }
    }
}