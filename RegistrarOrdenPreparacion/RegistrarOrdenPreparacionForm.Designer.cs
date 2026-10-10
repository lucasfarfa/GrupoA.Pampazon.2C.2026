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
            lblNum11 = new Label();
            lblCuit = new Label();
            txtCuit = new TextBox();
            lblDeposito = new Label();
            cboDeposito = new ComboBox();
            lblNum12 = new Label();
            lblModalidad = new Label();
            rbFulfillment = new RadioButton();
            rbPaletCerrado = new RadioButton();
            lblNum13 = new Label();
            gbTransportista = new GroupBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblNum14 = new Label();
            lblPatente = new Label();
            txtPatente = new TextBox();
            lblNum15 = new Label();
            gbProductos = new GroupBox();
            lblSku = new Label();
            cboSku = new ComboBox();
            lblNum16 = new Label();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblDisponible = new Label();
            txtDisponible = new TextBox();
            lblCantidad = new Label();
            txtCantidad = new TextBox();
            lblNum17 = new Label();
            btnAgregar = new Button();
            dgvProductos = new DataGridView();
            colSku = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colDisponible = new DataGridViewTextBoxColumn();
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
            gbDatosOrden.Controls.Add(lblNum11);
            gbDatosOrden.Controls.Add(lblCuit);
            gbDatosOrden.Controls.Add(txtCuit);
            gbDatosOrden.Controls.Add(lblDeposito);
            gbDatosOrden.Controls.Add(cboDeposito);
            gbDatosOrden.Controls.Add(lblNum12);
            gbDatosOrden.Controls.Add(lblModalidad);
            gbDatosOrden.Controls.Add(rbFulfillment);
            gbDatosOrden.Controls.Add(rbPaletCerrado);
            gbDatosOrden.Controls.Add(lblNum13);
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
            lblCliente.Size = new Size(64, 20);
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
            // lblNum11
            // 
            lblNum11.BackColor = Color.Firebrick;
            lblNum11.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum11.ForeColor = Color.White;
            lblNum11.Location = new Point(368, 34);
            lblNum11.Name = "lblNum11";
            lblNum11.Size = new Size(36, 20);
            lblNum11.TabIndex = 2;
            lblNum11.Text = "1.1";
            lblNum11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(15, 69);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(38, 20);
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
            lblDeposito.Size = new Size(76, 20);
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
            // lblNum12
            // 
            lblNum12.BackColor = Color.Firebrick;
            lblNum12.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum12.ForeColor = Color.White;
            lblNum12.Location = new Point(368, 104);
            lblNum12.Name = "lblNum12";
            lblNum12.Size = new Size(36, 20);
            lblNum12.TabIndex = 7;
            lblNum12.Text = "1.2";
            lblNum12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(15, 139);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(87, 20);
            lblModalidad.TabIndex = 8;
            lblModalidad.Text = "Modalidad *";
            // 
            // rbFulfillment
            // 
            rbFulfillment.AutoSize = true;
            rbFulfillment.Location = new Point(120, 137);
            rbFulfillment.Name = "rbFulfillment";
            rbFulfillment.Size = new Size(98, 24);
            rbFulfillment.TabIndex = 9;
            rbFulfillment.Text = "Fulfillment";
            rbFulfillment.UseVisualStyleBackColor = true;
            // 
            // rbPaletCerrado
            // 
            rbPaletCerrado.AutoSize = true;
            rbPaletCerrado.Location = new Point(240, 137);
            rbPaletCerrado.Name = "rbPaletCerrado";
            rbPaletCerrado.Size = new Size(116, 24);
            rbPaletCerrado.TabIndex = 10;
            rbPaletCerrado.Text = "Palet cerrado";
            rbPaletCerrado.UseVisualStyleBackColor = true;
            // 
            // lblNum13
            // 
            lblNum13.BackColor = Color.Firebrick;
            lblNum13.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum13.ForeColor = Color.White;
            lblNum13.Location = new Point(372, 139);
            lblNum13.Name = "lblNum13";
            lblNum13.Size = new Size(36, 20);
            lblNum13.TabIndex = 11;
            lblNum13.Text = "1.3";
            lblNum13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbTransportista
            // 
            gbTransportista.Controls.Add(lblDni);
            gbTransportista.Controls.Add(txtDni);
            gbTransportista.Controls.Add(lblNum14);
            gbTransportista.Controls.Add(lblPatente);
            gbTransportista.Controls.Add(txtPatente);
            gbTransportista.Controls.Add(lblNum15);
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
            // lblNum14
            // 
            lblNum14.BackColor = Color.Firebrick;
            lblNum14.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum14.ForeColor = Color.White;
            lblNum14.Location = new Point(308, 34);
            lblNum14.Name = "lblNum14";
            lblNum14.Size = new Size(36, 20);
            lblNum14.TabIndex = 2;
            lblNum14.Text = "1.4";
            lblNum14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPatente
            // 
            lblPatente.AutoSize = true;
            lblPatente.Location = new Point(15, 69);
            lblPatente.Name = "lblPatente";
            lblPatente.Size = new Size(71, 20);
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
            // lblNum15
            // 
            lblNum15.BackColor = Color.Firebrick;
            lblNum15.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum15.ForeColor = Color.White;
            lblNum15.Location = new Point(308, 69);
            lblNum15.Name = "lblNum15";
            lblNum15.Size = new Size(36, 20);
            lblNum15.TabIndex = 5;
            lblNum15.Text = "1.5";
            lblNum15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbProductos
            // 
            gbProductos.Controls.Add(lblSku);
            gbProductos.Controls.Add(cboSku);
            gbProductos.Controls.Add(lblNum16);
            gbProductos.Controls.Add(lblDescripcion);
            gbProductos.Controls.Add(txtDescripcion);
            gbProductos.Controls.Add(lblDisponible);
            gbProductos.Controls.Add(txtDisponible);
            gbProductos.Controls.Add(lblCantidad);
            gbProductos.Controls.Add(txtCantidad);
            gbProductos.Controls.Add(lblNum17);
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
            // lblNum16
            // 
            lblNum16.BackColor = Color.Firebrick;
            lblNum16.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum16.ForeColor = Color.White;
            lblNum16.Location = new Point(203, 34);
            lblNum16.Name = "lblNum16";
            lblNum16.Size = new Size(36, 20);
            lblNum16.TabIndex = 2;
            lblNum16.Text = "1.6";
            lblNum16.TextAlign = ContentAlignment.MiddleCenter;
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
            lblDisponible.Size = new Size(80, 20);
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
            // lblNum17
            // 
            lblNum17.BackColor = Color.Firebrick;
            lblNum17.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNum17.ForeColor = Color.White;
            lblNum17.Location = new Point(863, 34);
            lblNum17.Name = "lblNum17";
            lblNum17.Size = new Size(36, 20);
            lblNum17.TabIndex = 9;
            lblNum17.Text = "1.7";
            lblNum17.TextAlign = ContentAlignment.MiddleCenter;
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
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colSku, colDescripcion, colCantidad, colDisponible });
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
            // colSku
            // 
            colSku.DataPropertyName = "Sku";
            colSku.FillWeight = 20F;
            colSku.HeaderText = "SKU";
            colSku.MinimumWidth = 6;
            colSku.Name = "colSku";
            colSku.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.FillWeight = 45F;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 6;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.FillWeight = 15F;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 6;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colDisponible
            // 
            colDisponible.DataPropertyName = "Disponible";
            colDisponible.FillWeight = 20F;
            colDisponible.HeaderText = "Disponible";
            colDisponible.MinimumWidth = 6;
            colDisponible.Name = "colDisponible";
            colDisponible.ReadOnly = true;
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
        private Label lblNum11;
        private Label lblCuit;
        private TextBox txtCuit;
        private Label lblDeposito;
        private ComboBox cboDeposito;
        private Label lblNum12;
        private Label lblModalidad;
        private RadioButton rbFulfillment;
        private RadioButton rbPaletCerrado;
        private Label lblNum13;
        private GroupBox gbTransportista;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblNum14;
        private Label lblPatente;
        private TextBox txtPatente;
        private Label lblNum15;
        private GroupBox gbProductos;
        private Label lblSku;
        private ComboBox cboSku;
        private Label lblNum16;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblDisponible;
        private TextBox txtDisponible;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Label lblNum17;
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