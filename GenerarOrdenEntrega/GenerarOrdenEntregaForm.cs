namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    public partial class GenerarOrdenEntregaForm : Form
    {
        private GenerarOrdenEntregaModelo _modelo = new GenerarOrdenEntregaModelo();

        public GenerarOrdenEntregaForm()
        {
            InitializeComponent();
        }

        private void GenerarOrdenEntregaForm_Load(object sender, EventArgs e)
        {
            // La pantalla trae el botón deshabilitado: se habilita para poder avisar que no hay fila marcada (CU-05, 7.1).
            btnGenerarOrden.Enabled = true;
            RefrescarListas();

            if (lvPendientes.Items.Count == 0)
            {
                MessageBox.Show("No hay órdenes preparadas pendientes de orden de entrega", Text);
            }
        }

        // Solo se puede marcar una fila: al marcar otra se desmarca la anterior.
        private void lvPendientes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!e.Item.Checked) return;

            // Recorre las filas marcadas (Cast las trata como ListViewItem) salvo la recién marcada (Where);
            // ToList hace una copia para poder desmarcarlas mientras se recorren.
            foreach (var item in lvPendientes.CheckedItems.Cast<ListViewItem>().Where(item => item != e.Item).ToList())
                item.Checked = false;
        }

        // Seleccionar una fila también la marca, así la elección funciona con clic en la fila o en la casilla.
        private void lvPendientes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item != null) e.Item.Checked = true;
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            if (lvPendientes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un grupo de órdenes", Text);
                return;
            }

            ListViewItem item = lvPendientes.CheckedItems[0];
            if (item.Tag == null) return;
            string clave = (string)item.Tag;

            if (!_modelo.ObtenerGrupo(clave, out GrupoOrdenes? grupo) || grupo == null) return;

            if (MessageBox.Show("¿Confirma la orden de entrega para " + grupo.Cliente + ", transportista " + grupo.NombreTransportista +
                    ", retiro " + grupo.FechaRetiro.ToString("dd/MM/yyyy") + ", con " + grupo.CantidadOP + " OP?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            if (!_modelo.GenerarOrdenEntrega(clave, out string nroOE)) return;

            MessageBox.Show("Orden de entrega N° " + nroOE + " generada", Text);
            RefrescarListas();
        }

        // Vuelve a cargar los grupos de OP Preparadas sin OE que tiene el modelo.
        private void RefrescarListas()
        {
            lvPendientes.Items.Clear();

            foreach (var grupo in _modelo.Grupos)
            {
                var item = new ListViewItem(new[] { grupo.Cliente, grupo.NombreTransportista, grupo.FechaRetiro.ToString("dd/MM/yyyy"), grupo.CantidadOP.ToString() });
                item.Tag = grupo.Clave;
                lvPendientes.Items.Add(item);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
