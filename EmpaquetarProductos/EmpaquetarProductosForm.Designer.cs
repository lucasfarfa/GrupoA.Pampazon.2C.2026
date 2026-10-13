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
            textModalidad = new TextBox();
            label5 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            label6 = new Label();
            label2 = new Label();
            lstProductos = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label9 = new Label();
            btnEmpaquetar = new Button();
            label1 = new Label();
            DepositoLbl = new Label();
            label4 = new Label();
            PuestoLbl = new Label();
            textBox1 = new TextBox();
            btnCancelar = new Button();
            grpOrden.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrden
            // 
            grpOrden.Controls.Add(textBox1);
            grpOrden.Controls.Add(textModalidad);
            grpOrden.Controls.Add(label5);
            grpOrden.Controls.Add(label3);
            grpOrden.Location = new Point(6, 40);
            grpOrden.Margin = new Padding(2);
            grpOrden.Name = "grpOrden";
            grpOrden.Padding = new Padding(2);
            grpOrden.Size = new Size(665, 63);
            grpOrden.TabIndex = 6;
            grpOrden.TabStop = false;
            grpOrden.Text = "Selección de Orden de Preparación";
            grpOrden.UseWaitCursor = true;
            // 
            // textModalidad
            // 
            textModalidad.Location = new Point(483, 22);
            textModalidad.Margin = new Padding(2);
            textModalidad.Name = "textModalidad";
            textModalidad.ReadOnly = true;
            textModalidad.Size = new Size(168, 23);
            textModalidad.TabIndex = 11;
            textModalidad.Text = "Fulfillment /Pallets";
            textModalidad.UseWaitCursor = true;
            textModalidad.TextChanged += textModalidad_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(384, 25);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 10;
            label5.Text = "Modalidad:";
            label5.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 28);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 0;
            label3.Text = "Orden:";
            label3.UseWaitCursor = true;
            label3.Click += label3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(lstProductos);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(6, 106);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(663, 275);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Productos a empaquetar";
            groupBox2.UseWaitCursor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(626, 252);
            label6.Name = "label6";
            label6.Size = new Size(22, 15);
            label6.TabIndex = 14;
            label6.Text = "[X]";
            label6.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(542, 252);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 13;
            label2.Text = "Total Bultos:";
            label2.UseWaitCursor = true;
            // 
            // lstProductos
            // 
            lstProductos.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lstProductos.FullRowSelect = true;
            lstProductos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstProductos.Location = new Point(8, 18);
            lstProductos.Margin = new Padding(2);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(649, 223);
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
            label9.Location = new Point(8, 25);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 0;
            label9.UseWaitCursor = true;
            // 
            // btnEmpaquetar
            // 
            btnEmpaquetar.Enabled = false;
            btnEmpaquetar.ForeColor = SystemColors.HotTrack;
            btnEmpaquetar.Location = new Point(390, 397);
            btnEmpaquetar.Margin = new Padding(2);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(188, 35);
            btnEmpaquetar.TabIndex = 9;
            btnEmpaquetar.Text = "Confirmar Empaquetado";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 17);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 12;
            label1.Text = "Depósito:";
            // 
            // DepositoLbl
            // 
            DepositoLbl.AutoSize = true;
            DepositoLbl.Location = new Point(77, 17);
            DepositoLbl.Name = "DepositoLbl";
            DepositoLbl.Size = new Size(69, 15);
            DepositoLbl.TabIndex = 14;
            DepositoLbl.Text = "[DEPOSITO]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(167, 17);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 15;
            label4.Text = "Puesto:";
            // 
            // PuestoLbl
            // 
            PuestoLbl.AutoSize = true;
            PuestoLbl.Location = new Point(221, 17);
            PuestoLbl.Name = "PuestoLbl";
            PuestoLbl.Size = new Size(57, 15);
            PuestoLbl.TabIndex = 16;
            PuestoLbl.Text = "[PUESTO]";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 22);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(312, 23);
            textBox1.TabIndex = 12;
            textBox1.Text = "[Numero de orden]";
            textBox1.UseWaitCursor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlLight;
            btnCancelar.ForeColor = SystemColors.WindowFrame;
            btnCancelar.Location = new Point(582, 397);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 35);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // EmpaquetarProductosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 448);
            Controls.Add(PuestoLbl);
            Controls.Add(label4);
            Controls.Add(DepositoLbl);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnEmpaquetar);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox grpOrden;
        private Label label5;
        private TextBox textModalidad;
        private GroupBox groupBox2;
        private Label label9;
        private ListView lstProductos;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btnEmpaquetar;
        private Label label1;
        private Label DepositoLbl;
        private Label label4;
        private Label PuestoLbl;
        private Label label3;
        private Label label6;
        private Label label2;
        private TextBox textBox1;
        private Button btnCancelar;
    }
}