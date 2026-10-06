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
            lblTitulo = new Label();
            lblDeposito = new Label();
            cboDeposito = new ComboBox();
            btnValidarOrdenes = new Button();
            btnGenerarSeleccion = new Button();
            btnPrepararProductos = new Button();
            btnEmpaquetar = new Button();
            btnGenerarEntrega = new Button();
            btnGenerarRemito = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(0, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Menú Inicio Empresa";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(88, 52);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(92, 28);
            lblDeposito.TabIndex = 1;
            lblDeposito.Text = "Depósito";
            lblDeposito.Click += lblDeposito_Click;
            // 
            // cboDeposito
            // 
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.FormattingEnabled = true;
            cboDeposito.Items.AddRange(new object[] { "DEPOSITO BSAS", "DEPOSITO LAS FLORES", "DEPOSITO RAUCH", "DEPOSITO TANDIL", "DEPOSITO NECOCHEA" });
            cboDeposito.Location = new Point(88, 83);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(324, 36);
            cboDeposito.TabIndex = 2;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // btnValidarOrdenes
            // 
            btnValidarOrdenes.Location = new Point(88, 145);
            btnValidarOrdenes.Name = "btnValidarOrdenes";
            btnValidarOrdenes.Size = new Size(324, 46);
            btnValidarOrdenes.TabIndex = 3;
            btnValidarOrdenes.Text = "Validar órdenes de preparación";
            btnValidarOrdenes.UseVisualStyleBackColor = true;
            // 
            // btnGenerarSeleccion
            // 
            btnGenerarSeleccion.Location = new Point(88, 207);
            btnGenerarSeleccion.Name = "btnGenerarSeleccion";
            btnGenerarSeleccion.Size = new Size(324, 46);
            btnGenerarSeleccion.TabIndex = 4;
            btnGenerarSeleccion.Text = "Generar orden de selección";
            btnGenerarSeleccion.UseVisualStyleBackColor = true;
            // 
            // btnPrepararProductos
            // 
            btnPrepararProductos.Location = new Point(88, 269);
            btnPrepararProductos.Name = "btnPrepararProductos";
            btnPrepararProductos.Size = new Size(324, 46);
            btnPrepararProductos.TabIndex = 5;
            btnPrepararProductos.Text = "Preparar los productos";
            btnPrepararProductos.UseVisualStyleBackColor = true;
            btnPrepararProductos.Click += btnPrepararProductos_Click;
            // 
            // btnEmpaquetar
            // 
            btnEmpaquetar.Location = new Point(88, 331);
            btnEmpaquetar.Name = "btnEmpaquetar";
            btnEmpaquetar.Size = new Size(324, 46);
            btnEmpaquetar.TabIndex = 6;
            btnEmpaquetar.Text = "Empaquetar productos";
            btnEmpaquetar.UseVisualStyleBackColor = true;
            // 
            // btnGenerarEntrega
            // 
            btnGenerarEntrega.Location = new Point(88, 393);
            btnGenerarEntrega.Name = "btnGenerarEntrega";
            btnGenerarEntrega.Size = new Size(324, 46);
            btnGenerarEntrega.TabIndex = 7;
            btnGenerarEntrega.Text = "Generar orden de entrega";
            btnGenerarEntrega.UseVisualStyleBackColor = true;
            // 
            // btnGenerarRemito
            // 
            btnGenerarRemito.Location = new Point(88, 455);
            btnGenerarRemito.Name = "btnGenerarRemito";
            btnGenerarRemito.Size = new Size(324, 46);
            btnGenerarRemito.TabIndex = 8;
            btnGenerarRemito.Text = "Generar remito y despachar";
            btnGenerarRemito.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 535);
            Controls.Add(btnGenerarRemito);
            Controls.Add(btnGenerarEntrega);
            Controls.Add(btnEmpaquetar);
            Controls.Add(btnPrepararProductos);
            Controls.Add(btnGenerarSeleccion);
            Controls.Add(btnValidarOrdenes);
            Controls.Add(cboDeposito);
            Controls.Add(lblDeposito);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MenuPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Empresa";
            Load += MenuPrincipalForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.ComboBox cboDeposito;
        private System.Windows.Forms.Button btnValidarOrdenes;
        private System.Windows.Forms.Button btnGenerarSeleccion;
        private System.Windows.Forms.Button btnPrepararProductos;
        private System.Windows.Forms.Button btnEmpaquetar;
        private System.Windows.Forms.Button btnGenerarEntrega;
        private System.Windows.Forms.Button btnGenerarRemito;
    }
}