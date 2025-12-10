namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormRutasAsignar
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
            this.cmbPedidos = new System.Windows.Forms.ComboBox();
            this.lblPedido = new System.Windows.Forms.Label();
            this.cmbRepartidor = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblIDRepartidor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPedidos
            // 
            this.cmbPedidos.FormattingEnabled = true;
            this.cmbPedidos.Location = new System.Drawing.Point(145, 64);
            this.cmbPedidos.Name = "cmbPedidos";
            this.cmbPedidos.Size = new System.Drawing.Size(100, 21);
            this.cmbPedidos.TabIndex = 53;
            // 
            // lblPedido
            // 
            this.lblPedido.Location = new System.Drawing.Point(30, 70);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(90, 15);
            this.lblPedido.TabIndex = 52;
            this.lblPedido.Text = "ID Pedido:";
            // 
            // cmbRepartidor
            // 
            this.cmbRepartidor.FormattingEnabled = true;
            this.cmbRepartidor.Location = new System.Drawing.Point(145, 34);
            this.cmbRepartidor.Name = "cmbRepartidor";
            this.cmbRepartidor.Size = new System.Drawing.Size(100, 21);
            this.cmbRepartidor.TabIndex = 58;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 57;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(33, 110);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(100, 40);
            this.btnAsignar.TabIndex = 56;
            this.btnAsignar.Text = "Asignar Ruta";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lblIDRepartidor
            // 
            this.lblIDRepartidor.Location = new System.Drawing.Point(30, 40);
            this.lblIDRepartidor.Name = "lblIDRepartidor";
            this.lblIDRepartidor.Size = new System.Drawing.Size(90, 15);
            this.lblIDRepartidor.TabIndex = 55;
            this.lblIDRepartidor.Text = "ID Repartidor:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 20);
            this.lblTitulo.TabIndex = 54;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormRutasAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.cmbRepartidor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.lblIDRepartidor);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cmbPedidos);
            this.Controls.Add(this.lblPedido);
            this.Name = "FormRutasAsignar";
            this.Text = "FormRutasAsignar";
            this.Load += new System.EventHandler(this.FormRutasAsignar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPedidos;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.ComboBox cmbRepartidor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label lblIDRepartidor;
        private System.Windows.Forms.Label lblTitulo;
    }
}