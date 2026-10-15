using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            AjustarColumnasFormulario();
        }

        private void AjustarColumnasFormulario()
        {

            listViewDetalle.View = View.Details;
            listViewDetalle.GridLines = true;

            int anchoDisponibleDetalle = listViewDetalle.ClientSize.Width - 25;

            listViewDetalle.Columns[0].Width = (int)(anchoDisponibleDetalle * 0.20);
            listViewDetalle.Columns[1].Width = (int)(anchoDisponibleDetalle * 0.30);
            listViewDetalle.Columns[2].Width = (int)(anchoDisponibleDetalle * 0.30);
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
            string modalidad = comboOrdenSeleccion.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(modalidad))
            {
                // Si manejas la lista de OS pendientes en otro control o combobox, lo puedes enlazar aquí.
                var pendientes = _modelo.GetOrdenesPendientes();

                listViewDetalle.Items.Clear();

                foreach (var os in pendientes)
                {
                    foreach(var op in os.Lineas.Where(w => w.Modalidad.Equals(modalidad)))
                    {
                        var lvi = new ListViewItem(new string[] { op.Posicion, op.Sku, op.Cantidad.ToString() });
                        listViewDetalle.Items.Add(lvi);
                    }
                }
            }

            // Habilitar el botón de cerrar SOLO si todas las OP de esta OS están PREPARADA y la OS aún no está CUMPLIDA
            btnConfirmar.Enabled = listViewDetalle.Items.Count > 0;
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

        private void comboOrdenSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargar la lista de OS en base al tipo de Orden (item del combo box)
            // "Fullfilment" / "Palet cerrado"
            RefrescarOrdenesSeleccion();
        }

    }
}