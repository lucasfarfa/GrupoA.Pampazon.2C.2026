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
            int anchoDisponible = listView1.ClientSize.Width - 25;
            listView1.Columns[0].Width = (int)(anchoDisponible * 0.20);
            listView1.Columns[1].Width = (int)(anchoDisponible * 0.30);
            listView1.Columns[2].Width = (int)(anchoDisponible * 0.30);
            listView1.Columns[3].Width = (int)(anchoDisponible * 0.20);


            int anchoDisponible2 = listView2.ClientSize.Width - 25;
            listView2.Columns[0].Width = (int)(anchoDisponible2 * 0.20);
            listView2.Columns[1].Width = (int)(anchoDisponible2 * 0.20);
            listView2.Columns[2].Width = (int)(anchoDisponible2 * 0.20);
            listView2.Columns[3].Width = (int)(anchoDisponible2 * 0.20);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = listView1.SelectedItems[0];
                string idPais = itemSeleccionado.SubItems[0].Text;
                string estado = itemSeleccionado.SubItems[3].Text;

                listView2.Items.Clear();

                if (estado == "PENDIENTE")
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

                switch (idPais)
                {
                    case "OS-0000001":
                    case "OS-0000003":
                    case "OS-0000005":
                    case "OS-0000007":
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000001", "Teclado", "10.00", "X0-Y1-Z2" }));
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000002", "Mouse", "10.00", "X3-Y4-Z5" }));
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000003", "Usb", "10.00", "X6-Y7-Z8" }));
                        break;

                    case "OS-0000002":
                    case "OS-0000004":
                    case "OS-0000006":
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000004", "Monitor", "10.00", "X9-Y12-Z22" }));
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000005", "Motherboard", "10.00", "X20-Y21-Z22" }));
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000006", "CPU AMD", "10.00", "X30-Y51-Z42" }));
                        break;

                    case "OS-0000008":
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000007", "CPU INTEL", "10.00", "X40-Y41-Z42" }));
                        listView2.Items.Add(new ListViewItem(new string[] { "SKU-0000008", "Fuente X Watts", "10.00", "X40-Y41-Z82" }));
                        break;
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdFinalizarFulFillment_Click(object sender, EventArgs e)
        {
            ValidarBotonCierreSeleccion();
        }

        private void ValidarBotonCierreSeleccion()
        {
            if (listView1.SelectedItems.Count > 0)
            {

                CambiarEstadoFila(listView1.SelectedItems[0], "CUMPLIDO");

                // Cambiar Estado a CUMPLIDO
                listView1.SelectedItems[0].SubItems[3].Text = "CUMPLIDO";

                // Apagar el botón de finalizar
                btnFinalizarFulFillment.Enabled = false;

                // Validar si TODO listView1 quedó listo para habilitar el botón grande de abajo
                btnCierreSeleccion.Enabled = ValidarTodosCumplidos();
            }
        }

        private bool ValidarTodosCumplidos()
        {
            // 1. Si la grilla está vacía, decidimos si habilitar o no (ejemplo: false)
            if (listView1.Items.Count == 0) return false;

            // 2. Recorrer cada fila de la grilla
            foreach (ListViewItem fila in listView1.Items)
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

        private void CambiarEstadoFila(ListViewItem fila, string nuevoEstado)
        {
            // OBLIGATORIO: Desactivar el estilo heredado para ESTA fila específica
            fila.UseItemStyleForSubItems = false;

            // 1. Asignar el texto del estado en la columna 4 (índice 3)
            fila.SubItems[3].Text = nuevoEstado;

            // 2. Evaluar el estado para aplicar el color de fuente correspondiente
            switch (nuevoEstado)
            {
                case "PENDIENTE":
                    fila.SubItems[3].ForeColor = Color.Blue; // Azul para Pendiente
                    break;

                case "EN_PROCESO":
                    fila.SubItems[3].ForeColor = Color.Red;  // Rojo para En Proceso
                    break;

                case "CUMPLIDO":
                    fila.SubItems[3].ForeColor = Color.Green; // Verde para Cumplido
                    break;

                default:
                    fila.SubItems[3].ForeColor = Color.Black;
                    break;
            }
        }


        private void btnIniciarFulFillment_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Cambiar Estado en la columna 4 (índice 3)
                listView1.SelectedItems[0].SubItems[3].Text = "EN_PROCESO";
                CambiarEstadoFila(listView1.SelectedItems[0], "EN_PROCESO");

                // Cambiar estados de botones
                btnIniciarFulFillment.Enabled = false;
                btnFinalizarFulFillment.Enabled = true;

            }
        }
    }
}
