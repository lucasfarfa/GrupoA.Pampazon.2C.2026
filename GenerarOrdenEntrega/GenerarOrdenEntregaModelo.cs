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

        private static readonly Transportista _joseGomez = new Transportista { DNI = "24568779", NombreApellido = "Jose Gomez" };

        private static readonly List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion { NroOP = "101", Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaRetiro = new DateTime(2026, 10, 20), Bultos = 10, Estado = Preparada },
            new OrdenPreparacion { NroOP = "102", Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaRetiro = new DateTime(2026, 10, 20), Bultos = 8, Estado = Preparada },
            new OrdenPreparacion { NroOP = "105", Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaRetiro = new DateTime(2026, 10, 21), Bultos = 10, Estado = Preparada },
            new OrdenPreparacion { NroOP = "103", Deposito = "GBA", Cliente = "MundoFOX S.R.L.", Transportista = _joseGomez, FechaRetiro = new DateTime(2026, 10, 20), Bultos = 1, Estado = Preparada },
            new OrdenPreparacion { NroOP = "109", Deposito = "GBA", Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaRetiro = new DateTime(2026, 10, 17), Bultos = 5, Estado = EnEntrega, NroOE = "700" }
        };

        private static readonly List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega
            {
                NroOE = "700", Estado = PendienteEntrega, Deposito = "GBA", FechaEmision = new DateTime(2026, 10, 14),
                Cliente = "Mercadito S.A.", Transportista = _joseGomez, FechaRetiro = new DateTime(2026, 10, 17),
                Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = "109", Bultos = 5 } }
            }
        };

        private static int _ultimoNroOE = 700;

        // Filas de "Órdenes preparadas sin orden de entrega": un grupo por cliente, transportista y fecha de retiro.
        // Agrupa las OP Preparadas sin OE por esa clave (GroupBy); de cada grupo toma los datos de la primera OP y
        // cuenta cuántas tiene (Select, First y Count), y los ordena por cliente y fecha de retiro (OrderBy y ThenBy).
        public List<GrupoOrdenes> Grupos
        {
            get
            {
                return OrdenesSinOE()
                    .GroupBy(op => Clave(op))
                    .Select(g => new GrupoOrdenes
                    {
                        Clave = g.Key,
                        Cliente = g.First().Cliente,
                        NombreTransportista = g.First().Transportista.NombreApellido,
                        FechaRetiro = g.First().FechaRetiro,
                        CantidadOP = g.Count()
                    })
                    .OrderBy(g => g.Cliente)
                    .ThenBy(g => g.FechaRetiro)
                    .ToList();
            }
        }

        // Datos del grupo marcado para el mensaje de confirmación. Devuelve true si todavía tiene OP Preparadas sin OE.
        // Busca en Grupos el que tiene esa clave, o null si ya no está (FirstOrDefault).
        public bool ObtenerGrupo(string clave, out GrupoOrdenes? grupo)
        {
            grupo = Grupos.FirstOrDefault(g => g.Clave == clave);
            return grupo != null;
        }

        // Genera la OE: la registra Emitida con las OP del grupo y las pasa a En entrega.
        // Devuelve true si el grupo todavía tiene OP Preparadas sin OE.
        public bool GenerarOrdenEntrega(string clave, out string nroOE)
        {
            nroOE = "";
            // OP del grupo (Where), ordenadas por N° (OrderBy).
            var ordenes = OrdenesSinOE().Where(op => Clave(op) == clave).OrderBy(op => op.NroOP).ToList();
            if (ordenes.Count == 0) return false;

            _ultimoNroOE++;
            nroOE = _ultimoNroOE.ToString();

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

        private static string Clave(OrdenPreparacion op)
        {
            return op.Cliente + "|" + op.Transportista.DNI + "|" + op.FechaRetiro.ToString("yyyyMMdd");
        }
    }
}
