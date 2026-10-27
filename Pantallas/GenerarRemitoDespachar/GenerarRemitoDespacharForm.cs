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
        private void btnBuscarOrdenes_Click(object sender, EventArgs e)
        {
            // Cada búsqueda arranca de cero: se descarta la selección anterior y se vacían el nombre y las listas.
            lblNombreTransportista.Text = "";
            if (!_modelo.LimpiarBusqueda()) return;
            RefrescarListas();

            if (!int.TryParse(textDNITransportista.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos", Text);
                return;
            }

            if (!_modelo.DniValido(dni))
            {
                MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos", Text);
                return;
            }

            // Un DNI sin transportista registrado no tiene documentos: mismo mensaje que sin OE (CU-07, 4.2).
            if (!_modelo.BuscarTransportista(dni, out Transportista? transportista) || transportista == null)
            {
                MessageBox.Show("No hay órdenes de entrega pendientes para el DNI " + dni, Text);
                return;
            }

            lblNombreTransportista.Text = transportista.NombreApellido;
            RefrescarListas();

            // Si no tiene OE, igual quedan a la vista sus remitos pendientes de firma (CU-07, 4.3).
            if (_modelo.OrdenesPendientes.Count == 0)
            {
                MessageBox.Show("No hay órdenes de entrega pendientes para el DNI " + dni, Text);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            List<int> nrosOE = new List<int>();
            foreach (ListViewItem item in lvOEPendientesEntrega.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosOE.Add((int)item.Tag);
            }

            if (!_modelo.HayOrdenes(nrosOE))
            {
                MessageBox.Show("Seleccione al menos una orden de entrega", Text);
                return;
            }

            if (!_modelo.SeleccionarOrdenes(nrosOE)) return;

            RefrescarListas();
        }

        // Devuelve a la primera lista las OE de los remitos (clientes) marcados en "Se emitirán los siguientes remitos".
        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            List<int> nrosOE = new List<int>();
            foreach (ListViewItem item in lvRemitosEmitir.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosOE.AddRange((List<int>)item.Tag);
            }

            if (!_modelo.HayOrdenes(nrosOE)) return;

            if (!_modelo.DeseleccionarOrdenes(nrosOE)) return;

            RefrescarListas();
        }

        private void btnEmitirRemitos_Click(object sender, EventArgs e)
        {
            if (!_modelo.HaySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos una orden de entrega", Text);
                return;
            }

            int cantidad = _modelo.RemitosAEmitir.Count;
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
            List<int> nrosRemito = new List<int>();
            foreach (ListViewItem item in lvRemitosPendientesFirma.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosRemito.Add((int)item.Tag);
            }

            if (!_modelo.HayRemitos(nrosRemito))
            {
                MessageBox.Show("Debe seleccionar al menos un remito", Text);
                return;
            }

            if (MessageBox.Show("¿Confirma la entrega de los remitos N° " + string.Join(", ", nrosRemito.Select(nro => "R-" + nro)) + " con la copia firmada?", Text,
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

            foreach (var oe in _modelo.OrdenesPendientes)
            {
                var item = new ListViewItem(new[] { oe.Cliente.RazonSocial, oe.NroOE.ToString(), string.Join(", ", oe.Lineas.Select(l => l.NroOP)), oe.Lineas.Sum(l => l.Bultos).ToString() });
                item.Tag = oe.NroOE;
                lvOEPendientesEntrega.Items.Add(item);
            }

            foreach (var remito in _modelo.RemitosAEmitir)
            {
                var item = new ListViewItem(new[] { remito.Cliente.RazonSocial, string.Join(", ", remito.NrosOE) });
                item.Tag = remito.NrosOE;
                lvRemitosEmitir.Items.Add(item);
            }

            foreach (var remito in _modelo.RemitosPendientesFirma)
            {
                var item = new ListViewItem("R-" + remito.NroRemito);
                item.Tag = remito.NroRemito;
                lvRemitosPendientesFirma.Items.Add(item);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Cubre tanto "Cancelar" como cerrar la ventana.
        private void GenerarRemitoDespacharForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modelo.HaySeleccion)
            {
                MessageBox.Show("No se emitió ningún remito", Text);
            }
        }
    }
}
