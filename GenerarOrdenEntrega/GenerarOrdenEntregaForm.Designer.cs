namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    partial class GenerarOrdenEntregaForm
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

        private void InitializeComponent()
        {
            gbPendientes = new GroupBox();
            lvPendientes = new ListView();
            colPenCliente = new ColumnHeader();
            colPenTransportista = new ColumnHeader();
            colPenFechaRetiro = new ColumnHeader();
            colPenCantidadOP = new ColumnHeader();
            btnGenerarOrden = new Button();
            btnCerrar = new Button();
            gbPendientes.SuspendLayout();
            SuspendLayout();
            // 
            // gbPendientes
            // 
            gbPendientes.Controls.Add(lvPendientes);
            gbPendientes.Location = new Point(14, 16);
            gbPendientes.Margin = new Padding(3, 4, 3, 4);
            gbPendientes.Name = "gbPendientes";
            gbPendientes.Padding = new Padding(3, 4, 3, 4);
            gbPendientes.Size = new Size(773, 313);
            gbPendientes.TabIndex = 0;
            gbPendientes.TabStop = false;
            gbPendientes.Text = "Órdenes preparadas sin orden de entrega";
            // 
            // lvPendientes
            // 
            lvPendientes.CheckBoxes = true;
            lvPendientes.Columns.AddRange(new ColumnHeader[] { colPenCliente, colPenTransportista, colPenFechaRetiro, colPenCantidadOP });
            lvPendientes.FullRowSelect = true;
            lvPendientes.GridLines = true;
            lvPendientes.Location = new Point(14, 32);
            lvPendientes.Margin = new Padding(3, 4, 3, 4);
            lvPendientes.Name = "lvPendientes";
            lvPendientes.Size = new Size(745, 262);
            lvPendientes.TabIndex = 0;
            lvPendientes.UseCompatibleStateImageBehavior = false;
            lvPendientes.View = View.Details;
            lvPendientes.ItemChecked += lvPendientes_ItemChecked;
            // 
            // colPenCliente
            // 
            colPenCliente.Text = "Cliente";
            colPenCliente.Width = 180;
            // 
            // colPenTransportista
            // 
            colPenTransportista.Text = "Transportista";
            colPenTransportista.Width = 180;
            // 
            // colPenFechaRetiro
            // 
            colPenFechaRetiro.Text = "Fecha Retiro";
            colPenFechaRetiro.Width = 140;
            // 
            // colPenCantidadOP
            // 
            colPenCantidadOP.Text = "Cantidad OP";
            colPenCantidadOP.Width = 120;
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Enabled = false;
            btnGenerarOrden.Location = new Point(452, 351);
            btnGenerarOrden.Margin = new Padding(3, 4, 3, 4);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(215, 43);
            btnGenerarOrden.TabIndex = 1;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += btnGenerarOrden_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(673, 351);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 43);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // GenerarOrdenEntregaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 407);
            Controls.Add(btnCerrar);
            Controls.Add(btnGenerarOrden);
            Controls.Add(gbPendientes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarOrdenEntregaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar Orden de Entrega";
            Load += GenerarOrdenEntregaForm_Load;
            gbPendientes.ResumeLayout(false);
            ResumeLayout(false);
        }


        private GroupBox gbPendientes;
        private ListView lvPendientes;
        private ColumnHeader colPenCliente;
        private ColumnHeader colPenTransportista;
        private ColumnHeader colPenFechaRetiro;
        private ColumnHeader colPenCantidadOP;
        private Button btnGenerarOrden;
        private Button btnCerrar;
    }
}