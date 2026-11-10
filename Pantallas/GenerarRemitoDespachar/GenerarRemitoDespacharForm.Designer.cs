namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    partial class GenerarRemitoDespacharForm
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
            grpTransportista = new GroupBox();
            btnBuscarOrdenes = new Button();
            lblNombreTransportista = new Label();
            lblNombre = new Label();
            textDNITransportista = new TextBox();
            lblDni = new Label();
            grpOEPendientes = new GroupBox();
            btnDeseleccionar = new Button();
            btnSeleccionar = new Button();
            lvOEPendientesEntrega = new ListView();
            colClientePendiente = new ColumnHeader();
            colNOEPendiente = new ColumnHeader();
            colOP = new ColumnHeader();
            colBultos = new ColumnHeader();
            grpRemitosEmitir = new GroupBox();
            btnEmitirRemitos = new Button();
            lvRemitosEmitir = new ListView();
            colClienteEmitirRemito = new ColumnHeader();
            colOEincluida = new ColumnHeader();
            grpRemitosPendientesFirma = new GroupBox();
            btnConfirmarEntregaFirma = new Button();
            lvRemitosPendientesFirma = new ListView();
            colNRemito = new ColumnHeader();
            btnCancelar = new Button();
            grpTransportista.SuspendLayout();
            grpOEPendientes.SuspendLayout();
            grpRemitosEmitir.SuspendLayout();
            grpRemitosPendientesFirma.SuspendLayout();
            SuspendLayout();
            // 
            // grpTransportista
            // 
            grpTransportista.Controls.Add(btnBuscarOrdenes);
            grpTransportista.Controls.Add(lblNombreTransportista);
            grpTransportista.Controls.Add(lblNombre);
            grpTransportista.Controls.Add(textDNITransportista);
            grpTransportista.Controls.Add(lblDni);
            grpTransportista.Location = new Point(11, 12);
            grpTransportista.Name = "grpTransportista";
            grpTransportista.Size = new Size(917, 80);
            grpTransportista.TabIndex = 2;
            grpTransportista.TabStop = false;
            grpTransportista.Text = "Identificar transportista";
            // 
            // btnBuscarOrdenes
            // 
            btnBuscarOrdenes.Location = new Point(688, 25);
            btnBuscarOrdenes.Name = "btnBuscarOrdenes";
            btnBuscarOrdenes.Size = new Size(219, 43);
            btnBuscarOrdenes.TabIndex = 5;
            btnBuscarOrdenes.Text = "Buscar órdenes";
            btnBuscarOrdenes.UseVisualStyleBackColor = true;
            btnBuscarOrdenes.Click += btnBuscarOrdenes_Click;
            // 
            // lblNombreTransportista
            // 
            lblNombreTransportista.AutoSize = true;
            lblNombreTransportista.Location = new Point(325, 36);
            lblNombreTransportista.Name = "lblNombreTransportista";
            lblNombreTransportista.Size = new Size(153, 20);
            lblNombreTransportista.TabIndex = 4;
            lblNombreTransportista.Text = "[NOMBRE, APELLIDO]";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(251, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // textDNITransportista
            // 
            textDNITransportista.Location = new Point(50, 33);
            textDNITransportista.Name = "textDNITransportista";
            textDNITransportista.Size = new Size(195, 27);
            textDNITransportista.TabIndex = 2;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(6, 36);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(38, 20);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI:";
            // 
            // grpOEPendientes
            // 
            grpOEPendientes.Controls.Add(btnDeseleccionar);
            grpOEPendientes.Controls.Add(btnSeleccionar);
            grpOEPendientes.Controls.Add(lvOEPendientesEntrega);
            grpOEPendientes.Location = new Point(11, 98);
            grpOEPendientes.Name = "grpOEPendientes";
            grpOEPendientes.Size = new Size(917, 216);
            grpOEPendientes.TabIndex = 3;
            grpOEPendientes.TabStop = false;
            grpOEPendientes.Text = "1. Ordenes de entrega pendientes de entrega";
            // 
            // btnDeseleccionar
            // 
            btnDeseleccionar.Location = new Point(459, 163);
            btnDeseleccionar.Name = "btnDeseleccionar";
            btnDeseleccionar.Size = new Size(448, 43);
            btnDeseleccionar.TabIndex = 7;
            btnDeseleccionar.Text = "Deseleccionar";
            btnDeseleccionar.UseVisualStyleBackColor = true;
            btnDeseleccionar.Click += btnDeseleccionar_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(6, 163);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(448, 43);
            btnSeleccionar.TabIndex = 6;
            btnSeleccionar.Text = "Seleccionar ";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // lvOEPendientesEntrega
            // 
            lvOEPendientesEntrega.Columns.AddRange(new ColumnHeader[] { colClientePendiente, colNOEPendiente, colOP, colBultos });
            lvOEPendientesEntrega.FullRowSelect = true;
            lvOEPendientesEntrega.Location = new Point(6, 35);
            lvOEPendientesEntrega.Name = "lvOEPendientesEntrega";
            lvOEPendientesEntrega.Size = new Size(902, 121);
            lvOEPendientesEntrega.TabIndex = 0;
            lvOEPendientesEntrega.UseCompatibleStateImageBehavior = false;
            lvOEPendientesEntrega.View = View.Details;
            // 
            // colClientePendiente
            // 
            colClientePendiente.Text = "Cliente";
            colClientePendiente.Width = 120;
            // 
            // colNOEPendiente
            // 
            colNOEPendiente.Text = "N° OE";
            colNOEPendiente.Width = 100;
            // 
            // colOP
            // 
            colOP.Text = "Ordenes de preparación";
            colOP.Width = 200;
            // 
            // colBultos
            // 
            colBultos.Text = "Bultos";
            colBultos.Width = 80;
            // 
            // grpRemitosEmitir
            // 
            grpRemitosEmitir.Controls.Add(btnEmitirRemitos);
            grpRemitosEmitir.Controls.Add(lvRemitosEmitir);
            grpRemitosEmitir.Location = new Point(12, 320);
            grpRemitosEmitir.Name = "grpRemitosEmitir";
            grpRemitosEmitir.Size = new Size(917, 216);
            grpRemitosEmitir.TabIndex = 4;
            grpRemitosEmitir.TabStop = false;
            grpRemitosEmitir.Text = "2. Se emitirán los siguientes remitos:";
            // 
            // btnEmitirRemitos
            // 
            btnEmitirRemitos.Location = new Point(6, 163);
            btnEmitirRemitos.Name = "btnEmitirRemitos";
            btnEmitirRemitos.Size = new Size(902, 43);
            btnEmitirRemitos.TabIndex = 7;
            btnEmitirRemitos.Text = "Emitir remitos";
            btnEmitirRemitos.UseVisualStyleBackColor = true;
            btnEmitirRemitos.Click += btnEmitirRemitos_Click;
            // 
            // lvRemitosEmitir
            // 
            lvRemitosEmitir.Columns.AddRange(new ColumnHeader[] { colClienteEmitirRemito, colOEincluida });
            lvRemitosEmitir.FullRowSelect = true;
            lvRemitosEmitir.Location = new Point(6, 35);
            lvRemitosEmitir.Name = "lvRemitosEmitir";
            lvRemitosEmitir.Size = new Size(902, 121);
            lvRemitosEmitir.TabIndex = 0;
            lvRemitosEmitir.UseCompatibleStateImageBehavior = false;
            lvRemitosEmitir.View = View.Details;
            // 
            // colClienteEmitirRemito
            // 
            colClienteEmitirRemito.Text = "Cliente";
            colClienteEmitirRemito.Width = 120;
            // 
            // colOEincluida
            // 
            colOEincluida.Text = "OE incluidas";
            colOEincluida.Width = 100;
            // 
            // grpRemitosPendientesFirma
            // 
            grpRemitosPendientesFirma.Controls.Add(btnConfirmarEntregaFirma);
            grpRemitosPendientesFirma.Controls.Add(lvRemitosPendientesFirma);
            grpRemitosPendientesFirma.Location = new Point(12, 542);
            grpRemitosPendientesFirma.Name = "grpRemitosPendientesFirma";
            grpRemitosPendientesFirma.Size = new Size(917, 216);
            grpRemitosPendientesFirma.TabIndex = 8;
            grpRemitosPendientesFirma.TabStop = false;
            grpRemitosPendientesFirma.Text = "3. Remitos pendiente de firma";
            // 
            // btnConfirmarEntregaFirma
            // 
            btnConfirmarEntregaFirma.Location = new Point(6, 163);
            btnConfirmarEntregaFirma.Name = "btnConfirmarEntregaFirma";
            btnConfirmarEntregaFirma.Size = new Size(902, 43);
            btnConfirmarEntregaFirma.TabIndex = 7;
            btnConfirmarEntregaFirma.Text = "Confirmar entrega y firma";
            btnConfirmarEntregaFirma.UseVisualStyleBackColor = true;
            btnConfirmarEntregaFirma.Click += btnConfirmarEntregaFirma_Click;
            // 
            // lvRemitosPendientesFirma
            // 
            lvRemitosPendientesFirma.Columns.AddRange(new ColumnHeader[] { colNRemito });
            lvRemitosPendientesFirma.FullRowSelect = true;
            lvRemitosPendientesFirma.Location = new Point(6, 35);
            lvRemitosPendientesFirma.Name = "lvRemitosPendientesFirma";
            lvRemitosPendientesFirma.Size = new Size(902, 121);
            lvRemitosPendientesFirma.TabIndex = 0;
            lvRemitosPendientesFirma.UseCompatibleStateImageBehavior = false;
            lvRemitosPendientesFirma.View = View.Details;
            // 
            // colNRemito
            // 
            colNRemito.Text = "N° Remito";
            colNRemito.Width = 775;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(709, 773);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(219, 43);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // GenerarRemitoDespacharForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 825);
            Controls.Add(btnCancelar);
            Controls.Add(grpRemitosPendientesFirma);
            Controls.Add(grpRemitosEmitir);
            Controls.Add(grpOEPendientes);
            Controls.Add(grpTransportista);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarRemitoDespacharForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar Remito y Despachar - Pampazon S.A.";
            FormClosing += GenerarRemitoDespacharForm_FormClosing;
            grpTransportista.ResumeLayout(false);
            grpTransportista.PerformLayout();
            grpOEPendientes.ResumeLayout(false);
            grpRemitosEmitir.ResumeLayout(false);
            grpRemitosPendientesFirma.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grpTransportista;
        private Label lblDni;
        private Button btnBuscarOrdenes;
        private Label lblNombreTransportista;
        private Label lblNombre;
        private TextBox textDNITransportista;
        private GroupBox grpOEPendientes;
        private Button btnDeseleccionar;
        private Button btnSeleccionar;
        private ListView lvOEPendientesEntrega;
        private ColumnHeader colClientePendiente;
        private ColumnHeader colNOEPendiente;
        private ColumnHeader colOP;
        private ColumnHeader colBultos;
        private GroupBox grpRemitosEmitir;
        private Button btnEmitirRemitos;
        private ListView lvRemitosEmitir;
        private ColumnHeader colClienteEmitirRemito;
        private ColumnHeader colOEincluida;
        private GroupBox grpRemitosPendientesFirma;
        private Button btnConfirmarEntregaFirma;
        private ListView lvRemitosPendientesFirma;
        private ColumnHeader colNRemito;
        private Button btnCancelar;
    }
}