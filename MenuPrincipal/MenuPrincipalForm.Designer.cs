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
            RegistrarOrdenPrepracionBtn = new Button();
            GenerarOrdenSeleccionBtn = new Button();
            PrepararProductosBtn = new Button();
            EmpaquetarBtn = new Button();
            GenerarOrdenEntregaBtn = new Button();
            GenerarRemitoDespachar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // RegistrarOrdenPrepracionBtn
            // 
            RegistrarOrdenPrepracionBtn.Location = new Point(88, 74);
            RegistrarOrdenPrepracionBtn.Name = "RegistrarOrdenPrepracionBtn";
            RegistrarOrdenPrepracionBtn.Size = new Size(324, 46);
            RegistrarOrdenPrepracionBtn.TabIndex = 3;
            RegistrarOrdenPrepracionBtn.Text = "Registrar Orden de Preparación";
            RegistrarOrdenPrepracionBtn.UseVisualStyleBackColor = true;
            RegistrarOrdenPrepracionBtn.Click += btnValidarOrdenes_Click;
            // 
            // GenerarOrdenSeleccionBtn
            // 
            GenerarOrdenSeleccionBtn.Location = new Point(88, 136);
            GenerarOrdenSeleccionBtn.Name = "GenerarOrdenSeleccionBtn";
            GenerarOrdenSeleccionBtn.Size = new Size(324, 46);
            GenerarOrdenSeleccionBtn.TabIndex = 4;
            GenerarOrdenSeleccionBtn.Text = "Generar Orden de Selección";
            GenerarOrdenSeleccionBtn.UseVisualStyleBackColor = true;
            // 
            // PrepararProductosBtn
            // 
            PrepararProductosBtn.Location = new Point(88, 198);
            PrepararProductosBtn.Name = "PrepararProductosBtn";
            PrepararProductosBtn.Size = new Size(324, 46);
            PrepararProductosBtn.TabIndex = 5;
            PrepararProductosBtn.Text = "Preparar productos";
            PrepararProductosBtn.UseVisualStyleBackColor = true;
            PrepararProductosBtn.Click += btnPrepararProductos_Click;
            // 
            // EmpaquetarBtn
            // 
            EmpaquetarBtn.Location = new Point(88, 260);
            EmpaquetarBtn.Name = "EmpaquetarBtn";
            EmpaquetarBtn.Size = new Size(324, 46);
            EmpaquetarBtn.TabIndex = 6;
            EmpaquetarBtn.Text = "Empaquetar productos";
            EmpaquetarBtn.UseVisualStyleBackColor = true;
            // 
            // GenerarOrdenEntregaBtn
            // 
            GenerarOrdenEntregaBtn.Location = new Point(88, 326);
            GenerarOrdenEntregaBtn.Name = "GenerarOrdenEntregaBtn";
            GenerarOrdenEntregaBtn.Size = new Size(324, 46);
            GenerarOrdenEntregaBtn.TabIndex = 7;
            GenerarOrdenEntregaBtn.Text = "Generar Orden de Entrega";
            GenerarOrdenEntregaBtn.UseVisualStyleBackColor = true;
            GenerarOrdenEntregaBtn.Click += btnGenerarEntrega_Click;
            // 
            // GenerarRemitoDespachar
            // 
            GenerarRemitoDespachar.Location = new Point(88, 453);
            GenerarRemitoDespachar.Name = "GenerarRemitoDespachar";
            GenerarRemitoDespachar.Size = new Size(324, 46);
            GenerarRemitoDespachar.TabIndex = 8;
            GenerarRemitoDespachar.Text = "Generar remito y despachar";
            GenerarRemitoDespachar.UseVisualStyleBackColor = true;
            GenerarRemitoDespachar.Click += btnGenerarRemito_Click;
            // 
            // button1
            // 
            button1.Location = new Point(88, 391);
            button1.Name = "button1";
            button1.Size = new Size(324, 46);
            button1.TabIndex = 9;
            button1.Text = "Recepcionar Orden de Entrega";
            button1.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 554);
            Controls.Add(button1);
            Controls.Add(GenerarRemitoDespachar);
            Controls.Add(GenerarOrdenEntregaBtn);
            Controls.Add(EmpaquetarBtn);
            Controls.Add(PrepararProductosBtn);
            Controls.Add(GenerarOrdenSeleccionBtn);
            Controls.Add(RegistrarOrdenPrepracionBtn);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MenuPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Depósito";
            Load += MenuPrincipalForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button RegistrarOrdenPrepracionBtn;
        private System.Windows.Forms.Button GenerarOrdenSeleccionBtn;
        private System.Windows.Forms.Button PrepararProductosBtn;
        private System.Windows.Forms.Button EmpaquetarBtn;
        private System.Windows.Forms.Button GenerarOrdenEntregaBtn;
        private System.Windows.Forms.Button GenerarRemitoDespachar;
        private Button button1;
    }
}