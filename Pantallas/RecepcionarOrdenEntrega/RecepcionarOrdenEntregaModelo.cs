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

        private List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega { NroOE = 700, Estado = PendienteEntrega, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaEmision = new DateTime(2026, 10, 14), NrosOP = new List<int> { 109 }, Bultos = 5, Ubicacion = Despacho, FechaRecepcion = new DateTime(2026, 10, 14) },
            new OrdenEntrega { NroOE = 701, Estado = Emitida, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaEmision = new DateTime(2026, 10, 14), NrosOP = new List<int> { 101, 102 }, Bultos = 18, Ubicacion = Preparacion },
            new OrdenEntrega { NroOE = 702, Estado = Emitida, Deposito = "GBA", Cliente = "MundoFOX S.R.L.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaEmision = new DateTime(2026, 10, 14), NrosOP = new List<int> { 103 }, Bultos = 1, Ubicacion = Preparacion }
        };

        // Filas de "Órdenes de entrega emitidas": las OE Emitidas del depósito.
        // Filtra por depósito y estado Emitida (Where) y las ordena por N° de OE (OrderBy).
        public List<OrdenEntrega> OrdenesEmitidas
        {
            get
            {
                return _ordenesEntrega
                    .Where(oe => oe.Deposito == Deposito && oe.Estado == Emitida)
                    .OrderBy(oe => oe.NroOE)
                    .ToList();
            }
        }

        // Confirma que Despacho recibió la OE: pasa a Pendiente de entrega y su mercadería al depósito transitorio de Despacho.
        // Devuelve true si la OE existe y estaba Emitida.
        public bool ConfirmarRecepcion(int nroOE)
        {
            // Busca la OE Emitida del depósito con ese N°, o null si no está (FirstOrDefault).
            var oe = _ordenesEntrega.FirstOrDefault(o => o.NroOE == nroOE && o.Deposito == Deposito && o.Estado == Emitida);
            if (oe == null) return false;

            oe.Estado = PendienteEntrega;
            oe.Ubicacion = Despacho;
            oe.FechaRecepcion = DateTime.Now;
            return true;
        }
    }
}
