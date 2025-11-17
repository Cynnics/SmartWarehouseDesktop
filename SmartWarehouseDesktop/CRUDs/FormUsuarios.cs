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
    public partial class FormUsuarios: Form
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            BackColor = TemaApp.AzulIntermedio;
            dgvUsuarios.DefaultCellStyle.Font = TemaApp.FuenteGeneral;
            lblTitulo.Font = TemaApp.FuenteTitulo;
            UIHelper.EstilizarBoton(btnAgregar);
            UIHelper.EstiloHover(btnAgregar);
            UIHelper.EstilizarBoton(btnCargar);
            UIHelper.EstiloHover(btnCargar);
            UIHelper.EstilizarBoton(btnEditar);
            UIHelper.EstiloHover(btnEditar);
            UIHelper.EstilizarBoton(btnEliminar);
            UIHelper.EstiloHover(btnEliminar);
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            List<Usuario> usuarios = usuarioDAO.ObtenerUsuarios();
            dgvUsuarios.DataSource = usuarios;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario
                {
                    Nombre = Prompt.ShowDialog("Nombre:", "Nuevo usuario"),
                    Email = Prompt.ShowDialog("Correo:", "Nuevo usuario"),
                    Password = Prompt.ShowDialog("Contraseña:", "Nuevo usuario"),
                    Rol = Prompt.ShowDialog("Rol (ADMIN, CLIENTE, REPARTIDOR):", "Nuevo usuario")
                };

                if (usuarioDAO.InsertarUsuario(nuevo))
                {
                    MessageBox.Show("Usuario agregado correctamente.");
                    CargarUsuarios();
                }
            }
            catch
            {
                MessageBox.Show("Error al agregar usuario.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            Usuario u = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

            try
            {
                u.Nombre = Prompt.ShowDialog("Nombre:", "Editar usuario", u.Nombre);
                u.Email = Prompt.ShowDialog("Correo:", "Editar usuario", u.Email);
                u.Password = Prompt.ShowDialog("Contraseña:", "Editar usuario", u.Password);
                u.Rol = Prompt.ShowDialog("Rol:", "Editar usuario", u.Rol);

                if (usuarioDAO.ActualizarUsuario(u))
                {
                    MessageBox.Show("Usuario actualizado correctamente.");
                    CargarUsuarios();
                }
            }
            catch
            {
                MessageBox.Show("Error al editar usuario.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            Usuario u = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Eliminar usuario '{u.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (usuarioDAO.EliminarUsuario(u.IdUsuario))
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios();
                }
            }
        }
    }
}