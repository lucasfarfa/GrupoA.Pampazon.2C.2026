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
    private readonly MenuPrincipalModelo _modelo = new MenuPrincipalModelo();

    public MenuPrincipalForm()
    {
        InitializeComponent();

        cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDeposito.Items.AddRange(_modelo.Depositos.ToArray());
        cboDeposito.SelectedIndex = 0;
    }

    // Código del depósito elegido en el combo; "" si no hay ninguno elegido.
    private string ObtenerDeposito()
    {
        return cboDeposito.SelectedItem as string ?? "";
    }

    private void btnGenerarOrdenSeleccion_Click(object sender, EventArgs e)
    {
        if (!_modelo.SeleccionarDeposito(ObtenerDeposito())) return;
        new GenerarOrdenSeleccionForm(_modelo.DepositoSeleccionado).ShowDialog();
    }

    private void btnPrepararProductos_Click(object sender, EventArgs e)
    {
        if (!_modelo.SeleccionarDeposito(ObtenerDeposito())) return;
        new PrepararProductosForm().ShowDialog();
    }

    private void btnEmpaquetar_Click(object sender, EventArgs e)
    {
        if (!_modelo.SeleccionarDeposito(ObtenerDeposito())) return;
        new EmpaquetarProductosForm().ShowDialog();
    }

    private void btnValidarOrdenes_Click(object sender, EventArgs e)
    {
        new RegistrarOrdenPreparacionForm().ShowDialog();
    }

    private void btnGenerarEntrega_Click(object sender, EventArgs e)
    {
        if (!_modelo.SeleccionarDeposito(ObtenerDeposito())) return;
        new GenerarOrdenEntregaForm().ShowDialog();
    }

    private void btnRecepcionarOrdenEntrega_Click(object sender, EventArgs e)
    {
        if (!_modelo.SeleccionarDeposito(ObtenerDeposito())) return;
        new RecepcionarOrdenEntregaForm().ShowDialog();
    }

    private void btnGenerarRemito_Click(object sender, EventArgs e)
    {
        if (!_modelo.SeleccionarDeposito(ObtenerDeposito())) return;
        new GenerarRemitoDespacharForm().ShowDialog();
    }
}