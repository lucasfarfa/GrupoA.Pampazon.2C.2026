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
            lblDeposito = new System.Windows.Forms.Label();
            grpDetalle = new System.Windows.Forms.GroupBox();
            listViewDetalle = new System.Windows.Forms.ListView();
            colDetPosicion = new System.Windows.Forms.ColumnHeader();
            colDetSku = new System.Windows.Forms.ColumnHeader();
            colDetCantidad = new System.Windows.Forms.ColumnHeader();
            colDetDescripcion = new System.Windows.Forms.ColumnHeader();
            btnConfirmar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new System.Drawing.Point(12, 17);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new System.Drawing.Size(122, 15);
            lblDeposito.TabIndex = 0;
            lblDeposito.Text = "Depósito: [DEPOSITO]";
            // 
            // grpDetalle
            // 
            grpDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpDetalle.Controls.Add(listViewDetalle);
            grpDetalle.Location = new System.Drawing.Point(13, 44);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new System.Drawing.Size(860, 487);
            grpDetalle.TabIndex = 3;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Mercadería a retirar del almacén";
            // 
            // listViewDetalle
            // 
            listViewDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listViewDetalle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colDetPosicion, colDetSku, colDetCantidad, colDetDescripcion });
            listViewDetalle.FullRowSelect = true;
            listViewDetalle.Location = new System.Drawing.Point(5, 27);
            listViewDetalle.MultiSelect = false;
            listViewDetalle.Name = "listViewDetalle";
            listViewDetalle.Size = new System.Drawing.Size(840, 455);
            listViewDetalle.TabIndex = 0;
            listViewDetalle.UseCompatibleStateImageBehavior = false;
            listViewDetalle.View = System.Windows.Forms.View.Details;
            // 
            // colDetPosicion
            // 
            colDetPosicion.Text = "Posición (X-Y-Z)";
            colDetPosicion.Width = 150;
            // 
            // colDetSku
            // 
            colDetSku.Text = "SKU";
            colDetSku.Width = 100;
            // 
            // colDetCantidad
            // 
            colDetCantidad.Text = "Cantidad";
            colDetCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            colDetCantidad.Width = 80;
            // 
            // colDetDescripcion
            // 
            colDetDescripcion.Text = "Descripción";
            colDetDescripcion.Width = 270;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new System.Drawing.Point(542, 538);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new System.Drawing.Size(230, 30);
            btnConfirmar.TabIndex = 4;
            btnConfirmar.Text = "Confirmar entrega a Preparación";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancelar.Location = new System.Drawing.Point(782, 538);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(90, 30);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(884, 580);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(grpDetalle);
            Controls.Add(lblDeposito);
            MinimumSize = new System.Drawing.Size(699, 478);
            Name = "PrepararProductosForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Preparar Productos - Pampazon S.A.";
            Load += PrepararProductosForm_Load;
            grpDetalle.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.ListView listViewDetalle;
        private System.Windows.Forms.ColumnHeader colDetPosicion;
        private System.Windows.Forms.ColumnHeader colDetSku;
        private System.Windows.Forms.ColumnHeader colDetDescripcion;
        private System.Windows.Forms.ColumnHeader colDetCantidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}