namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    partial class RegistrarOrdenPreparacionForm
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
            groupBox1 = new GroupBox();
            rbPaletCerrado = new RadioButton();
            rbFulfillment = new RadioButton();
            label4 = new Label();
            cboDeposito = new ComboBox();
            label3 = new Label();
            txtCuit = new TextBox();
            label2 = new Label();
            cboCliente = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtFechaRetiro = new TextBox();
            label7 = new Label();
            txtNombreTransportista = new TextBox();
            label6 = new Label();
            txtDni = new TextBox();
            label5 = new Label();
            groupBox3 = new GroupBox();
            btnAgregar = new Button();
            txtCantidad = new TextBox();
            label10 = new Label();
            txtDisponible = new TextBox();
            label9 = new Label();
            cboSku = new ComboBox();
            label11 = new Label();
            btnQuitarSeleccionado = new Button();
            btnRegistrarOp = new Button();
            btnCancelar = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbPaletCerrado);
            groupBox1.Controls.Add(rbFulfillment);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboDeposito);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCuit);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboCliente);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(447, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la orden";
            // 
            // rbPaletCerrado
            // 
            rbPaletCerrado.AutoSize = true;
            rbPaletCerrado.Location = new Point(302, 149);
            rbPaletCerrado.Margin = new Padding(3, 4, 3, 4);
            rbPaletCerrado.Name = "rbPaletCerrado";
            rbPaletCerrado.Size = new Size(117, 24);
            rbPaletCerrado.TabIndex = 8;
            rbPaletCerrado.TabStop = true;
            rbPaletCerrado.Text = "Palet cerrado";
            rbPaletCerrado.UseVisualStyleBackColor = true;
            // 
            // rbFulfillment
            // 
            rbFulfillment.AutoSize = true;
            rbFulfillment.Location = new Point(171, 149);
            rbFulfillment.Margin = new Padding(3, 4, 3, 4);
            rbFulfillment.Name = "rbFulfillment";
            rbFulfillment.Size = new Size(100, 24);
            rbFulfillment.TabIndex = 7;
            rbFulfillment.TabStop = true;
            rbFulfillment.Text = "Fulfillment";
            rbFulfillment.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 153);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 6;
            label4.Text = "Modalidad";
            // 
            // cboDeposito
            // 
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Location = new Point(171, 107);
            cboDeposito.Margin = new Padding(3, 4, 3, 4);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(248, 28);
            cboDeposito.TabIndex = 5;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 111);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Depósito";
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(171, 67);
            txtCuit.Margin = new Padding(3, 4, 3, 4);
            txtCuit.Name = "txtCuit";
            txtCuit.ReadOnly = true;
            txtCuit.Size = new Size(248, 27);
            txtCuit.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 71);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 2;
            label2.Text = "CUIT";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(171, 27);
            cboCliente.Margin = new Padding(3, 4, 3, 4);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(248, 28);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 31);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNombreTransportista);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtDni);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(488, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(419, 135);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Transportista autorizado";
            // 
            // txtFechaRetiro
            // 
            txtFechaRetiro.Location = new Point(625, 174);
            txtFechaRetiro.Margin = new Padding(3, 4, 3, 4);
            txtFechaRetiro.Name = "txtFechaRetiro";
            txtFechaRetiro.Size = new Size(272, 27);
            txtFechaRetiro.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(488, 181);
            label7.Name = "label7";
            label7.Size = new Size(112, 20);
            label7.TabIndex = 4;
            label7.Text = "Fecha de Retiro";
            // 
            // txtNombreTransportista
            // 
            txtNombreTransportista.Location = new Point(137, 73);
            txtNombreTransportista.Margin = new Padding(3, 4, 3, 4);
            txtNombreTransportista.Name = "txtNombreTransportista";
            txtNombreTransportista.Size = new Size(272, 27);
            txtNombreTransportista.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 77);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 2;
            label6.Text = "Nombre";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(137, 27);
            txtDni.Margin = new Padding(3, 4, 3, 4);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(272, 27);
            txtDni.TabIndex = 1;
            txtDni.KeyPress += SoloDigitos_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 31);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 0;
            label5.Text = "DNI";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listView1);
            groupBox3.Controls.Add(btnAgregar);
            groupBox3.Controls.Add(txtCantidad);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(txtDisponible);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(cboSku);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(btnQuitarSeleccionado);
            groupBox3.Location = new Point(14, 233);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(893, 373);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Productos a preparar";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(767, 28);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(116, 36);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(559, 34);
            txtCantidad.Margin = new Padding(3, 4, 3, 4);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(91, 27);
            txtCantidad.TabIndex = 9;
            txtCantidad.KeyPress += SoloDigitos_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(490, 38);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 8;
            label10.Text = "Cantidad";
            // 
            // txtDisponible
            // 
            txtDisponible.Location = new Point(365, 34);
            txtDisponible.Margin = new Padding(3, 4, 3, 4);
            txtDisponible.Name = "txtDisponible";
            txtDisponible.ReadOnly = true;
            txtDisponible.Size = new Size(91, 27);
            txtDisponible.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(278, 38);
            label9.Name = "label9";
            label9.Size = new Size(81, 20);
            label9.TabIndex = 6;
            label9.Text = "Disponible";
            // 
            // cboSku
            // 
            cboSku.FormattingEnabled = true;
            cboSku.Location = new Point(57, 33);
            cboSku.Margin = new Padding(3, 4, 3, 4);
            cboSku.Name = "cboSku";
            cboSku.Size = new Size(165, 28);
            cboSku.TabIndex = 3;
            cboSku.SelectedIndexChanged += cboSku_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 37);
            label11.Name = "label11";
            label11.Size = new Size(36, 20);
            label11.TabIndex = 2;
            label11.Text = "SKU";
            // 
            // btnQuitarSeleccionado
            // 
            btnQuitarSeleccionado.Location = new Point(723, 332);
            btnQuitarSeleccionado.Margin = new Padding(3, 4, 3, 4);
            btnQuitarSeleccionado.Name = "btnQuitarSeleccionado";
            btnQuitarSeleccionado.Size = new Size(160, 33);
            btnQuitarSeleccionado.TabIndex = 1;
            btnQuitarSeleccionado.Text = "Quitar seleccionado";
            btnQuitarSeleccionado.UseVisualStyleBackColor = true;
            
            // 
            // btnRegistrarOp
            // 
            btnRegistrarOp.Location = new Point(613, 624);
            btnRegistrarOp.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarOp.Name = "btnRegistrarOp";
            btnRegistrarOp.Size = new Size(197, 40);
            btnRegistrarOp.TabIndex = 3;
            btnRegistrarOp.Text = "Registrar OP";
            btnRegistrarOp.UseVisualStyleBackColor = true;
            btnRegistrarOp.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(816, 624);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(91, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader3 });
            listView1.Location = new Point(18, 85);
            listView1.Name = "listView1";
            listView1.Size = new Size(865, 235);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "SKU";
            columnHeader1.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Cantidad";
            columnHeader3.Width = 120;
            // 
            // RegistrarOrdenPreparacionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 677);
            Controls.Add(txtFechaRetiro);
            Controls.Add(btnCancelar);
            Controls.Add(label7);
            Controls.Add(btnRegistrarOp);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrarOrdenPreparacionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Orden de Preparación - Pampazon S.A.";
            FormClosing += RegistrarOrdenPreparacionForm_FormClosing;
            Load += RegistrarOrdenPreparacionForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cboCliente;
        private TextBox txtCuit;
        private Label label2;
        private ComboBox cboDeposito;
        private Label label3;
        private Label label4;
        private RadioButton rbFulfillment;
        private RadioButton rbPaletCerrado;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtDni;
        private TextBox txtNombreTransportista;
        private Label label6;
        private TextBox txtFechaRetiro;
        private Label label7;
        private GroupBox groupBox3;
        private Button btnQuitarSeleccionado;
        private ComboBox cboSku;
        private Label label11;
        private TextBox txtDisponible;
        private Label label9;
        private TextBox txtCantidad;
        private Label label10;
        private Button btnAgregar;
        private Button btnRegistrarOp;
        private Button btnCancelar;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
    }
}