using System.Collections.Generic;
using System.Linq;

namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    public class TransportistaRecepcion
    {
        public string DNI { get; set; }
        public string NombreApellido { get; set; }
    }

    public class OrdenEntregaRecepcion
    {
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public TransportistaRecepcion Transportista { get; set; }
        public string FechaEmision { get; set; }
        public string NroOp { get; set; }
        public int Bultos { get; set; }
        public string Estado { get; set; } // "Emitida", "Pendiente de entrega"
    }

    internal class RecepcionarOrdenEntregaModelo
    {
        private static readonly List<OrdenEntregaRecepcion> _ordenes = new List<OrdenEntregaRecepcion>
        {
            new OrdenEntregaRecepcion
            {
                Numero = "700",
                Cliente = "Mercadito S.A.",
                Transportista = new TransportistaRecepcion { DNI = "24568779", NombreApellido = "Jose Gomez" },
                FechaEmision = "14/10/2026",
                NroOp = "109",
                Bultos = 5,
                Estado = "Pendiente de entrega"
            },
            new OrdenEntregaRecepcion
            {
                Numero = "701",
                Cliente = "Mercadito S.A.",
                Transportista = new TransportistaRecepcion { DNI = "24568779", NombreApellido = "Jose Gomez" },
                FechaEmision = "14/10/2026",
                NroOp = "101, 102",
                Bultos = 18,
                Estado = "Emitida"
            },
            new OrdenEntregaRecepcion
            {
                Numero = "702",
                Cliente = "MundoFOX S.R.L.",
                Transportista = new TransportistaRecepcion { DNI = "24568779", NombreApellido = "Jose Gomez" },
                FechaEmision = "14/10/2026",
                NroOp = "103",
                Bultos = 1,
                Estado = "Emitida"
            }
        };

        public List<OrdenEntregaRecepcion> ObtenerOrdenesEmitidas()
        {
            return _ordenes.Where(o => o.Estado == "Emitida").ToList();
        }

        public bool ConfirmarRecepcion(string numeroOE)
        {
            var oe = _ordenes.FirstOrDefault(o => o.Numero == numeroOE && o.Estado == "Emitida");
            if (oe == null) return false;

            oe.Estado = "Pendiente de entrega";
            return true;
        }
    }
}