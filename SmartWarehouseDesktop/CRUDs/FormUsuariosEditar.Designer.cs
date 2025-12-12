namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormUsuarioEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuarioEditar));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.txtDireccionFacturacion = new System.Windows.Forms.TextBox();
            this.lblNif = new System.Windows.Forms.Label();
            this.lblDireccionFacturacion = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(33, 245);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(145, 100);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 21;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(145, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(145, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // lblRol
            // 
            this.lblRol.Location = new System.Drawing.Point(30, 130);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(90, 15);
            this.lblRol.TabIndex = 17;
            this.lblRol.Text = "Rol:";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(30, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 15);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Password:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(90, 15);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email:";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(30, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(90, 15);
            this.lblNombre.TabIndex = 14;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 20);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "admin",
            "empleado",
            "repartidor",
            "cliente"});
            this.cmbRol.Location = new System.Drawing.Point(145, 130);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(100, 21);
            this.cmbRol.TabIndex = 26;
            // 
            // txtNif
            // 
            this.txtNif.Location = new System.Drawing.Point(145, 214);
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(100, 20);
            this.txtNif.TabIndex = 30;
            this.txtNif.Visible = false;
            // 
            // txtDireccionFacturacion
            // 
            this.txtDireccionFacturacion.Location = new System.Drawing.Point(145, 183);
            this.txtDireccionFacturacion.Name = "txtDireccionFacturacion";
            this.txtDireccionFacturacion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccionFacturacion.TabIndex = 29;
            this.txtDireccionFacturacion.Visible = false;
            // 
            // lblNif
            // 
            this.lblNif.Location = new System.Drawing.Point(30, 216);
            this.lblNif.Name = "lblNif";
            this.lblNif.Size = new System.Drawing.Size(90, 15);
            this.lblNif.TabIndex = 28;
            this.lblNif.Text = "NIF:";
            this.lblNif.Visible = false;
            // 
            // lblDireccionFacturacion
            // 
            this.lblDireccionFacturacion.Location = new System.Drawing.Point(30, 179);
            this.lblDireccionFacturacion.Name = "lblDireccionFacturacion";
            this.lblDireccionFacturacion.Size = new System.Drawing.Size(90, 30);
            this.lblDireccionFacturacion.TabIndex = 27;
            this.lblDireccionFacturacion.Text = "Direccion de Facturacion:";
            this.lblDireccionFacturacion.Visible = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(145, 157);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 32;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(30, 157);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(90, 20);
            this.lblTelefono.TabIndex = 31;
            this.lblTelefono.Text = "Telefono:";
            // 
            // FormUsuarioEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtNif);
            this.Controls.Add(this.txtDireccionFacturacion);
            this.Controls.Add(this.lblNif);
            this.Controls.Add(this.lblDireccionFacturacion);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUsuarioEditar";
            this.Text = "FormUsuariosEditar";
            this.Load += new System.EventHandler(this.FormUsuarioEditar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.TextBox txtNif;
        private System.Windows.Forms.TextBox txtDireccionFacturacion;
        private System.Windows.Forms.Label lblNif;
        private System.Windows.Forms.Label lblDireccionFacturacion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
    }
}