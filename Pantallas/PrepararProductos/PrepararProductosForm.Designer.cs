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
            grpDetalle = new GroupBox();
            listViewDetalle = new ListView();
            colDetPosicion = new ColumnHeader();
            colDetSku = new ColumnHeader();
            colDetCantidad = new ColumnHeader();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            comboOrdenSeleccion = new ComboBox();
            lblModalidad = new Label();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(14, 22);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(155, 20);
            lblDeposito.TabIndex = 0;
            lblDeposito.Text = "Depósito: [DEPOSITO]";
            // 
            // grpDetalle
            // 
            grpDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalle.Controls.Add(listViewDetalle);
            grpDetalle.Location = new Point(15, 58);
            grpDetalle.Margin = new Padding(3, 4, 3, 4);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Padding = new Padding(3, 4, 3, 4);
            grpDetalle.Size = new Size(983, 650);
            grpDetalle.TabIndex = 3;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Mercadería a retirar del almacén";
            // 
            // listViewDetalle
            // 
            listViewDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewDetalle.Columns.AddRange(new ColumnHeader[] { colDetPosicion, colDetSku, colDetCantidad });
            listViewDetalle.FullRowSelect = true;
            listViewDetalle.Location = new Point(6, 36);
            listViewDetalle.Margin = new Padding(3, 4, 3, 4);
            listViewDetalle.MultiSelect = false;
            listViewDetalle.Name = "listViewDetalle";
            listViewDetalle.Size = new Size(959, 606);
            listViewDetalle.TabIndex = 1;
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
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new Point(619, 718);
            btnConfirmar.Margin = new Padding(3, 4, 3, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(263, 40);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar entrega a Preparación";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(894, 718);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // comboOrdenSeleccion
            // 
            comboOrdenSeleccion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOrdenSeleccion.FormattingEnabled = true;
            comboOrdenSeleccion.Items.AddRange(new object[] { "FulFillment", "Palet Cerrado" });
            comboOrdenSeleccion.Location = new Point(776, 22);
            comboOrdenSeleccion.Margin = new Padding(3, 2, 3, 2);
            comboOrdenSeleccion.Name = "comboOrdenSeleccion";
            comboOrdenSeleccion.Size = new Size(204, 28);
            comboOrdenSeleccion.TabIndex = 0;
            comboOrdenSeleccion.SelectedIndexChanged += comboOrdenSeleccion_SelectedIndexChanged;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(634, 25);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(136, 20);
            lblModalidad.TabIndex = 11;
            lblModalidad.Text = "Orden de seleccion";
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1010, 774);
            Controls.Add(comboOrdenSeleccion);
            Controls.Add(lblModalidad);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(grpDetalle);
            Controls.Add(lblDeposito);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(794, 614);
            Name = "PrepararProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preparar Productos - Pampazon S.A.";
            FormClosing += PrepararProductosForm_FormClosing;
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
        private System.Windows.Forms.ColumnHeader colDetCantidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private ComboBox comboOrdenSeleccion;
        private Label lblModalidad;
    }
}