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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.cboDeposito = new System.Windows.Forms.ComboBox();
            this.btnValidarOrdenes = new System.Windows.Forms.Button();
            this.btnGenerarSeleccion = new System.Windows.Forms.Button();
            this.btnPrepararProductos = new System.Windows.Forms.Button();
            this.btnEmpaquetar = new System.Windows.Forms.Button();
            this.btnGenerarEntrega = new System.Windows.Forms.Button();
            this.btnGenerarRemito = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Location = new System.Drawing.Point(0, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Menú Inicio Empresa";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDeposito
            //
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Location = new System.Drawing.Point(88, 52);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(60, 19);
            this.lblDeposito.TabIndex = 1;
            this.lblDeposito.Text = "Depósito";
            //
            // cboDeposito
            //
            this.cboDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeposito.FormattingEnabled = true;
            this.cboDeposito.Location = new System.Drawing.Point(88, 74);
            this.cboDeposito.Name = "cboDeposito";
            this.cboDeposito.Size = new System.Drawing.Size(324, 25);
            this.cboDeposito.TabIndex = 2;
            this.cboDeposito.SelectedIndexChanged += new System.EventHandler(this.cboDeposito_SelectedIndexChanged);
            //
            // btnValidarOrdenes
            //
            this.btnValidarOrdenes.Location = new System.Drawing.Point(88, 118);
            this.btnValidarOrdenes.Name = "btnValidarOrdenes";
            this.btnValidarOrdenes.Size = new System.Drawing.Size(324, 46);
            this.btnValidarOrdenes.TabIndex = 3;
            this.btnValidarOrdenes.Text = "Validar órdenes de preparación";
            this.btnValidarOrdenes.UseVisualStyleBackColor = true;
      //      this.btnValidarOrdenes.Click += new System.EventHandler(this.btnValidarOrdenes_Click);
            //
            // btnGenerarSeleccion
            //
            this.btnGenerarSeleccion.Location = new System.Drawing.Point(88, 180);
            this.btnGenerarSeleccion.Name = "btnGenerarSeleccion";
            this.btnGenerarSeleccion.Size = new System.Drawing.Size(324, 46);
            this.btnGenerarSeleccion.TabIndex = 4;
            this.btnGenerarSeleccion.Text = "Generar orden de selección";
            this.btnGenerarSeleccion.UseVisualStyleBackColor = true;
          //  this.btnGenerarSeleccion.Click += new System.EventHandler(this.btnGenerarSeleccion_Click);
            //
            // btnPrepararProductos
            //
            this.btnPrepararProductos.Location = new System.Drawing.Point(88, 242);
            this.btnPrepararProductos.Name = "btnPrepararProductos";
            this.btnPrepararProductos.Size = new System.Drawing.Size(324, 46);
            this.btnPrepararProductos.TabIndex = 5;
            this.btnPrepararProductos.Text = "Preparar los productos";
            this.btnPrepararProductos.UseVisualStyleBackColor = true;
         //   this.btnPrepararProductos.Click += new System.EventHandler(this.btnPrepararProductos_Click);
            //
            // btnEmpaquetar
            //
            this.btnEmpaquetar.Location = new System.Drawing.Point(88, 304);
            this.btnEmpaquetar.Name = "btnEmpaquetar";
            this.btnEmpaquetar.Size = new System.Drawing.Size(324, 46);
            this.btnEmpaquetar.TabIndex = 6;
            this.btnEmpaquetar.Text = "Empaquetar productos";
            this.btnEmpaquetar.UseVisualStyleBackColor = true;
         //   this.btnEmpaquetar.Click += new System.EventHandler(this.btnEmpaquetar_Click);
            //
            // btnGenerarEntrega
            //
            this.btnGenerarEntrega.Location = new System.Drawing.Point(88, 366);
            this.btnGenerarEntrega.Name = "btnGenerarEntrega";
            this.btnGenerarEntrega.Size = new System.Drawing.Size(324, 46);
            this.btnGenerarEntrega.TabIndex = 7;
            this.btnGenerarEntrega.Text = "Generar orden de entrega";
            this.btnGenerarEntrega.UseVisualStyleBackColor = true;
          //  this.btnGenerarEntrega.Click += new System.EventHandler(this.btnGenerarEntrega_Click);
            //
            // btnGenerarRemito
            //
            this.btnGenerarRemito.Location = new System.Drawing.Point(88, 428);
            this.btnGenerarRemito.Name = "btnGenerarRemito";
            this.btnGenerarRemito.Size = new System.Drawing.Size(324, 46);
            this.btnGenerarRemito.TabIndex = 8;
            this.btnGenerarRemito.Text = "Generar remito y despachar";
            this.btnGenerarRemito.UseVisualStyleBackColor = true;
           // this.btnGenerarRemito.Click += new System.EventHandler(this.btnGenerarRemito_Click);
            //
            // FrmMenuPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.btnGenerarRemito);
            this.Controls.Add(this.btnGenerarEntrega);
            this.Controls.Add(this.btnEmpaquetar);
            this.Controls.Add(this.btnPrepararProductos);
            this.Controls.Add(this.btnGenerarSeleccion);
            this.Controls.Add(this.btnValidarOrdenes);
            this.Controls.Add(this.cboDeposito);
            this.Controls.Add(this.lblDeposito);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Empresa";
            this.ResumeLayout(false);
            this.PerformLayout();
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