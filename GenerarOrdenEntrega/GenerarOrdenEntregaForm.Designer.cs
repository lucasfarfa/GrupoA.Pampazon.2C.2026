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
            label3 = new Label();
            label5 = new Label();
            button3 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            Transportista = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            button1 = new Button();
            groupBox1 = new GroupBox();
            listView2 = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            button4 = new Button();
            groupBox2 = new GroupBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Location = new Point(331, 496);
            btnGenerarOrden.Margin = new Padding(3, 2, 3, 2);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(174, 37);
            btnGenerarOrden.TabIndex = 3;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 16);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 27;
            label3.Text = "Depósito:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 16);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 34;
            label5.Text = "[DEPOSITO]";
            // 
            // button3
            // 
            button3.Location = new Point(510, 496);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(115, 37);
            button3.TabIndex = 32;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader5, Transportista, columnHeader7 });
            listView1.Location = new Point(8, 25);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(599, 148);
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
            // button1
            // 
            button1.Location = new Point(5, 176);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(601, 28);
            button1.TabIndex = 34;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(10, 40);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(614, 212);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes preparadas sin orden de entrega";
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader6, columnHeader8, columnHeader9 });
            listView2.Location = new Point(8, 25);
            listView2.Margin = new Padding(3, 2, 3, 2);
            listView2.Name = "listView2";
            listView2.Size = new Size(599, 148);
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
            // button4
            // 
            button4.Location = new Point(5, 176);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(601, 28);
            button4.TabIndex = 35;
            button4.Text = "Quitar";
            button4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(listView2);
            groupBox2.Location = new Point(10, 256);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(614, 212);
            groupBox2.TabIndex = 36;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle Orden de Entrega";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 470);
            label1.Name = "label1";
            label1.Size = new Size(362, 15);
            label1.TabIndex = 37;
            label1.Text = "La OE solo puede agrupar órdenes del mismo cliente y transportista";
            // 
            // btnCancelar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 542);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(btnGenerarOrden);
            Controls.Add(label5);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "btnCancelar";
            Text = "GenerarOrdenEntrega";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGenerarOrden;
        private Label label3;
        private Label label5;
        private Button button3;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader5;
        private ColumnHeader Transportista;
        private ColumnHeader columnHeader7;
        private Button button1;
        private GroupBox groupBox1;
        private ListView listView2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private Button button4;
        private GroupBox groupBox2;
        private Label label1;
    }
}