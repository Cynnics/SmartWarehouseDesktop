using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormRutasEntrega : Form
    {
        private readonly RutaEntregaService _service = new RutaEntregaService();
        private readonly BindingSource _bs = new BindingSource();

        public FormRutasEntrega()
        {
            InitializeComponent();
        }

        private async void FormRutas_Load(object sender, EventArgs e)
        {
            // estilos tuyos
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

            // configurar DataGridView para usar BindingSource
            dgvRutas.AutoGenerateColumns = true; // si tienes columnas personalizadas cambia a false
            dgvRutas.DataSource = _bs;

            await CargarRutas();
        }

        private async Task CargarRutas()
        {
            try
            {
                dgvRutas.DataSource = null;
                var data = await _service.GetAll();
                if (data == null)
                {
                    MessageBox.Show("No se pudieron obtener las rutas (respuesta nula). Comprueba la API o el token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _bs.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar rutas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarRutas();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // opcional: reemplazar por un FormRutaEditar cuando lo tengas
                string idRepStr = Prompt.ShowDialog("ID del repartidor:", "Nueva ruta");
                if (!int.TryParse(idRepStr, out int idRep))
                {
                    MessageBox.Show("ID de repartidor inválido.");
                    return;
                }

                string fechaStr = Prompt.ShowDialog("Fecha de la ruta (YYYY-MM-DD):", "Nueva ruta", DateTime.Now.ToString("yyyy-MM-dd"));
                if (!DateTime.TryParse(fechaStr, out DateTime fecha))
                {
                    MessageBox.Show("Fecha inválida.");
                    return;
                }

                string distanciaStr = Prompt.ShowDialog("Distancia estimada (km):", "Nueva ruta", "0");
                if (!decimal.TryParse(distanciaStr, out decimal distancia))
                {
                    MessageBox.Show("Distancia inválida.");
                    return;
                }

                string duracionStr = Prompt.ShowDialog("Duración estimada (min):", "Nueva ruta", "0");
                if (!int.TryParse(duracionStr, out int duracion))
                {
                    MessageBox.Show("Duración inválida.");
                    return;
                }

                var nuevo = new RutaEntregaApiModel
                {
                    IdRepartidor = idRep,
                    FechaRuta = fecha,
                    DistanciaEstimadaKm = distancia,
                    DuracionEstimadaMin = duracion,
                    Estado = "planificada"
                };

                bool ok = await _service.Create(nuevo);
                if (ok)
                {
                    MessageBox.Show("Ruta creada correctamente.");
                    await CargarRutas();
                }
                else
                {
                    MessageBox.Show("No se pudo crear la ruta. Comprueba la respuesta del servidor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la ruta: " + ex.Message);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null) return;

            var ruta = dgvRutas.CurrentRow.DataBoundItem as RutaEntregaApiModel;
            if (ruta == null) return;

            try
            {
                // si haces FormRutaEditar sustituye los Prompt por el form modal
                string nuevoEstado = Prompt.ShowDialog("Nuevo estado:", "Actualizar ruta", ruta.Estado ?? "");
                string distanciaStr = Prompt.ShowDialog("Distancia (km):", "Actualizar ruta", (ruta.DistanciaEstimadaKm ?? 0).ToString());
                string duracionStr = Prompt.ShowDialog("Duración (min):", "Actualizar ruta", (ruta.DuracionEstimadaMin ?? 0).ToString());

                if (decimal.TryParse(distanciaStr, out decimal distancia))
                    ruta.DistanciaEstimadaKm = distancia;
                if (int.TryParse(duracionStr, out int duracion))
                    ruta.DuracionEstimadaMin = duracion;
                if (!string.IsNullOrWhiteSpace(nuevoEstado))
                    ruta.Estado = nuevoEstado;

                bool ok = await _service.Update(ruta);
                if (ok)
                {
                    MessageBox.Show("Ruta actualizada.");
                    await CargarRutas();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la ruta. Comprueba la respuesta del servidor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null) return;

            var ruta = dgvRutas.CurrentRow.DataBoundItem as RutaEntregaApiModel;
            if (ruta == null) return;

            if (MessageBox.Show($"¿Eliminar ruta #{ruta.IdRuta}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bool ok = await _service.Delete(ruta.IdRuta);
                    if (ok)
                    {
                        MessageBox.Show("Ruta eliminada.");
                        await CargarRutas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la ruta. Es posible que tenga pedidos asignados o haya restricciones en el servidor.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una ruta para ver su ubicación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ruta = dgvRutas.CurrentRow.DataBoundItem as RutaEntregaApiModel;
            if (ruta == null)
            {
                MessageBox.Show("Elemento seleccionado inválido.");
                return;
            }

            using (var formUbic = new FormUbicaciones(ruta.IdRuta))
            {
                formUbic.StartPosition = FormStartPosition.CenterParent;
                formUbic.ShowDialog(this);
            }
        }
    }
}
