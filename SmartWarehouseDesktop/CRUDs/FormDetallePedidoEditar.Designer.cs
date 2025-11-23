namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormDetallePedidoEditar
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
            this.nudSubtotal = new System.Windows.Forms.NumericUpDown();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.nudIDProducto = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblIDProducto = new System.Windows.Forms.Label();
            this.lblIDPedido = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.nudIDPedido = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIDProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIDPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSubtotal
            // 
            this.nudSubtotal.DecimalPlaces = 2;
            this.nudSubtotal.Location = new System.Drawing.Point(145, 125);
            this.nudSubtotal.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSubtotal.Name = "nudSubtotal";
            this.nudSubtotal.Size = new System.Drawing.Size(100, 20);
            this.nudSubtotal.TabIndex = 42;
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Location = new System.Drawing.Point(145, 95);
            this.nudCantidad.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(100, 20);
            this.nudCantidad.TabIndex = 41;
            // 
            // nudIDProducto
            // 
            this.nudIDProducto.DecimalPlaces = 2;
            this.nudIDProducto.Location = new System.Drawing.Point(145, 65);
            this.nudIDProducto.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudIDProducto.Name = "nudIDProducto";
            this.nudIDProducto.Size = new System.Drawing.Size(100, 20);
            this.nudIDProducto.TabIndex = 40;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 206);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(33, 206);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(30, 130);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(90, 15);
            this.lblSubtotal.TabIndex = 35;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(30, 100);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(90, 15);
            this.lblCantidad.TabIndex = 34;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblIDProducto
            // 
            this.lblIDProducto.Location = new System.Drawing.Point(30, 70);
            this.lblIDProducto.Name = "lblIDProducto";
            this.lblIDProducto.Size = new System.Drawing.Size(90, 15);
            this.lblIDProducto.TabIndex = 33;
            this.lblIDProducto.Text = "ID Producto:";
            // 
            // lblIDPedido
            // 
            this.lblIDPedido.Location = new System.Drawing.Point(30, 40);
            this.lblIDPedido.Name = "lblIDPedido";
            this.lblIDPedido.Size = new System.Drawing.Size(90, 15);
            this.lblIDPedido.TabIndex = 32;
            this.lblIDPedido.Text = "ID Pedido:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 20);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudIDPedido
            // 
            this.nudIDPedido.DecimalPlaces = 2;
            this.nudIDPedido.Location = new System.Drawing.Point(145, 35);
            this.nudIDPedido.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudIDPedido.Name = "nudIDPedido";
            this.nudIDPedido.Size = new System.Drawing.Size(100, 20);
            this.nudIDPedido.TabIndex = 43;
            // 
            // FormDetallePedidoEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.nudIDPedido);
            this.Controls.Add(this.nudSubtotal);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.nudIDProducto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblIDProducto);
            this.Controls.Add(this.lblIDPedido);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormDetallePedidoEditar";
            this.Text = "FormDetallePedidoEditar";
            this.Load += new System.EventHandler(this.FormDetallePedidoEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIDProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIDPedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudSubtotal;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.NumericUpDown nudIDProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblIDProducto;
        private System.Windows.Forms.Label lblIDPedido;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.NumericUpDown nudIDPedido;
    }
}