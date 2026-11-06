namespace GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos
{
    partial class EmpaquetarProductosForm
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
            grpOrden = new GroupBox();
            lblModalidad = new Label();
            lblNroOrden = new Label();
            lblModalidadTitulo = new Label();
            lblOrdenTitulo = new Label();
            grpProductos = new GroupBox();
            lblTotalBultos = new Label();
            lblTotalBultosTitulo = new Label();
            lstProductos = new ListView();
            columnSKU = new ColumnHeader();
            colDescripcion = new ColumnHeader();
            colCantidad = new ColumnHeader();
            CantidadCol = new ColumnHeader();
            btnEmpaquetar = new Button();
            btnCancelar = new Button();
            grpOrden.SuspendLayout();
            grpProductos.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrden
            // 
            grpOrden.Controls.Add(lblModalidad);
            grpOrden.Controls.Add(lblNroOrden);
            grpOrden.Controls.Add(lblModalidadTitulo);
            grpOrden.Controls.Add(lblOrdenTitulo);
            grpOrden.Location = new Point(6, 9);
            grpOrden.Margin = new Padding(2, 2, 2, 2);
            grpOrden.Name = "grpOrden";
            grpOrden.Padding = new Padding(2, 2, 2, 2);
            grpOrden.Size = new Size(665, 63);
            grpOrden.TabIndex = 6;
            grpOrden.TabStop = false;
            grpOrden.Text = "Orden de Preparación ";
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(461, 25);
            lblModalidad.Margin = new Padding(2, 0, 2, 0);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(98, 15);
            lblModalidad.TabIndex = 13;
            lblModalidad.Text = "Pallet/Fullfilment";
            // 
            // lblNroOrden
            // 
            lblNroOrden.AutoSize = true;
            lblNroOrden.Location = new Point(58, 25);
            lblNroOrden.Margin = new Padding(2, 0, 2, 0);
            lblNroOrden.Name = "lblNroOrden";
            lblNroOrden.Size = new Size(144, 15);
            lblNroOrden.TabIndex = 12;
            lblNroOrden.Text = "NRO ORDEN A PREPARAR";
            // 
            // lblModalidadTitulo
            // 
            lblModalidadTitulo.AutoSize = true;
            lblModalidadTitulo.Location = new Point(384, 25);
            lblModalidadTitulo.Margin = new Padding(2, 0, 2, 0);
            lblModalidadTitulo.Name = "lblModalidadTitulo";
            lblModalidadTitulo.Size = new Size(67, 15);
            lblModalidadTitulo.TabIndex = 10;
            lblModalidadTitulo.Text = "Modalidad:";
            // 
            // lblOrdenTitulo
            // 
            lblOrdenTitulo.AutoSize = true;
            lblOrdenTitulo.Location = new Point(8, 25);
            lblOrdenTitulo.Margin = new Padding(2, 0, 2, 0);
            lblOrdenTitulo.Name = "lblOrdenTitulo";
            lblOrdenTitulo.Size = new Size(43, 15);
            lblOrdenTitulo.TabIndex = 0;
            lblOrdenTitulo.Text = "Orden:";
            // 
            // grpProductos
            // 
            grpProductos.Controls.Add(lblTotalBultos);
            grpProductos.Controls.Add(lblTotalBultosTitulo);
            grpProductos.Controls.Add(lstProductos);
            grpProductos.Location = new Point(6, 76);
            grpProductos.Margin = new Padding(2, 2, 2, 2);
            grpProductos.Name = "grpProductos";
            grpProductos.Padding = new Padding(2, 2, 2, 2);
            grpProductos.Size = new Size(663, 275);
            grpProductos.TabIndex = 7;
            grpProductos.TabStop = false;
            grpProductos.Text = "Productos a empaquetar";
            // 
            // lblTotalBultos
            // 
            lblTotalBultos.AutoSize = true;
            lblTotalBultos.Location = new Point(626, 252);
            lblTotalBultos.Name = "lblTotalBultos";
            lblTotalBultos.Size = new Size(22, 15);
            lblTotalBultos.TabIndex = 14;
            lblTotalBultos.Text = "[X]";
            // 
            // lblTotalBultosTitulo
            // 
            lblTotalBultosTitulo.AutoSize = true;
            lblTotalBultosTitulo.Location = new Point(542, 252);
            lblTotalBultosTitulo.Name = "lblTotalBultosTitulo";
            lblTotalBultosTitulo.Size = new Size(72, 15);
            lblTotalBultosTitulo.TabIndex = 13;
            lblTotalBultosTitulo.Text = "Total Bultos:";
            // 
            // lstProductos
            // 
            lstProductos.Columns.AddRange(new ColumnHeader[] { columnSKU, colDescripcion, colCantidad });
            lstProductos.FullRowSelect = true;
            lstProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstProductos.Location = new Point(8, 18);
            lstProductos.Margin = new Padding(2, 2, 2, 2);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(649, 223);
            lstProductos.TabIndex = 1;
            lstProductos.UseCompatibleStateImageBehavior = false;
            lstProductos.View = View.Details;
            // 
            // columnSKU
            // 
            columnSKU.Text = "SKU";
            columnSKU.Width = 100;
            // 
            // colDescripcion
            // 
            colDescripcion.Text = "Descripcion";
            colDescripcion.Width = 200;
            // 
            // colCantidad
            // 
            colCantidad.Text = "Cantidad";
            colCantidad.Width = 80;
            // 
            // CantidadCol
            // 
            CantidadCol.Text = "Cantidad";
            CantidadCol.Width = 120;
            // 
            // btnEmpaquetar
            // 
            btnEmpaquetar.Enabled = false;
            btnEmpaquetar.ForeColor = SystemColors.HotTrack;
            btnEmpaquetar.Location = new Point(390, 381);
            btnEmpaquetar.Margin = new Padding(2, 2, 2, 2);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(188, 35);
            btnEmpaquetar.TabIndex = 9;
            btnEmpaquetar.Text = "Confirmar Empaquetado";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            btnEmpaquetar.Click += btnEmpaquetar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlLight;
            btnCancelar.ForeColor = SystemColors.WindowFrame;
            btnCancelar.Location = new Point(580, 381);
            btnCancelar.Margin = new Padding(2, 2, 2, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 35);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EmpaquetarProductosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 421);
            Controls.Add(btnCancelar);
            Controls.Add(btnEmpaquetar);
            Controls.Add(grpProductos);
            Controls.Add(grpOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmpaquetarProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empaquetar Productos - Pampazon S.A";
            FormClosing += EmpaquetarProductosForm_FormClosing;
            Load += EmpaquetarProductosForm_Load;
            grpOrden.ResumeLayout(false);
            grpOrden.PerformLayout();
            grpProductos.ResumeLayout(false);
            grpProductos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOrden;
        private Label lblModalidadTitulo;
        // private TextBox textModalidad;
        private GroupBox grpProductos;
        private ListView lstProductos;
        // private ColumnHeader columnHeader1;
        // private ColumnHeader columnHeader2;
        private ColumnHeader CantidadCol;
        private Button btnEmpaquetar;
        private Label lblOrdenTitulo;
        private Label lblTotalBultos;
        private Label lblTotalBultosTitulo;
        // private TextBox txtNumeroOrden;
        private Button btnCancelar;
        private Label lblModalidad;
        private Label lblNroOrden;
        private ColumnHeader columnSKU;
        private ColumnHeader colDescripcion;
        private ColumnHeader colCantidad;
    }
}