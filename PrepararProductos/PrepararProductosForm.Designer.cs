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
            label1 = new Label();
            listViewProductos = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btnIniciarPicking = new Button();
            label2 = new Label();
            listViewOP = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            btnFinalizarPicking = new Button();
            label3 = new Label();
            btnCierreSeleccion = new Button();
            listViewOS = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(182, 25);
            label1.TabIndex = 0;
            label1.Text = "Ordenes de Selección";
            // 
            // listViewProductos
            // 
            listViewProductos.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listViewProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewProductos.Location = new Point(799, 309);
            listViewProductos.MultiSelect = false;
            listViewProductos.Name = "listViewProductos";
            listViewProductos.Size = new Size(836, 379);
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
            btnIniciarPicking.Location = new Point(799, 694);
            btnIniciarPicking.Name = "btnIniciarPicking";
            btnIniciarPicking.Size = new Size(251, 34);
            btnIniciarPicking.TabIndex = 5;
            btnIniciarPicking.Text = "Iniciar Picking";
            btnIniciarPicking.UseVisualStyleBackColor = true;
            btnIniciarPicking.Click += btnIniciarFulFillment_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 281);
            label2.Name = "label2";
            label2.Size = new Size(477, 25);
            label2.TabIndex = 0;
            label2.Text = "Ordenes de preparación vinculadas a la orden de Selección";
            // 
            // listViewOP
            // 
            listViewOP.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader8 });
            listViewOP.Location = new Point(12, 309);
            listViewOP.MultiSelect = false;
            listViewOP.Name = "listViewOP";
            listViewOP.Size = new Size(749, 379);
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
            btnFinalizarPicking.Location = new Point(1359, 694);
            btnFinalizarPicking.Name = "btnFinalizarPicking";
            btnFinalizarPicking.Size = new Size(276, 34);
            btnFinalizarPicking.TabIndex = 5;
            btnFinalizarPicking.Text = "Finalizar Picking";
            btnFinalizarPicking.UseVisualStyleBackColor = true;
            btnFinalizarPicking.Click += cmdFinalizarFulFillment_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 776);
            label3.Name = "label3";
            label3.Size = new Size(762, 25);
            label3.TabIndex = 7;
            label3.Text = "(*) Una vez cerrados todas las operaciones de FulFillment se podra cerrar la Orden de Selección";
            // 
            // btnCierreSeleccion
            // 
            btnCierreSeleccion.Enabled = false;
            btnCierreSeleccion.Location = new Point(425, 818);
            btnCierreSeleccion.Name = "btnCierreSeleccion";
            btnCierreSeleccion.Size = new Size(762, 34);
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
            listViewOS.Size = new Size(1623, 181);
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
            // button1
            // 
            button1.Location = new Point(1283, 224);
            button1.Name = "button1";
            button1.Size = new Size(352, 34);
            button1.TabIndex = 10;
            button1.Text = "Refrescar Lista de Ordenes de Selección";
            button1.UseVisualStyleBackColor = true;
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1650, 871);
            Controls.Add(button1);
            Controls.Add(listViewOS);
            Controls.Add(btnCierreSeleccion);
            Controls.Add(label3);
            Controls.Add(listViewOP);
            Controls.Add(btnFinalizarPicking);
            Controls.Add(btnIniciarPicking);
            Controls.Add(listViewProductos);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrepararProductosForm";
            Text = "Preparar Productos";
            Load += PrepararProductosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;

        private void PrepararProductosForm_Load(object sender, EventArgs e)
        {

            listViewOS.View = View.Details;
            listViewOS.FullRowSelect = true;
            listViewOS.GridLines = true;
            listViewOS.Items.Add(new ListViewItem(new string[] { "OS-0000092", "2026-01-01 10:00:00", "PENDIENTE" }));
            listViewOS.Items.Add(new ListViewItem(new string[] { "OS-0000093", "2026-01-01 10:00:00", "PENDIENTE" }));

            listViewOP.View = View.Details;
            listViewOP.FullRowSelect = true;
            listViewOP.GridLines = true;
            
            listViewProductos.View = View.Details;
            listViewProductos.FullRowSelect = true;
            listViewProductos.GridLines = true;

            AjustarColumnasFormulario();

            btnIniciarPicking.Enabled = false;
            btnFinalizarPicking.Enabled = false;
            btnCierreSeleccion.Enabled = false;

        }

        private void SeleccionarTodasLasOrdenesPendientes()
        {
            // Enfoca el ListView para que los elementos seleccionados se resalten visualmente
            listViewOP.Focus();

            foreach (ListViewItem item in listViewOP.Items)
            {
                item.Selected = true;
            }
        }

        private void LimpiarSeleccionDeOrdenesPendientes()
        {
            listViewOP.SelectedItems.Clear();
        }

        private ListView listViewProductos;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button btnIniciarPicking;
        private Label label2;
        private ListView listViewOP;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btnFinalizarPicking;
        private ColumnHeader columnHeader8;
        private Label label3;
        private Button btnCierreSeleccion;
        private ListView listViewOS;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private Button button1;
    }
}