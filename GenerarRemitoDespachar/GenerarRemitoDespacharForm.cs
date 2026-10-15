using System.Text.RegularExpressions;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    public partial class GenerarRemitoDespacharForm : Form
    {
        private GenerarRemitoDespacharModelo _modelo = new GenerarRemitoDespacharModelo();

        public GenerarRemitoDespacharForm()
        {
            InitializeComponent();
        }

        // Botón "Buscar órdenes": identifica al transportista por DNI.
        private void button1_Click(object sender, EventArgs e)
        {
            string dni = textDNITransportista.Text.Trim();

            // Cada búsqueda arranca de cero: se descarta la selección anterior y se vacían el nombre y las listas.
            lblNombreTransportista.Text = "";
            _modelo.LimpiarBusqueda();
            RefrescarListas();

            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos", Text);
                return;
            }

            // Un DNI sin transportista registrado no tiene documentos: mismo mensaje que sin OE (CU-07, 4.2).
            if (!_modelo.BuscarTransportista(dni, out Transportista? transportista))
            {
                MessageBox.Show("No hay órdenes de entrega pendientes para el DNI " + dni, Text);
                return;
            }

            lblNombreTransportista.Text = transportista!.NombreApellido;
            RefrescarListas();

            // Si no tiene OE, igual quedan a la vista sus remitos pendientes de firma (CU-07, 4.3).
            if (!_modelo.BuscarOrdenesPendientes(out _))
            {
                MessageBox.Show("No hay órdenes de entrega pendientes para el DNI " + dni, Text);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (lvOEPendientesEntrega.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una orden de entrega", Text);
                return;
            }

            List<string> nrosOE = lvOEPendientesEntrega.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => (string)item.Tag!)
                .ToList();

            if (!_modelo.SeleccionarOrdenes(nrosOE)) return;

            RefrescarListas();
        }

        // Devuelve a la primera lista las OE de los remitos (clientes) marcados en "Se emitirán los siguientes remitos".
        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            if (lvRemitosEmitir.SelectedItems.Count == 0) return;

            List<string> nrosOE = lvRemitosEmitir.SelectedItems
                .Cast<ListViewItem>()
                .SelectMany(item => (List<string>)item.Tag!)
                .ToList();

            if (!_modelo.DeseleccionarOrdenes(nrosOE)) return;

            RefrescarListas();
        }

        private void btnEmitirRemitos_Click(object sender, EventArgs e)
        {
            if (lvRemitosEmitir.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una orden de entrega", Text);
                return;
            }

            int cantidad = lvRemitosEmitir.Items.Count;
            if (MessageBox.Show("Se emitirán " + cantidad + " remitos. ¿Confirma?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            if (!_modelo.EmitirRemitos()) return;

            RefrescarListas();
        }

        private void btnConfirmarEntregaFirma_Click(object sender, EventArgs e)
        {
            if (lvRemitosPendientesFirma.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un remito", Text);
                return;
            }

            List<string> nrosRemito = lvRemitosPendientesFirma.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => (string)item.Tag!)
                .ToList();

            if (MessageBox.Show("¿Confirma la entrega de los remitos N° " + string.Join(", ", nrosRemito) + " con la copia firmada?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            if (!_modelo.ConfirmarEntrega(nrosRemito)) return;

            MessageBox.Show("Entrega confirmada", Text);
            RefrescarListas();
        }

        // Vuelve a cargar las tres listas con lo que tiene el modelo para el transportista identificado.
        private void RefrescarListas()
        {
            lvOEPendientesEntrega.Items.Clear();
            lvRemitosEmitir.Items.Clear();
            lvRemitosPendientesFirma.Items.Clear();

            _modelo.BuscarOrdenesPendientes(out List<OrdenDeEntrega> ordenes);
            foreach (var oe in ordenes)
            {
                var item = new ListViewItem(new[] { oe.Cliente, oe.NroOE, oe.OrdenesPreparacion, oe.Bultos.ToString() });
                item.Tag = oe.NroOE;
                lvOEPendientesEntrega.Items.Add(item);
            }

            foreach (var remito in _modelo.ObtenerRemitosAEmitir())
            {
                var item = new ListViewItem(new[] { remito.Cliente, string.Join(", ", remito.NrosOE) });
                item.Tag = remito.NrosOE;
                lvRemitosEmitir.Items.Add(item);
            }

            foreach (var remito in _modelo.ObtenerRemitosPendientesFirma())
            {
                var item = new ListViewItem(remito.NroRemito);
                item.Tag = remito.NroRemito;
                lvRemitosPendientesFirma.Items.Add(item);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Cubre tanto "Cancelar" como cerrar la ventana. Los remitos sin firmar quedan en el modelo
        // y se ven al volver a buscar el mismo DNI (CU-07, 16.3).
        private void GenerarRemitoDespacharForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modelo.HaySeleccion)
            {
                MessageBox.Show("No se emitió ningún remito", Text);
            }
        }
    }
}
