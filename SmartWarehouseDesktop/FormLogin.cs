using MySql.Data.MySqlClient;
using SmartWarehouseDesktop.Conexion;
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
    public partial class FormLogin : Form
    {
        private DBConnection db = new DBConnection();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMensaje.Text = "Por favor, introduce usuario y contraseña.";
                return;
            }

            try
            {
                using (var conn = db.GetConnection())
                {
                    string query = @"SELECT * FROM Usuario 
                                     WHERE email=@correo AND password=@pass 
                                     AND (rol='ADMIN' OR rol='EMPLEADO')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@correo", email);
                    cmd.Parameters.AddWithValue("@pass", password);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader.GetString("nombre");
                            string rol = reader.GetString("rol");

                            MessageBox.Show($"Bienvenido {nombre} ({rol})",
                                            "Acceso concedido",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            this.Hide(); // Oculta el login
                            FormMenu menu = new FormMenu();
                            menu.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            lblMensaje.Text = "Credenciales incorrectas o acceso no permitido.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            this.Hide(); // Oculta el login
            FormMenu menu = new FormMenu();
            menu.ShowDialog();
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
           
            this.BackColor = TemaApp.AzulOscuro;

            // Labels
            UIHelper.EstilizarLabel(lblTitulo, esTitulo: true);
            UIHelper.EstilizarLabel(lblEmail);
            UIHelper.EstilizarLabel(lblPassword);

            // TextBox
            UIHelper.EstilizarTextBox(txtEmail);
            UIHelper.EstilizarTextBox(txtPassword);

            // Logo
            pictureBoxLogo.Image = Properties.Resources.logo;
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            // Botón
            UIHelper.EstilizarBoton(btnLogin);
            UIHelper.EstiloHover(btnLogin);

        }


    }
}