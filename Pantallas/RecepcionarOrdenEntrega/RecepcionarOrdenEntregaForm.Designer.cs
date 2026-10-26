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
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(679, 379);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Órdenes de Entrega emitidas";
            // 
            // lvOEEmitidas
            // 
            lvOEEmitidas.Columns.AddRange(new ColumnHeader[] { NOECol, TransportistaCol, ClienteCol, EmisionCol, CantOPCol });
            lvOEEmitidas.Location = new Point(10, 20);
            lvOEEmitidas.Margin = new Padding(3, 2, 3, 2);
            lvOEEmitidas.Name = "lvOEEmitidas";
            lvOEEmitidas.Size = new Size(657, 314);
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
            btnConfirmar.Location = new Point(10, 338);
            btnConfirmar.Margin = new Padding(3, 2, 3, 2);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(656, 32);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar recepción en Despacho";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(592, 392);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(481, 392);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(98, 32);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // RecepcionarOrdenEntregaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 432);
            Controls.Add(btnActualizar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RecepcionarOrdenEntregaForm";
            Text = "RecepcionarOrdenEntregaForm";
            Load += RecepcionarOrdenEntregaForm_Load;
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