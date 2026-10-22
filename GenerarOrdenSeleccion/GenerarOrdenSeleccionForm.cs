namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    public partial class GenerarOrdenSeleccionForm : Form
    {
        private GenerarOrdenSeleccionModelo _modelo;

        // El depósito llega elegido desde el menú principal.
        public GenerarOrdenSeleccionForm(string deposito)
        {
            InitializeComponent();
            _modelo = new GenerarOrdenSeleccionModelo(deposito);
        }

        // Muestra el depósito y las OP Pendientes recibidas hoy (CU-02, pasos 1 y 2).
        private void GenerarOrdenSeleccionForm_Load(object sender, EventArgs e)
        {
            DepositoLbl.Text = _modelo.Deposito;

            comboModalidad.Items.Clear();
            comboModalidad.Items.AddRange(_modelo.Modalidades.ToArray());

            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;

            if (!_modelo.HayOrdenesPendientes)
            {
                MessageBox.Show("No hay órdenes de preparación pendientes", Text);
                return;
            }

            _modelo.Filtrar("", DateTime.Today, DateTime.Today, "");
            RefrescarListas();
        }

        // Botón "Buscar" (CU-02, pasos 3 a 5). Una fecha destildada no filtra por esa punta.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text.Trim();
            string modalidad = comboModalidad.Text.Trim();
            DateTime? desde = dtpFechaDesde.Checked ? dtpFechaDesde.Value.Date : null;
            DateTime? hasta = dtpFechaHasta.Checked ? dtpFechaHasta.Value.Date : null;

            if (desde != null && hasta != null && desde > hasta)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta", Text);
                return;
            }

            // La modalidad escrita tiene que ser una de la lista, sin importar mayúsculas (Any: ¿coincide con alguna?).
            if (modalidad != "" && !_modelo.Modalidades.Any(m => m.Equals(modalidad, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Modalidad inválida", Text);
                return;
            }

            bool hayOrdenes = _modelo.Filtrar(cliente, desde, hasta, modalidad);
            RefrescarListas();

            if (!hayOrdenes)
            {
                MessageBox.Show("No hay órdenes pendientes para los filtros ingresados", Text);
            }
        }

        // Vuelve los filtros a los valores iniciales; las OP incluidas se mantienen (CU-02, exc. 3.1).
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            comboModalidad.Text = "";
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaDesde.Checked = true;
            dtpFechaHasta.Value = DateTime.Today;
            dtpFechaHasta.Checked = true;

            _modelo.Filtrar("", DateTime.Today, DateTime.Today, "");
            RefrescarListas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (OPPendientesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una orden", Text);
                return;
            }

            List<string> nrosOP = new List<string>();
            foreach (ListViewItem item in OPPendientesListView.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosOP.Add((string)item.Tag);
            }

            if (!_modelo.IncluirOrdenes(nrosOP)) return;

            RefrescarListas();
        }

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {
            List<string> nrosOP = new List<string>();
            foreach (ListViewItem item in OPPendientesListView.Items)
            {
                if (item.Tag == null) return;
                nrosOP.Add((string)item.Tag);
            }

            if (!_modelo.IncluirOrdenes(nrosOP)) return;

            RefrescarListas();
        }

        // CU-02, exc. 9.1 y 9.2.
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (OPPendientesListView.SelectedItems.Count == 0) return;

            List<string> nrosOP = new List<string>();
            foreach (ListViewItem item in OPPendientesListView.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosOP.Add((string)item.Tag);
            }

            if (!_modelo.QuitarOrdenes(nrosOP)) return;

            RefrescarListas();
        }

        private void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            if (!_modelo.QuitarTodas()) return;

            RefrescarListas();
        }

        // El tilde indica OP incluida y lo decide el modelo: el usuario no puede tildar a mano.
        private void OPPendientesListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem item = OPPendientesListView.Items[e.Index];
            if (item.Tag == null) return;
            string nroOP = (string)item.Tag;
            e.NewValue = _modelo.EstaIncluida(nroOP) ? CheckState.Checked : CheckState.Unchecked;
        }

        // CU-02, pasos 10 a 16.
        private void GenerarOSBtn_Click(object sender, EventArgs e)
        {
            if (_modelo.CantidadIncluidas == 0)
            {
                MessageBox.Show("Debe agregar al menos una orden de preparación", Text);
                return;
            }

            if (MessageBox.Show("¿Confirma la generación de la orden de selección con " + _modelo.CantidadIncluidas + " OP?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            if (!_modelo.GenerarOrdenSeleccion(out string nroOS)) return;

            MessageBox.Show("Orden de selección N° " + nroOS + " generada", Text);
            RefrescarListas();
        }

        // Vuelve a cargar la grilla de OP y el resumen consolidado con lo que tiene el modelo.
        private void RefrescarListas()
        {
            OPPendientesListView.Items.Clear();
            listViewResumen.Items.Clear();

            foreach (var op in _modelo.OrdenesFiltradas)
            {
                var item = new ListViewItem(new[] { op.NroOP, op.Cliente, op.FechaRecepcion.ToString("dd/MM/yyyy HH:mm"), op.Modalidad });
                item.Tag = op.NroOP;
                item.Checked = _modelo.EstaIncluida(op.NroOP);
                OPPendientesListView.Items.Add(item);
            }

            foreach (var linea in _modelo.ResumenConsolidado)
            {
                var item = new ListViewItem(new[] { linea.Sku, linea.Cantidad.ToString() });
                item.Tag = linea.Sku;
                listViewResumen.Items.Add(item);
            }
        }

        private void CencelarBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Cubre tanto "Cancelar" como cerrar la ventana (CU-02, Salida).
        private void GenerarOrdenSeleccionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modelo.CantidadIncluidas == 0) return;

            if (MessageBox.Show("No se generó ninguna orden de selección. ¿Desea salir?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
