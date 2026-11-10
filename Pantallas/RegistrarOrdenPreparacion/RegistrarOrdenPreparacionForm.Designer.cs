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
            grpDatosOrden = new GroupBox();
            rbPaletCerrado = new RadioButton();
            rbFulfillment = new RadioButton();
            lblModalidad = new Label();
            cboDeposito = new ComboBox();
            lblDeposito = new Label();
            txtCuitCliente = new TextBox();
            lblCuit = new Label();
            cboCliente = new ComboBox();
            lblCliente = new Label();
            grpTransportista = new GroupBox();
            txtNombreTransportista = new TextBox();
            lblNombre = new Label();
            txtDniTransportista = new TextBox();
            lblDni = new Label();
            txtFechaRetiro = new TextBox();
            lblFechaRetiro = new Label();
            grpProductos = new GroupBox();
            lblDisponible = new Label();
            listDetalleAgregado = new ListView();
            columnSKU = new ColumnHeader();
            columnDescripcion = new ColumnHeader();
            columnCantidad = new ColumnHeader();
            btnAgregar = new Button();
            txtCantidad = new TextBox();
            lblCantidad = new Label();
            lblDisponibleTitulo = new Label();
            cboSku = new ComboBox();
            lblSku = new Label();
            btnQuitarSeleccionado = new Button();
            btnRegistrarOp = new Button();
            btnCancelar = new Button();
            grpDatosOrden.SuspendLayout();
            grpTransportista.SuspendLayout();
            grpProductos.SuspendLayout();
            SuspendLayout();
            // 
            // grpDatosOrden
            // 
            grpDatosOrden.Controls.Add(rbPaletCerrado);
            grpDatosOrden.Controls.Add(rbFulfillment);
            grpDatosOrden.Controls.Add(lblModalidad);
            grpDatosOrden.Controls.Add(cboDeposito);
            grpDatosOrden.Controls.Add(lblDeposito);
            grpDatosOrden.Controls.Add(txtCuitCliente);
            grpDatosOrden.Controls.Add(lblCuit);
            grpDatosOrden.Controls.Add(cboCliente);
            grpDatosOrden.Controls.Add(lblCliente);
            grpDatosOrden.Location = new Point(12, 12);
            grpDatosOrden.Name = "grpDatosOrden";
            grpDatosOrden.Size = new Size(391, 150);
            grpDatosOrden.TabIndex = 0;
            grpDatosOrden.TabStop = false;
            grpDatosOrden.Text = "Datos de la orden";
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
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(15, 115);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(64, 15);
            lblModalidad.TabIndex = 6;
            lblModalidad.Text = "Modalidad";
            // 
            // cboDeposito
            // 
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Location = new Point(150, 80);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(218, 23);
            cboDeposito.TabIndex = 5;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(15, 83);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(54, 15);
            lblDeposito.TabIndex = 4;
            lblDeposito.Text = "Depósito";
            // 
            // txtCuitCliente
            // 
            txtCuitCliente.Location = new Point(150, 50);
            txtCuitCliente.Name = "txtCuitCliente";
            txtCuitCliente.ReadOnly = true;
            txtCuitCliente.Size = new Size(218, 23);
            txtCuitCliente.TabIndex = 3;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(15, 53);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(33, 15);
            lblCuit.TabIndex = 2;
            lblCuit.Text = "CUIT";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(150, 20);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(218, 23);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(15, 23);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // grpTransportista
            // 
            grpTransportista.Controls.Add(txtNombreTransportista);
            grpTransportista.Controls.Add(lblNombre);
            grpTransportista.Controls.Add(txtDniTransportista);
            grpTransportista.Controls.Add(lblDni);
            grpTransportista.Location = new Point(427, 12);
            grpTransportista.Name = "grpTransportista";
            grpTransportista.Size = new Size(367, 101);
            grpTransportista.TabIndex = 1;
            grpTransportista.TabStop = false;
            grpTransportista.Text = "Transportista autorizado";
            // 
            // txtNombreTransportista
            // 
            txtNombreTransportista.Location = new Point(120, 55);
            txtNombreTransportista.Name = "txtNombreTransportista";
            txtNombreTransportista.Size = new Size(238, 23);
            txtNombreTransportista.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtDniTransportista
            // 
            txtDniTransportista.Location = new Point(120, 20);
            txtDniTransportista.Name = "txtDniTransportista";
            txtDniTransportista.Size = new Size(238, 23);
            txtDniTransportista.TabIndex = 1;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(15, 23);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(27, 15);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI";
            // 
            // txtFechaRetiro
            // 
            txtFechaRetiro.Location = new Point(547, 130);
            txtFechaRetiro.Name = "txtFechaRetiro";
            txtFechaRetiro.Size = new Size(238, 23);
            txtFechaRetiro.TabIndex = 5;
            // 
            // lblFechaRetiro
            // 
            lblFechaRetiro.AutoSize = true;
            lblFechaRetiro.Location = new Point(427, 136);
            lblFechaRetiro.Name = "lblFechaRetiro";
            lblFechaRetiro.Size = new Size(88, 15);
            lblFechaRetiro.TabIndex = 4;
            lblFechaRetiro.Text = "Fecha de Retiro";
            // 
            // grpProductos
            // 
            grpProductos.Controls.Add(lblDisponible);
            grpProductos.Controls.Add(listDetalleAgregado);
            grpProductos.Controls.Add(btnAgregar);
            grpProductos.Controls.Add(txtCantidad);
            grpProductos.Controls.Add(lblCantidad);
            grpProductos.Controls.Add(lblDisponibleTitulo);
            grpProductos.Controls.Add(cboSku);
            grpProductos.Controls.Add(lblSku);
            grpProductos.Controls.Add(btnQuitarSeleccionado);
            grpProductos.Location = new Point(12, 175);
            grpProductos.Name = "grpProductos";
            grpProductos.Size = new Size(781, 280);
            grpProductos.TabIndex = 2;
            grpProductos.TabStop = false;
            grpProductos.Text = "Productos a preparar";
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
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(484, 28);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad";
            // 
            // lblDisponibleTitulo
            // 
            lblDisponibleTitulo.AutoSize = true;
            lblDisponibleTitulo.Location = new Point(298, 28);
            lblDisponibleTitulo.Name = "lblDisponibleTitulo";
            lblDisponibleTitulo.Size = new Size(63, 15);
            lblDisponibleTitulo.TabIndex = 6;
            lblDisponibleTitulo.Text = "Disponible";
            // 
            // cboSku
            // 
            cboSku.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSku.FormattingEnabled = true;
            cboSku.Location = new Point(50, 25);
            cboSku.Name = "cboSku";
            cboSku.Size = new Size(145, 23);
            cboSku.TabIndex = 3;
            cboSku.SelectedIndexChanged += cboSku_SelectedIndexChanged;
            // 
            // lblSku
            // 
            lblSku.AutoSize = true;
            lblSku.Location = new Point(15, 28);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(28, 15);
            lblSku.TabIndex = 2;
            lblSku.Text = "SKU";
            // 
            // btnQuitarSeleccionado
            // 
            btnQuitarSeleccionado.Location = new Point(633, 249);
            btnQuitarSeleccionado.Name = "btnQuitarSeleccionado";
            btnQuitarSeleccionado.Size = new Size(140, 25);
            btnQuitarSeleccionado.TabIndex = 1;
            btnQuitarSeleccionado.Text = "Quitar seleccionado";
            btnQuitarSeleccionado.UseVisualStyleBackColor = true;
            btnQuitarSeleccionado.Click += btnQuitarSeleccionado_Click;
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
            Controls.Add(lblFechaRetiro);
            Controls.Add(btnRegistrarOp);
            Controls.Add(grpProductos);
            Controls.Add(grpTransportista);
            Controls.Add(grpDatosOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrarOrdenPreparacionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Orden de Preparación - Pampazon S.A.";
            FormClosing += RegistrarOrdenPreparacionForm_FormClosing;
            Load += RegistrarOrdenPreparacionForm_Load;
            grpDatosOrden.ResumeLayout(false);
            grpDatosOrden.PerformLayout();
            grpTransportista.ResumeLayout(false);
            grpTransportista.PerformLayout();
            grpProductos.ResumeLayout(false);
            grpProductos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDatosOrden;
        private Label lblCliente;
        private ComboBox cboCliente;
        private TextBox txtCuitCliente;
        private Label lblCuit;
        private ComboBox cboDeposito;
        private Label lblDeposito;
        private Label lblModalidad;
        private RadioButton rbFulfillment;
        private RadioButton rbPaletCerrado;
        private GroupBox grpTransportista;
        private Label lblDni;
        private TextBox txtDniTransportista;
        private TextBox txtNombreTransportista;
        private Label lblNombre;
        private TextBox txtFechaRetiro;
        private Label lblFechaRetiro;
        private GroupBox grpProductos;
        private Button btnQuitarSeleccionado;
        private ComboBox cboSku;
        private Label lblSku;
        private Label lblDisponibleTitulo;
        private TextBox txtCantidad;
        private Label lblCantidad;
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