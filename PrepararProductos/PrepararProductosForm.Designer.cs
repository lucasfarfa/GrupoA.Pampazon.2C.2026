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
            lblDeposito = new Label();
            btnActualizar = new Button();
            grpOS = new GroupBox();
            lblNoHayOS = new Label();
            listViewOS = new ListView();
            colOsNumero = new ColumnHeader();
            grpDetalle = new GroupBox();
            listViewDetalle = new ListView();
            colDetPosicion = new ColumnHeader();
            colDetSku = new ColumnHeader();
            colDetCantidad = new ColumnHeader();
            colDetDescripcion = new ColumnHeader();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            grpOS.SuspendLayout();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(14, 23);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(155, 20);
            lblDeposito.TabIndex = 0;
            lblDeposito.Text = "Depósito: [DEPOSITO]";
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(848, 15);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(149, 36);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar lista";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // grpOS
            // 
            grpOS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpOS.Controls.Add(lblNoHayOS);
            grpOS.Controls.Add(listViewOS);
            grpOS.Location = new Point(14, 61);
            grpOS.Margin = new Padding(3, 4, 3, 4);
            grpOS.Name = "grpOS";
            grpOS.Padding = new Padding(3, 4, 3, 4);
            grpOS.Size = new Size(983, 177);
            grpOS.TabIndex = 2;
            grpOS.TabStop = false;
            grpOS.Text = "Órdenes de selección pendientes";
            // 
            // lblNoHayOS
            // 
            lblNoHayOS.AutoSize = true;
            lblNoHayOS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNoHayOS.ForeColor = Color.DodgerBlue;
            lblNoHayOS.Location = new Point(11, 148);
            lblNoHayOS.Name = "lblNoHayOS";
            lblNoHayOS.Size = new Size(337, 20);
            lblNoHayOS.TabIndex = 1;
            lblNoHayOS.Text = "NO HAY ÓRDENES DE SELECCIÓN PENDIENTES";
            lblNoHayOS.Visible = false;
            // 
            // listViewOS
            // 
            listViewOS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewOS.Columns.AddRange(new ColumnHeader[] { colOsNumero });
            listViewOS.FullRowSelect = true;
            listViewOS.Location = new Point(11, 29);
            listViewOS.Margin = new Padding(3, 4, 3, 4);
            listViewOS.MultiSelect = false;
            listViewOS.Name = "listViewOS";
            listViewOS.Size = new Size(959, 115);
            listViewOS.TabIndex = 0;
            listViewOS.UseCompatibleStateImageBehavior = false;
            listViewOS.View = View.Details;
            listViewOS.SelectedIndexChanged += listViewOS_SelectedIndexChanged;
            // 
            // colOsNumero
            // 
            colOsNumero.Text = "Nº OS";
            colOsNumero.Width = 110;
            // 
            // grpDetalle
            // 
            grpDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalle.Controls.Add(listViewDetalle);
            grpDetalle.Location = new Point(15, 246);
            grpDetalle.Margin = new Padding(3, 4, 3, 4);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Padding = new Padding(3, 4, 3, 4);
            grpDetalle.Size = new Size(983, 463);
            grpDetalle.TabIndex = 3;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Mercadería a retirar del almacén";
            // 
            // listViewDetalle
            // 
            listViewDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewDetalle.Columns.AddRange(new ColumnHeader[] { colDetPosicion, colDetSku, colDetCantidad, colDetDescripcion });
            listViewDetalle.FullRowSelect = true;
            listViewDetalle.Location = new Point(6, 36);
            listViewDetalle.Margin = new Padding(3, 4, 3, 4);
            listViewDetalle.MultiSelect = false;
            listViewDetalle.Name = "listViewDetalle";
            listViewDetalle.Size = new Size(959, 419);
            listViewDetalle.TabIndex = 0;
            listViewDetalle.UseCompatibleStateImageBehavior = false;
            listViewDetalle.View = View.Details;
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
            colDetCantidad.TextAlign = HorizontalAlignment.Right;
            colDetCantidad.Width = 80;
            // 
            // colDetDescripcion
            // 
            colDetDescripcion.Text = "Descripción";
            colDetDescripcion.Width = 270;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new Point(619, 717);
            btnConfirmar.Margin = new Padding(3, 4, 3, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(263, 40);
            btnConfirmar.TabIndex = 4;
            btnConfirmar.Text = "Confirmar entrega a Preparación";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(894, 717);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 40);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1010, 773);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(grpDetalle);
            Controls.Add(grpOS);
            Controls.Add(btnActualizar);
            Controls.Add(lblDeposito);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(797, 624);
            Name = "PrepararProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preparar Productos- Pampazon S.A.";
            Load += PrepararProductosForm_Load;
            grpOS.ResumeLayout(false);
            grpOS.PerformLayout();
            grpDetalle.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox grpOS;
        private System.Windows.Forms.Label lblNoHayOS;
        private System.Windows.Forms.ListView listViewOS;
        private System.Windows.Forms.ColumnHeader colOsNumero;
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