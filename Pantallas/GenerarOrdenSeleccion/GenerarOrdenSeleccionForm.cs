namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    public partial class GenerarOrdenSeleccionForm : Form
    {
        private GenerarOrdenSeleccionModelo _modelo;

        // El depósito llega elegido desde el menú principal.
        public GenerarOrdenSeleccionForm(string deposito)
        {
            InitializeComponent();
            _modelo = new GenerarOrdenSeleccionModelo();
            _modelo.SeleccionarDeposito(deposito);
        }

        // Muestra el depósito y todas las OP Pendientes: las fechas arrancan destildadas (CU-02, pasos 1 y 2).
        private void GenerarOrdenSeleccionForm_Load(object sender, EventArgs e)
        {
            // No debería pasar: el menú solo ofrece depósitos válidos.
            if (_modelo.Deposito == null) return;

            DepositoLbl.Text = _modelo.Deposito;

            comboModalidad.Items.Clear();
            foreach (var modalidad in _modelo.Modalidades)
                comboModalidad.Items.Add(TextoModalidad(modalidad));

            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Value = DateTime.Today;
            dtpFechaHasta.Checked = false;

            if (!_modelo.HayOrdenesPendientes)
            {
                MessageBox.Show("No hay órdenes de preparación pendientes", Text);
                return;
            }

            if (!_modelo.Filtrar("", null, null, null)) return;
            RefrescarListas();
        }

        // Botón "Buscar" (CU-02, pasos 3 a 5). Una fecha destildada no filtra por esa punta.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text.Trim();
            DateTime? desde = dtpFechaDesde.Checked ? dtpFechaDesde.Value.Date : null;
            DateTime? hasta = dtpFechaHasta.Checked ? dtpFechaHasta.Value.Date : null;

            if (!_modelo.FechasValidas(desde, hasta))
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta", Text);
                return;
            }

            if (!ConvertirModalidad(comboModalidad.Text.Trim(), out Modalidad? modalidad))
            {
                MessageBox.Show("Modalidad inválida", Text);
                return;
            }

            if (!_modelo.ModalidadValida(modalidad))
            {
                MessageBox.Show("Modalidad inválida", Text);
                return;
            }

            if (!_modelo.Filtrar(cliente, desde, hasta, modalidad)) return;
            RefrescarListas();

            if (_modelo.OrdenesFiltradas.Count == 0)
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
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Value = DateTime.Today;
            dtpFechaHasta.Checked = false;

            if (!_modelo.Filtrar("", null, null, null)) return;
            RefrescarListas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<int> nrosOP = new List<int>();
            foreach (ListViewItem item in OPPendientesListView.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosOP.Add((int)item.Tag);
            }

            if (!_modelo.HayOrdenes(nrosOP))
            {
                MessageBox.Show("Seleccione al menos una orden", Text);
                return;
            }

            if (!_modelo.IncluirOrdenes(nrosOP)) return;

            RefrescarListas();
        }

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {
            List<int> nrosOP = new List<int>();
            foreach (ListViewItem item in OPPendientesListView.Items)
            {
                if (item.Tag == null) return;
                nrosOP.Add((int)item.Tag);
            }

            if (!_modelo.IncluirOrdenes(nrosOP)) return;

            RefrescarListas();
        }

        // CU-02, exc. 9.1 y 9.2.
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            List<int> nrosOP = new List<int>();
            foreach (ListViewItem item in OPPendientesListView.SelectedItems)
            {
                if (item.Tag == null) return;
                nrosOP.Add((int)item.Tag);
            }

            if (!_modelo.HayOrdenes(nrosOP)) return;

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
            int nroOP = (int)item.Tag;
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

            if (!_modelo.GenerarOrdenSeleccion(out int nroOS)) return;

            MessageBox.Show("Orden de selección N° " + nroOS + " generada", Text);
            RefrescarListas();
        }

        // Convierte el texto del combo a la modalidad, sin importar mayúsculas; vacío no filtra (null).
        // Devuelve false si no coincide con ninguna.
        private bool ConvertirModalidad(string texto, out Modalidad? modalidad)
        {
            modalidad = null;
            if (texto == "") return true;
            foreach (var m in _modelo.Modalidades)
            {
                if (TextoModalidad(m).Equals(texto, StringComparison.OrdinalIgnoreCase))
                {
                    modalidad = m;
                    return true;
                }
            }
            return false;
        }

        // Texto con que se muestra la modalidad.
        private string TextoModalidad(Modalidad modalidad)
        {
            return modalidad == Modalidad.PaletCerrado ? "Palet cerrado" : "Fulfillment";
        }

        // Vuelve a cargar la grilla de OP y el resumen consolidado con lo que tiene el modelo.
        private void RefrescarListas()
        {
            OPPendientesListView.Items.Clear();
            listViewResumen.Items.Clear();

            foreach (var op in _modelo.OrdenesFiltradas)
            {
                var item = new ListViewItem(new[] { op.NroOP.ToString(), op.Cliente, op.FechaRecepcion.ToString("dd/MM/yyyy HH:mm"), TextoModalidad(op.Modalidad) });
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
