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
            grpOrden = new GroupBox();
            textBox1 = new TextBox();
            label2 = new Label();
            textModalidad = new TextBox();
            label5 = new Label();
            textCliente = new TextBox();
            txtCliente = new Label();
            groupBox2 = new GroupBox();
            lstProductos = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label9 = new Label();
            groupBox3 = new GroupBox();
            txtCantidadBultos = new TextBox();
            label6 = new Label();
            chkVerificacionFisica = new CheckBox();
            btnEmpaquetar = new Button();
            btnCancelar = new Button();
            ActualizarBtn = new Button();
            label1 = new Label();
            DepositoLbl = new Label();
            label4 = new Label();
            PuestoLbl = new Label();
            label3 = new Label();
            cmbOrden = new ComboBox();
            columnHeader4 = new ColumnHeader();
            grpOrden.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrden
            // 
            grpOrden.Controls.Add(textBox1);
            grpOrden.Controls.Add(label2);
            grpOrden.Controls.Add(textModalidad);
            grpOrden.Controls.Add(label5);
            grpOrden.Controls.Add(textCliente);
            grpOrden.Controls.Add(txtCliente);
            grpOrden.Controls.Add(label3);
            grpOrden.Controls.Add(cmbOrden);
            grpOrden.Location = new Point(7, 70);
            grpOrden.Margin = new Padding(2);
            grpOrden.Name = "grpOrden";
            grpOrden.Padding = new Padding(2);
            grpOrden.Size = new Size(760, 149);
            grpOrden.TabIndex = 6;
            grpOrden.TabStop = false;
            grpOrden.Text = "Selección de Orden de Preparación";
            grpOrden.UseWaitCursor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(555, 33);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(191, 27);
            textBox1.TabIndex = 13;
            textBox1.Text = "OS-XXX";
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(410, 37);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 12;
            label2.Text = "Orden de Selección:";
            label2.UseWaitCursor = true;
            // 
            // textModalidad
            // 
            textModalidad.Location = new Point(555, 88);
            textModalidad.Margin = new Padding(2);
            textModalidad.Name = "textModalidad";
            textModalidad.ReadOnly = true;
            textModalidad.Size = new Size(192, 27);
            textModalidad.TabIndex = 11;
            textModalidad.Text = "Fulfillment /Pallets";
            textModalidad.UseWaitCursor = true;
            textModalidad.TextChanged += textModalidad_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 91);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 10;
            label5.Text = "Modalidad:";
            label5.UseWaitCursor = true;
            // 
            // textCliente
            // 
            textCliente.Location = new Point(97, 86);
            textCliente.Margin = new Padding(2);
            textCliente.Name = "textCliente";
            textCliente.ReadOnly = true;
            textCliente.Size = new Size(281, 27);
            textCliente.TabIndex = 9;
            textCliente.Text = "MundoFOX S.A.";
            textCliente.UseWaitCursor = true;
            // 
            // txtCliente
            // 
            txtCliente.AutoSize = true;
            txtCliente.Location = new Point(9, 91);
            txtCliente.Margin = new Padding(2, 0, 2, 0);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(58, 20);
            txtCliente.TabIndex = 8;
            txtCliente.Text = "Cliente:";
            txtCliente.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstProductos);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(6, 240);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(758, 166);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Productos a empaquetar";
            groupBox2.UseWaitCursor = true;
            // 
            // lstProductos
            // 
            lstProductos.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lstProductos.FullRowSelect = true;
            lstProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstProductos.Location = new Point(7, 24);
            lstProductos.Margin = new Padding(2);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(741, 140);
            lstProductos.TabIndex = 1;
            lstProductos.UseCompatibleStateImageBehavior = false;
            lstProductos.UseWaitCursor = true;
            lstProductos.View = View.Details;
            lstProductos.SelectedIndexChanged += lstProductos_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "SKU Producto";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Descripcion";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Cantidad";
            columnHeader3.Width = 120;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(9, 33);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(0, 18);
            label9.TabIndex = 0;
            label9.UseWaitCursor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCantidadBultos);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(chkVerificacionFisica);
            groupBox3.Location = new Point(7, 424);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(760, 88);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Consolidacion de Empaque y rotulación";
            groupBox3.UseWaitCursor = true;
            // 
            // txtCantidadBultos
            // 
            txtCantidadBultos.Enabled = false;
            txtCantidadBultos.Location = new Point(694, 36);
            txtCantidadBultos.Margin = new Padding(2);
            txtCantidadBultos.Name = "txtCantidadBultos";
            txtCantidadBultos.Size = new Size(61, 27);
            txtCantidadBultos.TabIndex = 2;
            txtCantidadBultos.UseWaitCursor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(552, 39);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(138, 20);
            label6.TabIndex = 1;
            label6.Text = "Cantidad de bultos:";
            label6.UseWaitCursor = true;
            // 
            // chkVerificacionFisica
            // 
            chkVerificacionFisica.AutoSize = true;
            chkVerificacionFisica.Location = new Point(11, 36);
            chkVerificacionFisica.Margin = new Padding(2);
            chkVerificacionFisica.Name = "chkVerificacionFisica";
            chkVerificacionFisica.Size = new Size(213, 24);
            chkVerificacionFisica.TabIndex = 0;
            chkVerificacionFisica.Text = "Verificación física completa";
            chkVerificacionFisica.UseVisualStyleBackColor = true;
            chkVerificacionFisica.UseWaitCursor = true;
            // 
            // btnEmpaquetar
            // 
            btnEmpaquetar.Enabled = false;
            btnEmpaquetar.ForeColor = SystemColors.HotTrack;
            btnEmpaquetar.Location = new Point(539, 529);
            btnEmpaquetar.Margin = new Padding(2);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(122, 47);
            btnEmpaquetar.TabIndex = 9;
            btnEmpaquetar.Text = "Empaquetar";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlLight;
            btnCancelar.ForeColor = SystemColors.WindowFrame;
            btnCancelar.Location = new Point(665, 529);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 47);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // ActualizarBtn
            // 
            ActualizarBtn.Location = new Point(663, 15);
            ActualizarBtn.Name = "ActualizarBtn";
            ActualizarBtn.Size = new Size(99, 37);
            ActualizarBtn.TabIndex = 13;
            ActualizarBtn.Text = "Actualizar";
            ActualizarBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 23);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 12;
            label1.Text = "Depósito:";
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(88, 23);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(87, 20);
            DepositoLbl.TabIndex = 14;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 23);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 15;
            label4.Text = "Puesto:";
            // 
            // PuestoLbl
            // 
            PuestoLbl.AutoSize = true;
            PuestoLbl.Location = new Point(279, 23);
            PuestoLbl.Name = "PuestoLbl";
            PuestoLbl.Size = new Size(71, 20);
            PuestoLbl.TabIndex = 16;
            PuestoLbl.Text = "[PUESTO]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 37);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
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
            cmbOrden.Location = new Point(97, 33);
            cmbOrden.Margin = new Padding(2);
            cmbOrden.Name = "cmbOrden";
            cmbOrden.Size = new Size(281, 28);
            cmbOrden.TabIndex = 1;
            cmbOrden.UseWaitCursor = true;
            cmbOrden.SelectedIndexChanged += cmbOrden_SelectedIndexChanged;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Unidad";
            columnHeader4.Width = 80;
            // 
            // EmpaquetarProductosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 584);
            Controls.Add(PuestoLbl);
            Controls.Add(label4);
            Controls.Add(DepositoLbl);
            Controls.Add(ActualizarBtn);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnEmpaquetar);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(grpOrden);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            Name = "EmpaquetarProductosForm";
            Text = "Empaquetar Productos Forms - Pampazon S.A";
            Load += EmpaquetarProductosForm_Load;
            grpOrden.ResumeLayout(false);
            grpOrden.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox grpOrden;
        private Label txtCliente;
        private TextBox textCliente;
        private Label label5;
        private TextBox textModalidad;
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
        private TextBox textBox1;
        private Label label2;
        private Button ActualizarBtn;
        private Label label1;
        private Label DepositoLbl;
        private Label label4;
        private Label PuestoLbl;
        private Label label3;
        private ComboBox cmbOrden;
        private ColumnHeader columnHeader4;
    }
}