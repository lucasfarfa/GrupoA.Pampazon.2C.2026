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
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "OP-000310", "Producto ficticio A", "40" }, -1);
            grpOrdenesPendientes = new GroupBox();
            lvwOrdenes = new ListView();
            ColNroOrden = new ColumnHeader();
            ColCliente = new ColumnHeader();
            ColBultos = new ColumnHeader();
            ColDarsena = new ColumnHeader();
            ColFechaPreparación = new ColumnHeader();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();

            btnConfirmarDespacho = new Button();
            button1 = new Button();
            grpOrdenesPendientes.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpOrdenesPendientes
            // 
            grpOrdenesPendientes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpOrdenesPendientes.Controls.Add(lvwOrdenes);
            grpOrdenesPendientes.Font = new Font("Segoe UI", 9F);
            grpOrdenesPendientes.Location = new Point(12, 12);
            grpOrdenesPendientes.Name = "grpOrdenesPendientes";
            grpOrdenesPendientes.Size = new Size(1095, 302);
            grpOrdenesPendientes.TabIndex = 0;
            grpOrdenesPendientes.TabStop = false;
            grpOrdenesPendientes.Text = "Órdenes de entrega en despacho";
            grpOrdenesPendientes.Enter += grpOrdenesPendientes_Enter;
            // 
            // lvwOrdenes
            // 
            lvwOrdenes.Columns.AddRange(new ColumnHeader[] { ColNroOrden, ColCliente, ColDomicilio, ColBultos, ColPeso, ColDarsena, ColFechaPreparación });
            lvwOrdenes.Dock = DockStyle.Fill;
            lvwOrdenes.Font = new Font("Segoe UI", 9F);
            lvwOrdenes.FullRowSelect = true;
            lvwOrdenes.Location = new Point(3, 23);
            lvwOrdenes.MultiSelect = false;
            lvwOrdenes.Name = "lvwOrdenes";
            lvwOrdenes.Size = new Size(1089, 276);
            lvwOrdenes.TabIndex = 0;
            lvwOrdenes.UseCompatibleStateImageBehavior = false;
            lvwOrdenes.View = View.Details;
            lvwOrdenes.SelectedIndexChanged += lvwOrdenes_SelectedIndexChanged;
            // 
            // ColNroOrden
            // 
            ColNroOrden.Text = "N° Orden";
            ColNroOrden.Width = 80;
            // 
            // ColCliente
            // 
            ColCliente.Text = "Cliente";
            ColCliente.Width = 330;
            // 
            // ColBultos
            // 
            ColBultos.Text = "Bultos";
            ColBultos.TextAlign = HorizontalAlignment.Right;
            // 
            // ColDarsena
            // 
            ColDarsena.Text = "Dársena";
            ColDarsena.Width = 70;
            // 
            // ColFechaPreparación
            // 
            ColFechaPreparación.Text = "Fecha de preparación";
            ColFechaPreparación.Width = 110;
            
          

            // 
            // textBox4
            // 
            textBox4.Location = new Point(166, 178);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(426, 27);
            textBox4.TabIndex = 17;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(166, 100);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(202, 27);
            textBox3.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(194, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(202, 27);
            textBox2.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(140, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 27);
            textBox1.TabIndex = 14;
          
            // 
            // btnConfirmarDespacho
            // 
            btnConfirmarDespacho.Location = new Point(766, 604);
            btnConfirmarDespacho.Name = "btnConfirmarDespacho";
            btnConfirmarDespacho.Size = new Size(185, 41);
            btnConfirmarDespacho.TabIndex = 4;
            btnConfirmarDespacho.Text = "Confirmar despacho";
            btnConfirmarDespacho.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(957, 604);
            button1.Name = "button1";
            button1.Size = new Size(137, 41);
            button1.TabIndex = 5;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // GenerarRemitoDespacharForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 662);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(btnConfirmarDespacho);
            Controls.Add(grpOrdenesPendientes);
            MinimumSize = new Size(1100, 650);
            Name = "GenerarRemitoDespacharForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar remito y despachar";
            WindowState = FormWindowState.Maximized;
            grpOrdenesPendientes.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOrdenesPendientes;
        private Button btnConfirmarDespacho;
        private Button button1;
        private ListView lvwOrdenes;
        private ColumnHeader ColNroOrden;
        private ColumnHeader ColCliente;
        private ColumnHeader ColBultos;
        private ColumnHeader ColDarsena;
        private ColumnHeader ColFechaPreparación;
        private ColumnHeader ColDomicilio;
        private ColumnHeader ColPeso;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListView lvwDetalle;
        private ColumnHeader ColOrdenPreparacion;
        private ColumnHeader ColProducto;
        private ColumnHeader ColCantidad;
        private Label lblPatente;
        private Label lblChofer;
        private Label lblDni;
        private Label lblEmpresaTransportista;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
