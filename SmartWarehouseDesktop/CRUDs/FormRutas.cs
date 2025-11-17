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
    public partial class FormRutas : Form
    {
        private RutaEntregaDAO rutaDAO = new RutaEntregaDAO();

        public FormRutas()
        {
            InitializeComponent();
        }

        private void FormRutas_Load(object sender, EventArgs e)
        {
            CargarRutas();
            dgvRutas.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnActualizar);
            UIHelper.EstiloHover(btnActualizar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
            UIHelper.EstilizarBoton(btnForm);
            UIHelper.EstiloHover(btnForm);
        }

        private void CargarRutas()
        {
            dgvRutas.DataSource = null;
            dgvRutas.DataSource = rutaDAO.ObtenerRutas();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarRutas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idRep = Convert.ToInt32(Prompt.ShowDialog("ID del repartidor:", "Nueva ruta"));
                DateTime fecha = DateTime.Parse(Prompt.ShowDialog("Fecha de la ruta (YYYY-MM-DD):", "Nueva ruta"));
                decimal distancia = Convert.ToDecimal(Prompt.ShowDialog("Distancia estimada (km):", "Nueva ruta"));
                int duracion = Convert.ToInt32(Prompt.ShowDialog("Duración estimada (min):", "Nueva ruta"));

                RutaEntrega r = new RutaEntrega
                {
                    IdRepartidor = idRep,
                    FechaRuta = fecha,
                    DistanciaEstimadaKm = distancia,
                    DuracionEstimadaMin = duracion,
                    Estado = "Planificada"
                };

                if (rutaDAO.InsertarRuta(r))
                {
                    MessageBox.Show("Ruta creada correctamente.");
                    CargarRutas();
                }
            }
            catch
            {
                MessageBox.Show("Error al crear la ruta.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null) return;
            var r = (RutaEntrega)dgvRutas.CurrentRow.DataBoundItem;

            try
            {
                r.Estado = Prompt.ShowDialog("Nuevo estado:", "Actualizar ruta", r.Estado);
                r.DistanciaEstimadaKm = Convert.ToDecimal(Prompt.ShowDialog("Distancia (km):", "Actualizar ruta", r.DistanciaEstimadaKm.ToString()));
                r.DuracionEstimadaMin = Convert.ToInt32(Prompt.ShowDialog("Duración (min):", "Actualizar ruta", r.DuracionEstimadaMin.ToString()));

                if (rutaDAO.ActualizarRuta(r))
                {
                    MessageBox.Show("Ruta actualizada.");
                    CargarRutas();
                }
            }
            catch
            {
                MessageBox.Show("Error al actualizar la ruta.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null) return;
            var r = (RutaEntrega)dgvRutas.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar ruta #{r.IdRuta}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (rutaDAO.EliminarRuta(r.IdRuta))
                {
                    MessageBox.Show("Ruta eliminada.");
                    CargarRutas();
                }
            }
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            /*
            if (dgvRutas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una ruta para ver su ubicación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idRuta = Convert.ToInt32(dgvRutas.CurrentRow.Cells["IdRuta"].Value);

            using (FormUbicaciones formUbic = new FormUbicaciones(idRuta))
            {
                formUbic.StartPosition = FormStartPosition.CenterParent;
                formUbic.ShowDialog(this);
            }*/
            FormUbicaciones formUbicaciones = new FormUbicaciones();
            formUbicaciones.ShowDialog();
        }
    }
}