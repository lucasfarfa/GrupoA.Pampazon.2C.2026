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
            btnGenerarOrden = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            listView2 = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            txtNumeroOE = new TextBox();
            button3 = new Button();
            btnActualizarListas = new Button();
            label5 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Location = new Point(289, 607);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(199, 49);
            btnGenerarOrden.TabIndex = 3;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView1.Location = new Point(9, 33);
            listView1.Name = "listView1";
            listView1.Size = new Size(684, 115);
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
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13, columnHeader14 });
            listView2.Location = new Point(9, 28);
            listView2.Name = "listView2";
            listView2.Size = new Size(684, 115);
            listView2.TabIndex = 25;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 21);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 27;
            label3.Text = "Depósito:";
            // 
            // button1
            // 
            button1.Location = new Point(9, 164);
            button1.Name = "button1";
            button1.Size = new Size(684, 43);
            button1.TabIndex = 28;
            button1.Text = "Agregar las órdenes seleccionadas";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(9, 170);
            button2.Name = "button2";
            button2.Size = new Size(684, 44);
            button2.TabIndex = 29;
            button2.Text = "Quitar las órdenes seleccionadas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 539);
            label4.Name = "label4";
            label4.Size = new Size(147, 20);
            label4.TabIndex = 30;
            label4.Text = "N° Orden de Entrega";
            // 
            // txtNumeroOE
            // 
            txtNumeroOE.Location = new Point(171, 539);
            txtNumeroOE.Name = "txtNumeroOE";
            txtNumeroOE.ReadOnly = true;
            txtNumeroOE.Size = new Size(125, 27);
            txtNumeroOE.TabIndex = 31;
            // 
            // button3
            // 
            button3.Location = new Point(506, 607);
            button3.Name = "button3";
            button3.Size = new Size(199, 49);
            button3.TabIndex = 32;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnActualizarListas
            // 
            btnActualizarListas.Location = new Point(583, 12);
            btnActualizarListas.Name = "btnActualizarListas";
            btnActualizarListas.Size = new Size(131, 38);
            btnActualizarListas.TabIndex = 33;
            btnActualizarListas.Text = "Actualizar lista";
            btnActualizarListas.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 21);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 34;
            label5.Text = "[DEPOSITO]";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(12, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(702, 223);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes preparadas sin orden de entrega";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(listView2);
            groupBox2.Location = new Point(12, 313);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(702, 220);
            groupBox2.TabIndex = 36;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ordenes preparadas incluidas en la orden de entrega";
            // 
            // btnCancelar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 683);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(btnActualizarListas);
            Controls.Add(button3);
            Controls.Add(txtNumeroOE);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnGenerarOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "btnCancelar";
            Text = "GenerarOrdenEntrega";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGenerarOrden;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ListView listView2;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label4;
        private TextBox txtNumeroOE;
        private Button button3;
        private Button btnActualizarListas;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}