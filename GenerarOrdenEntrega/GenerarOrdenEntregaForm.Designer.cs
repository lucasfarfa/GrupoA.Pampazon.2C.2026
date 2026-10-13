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
            columnHeader5 = new ColumnHeader();
            Transportista = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            label3 = new Label();
            button3 = new Button();
            label5 = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            groupBox2 = new GroupBox();
            button4 = new Button();
            listView2 = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Location = new Point(378, 662);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(199, 49);
            btnGenerarOrden.TabIndex = 3;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader5, Transportista, columnHeader7 });
            listView1.Location = new Point(9, 33);
            listView1.Name = "listView1";
            listView1.Size = new Size(684, 196);
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
            // columnHeader5
            // 
            columnHeader5.Text = "Bultos";
            columnHeader5.Width = 70;
            // 
            // Transportista
            // 
            Transportista.Text = "Transportista";
            Transportista.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Fecha Entrega";
            columnHeader7.Width = 140;
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
            // button3
            // 
            button3.Location = new Point(583, 662);
            button3.Name = "button3";
            button3.Size = new Size(131, 49);
            button3.TabIndex = 32;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
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
            groupBox1.Location = new Point(12, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(702, 282);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes preparadas sin orden de entrega";
            // 
            // button1
            // 
            button1.Location = new Point(6, 235);
            button1.Name = "button1";
            button1.Size = new Size(687, 38);
            button1.TabIndex = 34;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(listView2);
            groupBox2.Location = new Point(12, 341);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(702, 282);
            groupBox2.TabIndex = 36;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle Orden de Entrega";
            // 
            // button4
            // 
            button4.Location = new Point(6, 235);
            button4.Name = "button4";
            button4.Size = new Size(687, 38);
            button4.TabIndex = 35;
            button4.Text = "Quitar";
            button4.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader6, columnHeader8, columnHeader9 });
            listView2.Location = new Point(9, 33);
            listView2.Name = "listView2";
            listView2.Size = new Size(684, 196);
            listView2.TabIndex = 14;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "N° OP";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Cliente";
            columnHeader4.Width = 70;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Bultos";
            columnHeader6.Width = 70;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Transportista";
            columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Fecha Entrega";
            columnHeader9.Width = 140;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 626);
            label1.Name = "label1";
            label1.Size = new Size(458, 20);
            label1.TabIndex = 37;
            label1.Text = "La OE solo puede agrupar órdenes del mismo cliente y transportista";
            // 
            // btnCancelar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 723);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(btnGenerarOrden);
            Controls.Add(label5);
            Controls.Add(label3);
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
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader7;
        private Label label3;
        private Button button3;
        private Label label5;
        private GroupBox groupBox1;
        private ColumnHeader Transportista;
        private Button button1;
        private GroupBox groupBox2;
        private Button button4;
        private ListView listView2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private Label label1;
    }
}