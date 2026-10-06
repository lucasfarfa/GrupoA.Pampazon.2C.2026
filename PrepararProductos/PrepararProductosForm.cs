using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    public partial class PrepararProductosForm : Form
    {
        public PrepararProductosForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarSeleccionDeOrdenesPendientes();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            SeleccionarTodasLasOrdenesPendientes();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarSeleccionDeOrdenesPendientes();
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

        private void listViewOP_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewOP.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = listViewOP.SelectedItems[0];
                string id = itemSeleccionado.SubItems[0].Text;
                string estado = itemSeleccionado.SubItems[3].Text;

                listViewProductos.Items.Clear();

                if (estado == "SELECCIONADA")
                {
                    btnIniciarFulFillment.Enabled = true;
                    btnFinalizarFulFillment.Enabled = false;
                }
                else if (estado == "EN_PROCESO")
                {
                    btnIniciarFulFillment.Enabled = false;
                    btnFinalizarFulFillment.Enabled = true;
                }
                else if (estado == "CUMPLIDO")
                {
                    btnIniciarFulFillment.Enabled = false;
                    btnFinalizarFulFillment.Enabled = false;
                }

                switch (id)
                {
                    case "OP-0000001":
                    case "OP-0000003":
                    case "OP-0000005":
                    case "OP-0000007":
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000001", "Teclado", "10.00", "X0-Y1-Z2" }));
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000002", "Mouse", "10.00", "X3-Y4-Z5" }));
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000003", "Usb", "10.00", "X6-Y7-Z8" }));
                        break;

                    case "OP-0000002":
                    case "OP-0000004":
                    case "OP-0000006":
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000004", "Monitor", "10.00", "X9-Y12-Z22" }));
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000005", "Motherboard", "10.00", "X20-Y21-Z22" }));
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000006", "CPU AMD", "10.00", "X30-Y51-Z42" }));
                        break;

                    case "OP-0000008":
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000007", "CPU INTEL", "10.00", "X40-Y41-Z42" }));
                        listViewProductos.Items.Add(new ListViewItem(new string[] { "SKU-0000008", "Fuente X Watts", "10.00", "X40-Y41-Z82" }));
                        break;
                }
            }
        }

        private void listViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdFinalizarFulFillment_Click(object sender, EventArgs e)
        {
            ValidarBotonCierreSeleccion();
        }

        private void ValidarBotonCierreSeleccion()
        {
            if (listViewOP.SelectedItems.Count > 0)
            {

                CambiarEstadoFila(listViewOP.SelectedItems[0], 3, "CUMPLIDO");

                // Cambiar Estado a CUMPLIDO
                listViewOP.SelectedItems[0].SubItems[3].Text = "CUMPLIDO";

                // Apagar el botón de finalizar
                btnFinalizarFulFillment.Enabled = false;

                // Validar si TODO listView1 quedó listo para habilitar el botón grande de abajo
                btnCierreSeleccion.Enabled = ValidarTodosCumplidos();
            }
        }

        private bool ValidarTodosCumplidos()
        {
            // 1. Si la grilla está vacía, decidimos si habilitar o no (ejemplo: false)
            if (listViewOP.Items.Count == 0) return false;

            // 2. Recorrer cada fila de la grilla
            foreach (ListViewItem fila in listViewOP.Items)
            {
                // Validar que la fila tenga suficientes subelementos para evitar errores
                if (fila.SubItems.Count > 3)
                {
                    // Extraer el texto quitando espacios en blanco y convirtiendo a mayúsculas
                    string estado = fila.SubItems[3].Text.Trim().ToUpper();

                    if (estado != "CUMPLIDO")
                    {
                        return false; // Al primer fallo, cancelamos y salimos
                    }
                }
                else
                {
                    return false; // Si falta la columna [3] en alguna fila, no está cumplido todo
                }
            }

            return true; // Si completó el bucle sin salir, es porque TODOS son "CUMPLIDO"
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
                    fila.SubItems[indice].ForeColor = Color.Red;  // Rojo para En Proceso
                    break;

                case "CUMPLIDO":
                    fila.SubItems[indice].ForeColor = Color.Green; // Verde para Cumplido
                    break;

                default:
                    fila.SubItems[indice].ForeColor = Color.Black;
                    break;
            }
        }


        private void btnIniciarFulFillment_Click(object sender, EventArgs e)
        {
            if (listViewOP.SelectedItems.Count > 0)
            {
                // Cambiar Estado en la columna 4 (índice 3)
                listViewOP.SelectedItems[0].SubItems[3].Text = "EN_PROCESO";
                CambiarEstadoFila(listViewOP.SelectedItems[0], 3, "EN_PROCESO");

                // Cambiar estados de botones
                btnIniciarFulFillment.Enabled = false;
                btnFinalizarFulFillment.Enabled = true;

            }
        }

        private void listViewOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOS.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = listViewOS.SelectedItems[0];
                string id = itemSeleccionado.SubItems[0].Text;
                string fecha = itemSeleccionado.SubItems[1].Text;
                string estado = itemSeleccionado.SubItems[2].Text;

                listViewOP.Items.Clear();
                listViewProductos.Items.Clear();

                btnIniciarFulFillment.Enabled = false;
                btnFinalizarFulFillment.Enabled = false;
                btnCierreSeleccion.Enabled = false;
                
                if (estado == "CUMPLIDO") { 
                    MessageBox.Show("La Orden de Selección ya esta cumplida.\nPor favor, selecciona un elemento de la lista que no este CUMPLIDO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (id)
                {
                    case "OS-0000092":
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000002", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000003", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000004", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000005", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000006", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        break;

                    case "OS-0000093":
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000007", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000008", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        listViewOP.Items.Add(new ListViewItem(new string[] { "OP-0000001", "Luis Pérez", "2026-01-01 10:00:00", "SELECCIONADA" }));
                        break;
                }
            }
        }

        private void btnCierreSeleccion_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya al menos un elemento seleccionado
            if (listViewOS.SelectedItems.Count > 0)
            {
                // 2. Modificar el SubItem[2] del primer elemento seleccionado
                listViewOS.SelectedItems[0].SubItems[2].Text = "CUMPLIDO";
                CambiarEstadoFila(listViewOS.SelectedItems[0], 2, "CUMPLIDO");
                listViewOP.Items.Clear();
                listViewProductos.Items.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un elemento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
