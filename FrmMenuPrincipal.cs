using System;
using System.Windows.Forms;

namespace OrdenesPreparacion;

// Menú de inicio: el operador elige el depósito y la actividad a realizar.
// Los controles están definidos en FrmMenuPrincipal.Designer.cs
public partial class FrmMenuPrincipal : Form
{
    public FrmMenuPrincipal()
    {
        InitializeComponent();

        // Se cargan los depósitos y se elige el primero.
        // Al elegirlo se dispara cboDeposito_SelectedIndexChanged, que lo deja guardado.
        cboDeposito.Items.AddRange(Repositorio.Depositos.ToArray());
        cboDeposito.SelectedIndex = 0;
    }

    private void cboDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboDeposito.SelectedItem != null)
            Repositorio.DepositoActual = cboDeposito.SelectedItem.ToString();
    }

    // ---- Un manejador por botón ----
    // Solo la primera opción tiene pantalla real. Las demás abren una pantalla provisoria.
    // Cuando tengan otra pantalla lista, reemplazar el FrmEnDesarrollo por el formulario real.

    private void btnValidarOrdenes_Click(object sender, EventArgs e) =>
        Abrir(new FrmRegistrarOrdenPreparacion());

    private void btnGenerarSeleccion_Click(object sender, EventArgs e) =>
        Abrir(new FrmEnDesarrollo("Generar orden de selección"));

    private void btnPrepararProductos_Click(object sender, EventArgs e) =>
        Abrir(new FrmEnDesarrollo("Preparar los productos"));

    private void btnEmpaquetar_Click(object sender, EventArgs e) =>
        Abrir(new FrmEnDesarrollo("Empaquetar productos"));

    private void btnGenerarEntrega_Click(object sender, EventArgs e) =>
        Abrir(new FrmEnDesarrollo("Generar orden de entrega"));

    private void btnGenerarRemito_Click(object sender, EventArgs e) =>
        Abrir(new FrmEnDesarrollo("Generar remito y despachar"));

    // La pantalla se crea recién al hacer clic (así toma el depósito elegido)
    // y el menú queda esperando hasta que se cierre.
    private void Abrir(Form pantalla)
    {
        using (pantalla)
        {
            pantalla.ShowDialog(this);
        }
    }
}