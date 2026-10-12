namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    partial class btnCancelar
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
            btnGenerarOrden = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            Transportista = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            label3 = new Label();
            button3 = new Button();
            label5 = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Location = new Point(378, 531);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(199, 49);
            btnGenerarOrden.TabIndex = 3;
            btnGenerarOrden.Text = "Generar Orden de Entrega";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader5, Transportista, columnHeader7 });
            listView1.Location = new Point(9, 33);
            listView1.Name = "listView1";
            listView1.Size = new Size(684, 363);
            listView1.TabIndex = 14;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° OP";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            columnHeader2.Width = 70;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Bultos";
            columnHeader5.Width = 70;
            // 
            // Transportista
            // 
            Transportista.Text = "Transportista";
            Transportista.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Fecha Entrega";
            columnHeader7.Width = 140;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 21);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 27;
            label3.Text = "Depósito:";
            // 
            // button3
            // 
            button3.Location = new Point(583, 531);
            button3.Name = "button3";
            button3.Size = new Size(131, 49);
            button3.TabIndex = 32;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 21);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 34;
            label5.Text = "[DEPOSITO]";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(12, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(702, 455);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes preparadas sin orden de entrega";
            // 
            // button1
            // 
            button1.Location = new Point(9, 411);
            button1.Name = "button1";
            button1.Size = new Size(216, 38);
            button1.TabIndex = 34;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(231, 411);
            button2.Name = "button2";
            button2.Size = new Size(222, 38);
            button2.TabIndex = 35;
            button2.Text = "Quitar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(459, 411);
            button4.Name = "button4";
            button4.Size = new Size(234, 38);
            button4.TabIndex = 36;
            button4.Text = "Actualizar";
            button4.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 604);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(btnGenerarOrden);
            Controls.Add(label5);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "btnCancelar";
            Text = "GenerarOrdenEntrega";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGenerarOrden;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader7;
        private Label label3;
        private Button button3;
        private Label label5;
        private GroupBox groupBox1;
        private ColumnHeader Transportista;
        private Button button1;
        private Button button4;
        private Button button2;
    }
}