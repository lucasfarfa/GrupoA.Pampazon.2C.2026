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
            groupBoxFiltros = new GroupBox();
            lblCliente = new Label();
            txtCliente = new TextBox();
            lblFechaDesde = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            lblModalidad = new Label();
            txtModalidad = new TextBox();
            btnBuscar = new Button();
            groupBox1 = new GroupBox();
            OPPendientesListView = new ListView();
            NumeroOpCol = new ColumnHeader();
            ClienteCol = new ColumnHeader();
            FechaRecepCol = new ColumnHeader();
            FechaEntregaCol = new ColumnHeader();
            ModalidadCol = new ColumnHeader();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnAgregarTodo = new Button();
            btnQuitarTodo = new Button();
            groupBox2 = new GroupBox();
            listViewResumen = new ListView();
            colResSku = new ColumnHeader();
            colResDescripcion = new ColumnHeader();
            colResCantidad = new ColumnHeader();
            groupBoxPosiciones = new GroupBox();
            listViewPosiciones = new ListView();
            colPosSku = new ColumnHeader();
            colPosUbicacion = new ColumnHeader();
            colPosCantidad = new ColumnHeader();
            GenerarOSBtn = new Button();
            CencelarBtn = new Button();
            groupBoxFiltros.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBoxPosiciones.SuspendLayout();
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
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(lblCliente);
            groupBoxFiltros.Controls.Add(txtCliente);
            groupBoxFiltros.Controls.Add(lblFechaDesde);
            groupBoxFiltros.Controls.Add(dtpFechaDesde);
            groupBoxFiltros.Controls.Add(lblFechaHasta);
            groupBoxFiltros.Controls.Add(dtpFechaHasta);
            groupBoxFiltros.Controls.Add(lblModalidad);
            groupBoxFiltros.Controls.Add(txtModalidad);
            groupBoxFiltros.Controls.Add(btnBuscar);
            groupBoxFiltros.Location = new Point(12, 42);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(1112, 68);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de búsqueda (Miles de OP)";
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
            // txtCliente
            // 
            txtCliente.Location = new Point(65, 23);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(160, 23);
            txtCliente.TabIndex = 1;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(245, 26);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(72, 15);
            lblFechaDesde.TabIndex = 2;
            lblFechaDesde.Text = "Fecha Desde";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(323, 23);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(110, 23);
            dtpFechaDesde.TabIndex = 3;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(452, 26);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(70, 15);
            lblFechaHasta.TabIndex = 4;
            lblFechaHasta.Text = "Fecha Hasta";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(528, 23);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(110, 23);
            dtpFechaHasta.TabIndex = 5;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(655, 26);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(64, 15);
            lblModalidad.TabIndex = 6;
            lblModalidad.Text = "Modalidad";
            // 
            // txtModalidad
            // 
            txtModalidad.Location = new Point(725, 23);
            txtModalidad.Name = "txtModalidad";
            txtModalidad.Size = new Size(150, 23);
            txtModalidad.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(895, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 26);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Filtrar / Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(OPPendientesListView);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(btnQuitar);
            groupBox1.Controls.Add(btnAgregarTodo);
            groupBox1.Controls.Add(btnQuitarTodo);
            groupBox1.Location = new Point(12, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1112, 200);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Órdenes de Preparación Pendientes";
            // 
            // OPPendientesListView
            // 
            OPPendientesListView.CheckBoxes = true;
            OPPendientesListView.Columns.AddRange(new ColumnHeader[] { NumeroOpCol, ClienteCol, FechaRecepCol, FechaEntregaCol, ModalidadCol });
            OPPendientesListView.FullRowSelect = true;
            OPPendientesListView.GridLines = true;
            OPPendientesListView.Location = new Point(15, 24);
            OPPendientesListView.Name = "OPPendientesListView";
            OPPendientesListView.Size = new Size(650, 130);
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
            // FechaRecepCol
            // 
            FechaRecepCol.Text = "Fecha Recepción";
            FechaRecepCol.Width = 130;
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
            // btnAgregar
            // 
            btnAgregar.Location = new Point(685, 24);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 30);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar Seleccionadas";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(685, 65);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(140, 30);
            btnQuitar.TabIndex = 2;
            btnQuitar.Text = "Quitar Seleccionadas";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarTodo
            // 
            btnAgregarTodo.Location = new Point(685, 106);
            btnAgregarTodo.Name = "btnAgregarTodo";
            btnAgregarTodo.Size = new Size(140, 30);
            btnAgregarTodo.TabIndex = 3;
            btnAgregarTodo.Text = "Agregar Todo";
            btnAgregarTodo.UseVisualStyleBackColor = true;
            // 
            // btnQuitarTodo
            // 
            btnQuitarTodo.Location = new Point(685, 147);
            btnQuitarTodo.Name = "btnQuitarTodo";
            btnQuitarTodo.Size = new Size(140, 30);
            btnQuitarTodo.TabIndex = 4;
            btnQuitarTodo.Text = "Quitar Todo";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listViewResumen);
            groupBox2.Location = new Point(12, 322);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(550, 230);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resumen consolidado de Productos (Sin posición fija)";
            // 
            // listViewResumen
            // 
            listViewResumen.Columns.AddRange(new ColumnHeader[] { colResSku, colResDescripcion, colResCantidad });
            listViewResumen.FullRowSelect = true;
            listViewResumen.GridLines = true;
            listViewResumen.Location = new Point(15, 24);
            listViewResumen.Name = "listViewResumen";
            listViewResumen.Size = new Size(520, 190);
            listViewResumen.TabIndex = 0;
            listViewResumen.UseCompatibleStateImageBehavior = false;
            listViewResumen.View = View.Details;
            // 
            // colResSku
            // 
            colResSku.Text = "SKU";
            colResSku.Width = 110;
            // 
            // colResDescripcion
            // 
            colResDescripcion.Text = "Descripción";
            colResDescripcion.Width = 270;
            // 
            // colResCantidad
            // 
            colResCantidad.Text = "Cantidad Total";
            colResCantidad.Width = 120;
            // 
            // groupBoxPosiciones
            // 
            groupBoxPosiciones.Controls.Add(listViewPosiciones);
            groupBoxPosiciones.Location = new Point(574, 322);
            groupBoxPosiciones.Name = "groupBoxPosiciones";
            groupBoxPosiciones.Size = new Size(550, 230);
            groupBoxPosiciones.TabIndex = 5;
            groupBoxPosiciones.TabStop = false;
            groupBoxPosiciones.Text = "3ra Grilla: Desglose por Posición (Ubicaciones del SKU seleccionado)";
            // 
            // listViewPosiciones
            // 
            listViewPosiciones.Columns.AddRange(new ColumnHeader[] { colPosSku, colPosUbicacion, colPosCantidad });
            listViewPosiciones.FullRowSelect = true;
            listViewPosiciones.GridLines = true;
            listViewPosiciones.Location = new Point(15, 24);
            listViewPosiciones.Name = "listViewPosiciones";
            listViewPosiciones.Size = new Size(520, 190);
            listViewPosiciones.TabIndex = 0;
            listViewPosiciones.UseCompatibleStateImageBehavior = false;
            listViewPosiciones.View = View.Details;
            // 
            // colPosSku
            // 
            colPosSku.Text = "SKU";
            colPosSku.Width = 110;
            // 
            // colPosUbicacion
            // 
            colPosUbicacion.Text = "Posición (XYZ)";
            colPosUbicacion.Width = 270;
            // 
            // colPosCantidad
            // 
            colPosCantidad.Text = "Cantidad";
            colPosCantidad.Width = 120;
            // 
            // GenerarOSBtn
            // 
            GenerarOSBtn.Location = new Point(882, 565);
            GenerarOSBtn.Name = "GenerarOSBtn";
            GenerarOSBtn.Size = new Size(242, 36);
            GenerarOSBtn.TabIndex = 6;
            GenerarOSBtn.Text = "Generar Orden de Selección";
            GenerarOSBtn.UseVisualStyleBackColor = true;
            // 
            // CencelarBtn
            // 
            CencelarBtn.Location = new Point(776, 565);
            CencelarBtn.Name = "CencelarBtn";
            CencelarBtn.Size = new Size(100, 36);
            CencelarBtn.TabIndex = 7;
            CencelarBtn.Text = "Cancelar";
            CencelarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOrdenSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CencelarBtn;
            ClientSize = new Size(1136, 613);
            Controls.Add(CencelarBtn);
            Controls.Add(GenerarOSBtn);
            Controls.Add(groupBoxPosiciones);
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
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBoxPosiciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label DepositoLbl;
        private GroupBox groupBoxFiltros;
        private Label lblCliente;
        private TextBox txtCliente;
        private Label lblFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label lblFechaHasta;
        private DateTimePicker dtpFechaHasta;
        private Label lblModalidad;
        private TextBox txtModalidad;
        private Button btnBuscar;
        private GroupBox groupBox1;
        private ListView OPPendientesListView;
        private ColumnHeader NumeroOpCol;
        private ColumnHeader ClienteCol;
        private ColumnHeader FechaRecepCol;
        private ColumnHeader FechaEntregaCol;
        private ColumnHeader ModalidadCol;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnAgregarTodo;
        private Button btnQuitarTodo;
        private GroupBox groupBox2;
        private ListView listViewResumen;
        private ColumnHeader colResSku;
        private ColumnHeader colResDescripcion;
        private ColumnHeader colResCantidad;
        private GroupBox groupBoxPosiciones;
        private ListView listViewPosiciones;
        private ColumnHeader colPosSku;
        private ColumnHeader colPosUbicacion;
        private ColumnHeader colPosCantidad;
        private Button GenerarOSBtn;
        private Button CencelarBtn;
    }
}