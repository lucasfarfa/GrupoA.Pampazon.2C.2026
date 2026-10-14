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
            groupBox1 = new GroupBox();
            btnBuscarOrdenes = new Button();
            lblNombreTransportista = new Label();
            label4 = new Label();
            textDNITransportista = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            btnDeseleccionar = new Button();
            btnSeleccionar = new Button();
            lvOEPendientesEntrega = new ListView();
            colClientePendiente = new ColumnHeader();
            colNOEPendiente = new ColumnHeader();
            colOP = new ColumnHeader();
            colBultos = new ColumnHeader();
            groupBox3 = new GroupBox();
            btnEmitirRemitos = new Button();
            lvRemitosEmitir = new ListView();
            colClienteEmitirRemito = new ColumnHeader();
            colOEincluida = new ColumnHeader();
            groupBox4 = new GroupBox();
            btnConfirmarEntregaFirma = new Button();
            lvRemitosPendientesFirma = new ListView();
            colNRemito = new ColumnHeader();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarOrdenes);
            groupBox1.Controls.Add(lblNombreTransportista);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textDNITransportista);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(917, 80);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Identificar transportista";
            // 
            // btnBuscarOrdenes
            // 
            btnBuscarOrdenes.Location = new Point(688, 25);
            btnBuscarOrdenes.Name = "btnBuscarOrdenes";
            btnBuscarOrdenes.Size = new Size(219, 43);
            btnBuscarOrdenes.TabIndex = 5;
            btnBuscarOrdenes.Text = "Buscar órdenes";
            btnBuscarOrdenes.UseVisualStyleBackColor = true;
            btnBuscarOrdenes.Click += button1_Click;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(251, 36);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "Nombre:";
            // 
            // textDNITransportista
            // 
            textDNITransportista.Location = new Point(50, 33);
            textDNITransportista.Name = "textDNITransportista";
            textDNITransportista.Size = new Size(195, 27);
            textDNITransportista.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 36);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 1;
            label3.Text = "DNI:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDeseleccionar);
            groupBox2.Controls.Add(btnSeleccionar);
            groupBox2.Controls.Add(lvOEPendientesEntrega);
            groupBox2.Location = new Point(11, 98);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(917, 216);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "1. Ordenes de entrega pendientes de entrega";
            // 
            // btnDeseleccionar
            // 
            btnDeseleccionar.Location = new Point(459, 163);
            btnDeseleccionar.Name = "btnDeseleccionar";
            btnDeseleccionar.Size = new Size(448, 43);
            btnDeseleccionar.TabIndex = 7;
            btnDeseleccionar.Text = "Deseleccionar";
            btnDeseleccionar.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(6, 163);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(448, 43);
            btnSeleccionar.TabIndex = 6;
            btnSeleccionar.Text = "Seleccionar ";
            btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // lvOEPendientesEntrega
            // 
            lvOEPendientesEntrega.Columns.AddRange(new ColumnHeader[] { colClientePendiente, colNOEPendiente, colOP, colBultos });
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
            // groupBox3
            // 
            groupBox3.Controls.Add(btnEmitirRemitos);
            groupBox3.Controls.Add(lvRemitosEmitir);
            groupBox3.Location = new Point(12, 320);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(917, 216);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "2. Se emitirán los siguientes remitos:";
            // 
            // btnEmitirRemitos
            // 
            btnEmitirRemitos.Location = new Point(6, 163);
            btnEmitirRemitos.Name = "btnEmitirRemitos";
            btnEmitirRemitos.Size = new Size(902, 43);
            btnEmitirRemitos.TabIndex = 7;
            btnEmitirRemitos.Text = "Emitir remitos";
            btnEmitirRemitos.UseVisualStyleBackColor = true;
            // 
            // lvRemitosEmitir
            // 
            lvRemitosEmitir.Columns.AddRange(new ColumnHeader[] { colClienteEmitirRemito, colOEincluida });
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
            // groupBox4
            // 
            groupBox4.Controls.Add(btnConfirmarEntregaFirma);
            groupBox4.Controls.Add(lvRemitosPendientesFirma);
            groupBox4.Location = new Point(12, 542);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(917, 216);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "3. Remitos pendiente de firma";
            // 
            // btnConfirmarEntregaFirma
            // 
            btnConfirmarEntregaFirma.Location = new Point(6, 163);
            btnConfirmarEntregaFirma.Name = "btnConfirmarEntregaFirma";
            btnConfirmarEntregaFirma.Size = new Size(902, 43);
            btnConfirmarEntregaFirma.TabIndex = 7;
            btnConfirmarEntregaFirma.Text = "Confirmar entrega y firma";
            btnConfirmarEntregaFirma.UseVisualStyleBackColor = true;
            // 
            // lvRemitosPendientesFirma
            // 
            lvRemitosPendientesFirma.Columns.AddRange(new ColumnHeader[] { colNRemito });
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
            // 
            // GenerarRemitoDespacharForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 825);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarRemitoDespacharForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar remito y despachar";
            Load += GenerarRemitoDespacharForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label3;
        private Button btnBuscarOrdenes;
        private Label lblNombreTransportista;
        private Label label4;
        private TextBox textDNITransportista;
        private GroupBox groupBox2;
        private Button btnDeseleccionar;
        private Button btnSeleccionar;
        private ListView lvOEPendientesEntrega;
        private ColumnHeader colClientePendiente;
        private ColumnHeader colNOEPendiente;
        private ColumnHeader colOP;
        private ColumnHeader colBultos;
        private GroupBox groupBox3;
        private Button btnEmitirRemitos;
        private ListView lvRemitosEmitir;
        private ColumnHeader colClienteEmitirRemito;
        private ColumnHeader colOEincluida;
        private GroupBox groupBox4;
        private Button btnConfirmarEntregaFirma;
        private ListView lvRemitosPendientesFirma;
        private ColumnHeader colNRemito;
        private Button btnCancelar;
    }
}