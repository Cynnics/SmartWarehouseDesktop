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
        private readonly UserApiModel usuario; // null = agregar

        public FormUsuarioEditar(UserApiModel usuario = null)
        {
            InitializeComponent();
            this.usuario = usuario;
            UIHelper.EstilizarFormulario(this);
            UIHelper.EstilizarLabel(lblTitulo,true);
            UIHelper.EstilizarLabel(lblNombre);
            UIHelper.EstilizarLabel(lblEmail);
            UIHelper.EstilizarLabel(lblPassword);
            UIHelper.EstilizarLabel(lblRol);
            UIHelper.EstilizarBoton(btnGuardar);
            UIHelper.EstilizarBoton(btnCancelar);
            UIHelper.EstiloHover(btnGuardar);
            UIHelper.EstiloHover(btnCancelar);
        }

        private void FormUsuarioEditar_Load(object sender, EventArgs e)
        {
            if (usuario == null)
            {
                lblTitulo.Text = "Agregar Usuario";
            }
            else
            {
                lblTitulo.Text = "Editar Usuario";

                txtNombre.Text = usuario.Nombre;
                txtEmail.Text = usuario.Email;
                cmbRol.SelectedItem = usuario.Rol;
            }

            // Inicializa combo de roles
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(new string[] { "admin", "empleado", "repartidor", "cliente" });
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Nombre, Email y Rol son obligatorios.");
                return;
            }

            if (usuario == null)
            {
                // Crear nuevo
                var nuevo = new CreateUserApiModel
                {
                    Nombre = txtNombre.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text, // en crear pedimos password
                    Rol = cmbRol.SelectedItem.ToString()
                };

                bool ok = await _service.Create(nuevo);
                if (ok)
                {
                    MessageBox.Show("Usuario agregado correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar usuario.");
                }
            }
            else
            {
                // Para editar, usamos PATCH
                var cambios = new Dictionary<string, object>();
                cambios["nombre"] = txtNombre.Text;
                cambios["email"] = txtEmail.Text;
                cambios["rol"] = cmbRol.SelectedItem.ToString();

                bool ok = await _service.Patch(usuario.IdUsuario, cambios);
                if (ok)
                {
                    MessageBox.Show("Usuario actualizado correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar usuario.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

     
    }
}
