namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    partial class GenerarOrdenEntregaForm
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
            btnCancelar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            txtObservaciones = new TextBox();
            cmbDarsena = new ComboBox();
            dtpFechaSalida = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(244, 20);
            label1.TabIndex = 2;
            label1.Text = "Órdenes empaquetadas pendientes";
            label1.Click += label1_Click;
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Location = new Point(442, 502);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(199, 29);
            btnGenerarOrden.TabIndex = 3;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(662, 502);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 29);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.TopCenter;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(430, 23);
            label2.Name = "label2";
            label2.Size = new Size(225, 20);
            label2.TabIndex = 5;
            label2.Text = "Datos de la orden empaquetada";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(439, 61);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 6;
            label3.Text = "Razón social";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(439, 151);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 7;
            label4.Text = "CUIT";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(439, 107);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 8;
            label5.Text = "N° Orden prep";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(439, 202);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 9;
            label6.Text = "Bultos";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(439, 265);
            label7.Name = "label7";
            label7.Size = new Size(222, 20);
            label7.TabIndex = 10;
            label7.Text = "Asignación de orden de entrega";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(442, 317);
            label8.Name = "label8";
            label8.Size = new Size(127, 20);
            label8.TabIndex = 11;
            label8.Text = "Dársena asignada";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(439, 366);
            label9.Name = "label9";
            label9.Size = new Size(196, 20);
            label9.TabIndex = 12;
            label9.Text = "Fecha programada de carga";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(442, 420);
            label10.Name = "label10";
            label10.Size = new Size(105, 20);
            label10.TabIndex = 13;
            label10.Text = "Observaciones";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listView1.Location = new Point(12, 82);
            listView1.Name = "listView1";
            listView1.Size = new Size(403, 203);
            listView1.TabIndex = 14;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° Ord. Prep.";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Bultos";
            columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Vol (m³";
            columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Fecha";
            columnHeader5.Width = 70;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(556, 100);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(129, 27);
            textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(548, 54);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 27);
            textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(502, 195);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(123, 27);
            textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(502, 144);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(137, 27);
            textBox4.TabIndex = 18;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(568, 417);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(181, 27);
            txtObservaciones.TabIndex = 21;
            // 
            // cmbDarsena
            // 
            cmbDarsena.FormattingEnabled = true;
            cmbDarsena.Location = new Point(585, 317);
            cmbDarsena.Name = "cmbDarsena";
            cmbDarsena.Size = new Size(151, 28);
            cmbDarsena.TabIndex = 22;
            // 
            // dtpFechaSalida
            // 
            dtpFechaSalida.Location = new Point(641, 366);
            dtpFechaSalida.Name = "dtpFechaSalida";
            dtpFechaSalida.Size = new Size(207, 27);
            dtpFechaSalida.TabIndex = 23;
            // 
            // GenerarOrdenEntregaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 579);
            Controls.Add(dtpFechaSalida);
            Controls.Add(cmbDarsena);
            Controls.Add(txtObservaciones);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGenerarOrden);
            Controls.Add(label1);
            Name = "GenerarOrdenEntregaForm";
            Text = "GenerarOrdenEntrega";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnGenerarOrden;
        private Button btnCancelar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox txtObservaciones;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ComboBox cmbDarsena;
        private DateTimePicker dtpFechaSalida;
    }
}