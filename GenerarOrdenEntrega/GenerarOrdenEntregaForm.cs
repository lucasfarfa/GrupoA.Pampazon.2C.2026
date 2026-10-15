using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    public partial class GenerarOrdenEntregaForm : Form
    {
        private class GrupoOP
        {
            public string Cliente { get; set; }
            public string Transportista { get; set; }
            public DateTime FechaRetiro { get; set; }
            public int CantidadOP { get; set; }
        }


        // REVISAR NOMBRES
        private static readonly List<GrupoOP> _pendientes = new List<GrupoOP>
        {
            new GrupoOP { Cliente = "Juan Perez", Transportista = "La Sosa S.A.",  FechaRetiro = DateTime.Today,            CantidadOP = 500 },
            new GrupoOP { Cliente = "Lola Mem",   Transportista = "La Sosa S.A.",  FechaRetiro = DateTime.Today.AddDays(1), CantidadOP = 200 },
            new GrupoOP { Cliente = "Loca Mem",   Transportista = "La Chara S.A.", FechaRetiro = DateTime.Today,            CantidadOP = 600 }
        };

        private static int _ultimoNumero = 0;

        public GenerarOrdenEntregaForm()
        {
            InitializeComponent();
        }

        private void GenerarOrdenEntregaForm_Load(object sender, EventArgs e)
        {
            CargarListas();
        }

        private void CargarListas()
        {
            lvPendientes.Items.Clear();
            foreach (var grupo in _pendientes)
            {
                var item = new ListViewItem(grupo.Cliente) { Tag = grupo };
                item.SubItems.Add(grupo.Transportista);
                item.SubItems.Add(grupo.FechaRetiro.ToString("dd/MM/yyyy"));
                item.SubItems.Add(grupo.CantidadOP.ToString());
                lvPendientes.Items.Add(item);
            }

           
            ActualizarBotonGenerar();
        }

        private void lvPendientes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ActualizarBotonGenerar();
        }

        private void ActualizarBotonGenerar()
        {
            btnGenerarOrden.Enabled = lvPendientes.CheckedItems.Count > 0;
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            var elegidas = lvPendientes.CheckedItems
                .Cast<ListViewItem>()
                .Select(i => (GrupoOP)i.Tag)
                .ToList();

            if (elegidas.Count == 0)
            {
                MessageBox.Show("Marque al menos una fila para generar la orden de entrega.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mensajesNuevos = new List<string>();
            foreach (var grupo in elegidas)
            {
                _ultimoNumero++;
                string numeroOE = $"OE-{_ultimoNumero:000000}";
                mensajesNuevos.Add($"{numeroOE} => {grupo.Cliente} | {grupo.Transportista} | {grupo.FechaRetiro:dd/MM/yyyy}");

                _pendientes.Remove(grupo); // Se quita de pendientes
            }

            CargarListas();

            var mensaje = new StringBuilder();
            mensaje.AppendLine(mensajesNuevos.Count == 1
                ? "Se generó 1 orden de entrega:"
                : $"Se generaron {mensajesNuevos.Count} órdenes de entrega:");
            mensaje.AppendLine();

            foreach (var item in mensajesNuevos)
            {
                mensaje.AppendLine(item);
            }

            MessageBox.Show(mensaje.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}