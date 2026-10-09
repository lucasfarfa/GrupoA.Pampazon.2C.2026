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
            lblTotalBultosValor = new Label();
            lblTotalBultos = new Label();
            lvwOrdenes = new ListView();
            ColNroOrdenEntrega = new ColumnHeader();
            ColNOp = new ColumnHeader();
            ColCliente = new ColumnHeader();
            ColBultos = new ColumnHeader();
            btnConfirmarDespacho = new Button();
            btnCancelar = new Button();
            grpTransportista = new GroupBox();
            txtPatente = new TextBox();
            txtDni = new TextBox();
            btnBuscarOrdenes = new Button();
            lblPatente = new Label();
            lblDni = new Label();
            lblDepósito = new Label();
            lblNroRemito = new Label();
            txtNroRemito = new TextBox();
            DepositoLbl = new Label();
            grpOrdenesPendientes.SuspendLayout();
            grpTransportista.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrdenesPendientes
            // 
            grpOrdenesPendientes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpOrdenesPendientes.Controls.Add(lblTotalBultosValor);
            grpOrdenesPendientes.Controls.Add(lblTotalBultos);
            grpOrdenesPendientes.Controls.Add(lvwOrdenes);
            grpOrdenesPendientes.Font = new Font("Segoe UI", 9F);
            grpOrdenesPendientes.Location = new Point(12, 177);
            grpOrdenesPendientes.Name = "grpOrdenesPendientes";
            grpOrdenesPendientes.Size = new Size(740, 351);
            grpOrdenesPendientes.TabIndex = 0;
            grpOrdenesPendientes.TabStop = false;
            grpOrdenesPendientes.Text = "Órdenes de entrega pendientes del transportista";
            grpOrdenesPendientes.Enter += grpOrdenesPendientes_Enter;
            // 
            // lblTotalBultosValor
            // 
            lblTotalBultosValor.Font = new Font("Segoe UI", 9F);
            lblTotalBultosValor.ForeColor = SystemColors.ControlText;
            lblTotalBultosValor.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalBultosValor.Location = new Point(615, 325);
            lblTotalBultosValor.Name = "lblTotalBultosValor";
            lblTotalBultosValor.Size = new Size(102, 23);
            lblTotalBultosValor.TabIndex = 10;
            lblTotalBultosValor.Text = "9";
            lblTotalBultosValor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBultos
            // 
            lblTotalBultos.Font = new Font("Segoe UI", 9F);
            lblTotalBultos.Location = new Point(507, 325);
            lblTotalBultos.Name = "lblTotalBultos";
            lblTotalBultos.Size = new Size(102, 23);
            lblTotalBultos.TabIndex = 9;
            lblTotalBultos.Text = "Total bultos:";
            lblTotalBultos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lvwOrdenes
            // 
            lvwOrdenes.Columns.AddRange(new ColumnHeader[] { ColNroOrdenEntrega, ColNOp, ColCliente, ColBultos });
            lvwOrdenes.Font = new Font("Segoe UI", 9F);
            lvwOrdenes.FullRowSelect = true;
            lvwOrdenes.Location = new Point(3, 26);
            lvwOrdenes.MultiSelect = false;
            lvwOrdenes.Name = "lvwOrdenes";
            lvwOrdenes.Size = new Size(714, 285);
            lvwOrdenes.TabIndex = 0;
            lvwOrdenes.UseCompatibleStateImageBehavior = false;
            lvwOrdenes.View = View.Details;
            lvwOrdenes.SelectedIndexChanged += lvwOrdenes_SelectedIndexChanged;
            // 
            // ColNroOrdenEntrega
            // 
            ColNroOrdenEntrega.Text = "N° OE";
            ColNroOrdenEntrega.Width = 80;
            // 
            // ColNOp
            // 
            ColNOp.Text = "N°OP";
            ColNOp.Width = 80;
            // 
            // ColCliente
            // 
            ColCliente.Text = "Cliente";
            ColCliente.Width = 400;
            // 
            // ColBultos
            // 
            ColBultos.Text = "Bultos";
            ColBultos.TextAlign = HorizontalAlignment.Right;
            // 
            // btnConfirmarDespacho
            // 
            btnConfirmarDespacho.AutoSize = true;
            btnConfirmarDespacho.Location = new Point(342, 564);
            btnConfirmarDespacho.Name = "btnConfirmarDespacho";
            btnConfirmarDespacho.Size = new Size(258, 30);
            btnConfirmarDespacho.TabIndex = 4;
            btnConfirmarDespacho.Text = "Confirmar despacho y emitir remito";
            btnConfirmarDespacho.UseVisualStyleBackColor = true;
            btnConfirmarDespacho.Click += btnConfirmarDespacho_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(623, 567);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(123, 27);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpTransportista
            // 
            grpTransportista.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpTransportista.Controls.Add(txtPatente);
            grpTransportista.Controls.Add(txtDni);
            grpTransportista.Controls.Add(btnBuscarOrdenes);
            grpTransportista.Controls.Add(lblPatente);
            grpTransportista.Controls.Add(lblDni);
            grpTransportista.Font = new Font("Segoe UI", 9F);
            grpTransportista.Location = new Point(12, 48);
            grpTransportista.Name = "grpTransportista";
            grpTransportista.Size = new Size(740, 113);
            grpTransportista.TabIndex = 2;
            grpTransportista.TabStop = false;
            grpTransportista.Text = "Identificación del transportista";
            grpTransportista.Enter += groupBox2_Enter;
            // 
            // txtPatente
            // 
            txtPatente.Location = new Point(363, 49);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(155, 27);
            txtPatente.TabIndex = 6;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(79, 49);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(146, 27);
            txtDni.TabIndex = 5;
            txtDni.TextChanged += textBox3_TextChanged;
            // 
            // btnBuscarOrdenes
            // 
            btnBuscarOrdenes.Location = new Point(581, 38);
            btnBuscarOrdenes.Name = "btnBuscarOrdenes";
            btnBuscarOrdenes.Size = new Size(153, 48);
            btnBuscarOrdenes.TabIndex = 6;
            btnBuscarOrdenes.Text = "Buscar órdenes";
            btnBuscarOrdenes.UseVisualStyleBackColor = true;
            btnBuscarOrdenes.Click += button2_Click;
            // 
            // lblPatente
            // 
            lblPatente.Font = new Font("Segoe UI", 9F);
            lblPatente.Location = new Point(249, 51);
            lblPatente.Name = "lblPatente";
            lblPatente.Size = new Size(91, 23);
            lblPatente.TabIndex = 2;
            lblPatente.Text = "Patente";
            lblPatente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDni
            // 
            lblDni.Font = new Font("Segoe UI", 9F);
            lblDni.Location = new Point(10, 51);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(63, 23);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI";
            lblDni.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDepósito
            // 
            lblDepósito.AutoSize = true;
            lblDepósito.Font = new Font("Segoe UI", 9F);
            lblDepósito.Location = new Point(12, 9);
            lblDepósito.Name = "lblDepósito";
            lblDepósito.Size = new Size(73, 20);
            lblDepósito.TabIndex = 7;
            lblDepósito.Text = "Depósito:";
            lblDepósito.TextAlign = ContentAlignment.MiddleLeft;
            lblDepósito.Click += lblDepósito_Click;
            // 
            // lblNroRemito
            // 
            lblNroRemito.CausesValidation = false;
            lblNroRemito.Font = new Font("Segoe UI", 9F);
            lblNroRemito.Location = new Point(12, 555);
            lblNroRemito.Name = "lblNroRemito";
            lblNroRemito.Size = new Size(102, 23);
            lblNroRemito.TabIndex = 7;
            lblNroRemito.Text = "N°remito";
            lblNroRemito.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNroRemito
            // 
            txtNroRemito.Location = new Point(120, 555);
            txtNroRemito.Name = "txtNroRemito";
            txtNroRemito.ReadOnly = true;
            txtNroRemito.Size = new Size(139, 27);
            txtNroRemito.TabIndex = 7;
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(91, 9);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(87, 20);
            DepositoLbl.TabIndex = 8;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // GenerarRemitoDespacharForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(DepositoLbl);
            Controls.Add(txtNroRemito);
            Controls.Add(lblNroRemito);
            Controls.Add(lblDepósito);
            Controls.Add(grpTransportista);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmarDespacho);
            Controls.Add(grpOrdenesPendientes);
            MinimumSize = new Size(1100, 650);
            Name = "GenerarRemitoDespacharForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar remito y despachar";
            WindowState = FormWindowState.Maximized;
            grpOrdenesPendientes.ResumeLayout(false);
            grpTransportista.ResumeLayout(false);
            grpTransportista.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpOrdenesPendientes;
        private Button btnConfirmarDespacho;
        private Button btnCancelar;
        private ListView lvwOrdenes;
        private ColumnHeader ColNroOrdenEntrega;
        private ColumnHeader ColNOp;
        private ColumnHeader ColBultos;
        private ColumnHeader ColCliente;
        private GroupBox grpTransportista;
        private Label lblPatente;
        private Label lblDni;
        private TextBox txtPatente;
        private TextBox txtDni;
        private Button btnBuscarOrdenes;
        private Label lblDepósito;
        private Label lblNroRemito;
        private TextBox txtNroRemito;
        private Label lblTotalBultos;
        private Label lblTotalBultosValor;
        private Label DepositoLbl;
    }
}
