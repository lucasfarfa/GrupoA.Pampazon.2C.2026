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
            txtCuitCliente = new TextBox();
            label2 = new Label();
            cboCliente = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtNombreTransportista = new TextBox();
            label6 = new Label();
            txtDniTransportista = new TextBox();
            label5 = new Label();
            txtFechaRetiro = new TextBox();
            label7 = new Label();
            groupBox3 = new GroupBox();
            lblDisponible = new Label();
            listDetalleAgregado = new ListView();
            columnSKU = new ColumnHeader();
            columnDescripcion = new ColumnHeader();
            columnCantidad = new ColumnHeader();
            btnAgregar = new Button();
            txtCantidad = new TextBox();
            label10 = new Label();
            label9 = new Label();
            cboSku = new ComboBox();
            label11 = new Label();
            btnQuitarSeleccionado = new Button();
            btnRegistrarOp = new Button();
            btnCancelar = new Button();
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
            groupBox1.Controls.Add(txtCuitCliente);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboCliente);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la orden";
            // 
            // rbPaletCerrado
            // 
            rbPaletCerrado.AutoSize = true;
            rbPaletCerrado.Location = new Point(264, 112);
            rbPaletCerrado.Name = "rbPaletCerrado";
            rbPaletCerrado.Size = new Size(94, 19);
            rbPaletCerrado.TabIndex = 8;
            rbPaletCerrado.TabStop = true;
            rbPaletCerrado.Text = "Palet cerrado";
            rbPaletCerrado.UseVisualStyleBackColor = true;
            // 
            // rbFulfillment
            // 
            rbFulfillment.AutoSize = true;
            rbFulfillment.Location = new Point(150, 112);
            rbFulfillment.Name = "rbFulfillment";
            rbFulfillment.Size = new Size(82, 19);
            rbFulfillment.TabIndex = 7;
            rbFulfillment.TabStop = true;
            rbFulfillment.Text = "Fulfillment";
            rbFulfillment.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 115);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 6;
            label4.Text = "Modalidad";
            // 
            // cboDeposito
            // 
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Location = new Point(150, 80);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(218, 23);
            cboDeposito.TabIndex = 5;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 83);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 4;
            label3.Text = "Depósito";
            // 
            // txtCuitCliente
            // 
            txtCuitCliente.Location = new Point(150, 50);
            txtCuitCliente.Name = "txtCuitCliente";
            txtCuitCliente.ReadOnly = true;
            txtCuitCliente.Size = new Size(218, 23);
            txtCuitCliente.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 53);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 2;
            label2.Text = "CUIT";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(150, 20);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(218, 23);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 23);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNombreTransportista);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtDniTransportista);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(427, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(367, 101);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Transportista autorizado";
            // 
            // txtNombreTransportista
            // 
            txtNombreTransportista.Location = new Point(120, 55);
            txtNombreTransportista.Name = "txtNombreTransportista";
            txtNombreTransportista.Size = new Size(238, 23);
            txtNombreTransportista.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 58);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 2;
            label6.Text = "Nombre";
            // 
            // txtDniTransportista
            // 
            txtDniTransportista.Location = new Point(120, 20);
            txtDniTransportista.Name = "txtDniTransportista";
            txtDniTransportista.Size = new Size(238, 23);
            txtDniTransportista.TabIndex = 1;
            txtDniTransportista.KeyPress += SoloDigitos_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 23);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 0;
            label5.Text = "DNI";
            // 
            // txtFechaRetiro
            // 
            txtFechaRetiro.Location = new Point(547, 130);
            txtFechaRetiro.Name = "txtFechaRetiro";
            txtFechaRetiro.Size = new Size(238, 23);
            txtFechaRetiro.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(427, 136);
            label7.Name = "label7";
            label7.Size = new Size(88, 15);
            label7.TabIndex = 4;
            label7.Text = "Fecha de Retiro";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblDisponible);
            groupBox3.Controls.Add(listDetalleAgregado);
            groupBox3.Controls.Add(btnAgregar);
            groupBox3.Controls.Add(txtCantidad);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(cboSku);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(btnQuitarSeleccionado);
            groupBox3.Location = new Point(12, 175);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(781, 280);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Productos a preparar";
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.Location = new Point(374, 28);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(42, 15);
            lblDisponible.TabIndex = 9;
            lblDisponible.Text = "XXXXX";
            // 
            // listDetalleAgregado
            // 
            listDetalleAgregado.Columns.AddRange(new ColumnHeader[] { columnSKU, columnDescripcion, columnCantidad });
            listDetalleAgregado.Location = new Point(16, 64);
            listDetalleAgregado.Margin = new Padding(3, 2, 3, 2);
            listDetalleAgregado.Name = "listDetalleAgregado";
            listDetalleAgregado.Size = new Size(757, 177);
            listDetalleAgregado.TabIndex = 11;
            listDetalleAgregado.UseCompatibleStateImageBehavior = false;
            listDetalleAgregado.View = View.Details;
            listDetalleAgregado.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnSKU
            // 
            columnSKU.Text = "SKU";
            columnSKU.Width = 100;
            // 
            // columnDescripcion
            // 
            columnDescripcion.Text = "Descripción";
            columnDescripcion.Width = 200;
            // 
            // columnCantidad
            // 
            columnCantidad.Text = "Cantidad";
            columnCantidad.Width = 120;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(671, 21);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(102, 27);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(544, 25);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(80, 23);
            txtCantidad.TabIndex = 9;
            txtCantidad.KeyPress += SoloDigitos_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(484, 28);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 8;
            label10.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(298, 28);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 6;
            label9.Text = "Disponible";
            // 
            // cboSku
            // 
            cboSku.FormattingEnabled = true;
            cboSku.Location = new Point(50, 25);
            cboSku.Name = "cboSku";
            cboSku.Size = new Size(145, 23);
            cboSku.TabIndex = 3;
            cboSku.SelectedIndexChanged += cboSku_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 28);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 2;
            label11.Text = "SKU";
            // 
            // btnQuitarSeleccionado
            // 
            btnQuitarSeleccionado.Location = new Point(633, 249);
            btnQuitarSeleccionado.Name = "btnQuitarSeleccionado";
            btnQuitarSeleccionado.Size = new Size(140, 25);
            btnQuitarSeleccionado.TabIndex = 1;
            btnQuitarSeleccionado.Text = "Quitar seleccionado";
            btnQuitarSeleccionado.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarOp
            // 
            btnRegistrarOp.Location = new Point(536, 468);
            btnRegistrarOp.Name = "btnRegistrarOp";
            btnRegistrarOp.Size = new Size(172, 30);
            btnRegistrarOp.TabIndex = 3;
            btnRegistrarOp.Text = "Registrar OP";
            btnRegistrarOp.UseVisualStyleBackColor = true;
            btnRegistrarOp.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(714, 468);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarOrdenPreparacionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 508);
            Controls.Add(txtFechaRetiro);
            Controls.Add(btnCancelar);
            Controls.Add(label7);
            Controls.Add(btnRegistrarOp);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
        private TextBox txtCuitCliente;
        private Label label2;
        private ComboBox cboDeposito;
        private Label label3;
        private Label label4;
        private RadioButton rbFulfillment;
        private RadioButton rbPaletCerrado;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtDniTransportista;
        private TextBox txtNombreTransportista;
        private Label label6;
        private TextBox txtFechaRetiro;
        private Label label7;
        private GroupBox groupBox3;
        private Button btnQuitarSeleccionado;
        private ComboBox cboSku;
        private Label label11;
        private Label label9;
        private TextBox txtCantidad;
        private Label label10;
        private Button btnAgregar;
        private Button btnRegistrarOp;
        private Button btnCancelar;
        private ListView listDetalleAgregado;
        private ColumnHeader columnSKU;
        private ColumnHeader columnCantidad;
        private Label lblDisponible;
        private ColumnHeader columnDescripcion;
    }
}