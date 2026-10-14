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
            colResCantidad = new ColumnHeader();
            GenerarOSBtn = new Button();
            CencelarBtn = new Button();
            groupBoxFiltros.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Depósito:";
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(86, 20);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(87, 20);
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
            groupBoxFiltros.Location = new Point(14, 56);
            groupBoxFiltros.Margin = new Padding(3, 4, 3, 4);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Padding = new Padding(3, 4, 3, 4);
            groupBoxFiltros.Size = new Size(1271, 91);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de búsqueda ";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(17, 35);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(74, 31);
            txtCliente.Margin = new Padding(3, 4, 3, 4);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(182, 27);
            txtCliente.TabIndex = 1;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(270, 35);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(93, 20);
            lblFechaDesde.TabIndex = 2;
            lblFechaDesde.Text = "Fecha Desde";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(369, 31);
            dtpFechaDesde.Margin = new Padding(3, 4, 3, 4);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(125, 27);
            dtpFechaDesde.TabIndex = 3;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(508, 35);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(89, 20);
            lblFechaHasta.TabIndex = 4;
            lblFechaHasta.Text = "Fecha Hasta";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(603, 31);
            dtpFechaHasta.Margin = new Padding(3, 4, 3, 4);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(125, 27);
            dtpFechaHasta.TabIndex = 5;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(749, 35);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(82, 20);
            lblModalidad.TabIndex = 6;
            lblModalidad.Text = "Modalidad";
            // 
            // txtModalidad
            // 
            txtModalidad.Location = new Point(829, 31);
            txtModalidad.Margin = new Padding(3, 4, 3, 4);
            txtModalidad.Name = "txtModalidad";
            txtModalidad.Size = new Size(171, 27);
            txtModalidad.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(1023, 28);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(114, 35);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Filtrar / Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(OPPendientesListView);
            groupBox1.Controls.Add(btnAgregarTodo);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(btnQuitar);
            groupBox1.Controls.Add(btnQuitarTodo);
            groupBox1.Location = new Point(14, 155);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1271, 267);
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
            OPPendientesListView.Location = new Point(17, 32);
            OPPendientesListView.Margin = new Padding(3, 4, 3, 4);
            OPPendientesListView.Name = "OPPendientesListView";
            OPPendientesListView.Size = new Size(983, 212);
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
            btnAgregar.Location = new Point(1032, 32);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(217, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar Seleccionadas";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(1032, 90);
            btnQuitar.Margin = new Padding(3, 4, 3, 4);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(217, 40);
            btnQuitar.TabIndex = 2;
            btnQuitar.Text = "Quitar Seleccionadas";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarTodo
            // 
            btnAgregarTodo.Location = new Point(1032, 147);
            btnAgregarTodo.Margin = new Padding(3, 4, 3, 4);
            btnAgregarTodo.Name = "btnAgregarTodo";
            btnAgregarTodo.Size = new Size(217, 40);
            btnAgregarTodo.TabIndex = 3;
            btnAgregarTodo.Text = "Agregar Todo";
            btnAgregarTodo.UseVisualStyleBackColor = true;
            // 
            // btnQuitarTodo
            // 
            btnQuitarTodo.Location = new Point(1032, 204);
            btnQuitarTodo.Margin = new Padding(3, 4, 3, 4);
            btnQuitarTodo.Name = "btnQuitarTodo";
            btnQuitarTodo.Size = new Size(217, 40);
            btnQuitarTodo.TabIndex = 4;
            btnQuitarTodo.Text = "Quitar Todo";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listViewResumen);
            groupBox2.Location = new Point(14, 429);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1271, 307);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resumen consolidado de Productos";
            // 
            // listViewResumen
            // 
            listViewResumen.Columns.AddRange(new ColumnHeader[] { colResSku, colResCantidad });
            listViewResumen.FullRowSelect = true;
            listViewResumen.GridLines = true;
            listViewResumen.Location = new Point(17, 28);
            listViewResumen.Margin = new Padding(3, 4, 3, 4);
            listViewResumen.Name = "listViewResumen";
            listViewResumen.Size = new Size(1232, 252);
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
            GenerarOSBtn.Location = new Point(888, 756);
            GenerarOSBtn.Margin = new Padding(3, 4, 3, 4);
            GenerarOSBtn.Name = "GenerarOSBtn";
            GenerarOSBtn.Size = new Size(277, 48);
            GenerarOSBtn.TabIndex = 6;
            GenerarOSBtn.Text = "Generar Orden de Selección";
            GenerarOSBtn.UseVisualStyleBackColor = true;
            // 
            // CencelarBtn
            // 
            CencelarBtn.Location = new Point(1171, 756);
            CencelarBtn.Margin = new Padding(3, 4, 3, 4);
            CencelarBtn.Name = "CencelarBtn";
            CencelarBtn.Size = new Size(114, 48);
            CencelarBtn.TabIndex = 7;
            CencelarBtn.Text = "Cancelar";
            CencelarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOrdenSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CencelarBtn;
            ClientSize = new Size(1298, 817);
            Controls.Add(CencelarBtn);
            Controls.Add(GenerarOSBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxFiltros);
            Controls.Add(DepositoLbl);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarOrdenSeleccionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar Orden de Selección";
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
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
        private ColumnHeader colResCantidad;
        private Button GenerarOSBtn;
        private Button CencelarBtn;
    }
}