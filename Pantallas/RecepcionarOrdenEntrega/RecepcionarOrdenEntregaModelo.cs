namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    internal class RecepcionarOrdenEntregaModelo
    {
        private const string Preparacion = "Preparación";
        private const string Despacho = "Depósito transitorio de Despacho";

        // Depósito del operario.
        private const string Deposito = "GBA";

        private List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega { NroOE = 700, Estado = EstadoOrdenEntrega.PendienteEntrega, Deposito = "GBA", Cliente = new Cliente { Cuit = 30712345678, Nombre = "Mercadito S.A." }, Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaEmision = new DateTime(2026, 10, 14), Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 109, Bultos = 5 } }, Ubicacion = Despacho, FechaRecepcionDespacho = new DateTime(2026, 10, 14) },
            new OrdenEntrega { NroOE = 701, Estado = EstadoOrdenEntrega.Emitida, Deposito = "GBA", Cliente = new Cliente { Cuit = 30712345678, Nombre = "Mercadito S.A." }, Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaEmision = new DateTime(2026, 10, 14), Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 101, Bultos = 10 }, new LineaOrdenEntrega { NroOP = 102, Bultos = 8 } }, Ubicacion = Preparacion },
            new OrdenEntrega { NroOE = 702, Estado = EstadoOrdenEntrega.Emitida, Deposito = "GBA", Cliente = new Cliente { Cuit = 30709876543, Nombre = "MundoFOX S.R.L." }, Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaEmision = new DateTime(2026, 10, 14), Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 103, Bultos = 1 } }, Ubicacion = Preparacion }
        };

        // Filas de "Órdenes de entrega emitidas": las OE Emitidas del depósito.
        // Filtra por depósito y estado Emitida (Where) y las ordena por N° de OE (OrderBy).
        public List<OrdenEntrega> OrdenesEmitidas
        {
            get
            {
                return _ordenesEntrega
                    .Where(oe => oe.Deposito == Deposito && oe.Estado == EstadoOrdenEntrega.Emitida)
                    .OrderBy(oe => oe.NroOE)
                    .ToList();
            }
        }

        // Confirma que Despacho recibió la OE: pasa a Pendiente de entrega y su mercadería al depósito transitorio de Despacho.
        // Devuelve true si la OE existe y estaba Emitida.
        public bool ConfirmarRecepcion(int nroOE)
        {
            // Busca la OE Emitida del depósito con ese N°, o null si no está (FirstOrDefault).
            var oe = _ordenesEntrega.FirstOrDefault(o => o.NroOE == nroOE && o.Deposito == Deposito && o.Estado == EstadoOrdenEntrega.Emitida);
            if (oe == null) return false;

            oe.Estado = EstadoOrdenEntrega.PendienteEntrega;
            oe.Ubicacion = Despacho;
            oe.FechaRecepcionDespacho = DateTime.Now;
            return true;
        }
    }
}
