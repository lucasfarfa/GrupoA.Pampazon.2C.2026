using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrdenesPreparacion;

// Pantalla provisoria para las opciones del menú que todavía no están desarrolladas.
public class FrmEnDesarrollo : Form
{
    public FrmEnDesarrollo(string titulo)
    {
        Text = titulo;
        ClientSize = new Size(480, 220);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Font = new Font("Segoe UI", 10F);

        Controls.Add(new Label
        {
            Text = titulo,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            AutoSize = false,
            Left = 0,
            Top = 40,
            Width = 480,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        });

        Controls.Add(new Label
        {
            Text = $"Pantalla en desarrollo.\n{Repositorio.DepositoActual}",
            AutoSize = false,
            Left = 0,
            Top = 85,
            Width = 480,
            Height = 50,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = SystemColors.GrayText
        });

        var btnVolver = new Button { Text = "Volver", Left = 190, Top = 160, Width = 100, Height = 34 };
        btnVolver.Click += (s, e) => Close();
        Controls.Add(btnVolver);
    }
}