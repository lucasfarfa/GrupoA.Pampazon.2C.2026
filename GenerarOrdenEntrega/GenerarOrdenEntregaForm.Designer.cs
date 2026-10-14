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
            lblInstruccion = new Label();
            btnGenerarOrden = new Button();
            btnCerrar = new Button();
            gbPendientes.SuspendLayout();
            SuspendLayout();
            // 
            // gbPendientes
            // 
            gbPendientes.Controls.Add(lvPendientes);
            gbPendientes.Controls.Add(lblInstruccion);
            gbPendientes.Location = new Point(12, 12);
            gbPendientes.Name = "gbPendientes";
            gbPendientes.Size = new Size(676, 235);
            gbPendientes.TabIndex = 0;
            gbPendientes.TabStop = false;
            gbPendientes.Text = "Órdenes preparadas sin orden de entrega (por cliente, transportista y fecha de retiro)";
            // 
            // lvPendientes
            // 
            lvPendientes.CheckBoxes = true;
            lvPendientes.Columns.AddRange(new ColumnHeader[] { colPenCliente, colPenTransportista, colPenFechaRetiro, colPenCantidadOP });
            lvPendientes.FullRowSelect = true;
            lvPendientes.GridLines = true;
            lvPendientes.HideSelection = false;
            lvPendientes.Location = new Point(12, 24);
            lvPendientes.Name = "lvPendientes";
            lvPendientes.Size = new Size(652, 160);
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
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new Point(12, 198);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(330, 15);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "Marque los grupos de OP para los que desea generar una orden.";
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Enabled = false;
            btnGenerarOrden.Location = new Point(500, 258);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(188, 32);
            btnGenerarOrden.TabIndex = 1;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += btnGenerarOrden_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(12, 258);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // GenerarOrdenEntregaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 305);
            Controls.Add(btnCerrar);
            Controls.Add(btnGenerarOrden);
            Controls.Add(gbPendientes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarOrdenEntregaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar Orden de Entrega";
            Load += GenerarOrdenEntregaForm_Load;
            gbPendientes.ResumeLayout(false);
            gbPendientes.PerformLayout();
            ResumeLayout(false);
        }


        private GroupBox gbPendientes;
        private ListView lvPendientes;
        private ColumnHeader colPenCliente;
        private ColumnHeader colPenTransportista;
        private ColumnHeader colPenFechaRetiro;
        private ColumnHeader colPenCantidadOP;
        private Label lblInstruccion;
        private Button btnGenerarOrden;
        private Button btnCerrar;
    }
}