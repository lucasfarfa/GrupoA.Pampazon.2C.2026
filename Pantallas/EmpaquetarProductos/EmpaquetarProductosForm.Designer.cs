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
            grpOrden.Location = new Point(9, 15);
            grpOrden.Margin = new Padding(2, 4, 2, 4);
            grpOrden.Name = "grpOrden";
            grpOrden.Padding = new Padding(2, 4, 2, 4);
            grpOrden.Size = new Size(950, 105);
            grpOrden.TabIndex = 6;
            grpOrden.TabStop = false;
            grpOrden.Text = "Orden de Preparación ";
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(659, 41);
            lblModalidad.Margin = new Padding(2, 0, 2, 0);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(142, 25);
            lblModalidad.TabIndex = 13;
            lblModalidad.Text = "Pallet/Fullfilment";
            // 
            // lblNroOrden
            // 
            lblNroOrden.AutoSize = true;
            lblNroOrden.Location = new Point(82, 41);
            lblNroOrden.Margin = new Padding(2, 0, 2, 0);
            lblNroOrden.Name = "lblNroOrden";
            lblNroOrden.Size = new Size(222, 25);
            lblNroOrden.TabIndex = 12;
            lblNroOrden.Text = "NRO ORDEN A PREPARAR";
            // 
            // lblModalidadTitulo
            // 
            lblModalidadTitulo.AutoSize = true;
            lblModalidadTitulo.Location = new Point(549, 41);
            lblModalidadTitulo.Margin = new Padding(2, 0, 2, 0);
            lblModalidadTitulo.Name = "lblModalidadTitulo";
            lblModalidadTitulo.Size = new Size(102, 25);
            lblModalidadTitulo.TabIndex = 10;
            lblModalidadTitulo.Text = "Modalidad:";
            // 
            // lblOrdenTitulo
            // 
            lblOrdenTitulo.AutoSize = true;
            lblOrdenTitulo.Location = new Point(11, 41);
            lblOrdenTitulo.Margin = new Padding(2, 0, 2, 0);
            lblOrdenTitulo.Name = "lblOrdenTitulo";
            lblOrdenTitulo.Size = new Size(66, 25);
            lblOrdenTitulo.TabIndex = 0;
            lblOrdenTitulo.Text = "Orden:";
            // 
            // grpProductos
            // 
            grpProductos.Controls.Add(lblTotalBultos);
            grpProductos.Controls.Add(lblTotalBultosTitulo);
            grpProductos.Controls.Add(lstProductos);
            grpProductos.Location = new Point(9, 126);
            grpProductos.Margin = new Padding(2, 4, 2, 4);
            grpProductos.Name = "grpProductos";
            grpProductos.Padding = new Padding(2, 4, 2, 4);
            grpProductos.Size = new Size(948, 459);
            grpProductos.TabIndex = 7;
            grpProductos.TabStop = false;
            grpProductos.Text = "Productos a empaquetar";
            grpProductos.Enter += grpProductos_Enter;
            // 
            // lblTotalBultos
            // 
            lblTotalBultos.AutoSize = true;
            lblTotalBultos.Location = new Point(894, 420);
            lblTotalBultos.Margin = new Padding(4, 0, 4, 0);
            lblTotalBultos.Name = "lblTotalBultos";
            lblTotalBultos.Size = new Size(33, 25);
            lblTotalBultos.TabIndex = 14;
            lblTotalBultos.Text = "[X]";
            // 
            // lblTotalBultosTitulo
            // 
            lblTotalBultosTitulo.AutoSize = true;
            lblTotalBultosTitulo.Location = new Point(774, 420);
            lblTotalBultosTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTotalBultosTitulo.Name = "lblTotalBultosTitulo";
            lblTotalBultosTitulo.Size = new Size(107, 25);
            lblTotalBultosTitulo.TabIndex = 13;
            lblTotalBultosTitulo.Text = "Total Bultos:";
            // 
            // lstProductos
            // 
            lstProductos.Columns.AddRange(new ColumnHeader[] { columnSKU, colDescripcion, colCantidad });
            lstProductos.FullRowSelect = true;
            lstProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstProductos.Location = new Point(11, 30);
            lstProductos.Margin = new Padding(2, 4, 2, 4);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(925, 369);
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
            btnEmpaquetar.ForeColor = SystemColors.Desktop;
            btnEmpaquetar.Location = new Point(558, 635);
            btnEmpaquetar.Margin = new Padding(2, 4, 2, 4);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(269, 59);
            btnEmpaquetar.TabIndex = 9;
            btnEmpaquetar.Text = "Confirmar Empaquetado";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            btnEmpaquetar.Click += btnEmpaquetar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(829, 635);
            btnCancelar.Margin = new Padding(2, 4, 2, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(128, 59);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EmpaquetarProductosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 701);
            Controls.Add(btnCancelar);
            Controls.Add(btnEmpaquetar);
            Controls.Add(grpProductos);
            Controls.Add(grpOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmpaquetarProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empaquetar Productos - Pampazon S.A.";
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