namespace SmartWarehouseDesktop
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnDetallesPedido = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnUbicaciones = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCargarProductos_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(332, 138);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(75, 23);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnDetallesPedido
            // 
            this.btnDetallesPedido.Location = new System.Drawing.Point(457, 138);
            this.btnDetallesPedido.Name = "btnDetallesPedido";
            this.btnDetallesPedido.Size = new System.Drawing.Size(142, 23);
            this.btnDetallesPedido.TabIndex = 2;
            this.btnDetallesPedido.Text = "Detalles Pedido";
            this.btnDetallesPedido.UseVisualStyleBackColor = true;
            this.btnDetallesPedido.Click += new System.EventHandler(this.btnDetallesPedido_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.Location = new System.Drawing.Point(483, 212);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(75, 23);
            this.btnPedidos.TabIndex = 3;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnUbicaciones
            // 
            this.btnUbicaciones.Location = new System.Drawing.Point(457, 270);
            this.btnUbicaciones.Name = "btnUbicaciones";
            this.btnUbicaciones.Size = new System.Drawing.Size(75, 23);
            this.btnUbicaciones.TabIndex = 4;
            this.btnUbicaciones.Text = "Ubicaciones";
            this.btnUbicaciones.UseVisualStyleBackColor = true;
            this.btnUbicaciones.Click += new System.EventHandler(this.btnUbicaciones_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(457, 327);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnUbicaciones);
            this.Controls.Add(this.btnPedidos);
            this.Controls.Add(this.btnDetallesPedido);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnDetallesPedido;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnUbicaciones;
        private System.Windows.Forms.Button btnUsuarios;
    }
}

