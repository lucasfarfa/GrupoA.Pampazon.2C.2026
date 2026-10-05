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
            listView2 = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btnIniciarFulFillment = new Button();
            label2 = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            btnFinalizarFulFillment = new Button();
            label3 = new Label();
            btnCierreSeleccion = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(842, 25);
            label1.TabIndex = 0;
            label1.Text = "Orden de Selección En Procesamiento <XXXXXXX>, incluye XXX Ordenes de Preparación de XXX Clientes";
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView2.Location = new Point(799, 83);
            listView2.MultiSelect = false;
            listView2.Name = "listView2";
            listView2.Size = new Size(836, 492);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
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
            // btnIniciarFulFillment
            // 
            btnIniciarFulFillment.Enabled = false;
            btnIniciarFulFillment.Location = new Point(799, 581);
            btnIniciarFulFillment.Name = "btnIniciarFulFillment";
            btnIniciarFulFillment.Size = new Size(251, 34);
            btnIniciarFulFillment.TabIndex = 5;
            btnIniciarFulFillment.Text = "Iniciar FulFillment";
            btnIniciarFulFillment.UseVisualStyleBackColor = true;
            btnIniciarFulFillment.Click += btnIniciarFulFillment_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(477, 25);
            label2.TabIndex = 0;
            label2.Text = "Ordenes de preparación vinculadas a la orden de Selección";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader8 });
            listView1.Location = new Point(12, 83);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(749, 492);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
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
            // btnFinalizarFulFillment
            // 
            btnFinalizarFulFillment.Enabled = false;
            btnFinalizarFulFillment.Location = new Point(1359, 581);
            btnFinalizarFulFillment.Name = "btnFinalizarFulFillment";
            btnFinalizarFulFillment.Size = new Size(276, 34);
            btnFinalizarFulFillment.TabIndex = 5;
            btnFinalizarFulFillment.Text = "Finalizar FulFillment (nueva OE)";
            btnFinalizarFulFillment.UseVisualStyleBackColor = true;
            btnFinalizarFulFillment.Click += cmdFinalizarFulFillment_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 663);
            label3.Name = "label3";
            label3.Size = new Size(762, 25);
            label3.TabIndex = 7;
            label3.Text = "(*) Una vez cerrados todas las operaciones de FulFillment se podra cerrar la Orden de Selección";
            // 
            // btnCierreSeleccion
            // 
            btnCierreSeleccion.Enabled = false;
            btnCierreSeleccion.Location = new Point(425, 705);
            btnCierreSeleccion.Name = "btnCierreSeleccion";
            btnCierreSeleccion.Size = new Size(762, 34);
            btnCierreSeleccion.TabIndex = 8;
            btnCierreSeleccion.Text = "Cerrar Orden de Selección";
            btnCierreSeleccion.UseVisualStyleBackColor = true;
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1650, 757);
            Controls.Add(btnCierreSeleccion);
            Controls.Add(label3);
            Controls.Add(listView1);
            Controls.Add(btnFinalizarFulFillment);
            Controls.Add(btnIniciarFulFillment);
            Controls.Add(listView2);
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
            listView1.View = View.Details;
            listView1.FullRowSelect = true; // Selecciona toda la fila al hacer clic
            listView1.GridLines = true;     // Muestra líneas de división

            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000002", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000003", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000004", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000005", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000006", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000007", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000008", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));
            listView1.Items.Add(new ListViewItem(new string[] { "OS-0000001", "Luis Pérez", "2026-01-01 10:00:00", "PENDIENTE" }));

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;

            AjustarColumnasFormulario();

            btnIniciarFulFillment.Enabled = false;
            btnFinalizarFulFillment.Enabled = false;
            btnCierreSeleccion.Enabled = false;

        }

        private void SeleccionarTodasLasOrdenesPendientes()
        {
            // Enfoca el ListView para que los elementos seleccionados se resalten visualmente
            listView1.Focus();

            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = true;
            }
        }

        private void LimpiarSeleccionDeOrdenesPendientes()
        {
            listView1.SelectedItems.Clear();
        }

        private ListView listView2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button btnIniciarFulFillment;
        private Label label2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btnFinalizarFulFillment;
        private ColumnHeader columnHeader8;
        private Label label3;
        private Button btnCierreSeleccion;
    }
}