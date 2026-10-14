namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    partial class RecepcionarOrdenEntregaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lvOEEmitidas = new ListView();
            NOECol = new ColumnHeader();
            TransportistaCol = new ColumnHeader();
            ClienteCol = new ColumnHeader();
            EmisionCol = new ColumnHeader();
            CantOPCol = new ColumnHeader();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            btnActualizar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lvOEEmitidas);
            groupBox1.Controls.Add(btnConfirmar);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 505);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Órdenes de Entrega emitidas";
            // 
            // lvOEEmitidas
            // 
            lvOEEmitidas.Columns.AddRange(new ColumnHeader[] { NOECol, TransportistaCol, ClienteCol, EmisionCol, CantOPCol });
            lvOEEmitidas.Location = new Point(11, 27);
            lvOEEmitidas.Name = "lvOEEmitidas";
            lvOEEmitidas.Size = new Size(750, 417);
            lvOEEmitidas.TabIndex = 0;
            lvOEEmitidas.UseCompatibleStateImageBehavior = false;
            lvOEEmitidas.View = View.Details;
            // 
            // NOECol
            // 
            NOECol.Text = "N° OE";
            NOECol.Width = 100;
            // 
            // TransportistaCol
            // 
            TransportistaCol.Text = "Transportista";
            TransportistaCol.Width = 120;
            // 
            // ClienteCol
            // 
            ClienteCol.Text = "Cliente";
            ClienteCol.Width = 100;
            // 
            // EmisionCol
            // 
            EmisionCol.Text = "Fecha Emisión";
            EmisionCol.Width = 120;
            // 
            // CantOPCol
            // 
            CantOPCol.Text = "N° OP que contiene";
            CantOPCol.Width = 250;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(11, 450);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(750, 43);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar recepción en Despacho";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(677, 523);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 43);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(550, 523);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(112, 43);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // RecepcionarOrdenEntregaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 576);
            Controls.Add(btnActualizar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Name = "RecepcionarOrdenEntregaForm";
            Text = "RecepcionarOrdenEntregaForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView lvOEEmitidas;
        private ColumnHeader NOECol;
        private ColumnHeader TransportistaCol;
        private ColumnHeader ClienteCol;
        private ColumnHeader EmisionCol;
        private Button btnConfirmar;
        private Button btnCancelar;
        private ColumnHeader CantOPCol;
        private Button btnActualizar;
    }
}