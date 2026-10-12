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
            ColNOp = new ColumnHeader();
            ColCliente = new ColumnHeader();
            ColBultos = new ColumnHeader();
            btnConfirmarDespacho = new Button();
            btnCancelar = new Button();
            grpTransportista = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            txtDni = new TextBox();
            btnBuscarOrdenes = new Button();
            lblDni = new Label();
            lblDepósito = new Label();
            DepositoLbl = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
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
            grpOrdenesPendientes.ImeMode = ImeMode.NoControl;
            grpOrdenesPendientes.Location = new Point(12, 164);
            grpOrdenesPendientes.Name = "grpOrdenesPendientes";
            grpOrdenesPendientes.Size = new Size(740, 351);
            grpOrdenesPendientes.TabIndex = 0;
            grpOrdenesPendientes.TabStop = false;
            grpOrdenesPendientes.Text = "Órdenes de Preparación";
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
            lvwOrdenes.Columns.AddRange(new ColumnHeader[] { ColNOp, ColCliente, ColBultos });
            lvwOrdenes.Font = new Font("Segoe UI", 9F);
            lvwOrdenes.FullRowSelect = true;
            lvwOrdenes.Location = new Point(10, 26);
            lvwOrdenes.MultiSelect = false;
            lvwOrdenes.Name = "lvwOrdenes";
            lvwOrdenes.Size = new Size(714, 285);
            lvwOrdenes.TabIndex = 0;
            lvwOrdenes.UseCompatibleStateImageBehavior = false;
            lvwOrdenes.View = View.Details;
            lvwOrdenes.SelectedIndexChanged += lvwOrdenes_SelectedIndexChanged;
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
            btnConfirmarDespacho.Location = new Point(12, 524);
            btnConfirmarDespacho.Name = "btnConfirmarDespacho";
            btnConfirmarDespacho.Size = new Size(740, 39);
            btnConfirmarDespacho.TabIndex = 4;
            btnConfirmarDespacho.Text = "Generar remito";
            btnConfirmarDespacho.UseVisualStyleBackColor = true;
            btnConfirmarDespacho.Click += btnConfirmarDespacho_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(638, 648);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(123, 39);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpTransportista
            // 
            grpTransportista.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpTransportista.Controls.Add(label2);
            grpTransportista.Controls.Add(label1);
            grpTransportista.Controls.Add(txtDni);
            grpTransportista.Controls.Add(btnBuscarOrdenes);
            grpTransportista.Controls.Add(lblDni);
            grpTransportista.Font = new Font("Segoe UI", 9F);
            grpTransportista.Location = new Point(12, 45);
            grpTransportista.Name = "grpTransportista";
            grpTransportista.Size = new Size(740, 113);
            grpTransportista.TabIndex = 2;
            grpTransportista.TabStop = false;
            grpTransportista.Text = "Identificación del transportista";
            grpTransportista.Enter += groupBox2_Enter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(405, 53);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 8;
            label2.Text = "_____________-";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(330, 53);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 7;
            label1.Text = "Nombre";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(57, 51);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(243, 27);
            txtDni.TabIndex = 5;
            txtDni.TextChanged += textBox3_TextChanged;
            // 
            // btnBuscarOrdenes
            // 
            btnBuscarOrdenes.Location = new Point(571, 40);
            btnBuscarOrdenes.Name = "btnBuscarOrdenes";
            btnBuscarOrdenes.Size = new Size(153, 48);
            btnBuscarOrdenes.TabIndex = 6;
            btnBuscarOrdenes.Text = "Buscar órdenes";
            btnBuscarOrdenes.UseVisualStyleBackColor = true;
            btnBuscarOrdenes.Click += button2_Click;
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
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(91, 9);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(87, 20);
            DepositoLbl.TabIndex = 8;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(333, 648);
            button1.Name = "button1";
            button1.Size = new Size(299, 39);
            button1.TabIndex = 9;
            button1.Text = "Confirmar Entrega (remito firmado)";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 589);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 11;
            label3.Text = "[REMITO]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(12, 589);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 10;
            label4.Text = "Nro Remito:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(396, 589);
            label5.Name = "label5";
            label5.Size = new Size(179, 20);
            label5.TabIndex = 13;
            label5.Text = "Espera firma transportista";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(333, 589);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 12;
            label6.Text = "Estado:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GenerarRemitoDespacharForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 709);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(DepositoLbl);
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
        private ColumnHeader ColNOp;
        private ColumnHeader ColBultos;
        private ColumnHeader ColCliente;
        private GroupBox grpTransportista;
        private Label lblDni;
        private TextBox txtDni;
        private Button btnBuscarOrdenes;
        private Label lblDepósito;
        private Label lblTotalBultos;
        private Label lblTotalBultosValor;
        private Label DepositoLbl;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
