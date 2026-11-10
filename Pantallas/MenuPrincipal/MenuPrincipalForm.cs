using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;
using GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar;
using GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos;
using GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion;

namespace GrupoA.PampazonSA.AdministracionDeposito.MenuPrincipal;

// Menú de inicio: el operador elige el depósito y la actividad a realizar.
// El menú no lleva modelo: solo deja el depósito elegido en DepositoAlmacen.IdDepositoActivo y las pantallas lo leen de ahí.
// Los controles están definidos en MenuPrincipalForm.Designer.cs
public partial class MenuPrincipalForm : Form
{
    public MenuPrincipalForm()
    {
        InitializeComponent();

        cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;

        // Carga el combo con el código de cada depósito de Deposito.json.
        foreach (var deposito in DepositoAlmacen.Depositos)
            cboDeposito.Items.Add(deposito.IdDeposito);

        cboDeposito.SelectedIndex = 0;
    }

    // Deja el depósito elegido en el combo como depósito activo: las pantallas lo leen de DepositoAlmacen.
    private void ActivarDeposito()
    {
        DepositoAlmacen.IdDepositoActivo = cboDeposito.SelectedItem as string ?? "";
    }

    private void btnGenerarOrdenSeleccion_Click(object sender, EventArgs e)
    {
        ActivarDeposito();
        new GenerarOrdenSeleccionForm(DepositoAlmacen.IdDepositoActivo).ShowDialog();
    }

    private void btnPrepararProductos_Click(object sender, EventArgs e)
    {
        ActivarDeposito();
        new PrepararProductosForm().ShowDialog();
    }

    private void btnEmpaquetar_Click(object sender, EventArgs e)
    {
        ActivarDeposito();
        new EmpaquetarProductosForm().ShowDialog();
    }

    // Registrar OP no usa el depósito del menú: el operario lo elige en su propio combo.
    private void btnValidarOrdenes_Click(object sender, EventArgs e)
    {
        new RegistrarOrdenPreparacionForm().ShowDialog();
    }

    private void btnGenerarEntrega_Click(object sender, EventArgs e)
    {
        ActivarDeposito();
        new GenerarOrdenEntregaForm().ShowDialog();
    }

    private void btnRecepcionarOrdenEntrega_Click(object sender, EventArgs e)
    {
        ActivarDeposito();
        new RecepcionarOrdenEntregaForm().ShowDialog();
    }

    private void btnGenerarRemito_Click(object sender, EventArgs e)
    {
        ActivarDeposito();
        new GenerarRemitoDespacharForm().ShowDialog();
    }
}
