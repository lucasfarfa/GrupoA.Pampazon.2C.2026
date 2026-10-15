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

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (caso E.1 sin OP Preparadas sin OE).
        private static readonly List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion { NroOP = "101", Deposito = "GBA", Cliente = "Mercadito S.A.", DniTransportista = "24568779", NombreTransportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 20), Bultos = 10, Estado = Preparada },
            new OrdenPreparacion { NroOP = "102", Deposito = "GBA", Cliente = "Mercadito S.A.", DniTransportista = "24568779", NombreTransportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 20), Bultos = 8, Estado = Preparada },
            new OrdenPreparacion { NroOP = "105", Deposito = "GBA", Cliente = "Mercadito S.A.", DniTransportista = "24568779", NombreTransportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 21), Bultos = 10, Estado = Preparada },
            new OrdenPreparacion { NroOP = "103", Deposito = "GBA", Cliente = "MundoFOX S.R.L.", DniTransportista = "24568779", NombreTransportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 20), Bultos = 1, Estado = Preparada },
            new OrdenPreparacion { NroOP = "109", Deposito = "GBA", Cliente = "Mercadito S.A.", DniTransportista = "24568779", NombreTransportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 17), Bultos = 5, Estado = EnEntrega, NroOE = "700" }
        };

        private static readonly List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega
            {
                NroOE = "700", Estado = PendienteEntrega, Deposito = "GBA", FechaEmision = new DateTime(2026, 10, 14),
                Cliente = "Mercadito S.A.", DniTransportista = "24568779", NombreTransportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 17),
                Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = "109", Bultos = 5 } }
            }
        };

        private static int _ultimoNroOE = 700;

        // Agrupa las OP Preparadas del depósito sin OE por cliente, DNI del transportista y fecha de retiro (CU-05, pasos 2 a 4).
        public List<GrupoOrdenes> ObtenerGrupos()
        {
            return OrdenesSinOE()
                .GroupBy(op => Clave(op))
                .Select(g => new GrupoOrdenes
                {
                    Clave = g.Key,
                    Cliente = g.First().Cliente,
                    NombreTransportista = g.First().NombreTransportista,
                    FechaRetiro = g.First().FechaRetiro,
                    CantidadOP = g.Count()
                })
                .OrderBy(g => g.Cliente)
                .ThenBy(g => g.FechaRetiro)
                .ToList();
        }

        // Registra la OE Emitida con las OP del grupo y las pasa a En entrega (CU-05, pasos 10 y 11).
        // Devuelve true si el grupo todavía tiene OP Preparadas sin OE.
        public bool GenerarOrdenEntrega(string clave, out string nroOE)
        {
            nroOE = "";
            var ordenes = OrdenesSinOE().Where(op => Clave(op) == clave).OrderBy(op => op.NroOP).ToList();
            if (ordenes.Count == 0) return false;

            _ultimoNroOE++;
            nroOE = _ultimoNroOE.ToString();

            var primera = ordenes.First();
            _ordenesEntrega.Add(new OrdenEntrega
            {
                NroOE = nroOE,
                Estado = Emitida,
                Deposito = Deposito,
                FechaEmision = DateTime.Now,
                Cliente = primera.Cliente,
                DniTransportista = primera.DniTransportista,
                NombreTransportista = primera.NombreTransportista,
                FechaRetiro = primera.FechaRetiro,
                Lineas = ordenes.Select(op => new LineaOrdenEntrega { NroOP = op.NroOP, Bultos = op.Bultos }).ToList()
            });

            foreach (var op in ordenes)
            {
                op.Estado = EnEntrega;
                op.NroOE = nroOE;
            }

            return true;
        }

        private List<OrdenPreparacion> OrdenesSinOE()
        {
            return _ordenesPreparacion
                .Where(op => op.Deposito == Deposito && op.Estado == Preparada && op.NroOE == null)
                .ToList();
        }

        private static string Clave(OrdenPreparacion op)
        {
            return op.Cliente + "|" + op.DniTransportista + "|" + op.FechaRetiro.ToString("yyyyMMdd");
        }
    }
}
