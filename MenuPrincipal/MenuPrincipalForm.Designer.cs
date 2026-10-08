using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrdenesPreparacion
{
    partial class MenuPrincipalForm
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
            lblDeposito = new Label();
            cboDeposito = new ComboBox();
            btnValidarOrdenes = new Button();
            btnGenerarSeleccion = new Button();
            btnPrepararProductos = new Button();
            btnEmpaquetar = new Button();
            btnGenerarEntrega = new Button();
            btnGenerarRemito = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(88, 52);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(78, 23);
            lblDeposito.TabIndex = 1;
            lblDeposito.Text = "Depósito";
            lblDeposito.Click += lblDeposito_Click;
            // 
            // cboDeposito
            // 
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Items.AddRange(new object[] { "DEPOSITO BSAS", "DEPOSITO LAS FLORES", "DEPOSITO NECOCHEA", "DEPOSITO RAUCH", "DEPOSITO TANDIL" });
            cboDeposito.Location = new Point(88, 83);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(324, 31);
            cboDeposito.Sorted = true;
            cboDeposito.TabIndex = 2;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // btnValidarOrdenes
            // 
            btnValidarOrdenes.Location = new Point(88, 145);
            btnValidarOrdenes.Name = "btnValidarOrdenes";
            btnValidarOrdenes.Size = new Size(324, 46);
            btnValidarOrdenes.TabIndex = 3;
            btnValidarOrdenes.Text = "Generar Orden de Preparación";
            btnValidarOrdenes.UseVisualStyleBackColor = true;
            btnValidarOrdenes.Click += btnValidarOrdenes_Click;
            // 
            // btnGenerarSeleccion
            // 
            btnGenerarSeleccion.Location = new Point(88, 207);
            btnGenerarSeleccion.Name = "btnGenerarSeleccion";
            btnGenerarSeleccion.Size = new Size(324, 46);
            btnGenerarSeleccion.TabIndex = 4;
            btnGenerarSeleccion.Text = "Generar Orden de Selección";
            btnGenerarSeleccion.UseVisualStyleBackColor = true;
            // 
            // btnPrepararProductos
            // 
            btnPrepararProductos.Location = new Point(88, 269);
            btnPrepararProductos.Name = "btnPrepararProductos";
            btnPrepararProductos.Size = new Size(324, 46);
            btnPrepararProductos.TabIndex = 5;
            btnPrepararProductos.Text = "Preparar los productos (picking)";
            btnPrepararProductos.UseVisualStyleBackColor = true;
            btnPrepararProductos.Click += btnPrepararProductos_Click;
            // 
            // btnEmpaquetar
            // 
            btnEmpaquetar.Location = new Point(88, 331);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(324, 46);
            btnEmpaquetar.TabIndex = 6;
            btnEmpaquetar.Text = "Empaquetar productos (fullfilment)";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            // 
            // btnGenerarEntrega
            // 
            btnGenerarEntrega.Location = new Point(88, 397);
            btnGenerarEntrega.Name = "btnGenerarEntrega";
            btnGenerarEntrega.Size = new Size(324, 46);
            btnGenerarEntrega.TabIndex = 7;
            btnGenerarEntrega.Text = "Generar Orden de Entrega";
            btnGenerarEntrega.UseVisualStyleBackColor = true;
            btnGenerarEntrega.Click += btnGenerarEntrega_Click;
            // 
            // btnGenerarRemito
            // 
            btnGenerarRemito.Location = new Point(88, 521);
            btnGenerarRemito.Name = "btnGenerarRemito";
            btnGenerarRemito.Size = new Size(324, 46);
            btnGenerarRemito.TabIndex = 8;
            btnGenerarRemito.Text = "Generar remito y despachar";
            btnGenerarRemito.UseVisualStyleBackColor = true;
            btnGenerarRemito.Click += btnGenerarRemito_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Location = new Point(88, 458);
            button1.Name = "button1";
            button1.Size = new Size(324, 46);
            button1.TabIndex = 9;
            button1.Text = "Confirmar Orden de Entrega";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 596);
            Controls.Add(button1);
            Controls.Add(btnGenerarRemito);
            Controls.Add(btnGenerarEntrega);
            Controls.Add(btnEmpaquetar);
            Controls.Add(btnPrepararProductos);
            Controls.Add(btnGenerarSeleccion);
            Controls.Add(btnValidarOrdenes);
            Controls.Add(cboDeposito);
            Controls.Add(lblDeposito);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MenuPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Depósito";
            Load += MenuPrincipalForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.ComboBox cboDeposito;
        private System.Windows.Forms.Button btnValidarOrdenes;
        private System.Windows.Forms.Button btnGenerarSeleccion;
        private System.Windows.Forms.Button btnPrepararProductos;
        private System.Windows.Forms.Button btnEmpaquetar;
        private System.Windows.Forms.Button btnGenerarEntrega;
        private System.Windows.Forms.Button btnGenerarRemito;
        private Button button1;
    }
}