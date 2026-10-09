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
            RegistrarOrdenPrepracionBtn = new Button();
            GenerarOrdenSeleccionBtn = new Button();
            PrepararProductosBtn = new Button();
            EmpaquetarBtn = new Button();
            GenerarOrdenEntregaBtn = new Button();
            GenerarRemitoDespachar = new Button();
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
            cboDeposito.Items.AddRange(new object[] { "CORDOBA 1", "CORDOBA 2", "GBA 1", "GBA 2", "NEUQUEN", "ROSARIO", "SALTA", "TUCUMAN" });
            cboDeposito.Location = new Point(88, 83);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(324, 31);
            cboDeposito.Sorted = true;
            cboDeposito.TabIndex = 2;
            cboDeposito.SelectedIndexChanged += cboDeposito_SelectedIndexChanged;
            // 
            // RegistrarOrdenPrepracionBtn
            // 
            RegistrarOrdenPrepracionBtn.Location = new Point(88, 145);
            RegistrarOrdenPrepracionBtn.Name = "RegistrarOrdenPrepracionBtn";
            RegistrarOrdenPrepracionBtn.Size = new Size(324, 46);
            RegistrarOrdenPrepracionBtn.TabIndex = 3;
            RegistrarOrdenPrepracionBtn.Text = "Registrar Orden de Preparación";
            RegistrarOrdenPrepracionBtn.UseVisualStyleBackColor = true;
            RegistrarOrdenPrepracionBtn.Click += btnValidarOrdenes_Click;
            // 
            // GenerarOrdenSeleccionBtn
            // 
            GenerarOrdenSeleccionBtn.Location = new Point(88, 207);
            GenerarOrdenSeleccionBtn.Name = "GenerarOrdenSeleccionBtn";
            GenerarOrdenSeleccionBtn.Size = new Size(324, 46);
            GenerarOrdenSeleccionBtn.TabIndex = 4;
            GenerarOrdenSeleccionBtn.Text = "Generar Orden de Selección";
            GenerarOrdenSeleccionBtn.UseVisualStyleBackColor = true;
            // 
            // PrepararProductosBtn
            // 
            PrepararProductosBtn.Location = new Point(88, 269);
            PrepararProductosBtn.Name = "PrepararProductosBtn";
            PrepararProductosBtn.Size = new Size(324, 46);
            PrepararProductosBtn.TabIndex = 5;
            PrepararProductosBtn.Text = "Preparar los productos (picking)";
            PrepararProductosBtn.UseVisualStyleBackColor = true;
            PrepararProductosBtn.Click += btnPrepararProductos_Click;
            // 
            // EmpaquetarBtn
            // 
            EmpaquetarBtn.Location = new Point(88, 331);
            EmpaquetarBtn.Name = "EmpaquetarBtn";
            EmpaquetarBtn.Size = new Size(324, 46);
            EmpaquetarBtn.TabIndex = 6;
            EmpaquetarBtn.Text = "Empaquetar productos (fullfilment)";
            EmpaquetarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOrdenEntregaBtn
            // 
            GenerarOrdenEntregaBtn.Location = new Point(88, 397);
            GenerarOrdenEntregaBtn.Name = "GenerarOrdenEntregaBtn";
            GenerarOrdenEntregaBtn.Size = new Size(324, 46);
            GenerarOrdenEntregaBtn.TabIndex = 7;
            GenerarOrdenEntregaBtn.Text = "Generar Orden de Entrega";
            GenerarOrdenEntregaBtn.UseVisualStyleBackColor = true;
            GenerarOrdenEntregaBtn.Click += btnGenerarEntrega_Click;
            // 
            // GenerarRemitoDespachar
            // 
            GenerarRemitoDespachar.Location = new Point(88, 461);
            GenerarRemitoDespachar.Name = "GenerarRemitoDespachar";
            GenerarRemitoDespachar.Size = new Size(324, 46);
            GenerarRemitoDespachar.TabIndex = 8;
            GenerarRemitoDespachar.Text = "Generar remito y despachar";
            GenerarRemitoDespachar.UseVisualStyleBackColor = true;
            GenerarRemitoDespachar.Click += btnGenerarRemito_Click;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 554);
            Controls.Add(GenerarRemitoDespachar);
            Controls.Add(GenerarOrdenEntregaBtn);
            Controls.Add(EmpaquetarBtn);
            Controls.Add(PrepararProductosBtn);
            Controls.Add(GenerarOrdenSeleccionBtn);
            Controls.Add(RegistrarOrdenPrepracionBtn);
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
        private System.Windows.Forms.Button RegistrarOrdenPrepracionBtn;
        private System.Windows.Forms.Button GenerarOrdenSeleccionBtn;
        private System.Windows.Forms.Button PrepararProductosBtn;
        private System.Windows.Forms.Button EmpaquetarBtn;
        private System.Windows.Forms.Button GenerarOrdenEntregaBtn;
        private System.Windows.Forms.Button GenerarRemitoDespachar;
    }
}