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
            lblDni = new Label();
            txtDni = new TextBox();
            lblPatente = new Label();
            txtPatente = new TextBox();
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
            gbDatosOrden.Location = new Point(12, 12);
            gbDatosOrden.Name = "gbDatosOrden";
            gbDatosOrden.Size = new Size(520, 175);
            gbDatosOrden.TabIndex = 0;
            gbDatosOrden.TabStop = false;
            gbDatosOrden.Text = "Datos de la orden";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(15, 34);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(65, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente *";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(120, 30);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(240, 28);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(15, 69);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(40, 20);
            lblCuit.TabIndex = 3;
            lblCuit.Text = "CUIT";
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(120, 65);
            txtCuit.Name = "txtCuit";
            txtCuit.ReadOnly = true;
            txtCuit.Size = new Size(180, 27);
            txtCuit.TabIndex = 4;
            txtCuit.TabStop = false;
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(15, 104);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(80, 20);
            lblDeposito.TabIndex = 5;
            lblDeposito.Text = "Depósito *";
            // 
            // cboDeposito
            // 
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Location = new Point(120, 100);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(240, 28);
            cboDeposito.TabIndex = 6;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(15, 139);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(92, 20);
            lblModalidad.TabIndex = 8;
            lblModalidad.Text = "Modalidad *";
            // 
            // rbFulfillment
            // 
            rbFulfillment.AutoSize = true;
            rbFulfillment.Location = new Point(120, 137);
            rbFulfillment.Name = "rbFulfillment";
            rbFulfillment.Size = new Size(100, 24);
            rbFulfillment.TabIndex = 9;
            rbFulfillment.Text = "Fulfillment";
            rbFulfillment.UseVisualStyleBackColor = true;
            // 
            // rbPaletCerrado
            // 
            rbPaletCerrado.AutoSize = true;
            rbPaletCerrado.Location = new Point(240, 137);
            rbPaletCerrado.Name = "rbPaletCerrado";
            rbPaletCerrado.Size = new Size(117, 24);
            rbPaletCerrado.TabIndex = 10;
            rbPaletCerrado.Text = "Palet cerrado";
            rbPaletCerrado.UseVisualStyleBackColor = true;
            // 
            // gbTransportista
            // 
            gbTransportista.Controls.Add(lblDni);
            gbTransportista.Controls.Add(txtDni);
            gbTransportista.Controls.Add(lblPatente);
            gbTransportista.Controls.Add(txtPatente);
            gbTransportista.Location = new Point(544, 12);
            gbTransportista.Name = "gbTransportista";
            gbTransportista.Size = new Size(484, 175);
            gbTransportista.TabIndex = 1;
            gbTransportista.TabStop = false;
            gbTransportista.Text = "Transportista autorizado";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(15, 34);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(45, 20);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI *";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(100, 30);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(200, 27);
            txtDni.TabIndex = 1;
            txtDni.KeyPress += SoloDigitos_KeyPress;
            // 
            // lblPatente
            // 
            lblPatente.AutoSize = true;
            lblPatente.Location = new Point(15, 69);
            lblPatente.Name = "lblPatente";
            lblPatente.Size = new Size(68, 20);
            lblPatente.TabIndex = 3;
            lblPatente.Text = "Patente *";
            // 
            // txtPatente
            // 
            txtPatente.CharacterCasing = CharacterCasing.Upper;
            txtPatente.Location = new Point(100, 65);
            txtPatente.MaxLength = 7;
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(200, 27);
            txtPatente.TabIndex = 4;
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
            gbProductos.Location = new Point(12, 200);
            gbProductos.Name = "gbProductos";
            gbProductos.Size = new Size(1016, 285);
            gbProductos.TabIndex = 2;
            gbProductos.TabStop = false;
            gbProductos.Text = "Productos a preparar";
            // 
            // lblSku
            // 
            lblSku.AutoSize = true;
            lblSku.Location = new Point(15, 34);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(46, 20);
            lblSku.TabIndex = 0;
            lblSku.Text = "SKU *";
            // 
            // cboSku
            // 
            cboSku.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSku.Enabled = false;
            cboSku.FormattingEnabled = true;
            cboSku.Location = new Point(62, 30);
            cboSku.Name = "cboSku";
            cboSku.Size = new Size(135, 28);
            cboSku.TabIndex = 1;
            cboSku.SelectedIndexChanged += cboSku_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(247, 34);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(87, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(341, 30);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(190, 27);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.TabStop = false;
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.Location = new Point(541, 34);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(81, 20);
            lblDisponible.TabIndex = 5;
            lblDisponible.Text = "Disponible";
            // 
            // txtDisponible
            // 
            txtDisponible.Location = new Point(627, 30);
            txtDisponible.Name = "txtDisponible";
            txtDisponible.ReadOnly = true;
            txtDisponible.Size = new Size(75, 27);
            txtDisponible.TabIndex = 6;
            txtDisponible.TabStop = false;
            txtDisponible.TextAlign = HorizontalAlignment.Right;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(712, 34);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(79, 20);
            lblCantidad.TabIndex = 7;
            lblCantidad.Text = "Cantidad *";
            // 
            // txtCantidad
            // 
            txtCantidad.Enabled = false;
            txtCantidad.Location = new Point(797, 30);
            txtCantidad.MaxLength = 6;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(60, 27);
            txtCantidad.TabIndex = 8;
            txtCantidad.TextAlign = HorizontalAlignment.Right;
            txtCantidad.KeyPress += SoloDigitos_KeyPress;
            // 
            // btnAgregar
            // 
            btnAgregar.Enabled = false;
            btnAgregar.Location = new Point(905, 28);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(96, 32);
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
            dgvProductos.Location = new Point(15, 72);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(986, 150);
            dgvProductos.TabIndex = 11;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(831, 231);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(170, 34);
            btnQuitar.TabIndex = 12;
            btnQuitar.Text = "Quitar seleccionado";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(766, 500);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 38);
            btnRegistrar.TabIndex = 3;
            btnRegistrar.Text = "Registrar OP";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(906, 500);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 38);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarOrdenPreparacionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 550);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrar);
            Controls.Add(gbProductos);
            Controls.Add(gbTransportista);
            Controls.Add(gbDatosOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
        private Label lblPatente;
        private TextBox txtPatente;
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
    }
}