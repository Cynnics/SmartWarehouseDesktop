namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormGenerarFactura
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbPedidos = new System.Windows.Forms.ComboBox();
            this.nudSubtotal = new System.Windows.Forms.NumericUpDown();
            this.nudIVA = new System.Windows.Forms.NumericUpDown();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(33, 206);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 40);
            this.btnGenerar.TabIndex = 24;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(30, 160);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(90, 15);
            this.lblFecha.TabIndex = 18;
            this.lblFecha.Text = "Fecha emisión:";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(30, 130);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 15);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total:";
            // 
            // lblIVA
            // 
            this.lblIVA.Location = new System.Drawing.Point(30, 100);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(90, 15);
            this.lblIVA.TabIndex = 16;
            this.lblIVA.Text = "IVA (%):";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(30, 70);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(90, 15);
            this.lblSubtotal.TabIndex = 15;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblPedido
            // 
            this.lblPedido.Location = new System.Drawing.Point(30, 40);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(90, 15);
            this.lblPedido.TabIndex = 14;
            this.lblPedido.Text = "Pedido:";
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
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 206);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbPedidos
            // 
            this.cmbPedidos.FormattingEnabled = true;
            this.cmbPedidos.Location = new System.Drawing.Point(145, 34);
            this.cmbPedidos.Name = "cmbPedidos";
            this.cmbPedidos.Size = new System.Drawing.Size(100, 21);
            this.cmbPedidos.TabIndex = 26;
            this.cmbPedidos.SelectedIndexChanged += new System.EventHandler(this.cmbPedidos_SelectedIndexChanged);
            // 
            // nudSubtotal
            // 
            this.nudSubtotal.DecimalPlaces = 2;
            this.nudSubtotal.Location = new System.Drawing.Point(145, 65);
            this.nudSubtotal.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSubtotal.Name = "nudSubtotal";
            this.nudSubtotal.Size = new System.Drawing.Size(100, 20);
            this.nudSubtotal.TabIndex = 27;
            // 
            // nudIVA
            // 
            this.nudIVA.DecimalPlaces = 2;
            this.nudIVA.Location = new System.Drawing.Point(145, 95);
            this.nudIVA.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudIVA.Name = "nudIVA";
            this.nudIVA.Size = new System.Drawing.Size(100, 20);
            this.nudIVA.TabIndex = 28;
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Location = new System.Drawing.Point(145, 125);
            this.nudTotal.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(100, 20);
            this.nudTotal.TabIndex = 29;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(145, 155);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 30;
            // 
            // FormGenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.nudIVA);
            this.Controls.Add(this.nudSubtotal);
            this.Controls.Add(this.cmbPedidos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormGenerarFactura";
            this.Text = "FormGenerarFacturas";
            this.Load += new System.EventHandler(this.FormGenerarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbPedidos;
        private System.Windows.Forms.NumericUpDown nudSubtotal;
        private System.Windows.Forms.NumericUpDown nudIVA;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}