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

        // Solo se puede marcar una fila: al marcar otra se desmarca la anterior (CU-05, paso 5).
        private void lvPendientes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!e.Item.Checked) return;

            foreach (var item in lvPendientes.CheckedItems.Cast<ListViewItem>().Where(item => item != e.Item).ToList())
                item.Checked = false;
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            if (lvPendientes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un grupo de órdenes", Text);
                return;
            }

            var item = lvPendientes.CheckedItems[0];
            string clave = (string)item.Tag!;
            string cliente = item.SubItems[0].Text;
            string transportista = item.SubItems[1].Text;
            string fechaRetiro = item.SubItems[2].Text;
            string cantidadOP = item.SubItems[3].Text;

            if (MessageBox.Show("¿Confirma la orden de entrega para " + cliente + ", transportista " + transportista +
                    ", retiro " + fechaRetiro + ", con " + cantidadOP + " OP?", Text,
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

            foreach (var grupo in _modelo.ObtenerGrupos())
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
