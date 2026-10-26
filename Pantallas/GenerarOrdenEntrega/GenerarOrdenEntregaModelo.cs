namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    internal class GenerarOrdenEntregaModelo
    {
        private const string Preparada = "Preparada";
        private const string EnEntrega = "En entrega";
        private const string Emitida = "Emitida";
        private const string PendienteEntrega = "Pendiente de entrega";

        // Depósito del operario.
        private const string Deposito = "GBA";

        private List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion { NroOP = 101, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaRetiro = new DateTime(2026, 10, 20), Bultos = 10, Estado = Preparada },
            new OrdenPreparacion { NroOP = 102, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaRetiro = new DateTime(2026, 10, 20), Bultos = 8, Estado = Preparada },
            new OrdenPreparacion { NroOP = 105, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaRetiro = new DateTime(2026, 10, 21), Bultos = 10, Estado = Preparada },
            new OrdenPreparacion { NroOP = 103, Deposito = "GBA", Cliente = "MundoFOX S.R.L.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaRetiro = new DateTime(2026, 10, 20), Bultos = 1, Estado = Preparada },
            new OrdenPreparacion { NroOP = 109, Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaRetiro = new DateTime(2026, 10, 17), Bultos = 5, Estado = EnEntrega, NroOE = 700 }
        };

        private List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega
            {
                NroOE = 700, Estado = PendienteEntrega, Deposito = "GBA", FechaEmision = new DateTime(2026, 10, 14),
                Cliente = "Mercadito S.A.", Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, FechaRetiro = new DateTime(2026, 10, 17),
                Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 109, Bultos = 5 } }
            }
        };

        private int _ultimoNroOE = 700;

        // Filas de "Órdenes preparadas sin orden de entrega": un grupo por cliente, transportista y fecha de retiro.
        // Agrupa las OP Preparadas sin OE por esa clave (GroupBy); de cada grupo toma los datos de la primera OP y
        // cuenta cuántas tiene (Select, First y Count), y los ordena por cliente y fecha de retiro (OrderBy y ThenBy).
        public List<GrupoOrdenes> Grupos
        {
            get
            {
                return OrdenesSinOE()
                    .GroupBy(op => new { op.Cliente, op.Transportista.DNI, op.FechaRetiro })
                    .Select(g => new GrupoOrdenes
                    {
                        Cliente = g.First().Cliente,
                        Transportista = g.First().Transportista,
                        FechaRetiro = g.First().FechaRetiro,
                        CantidadOP = g.Count()
                    })
                    .OrderBy(g => g.Cliente)
                    .ThenBy(g => g.FechaRetiro)
                    .ToList();
            }
        }

        // Genera la OE: la registra Emitida con las OP del grupo (cliente, transportista y fecha de retiro) y las pasa a En entrega.
        // Devuelve true si el grupo todavía tiene OP Preparadas sin OE.
        public bool GenerarOrdenEntrega(string cliente, int dniTransportista, DateTime fechaRetiro, out int nroOE)
        {
            nroOE = 0;
            // OP del grupo (Where), ordenadas por N° (OrderBy).
            var ordenes = OrdenesSinOE()
                .Where(op => op.Cliente == cliente && op.Transportista.DNI == dniTransportista && op.FechaRetiro == fechaRetiro)
                .OrderBy(op => op.NroOP)
                .ToList();
            if (ordenes.Count == 0) return false;

            _ultimoNroOE++;
            nroOE = _ultimoNroOE;

            // Cliente, transportista y fecha de retiro son iguales en todo el grupo: se toman de la primera OP (First).
            var primera = ordenes.First();
            _ordenesEntrega.Add(new OrdenEntrega
            {
                NroOE = nroOE,
                Estado = Emitida,
                Deposito = Deposito,
                FechaEmision = DateTime.Now,
                Cliente = primera.Cliente,
                Transportista = primera.Transportista,
                FechaRetiro = primera.FechaRetiro,
                // Una línea por OP con su N° y sus bultos (Select).
                Lineas = ordenes.Select(op => new LineaOrdenEntrega { NroOP = op.NroOP, Bultos = op.Bultos }).ToList()
            });

            foreach (var op in ordenes)
            {
                op.Estado = EnEntrega;
                op.NroOE = nroOE;
            }

            return true;
        }

        // OP Preparadas del depósito que todavía no tienen OE (Where).
        private List<OrdenPreparacion> OrdenesSinOE()
        {
            return _ordenesPreparacion
                .Where(op => op.Deposito == Deposito && op.Estado == Preparada && op.NroOE == null)
                .ToList();
        }
    }
}
