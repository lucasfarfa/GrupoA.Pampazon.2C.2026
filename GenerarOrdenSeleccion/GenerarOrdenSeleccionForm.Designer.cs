namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    partial class GenerarOrdenSeleccionForm
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
            label1 = new Label();
            DepositoLbl = new Label();
            groupBox1 = new GroupBox();
            OPPendientesListView = new ListView();
            NumeroOpCol = new ColumnHeader();
            ClienteCol = new ColumnHeader();
            FechaEntregaCol = new ColumnHeader();
            ModalidadCol = new ColumnHeader();
            btnAgregarTodo = new Button();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnQuitarTodo = new Button();
            groupBox2 = new GroupBox();
            listViewResumen = new ListView();
            colResSku = new ColumnHeader();
            colResCantidad = new ColumnHeader();
            GenerarOSBtn = new Button();
            CencelarBtn = new Button();
            btnBuscar = new Button();
            lblModalidad = new Label();
            dtpFechaHasta = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaDesde = new Label();
            txtCliente = new TextBox();
            lblCliente = new Label();
            comboModalidad = new ComboBox();
            btnLimpiarFiltros = new Button();
            groupBoxFiltros = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBoxFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Depósito:";
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(75, 15);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(69, 15);
            DepositoLbl.TabIndex = 1;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(OPPendientesListView);
            groupBox1.Controls.Add(btnAgregarTodo);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(btnQuitar);
            groupBox1.Controls.Add(btnQuitarTodo);
            groupBox1.Location = new Point(13, 130);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1112, 200);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Órdenes de Preparación Pendientes";
            // 
            // OPPendientesListView
            // 
            OPPendientesListView.CheckBoxes = true;
            OPPendientesListView.Columns.AddRange(new ColumnHeader[] { NumeroOpCol, ClienteCol, FechaEntregaCol, ModalidadCol });
            OPPendientesListView.FullRowSelect = true;
            OPPendientesListView.GridLines = true;
            OPPendientesListView.Location = new Point(15, 24);
            OPPendientesListView.Name = "OPPendientesListView";
            OPPendientesListView.Size = new Size(553, 160);
            OPPendientesListView.TabIndex = 0;
            OPPendientesListView.UseCompatibleStateImageBehavior = false;
            OPPendientesListView.View = View.Details;
            // 
            // NumeroOpCol
            // 
            NumeroOpCol.Text = "N° OP";
            NumeroOpCol.Width = 90;
            // 
            // ClienteCol
            // 
            ClienteCol.Text = "Cliente";
            ClienteCol.Width = 150;
            // 
            // FechaEntregaCol
            // 
            FechaEntregaCol.Text = "Fecha Entrega";
            FechaEntregaCol.Width = 130;
            // 
            // ModalidadCol
            // 
            ModalidadCol.Text = "Modalidad";
            ModalidadCol.Width = 130;
            // 
            // btnAgregarTodo
            // 
            btnAgregarTodo.Location = new Point(586, 110);
            btnAgregarTodo.Name = "btnAgregarTodo";
            btnAgregarTodo.Size = new Size(507, 30);
            btnAgregarTodo.TabIndex = 3;
            btnAgregarTodo.Text = "Agregar Todo";
            btnAgregarTodo.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(586, 24);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(507, 30);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar Seleccionadas";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(586, 68);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(507, 30);
            btnQuitar.TabIndex = 2;
            btnQuitar.Text = "Quitar Seleccionadas";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnQuitarTodo
            // 
            btnQuitarTodo.Location = new Point(586, 153);
            btnQuitarTodo.Name = "btnQuitarTodo";
            btnQuitarTodo.Size = new Size(507, 30);
            btnQuitarTodo.TabIndex = 4;
            btnQuitarTodo.Text = "Quitar Todo";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listViewResumen);
            groupBox2.Location = new Point(12, 331);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1112, 230);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resumen consolidado de Productos";
            // 
            // listViewResumen
            // 
            listViewResumen.Columns.AddRange(new ColumnHeader[] { colResSku, colResCantidad });
            listViewResumen.FullRowSelect = true;
            listViewResumen.GridLines = true;
            listViewResumen.Location = new Point(15, 21);
            listViewResumen.Name = "listViewResumen";
            listViewResumen.Size = new Size(1078, 190);
            listViewResumen.TabIndex = 0;
            listViewResumen.UseCompatibleStateImageBehavior = false;
            listViewResumen.View = View.Details;
            // 
            // colResSku
            // 
            colResSku.Text = "SKU";
            colResSku.Width = 110;
            // 
            // colResCantidad
            // 
            colResCantidad.Text = "Cantidad Total";
            colResCantidad.Width = 120;
            // 
            // GenerarOSBtn
            // 
            GenerarOSBtn.Location = new Point(777, 567);
            GenerarOSBtn.Name = "GenerarOSBtn";
            GenerarOSBtn.Size = new Size(242, 36);
            GenerarOSBtn.TabIndex = 6;
            GenerarOSBtn.Text = "Generar Orden de Selección";
            GenerarOSBtn.UseVisualStyleBackColor = true;
            // 
            // CencelarBtn
            // 
            CencelarBtn.Location = new Point(1025, 567);
            CencelarBtn.Name = "CencelarBtn";
            CencelarBtn.Size = new Size(100, 36);
            CencelarBtn.TabIndex = 7;
            CencelarBtn.Text = "Cancelar";
            CencelarBtn.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(916, 17);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(182, 26);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(536, 26);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(67, 15);
            lblModalidad.TabIndex = 6;
            lblModalidad.Text = "Modalidad:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(323, 50);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.ShowCheckBox = true;
            dtpFechaHasta.Size = new Size(110, 23);
            dtpFechaHasta.TabIndex = 5;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(236, 51);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(71, 15);
            lblFechaHasta.TabIndex = 4;
            lblFechaHasta.Text = "Fecha Hasta";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(323, 23);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.ShowCheckBox = true;
            dtpFechaDesde.Size = new Size(110, 23);
            dtpFechaDesde.TabIndex = 3;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(236, 26);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(73, 15);
            lblFechaDesde.TabIndex = 2;
            lblFechaDesde.Text = "Fecha Desde";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(15, 44);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(160, 23);
            txtCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(15, 26);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // comboModalidad
            // 
            comboModalidad.FormattingEnabled = true;
            comboModalidad.Items.AddRange(new object[] { "Fullfilment", "Palet cerrado" });
            comboModalidad.Location = new Point(628, 23);
            comboModalidad.Margin = new Padding(3, 2, 3, 2);
            comboModalidad.Name = "comboModalidad";
            comboModalidad.Size = new Size(179, 23);
            comboModalidad.TabIndex = 10;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(916, 48);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(182, 26);
            btnLimpiarFiltros.TabIndex = 12;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(btnLimpiarFiltros);
            groupBoxFiltros.Controls.Add(comboModalidad);
            groupBoxFiltros.Controls.Add(lblCliente);
            groupBoxFiltros.Controls.Add(txtCliente);
            groupBoxFiltros.Controls.Add(lblFechaDesde);
            groupBoxFiltros.Controls.Add(dtpFechaDesde);
            groupBoxFiltros.Controls.Add(lblFechaHasta);
            groupBoxFiltros.Controls.Add(dtpFechaHasta);
            groupBoxFiltros.Controls.Add(lblModalidad);
            groupBoxFiltros.Controls.Add(btnBuscar);
            groupBoxFiltros.Location = new Point(12, 42);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(1112, 82);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de búsqueda ";
            // 
            // GenerarOrdenSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CencelarBtn;
            ClientSize = new Size(1136, 613);
            Controls.Add(CencelarBtn);
            Controls.Add(GenerarOSBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxFiltros);
            Controls.Add(DepositoLbl);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarOrdenSeleccionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar Orden de Selección";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label DepositoLbl;
        private GroupBox groupBox1;
        private ListView OPPendientesListView;
        private ColumnHeader NumeroOpCol;
        private ColumnHeader ClienteCol;
        private ColumnHeader FechaEntregaCol;
        private ColumnHeader ModalidadCol;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnAgregarTodo;
        private Button btnQuitarTodo;
        private GroupBox groupBox2;
        private ListView listViewResumen;
        private ColumnHeader colResSku;
        private ColumnHeader colResCantidad;
        private Button GenerarOSBtn;
        private Button CencelarBtn;
        private Button btnBuscar;
        private Label lblModalidad;
        private DateTimePicker dtpFechaHasta;
        private Label lblFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private Label lblFechaDesde;
        private TextBox txtCliente;
        private Label lblCliente;
        private ComboBox comboModalidad;
        private Button btnLimpiarFiltros;
        private GroupBox groupBoxFiltros;
    }
}