using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    public partial class RecepcionarOrdenEntregaForm : Form
    {
        // Única instancia permitida en la vista: el modelo
        private readonly RecepcionarOrdenEntregaModelo _modelo = new RecepcionarOrdenEntregaModelo();
        private bool _cargando;

        public RecepcionarOrdenEntregaForm()
        {
            InitializeComponent();
        }

        private void RecepcionarOrdenEntregaForm_Load(object sender, EventArgs e)
        {
            RefrescarListas();
        }

        private void RefrescarListas()
        {
            if (lvOEEmitidas == null) return;

            _cargando = true;
            lvOEEmitidas.Items.Clear();

            var ordenes = _modelo.ObtenerOrdenesEmitidas();
            foreach (var oe in ordenes)
            {
                var item = new ListViewItem(oe.Numero) { Tag = oe.Numero };
                item.SubItems.Add(oe.Transportista.NombreApellido);
                item.SubItems.Add(oe.Cliente);
                item.SubItems.Add(oe.FechaEmision);
                item.SubItems.Add(oe.NroOp);

                lvOEEmitidas.Items.Add(item);
            }

            _cargando = false;

            if (ordenes.Count == 0)
            {
                MessageBox.Show("No hay órdenes de entrega para recepcionar", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarListas();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (lvOEEmitidas == null || lvOEEmitidas.SelectedItems.Count == 0)
            {
                Advertir("Debe seleccionar una orden de entrega.", lvOEEmitidas);
                return;
            }

            var selectedItem = lvOEEmitidas.SelectedItems[0];
            if (selectedItem.Tag is not string numeroOE) return;

            var confirmacion = MessageBox.Show($"¿Confirma la recepción de la OE N° {numeroOE} en Despacho?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            if (!_modelo.ConfirmarRecepcion(numeroOE))
            {
                MessageBox.Show("No se pudo confirmar la recepción de la orden de entrega.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Orden de entrega N° {numeroOE} recepcionada", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarListas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Advertir(string mensaje, Control foco)
        {
            MessageBox.Show(mensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            foco?.Focus();
        }
    }
}