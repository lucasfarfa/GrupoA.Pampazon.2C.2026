using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    public partial class PrepararProductosForm : Form
    {
        private PrepararProductosModelo _modelo;

        public PrepararProductosForm()
        {
            InitializeComponent();
        }

        public void InitializeModelBindings()
        {
            if (_modelo == null) _modelo = new PrepararProductosModelo();
            RefrescarListaOrdenesSeleccion();

            btnIniciarPicking.Enabled = false;
            btnFinalizarPicking.Enabled = false;
            btnCierreSeleccion.Enabled = false;
        }

        private void RefrescarListaOrdenesSeleccion()
        {
            listViewOS.Items.Clear();
            foreach (var os in _modelo.OrdenesSeleccion.Where(w => w.Estado != "CUMPLIDA"))
            {
                var lvi = new ListViewItem(new string[] { os.Id, os.Descripcion, os.Estado });
                listViewOS.Items.Add(lvi);
                CambiarEstadoFila(lvi, 2, os.Estado);
            }

            if (_modelo.OrdenesSeleccion.Where(w => w.Estado != "CUMPLIDA").Count() == 0)
            {
                MessageBox.Show("No hay Ordenes de Selección pendientes de cumplir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTituloNoHayOS.Visible = true;
            } else
            {
                lblTituloNoHayOS.Visible = false;
            }
        }

        private void AjustarColumnasFormulario()
        {

            // 1. Obtener el ancho total disponible restando el espacio del scroll
            int anchoDisponibleOS = listViewOS.ClientSize.Width - 25;
            listViewOS.Columns[0].Width = (int)(anchoDisponibleOS * 0.20);
            listViewOS.Columns[1].Width = (int)(anchoDisponibleOS * 0.30);
            listViewOS.Columns[2].Width = (int)(anchoDisponibleOS * 0.30);

            int anchoDisponibleOP = listViewOP.ClientSize.Width - 25;
            listViewOP.Columns[0].Width = (int)(anchoDisponibleOP * 0.20);
            listViewOP.Columns[1].Width = (int)(anchoDisponibleOP * 0.30);
            listViewOP.Columns[2].Width = (int)(anchoDisponibleOP * 0.30);
            listViewOP.Columns[3].Width = (int)(anchoDisponibleOP * 0.20);

            int anchoDisponibleProductos = listViewProductos.ClientSize.Width - 25;
            listViewProductos.Columns[0].Width = (int)(anchoDisponibleProductos * 0.20);
            listViewProductos.Columns[1].Width = (int)(anchoDisponibleProductos * 0.20);
            listViewProductos.Columns[2].Width = (int)(anchoDisponibleProductos * 0.20);
            listViewProductos.Columns[3].Width = (int)(anchoDisponibleProductos * 0.20);
        }

        private void listViewOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOS.SelectedItems.Count == 0) return;

            var itemSeleccionado = listViewOS.SelectedItems[0];
            var osId = itemSeleccionado.SubItems[0].Text;
            var os = _modelo?.GetOrdenSeleccionById(osId);
            if (os == null) return;

            listViewOP.Items.Clear();
            listViewProductos.Items.Clear();

            btnIniciarPicking.Enabled = false;
            btnFinalizarPicking.Enabled = false;
            btnCierreSeleccion.Enabled = false;

            if (string.Equals(os.Estado, "CUMPLIDA", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La Orden de Selección ya esta cumplida.\nPor favor, selecciona un elemento de la lista que no este CUMPLIDO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var op in os.OrdenesPreparacion)
            {
                var lvi = new ListViewItem(new string[] { op.Id, op.Cliente, string.Empty, op.Estado });
                listViewOP.Items.Add(lvi);
                CambiarEstadoFila(lvi, 3, op.Estado);
            }

            // Habilitar el botón de cerrar SOLO si todas las OP de esta OS están PICKEADA y la OS aún no está CUMPLIDA
            btnCierreSeleccion.Enabled = os.OrdenesPreparacion.All(o => string.Equals(o.Estado, "PICKEADA", StringComparison.OrdinalIgnoreCase))
                                      && !string.Equals(os.Estado, "CUMPLIDA", StringComparison.OrdinalIgnoreCase);
        }

        private void listViewOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewProductos.Items.Clear();

            if (listViewOP.SelectedItems.Count == 0) return;

            var itemSeleccionado = listViewOP.SelectedItems[0];
            var opId = itemSeleccionado.SubItems[0].Text;

            var op = _modelo?.GetOrdenPreparacionById(opId);
            if (op == null) return;

            // llenar productos
            foreach (var p in op.Productos)
            {
                listViewProductos.Items.Add(new ListViewItem(new string[] { p.Sku, p.Nombre, p.Cantidad.ToString("0.##"), p.Ubicacion }));
            }

            // botones según estado
            if (string.Equals(op.Estado, "SELECCIONADA", StringComparison.OrdinalIgnoreCase))
            {
                btnIniciarPicking.Enabled = true;
                btnFinalizarPicking.Enabled = false;
            }
            else if (string.Equals(op.Estado, "EN_PROCESO", StringComparison.OrdinalIgnoreCase))
            {
                btnIniciarPicking.Enabled = false;
                btnFinalizarPicking.Enabled = true;
            }
            else
            {
                btnIniciarPicking.Enabled = false;
                btnFinalizarPicking.Enabled = false;
            }

            // mantener color/estado visual
            CambiarEstadoFila(itemSeleccionado, 3, op.Estado);
        }

        private void listViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            RefrescarListaOrdenesSeleccion();
        }

        private void btnIniciarPicking_Click(object sender, EventArgs e)
        {
            if (listViewOP.SelectedItems.Count == 0) return;

            var opId = listViewOP.SelectedItems[0].SubItems[0].Text;
            var ok = _modelo?.IniciarPicking(opId) ?? false;
            if (!ok) return;

            // actualizar UI
            var item = listViewOP.SelectedItems[0];
            item.SubItems[3].Text = "EN_PROCESO";
            CambiarEstadoFila(item, 3, "EN_PROCESO");
            btnIniciarPicking.Enabled = false;
            btnFinalizarPicking.Enabled = true;
        }

        private void btnFinalizarPicking_Click(object sender, EventArgs e)
        {
            ValidarBotonCierreSeleccion();
        }

        private void btnCierreSeleccion_Click(object sender, EventArgs e)
        {
            if (listViewOS.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un elemento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var osId = listViewOS.SelectedItems[0].SubItems[0].Text;
            var os = _modelo?.GetOrdenSeleccionById(osId);
            if (os == null) return;

            // Cerrar la OS si corresponde (en el prototipo, forzamos el cierre)
            os.Estado = "CUMPLIDA";
            listViewOS.SelectedItems[0].SubItems[2].Text = "CUMPLIDA";
            CambiarEstadoFila(listViewOS.SelectedItems[0], 2, "CUMPLIDA");
            listViewOP.Items.Clear();
            listViewProductos.Items.Clear();

            RefrescarListaOrdenesSeleccion();

            btnCierreSeleccion.Enabled = false;
        }

        private void ValidarBotonCierreSeleccion()
        {
            if (listViewOP.SelectedItems.Count == 0) return;

            var opId = listViewOP.SelectedItems[0].SubItems[0].Text;
            var ok = _modelo?.FinalizarPicking(opId) ?? false;
            if (!ok) return;

            // actualizar UI
            var item = listViewOP.SelectedItems[0];
            item.SubItems[3].Text = "PICKEADA";
            CambiarEstadoFila(item, 3, "PICKEADA");
            btnFinalizarPicking.Enabled = false;

            // habilitar cierre si la OS padre tiene todas las OP PICKEADA y la OS no está aún CUMPLIDA
            var parent = _modelo?.OrdenesSeleccion.FirstOrDefault(os => os.OrdenesPreparacion.Any(o => o.Id == opId));
            if (parent != null)
            {
                var listo = parent.OrdenesPreparacion.All(o => string.Equals(o.Estado, "PICKEADA", StringComparison.OrdinalIgnoreCase));
                btnCierreSeleccion.Enabled = listo && !string.Equals(parent.Estado, "CUMPLIDA", StringComparison.OrdinalIgnoreCase);
                // actualizar estado visual de la OS en la lista si existe
                foreach (ListViewItem l in listViewOS.Items)
                {
                    if (l.SubItems[0].Text == parent.Id)
                    {
                        l.SubItems[2].Text = parent.Estado;
                        CambiarEstadoFila(l, 2, parent.Estado);
                        break;
                    }
                }
            }
        }

        private void CambiarEstadoFila(ListViewItem fila, int indice, string nuevoEstado)
        {
            // OBLIGATORIO: Desactivar el estilo heredado para ESTA fila específica
            fila.UseItemStyleForSubItems = false;

            // 1. Asignar el texto del estado en la columna 4 (índice 3)
            fila.SubItems[indice].Text = nuevoEstado;

            // 2. Evaluar el estado para aplicar el color de fuente correspondiente
            switch (nuevoEstado)
            {
                case "SELECCIONADA":
                    fila.SubItems[indice].ForeColor = Color.Blue; // Azul para Seleccionada, sin trabajo todavia
                    break;

                case "EN_PROCESO":
                case "EN_PICKING":
                    fila.SubItems[indice].ForeColor = Color.Red;  // Rojo para En Proceso
                    break;

                case "CUMPLIDO":
                case "PICKEADA":
                    fila.SubItems[indice].ForeColor = Color.Green; // Verde para Cumplido
                    break;

                default:
                    fila.SubItems[indice].ForeColor = Color.Black;
                    break;
            }
        }

    }
}
