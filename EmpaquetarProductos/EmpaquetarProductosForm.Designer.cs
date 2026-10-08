namespace GrupoA.PampazonSA.AdministracionDeposito.CU04EmpaquetarProductos
{
    partial class EmpaquetarProductosForm
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
            cmbAlmacen = new ComboBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            btnLogin = new Button();
            groupBox1 = new GroupBox();
            grpOrden = new GroupBox();
            textModalidad = new TextBox();
            label5 = new Label();
            textCliente = new TextBox();
            txtCliente = new Label();
            label4 = new Label();
            label3 = new Label();
            cmbOrden = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            groupBox2 = new GroupBox();
            label9 = new Label();
            groupBox3 = new GroupBox();
            lstProductos = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            chkVerificacionFisica = new CheckBox();
            label6 = new Label();
            txtCantidadBultos = new TextBox();
            btnEmpaquetar = new Button();
            btnCancelar = new Button();
            btnAlmacén = new Button();
            groupBox1.SuspendLayout();
            grpOrden.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(15, 53);
            label1.Name = "label1";
            label1.Size = new Size(106, 29);
            label1.TabIndex = 0;
            label1.Text = "Almacén";
            // 
            // cmbAlmacen
            // 
            cmbAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlmacen.FormattingEnabled = true;
            cmbAlmacen.Items.AddRange(new object[] { "Buenos Aires - Nave Central", "Rosario", "Cordoba", "Tucuman" });
            cmbAlmacen.Location = new Point(127, 47);
            cmbAlmacen.Name = "cmbAlmacen";
            cmbAlmacen.Size = new Size(383, 40);
            cmbAlmacen.TabIndex = 1;
            cmbAlmacen.SelectedIndexChanged += cmbAlmacen_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(630, 53);
            label2.Name = "label2";
            label2.Size = new Size(109, 29);
            label2.TabIndex = 2;
            label2.Text = "Operario";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Leg. 8876 - Lidia  (Fulfillment)", "Leg. 8877 - Lucas (Jefe de Depopsito)", "Leg. 8878 - Mora (Fulfillment)" });
            comboBox1.Location = new Point(768, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(454, 40);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.AppWorkspace;
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(892, 121);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(269, 44);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Seleccionar Operario";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAlmacén);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(cmbAlmacen);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(0, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1250, 193);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // grpOrden
            // 
            grpOrden.Controls.Add(dateTimePicker1);
            grpOrden.Controls.Add(textModalidad);
            grpOrden.Controls.Add(label5);
            grpOrden.Controls.Add(textCliente);
            grpOrden.Controls.Add(txtCliente);
            grpOrden.Controls.Add(label4);
            grpOrden.Controls.Add(label3);
            grpOrden.Controls.Add(cmbOrden);
            grpOrden.Location = new Point(9, 226);
            grpOrden.Name = "grpOrden";
            grpOrden.Size = new Size(1235, 207);
            grpOrden.TabIndex = 6;
            grpOrden.TabStop = false;
            grpOrden.Text = "Selección de Orden de Preparación";
            grpOrden.UseWaitCursor = true;
            // 
            // textModalidad
            // 
            textModalidad.Location = new Point(842, 142);
            textModalidad.Name = "textModalidad";
            textModalidad.ReadOnly = true;
            textModalidad.Size = new Size(310, 39);
            textModalidad.TabIndex = 11;
            textModalidad.Text = "Fulfillment /Pallets";
            textModalidad.UseWaitCursor = true;
            textModalidad.TextChanged += textModalidad_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(667, 145);
            label5.Name = "label5";
            label5.Size = new Size(133, 32);
            label5.TabIndex = 10;
            label5.Text = "Modalidad:";
            label5.UseWaitCursor = true;
            // 
            // textCliente
            // 
            textCliente.Location = new Point(157, 138);
            textCliente.Name = "textCliente";
            textCliente.ReadOnly = true;
            textCliente.Size = new Size(454, 39);
            textCliente.TabIndex = 9;
            textCliente.Text = "MundoFOX S.A.";
            // 
            // txtCliente
            // 
            txtCliente.AutoSize = true;
            txtCliente.Location = new Point(19, 141);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(94, 32);
            txtCliente.TabIndex = 8;
            txtCliente.Text = "Cliente:";
            txtCliente.UseWaitCursor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(667, 50);
            label4.Name = "label4";
            label4.Size = new Size(169, 32);
            label4.TabIndex = 2;
            label4.Text = "Fecha Entrega:";
            label4.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(15, 53);
            label3.Name = "label3";
            label3.Size = new Size(87, 29);
            label3.TabIndex = 0;
            label3.Text = "Orden:";
            label3.UseWaitCursor = true;
            label3.Click += label3_Click;
            // 
            // cmbOrden
            // 
            cmbOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrden.FormattingEnabled = true;
            cmbOrden.Items.AddRange(new object[] { "OP-2026-0016 (MundoFOX S.A.)" });
            cmbOrden.Location = new Point(157, 53);
            cmbOrden.Name = "cmbOrden";
            cmbOrden.Size = new Size(454, 40);
            cmbOrden.TabIndex = 1;
            cmbOrden.UseWaitCursor = true;
            cmbOrden.SelectedIndexChanged += cmbOrden_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(842, 51);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(310, 39);
            dateTimePicker1.TabIndex = 12;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstProductos);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(12, 453);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1232, 266);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Productos a empaquetar";
            groupBox2.UseWaitCursor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(15, 53);
            label9.Name = "label9";
            label9.Size = new Size(0, 29);
            label9.TabIndex = 0;
            label9.UseWaitCursor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCantidadBultos);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(chkVerificacionFisica);
            groupBox3.Location = new Point(10, 749);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1235, 140);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Consolidacion de Empaque y rotulación";
            groupBox3.UseWaitCursor = true;
            // 
            // lstProductos
            // 
            lstProductos.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lstProductos.FullRowSelect = true;
            lstProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstProductos.Location = new Point(12, 38);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(1202, 222);
            lstProductos.TabIndex = 1;
            lstProductos.UseCompatibleStateImageBehavior = false;
            lstProductos.View = View.Details;
            lstProductos.SelectedIndexChanged += lstProductos_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "SKU Producto";
            columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nombre Producto";
            columnHeader2.Width = 650;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Cantidad";
            columnHeader3.Width = 120;
            // 
            // chkVerificacionFisica
            // 
            chkVerificacionFisica.AutoSize = true;
            chkVerificacionFisica.Location = new Point(18, 58);
            chkVerificacionFisica.Name = "chkVerificacionFisica";
            chkVerificacionFisica.Size = new Size(334, 36);
            chkVerificacionFisica.TabIndex = 0;
            chkVerificacionFisica.Text = "Verificación física completa";
            chkVerificacionFisica.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(493, 56);
            label6.Name = "label6";
            label6.Size = new Size(221, 32);
            label6.TabIndex = 1;
            label6.Text = "Cantidad de bultos:";
            // 
            // txtCantidadBultos
            // 
            txtCantidadBultos.Enabled = false;
            txtCantidadBultos.Location = new Point(758, 49);
            txtCantidadBultos.Name = "txtCantidadBultos";
            txtCantidadBultos.Size = new Size(96, 39);
            txtCantidadBultos.TabIndex = 2;
            // 
            // btnEmpaquetar
            // 
            btnEmpaquetar.Enabled = false;
            btnEmpaquetar.ForeColor = SystemColors.HotTrack;
            btnEmpaquetar.Location = new Point(818, 950);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(150, 46);
            btnEmpaquetar.TabIndex = 9;
            btnEmpaquetar.Text = "Empaquetar";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlLight;
            btnCancelar.ForeColor = SystemColors.WindowFrame;
            btnCancelar.Location = new Point(1011, 950);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 46);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAlmacén
            // 
            btnAlmacén.BackColor = SystemColors.AppWorkspace;
            btnAlmacén.ForeColor = Color.Black;
            btnAlmacén.Location = new Point(241, 121);
            btnAlmacén.Name = "btnAlmacén";
            btnAlmacén.Size = new Size(269, 44);
            btnAlmacén.TabIndex = 5;
            btnAlmacén.Text = "Seleccionar Almacén";
            btnAlmacén.UseVisualStyleBackColor = false;
            // 
            // EmpaquetarProductosForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 1024);
            Controls.Add(btnCancelar);
            Controls.Add(btnEmpaquetar);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(grpOrden);
            Controls.Add(groupBox1);
            Name = "EmpaquetarProductosForm";
            Text = "Empaquetar Productos Forms - Pampazon S.A";
            Load += EmpaquetarProductosForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpOrden.ResumeLayout(false);
            grpOrden.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cmbAlmacen;
        private Label label2;
        private ComboBox comboBox1;
        private Button btnLogin;
        private GroupBox groupBox1;
        private GroupBox grpOrden;
        private Label label3;
        private ComboBox cmbOrden;
        private Label label4;
        private Label txtCliente;
        private TextBox textCliente;
        private Label label5;
        private TextBox textModalidad;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox2;
        private Label label9;
        private GroupBox groupBox3;
        private ListView lstProductos;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private TextBox txtCantidadBultos;
        private Label label6;
        private CheckBox chkVerificacionFisica;
        private Button btnEmpaquetar;
        private Button btnCancelar;
        private Button btnAlmacén;
    }
}