namespace GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos
{
    public partial class EmpaquetarProductosForm : Form
    {
        private EmpaquetarProductosModelo _modelo = new EmpaquetarProductosModelo();

        public EmpaquetarProductosForm()
        {
            InitializeComponent();
        }

        private void EmpaquetarProductosForm_Load(object sender, EventArgs e)
        {
            MostrarOrdenAsignada();
        }

        // Asigna la siguiente OP por FIFO y muestra sus datos 
        private void MostrarOrdenAsignada()
        {
            if (!_modelo.AsignarSiguienteOrden(out OrdenPreparacion? orden) || orden == null)
            {
                lblNroOrden.Text = "";
                lblModalidad.Text = "";
                lblTotalBultos.Text = "";
                btnEmpaquetar.Enabled = false;
                RefrescarListas();
                MessageBox.Show("No hay órdenes para empaquetar", Text);
                return;
            }

            lblNroOrden.Text = orden.NroOP.ToString();
            lblModalidad.Text = orden.Modalidad;
            lblTotalBultos.Text = _modelo.TotalBultos.ToString();
            btnEmpaquetar.Enabled = true;
            RefrescarListas();
        }

        // Vuelve a cargar los productos de la OP asignada con lo que tiene el modelo.
        private void RefrescarListas()
        {
            lstProductos.Items.Clear();

            foreach (var producto in _modelo.Lineas)
            {
                var item = new ListViewItem(new[] { producto.Sku, producto.Descripcion, producto.Cantidad.ToString() });
                item.Tag = producto.Sku;
                lstProductos.Items.Add(item);
            }
        }

        private void btnEmpaquetar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma el empaquetado de la OP N° " + _modelo.NroOPAsignada + " en " + _modelo.TotalBultos + " bultos?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            if (!_modelo.ConfirmarEmpaquetado(out int nroOP)) return;

            MessageBox.Show("Orden de preparación N° " + nroOP + " preparada", Text);
            MostrarOrdenAsignada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Cubre tanto "Cancelar" como cerrar la ventana. La OP sigue En preparación.
        private void EmpaquetarProductosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modelo.HayOrdenAsignada)
            {
                MessageBox.Show("No se registró el empaquetado", Text);
            }
        }
    }
}
