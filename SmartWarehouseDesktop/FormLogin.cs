using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.Conexion;
using System;
using System.Net.Http;
using System.Text;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMensaje.Text = "Por favor, introduce usuario y contraseña.";
                return;
            }

            try
            {
                var loginData = new LoginRequest
                {
                    Email = email,
                    Password = password
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    string url = "http://localhost:5294/api/Auth/login";

                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResp = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(jsonResp);

                        // 🔥 Guardamos la sesión 🔥
                        Session.Token = result.Token;
                        Session.UsuarioActual = result.Usuario;

                        MessageBox.Show(
                            $"Bienvenido {result.Usuario.Nombre} ({result.Usuario.Rol})",
                            "Acceso concedido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        txtEmail.Clear();
                        txtPassword.Clear();

                        this.Hide();
                        FormMenu menu = new FormMenu();
                        menu.FormClosed += (s, args) => this.Show();   // ← cuando cierre menú, vuelve login
                        menu.Show();
                    }
                    else
                    {
                        lblMensaje.Text = "Credenciales incorrectas.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la API:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                btnLogin_Click(sender, e);
        }
    }
}