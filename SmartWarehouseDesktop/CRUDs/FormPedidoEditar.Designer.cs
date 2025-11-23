namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormPedidoEditar
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
            this.dtpFechaPedido = new System.Windows.Forms.DateTimePicker();
            this.nudCliente = new System.Windows.Forms.NumericUpDown();
            this.nudRepartidor = new System.Windows.Forms.NumericUpDown();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblRepartidor = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepartidor)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaPedido
            // 
            this.dtpFechaPedido.Enabled = false;
            this.dtpFechaPedido.Location = new System.Drawing.Point(145, 34);
            this.dtpFechaPedido.Name = "dtpFechaPedido";
            this.dtpFechaPedido.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaPedido.TabIndex = 43;
            // 
            // nudCliente
            // 
            this.nudCliente.DecimalPlaces = 2;
            this.nudCliente.Location = new System.Drawing.Point(145, 95);
            this.nudCliente.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudCliente.Name = "nudCliente";
            this.nudCliente.Size = new System.Drawing.Size(100, 20);
            this.nudCliente.TabIndex = 41;
            // 
            // nudRepartidor
            // 
            this.nudRepartidor.DecimalPlaces = 2;
            this.nudRepartidor.Location = new System.Drawing.Point(145, 125);
            this.nudRepartidor.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudRepartidor.Name = "nudRepartidor";
            this.nudRepartidor.Size = new System.Drawing.Size(100, 20);
            this.nudRepartidor.TabIndex = 40;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(145, 64);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(100, 21);
            this.cmbEstado.TabIndex = 39;
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
            // lblRepartidor
            // 
            this.lblRepartidor.Location = new System.Drawing.Point(30, 130);
            this.lblRepartidor.Name = "lblRepartidor";
            this.lblRepartidor.Size = new System.Drawing.Size(90, 15);
            this.lblRepartidor.TabIndex = 35;
            this.lblRepartidor.Text = "Repartidor:";
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(30, 100);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(90, 15);
            this.lblCliente.TabIndex = 34;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(30, 70);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(90, 15);
            this.lblEstado.TabIndex = 33;
            this.lblEstado.Text = "Estado:";
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.Location = new System.Drawing.Point(30, 40);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(90, 15);
            this.lblFechaPedido.TabIndex = 32;
            this.lblFechaPedido.Text = "Fecha Pedido:";
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
            // FormPedidoEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dtpFechaPedido);
            this.Controls.Add(this.nudCliente);
            this.Controls.Add(this.nudRepartidor);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblRepartidor);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblFechaPedido);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormPedidoEditar";
            this.Text = "FormPedidoEditar";
            this.Load += new System.EventHandler(this.FormPedidoEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepartidor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaPedido;
        private System.Windows.Forms.NumericUpDown nudCliente;
        private System.Windows.Forms.NumericUpDown nudRepartidor;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblRepartidor;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.Label lblTitulo;
    }
}