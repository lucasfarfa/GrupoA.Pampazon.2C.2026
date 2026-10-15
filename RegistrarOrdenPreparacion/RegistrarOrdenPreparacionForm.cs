using System.Globalization;
using System.Text.RegularExpressions;

namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    public partial class RegistrarOrdenPreparacionForm : Form
    {
        private RegistrarOrdenPreparacionModelo _modelo = new RegistrarOrdenPreparacionModelo();

        public RegistrarOrdenPreparacionForm()
        {
            InitializeComponent();
        }

        private void RegistrarOrdenPreparacionForm_Load(object sender, EventArgs e)
        {
            foreach (var cliente in _modelo.ObtenerClientes())
                cboCliente.Items.Add(cliente);

            foreach (var deposito in _modelo.ObtenerDepositos())
                cboDeposito.Items.Add(deposito);

            lblDisponible.Text = "";

            // El DNI no admite más de 8 caracteres (prueba A.5).
            txtDniTransportista.MaxLength = 8;
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al volver al cliente que ya tiene el modelo (cancelar el cambio o pantalla vacía) no hay nada que hacer.
            if (cboCliente.SelectedItem is not string cliente || cliente == _modelo.ClienteSeleccionado) return;

            if (!ConfirmarQuitarProductos())
            {
                cboCliente.SelectedItem = _modelo.ClienteSeleccionado;
                return;
            }

            if (!_modelo.SeleccionarCliente(cliente, out string cuit)) return;

            txtCuitCliente.Text = cuit;
            CargarSkus();
            RefrescarListas();
        }

        private void cboDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDeposito.SelectedItem is not string deposito || deposito == _modelo.DepositoSeleccionado) return;

            if (!ConfirmarQuitarProductos())
            {
                cboDeposito.SelectedItem = _modelo.DepositoSeleccionado;
                return;
            }

            if (!_modelo.SeleccionarDeposito(deposito)) return;

            CargarSkus();
            RefrescarListas();
        }

        // CU-01, 17.7 a 17.9.
        private bool ConfirmarQuitarProductos()
        {
            if (!_modelo.HayProductos) return true;

            return MessageBox.Show("Se quitarán los productos cargados. ¿Desea continuar?", Text,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        // Carga en SKU los productos del cliente con stock en el depósito (CU-01, paso 6 y 6.1).
        private void CargarSkus()
        {
            cboSku.Items.Clear();
            lblDisponible.Text = "";

            List<string> skus = _modelo.ObtenerSkus();
            foreach (var sku in skus)
                cboSku.Items.Add(sku);

            if (_modelo.ClienteSeleccionado != null && _modelo.DepositoSeleccionado != null && skus.Count == 0)
            {
                MessageBox.Show("El cliente no tiene mercadería en el depósito seleccionado", Text);
            }
        }

        private void cboSku_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisponible.Text = "";
            if (cboSku.SelectedItem is not string sku) return;

            if (!_modelo.ObtenerDisponible(sku, out int disponible)) return;

            lblDisponible.Text = disponible.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboSku.SelectedItem is not string sku)
            {
                MessageBox.Show("Debe seleccionar un SKU", Text);
                return;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero mayor a cero", Text);
                return;
            }

            if (!_modelo.ObtenerDisponible(sku, out int disponible)) return;

            if (cantidad > disponible)
            {
                MessageBox.Show("La cantidad supera el disponible del SKU " + sku + ": " + disponible + " unidades", Text);
                return;
            }

            if (listDetalleAgregado.Items.Cast<ListViewItem>().Any(item => (string)item.Tag! == sku))
            {
                MessageBox.Show("El SKU ya está en la orden. Quítelo de la lista para cambiar la cantidad", Text);
                return;
            }

            if (!_modelo.AgregarProducto(sku, cantidad)) return;

            cboSku.SelectedIndex = -1;
            txtCantidad.Clear();
            RefrescarListas();
        }

        private void btnQuitarSeleccionado_Click(object sender, EventArgs e)
        {
            if (listDetalleAgregado.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista", Text);
                return;
            }

            List<string> skus = listDetalleAgregado.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => (string)item.Tag!)
                .ToList();

            if (!_modelo.QuitarProductos(skus)) return;

            RefrescarListas();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string dni = txtDniTransportista.Text.Trim();
            string nombre = txtNombreTransportista.Text.Trim();
            string fecha = txtFechaRetiro.Text.Trim();

            var faltantes = new List<string>();
            if (cboCliente.SelectedIndex < 0) faltantes.Add("Cliente");
            if (cboDeposito.SelectedIndex < 0) faltantes.Add("Depósito");
            if (!rbFulfillment.Checked && !rbPaletCerrado.Checked) faltantes.Add("Modalidad");
            if (dni == "") faltantes.Add("DNI");
            if (nombre == "") faltantes.Add("Nombre del transportista");
            if (fecha == "") faltantes.Add("Fecha de retiro");

            if (faltantes.Count > 0)
            {
                MessageBox.Show("Debe completar: " + string.Join(", ", faltantes), Text);
                return;
            }

            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos", Text);
                return;
            }

            if (!Regex.IsMatch(nombre, @"^[\p{L} '\-]+$"))
            {
                MessageBox.Show("El nombre solo admite letras, espacios, apóstrofos y guiones", Text);
                return;
            }

            if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRetiro))
            {
                MessageBox.Show("Fecha inválida", Text);
                return;
            }

            if (fechaRetiro < DateTime.Today)
            {
                MessageBox.Show("La fecha de retiro no puede ser anterior a hoy", Text);
                return;
            }

            if (listDetalleAgregado.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", Text);
                return;
            }

            if (MessageBox.Show("¿Confirma el registro de la orden de preparación?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            string modalidad = rbFulfillment.Checked ? "Fulfillment" : "Palet cerrado";
            if (!_modelo.Registrar(modalidad, dni, nombre, fechaRetiro, out string nroOP)) return;

            MessageBox.Show("Orden de preparación N° " + nroOP + " registrada", Text);
            VaciarPantalla();
        }

        // Vuelve a cargar la grilla "Productos a preparar" con lo que tiene el modelo.
        private void RefrescarListas()
        {
            listDetalleAgregado.Items.Clear();

            foreach (var linea in _modelo.ObtenerLineas())
            {
                var item = new ListViewItem(new[] { linea.Sku, linea.Descripcion, linea.Cantidad.ToString() });
                item.Tag = linea.Sku;
                listDetalleAgregado.Items.Add(item);
            }
        }

        // Deja la pantalla vacía para una nueva orden (CU-01, paso 29). El modelo ya quedó vacío al registrar.
        private void VaciarPantalla()
        {
            cboCliente.SelectedIndex = -1;
            txtCuitCliente.Clear();
            cboDeposito.SelectedIndex = -1;
            rbFulfillment.Checked = false;
            rbPaletCerrado.Checked = false;
            txtDniTransportista.Clear();
            txtNombreTransportista.Clear();
            txtFechaRetiro.Clear();
            txtCantidad.Clear();
            CargarSkus();
            RefrescarListas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Cubre tanto "Cancelar" como cerrar la ventana (CU-01, Salida).
        private void RegistrarOrdenPreparacionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool hayDatos = cboCliente.SelectedIndex >= 0
                || cboDeposito.SelectedIndex >= 0
                || rbFulfillment.Checked
                || rbPaletCerrado.Checked
                || txtDniTransportista.Text.Trim() != ""
                || txtNombreTransportista.Text.Trim() != ""
                || txtFechaRetiro.Text.Trim() != ""
                || txtCantidad.Text.Trim() != ""
                || listDetalleAgregado.Items.Count > 0;

            if (!hayDatos) return;

            if (MessageBox.Show("No se registró ninguna orden de preparación. ¿Desea salir?", Text,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
