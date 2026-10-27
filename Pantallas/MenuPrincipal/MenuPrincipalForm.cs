using GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar;
using GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos;
using GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion;

namespace GrupoA.PampazonSA.AdministracionDeposito.MenuPrincipal;

// Menú de inicio: el operador elige el depósito y la actividad a realizar.
// Los controles están definidos en MenuPrincipalForm.Designer.cs
public partial class MenuPrincipalForm : Form
{
    public MenuPrincipalForm()
    {
        InitializeComponent();

        cboDeposito.Items.AddRange(new object[] { "GBA (Gran Buenos Aires)", "ROS (Rosario)", "CBA (Córdoba)" });
        cboDeposito.SelectedIndex = 0;
    }

    // Código del depósito elegido en el combo, en el mismo orden que sus ítems; "" si no hay ninguno elegido.
    private string ObtenerDeposito()
    {
        string[] codigos = { "GBA", "ROS", "CBA" };
        if (cboDeposito.SelectedIndex < 0 || cboDeposito.SelectedIndex >= codigos.Length) return "";
        return codigos[cboDeposito.SelectedIndex];
    }

    private void btnGenerarOrdenSeleccion_Click(object sender, EventArgs e)
    {
        new GenerarOrdenSeleccionForm(ObtenerDeposito()).ShowDialog();
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

    private void btnRecepcionarOrdenEntrega_Click(object sender, EventArgs e)
    {
        new RecepcionarOrdenEntregaForm().ShowDialog();
    }

    private void btnGenerarRemito_Click(object sender, EventArgs e)
    {
        new GenerarRemitoDespacharForm().ShowDialog();
    }
}