namespace AdministracionDeposito
{
    partial class GenerarRemitoDespacharForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpOrdenesPendientes = new GroupBox();
            lvwOrdenes = new ListView();
            colNroOrden = new ColumnHeader();
            ColCliente = new ColumnHeader();
            ColBultos = new ColumnHeader();
            ColDarsena = new ColumnHeader();
            ColFechaPreparación = new ColumnHeader();
            grpDatosOrden = new GroupBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            labelRazonSocial = new Label();
            grpVerificacionChofer = new GroupBox();
            grpCargaRemito = new GroupBox();
            btnConfirmarDespacho = new Button();
            button1 = new Button();
            label1 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            grpOrdenesPendientes.SuspendLayout();
            grpDatosOrden.SuspendLayout();
            grpVerificacionChofer.SuspendLayout();
            grpCargaRemito.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrdenesPendientes
            // 
            grpOrdenesPendientes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpOrdenesPendientes.Controls.Add(lvwOrdenes);
            grpOrdenesPendientes.Font = new Font("Segoe UI", 9F);
            grpOrdenesPendientes.Location = new Point(12, 12);
            grpOrdenesPendientes.Name = "grpOrdenesPendientes";
            grpOrdenesPendientes.Size = new Size(430, 570);
            grpOrdenesPendientes.TabIndex = 0;
            grpOrdenesPendientes.TabStop = false;
            grpOrdenesPendientes.Text = "Ordenes de entrega pendientes";
            grpOrdenesPendientes.Enter += grpOrdenesPendientes_Enter;
            // 
            // lvwOrdenes
            // 
            lvwOrdenes.Columns.AddRange(new ColumnHeader[] { colNroOrden, ColCliente, ColBultos, ColDarsena, ColFechaPreparación });
            lvwOrdenes.Dock = DockStyle.Fill;
            lvwOrdenes.Font = new Font("Segoe UI", 9F);
            lvwOrdenes.FullRowSelect = true;
            lvwOrdenes.Location = new Point(3, 23);
            lvwOrdenes.MultiSelect = false;
            lvwOrdenes.Name = "lvwOrdenes";
            lvwOrdenes.Size = new Size(424, 544);
            lvwOrdenes.TabIndex = 0;
            lvwOrdenes.UseCompatibleStateImageBehavior = false;
            lvwOrdenes.View = View.Details;
            lvwOrdenes.SelectedIndexChanged += lvwOrdenes_SelectedIndexChanged;
            // 
            // colNroOrden
            // 
            colNroOrden.Text = "N° Orden";
            colNroOrden.Width = 90;
            // 
            // ColCliente
            // 
            ColCliente.Text = "Cliente";
            ColCliente.Width = 150;
            // 
            // ColBultos
            // 
            ColBultos.Text = "Bultos";
            ColBultos.TextAlign = HorizontalAlignment.Right;
            ColBultos.Width = 55;
            // 
            // ColDarsena
            // 
            ColDarsena.Text = "Darsena";
            // 
            // ColFechaPreparación
            // 
            ColFechaPreparación.Text = "Fecha de preparación";
            ColFechaPreparación.Width = 110;
            // 
            // grpDatosOrden
            // 
            grpDatosOrden.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosOrden.Controls.Add(textBox8);
            grpDatosOrden.Controls.Add(textBox7);
            grpDatosOrden.Controls.Add(textBox6);
            grpDatosOrden.Controls.Add(textBox5);
            grpDatosOrden.Controls.Add(textBox4);
            grpDatosOrden.Controls.Add(textBox3);
            grpDatosOrden.Controls.Add(textBox2);
            grpDatosOrden.Controls.Add(textBox1);
            grpDatosOrden.Controls.Add(label7);
            grpDatosOrden.Controls.Add(label6);
            grpDatosOrden.Controls.Add(label4);
            grpDatosOrden.Controls.Add(label1);
            grpDatosOrden.Controls.Add(label5);
            grpDatosOrden.Controls.Add(label3);
            grpDatosOrden.Controls.Add(label2);
            grpDatosOrden.Controls.Add(labelRazonSocial);
            grpDatosOrden.Font = new Font("Segoe UI", 9F);
            grpDatosOrden.Location = new Point(454, 12);
            grpDatosOrden.Name = "grpDatosOrden";
            grpDatosOrden.Size = new Size(640, 225);
            grpDatosOrden.TabIndex = 1;
            grpDatosOrden.TabStop = false;
            grpDatosOrden.Text = "Datos de la orden";
            // 
            // label5
            // 
            label5.Location = new Point(445, 33);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 7;
            label5.Text = "Cuit";
            label5.Click += label5_Click;
            // 
            // label3
            // 
            label3.Location = new Point(37, 68);
            label3.Name = "label3";
            label3.Size = new Size(151, 35);
            label3.TabIndex = 2;
            label3.Text = "Domicilio de entrega";
            // 
            // label2
            // 
            label2.Location = new Point(37, 103);
            label2.Name = "label2";
            label2.Size = new Size(151, 35);
            label2.TabIndex = 1;
            label2.Text = "Ordenes de prep.";
            // 
            // labelRazonSocial
            // 
            labelRazonSocial.Location = new Point(37, 33);
            labelRazonSocial.Name = "labelRazonSocial";
            labelRazonSocial.Size = new Size(151, 20);
            labelRazonSocial.TabIndex = 0;
            labelRazonSocial.Text = "Razón social";
            // 
            // grpVerificacionChofer
            // 
            grpVerificacionChofer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpVerificacionChofer.Controls.Add(button3);
            grpVerificacionChofer.Controls.Add(textBox12);
            grpVerificacionChofer.Controls.Add(textBox11);
            grpVerificacionChofer.Controls.Add(textBox10);
            grpVerificacionChofer.Controls.Add(textBox9);
            grpVerificacionChofer.Controls.Add(label12);
            grpVerificacionChofer.Controls.Add(label11);
            grpVerificacionChofer.Controls.Add(label10);
            grpVerificacionChofer.Controls.Add(label9);
            grpVerificacionChofer.Font = new Font("Segoe UI", 9F);
            grpVerificacionChofer.Location = new Point(454, 247);
            grpVerificacionChofer.Name = "grpVerificacionChofer";
            grpVerificacionChofer.Size = new Size(650, 150);
            grpVerificacionChofer.TabIndex = 2;
            grpVerificacionChofer.TabStop = false;
            grpVerificacionChofer.Text = "Verificación del chofer";
            // 
            // grpCargaRemito
            // 
            grpCargaRemito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCargaRemito.Controls.Add(button2);
            grpCargaRemito.Controls.Add(textBox14);
            grpCargaRemito.Controls.Add(textBox13);
            grpCargaRemito.Controls.Add(label14);
            grpCargaRemito.Controls.Add(label13);
            grpCargaRemito.Font = new Font("Segoe UI", 9F);
            grpCargaRemito.Location = new Point(454, 407);
            grpCargaRemito.Name = "grpCargaRemito";
            grpCargaRemito.Size = new Size(640, 175);
            grpCargaRemito.TabIndex = 3;
            grpCargaRemito.TabStop = false;
            grpCargaRemito.Text = "Carga y remito";
            // 
            // btnConfirmarDespacho
            // 
            btnConfirmarDespacho.Location = new Point(735, 618);
            btnConfirmarDespacho.Name = "btnConfirmarDespacho";
            btnConfirmarDespacho.Size = new Size(166, 27);
            btnConfirmarDespacho.TabIndex = 4;
            btnConfirmarDespacho.Text = "Confirmar despacho";
            btnConfirmarDespacho.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(921, 618);
            button1.Name = "button1";
            button1.Size = new Size(123, 27);
            button1.TabIndex = 5;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(37, 143);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 9;
            label1.Text = "Bultos";
            // 
            // label4
            // 
            label4.Location = new Point(212, 143);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 10;
            label4.Text = "Peso (Kg)";
            // 
            // label6
            // 
            label6.Location = new Point(405, 143);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 11;
            label6.Text = "Volumen (m3)";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.Location = new Point(38, 181);
            label7.Name = "label7";
            label7.Size = new Size(122, 20);
            label7.TabIndex = 12;
            label7.Text = "Transportista aut.";
            // 
            // label9
            // 
            label9.Location = new Point(37, 46);
            label9.Name = "label9";
            label9.Size = new Size(122, 20);
            label9.TabIndex = 13;
            label9.Text = "DNI";
            // 
            // label10
            // 
            label10.Location = new Point(262, 50);
            label10.Name = "label10";
            label10.Size = new Size(35, 20);
            label10.TabIndex = 14;
            label10.Text = "Patente";
            // 
            // label11
            // 
            label11.Location = new Point(37, 83);
            label11.Name = "label11";
            label11.Size = new Size(58, 20);
            label11.TabIndex = 15;
            label11.Text = "Chofer";
            // 
            // label12
            // 
            label12.Location = new Point(38, 117);
            label12.Name = "label12";
            label12.Size = new Size(122, 20);
            label12.TabIndex = 16;
            label12.Text = "Empresa transp.";
            // 
            // label13
            // 
            label13.Location = new Point(37, 47);
            label13.Name = "label13";
            label13.Size = new Size(122, 20);
            label13.TabIndex = 17;
            label13.Text = "Bultos cargados";
            // 
            // label14
            // 
            label14.Location = new Point(418, 54);
            label14.Name = "label14";
            label14.Size = new Size(115, 20);
            label14.TabIndex = 18;
            label14.Text = "N° remito";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(140, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 27);
            textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(194, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(202, 27);
            textBox2.TabIndex = 15;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(166, 100);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(202, 27);
            textBox3.TabIndex = 16;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(166, 178);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(426, 27);
            textBox4.TabIndex = 17;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(486, 30);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(134, 27);
            textBox5.TabIndex = 18;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(93, 143);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(59, 27);
            textBox6.TabIndex = 19;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(289, 143);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(79, 27);
            textBox7.TabIndex = 20;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(513, 143);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(79, 27);
            textBox8.TabIndex = 21;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(81, 43);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(136, 27);
            textBox9.TabIndex = 22;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(326, 47);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(140, 27);
            textBox10.TabIndex = 23;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(93, 80);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(136, 27);
            textBox11.TabIndex = 24;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(158, 114);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(136, 27);
            textBox12.TabIndex = 25;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(158, 44);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(82, 27);
            textBox13.TabIndex = 26;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(498, 47);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(136, 27);
            textBox14.TabIndex = 27;
            // 
            // button2
            // 
            button2.Location = new Point(262, 45);
            button2.Name = "button2";
            button2.Size = new Size(113, 29);
            button2.TabIndex = 28;
            button2.Text = "Emitir remito";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(498, 50);
            button3.Name = "button3";
            button3.Size = new Size(127, 29);
            button3.TabIndex = 29;
            button3.Text = "Verificar chofer";
            button3.UseVisualStyleBackColor = true;
            // 
            // FrmGenerarRemitoDespachar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 662);
            Controls.Add(button1);
            Controls.Add(btnConfirmarDespacho);
            Controls.Add(grpCargaRemito);
            Controls.Add(grpVerificacionChofer);
            Controls.Add(grpDatosOrden);
            Controls.Add(grpOrdenesPendientes);
            MinimumSize = new Size(1100, 650);
            Name = "FrmGenerarRemitoDespachar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar remito y despachar";
            WindowState = FormWindowState.Maximized;
            grpOrdenesPendientes.ResumeLayout(false);
            grpDatosOrden.ResumeLayout(false);
            grpDatosOrden.PerformLayout();
            grpVerificacionChofer.ResumeLayout(false);
            grpVerificacionChofer.PerformLayout();
            grpCargaRemito.ResumeLayout(false);
            grpCargaRemito.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOrdenesPendientes;
        private GroupBox grpDatosOrden;
        private GroupBox grpVerificacionChofer;
        private GroupBox grpCargaRemito;
        private Button btnConfirmarDespacho;
        private Button button1;
        private ListView lvwOrdenes;
        private ColumnHeader colNroOrden;
        private ColumnHeader ColCliente;
        private ColumnHeader ColBultos;
        private ColumnHeader ColDarsena;
        private ColumnHeader ColFechaPreparación;
        private Label label5;
        private TextBox textBox3;
        private Label label3;
        private Label label2;
        private Label labelRazonSocial;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label1;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label13;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button3;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private TextBox textBox9;
        private Button button2;
        private TextBox textBox14;
        private TextBox textBox13;
        private Label label14;
    }
}
