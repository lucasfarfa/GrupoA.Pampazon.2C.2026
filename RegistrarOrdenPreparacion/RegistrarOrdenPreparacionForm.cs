using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    public partial class RegistrarOrdenPreparacionForm : Form
    {
        private readonly RegistrarOrdenPreparacionModelo _modelo = new RegistrarOrdenPreparacionModelo();
        private readonly BindingList<LineaOrden> _lineas = new BindingList<LineaOrden>();

        private bool _cargando;          // true = se están cargando los combos: se ignoran sus eventos
        private int _idxCliente = -1;    // última selección aceptada de cada combo (para poder volver atrás)
        private int _idxDeposito = -1;

        public RegistrarOrdenPreparacionForm()
        {
            InitializeComponent();
        }

        // ===============================================================
        // CARGA INICIAL
        // ===============================================================
        private void RegistrarOrdenPreparacionForm_Load(object sender, EventArgs e)
        {
            _cargando = true;

            cboCliente.DataSource = _modelo.ObtenerClientes();
            cboCliente.DisplayMember = nameof(ClienteOrden.Nombre);
            cboCliente.SelectedIndex = -1;

            cboDeposito.DataSource = _modelo.ObtenerDepositos();
            cboDeposito.SelectedIndex = -1;

            dgvProductos.DataSource = _lineas;

            _cargando = false;
            ActualizarProductosDisponibles();
        }

        // ===============================================================
        // 1.1 CLIENTE  /  1.2 DEPÓSITO
        // Al cambiar alguno, los SKU y el stock disponible son otros: se quitan los productos ya cargados.
        // ===============================================================
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;

            if (!ConfirmarCambioConProductos())
            {
                Restaurar(cboCliente, _idxCliente);
                return;
            }

            _idxCliente = cboCliente.SelectedIndex;
            txtCuit.Text = cboCliente.SelectedItem is ClienteOrden cliente ? cliente.Cuit : "";
            _lineas.Clear();
            ActualizarProductosDisponibles();
        }

        private void cboDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;

            if (!ConfirmarCambioConProductos())
            {
                Restaurar(cboDeposito, _idxDeposito);
                return;
            }

            _idxDeposito = cboDeposito.SelectedIndex;
            _lineas.Clear();
            ActualizarProductosDisponibles();
        }

        private bool ConfirmarCambioConProductos()
        {
            if (_lineas.Count == 0) return true;

            return MessageBox.Show(
                "Al cambiar el cliente o el depósito se quitarán los productos agregados. ¿Desea continuar?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void Restaurar(ComboBox combo, int indice)
        {
            _cargando = true;
            combo.SelectedIndex = indice;
            _cargando = false;
        }

        // Carga los SKU del cliente en ese depósito. Si falta cliente o depósito, bloquea la carga de productos.
        private void ActualizarProductosDisponibles()
        {
            _cargando = true;

            if (cboCliente.SelectedItem is ClienteOrden cliente && cboDeposito.SelectedItem is string deposito)
            {
                cboSku.DataSource = _modelo.ObtenerProductos(cliente, deposito);
                cboSku.DisplayMember = nameof(ProductoStock.Sku);
                cboSku.SelectedIndex = -1;
                cboSku.Enabled = txtCantidad.Enabled = btnAgregar.Enabled = true;
            }
            else
            {
                cboSku.DataSource = null;
                cboSku.Enabled = txtCantidad.Enabled = btnAgregar.Enabled = false;
            }

            txtDescripcion.Clear();
            txtDisponible.Clear();
            txtCantidad.Clear();

            _cargando = false;
        }

        // ===============================================================
        // 1.6 SKU: al elegirlo se muestran su descripción y el stock disponible
        // ===============================================================
        private void cboSku_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;

            if (cboSku.SelectedItem is ProductoStock producto)
            {
                txtDescripcion.Text = producto.Descripcion;
                txtDisponible.Text = producto.Disponible.ToString();
                txtCantidad.Focus();
            }
            else
            {
                txtDescripcion.Clear();
                txtDisponible.Clear();
            }
        }

        // ===============================================================
        // 1.6 y 1.7: AGREGAR producto a la grilla
        // ===============================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // 1.6 SKU
            if (cboSku.SelectedItem is not ProductoStock producto)
            {
                Advertir("Seleccione el SKU del producto.", cboSku);
                return;
            }

            // 1.7 Cantidad: entero mayor a cero
            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                Advertir("La cantidad debe ser un número entero mayor a cero.", txtCantidad);
                return;
            }

            // La cantidad (sumada a la que ya está en la grilla) no puede superar el disponible
            var existente = _lineas.FirstOrDefault(l => l.Sku == producto.Sku);
            int total = cantidad + (existente?.Cantidad ?? 0);
            if (total > producto.Disponible)
            {
                Advertir($"Stock insuficiente para {producto.Sku}: solicitado {total}, disponible {producto.Disponible}.", txtCantidad);
                return;
            }

            if (existente != null)
            {
                existente.Cantidad = total;      // el SKU ya estaba: se suma la cantidad
                _lineas.ResetBindings();
            }
            else
            {
                _lineas.Add(new LineaOrden
                {
                    Sku = producto.Sku,
                    Descripcion = producto.Descripcion,
                    Cantidad = cantidad,
                    Disponible = producto.Disponible
                });
            }

            cboSku.SelectedIndex = -1;
            txtCantidad.Clear();
            cboSku.Focus();
        }

        // ===============================================================
        // QUITAR SELECCIONADO
        // ===============================================================
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                Advertir("Seleccione en la grilla el producto que desea quitar.", dgvProductos);
                return;
            }

            _lineas.RemoveAt(dgvProductos.SelectedRows[0].Index);
        }

        // ===============================================================
        // REGISTRAR OP
        // ===============================================================
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1.1 Cliente
            if (cboCliente.SelectedItem is not ClienteOrden cliente)
            {
                Advertir("Seleccione el cliente.", cboCliente);
                return;
            }

            // 1.2 Depósito
            if (cboDeposito.SelectedItem is not string deposito)
            {
                Advertir("Seleccione el depósito.", cboDeposito);
                return;
            }

            // 1.3 Modalidad
            string modalidad = rbFulfillment.Checked ? "Fulfillment"
                             : rbPaletCerrado.Checked ? "Palet cerrado"
                             : null;
            if (modalidad == null)
            {
                Advertir("Seleccione la modalidad: Fulfillment o Palet cerrado.", rbFulfillment);
                return;
            }

            // 1.4 DNI del transportista
            if (!RegistrarOrdenPreparacionModelo.DniValido(txtDni.Text))
            {
                Advertir("Ingrese un DNI válido (7 u 8 dígitos).", txtDni);
                return;
            }

            // 1.5 Patente
            if (!RegistrarOrdenPreparacionModelo.PatenteValida(txtPatente.Text))
            {
                Advertir("Ingrese una patente válida (por ejemplo AB123CD o ABC123).", txtPatente);
                return;
            }

            // Al menos un producto
            if (_lineas.Count == 0)
            {
                Advertir("Agregue al menos un producto a preparar.", cboSku);
                return;
            }

            string numero;
            try
            {
                numero = _modelo.RegistrarOrden(cliente, deposito, modalidad, txtDni.Text, txtPatente.Text, _lineas);
            }
            catch (InvalidOperationException ex)
            {
                // Por ejemplo, otra orden comprometió el stock mientras se cargaba ésta
                Advertir(ex.Message, cboSku);
                return;
            }

            MessageBox.Show($"La orden de preparación {numero} fue registrada en estado Pendiente.",
                Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        // ===============================================================
        // CANCELAR / CERRAR
        // ===============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();     // la confirmación está en FormClosing
        }

        private void RegistrarOrdenPreparacionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!HayDatosCargados()) return;

            var respuesta = MessageBox.Show("¿Desea salir? Se perderán los datos no confirmados.",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                e.Cancel = true;     // se queda en la pantalla con sus datos
        }

        // ===============================================================
        // AUXILIARES
        // ===============================================================
        private void SoloDigitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private bool HayDatosCargados() =>
            cboCliente.SelectedIndex >= 0
            || cboDeposito.SelectedIndex >= 0
            || rbFulfillment.Checked
            || rbPaletCerrado.Checked
            || !string.IsNullOrWhiteSpace(txtDni.Text)
            || !string.IsNullOrWhiteSpace(txtPatente.Text)
            || _lineas.Count > 0;

        private void LimpiarFormulario()
        {
            _cargando = true;

            cboCliente.SelectedIndex = -1;
            cboDeposito.SelectedIndex = -1;
            _idxCliente = -1;
            _idxDeposito = -1;
            txtCuit.Clear();
            rbFulfillment.Checked = false;
            rbPaletCerrado.Checked = false;
            txtDni.Clear();
            txtPatente.Clear();
            _lineas.Clear();

            _cargando = false;
            ActualizarProductosDisponibles();
            cboCliente.Focus();
        }

        private void Advertir(string mensaje, Control foco)
        {
            MessageBox.Show(mensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            foco?.Focus();
        }
    }
}
