using GrupoA.PampazonSA.AdministracionDeposito.CU04EmpaquetarProductos;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar;
using GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos;
using GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion;
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

        //cboDeposito.SelectedIndex = 0;
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
    private void btnGenerarOrdenSeleccion_Click(object sender, EventArgs e)
    {
        new GenerarOrdenSeleccionForm().ShowDialog();
    }

    private void btnPrepararProductos_Click(object sender, EventArgs e)
    {
        new PrepararProductosForm().ShowDialog();
    }

    private void btnEmpaquetar_Click(object sender, EventArgs e)
    {
        new EmpaquetarProductosForm().ShowDialog();
    }

    private void btnValidarOrdenes_Click(object sender, EventArgs e)
    {
        new RegistrarOrdenPreparacionForm().ShowDialog();
    }

    private void btnGenerarEntrega_Click(object sender, EventArgs e)
    {
        new GenerarOrdenEntregaForm().ShowDialog();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        new RecepcionarOrdenEntregaForm().ShowDialog();
    }

    private void btnGenerarRemito_Click(object sender, EventArgs e)
    {
        new GenerarRemitoDespacharForm().ShowDialog();
    }
}