using System;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    // Pantalla 3 - Registrar picking.
    // Almacén elige una Orden de Selección pendiente, ve la mercadería consolidada a retirar
    // (por posición) y confirma la entrega a Preparación: la OS queda Cumplida y se descuenta el stock.
    public partial class PrepararProductosForm : Form
    {
        private PrepararProductosModelo _modelo;

        public PrepararProductosForm()
        {
            InitializeComponent();
        }

        private void PrepararProductosForm_Load(object sender, EventArgs e)
        {
            InitializeModelBindings();
        }

        public void InitializeModelBindings()
        {
            if (_modelo == null) _modelo = new PrepararProductosModelo();

            lblDeposito.Text = "Depósito: " + _modelo.Deposito;
            RefrescarOrdenesSeleccion();
        }

        private void RefrescarOrdenesSeleccion()
        {
            // Nota: Si en tu diseñador agregaste un ListView para las OS, puedes incluirlo aquí.
            // Mantenemos la estructura limpia del detalle que tenías visualmente.
            LimpiarDetalle();

            var pendientes = _modelo.GetOrdenesPendientes();
            // Si manejas la lista de OS pendientes en otro control o combobox, lo puedes enlazar aquí.
        }

        private void LimpiarDetalle()
        {
            listViewDetalle.Items.Clear();
            grpDetalle.Text = "Mercadería a retirar del almacén";
            btnConfirmar.Enabled = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Lógica de confirmación por ID de Orden de Selección seleccionado de prueba o interfaz
            string osId = "OS-000032"; // Ejemplo base o tomado del control correspondiente

            var respuesta = MessageBox.Show(
                "¿Confirma que la mercadería de la " + osId + " fue entregada a Preparación?\n\n" +
                "La orden quedará Cumplida y se descontará el stock del almacén.",
                "Confirmar entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            var error = _modelo.ConfirmarEntregaAPreparacion(osId);
            if (error != null)
            {
                MessageBox.Show(error, "No se pudo confirmar la entrega",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("La " + osId + " quedó Cumplida. Se descontó el stock del almacén.",
                "Entrega confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefrescarOrdenesSeleccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}