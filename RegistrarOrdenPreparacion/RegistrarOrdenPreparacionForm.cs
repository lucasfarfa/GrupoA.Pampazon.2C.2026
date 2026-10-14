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

        private void RegistrarOrdenPreparacionForm_Load(object sender, EventArgs e)
        {
            _cargando = true;

            cboCliente.DataSource = _modelo.ObtenerClientes();
            cboCliente.DisplayMember = nameof(ClienteOrden.Nombre);
            cboCliente.SelectedIndex = -1;

            cboDeposito.DataSource = _modelo.ObtenerDepositos();
            cboDeposito.SelectedIndex = -1;

          

            _cargando = false;
            ActualizarProductosDisponibles();
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;

            if (!ConfirmarCambioConProductos())
            {
                Restaurar(cboCliente, _idxCliente);
                return;
            }

            _idxCliente = cboCliente.SelectedIndex;
            txtCuitCliente.Text = cboCliente.SelectedItem is ClienteOrden cliente ? cliente.Cuit : "";
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

            
            
            txtCantidad.Clear();

            _cargando = false;
        }

        private void cboSku_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;

            if (cboSku.SelectedItem is ProductoStock producto)
            {
                
                //txtDisponible.Text = producto.Disponible.ToString();
                txtCantidad.Focus();
            }
            else
            {
                
                //txtDisponible.Clear();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboSku.SelectedItem is not ProductoStock producto)
            {
                Advertir("Seleccione el SKU del producto.", cboSku);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                Advertir("Ingrese una cantidad válida mayor a cero.", txtCantidad);
                return;
            }

            if (cantidad > producto.Disponible)
            {
                Advertir("La cantidad ingresada supera el stock disponible.", txtCantidad);
                return;
            }

            // Verificar si el producto ya fue agregado a la grilla
            var lineaExistente = _lineas.FirstOrDefault(l => l.Sku == producto.Sku);
            if (lineaExistente != null)
            {
                if (lineaExistente.Cantidad + cantidad > producto.Disponible)
                {
                    Advertir("La cantidad total acumulada supera el stock disponible.", txtCantidad);
                    return;
                }
                lineaExistente.Cantidad += cantidad;
               
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

        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem is not ClienteOrden cliente)
            {
                Advertir("Seleccione el cliente.", cboCliente);
                return;
            }

            if (cboDeposito.SelectedItem is not string deposito)
            {
                Advertir("Seleccione el depósito.", cboDeposito);
                return;
            }

            if (!RegistrarOrdenPreparacionModelo.DniValido(txtDniTransportista.Text))
            {
                Advertir("Ingrese un DNI válido (7 u 8 dígitos).", txtDniTransportista);
                return;
            }

            if (_lineas.Count == 0)
            {
                Advertir("Agregue al menos un producto a preparar.", cboSku);
                return;
            }

            LimpiarFormulario();
        }

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
            || !string.IsNullOrWhiteSpace(txtDniTransportista.Text)
            || _lineas.Count > 0;

        private void LimpiarFormulario()
        {
            _cargando = true;

            cboCliente.SelectedIndex = -1;
            cboDeposito.SelectedIndex = -1;
            _idxCliente = -1;
            _idxDeposito = -1;
            txtCuitCliente.Clear();
            rbFulfillment.Checked = false;
            rbPaletCerrado.Checked = false;
            txtDniTransportista.Clear();
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

        private void lblDni_Click(object sender, EventArgs e)
        {
        }

       

        private void btnRegistrarOp_Click(object sender, EventArgs e)
        {
            btnRegistrar_Click(sender, e);
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}