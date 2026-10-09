namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    partial class PrepararProductosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTituloOS = new Label();
            listViewProductos = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btnIniciarPicking = new Button();
            lblTituloOP = new Label();
            listViewOP = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            btnFinalizarPicking = new Button();
            btnCierreSeleccion = new Button();
            listViewOS = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            btnRefrescar = new Button();
            lblTituloNoHayOS = new Label();
            SuspendLayout();
            // 
            // lblTituloOS
            // 
            lblTituloOS.AutoSize = true;
            lblTituloOS.Location = new Point(12, 9);
            lblTituloOS.Name = "lblTituloOS";
            lblTituloOS.Size = new Size(182, 25);
            lblTituloOS.TabIndex = 0;
            lblTituloOS.Text = "Ordenes de Selección";
            // 
            // listViewProductos
            // 
            listViewProductos.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listViewProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewProductos.Location = new Point(665, 335);
            listViewProductos.MultiSelect = false;
            listViewProductos.Name = "listViewProductos";
            listViewProductos.Size = new Size(616, 379);
            listViewProductos.TabIndex = 3;
            listViewProductos.UseCompatibleStateImageBehavior = false;
            listViewProductos.View = View.Details;
            listViewProductos.SelectedIndexChanged += listViewProductos_SelectedIndexChanged;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "SKU";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Descripción";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Cantidad";
            columnHeader6.TextAlign = HorizontalAlignment.Right;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Posición en Racks";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // btnIniciarPicking
            // 
            btnIniciarPicking.Enabled = false;
            btnIniciarPicking.Location = new Point(665, 720);
            btnIniciarPicking.Name = "btnIniciarPicking";
            btnIniciarPicking.Size = new Size(158, 34);
            btnIniciarPicking.TabIndex = 5;
            btnIniciarPicking.Text = "Iniciar Picking";
            btnIniciarPicking.UseVisualStyleBackColor = true;
            btnIniciarPicking.Click += btnIniciarPicking_Click;
            // 
            // lblTituloOP
            // 
            lblTituloOP.AutoSize = true;
            lblTituloOP.Location = new Point(13, 307);
            lblTituloOP.Name = "lblTituloOP";
            lblTituloOP.Size = new Size(477, 25);
            lblTituloOP.TabIndex = 0;
            lblTituloOP.Text = "Ordenes de preparación vinculadas a la orden de Selección";
            // 
            // listViewOP
            // 
            listViewOP.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader8 });
            listViewOP.Location = new Point(13, 335);
            listViewOP.MultiSelect = false;
            listViewOP.Name = "listViewOP";
            listViewOP.Size = new Size(646, 379);
            listViewOP.TabIndex = 6;
            listViewOP.UseCompatibleStateImageBehavior = false;
            listViewOP.View = View.Details;
            listViewOP.SelectedIndexChanged += listViewOP_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nro Orden";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Fecha/Hora";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Estado";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            // 
            // btnFinalizarPicking
            // 
            btnFinalizarPicking.Enabled = false;
            btnFinalizarPicking.Location = new Point(1123, 720);
            btnFinalizarPicking.Name = "btnFinalizarPicking";
            btnFinalizarPicking.Size = new Size(158, 34);
            btnFinalizarPicking.TabIndex = 5;
            btnFinalizarPicking.Text = "Finalizar Picking";
            btnFinalizarPicking.UseVisualStyleBackColor = true;
            btnFinalizarPicking.Click += btnFinalizarPicking_Click;
            // 
            // btnCierreSeleccion
            // 
            btnCierreSeleccion.Enabled = false;
            btnCierreSeleccion.Location = new Point(13, 224);
            btnCierreSeleccion.Name = "btnCierreSeleccion";
            btnCierreSeleccion.Size = new Size(304, 34);
            btnCierreSeleccion.TabIndex = 8;
            btnCierreSeleccion.Text = "Cerrar Orden de Selección";
            btnCierreSeleccion.UseVisualStyleBackColor = true;
            btnCierreSeleccion.Click += btnCierreSeleccion_Click;
            // 
            // listViewOS
            // 
            listViewOS.Columns.AddRange(new ColumnHeader[] { columnHeader9, columnHeader10, columnHeader11 });
            listViewOS.Location = new Point(12, 37);
            listViewOS.Name = "listViewOS";
            listViewOS.Size = new Size(1268, 181);
            listViewOS.TabIndex = 9;
            listViewOS.UseCompatibleStateImageBehavior = false;
            listViewOS.View = View.Details;
            listViewOS.SelectedIndexChanged += listViewOS_SelectedIndexChanged;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Nro Orden";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Fecha/Hora";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Estado";
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(928, 224);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(352, 34);
            btnRefrescar.TabIndex = 10;
            btnRefrescar.Text = "Refrescar Lista de Ordenes de Selección";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // lblTituloNoHayOS
            // 
            lblTituloNoHayOS.AutoSize = true;
            lblTituloNoHayOS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloNoHayOS.ForeColor = Color.DodgerBlue;
            lblTituloNoHayOS.Location = new Point(869, 9);
            lblTituloNoHayOS.Name = "lblTituloNoHayOS";
            lblTituloNoHayOS.Size = new Size(411, 25);
            lblTituloNoHayOS.TabIndex = 0;
            lblTituloNoHayOS.Text = "NO HAY ORDENES DE SELECCION PENDIENTES";
            lblTituloNoHayOS.Visible = false;
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 767);
            Controls.Add(btnRefrescar);
            Controls.Add(listViewOS);
            Controls.Add(btnCierreSeleccion);
            Controls.Add(listViewOP);
            Controls.Add(btnFinalizarPicking);
            Controls.Add(btnIniciarPicking);
            Controls.Add(listViewProductos);
            Controls.Add(lblTituloOP);
            Controls.Add(lblTituloNoHayOS);
            Controls.Add(lblTituloOS);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrepararProductosForm";
            Text = "Preparar Productos";
            Load += PrepararProductosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloOS;

        private void PrepararProductosForm_Load(object sender, EventArgs e)
        {

            listViewOS.View = View.Details;
            listViewOS.FullRowSelect = true;
            listViewOS.GridLines = true;

            listViewOP.View = View.Details;
            listViewOP.FullRowSelect = true;
            listViewOP.GridLines = true;
            
            listViewProductos.View = View.Details;
            listViewProductos.FullRowSelect = true;
            listViewProductos.GridLines = true;

            AjustarColumnasFormulario();

            // Inicializar modelo y bindear datos
            InitializeModelBindings();

        }


        private ListView listViewProductos;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button btnIniciarPicking;
        private Label lblTituloOP;
        private ListView listViewOP;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btnFinalizarPicking;
        private ColumnHeader columnHeader8;
        private Button btnCierreSeleccion;
        private ListView listViewOS;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private Button btnRefrescar;
        private Label lblTituloNoHayOS;
    }
}