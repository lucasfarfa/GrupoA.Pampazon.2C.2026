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
            DepositoCombo = new ComboBox();
            label1 = new Label();
            ActualizarBtn = new Button();
            groupBox1 = new GroupBox();
            AgregarTodoBtn = new Button();
            AgregarOPSeleccionadasBtn = new Button();
            OPPendientesListView = new ListView();
            NumeroOpCol = new ColumnHeader();
            ClienteCol = new ColumnHeader();
            FechaRecepCol = new ColumnHeader();
            ModalidadCol = new ColumnHeader();
            groupBox2 = new GroupBox();
            QuitarTodoBtn = new Button();
            QuitarOrdenesBtn = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            CencelarBtn = new Button();
            GenerarOSBtn = new Button();
            label2 = new Label();
            NroOSLabel = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // DepositoCombo
            // 
            DepositoCombo.FormattingEnabled = true;
            DepositoCombo.Location = new Point(88, 18);
            DepositoCombo.Name = "DepositoCombo";
            DepositoCombo.Size = new Size(309, 28);
            DepositoCombo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 1;
            label1.Text = "Depósito";
            // 
            // ActualizarBtn
            // 
            ActualizarBtn.Location = new Point(403, 12);
            ActualizarBtn.Name = "ActualizarBtn";
            ActualizarBtn.Size = new Size(385, 37);
            ActualizarBtn.TabIndex = 2;
            ActualizarBtn.Text = "Actualizar";
            ActualizarBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AgregarTodoBtn);
            groupBox1.Controls.Add(AgregarOPSeleccionadasBtn);
            groupBox1.Controls.Add(OPPendientesListView);
            groupBox1.Location = new Point(12, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 230);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes de Preparación Pendientes";
            // 
            // AgregarTodoBtn
            // 
            AgregarTodoBtn.Location = new Point(391, 177);
            AgregarTodoBtn.Name = "AgregarTodoBtn";
            AgregarTodoBtn.Size = new Size(379, 37);
            AgregarTodoBtn.TabIndex = 5;
            AgregarTodoBtn.Text = "Agregar todo";
            AgregarTodoBtn.UseVisualStyleBackColor = true;
            // 
            // AgregarOPSeleccionadasBtn
            // 
            AgregarOPSeleccionadasBtn.Location = new Point(6, 177);
            AgregarOPSeleccionadasBtn.Name = "AgregarOPSeleccionadasBtn";
            AgregarOPSeleccionadasBtn.Size = new Size(379, 37);
            AgregarOPSeleccionadasBtn.TabIndex = 4;
            AgregarOPSeleccionadasBtn.Text = "Agregar ordenes seleccionadas";
            AgregarOPSeleccionadasBtn.UseVisualStyleBackColor = true;
            // 
            // OPPendientesListView
            // 
            OPPendientesListView.Columns.AddRange(new ColumnHeader[] { NumeroOpCol, ClienteCol, FechaRecepCol, ModalidadCol });
            OPPendientesListView.Location = new Point(6, 26);
            OPPendientesListView.Name = "OPPendientesListView";
            OPPendientesListView.Size = new Size(764, 121);
            OPPendientesListView.TabIndex = 0;
            OPPendientesListView.UseCompatibleStateImageBehavior = false;
            OPPendientesListView.View = View.Details;
            OPPendientesListView.SelectedIndexChanged += OPPendientesListView_SelectedIndexChanged;
            // 
            // NumeroOpCol
            // 
            NumeroOpCol.Text = "N° OP";
            NumeroOpCol.Width = 80;
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
            // ModalidadCol
            // 
            ModalidadCol.Text = "Modalidad";
            ModalidadCol.Width = 130;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(QuitarTodoBtn);
            groupBox2.Controls.Add(QuitarOrdenesBtn);
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(12, 315);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 220);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ordenes de Preparación Seleccionadas";
            // 
            // QuitarTodoBtn
            // 
            QuitarTodoBtn.Location = new Point(391, 177);
            QuitarTodoBtn.Name = "QuitarTodoBtn";
            QuitarTodoBtn.Size = new Size(379, 37);
            QuitarTodoBtn.TabIndex = 5;
            QuitarTodoBtn.Text = "Quitar todo";
            QuitarTodoBtn.UseVisualStyleBackColor = true;
            // 
            // QuitarOrdenesBtn
            // 
            QuitarOrdenesBtn.Location = new Point(6, 177);
            QuitarOrdenesBtn.Name = "QuitarOrdenesBtn";
            QuitarOrdenesBtn.Size = new Size(379, 37);
            QuitarOrdenesBtn.TabIndex = 4;
            QuitarOrdenesBtn.Text = "Quitar ordenes seleccionadas";
            QuitarOrdenesBtn.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Location = new Point(6, 26);
            listView1.Name = "listView1";
            listView1.Size = new Size(764, 121);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° OP";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Fecha Recepción";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Modalidad";
            columnHeader4.Width = 130;
            // 
            // CencelarBtn
            // 
            CencelarBtn.Location = new Point(680, 554);
            CencelarBtn.Name = "CencelarBtn";
            CencelarBtn.Size = new Size(102, 37);
            CencelarBtn.TabIndex = 5;
            CencelarBtn.Text = "Cancelar";
            CencelarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOSBtn
            // 
            GenerarOSBtn.Location = new Point(403, 554);
            GenerarOSBtn.Name = "GenerarOSBtn";
            GenerarOSBtn.Size = new Size(271, 37);
            GenerarOSBtn.TabIndex = 6;
            GenerarOSBtn.Text = "Generar Orden de Selección";
            GenerarOSBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 562);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 7;
            label2.Text = "Nro de Orden de Selección:";
            // 
            // NroOSLabel
            // 
            NroOSLabel.AutoSize = true;
            NroOSLabel.BorderStyle = BorderStyle.Fixed3D;
            NroOSLabel.Location = new Point(209, 562);
            NroOSLabel.Name = "NroOSLabel";
            NroOSLabel.Size = new Size(101, 22);
            NroOSLabel.TabIndex = 8;
            NroOSLabel.Text = "XXXXXXXXXX";
            // 
            // GenerarOrdenSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CencelarBtn;
            ClientSize = new Size(800, 603);
            Controls.Add(NroOSLabel);
            Controls.Add(label2);
            Controls.Add(GenerarOSBtn);
            Controls.Add(CencelarBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(ActualizarBtn);
            Controls.Add(label1);
            Controls.Add(DepositoCombo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "GenerarOrdenSeleccionForm";
            Text = "GenerarOrdenSeleccionForm";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox DepositoCombo;
        private Label label1;
        private Button ActualizarBtn;
        private GroupBox groupBox1;
        private ListView OPPendientesListView;
        private Button AgregarTodoBtn;
        private Button AgregarOPSeleccionadasBtn;
        private ColumnHeader NumeroOpCol;
        private ColumnHeader ClienteCol;
        private ColumnHeader FechaRecepCol;
        private ColumnHeader ModalidadCol;
        private GroupBox groupBox2;
        private Button QuitarTodoBtn;
        private Button QuitarOrdenesBtn;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button CencelarBtn;
        private Button GenerarOSBtn;
        private Label label2;
        private Label NroOSLabel;
    }
}