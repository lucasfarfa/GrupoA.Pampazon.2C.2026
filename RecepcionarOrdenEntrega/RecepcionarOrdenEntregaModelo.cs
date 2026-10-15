namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    internal class RecepcionarOrdenEntregaModelo
    {
        private const string Emitida = "Emitida";
        private const string PendienteEntrega = "Pendiente de entrega";
        private const string Preparacion = "Preparación";
        private const string Despacho = "Depósito transitorio de Despacho";

        // Depósito del operario.
        private const string Deposito = "GBA";

        private static readonly Transportista _joseGomez = new Transportista { DNI = "24568779", NombreApellido = "Jose Gomez" };

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (caso F.2 sin OE Emitidas).
        private static readonly List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega { NroOE = "700", Estado = PendienteEntrega, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaEmision = new DateTime(2026, 10, 14), OrdenesPreparacion = "109", Bultos = 5, Ubicacion = Despacho, FechaRecepcion = new DateTime(2026, 10, 14) },
            new OrdenEntrega { NroOE = "701", Estado = Emitida, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaEmision = new DateTime(2026, 10, 14), OrdenesPreparacion = "101, 102", Bultos = 18, Ubicacion = Preparacion },
            new OrdenEntrega { NroOE = "702", Estado = Emitida, Deposito = "GBA", Cliente = "MundoFOX S.R.L.", Transportista = _joseGomez, FechaEmision = new DateTime(2026, 10, 14), OrdenesPreparacion = "103", Bultos = 1, Ubicacion = Preparacion }
        };

        // OE Emitidas del depósito (CU-06, paso 2).
        public List<OrdenEntrega> ObtenerOrdenesEmitidas()
        {
            return _ordenesEntrega
                .Where(oe => oe.Deposito == Deposito && oe.Estado == Emitida)
                .OrderBy(oe => oe.NroOE)
                .ToList();
        }

        // Registra la OE Pendiente de entrega y su mercadería en el depósito transitorio de Despacho (CU-06, pasos 9 y 10).
        // Devuelve true si la OE existe y estaba Emitida.
        public bool ConfirmarRecepcion(string nroOE)
        {
            var oe = _ordenesEntrega.FirstOrDefault(o => o.NroOE == nroOE && o.Deposito == Deposito && o.Estado == Emitida);
            if (oe == null) return false;

            oe.Estado = PendienteEntrega;
            oe.Ubicacion = Despacho;
            oe.FechaRecepcion = DateTime.Now;
            return true;
        }
    }
}
