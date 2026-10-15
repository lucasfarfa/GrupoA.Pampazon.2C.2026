namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    public partial class RecepcionarOrdenEntregaForm : Form
    {
        private RecepcionarOrdenEntregaModelo _modelo = new RecepcionarOrdenEntregaModelo();

        public RecepcionarOrdenEntregaForm()
        {
            InitializeComponent();
        }

        private void RecepcionarOrdenEntregaForm_Load(object sender, EventArgs e)
        {
            // La pantalla permite marcar varias filas: se selecciona una sola OE (CU-06, paso 4).
            lvOEEmitidas.MultiSelect = false;
            CargarOrdenes();
        }

        // "Actualizar" vuelve a leer la lista de OE Emitidas (CU-06, paso 2).
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void CargarOrdenes()
        {
            RefrescarListas();

            if (lvOEEmitidas.Items.Count == 0)
            {
                MessageBox.Show("No hay órdenes de entrega para recepcionar", Text);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (lvOEEmitidas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de entrega", Text);
                return;
            }

            string nroOE = (string)lvOEEmitidas.SelectedItems[0].Tag!;

            if (MessageBox.Show("¿Confirma la recepción de la OE N° " + nroOE + " en Despacho?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            if (!_modelo.ConfirmarRecepcion(nroOE)) return;

            MessageBox.Show("Orden de entrega N° " + nroOE + " recepcionada", Text);
            RefrescarListas();
        }

        // Vuelve a cargar las OE Emitidas que tiene el modelo.
        private void RefrescarListas()
        {
            lvOEEmitidas.Items.Clear();

            foreach (var oe in _modelo.ObtenerOrdenesEmitidas())
            {
                var item = new ListViewItem(new[] { oe.NroOE, oe.Transportista.NombreApellido, oe.Cliente, oe.FechaEmision.ToString("dd/MM/yyyy"), oe.OrdenesPreparacion });
                item.Tag = oe.NroOE;
                lvOEEmitidas.Items.Add(item);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
