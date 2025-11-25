using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var data = await _service.GetAll();

                if (data == null)
                {
                    MessageBox.Show("GetAll devolvió NULL");
                    return;
                }


                _bs.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR CargarRutas: " + ex.Message);
            }
        }



        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarRutas();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRutasEntregaEditar())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await CargarRutas();
            }
        }


        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una ruta.", "Aviso");
                return;
            }

            var ruta = dgvRutas.CurrentRow.DataBoundItem as RutaEntregaApiModel;
            if (ruta == null)
            {
                MessageBox.Show("Error: elemento inválido.");
                return;
            }

            using (var frm = new FormRutasEntregaEditar(ruta))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await CargarRutas();
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
