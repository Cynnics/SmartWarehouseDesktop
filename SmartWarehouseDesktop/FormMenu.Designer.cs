namespace SmartWarehouseDesktop
{
    partial class FormMenu
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
            this.btnProductos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAlbaranes = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.btnRutas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(47, 156);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(149, 23);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Gestión de Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(181, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(413, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "SmartWarehouse - Panel Principal";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(47, 185);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(149, 23);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Gestión de Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.Location = new System.Drawing.Point(47, 214);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(149, 23);
            this.btnPedidos.TabIndex = 3;
            this.btnPedidos.Text = "Gestión de Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(350, 394);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAlbaranes
            // 
            this.btnAlbaranes.Location = new System.Drawing.Point(614, 185);
            this.btnAlbaranes.Name = "btnAlbaranes";
            this.btnAlbaranes.Size = new System.Drawing.Size(129, 23);
            this.btnAlbaranes.TabIndex = 5;
            this.btnAlbaranes.Text = "Albaranes";
            this.btnAlbaranes.UseVisualStyleBackColor = true;
            this.btnAlbaranes.Click += new System.EventHandler(this.btnAlbaranes_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.Location = new System.Drawing.Point(614, 156);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(129, 23);
            this.btnFacturas.TabIndex = 6;
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.UseVisualStyleBackColor = true;
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnRutas
            // 
            this.btnRutas.Location = new System.Drawing.Point(614, 214);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(129, 23);
            this.btnRutas.TabIndex = 7;
            this.btnRutas.Text = "Rutas de Entrega";
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRutas);
            this.Controls.Add(this.btnFacturas);
            this.Controls.Add(this.btnAlbaranes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPedidos);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnProductos);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAlbaranes;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.Button btnRutas;
    }
}