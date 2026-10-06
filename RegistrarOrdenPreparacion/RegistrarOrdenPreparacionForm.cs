/*using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion;

// Pantalla del CU-B.2.2.1 "Validar órdenes de preparación".
// Actor principal: Operador de depósito.
// Los comentarios "Paso N" referencian los pasos del flujo principal del caso de uso.
// Los comentarios "Excepción" marcan dónde va cada bifurcación (le ponen el número ustedes).
public class RegistrarOrdenPreparacionForm : Form
{
   // private readonly Operador _operador = Repositorio.ObtenerOperadorActual();
    //private Cliente _cliente;                                  // null hasta que se valida el CUIT (paso 4)
   // private readonly BindingList<ItemOrden> _items = new();
    private bool _salidaConfirmada;                            // true = cerrar sin volver a preguntar
    private bool _seRegistroOrden;                             // true = ya se registró al menos una orden

    // Controles
    private Label lblSesion, lblTotales;
    private TextBox txtCuit, txtRazonSocial, txtContrato;
    private Button btnBuscar, btnAgregar, btnValidar, btnSalir;
    private GroupBox gbEntrega, gbItems;
    private DateTimePicker dtpRequerida;
    private TextBox txtReferencia, txtDestinatario, txtDomicilio;
    private TextBox txtSku, txtCantidad;
    private DataGridView dgvItems;

    public RegistrarOrdenPreparacionForm()
    {
        ConstruirPantalla();
        CargarPantallaInicial();
    }

    // ===============================================================
    // CONSTRUCCIÓN DE LA PANTALLA (equivale a lo que genera el diseñador)
    // ===============================================================
    private void ConstruirPantalla()
    {
        Text = "Registrar orden de preparación";
        ClientSize = new Size(744, 640);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Font = new Font("Segoe UI", 10F);

        Controls.Add(new Label
        {
            Text = "Registrar orden de preparación",
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            Left = 12,
            Top = 10,
            AutoSize = true
        });

        lblSesion = new Label { Left = 12, Top = 42, AutoSize = true, ForeColor = SystemColors.GrayText };
        Controls.Add(lblSesion);

        // ---- Cliente (pasos 3 y 4) ----
        var gbCliente = new GroupBox { Text = "Cliente", Left = 12, Top = 68, Width = 720, Height = 78 };
        Etiqueta(gbCliente, "CUIT del cliente *", 12, 22);
        txtCuit = Caja(gbCliente, 12, 42, 150, false);
        txtCuit.MaxLength = 13;
        txtCuit.TextChanged += txtCuit_TextChanged;
        txtCuit.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnBuscar.PerformClick(); }
        };
        btnBuscar = new Button { Text = "Buscar", Left = 172, Top = 40, Width = 90, Height = 28 };
        btnBuscar.Click += btnBuscar_Click;
        gbCliente.Controls.Add(btnBuscar);
        Etiqueta(gbCliente, "Razón social", 280, 22);
        txtRazonSocial = Caja(gbCliente, 280, 42, 250, true);
        Etiqueta(gbCliente, "N.° de contrato", 545, 22);
        txtContrato = Caja(gbCliente, 545, 42, 155, true);
        Controls.Add(gbCliente);

        // ---- Datos de entrega (paso 5) ----
        gbEntrega = new GroupBox { Text = "Datos de entrega", Left = 12, Top = 156, Width = 720, Height = 118 };
        Etiqueta(gbEntrega, "Fecha y hora requerida de retiro *", 12, 20);
        dtpRequerida = new DateTimePicker
        {
            Left = 12,
            Top = 42,
            Width = 200,
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd/MM/yyyy HH:mm",
            ShowCheckBox = true,            // destildado = "sin completar"
            Checked = false
        };
        gbEntrega.Controls.Add(dtpRequerida);
        Etiqueta(gbEntrega, "Referencia del cliente", 225, 20);
        txtReferencia = Caja(gbEntrega, 225, 42, 210, false);
        Etiqueta(gbEntrega, "Destinatario *", 450, 20);
        txtDestinatario = Caja(gbEntrega, 450, 42, 250, false);
        Etiqueta(gbEntrega, "Domicilio de entrega *", 12, 72);
        txtDomicilio = Caja(gbEntrega, 12, 90, 688, false);
        Controls.Add(gbEntrega);

        // ---- Ítems (pasos 6 a 8) ----
        gbItems = new GroupBox { Text = "Ítems de la orden", Left = 12, Top = 284, Width = 720, Height = 290 };
        Etiqueta(gbItems, "Código SKU *", 12, 22);
        txtSku = Caja(gbItems, 12, 42, 190, false);
        txtSku.CharacterCasing = CharacterCasing.Upper;
        Etiqueta(gbItems, "Cantidad *", 215, 22);
        txtCantidad = Caja(gbItems, 215, 42, 100, false);
        txtCantidad.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnAgregar.PerformClick(); }
        };
        btnAgregar = new Button { Text = "Agregar ítem", Left = 330, Top = 40, Width = 130, Height = 30 };
        btnAgregar.Click += btnAgregar_Click;
        gbItems.Controls.Add(btnAgregar);

        dgvItems = new DataGridView
        {
            Left = 12,
            Top = 80,
            Width = 696,
            Height = 175,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            AutoGenerateColumns = false,
            RowHeadersVisible = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = SystemColors.Window
        };
        dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SKU", DataPropertyName = "Sku", FillWeight = 22 });
        dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "Descripcion", FillWeight = 48 });
        dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad", FillWeight = 15 });
        dgvItems.Columns.Add(new DataGridViewButtonColumn { Name = "colQuitar", HeaderText = "", Text = "Quitar", UseColumnTextForButtonValue = true, FillWeight = 15 });
      //  dgvItems.DataSource = _items;
        dgvItems.CellClick += dgvItems_CellClick;
        gbItems.Controls.Add(dgvItems);

        lblTotales = new Label { Left = 12, Top = 262, AutoSize = true, ForeColor = SystemColors.GrayText };
        gbItems.Controls.Add(lblTotales);
        Controls.Add(gbItems);

       // _items.ListChanged += (s, e) => ActualizarTotales();

        // ---- Botones principales ----
        btnSalir = new Button { Text = "Salir", Left = 12, Top = 590, Width = 100, Height = 34 };
        btnSalir.Click += (s, e) => Close();            // la confirmación está en OnFormClosing
        Controls.Add(btnSalir);

        btnValidar = new Button { Text = "Validar orden", Left = 612, Top = 590, Width = 120, Height = 34 };
        btnValidar.Click += btnValidar_Click;
        Controls.Add(btnValidar);
    }

    private static void Etiqueta(Control padre, string texto, int x, int y) =>
        padre.Controls.Add(new Label { Text = texto, Left = x, Top = y, AutoSize = true });

    private static TextBox Caja(Control padre, int x, int y, int ancho, bool soloLectura)
    {
        var t = new TextBox { Left = x, Top = y, Width = ancho, ReadOnly = soloLectura };
        if (soloLectura) t.BackColor = SystemColors.Control;
        padre.Controls.Add(t);
        return t;
    }

    // ===============================================================
    // PASO 2: pantalla con fecha/hora, operador y campos vacíos.
    // Hasta que se valide el cliente (paso 4) solo se puede usar el CUIT.
    // ===============================================================
    private void CargarPantallaInicial()
    {
        //lblSesion.Text = $"Operador: {_operador.Nombre} · {_operador.Deposito} · {DateTime.Now:dd/MM/yyyy HH:mm}";
        txtCuit.Clear();
        txtRazonSocial.Clear();
        txtContrato.Clear();
        dtpRequerida.Value = DateTime.Now.AddDays(2);
        dtpRequerida.Checked = false;
        HabilitarCarga(false);
        ActualizarTotales();
        ActiveControl = txtCuit;
    }

    private void HabilitarCarga(bool habilitar)
    {
        gbEntrega.Enabled = habilitar;
        gbItems.Enabled = habilitar;
        btnValidar.Enabled = habilitar;
    }

    // ===============================================================
    // PASOS 3 y 4: buscar el cliente por CUIT y verificar su contrato
    // ===============================================================
    private void btnBuscar_Click(object sender, EventArgs e)
    {
       // string cuit = Repositorio.SoloDigitos(txtCuit.Text);

        if (cuit.Length != 11)
        {
         //   Advertir(Msg.CuitInvalido);                    // Excepción paso 4: CUIT mal ingresado
            txtCuit.Focus();
            return;
        }

     //   var cliente = Repositorio.BuscarClientePorCuit(cuit);
        if (cliente == null)
        {
          //  Advertir(Msg.ClienteNoRegistrado);             // Excepción paso 4: cliente no registrado (vuelve al paso 3)
            txtCuit.SelectAll(); txtCuit.Focus();
            return;
        }

       // if (!cliente.ContratoVigente)
        {
          //  Advertir(Msg.ContratoNoVigente);               // Excepción paso 4: contrato no vigente (vuelve al paso 3)
            txtCuit.SelectAll(); txtCuit.Focus();
            return;
        }

        // Paso 4 (camino feliz): muestra razón social y contrato, y habilita el resto de la carga
      //  _cliente = cliente;
    //    txtRazonSocial.Text = cliente.RazonSocial;
     //   txtContrato.Text = cliente.NroContrato;
        HabilitarCarga(true);
        dtpRequerida.Focus();
    }

    // Si el operador cambia el CUIT después de validarlo, se invalida el cliente
    // y se descartan los ítems (los SKUs válidos dependen del cliente).
    private void txtCuit_TextChanged(object sender, EventArgs e)
    {
        //if (_cliente != null &&
        //    Repositorio.SoloDigitos(txtCuit.Text) != Repositorio.SoloDigitos(_cliente.Cuit))
        {
        //    _cliente = null;
        //    _items.Clear();
            txtRazonSocial.Clear();
            txtContrato.Clear();
            HabilitarCarga(false);
        }
    }

    // ===============================================================
    // PASOS 6 a 8: agregar un ítem a la grilla
    // ===============================================================
    private void btnAgregar_Click(object sender, EventArgs e)
    {
        // Paso 7: el SKU debe estar declarado por ESTE cliente y habilitado
      //  var sku = Repositorio.BuscarSku(_cliente, txtSku.Text.Trim());
      //  if (sku == null || !sku.Habilitado)
        {
        //    Advertir(Msg.SkuInvalido);                                  // Excepción paso 7: SKU inválido
            txtSku.Clear(); txtCantidad.Clear(); txtSku.Focus();        // limpia y vuelve al paso 6
            return;
        }

        // Paso 7: la cantidad debe ser un entero mayor a cero
        if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
        {
            Advertir(Msg.CantidadInvalida);                             // Excepción paso 7: cantidad inválida
            txtCantidad.Clear(); txtCantidad.Focus();                   // limpia y vuelve al paso 6
            return;
        }

        // Paso 8: incorporar a la grilla (si el SKU ya estaba, se suman las cantidades)
        var existente = _items.FirstOrDefault(i => i.Sku == sku.Codigo);
        if (existente != null)
        {
            existente.Cantidad += cantidad;
            _items.ResetBindings();
        }
        else
        {
            _items.Add(new ItemOrden { Sku = sku.Codigo, Descripcion = sku.Descripcion, Cantidad = cantidad });
        }

        txtSku.Clear(); txtCantidad.Clear(); txtSku.Focus();
    }

    private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvItems.Columns[e.ColumnIndex].Name == "colQuitar")
            _items.RemoveAt(e.RowIndex);
    }

    private void ActualizarTotales()
    {
        lblTotales.Text = $"Total: {_items.Count} ítems · {_items.Sum(i => i.Cantidad)} unidades";
    }

    // ===============================================================
    // PASOS 9 a 16: validar, confirmar y registrar
    // ===============================================================
    private void btnValidar_Click(object sender, EventArgs e)
    {
        LimpiarResaltado();

        // Paso 10: datos de entrega completos y al menos un ítem
        if (_cliente == null
            || !dtpRequerida.Checked
            || string.IsNullOrWhiteSpace(txtDestinatario.Text)
            || string.IsNullOrWhiteSpace(txtDomicilio.Text)
            || _items.Count == 0)
        {
            Advertir(Msg.CamposObligatorios);                           // Excepción paso 10: vuelve al paso 5
            return;
        }

        // Paso 11: anticipación mínima de las reglas operativas del contrato
        if (dtpRequerida.Value < DateTime.Now.AddHours(_cliente.AnticipacionMinimaHoras))
        {
            Advertir(string.Format(Msg.AnticipacionMinima, _cliente.AnticipacionMinimaHoras));   // Excepción paso 11
            dtpRequerida.Focus();                                       // vuelve al paso 5
            return;
        }

        // Paso 12: stock disponible de cada ítem
        var faltantes = new StringBuilder();
        for (int i = 0; i < _items.Count; i++)
        {
            int disponible = Repositorio.StockDisponible(_items[i].Sku);
            if (_items[i].Cantidad > disponible)
            {
                dgvItems.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;   // resalta el ítem sin stock
                faltantes.AppendLine(string.Format(Msg.StockInsuficiente, _items[i].Sku, _items[i].Cantidad, disponible));
            }
        }
        if (faltantes.Length > 0)
        {
            Advertir(faltantes.ToString().TrimEnd());                   // Excepción paso 12: vuelve al paso 6
            txtSku.Focus();
            return;
        }

        // Pasos 13 y 14: resumen y confirmación del operador
        var resumen = new StringBuilder();
        resumen.AppendLine($"Cliente: {_cliente.RazonSocial} (contrato {_cliente.NroContrato})");
        resumen.AppendLine($"Retiro: {dtpRequerida.Value:dd/MM/yyyy HH:mm}");
        resumen.AppendLine($"Destinatario: {txtDestinatario.Text.Trim()} - {txtDomicilio.Text.Trim()}");
        resumen.AppendLine($"Ítems: {_items.Count} · Unidades: {_items.Sum(i => i.Cantidad)}");
        resumen.AppendLine();
        resumen.Append(Msg.ConfirmaEnvio);

        if (MessageBox.Show(resumen.ToString(), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            return;                                                     // Excepción paso 14: no confirma, vuelve al paso 5 con los datos intactos
        }

        // Paso 15: registrar en la Cola de órdenes de preparación (AL7) en estado Pendiente
        var orden = new OrdenPreparacion
        {
            CuitCliente = _cliente.Cuit,
            RazonSocial = _cliente.RazonSocial,
            NroContrato = _cliente.NroContrato,
            Operador = _operador.Nombre,
            Deposito = _operador.Deposito,
            FechaCarga = DateTime.Now,
            FechaRequerida = dtpRequerida.Value,
            Referencia = txtReferencia.Text.Trim(),
            Destinatario = txtDestinatario.Text.Trim(),
            Domicilio = txtDomicilio.Text.Trim(),
            Items = _items.Select(i => new ItemOrden { Sku = i.Sku, Descripcion = i.Descripcion, Cantidad = i.Cantidad }).ToList()
        };

        int numero;
        try
        {
            numero = Repositorio.RegistrarOrden(orden);
        }
        catch (Exception)
        {
            Advertir(Msg.ErrorRegistro);                                // Excepción paso 15: rollback, no queda nada registrado
            return;
        }
        _seRegistroOrden = true;

        // Paso 16: comprobante con estado "Validada".
        // (El medio real para informar al cliente - mail, teléfono, etc. - lo define "Información de la empresa".)
        var comprobante = new StringBuilder();
        comprobante.AppendLine(string.Format(Msg.OrdenRegistrada, numero.ToString("000000")));
        comprobante.AppendLine();
        comprobante.AppendLine($"Cliente: {orden.RazonSocial} (contrato {orden.NroContrato})");
        comprobante.AppendLine($"Registrada por: {orden.Operador} · {orden.Deposito}");
        comprobante.AppendLine($"Fecha de carga: {orden.FechaCarga:dd/MM/yyyy HH:mm}");
        comprobante.AppendLine("Estado informado al cliente: Validada");
        comprobante.AppendLine();
        foreach (var it in orden.Items)
            comprobante.AppendLine($"  {it.Sku}  {it.Descripcion}  x {it.Cantidad}");
        MessageBox.Show(comprobante.ToString(), "Comprobante de orden", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Poscondición: la pantalla queda vacía y lista para registrar otra orden
        LimpiarPantalla();
    }

    // ===============================================================
    // PASO 17 / SALIDA: disponible siempre (botón Salir o cruz de la ventana)
    // ===============================================================
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (!_salidaConfirmada)
        {
            if (HayDatosCargados())
            {
              //  var r = MessageBox.Show(Msg.ConfirmaSalida, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    e.Cancel = true;        // se queda en la pantalla con los datos intactos
                    return;
                }
            }
            if (!_seRegistroOrden)
                MessageBox.Show(Msg.SinRegistro, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        base.OnFormClosing(e);
    }

    // ===============================================================
    // AUXILIARES
    // ===============================================================
    private bool HayDatosCargados() =>
        !string.IsNullOrWhiteSpace(txtCuit.Text)
        || _items.Count > 0
        || dtpRequerida.Checked
        || !string.IsNullOrWhiteSpace(txtReferencia.Text)
        || !string.IsNullOrWhiteSpace(txtDestinatario.Text)
        || !string.IsNullOrWhiteSpace(txtDomicilio.Text);

    private void LimpiarPantalla()
    {
        _cliente = null;
        _items.Clear();
        txtReferencia.Clear();
        txtDestinatario.Clear();
        txtDomicilio.Clear();
        txtSku.Clear();
        txtCantidad.Clear();
        CargarPantallaInicial();
    }

    private void LimpiarResaltado()
    {
        foreach (DataGridViewRow fila in dgvItems.Rows)
            fila.DefaultCellStyle.BackColor = Color.Empty;
    }

    private void InitializeComponent()
    {

    }

    private void Advertir(string mensaje) =>
        MessageBox.Show(mensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
}

*/