namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    partial class GenerarOrdenSeleccionForm
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
            ActualizarBtn = new Button();
            groupBox1 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            listView2 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            OPPendientesListView = new ListView();
            NumeroOpCol = new ColumnHeader();
            ClienteCol = new ColumnHeader();
            FechaRecepCol = new ColumnHeader();
            Fecha = new ColumnHeader();
            ModalidadCol = new ColumnHeader();
            groupBox2 = new GroupBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            CencelarBtn = new Button();
            GenerarOSBtn = new Button();
            DepositoLbl = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 1;
            label1.Text = "Depósito:";
            label1.Click += label1_Click;
            // 
            // ActualizarBtn
            // 
            ActualizarBtn.Location = new Point(519, 241);
            ActualizarBtn.Name = "ActualizarBtn";
            ActualizarBtn.Size = new Size(411, 37);
            ActualizarBtn.TabIndex = 2;
            ActualizarBtn.Text = "Actualizar Ordenes Pendientes";
            ActualizarBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(listView2);
            groupBox1.Controls.Add(ActualizarBtn);
            groupBox1.Controls.Add(OPPendientesListView);
            groupBox1.Location = new Point(12, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(936, 284);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes de Preparación Pendientes";
            // 
            // button2
            // 
            button2.Location = new Point(261, 241);
            button2.Name = "button2";
            button2.Size = new Size(252, 37);
            button2.TabIndex = 8;
            button2.Text = "Quitar Orden";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 241);
            button1.Name = "button1";
            button1.Size = new Size(249, 37);
            button1.TabIndex = 7;
            button1.Text = "Agregar Orden";
            button1.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            listView2.Location = new Point(519, 26);
            listView2.Name = "listView2";
            listView2.Size = new Size(409, 209);
            listView2.TabIndex = 6;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "SKU";
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Posición XYZ";
            columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Descripcion";
            columnHeader7.Width = 130;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Cantidad";
            columnHeader8.Width = 130;
            // 
            // OPPendientesListView
            // 
            OPPendientesListView.Columns.AddRange(new ColumnHeader[] { NumeroOpCol, ClienteCol, FechaRecepCol, Fecha, ModalidadCol });
            OPPendientesListView.Location = new Point(6, 26);
            OPPendientesListView.Name = "OPPendientesListView";
            OPPendientesListView.Size = new Size(507, 209);
            OPPendientesListView.TabIndex = 0;
            OPPendientesListView.UseCompatibleStateImageBehavior = false;
            OPPendientesListView.View = View.Details;
            OPPendientesListView.SelectedIndexChanged += OPPendientesListView_SelectedIndexChanged;
            // 
            // NumeroOpCol
            // 
            NumeroOpCol.Text = "N° OP";
            NumeroOpCol.Width = 70;
            // 
            // ClienteCol
            // 
            ClienteCol.Text = "Cliente";
            ClienteCol.Width = 100;
            // 
            // FechaRecepCol
            // 
            FechaRecepCol.Text = "Fecha Recepción";
            FechaRecepCol.Width = 120;
            // 
            // Fecha
            // 
            Fecha.Text = "Fecha Entrega";
            Fecha.Width = 120;
            // 
            // ModalidadCol
            // 
            ModalidadCol.Text = "Modalidad";
            ModalidadCol.Width = 100;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(12, 356);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(936, 167);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resumen consolidado de Productos";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Location = new Point(6, 26);
            listView1.Name = "listView1";
            listView1.Size = new Size(922, 121);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "SKU";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Posicion XYZ";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Descripcion";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Cantidad";
            columnHeader4.Width = 130;
            // 
            // CencelarBtn
            // 
            CencelarBtn.Location = new Point(846, 553);
            CencelarBtn.Name = "CencelarBtn";
            CencelarBtn.Size = new Size(102, 48);
            CencelarBtn.TabIndex = 5;
            CencelarBtn.Text = "Cancelar";
            CencelarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOSBtn
            // 
            GenerarOSBtn.Location = new Point(569, 553);
            GenerarOSBtn.Name = "GenerarOSBtn";
            GenerarOSBtn.Size = new Size(271, 48);
            GenerarOSBtn.TabIndex = 6;
            GenerarOSBtn.Text = "Generar Orden de Selección";
            GenerarOSBtn.UseVisualStyleBackColor = true;
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(91, 21);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(87, 20);
            DepositoLbl.TabIndex = 9;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // GenerarOrdenSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CencelarBtn;
            ClientSize = new Size(969, 628);
            Controls.Add(DepositoLbl);
            Controls.Add(GenerarOSBtn);
            Controls.Add(CencelarBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "GenerarOrdenSeleccionForm";
            Text = "GenerarOrdenSeleccionForm";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button ActualizarBtn;
        private GroupBox groupBox1;
        private ListView OPPendientesListView;
        private ColumnHeader NumeroOpCol;
        private ColumnHeader ClienteCol;
        private ColumnHeader FechaRecepCol;
        private ColumnHeader ModalidadCol;
        private GroupBox groupBox2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button CencelarBtn;
        private Button GenerarOSBtn;
        private Label DepositoLbl;
        private ListView listView2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Button button1;
        private Button button2;
        private ColumnHeader Fecha;
    }
}