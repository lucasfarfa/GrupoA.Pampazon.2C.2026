using GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos;
using System;
using System.Windows.Forms;

namespace OrdenesPreparacion;

// Menú de inicio: el operador elige el depósito y la actividad a realizar.
// Los controles están definidos en FrmMenuPrincipal.Designer.cs
public partial class MenuPrincipalForm : Form
{
    public MenuPrincipalForm()
    {
        InitializeComponent();

        cboDeposito.SelectedIndex = 0;
    }

    private void cboDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void lblDeposito_Click(object sender, EventArgs e)
    {

    }

    private void MenuPrincipalForm_Load(object sender, EventArgs e)
    {

    }

    private void btnPrepararProductos_Click(object sender, EventArgs e)
    {
        new PrepararProductosForm().ShowDialog();
    }

    private void btnValidarOrdenes_Click(object sender, EventArgs e)
    {

    }

    private void btnGenerarEntrega_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void btnGenerarRemito_Click(object sender, EventArgs e)
    {

    }
}