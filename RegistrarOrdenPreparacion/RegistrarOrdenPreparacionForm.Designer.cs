namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    partial class RegistrarOrdenPreparacionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbDatosOrden = new GroupBox();
            lblCliente = new Label();
            cboCliente = new ComboBox();
            lblCuit = new Label();
            txtCuit = new TextBox();
            lblDeposito = new Label();
            cboDeposito = new ComboBox();
            lblModalidad = new Label();
            rbFulfillment = new RadioButton();
            rbPaletCerrado = new RadioButton();
            gbTransportista = new GroupBox();
            textBox2 = new TextBox();
            label2 = new Label();
            lblDni = new Label();
            txtDni = new TextBox();
            gbProductos = new GroupBox();
            lblSku = new Label();
            cboSku = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblDisponible = new Label();
            txtDisponible = new TextBox();
            lblCantidad = new Label();
            txtCantidad = new TextBox();
            btnAgregar = new Button();
            dgvProductos = new DataGridView();
            btnQuitar = new Button();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            gbDatosOrden.SuspendLayout();
            gbTransportista.SuspendLayout();
            gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // gbDatosOrden
            // 
            gbDatosOrden.Controls.Add(lblCliente);
            gbDatosOrden.Controls.Add(cboCliente);
            gbDatosOrden.Controls.Add(lblCuit);
            gbDatosOrden.Controls.Add(txtCuit);
            gbDatosOrden.Controls.Add(lblDeposito);
            gbDatosOrden.Controls.Add(cboDeposito);
            gbDatosOrden.Controls.Add(lblModalidad);
            gbDatosOrden.Controls.Add(rbFulfillment);
            gbDatosOrden.Controls.Add(rbPaletCerrado);
            gbDatosOrden.Location = new Point(10, 9);
            gbDatosOrden.Margin = new Padding(3, 2, 3, 2);
            gbDatosOrden.Name = "gbDatosOrden";
            gbDatosOrden.Padding = new Padding(3, 2, 3, 2);
            gbDatosOrden.Size = new Size(455, 131);
            gbDatosOrden.TabIndex = 0;
            gbDatosOrden.TabStop = false;
            gbDatosOrden.Text = "Datos de la orden";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(13, 26);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(105, 22);
            cboCliente.Margin = new Padding(3, 2, 3, 2);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(210, 23);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(13, 52);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(33, 15);
            lblCuit.TabIndex = 3;
            lblCuit.Text = "CUIT";
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(105, 49);
            txtCuit.Margin = new Padding(3, 2, 3, 2);
            txtCuit.Name = "txtCuit";
            txtCuit.ReadOnly = true;
            txtCuit.Size = new Size(210, 23);
            txtCuit.TabIndex = 4;
            txtCuit.TabStop = false;
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(13, 78);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(54, 15);
            lblDeposito.TabIndex = 5;
            lblDeposito.Text = "Depósito";
            // 
            // cboDeposito
            // 
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Location = new Point(105, 75);
            cboDeposito.Margin = new Padding(3, 2, 3, 2);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(210, 23);
            cboDeposito.TabIndex = 6;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(13, 104);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(64, 15);
            lblModalidad.TabIndex = 8;
            lblModalidad.Text = "Modalidad";
            // 
            // rbFulfillment
            // 
            rbFulfillment.AutoSize = true;
            rbFulfillment.Location = new Point(105, 103);
            rbFulfillment.Margin = new Padding(3, 2, 3, 2);
            rbFulfillment.Name = "rbFulfillment";
            rbFulfillment.Size = new Size(82, 19);
            rbFulfillment.TabIndex = 9;
            rbFulfillment.Text = "Fulfillment";
            rbFulfillment.UseVisualStyleBackColor = true;
            // 
            // rbPaletCerrado
            // 
            rbPaletCerrado.AutoSize = true;
            rbPaletCerrado.Location = new Point(213, 103);
            rbPaletCerrado.Margin = new Padding(3, 2, 3, 2);
            rbPaletCerrado.Name = "rbPaletCerrado";
            rbPaletCerrado.Size = new Size(94, 19);
            rbPaletCerrado.TabIndex = 10;
            rbPaletCerrado.Text = "Palet cerrado";
            rbPaletCerrado.UseVisualStyleBackColor = true;
            // 
            // gbTransportista
            // 
            gbTransportista.Controls.Add(textBox2);
            gbTransportista.Controls.Add(label2);
            gbTransportista.Controls.Add(lblDni);
            gbTransportista.Controls.Add(txtDni);
            gbTransportista.Location = new Point(476, 9);
            gbTransportista.Margin = new Padding(3, 2, 3, 2);
            gbTransportista.Name = "gbTransportista";
            gbTransportista.Padding = new Padding(3, 2, 3, 2);
            gbTransportista.Size = new Size(424, 93);
            gbTransportista.TabIndex = 1;
            gbTransportista.TabStop = false;
            gbTransportista.Text = "Transportista autorizado";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(116, 61);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.MaxLength = 8;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(176, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 63);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(13, 26);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(27, 15);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI";
            lblDni.Click += lblDni_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(116, 26);
            txtDni.Margin = new Padding(3, 2, 3, 2);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(176, 23);
            txtDni.TabIndex = 1;
            txtDni.KeyPress += SoloDigitos_KeyPress;
            // 
            // gbProductos
            // 
            gbProductos.Controls.Add(lblSku);
            gbProductos.Controls.Add(cboSku);
            gbProductos.Controls.Add(lblDescripcion);
            gbProductos.Controls.Add(txtDescripcion);
            gbProductos.Controls.Add(lblDisponible);
            gbProductos.Controls.Add(txtDisponible);
            gbProductos.Controls.Add(lblCantidad);
            gbProductos.Controls.Add(txtCantidad);
            gbProductos.Controls.Add(btnAgregar);
            gbProductos.Controls.Add(dgvProductos);
            gbProductos.Controls.Add(btnQuitar);
            gbProductos.Location = new Point(10, 150);
            gbProductos.Margin = new Padding(3, 2, 3, 2);
            gbProductos.Name = "gbProductos";
            gbProductos.Padding = new Padding(3, 2, 3, 2);
            gbProductos.Size = new Size(889, 214);
            gbProductos.TabIndex = 2;
            gbProductos.TabStop = false;
            gbProductos.Text = "Productos a preparar";
            // 
            // lblSku
            // 
            lblSku.AutoSize = true;
            lblSku.Location = new Point(13, 26);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(28, 15);
            lblSku.TabIndex = 0;
            lblSku.Text = "SKU";
            // 
            // cboSku
            // 
            cboSku.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSku.Enabled = false;
            cboSku.FormattingEnabled = true;
            cboSku.Location = new Point(54, 22);
            cboSku.Margin = new Padding(3, 2, 3, 2);
            cboSku.Name = "cboSku";
            cboSku.Size = new Size(119, 23);
            cboSku.TabIndex = 1;
            cboSku.SelectedIndexChanged += cboSku_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(216, 26);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(298, 22);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(167, 23);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.TabStop = false;
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.Location = new Point(473, 26);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(63, 15);
            lblDisponible.TabIndex = 5;
            lblDisponible.Text = "Disponible";
            // 
            // txtDisponible
            // 
            txtDisponible.Location = new Point(549, 22);
            txtDisponible.Margin = new Padding(3, 2, 3, 2);
            txtDisponible.Name = "txtDisponible";
            txtDisponible.ReadOnly = true;
            txtDisponible.Size = new Size(66, 23);
            txtDisponible.TabIndex = 6;
            txtDisponible.TabStop = false;
            txtDisponible.TextAlign = HorizontalAlignment.Right;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(623, 26);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 7;
            lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Enabled = false;
            txtCantidad.Location = new Point(697, 22);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.MaxLength = 6;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(53, 23);
            txtCantidad.TabIndex = 8;
            txtCantidad.TextAlign = HorizontalAlignment.Right;
            txtCantidad.KeyPress += SoloDigitos_KeyPress;
            // 
            // btnAgregar
            // 
            btnAgregar.Enabled = false;
            btnAgregar.Location = new Point(792, 21);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(84, 24);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(13, 54);
            dgvProductos.Margin = new Padding(3, 2, 3, 2);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(863, 112);
            dgvProductos.TabIndex = 11;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(727, 173);
            btnQuitar.Margin = new Padding(3, 2, 3, 2);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(149, 26);
            btnQuitar.TabIndex = 12;
            btnQuitar.Text = "Quitar seleccionado";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(670, 375);
            btnRegistrar.Margin = new Padding(3, 2, 3, 2);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(114, 28);
            btnRegistrar.TabIndex = 3;
            btnRegistrar.Text = "Registrar OP";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(793, 375);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 28);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(476, 115);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Fecha de Retiro";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(592, 112);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.MaxLength = 8;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 23);
            textBox1.TabIndex = 1;
            // 
            // RegistrarOrdenPreparacionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 412);
            Controls.Add(textBox1);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(btnRegistrar);
            Controls.Add(gbProductos);
            Controls.Add(gbTransportista);
            Controls.Add(gbDatosOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "RegistrarOrdenPreparacionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Orden de Preparación - Pampazon S.A.";
            FormClosing += RegistrarOrdenPreparacionForm_FormClosing;
            Load += RegistrarOrdenPreparacionForm_Load;
            gbDatosOrden.ResumeLayout(false);
            gbDatosOrden.PerformLayout();
            gbTransportista.ResumeLayout(false);
            gbTransportista.PerformLayout();
            gbProductos.ResumeLayout(false);
            gbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbDatosOrden;
        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblCuit;
        private TextBox txtCuit;
        private Label lblDeposito;
        private ComboBox cboDeposito;
        private Label lblModalidad;
        private RadioButton rbFulfillment;
        private RadioButton rbPaletCerrado;
        private GroupBox gbTransportista;
        private Label lblDni;
        private TextBox txtDni;
        private GroupBox gbProductos;
        private Label lblSku;
        private ComboBox cboSku;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblDisponible;
        private TextBox txtDisponible;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Button btnAgregar;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colSku;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colDisponible;
        private Button btnQuitar;
        private Button btnRegistrar;
        private Button btnCancelar;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
    }
}