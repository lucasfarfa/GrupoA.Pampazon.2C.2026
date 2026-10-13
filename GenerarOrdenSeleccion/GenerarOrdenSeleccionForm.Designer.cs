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
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            CencelarBtn = new Button();
            GenerarOSBtn = new Button();
            DepositoLbl = new Label();
            button3 = new Button();
            button4 = new Button();
            lblDni = new Label();
            txtDni = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            button5 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 16);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Depósito:";
            label1.Click += label1_Click;
            // 
            // ActualizarBtn
            // 
            ActualizarBtn.Location = new Point(576, 214);
            ActualizarBtn.Margin = new Padding(3, 2, 3, 2);
            ActualizarBtn.Name = "ActualizarBtn";
            ActualizarBtn.Size = new Size(360, 28);
            ActualizarBtn.TabIndex = 2;
            ActualizarBtn.Text = "Actualizar Ordenes Pendientes";
            ActualizarBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lblDni);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(listView2);
            groupBox1.Controls.Add(ActualizarBtn);
            groupBox1.Controls.Add(OPPendientesListView);
            groupBox1.Location = new Point(10, 50);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(1087, 257);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes de Preparación Pendientes";
            // 
            // button2
            // 
            button2.Location = new Point(229, 214);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(220, 28);
            button2.TabIndex = 8;
            button2.Text = "Quitar Orden";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 214);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(218, 28);
            button1.TabIndex = 7;
            button1.Text = "Agregar Orden";
            button1.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader7, columnHeader8 });
            listView2.Location = new Point(576, 96);
            listView2.Margin = new Padding(3, 2, 3, 2);
            listView2.Name = "listView2";
            listView2.Size = new Size(397, 115);
            listView2.TabIndex = 6;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "SKU";
            columnHeader5.Width = 80;
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
            OPPendientesListView.Location = new Point(6, 96);
            OPPendientesListView.Margin = new Padding(3, 2, 3, 2);
            OPPendientesListView.Name = "OPPendientesListView";
            OPPendientesListView.Size = new Size(564, 115);
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
            groupBox2.Location = new Point(10, 356);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(1107, 258);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resumen consolidado de Productos";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader1, columnHeader3, columnHeader4 });
            listView1.Location = new Point(12, 20);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(1075, 213);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 1;
            columnHeader2.Text = "Posicion XYZ";
            columnHeader2.Width = 150;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 0;
            columnHeader1.Text = "SKU";
            columnHeader1.Width = 80;
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
            CencelarBtn.Location = new Point(981, 618);
            CencelarBtn.Margin = new Padding(3, 2, 3, 2);
            CencelarBtn.Name = "CencelarBtn";
            CencelarBtn.Size = new Size(89, 36);
            CencelarBtn.TabIndex = 5;
            CencelarBtn.Text = "Cancelar";
            CencelarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOSBtn
            // 
            GenerarOSBtn.Location = new Point(739, 618);
            GenerarOSBtn.Margin = new Padding(3, 2, 3, 2);
            GenerarOSBtn.Name = "GenerarOSBtn";
            GenerarOSBtn.Size = new Size(237, 36);
            GenerarOSBtn.TabIndex = 6;
            GenerarOSBtn.Text = "Generar Orden de Selección";
            GenerarOSBtn.UseVisualStyleBackColor = true;
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(80, 16);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(69, 15);
            DepositoLbl.TabIndex = 9;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // button3
            // 
            button3.Location = new Point(16, 296);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(218, 28);
            button3.TabIndex = 9;
            button3.Text = "Agregar todo";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(245, 296);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(210, 28);
            button4.TabIndex = 9;
            button4.Text = "Quitar todo";
            button4.UseVisualStyleBackColor = true;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(12, 28);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(44, 15);
            lblDni.TabIndex = 9;
            lblDni.Text = "Cliente";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(6, 45);
            txtDni.Margin = new Padding(3, 2, 3, 2);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(176, 23);
            txtDni.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 28);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 11;
            label2.Text = "Fecha desde";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 45);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.MaxLength = 8;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 23);
            textBox1.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(376, 28);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 13;
            label3.Text = "Fecha hasta";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(370, 45);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.MaxLength = 8;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(176, 23);
            textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(552, 45);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.MaxLength = 8;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(176, 23);
            textBox3.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(552, 28);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 16;
            label4.Text = "Modalidad";
            // 
            // button5
            // 
            button5.Location = new Point(730, 45);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(89, 29);
            button5.TabIndex = 10;
            button5.Text = "Buscar";
            button5.UseVisualStyleBackColor = true;
            // 
            // GenerarOrdenSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CencelarBtn;
            ClientSize = new Size(1136, 673);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(DepositoLbl);
            Controls.Add(GenerarOSBtn);
            Controls.Add(CencelarBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "GenerarOrdenSeleccionForm";
            Text = "GenerarOrdenSeleccionForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Button button1;
        private Button button2;
        private ColumnHeader Fecha;
        private Button button4;
        private Button button3;
        private Label lblDni;
        private TextBox txtDni;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Button button5;
    }
}