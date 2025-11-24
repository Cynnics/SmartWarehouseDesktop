namespace SmartWarehouseDesktop.CRUDs
{
    partial class FormRutasEntregaEditar
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
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dtpFechaRuta = new System.Windows.Forms.DateTimePicker();
            this.nudDistancia = new System.Windows.Forms.NumericUpDown();
            this.cmbRepartidor = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblFechaRuta = new System.Windows.Forms.Label();
            this.lblRepartidor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(145, 158);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(100, 21);
            this.cmbEstado.TabIndex = 70;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(30, 160);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(90, 15);
            this.lblEstado.TabIndex = 69;
            this.lblEstado.Text = "Estado:";
            // 
            // dtpFechaRuta
            // 
            this.dtpFechaRuta.Enabled = false;
            this.dtpFechaRuta.Location = new System.Drawing.Point(145, 64);
            this.dtpFechaRuta.Name = "dtpFechaRuta";
            this.dtpFechaRuta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaRuta.TabIndex = 67;
            // 
            // nudDistancia
            // 
            this.nudDistancia.DecimalPlaces = 2;
            this.nudDistancia.Location = new System.Drawing.Point(145, 97);
            this.nudDistancia.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDistancia.Name = "nudDistancia";
            this.nudDistancia.Size = new System.Drawing.Size(100, 20);
            this.nudDistancia.TabIndex = 66;
            // 
            // cmbRepartidor
            // 
            this.cmbRepartidor.FormattingEnabled = true;
            this.cmbRepartidor.Location = new System.Drawing.Point(145, 34);
            this.cmbRepartidor.Name = "cmbRepartidor";
            this.cmbRepartidor.Size = new System.Drawing.Size(100, 21);
            this.cmbRepartidor.TabIndex = 65;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 64;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(33, 205);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 63;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblDuracion
            // 
            this.lblDuracion.Location = new System.Drawing.Point(30, 130);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(90, 15);
            this.lblDuracion.TabIndex = 62;
            this.lblDuracion.Text = "Duracion (min):";
            // 
            // lblDistancia
            // 
            this.lblDistancia.Location = new System.Drawing.Point(30, 100);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(90, 15);
            this.lblDistancia.TabIndex = 61;
            this.lblDistancia.Text = "Distancia (km):";
            // 
            // lblFechaRuta
            // 
            this.lblFechaRuta.Location = new System.Drawing.Point(30, 70);
            this.lblFechaRuta.Name = "lblFechaRuta";
            this.lblFechaRuta.Size = new System.Drawing.Size(90, 15);
            this.lblFechaRuta.TabIndex = 60;
            this.lblFechaRuta.Text = "Fecha Ruta:";
            // 
            // lblRepartidor
            // 
            this.lblRepartidor.Location = new System.Drawing.Point(30, 40);
            this.lblRepartidor.Name = "lblRepartidor";
            this.lblRepartidor.Size = new System.Drawing.Size(90, 15);
            this.lblRepartidor.TabIndex = 59;
            this.lblRepartidor.Text = "Repartidor:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 20);
            this.lblTitulo.TabIndex = 58;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDuracion
            // 
            this.nudDuracion.DecimalPlaces = 2;
            this.nudDuracion.Location = new System.Drawing.Point(145, 128);
            this.nudDuracion.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDuracion.Name = "nudDuracion";
            this.nudDuracion.Size = new System.Drawing.Size(100, 20);
            this.nudDuracion.TabIndex = 71;
            // 
            // FormRutasEntregaEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.nudDuracion);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.dtpFechaRuta);
            this.Controls.Add(this.nudDistancia);
            this.Controls.Add(this.cmbRepartidor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblDistancia);
            this.Controls.Add(this.lblFechaRuta);
            this.Controls.Add(this.lblRepartidor);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormRutasEntregaEditar";
            this.Text = "FormRutasEntregaEditar";
            this.Load += new System.EventHandler(this.FormRutasEntregaEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DateTimePicker dtpFechaRuta;
        private System.Windows.Forms.NumericUpDown nudDistancia;
        private System.Windows.Forms.ComboBox cmbRepartidor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblFechaRuta;
        private System.Windows.Forms.Label lblRepartidor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.NumericUpDown nudDuracion;
    }
}