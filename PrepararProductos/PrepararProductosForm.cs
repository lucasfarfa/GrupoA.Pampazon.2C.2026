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
            listViewOS.Items.Clear();
            LimpiarDetalle();

            var pendientes = _modelo.GetOrdenesPendientes();
            foreach (var os in pendientes)
            {
                var item = new ListViewItem(new string[]
                {
                    os.Id,
                    os.FechaEmision.ToString("dd/MM/yyyy HH:mm"),
                    string.Join(", ", os.OrdenesPreparacion),
                    os.Lineas.Count.ToString()
                });
                item.Tag = os.Id;
                listViewOS.Items.Add(item);
            }

            lblNoHayOS.Visible = pendientes.Count == 0;
        }

        private void LimpiarDetalle()
        {
            listViewDetalle.Items.Clear();
            grpDetalle.Text = "Mercadería a retirar del almacén";
            btnConfirmar.Enabled = false;
        }

        private void listViewOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarDetalle();
            if (listViewOS.SelectedItems.Count == 0) return;

            var osId = (string)listViewOS.SelectedItems[0].Tag;
            var lineas = _modelo.GetLineasOrdenadas(osId);

            foreach (var l in lineas)
            {
                listViewDetalle.Items.Add(new ListViewItem(new string[]
                {
                    l.Posicion,
                    l.Cliente,
                    l.Sku,
                    l.Descripcion,
                    l.Cantidad.ToString(),
                    l.Unidad
                }));
            }

            grpDetalle.Text = "Mercadería a retirar del almacén (" + osId + ")";
            btnConfirmar.Enabled = lineas.Count > 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (listViewOS.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una orden de selección.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var osId = (string)listViewOS.SelectedItems[0].Tag;

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarOrdenesSeleccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}