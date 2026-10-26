namespace GrupoA.PampazonSA.AdministracionDeposito.CU04EmpaquetarProductos
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
            label5 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            lblTotalBultos = new Label();
            label2 = new Label();
            lstProductos = new ListView();
            columnSKU = new ColumnHeader();
            colDescripcion = new ColumnHeader();
            colCantidad = new ColumnHeader();
            CantidadCol = new ColumnHeader();
            btnEmpaquetar = new Button();
            btnCancelar = new Button();
            grpOrden.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrden
            // 
            grpOrden.Controls.Add(lblModalidad);
            grpOrden.Controls.Add(lblNroOrden);
            grpOrden.Controls.Add(label5);
            grpOrden.Controls.Add(label3);
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(384, 25);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 10;
            label5.Text = "Modalidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 25);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 0;
            label3.Text = "Orden:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTotalBultos);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(lstProductos);
            groupBox2.Location = new Point(6, 76);
            groupBox2.Margin = new Padding(2, 2, 2, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 2, 2, 2);
            groupBox2.Size = new Size(663, 275);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Productos a empaquetar";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(542, 252);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 13;
            label2.Text = "Total Bultos:";
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
            Controls.Add(groupBox2);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOrden;
        private Label label5;
        // private TextBox textModalidad;
        private GroupBox groupBox2;
        private ListView lstProductos;
        // private ColumnHeader columnHeader1;
        // private ColumnHeader columnHeader2;
        private ColumnHeader CantidadCol;
        private Button btnEmpaquetar;
        private Label label3;
        private Label lblTotalBultos;
        private Label label2;
        // private TextBox txtNumeroOrden;
        private Button btnCancelar;
        private Label lblModalidad;
        private Label lblNroOrden;
        private ColumnHeader columnSKU;
        private ColumnHeader colDescripcion;
        private ColumnHeader colCantidad;
    }
}