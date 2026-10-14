using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.CU04EmpaquetarProductos
{
    public partial class EmpaquetarProductosForm : Form
    {
        private class OrdenPreparacionItem
        {
            public string NumeroOrden { get; set; }
            public string Modalidad { get; set; }
            public List<ProductoItem> Productos { get; set; } = new List<ProductoItem>();
        }

        private class ProductoItem
        {
            public string Sku { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }
        }

        private Queue<OrdenPreparacionItem> _colaFifo;
        private OrdenPreparacionItem _ordenActual;

        public EmpaquetarProductosForm()
        {
            InitializeComponent();
            CargarDatosPrueba();
        }

        private void EmpaquetarProductosForm_Load(object sender, EventArgs e)
        {
            DepositoLbl.Text = "GBA";
            PuestoLbl.Text = "Puesto 01";
            MostrarSiguienteOrdenFIFO();
        }

        private void CargarDatosPrueba()
        {
            _colaFifo = new Queue<OrdenPreparacionItem>();

            _colaFifo.Enqueue(new OrdenPreparacionItem
            {
                NumeroOrden = "OP-000141",
                Modalidad = "Fulfillment",
                Productos = new List<ProductoItem>
                {
                    new ProductoItem { Sku = "CEM-50", Descripcion = "Bolsa de cemento x 50 kg", Cantidad = 4 },
                    new ProductoItem { Sku = "CAL-25", Descripcion = "Bolsa de cal hidratada x 25 kg", Cantidad = 5 }
                }
            });

            _colaFifo.Enqueue(new OrdenPreparacionItem
            {
                NumeroOrden = "OP-000142",
                Modalidad = "Pallets",
                Productos = new List<ProductoItem>
                {
                    new ProductoItem { Sku = "TV-55-4K", Descripcion = "Smart TV 55\" 4K", Cantidad = 2 }
                }
            });
        }

        private void MostrarSiguienteOrdenFIFO()
        {
            lstProductos.Items.Clear();

            if (_colaFifo.Count > 0)
            {
                // Toma automáticamente la siguiente orden en la fila (FIFO) sin dejar que el usuario elija[cite: 3]
                _ordenActual = _colaFifo.Dequeue();

                txtNumeroOrden.Text = _ordenActual.NumeroOrden;
                textModalidad.Text = _ordenActual.Modalidad;

                foreach (var prod in _ordenActual.Productos)
                {
                    var item = new ListViewItem(prod.Sku);
                    item.SubItems.Add(prod.Descripcion);
                    item.SubItems.Add(prod.Cantidad.ToString());
                    lstProductos.Items.Add(item);
                }

                lblTotalBultos.Text = _ordenActual.Productos.Count.ToString();
                btnEmpaquetar.Enabled = true;
            }
            else
            {
                _ordenActual = null;
                txtNumeroOrden.Text = "[No hay más órdenes pendientes]";
                textModalidad.Text = string.Empty;
                lblTotalBultos.Text = "0";
                btnEmpaquetar.Enabled = false;

                MessageBox.Show("No quedan más órdenes de preparación pendientes de empaquetado.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEmpaquetar_Click(object sender, EventArgs e)
        {
            if (_ordenActual == null) return;

            var resultado = MessageBox.Show(
                $"¿Confirma el empaquetado de la orden {_ordenActual.NumeroOrden}?",
                "Confirmar Empaquetado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show($"La orden {_ordenActual.NumeroOrden} fue empaquetada con éxito.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Carga automáticamente la siguiente orden bajo el criterio FIFO
                MostrarSiguienteOrdenFIFO();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}