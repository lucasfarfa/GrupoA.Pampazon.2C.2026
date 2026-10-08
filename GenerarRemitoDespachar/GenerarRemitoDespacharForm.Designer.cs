namespace AdministracionDeposito
{
    partial class GenerarRemitoDespacharForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "OP-000310", "Producto ficticio A", "40" }, -1);
            grpOrdenesPendientes = new GroupBox();
            lvwOrdenes = new ListView();
            ColNroOrden = new ColumnHeader();
            ColCliente = new ColumnHeader();
            ColBultos = new ColumnHeader();
            ColDarsena = new ColumnHeader();
            ColFechaPreparación = new ColumnHeader();
            btnConfirmarDespacho = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ColDomicilio = new ColumnHeader();
            ColPeso = new ColumnHeader();
            lvwDetalle = new ListView();
            ColOrdenPreparacion = new ColumnHeader();
            ColProducto = new ColumnHeader();
            ColCantidad = new ColumnHeader();
            lblEmpresaTransportista = new Label();
            lblDni = new Label();
            lblChofer = new Label();
            lblPatente = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            grpOrdenesPendientes.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrdenesPendientes
            // 
            grpOrdenesPendientes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpOrdenesPendientes.Controls.Add(lvwOrdenes);
            grpOrdenesPendientes.Font = new Font("Segoe UI", 9F);
            grpOrdenesPendientes.Location = new Point(12, 12);
            grpOrdenesPendientes.Name = "grpOrdenesPendientes";
            grpOrdenesPendientes.Size = new Size(1095, 302);
            grpOrdenesPendientes.TabIndex = 0;
            grpOrdenesPendientes.TabStop = false;
            grpOrdenesPendientes.Text = "Órdenes de entrega en despacho";
            grpOrdenesPendientes.Enter += grpOrdenesPendientes_Enter;
            // 
            // lvwOrdenes
            // 
            lvwOrdenes.Columns.AddRange(new ColumnHeader[] { ColNroOrden, ColCliente, ColDomicilio, ColBultos, ColPeso, ColDarsena, ColFechaPreparación });
            lvwOrdenes.Dock = DockStyle.Fill;
            lvwOrdenes.Font = new Font("Segoe UI", 9F);
            lvwOrdenes.FullRowSelect = true;
            lvwOrdenes.Location = new Point(3, 23);
            lvwOrdenes.MultiSelect = false;
            lvwOrdenes.Name = "lvwOrdenes";
            lvwOrdenes.Size = new Size(1089, 276);
            lvwOrdenes.TabIndex = 0;
            lvwOrdenes.UseCompatibleStateImageBehavior = false;
            lvwOrdenes.View = View.Details;
            lvwOrdenes.SelectedIndexChanged += lvwOrdenes_SelectedIndexChanged;
            // 
            // ColNroOrden
            // 
            ColNroOrden.Text = "N° Orden";
            ColNroOrden.Width = 80;
            // 
            // ColCliente
            // 
            ColCliente.Text = "Cliente";
            ColCliente.Width = 330;
            // 
            // ColBultos
            // 
            ColBultos.Text = "Bultos";
            ColBultos.TextAlign = HorizontalAlignment.Right;
            // 
            // ColDarsena
            // 
            ColDarsena.Text = "Dársena";
            ColDarsena.Width = 70;
            // 
            // ColFechaPreparación
            // 
            ColFechaPreparación.Text = "Fecha de preparación";
            ColFechaPreparación.Width = 155;
            // 
            // btnConfirmarDespacho
            // 
            btnConfirmarDespacho.Location = new Point(776, 618);
            btnConfirmarDespacho.Name = "btnConfirmarDespacho";
            btnConfirmarDespacho.Size = new Size(166, 27);
            btnConfirmarDespacho.TabIndex = 4;
            btnConfirmarDespacho.Text = "Confirmar despacho";
            btnConfirmarDespacho.UseVisualStyleBackColor = true;
            btnConfirmarDespacho.Click += btnConfirmarDespacho_Click;
            // 
            // button1
            // 
            button1.Location = new Point(970, 618);
            button1.Name = "button1";
            button1.Size = new Size(123, 27);
            button1.TabIndex = 5;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(lvwDetalle);
            groupBox1.Font = new Font("Segoe UI", 9F);
            groupBox1.Location = new Point(15, 320);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(523, 274);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalle de la orden";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(lblPatente);
            groupBox2.Controls.Add(lblChofer);
            groupBox2.Controls.Add(lblDni);
            groupBox2.Controls.Add(lblEmpresaTransportista);
            groupBox2.Font = new Font("Segoe UI", 9F);
            groupBox2.Location = new Point(570, 317);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(534, 274);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del transportista";
            // 
            // ColDomicilio
            // 
            ColDomicilio.Text = "Domicilio de entrega";
            ColDomicilio.Width = 300;
            // 
            // ColPeso
            // 
            ColPeso.Text = "Peso (kg)";
            ColPeso.TextAlign = HorizontalAlignment.Right;
            ColPeso.Width = 80;
            // 
            // lvwDetalle
            // 
            lvwDetalle.Columns.AddRange(new ColumnHeader[] { ColOrdenPreparacion, ColProducto, ColCantidad });
            lvwDetalle.Dock = DockStyle.Fill;
            lvwDetalle.FullRowSelect = true;
            lvwDetalle.GridLines = true;
            lvwDetalle.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvwDetalle.Items.AddRange(new ListViewItem[] { listViewItem3 });
            lvwDetalle.Location = new Point(3, 23);
            lvwDetalle.MultiSelect = false;
            lvwDetalle.Name = "lvwDetalle";
            lvwDetalle.Size = new Size(517, 248);
            lvwDetalle.TabIndex = 0;
            lvwDetalle.TabStop = false;
            lvwDetalle.UseCompatibleStateImageBehavior = false;
            lvwDetalle.View = View.Details;
            // 
            // ColOrdenPreparacion
            // 
            ColOrdenPreparacion.Text = "Orden de preparación";
            ColOrdenPreparacion.Width = 165;
            // 
            // ColProducto
            // 
            ColProducto.Text = "Producto";
            ColProducto.Width = 190;
            // 
            // ColCantidad
            // 
            ColCantidad.Text = "Cantidad";
            ColCantidad.Width = 75;
            // 
            // lblEmpresaTransportista
            // 
            lblEmpresaTransportista.Font = new Font("Segoe UI", 11F);
            lblEmpresaTransportista.Location = new Point(10, 50);
            lblEmpresaTransportista.Name = "lblEmpresaTransportista";
            lblEmpresaTransportista.Size = new Size(155, 23);
            lblEmpresaTransportista.TabIndex = 0;
            lblEmpresaTransportista.Text = "Empresa transportista";
            lblEmpresaTransportista.TextAlign = ContentAlignment.MiddleRight;
            lblEmpresaTransportista.Click += lblEmpresaTransportista_Click;
            // 
            // lblDni
            // 
            lblDni.Font = new Font("Segoe UI", 11F);
            lblDni.Location = new Point(10, 150);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(151, 23);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI";
            lblDni.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblChofer
            // 
            lblChofer.Font = new Font("Segoe UI", 11F);
            lblChofer.Location = new Point(10, 100);
            lblChofer.Name = "lblChofer";
            lblChofer.Size = new Size(151, 23);
            lblChofer.TabIndex = 1;
            lblChofer.Text = "Chofer";
            lblChofer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPatente
            // 
            lblPatente.Font = new Font("Segoe UI", 11F);
            lblPatente.Location = new Point(10, 204);
            lblPatente.Name = "lblPatente";
            lblPatente.Size = new Size(151, 23);
            lblPatente.TabIndex = 2;
            lblPatente.Text = "Patente";
            lblPatente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(176, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(337, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(176, 96);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(337, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(176, 146);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(337, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(176, 200);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(337, 27);
            textBox4.TabIndex = 6;
            // 
            // FrmGenerarRemitoDespachar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 662);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(btnConfirmarDespacho);
            Controls.Add(grpOrdenesPendientes);
            MinimumSize = new Size(1100, 650);
            Name = "FrmGenerarRemitoDespachar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar remito y despachar";
            WindowState = FormWindowState.Maximized;
            grpOrdenesPendientes.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOrdenesPendientes;
        private Button btnConfirmarDespacho;
        private Button button1;
        private ListView lvwOrdenes;
        private ColumnHeader ColNroOrden;
        private ColumnHeader ColCliente;
        private ColumnHeader ColBultos;
        private ColumnHeader ColDarsena;
        private ColumnHeader ColFechaPreparación;
        private ColumnHeader ColDomicilio;
        private ColumnHeader ColPeso;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListView lvwDetalle;
        private ColumnHeader ColOrdenPreparacion;
        private ColumnHeader ColProducto;
        private ColumnHeader ColCantidad;
        private Label lblPatente;
        private Label lblChofer;
        private Label lblDni;
        private Label lblEmpresaTransportista;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
