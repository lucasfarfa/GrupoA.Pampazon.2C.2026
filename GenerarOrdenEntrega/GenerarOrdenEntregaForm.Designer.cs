namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    partial class btnCancelar
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
            btnGenerarOrden = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            label2 = new Label();
            listView2 = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            cmbDeposito = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            txtNumeroOE = new TextBox();
            button3 = new Button();
            btnActualizarListas = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 89);
            label1.Name = "label1";
            label1.Size = new Size(284, 20);
            label1.TabIndex = 2;
            label1.Text = "Órdenes preparadas sin orden de entrega";
            label1.Click += label1_Click;
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Location = new Point(362, 607);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(199, 29);
            btnGenerarOrden.TabIndex = 3;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView1.Location = new Point(12, 136);
            listView1.Name = "listView1";
            listView1.Size = new Size(693, 115);
            listView1.TabIndex = 14;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° OP";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "DNI transportista";
            columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Patente";
            columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Bultos";
            columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Vol (m³)";
            columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Fecha Preparación";
            columnHeader7.Width = 140;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 320);
            label2.Name = "label2";
            label2.Size = new Size(360, 20);
            label2.TabIndex = 24;
            label2.Text = "Órdenes preparadas incluidas en la orden de entrega";
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13, columnHeader14 });
            listView2.Location = new Point(12, 353);
            listView2.Name = "listView2";
            listView2.Size = new Size(693, 115);
            listView2.TabIndex = 25;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "N° OP";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Cliente";
            columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "DNI transportista";
            columnHeader10.Width = 140;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Patente";
            columnHeader11.Width = 70;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Bultos";
            columnHeader12.Width = 70;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Vol (m³)";
            columnHeader13.Width = 80;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Fecha Preparación";
            columnHeader14.Width = 140;
            // 
            // cmbDeposito
            // 
            cmbDeposito.FormattingEnabled = true;
            cmbDeposito.Location = new Point(136, 33);
            cmbDeposito.Name = "cmbDeposito";
            cmbDeposito.Size = new Size(170, 28);
            cmbDeposito.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 36);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 27;
            label3.Text = "Depósito:";
            // 
            // button1
            // 
            button1.Location = new Point(399, 257);
            button1.Name = "button1";
            button1.Size = new Size(306, 29);
            button1.TabIndex = 28;
            button1.Text = "Agregar las órdenes seleccionadas";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(399, 488);
            button2.Name = "button2";
            button2.Size = new Size(306, 29);
            button2.TabIndex = 29;
            button2.Text = "Quitar las órdenes seleccionadas";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 552);
            label4.Name = "label4";
            label4.Size = new Size(147, 20);
            label4.TabIndex = 30;
            label4.Text = "N° Orden de Entrega";
            // 
            // txtNumeroOE
            // 
            txtNumeroOE.Location = new Point(201, 552);
            txtNumeroOE.Name = "txtNumeroOE";
            txtNumeroOE.ReadOnly = true;
            txtNumeroOE.Size = new Size(125, 27);
            txtNumeroOE.TabIndex = 31;
            // 
            // button3
            // 
            button3.Location = new Point(567, 607);
            button3.Name = "button3";
            button3.Size = new Size(199, 29);
            button3.TabIndex = 32;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnActualizarListas
            // 
            btnActualizarListas.Location = new Point(502, 45);
            btnActualizarListas.Name = "btnActualizarListas";
            btnActualizarListas.Size = new Size(203, 29);
            btnActualizarListas.TabIndex = 33;
            btnActualizarListas.Text = "Actualizar lista";
            btnActualizarListas.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 712);
            Controls.Add(btnActualizarListas);
            Controls.Add(button3);
            Controls.Add(txtNumeroOE);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(cmbDeposito);
            Controls.Add(listView2);
            Controls.Add(label2);
            Controls.Add(listView1);
            Controls.Add(btnGenerarOrden);
            Controls.Add(label1);
            Name = "btnCancelar";
            Text = "GenerarOrdenEntrega";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnGenerarOrden;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Label label2;
        private ListView listView2;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ComboBox cmbDeposito;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label4;
        private TextBox txtNumeroOE;
        private Button button3;
        private Button btnActualizarListas;
    }
}