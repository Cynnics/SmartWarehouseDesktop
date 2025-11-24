namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormAlbaranEditar
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.nudEntregadoPor = new System.Windows.Forms.NumericUpDown();
            this.cmbPedidos = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblRecibidoPor = new System.Windows.Forms.Label();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtRecibidoPor = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudEntregadoPor)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(145, 64);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 54;
            // 
            // nudEntregadoPor
            // 
            this.nudEntregadoPor.DecimalPlaces = 2;
            this.nudEntregadoPor.Location = new System.Drawing.Point(145, 95);
            this.nudEntregadoPor.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudEntregadoPor.Name = "nudEntregadoPor";
            this.nudEntregadoPor.Size = new System.Drawing.Size(100, 20);
            this.nudEntregadoPor.TabIndex = 53;
            // 
            // cmbPedidos
            // 
            this.cmbPedidos.FormattingEnabled = true;
            this.cmbPedidos.Location = new System.Drawing.Point(145, 34);
            this.cmbPedidos.Name = "cmbPedidos";
            this.cmbPedidos.Size = new System.Drawing.Size(100, 21);
            this.cmbPedidos.TabIndex = 51;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(33, 205);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 49;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblRecibidoPor
            // 
            this.lblRecibidoPor.Location = new System.Drawing.Point(30, 130);
            this.lblRecibidoPor.Name = "lblRecibidoPor";
            this.lblRecibidoPor.Size = new System.Drawing.Size(90, 15);
            this.lblRecibidoPor.TabIndex = 48;
            this.lblRecibidoPor.Text = "Recibido por:";
            // 
            // lblEntregado
            // 
            this.lblEntregado.Location = new System.Drawing.Point(30, 100);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(90, 15);
            this.lblEntregado.TabIndex = 47;
            this.lblEntregado.Text = "Entregado por:";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(30, 70);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(90, 15);
            this.lblFecha.TabIndex = 46;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblPedido
            // 
            this.lblPedido.Location = new System.Drawing.Point(30, 40);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(90, 15);
            this.lblPedido.TabIndex = 45;
            this.lblPedido.Text = "Pedido:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 20);
            this.lblTitulo.TabIndex = 44;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecibidoPor
            // 
            this.txtRecibidoPor.Location = new System.Drawing.Point(145, 128);
            this.txtRecibidoPor.Name = "txtRecibidoPor";
            this.txtRecibidoPor.Size = new System.Drawing.Size(100, 20);
            this.txtRecibidoPor.TabIndex = 55;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(30, 160);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(90, 15);
            this.lblEstado.TabIndex = 56;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(145, 158);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(100, 21);
            this.cmbEstado.TabIndex = 57;
            // 
            // FormAlbaranEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtRecibidoPor);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.nudEntregadoPor);
            this.Controls.Add(this.cmbPedidos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblRecibidoPor);
            this.Controls.Add(this.lblEntregado);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormAlbaranEditar";
            this.Text = "FormAlbaranEditar";
            this.Load += new System.EventHandler(this.FormAlbaranEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudEntregadoPor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown nudEntregadoPor;
        private System.Windows.Forms.ComboBox cmbPedidos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblRecibidoPor;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtRecibidoPor;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}