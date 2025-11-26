namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormUbicacionesEditar
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
            this.cmbRepartidor = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.lblLatitud = new System.Windows.Forms.Label();
            this.lblRepartidor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.nudLatitud = new System.Windows.Forms.NumericUpDown();
            this.nudLongitud = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitud)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(145, 128);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 81;
            // 
            // cmbRepartidor
            // 
            this.cmbRepartidor.FormattingEnabled = true;
            this.cmbRepartidor.Location = new System.Drawing.Point(145, 34);
            this.cmbRepartidor.Name = "cmbRepartidor";
            this.cmbRepartidor.Size = new System.Drawing.Size(100, 21);
            this.cmbRepartidor.TabIndex = 79;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 78;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(33, 205);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 77;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(30, 130);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(90, 15);
            this.lblFecha.TabIndex = 76;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblLongitud
            // 
            this.lblLongitud.Location = new System.Drawing.Point(30, 100);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(90, 15);
            this.lblLongitud.TabIndex = 75;
            this.lblLongitud.Text = "Longitud:";
            // 
            // lblLatitud
            // 
            this.lblLatitud.Location = new System.Drawing.Point(30, 70);
            this.lblLatitud.Name = "lblLatitud";
            this.lblLatitud.Size = new System.Drawing.Size(90, 15);
            this.lblLatitud.TabIndex = 74;
            this.lblLatitud.Text = "Latitud:";
            // 
            // lblRepartidor
            // 
            this.lblRepartidor.Location = new System.Drawing.Point(30, 40);
            this.lblRepartidor.Name = "lblRepartidor";
            this.lblRepartidor.Size = new System.Drawing.Size(90, 15);
            this.lblRepartidor.TabIndex = 73;
            this.lblRepartidor.Text = "Repartidor:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 20);
            this.lblTitulo.TabIndex = 72;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudLatitud
            // 
            this.nudLatitud.DecimalPlaces = 6;
            this.nudLatitud.Location = new System.Drawing.Point(145, 65);
            this.nudLatitud.Name = "nudLatitud";
            this.nudLatitud.Size = new System.Drawing.Size(101, 20);
            this.nudLatitud.TabIndex = 82;
            // 
            // nudLongitud
            // 
            this.nudLongitud.DecimalPlaces = 6;
            this.nudLongitud.Location = new System.Drawing.Point(145, 95);
            this.nudLongitud.Name = "nudLongitud";
            this.nudLongitud.Size = new System.Drawing.Size(101, 20);
            this.nudLongitud.TabIndex = 83;
            // 
            // FormUbicacionesEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.nudLongitud);
            this.Controls.Add(this.nudLatitud);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbRepartidor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblLongitud);
            this.Controls.Add(this.lblLatitud);
            this.Controls.Add(this.lblRepartidor);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormUbicacionesEditar";
            this.Text = "FormUbicacionesEditar";
            this.Load += new System.EventHandler(this.FormUbicacionesEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbRepartidor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Label lblLatitud;
        private System.Windows.Forms.Label lblRepartidor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.NumericUpDown nudLatitud;
        private System.Windows.Forms.NumericUpDown nudLongitud;
    }
}