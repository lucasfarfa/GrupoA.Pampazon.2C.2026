namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    partial class PrepararProductosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDeposito = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.grpOS = new System.Windows.Forms.GroupBox();
            this.lblNoHayOS = new System.Windows.Forms.Label();
            this.listViewOS = new System.Windows.Forms.ListView();
            this.colOsNumero = new System.Windows.Forms.ColumnHeader();
            this.colOsFecha = new System.Windows.Forms.ColumnHeader();
            this.colOsOrdenes = new System.Windows.Forms.ColumnHeader();
            this.colOsLineas = new System.Windows.Forms.ColumnHeader();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.listViewDetalle = new System.Windows.Forms.ListView();
            this.colDetPosicion = new System.Windows.Forms.ColumnHeader();
            this.colDetCliente = new System.Windows.Forms.ColumnHeader();
            this.colDetSku = new System.Windows.Forms.ColumnHeader();
            this.colDetDescripcion = new System.Windows.Forms.ColumnHeader();
            this.colDetCantidad = new System.Windows.Forms.ColumnHeader();
            this.colDetUnidad = new System.Windows.Forms.ColumnHeader();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpOS.SuspendLayout();
            this.grpDetalle.SuspendLayout();
            this.SuspendLayout();
            //
            // lblDeposito
            //
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Location = new System.Drawing.Point(12, 17);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(96, 15);
            this.lblDeposito.TabIndex = 0;
            this.lblDeposito.Text = "Depósito: [DEPOSITO]";
            //
            // btnActualizar
            //
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(742, 11);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 27);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // grpOS
            //
            this.grpOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOS.Controls.Add(this.lblNoHayOS);
            this.grpOS.Controls.Add(this.listViewOS);
            this.grpOS.Location = new System.Drawing.Point(12, 46);
            this.grpOS.Name = "grpOS";
            this.grpOS.Size = new System.Drawing.Size(860, 180);
            this.grpOS.TabIndex = 2;
            this.grpOS.TabStop = false;
            this.grpOS.Text = "Órdenes de selección pendientes";
            //
            // lblNoHayOS
            //
            this.lblNoHayOS.AutoSize = true;
            this.lblNoHayOS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNoHayOS.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNoHayOS.Location = new System.Drawing.Point(10, 154);
            this.lblNoHayOS.Name = "lblNoHayOS";
            this.lblNoHayOS.Size = new System.Drawing.Size(290, 15);
            this.lblNoHayOS.TabIndex = 1;
            this.lblNoHayOS.Text = "NO HAY ÓRDENES DE SELECCIÓN PENDIENTES";
            this.lblNoHayOS.Visible = false;
            //
            // listViewOS
            //
            this.listViewOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewOS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOsNumero,
            this.colOsFecha,
            this.colOsOrdenes,
            this.colOsLineas});
            this.listViewOS.FullRowSelect = true;
            this.listViewOS.GridLines = false;
            this.listViewOS.HideSelection = false;
            this.listViewOS.Location = new System.Drawing.Point(10, 22);
            this.listViewOS.MultiSelect = false;
            this.listViewOS.Name = "listViewOS";
            this.listViewOS.Size = new System.Drawing.Size(840, 126);
            this.listViewOS.TabIndex = 0;
            this.listViewOS.UseCompatibleStateImageBehavior = false;
            this.listViewOS.View = System.Windows.Forms.View.Details;
            this.listViewOS.SelectedIndexChanged += new System.EventHandler(this.listViewOS_SelectedIndexChanged);
            //
            // colOsNumero
            //
            this.colOsNumero.Text = "Nº OS";
            this.colOsNumero.Width = 110;
            //
            // colOsFecha
            //
            this.colOsFecha.Text = "Fecha emisión";
            this.colOsFecha.Width = 130;
            //
            // colOsOrdenes
            //
            this.colOsOrdenes.Text = "Órdenes de preparación";
            this.colOsOrdenes.Width = 470;
            //
            // colOsLineas
            //
            this.colOsLineas.Text = "Líneas";
            this.colOsLineas.Width = 80;
            //
            // grpDetalle
            //
            this.grpDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalle.Controls.Add(this.listViewDetalle);
            this.grpDetalle.Location = new System.Drawing.Point(12, 236);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(860, 290);
            this.grpDetalle.TabIndex = 3;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Mercadería a retirar del almacén";
            //
            // listViewDetalle
            //
            this.listViewDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDetalle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDetPosicion,
            this.colDetCliente,
            this.colDetSku,
            this.colDetDescripcion,
            this.colDetCantidad,
            this.colDetUnidad});
            this.listViewDetalle.FullRowSelect = true;
            this.listViewDetalle.HideSelection = false;
            this.listViewDetalle.Location = new System.Drawing.Point(10, 22);
            this.listViewDetalle.MultiSelect = false;
            this.listViewDetalle.Name = "listViewDetalle";
            this.listViewDetalle.Size = new System.Drawing.Size(840, 258);
            this.listViewDetalle.TabIndex = 0;
            this.listViewDetalle.UseCompatibleStateImageBehavior = false;
            this.listViewDetalle.View = System.Windows.Forms.View.Details;
            //
            // colDetPosicion
            //
            this.colDetPosicion.Text = "Posición (X-Y-Z)";
            this.colDetPosicion.Width = 110;
            //
            // colDetCliente
            //
            this.colDetCliente.Text = "Cliente";
            this.colDetCliente.Width = 160;
            //
            // colDetSku
            //
            this.colDetSku.Text = "SKU";
            this.colDetSku.Width = 100;
            //
            // colDetDescripcion
            //
            this.colDetDescripcion.Text = "Descripción";
            this.colDetDescripcion.Width = 270;
            //
            // colDetCantidad
            //
            this.colDetCantidad.Text = "Cantidad";
            this.colDetCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDetCantidad.Width = 80;
            //
            // colDetUnidad
            //
            this.colDetUnidad.Text = "Unidad";
            this.colDetUnidad.Width = 80;
            //
            // btnConfirmar
            //
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Location = new System.Drawing.Point(542, 538);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(230, 30);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar entrega a Preparación";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(782, 538);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // PrepararProductosForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(884, 580);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.grpOS);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblDeposito);
            this.MinimumSize = new System.Drawing.Size(700, 480);
            this.Name = "PrepararProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Picking - Pampazon S.A.";
            this.Load += new System.EventHandler(this.PrepararProductosForm_Load);
            this.grpOS.ResumeLayout(false);
            this.grpOS.PerformLayout();
            this.grpDetalle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox grpOS;
        private System.Windows.Forms.Label lblNoHayOS;
        private System.Windows.Forms.ListView listViewOS;
        private System.Windows.Forms.ColumnHeader colOsNumero;
        private System.Windows.Forms.ColumnHeader colOsFecha;
        private System.Windows.Forms.ColumnHeader colOsOrdenes;
        private System.Windows.Forms.ColumnHeader colOsLineas;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.ListView listViewDetalle;
        private System.Windows.Forms.ColumnHeader colDetPosicion;
        private System.Windows.Forms.ColumnHeader colDetCliente;
        private System.Windows.Forms.ColumnHeader colDetSku;
        private System.Windows.Forms.ColumnHeader colDetDescripcion;
        private System.Windows.Forms.ColumnHeader colDetCantidad;
        private System.Windows.Forms.ColumnHeader colDetUnidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}