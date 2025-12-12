using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    public partial class FormUsuarioEditar : Form
    {
        private readonly UserService _service = new UserService();
        private readonly UserApiModel usuario; 

        public FormUsuarioEditar(UserApiModel usuario = null)
        {
            InitializeComponent();
            this.usuario = usuario;

            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo, true);
            UIHelper.EstilizarLabel(lblNombre);
            UIHelper.EstilizarLabel(lblEmail);
            UIHelper.EstilizarLabel(lblPassword);
            UIHelper.EstilizarLabel(lblRol);
            UIHelper.EstilizarLabel(lblTelefono);
            UIHelper.EstilizarLabel(lblNif);
            UIHelper.EstilizarLabel(lblDireccionFacturacion);
            UIHelper.EstilizarBoton(btnGuardar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGuardar);
            UIHelper.EstiloHover(btnCancelar);

            
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(new string[] { "admin", "empleado", "repartidor", "cliente" });
            cmbRol.SelectedIndexChanged += (s, ev) => AjustarCamposCliente();
        }

        private void FormUsuarioEditar_Load(object sender, EventArgs e)
        {
            if (usuario == null)
            {
                lblTitulo.Text = "Agregar Usuario";
                cmbRol.SelectedIndex = 0; 
            }
            else
            {
                lblTitulo.Text = "Editar Usuario";
                txtNombre.Text = usuario.Nombre;
                txtEmail.Text = usuario.Email;
                txtTelefono.Text = usuario.Telefono;
                cmbRol.SelectedItem = usuario.Rol;

                if (usuario.Rol.ToLower() == "cliente")
                {
                    txtNif.Text = usuario.Nif;
                    txtDireccionFacturacion.Text = usuario.DireccionFacturacion;
                }
            }

            AjustarCamposCliente();
        }

        private void AjustarCamposCliente()
        {
            bool esCliente = cmbRol.SelectedItem != null && cmbRol.SelectedItem.ToString().ToLower() == "cliente";

            txtNif.Visible = esCliente;
            txtDireccionFacturacion.Visible = esCliente;
            lblNif.Visible = esCliente;
            lblDireccionFacturacion.Visible = esCliente;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Nombre, Email y Rol son obligatorios.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string rol = cmbRol.SelectedItem.ToString();
            string password = txtPassword.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string nif = rol.ToLower() == "cliente" ? txtNif.Text.Trim() : null;
            string direccionFacturacion = rol.ToLower() == "cliente" ? txtDireccionFacturacion.Text.Trim() : null;

            if (usuario == null)
            {
                var nuevo = new UserApiModel
                {
                    Nombre = nombre,
                    Email = email,
                    Password = password, 
                    Rol = rol,
                    Telefono = telefono,
                    Nif = nif,
                    DireccionFacturacion = direccionFacturacion
                };

                bool ok = await _service.Create(nuevo);

                if (ok)
                {
                    MessageBox.Show("Usuario agregado correctamente.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar usuario.");
                }
            }
            else
            {
                var cambios = new Dictionary<string, object>
                {
                    ["nombre"] = nombre,
                    ["email"] = email,          
                    ["rol"] = rol,
                    ["telefono"] = telefono
                };

                if (rol.ToLower() == "cliente")
                {
                    cambios["nif"] = string.IsNullOrWhiteSpace(nif) ? "" : nif;
                    cambios["direccionFacturacion"] = string.IsNullOrWhiteSpace(direccionFacturacion) ? "" : direccionFacturacion;
                }

                bool ok = await _service.Patch(usuario.IdUsuario, cambios);

                if (ok)
                {
                    MessageBox.Show("Usuario actualizado correctamente.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar usuario.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
