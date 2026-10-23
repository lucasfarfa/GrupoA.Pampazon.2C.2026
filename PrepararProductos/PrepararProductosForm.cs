namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    public partial class PrepararProductosForm : Form
    {
        private PrepararProductosModelo _modelo = new PrepararProductosModelo();

        public PrepararProductosForm()
        {
            InitializeComponent();
        }

        private void PrepararProductosForm_Load(object sender, EventArgs e)
        {
            lblDeposito.Text = "Depósito: " + _modelo.Deposito;
            RefrescarListas();

            // CU-03, 2.1
            if (_modelo.OrdenesPendientes.Count == 0)
                MessageBox.Show("No hay órdenes de selección pendientes", Text);
        }

        //La clave de la OS es el texto del ítem del combo.
        private void comboOrdenSeleccion_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboOrdenSeleccion.SelectedItem is not string nro) return;

            // Al recargar el combo se vuelve a elegir la OS que ya tiene el modelo: no hay nada que hacer.
            if (nro == _modelo.OrdenSeleccionada) return;

            if (!_modelo.SeleccionarOrden(nro)) return;

            RefrescarListas();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // 
            if (comboOrdenSeleccion.SelectedItem is not string nro)
            {
                MessageBox.Show("Debe seleccionar una orden de selección", Text);
                return;
            }

            // Cancelar la pregunta no registra la entrega 
            if (MessageBox.Show(
                    "¿Confirma que entregó toda la mercadería de la OS N° " + nro + " a Preparación?",
                    Text,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            // 
            if (!_modelo.ConfirmarEntrega(nro)) return;

            MessageBox.Show("La OS " + nro + " quedó Cumplida. Se descontó el stock de almacén.", Text);
            RefrescarListas();

            // 
            if (_modelo.OrdenesPendientes.Count == 0)
                MessageBox.Show("No hay órdenes de selección pendientes", Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Salida. Cubre "Cancelar" y cerrar la ventana con la X.
        // Solo avisa si hay una OS elegida sin confirmar.
        private void PrepararProductosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modelo.OrdenSeleccionada == "") return;

            MessageBox.Show("No se registró la entrega a Preparación", Text);
        }

        // Vuelve a cargar las OS pendientes y el detalle de la OS elegida con lo que tiene el modelo.
        private void RefrescarListas()
        {
            comboOrdenSeleccion.Items.Clear();
            List<string> ordenes = _modelo.OrdenesPendientes;
            foreach (string nro in ordenes)
                comboOrdenSeleccion.Items.Add(nro);

            if (_modelo.OrdenSeleccionada != "")
                comboOrdenSeleccion.SelectedItem = _modelo.OrdenSeleccionada;

            listViewDetalle.Items.Clear();
            foreach (LineaMercaderia linea in _modelo.Lineas)
            {
                listViewDetalle.Items.Add(new ListViewItem(new[]
                {
                    linea.Posicion,
                    linea.Sku,
                    linea.Cantidad.ToString()
                }));
            }

            btnConfirmar.Enabled = ordenes.Count > 0;
        }
    }
}
