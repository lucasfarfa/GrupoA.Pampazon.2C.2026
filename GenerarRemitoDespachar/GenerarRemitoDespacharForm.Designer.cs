namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    partial class GenerarRemitoDespacharForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            label5 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            button4 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            groupBox3 = new GroupBox();
            button3 = new Button();
            listView2 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            groupBox4 = new GroupBox();
            button5 = new Button();
            listView3 = new ListView();
            columnHeaderRemito = new ColumnHeader();
            button6 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Depósito:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 9);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 1;
            label2.Text = "GBA";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(11, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(917, 80);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Identificar transportista";
            // 
            // button1
            // 
            button1.Location = new Point(688, 25);
            button1.Name = "button1";
            button1.Size = new Size(219, 43);
            button1.TabIndex = 5;
            button1.Text = "Buscar órdenes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(325, 36);
            label5.Name = "label5";
            label5.Size = new Size(153, 20);
            label5.TabIndex = 4;
            label5.Text = "[NOMBRE, APELLIDO]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(251, 36);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "Nombre:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(195, 27);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 36);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 1;
            label3.Text = "DNI:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(11, 132);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(917, 216);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "1. Ordenes de entrega pendientes de entrega";
            // 
            // button4
            // 
            button4.Location = new Point(459, 163);
            button4.Name = "button4";
            button4.Size = new Size(448, 43);
            button4.TabIndex = 7;
            button4.Text = "Deseleccionar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(6, 163);
            button2.Name = "button2";
            button2.Size = new Size(448, 43);
            button2.TabIndex = 6;
            button2.Text = "Seleccionar ";
            button2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Location = new Point(6, 35);
            listView1.Name = "listView1";
            listView1.Size = new Size(902, 121);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Cliente";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "N° OE";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ordenes de preparación";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Bultos";
            columnHeader4.Width = 80;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(listView2);
            groupBox3.Location = new Point(11, 355);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(917, 216);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "2. Se emitirán los siguientes remitos:";
            // 
            // button3
            // 
            button3.Location = new Point(6, 163);
            button3.Name = "button3";
            button3.Size = new Size(902, 43);
            button3.TabIndex = 7;
            button3.Text = "Emitir remitos";
            button3.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            listView2.Location = new Point(6, 35);
            listView2.Name = "listView2";
            listView2.Size = new Size(902, 121);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Cliente";
            columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "OE incluidas";
            columnHeader6.Width = 100;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button5);
            groupBox4.Controls.Add(listView3);
            groupBox4.Location = new Point(11, 576);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(917, 216);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "3. Remitos pendiente de firma";
            // 
            // button5
            // 
            button5.Location = new Point(6, 163);
            button5.Name = "button5";
            button5.Size = new Size(902, 43);
            button5.TabIndex = 7;
            button5.Text = "Confirmar entrega y firma";
            button5.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeaderRemito });
            listView3.Location = new Point(6, 35);
            listView3.Name = "listView3";
            listView3.Size = new Size(902, 121);
            listView3.TabIndex = 0;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeaderRemito
            // 
            columnHeaderRemito.Text = "N° Remito";
            columnHeaderRemito.Width = 775;
            // 
            // button6
            // 
            button6.Location = new Point(703, 812);
            button6.Name = "button6";
            button6.Size = new Size(219, 43);
            button6.TabIndex = 9;
            button6.Text = "Cerrar";
            button6.UseVisualStyleBackColor = true;
            // 
            // GenerarRemitoDespacharForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 867);
            Controls.Add(button6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarRemitoDespacharForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar remito y despachar";
            Load += GenerarRemitoDespacharForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label3;
        private Button button1;
        private Label label5;
        private Label label4;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private Button button4;
        private Button button2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private GroupBox groupBox3;
        private Button button3;
        private ListView listView2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private GroupBox groupBox4;
        private Button button5;
        private ListView listView3;
        private ColumnHeader columnHeaderRemito;
        private Button button6;
    }
}