namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class GenerarOrdenSeleccionModelo
    {
        private const string Pendiente = "Pendiente";
        private const string EnPreparacion = "En preparación";

        private List<string> _modalidades = new List<string> { "Fulfillment", "Palet cerrado" };

        // Fechas relativas al día de hoy para que los datos sirvan cualquier día.
        private List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion { NroOP = "101", Cliente = "Mercadito S.A.", FechaRecepcion = DateTime.Today.AddHours(9), Modalidad = "Fulfillment", Estado = Pendiente,
                Productos = new List<LineaProducto> { new LineaProducto { Sku = "CEM-50KG", Cantidad = 10 } } },
            new OrdenPreparacion { NroOP = "102", Cliente = "Mercadito S.A.", FechaRecepcion = DateTime.Today.AddHours(10.5), Modalidad = "Fulfillment", Estado = Pendiente,
                Productos = new List<LineaProducto> { new LineaProducto { Sku = "CEM-50KG", Cantidad = 5 }, new LineaProducto { Sku = "CAL-25KG", Cantidad = 3 } } },
            new OrdenPreparacion { NroOP = "103", Cliente = "MundoFOX S.R.L.", FechaRecepcion = DateTime.Today.AddDays(-1).AddHours(16), Modalidad = "Palet cerrado", Estado = Pendiente,
                Productos = new List<LineaProducto> { new LineaProducto { Sku = "ZAP-0042", Cantidad = 24 } } }
        };

        // Registro de stock del depósito. CEM-50KG está en dos posiciones
        private List<PosicionStock> _stock = new List<PosicionStock>
        {
            new PosicionStock { Sku = "CEM-50KG", Posicion = "12-43-2", Cantidad = 10 },
            new PosicionStock { Sku = "CEM-50KG", Posicion = "12-44-1", Cantidad = 50 },
            new PosicionStock { Sku = "CAL-25KG", Posicion = "03-10-1", Cantidad = 50 },
            new PosicionStock { Sku = "ZAP-0042", Posicion = "12-05-1", Cantidad = 100 }
        };

        private List<OrdenSeleccion> _ordenesSeleccion = new List<OrdenSeleccion>();
        private int _ultimoNroOS = 300;

        // Filtros aplicados con "Buscar"; al abrir, sin filtro de fechas.
        private string _cliente = "";
        private DateTime? _desde;
        private DateTime? _hasta;
        private string _modalidad = "";

        // OP incluidas en la OS en armado.
        private List<string> _incluidas = new List<string>();

        public string Deposito { get; }

        public GenerarOrdenSeleccionModelo(string deposito)
        {
            Deposito = deposito;
        }

        public int CantidadIncluidas => _incluidas.Count;

        public List<string> Modalidades => _modalidades.ToList();

        // Para avisar al abrir si no hay ninguna OP Pendiente (Any: ¿hay alguna OP en estado Pendiente?).
        public bool HayOrdenesPendientes => _ordenesPreparacion.Any(op => op.Estado == Pendiente);

        // Guarda los filtros (ya validados por el form; null = sin límite en esa fecha) y
        // devuelve true si hay OP Pendientes que los cumplen.
        public bool Filtrar(string cliente, DateTime? desde, DateTime? hasta, string modalidad)
        {
            _cliente = cliente;
            _desde = desde?.Date;
            _hasta = hasta?.Date;
            _modalidad = modalidad;

            return OrdenesFiltradas.Count > 0;
        }

        // Filas de la grilla de OP: las Pendientes que cumplen los filtros guardados.
        // Se queda con las que cumplen estado, cliente, fechas y modalidad (Where; un filtro vacío no filtra)
        // y las ordena por fecha de recepción (OrderBy).
        public List<OrdenPreparacion> OrdenesFiltradas
        {
            get
            {
                return _ordenesPreparacion
                    .Where(op => op.Estado == Pendiente
                        && op.Cliente.Contains(_cliente, StringComparison.OrdinalIgnoreCase)
                        && (_desde == null || op.FechaRecepcion.Date >= _desde)
                        && (_hasta == null || op.FechaRecepcion.Date <= _hasta)
                        && (_modalidad == "" || op.Modalidad.Equals(_modalidad, StringComparison.OrdinalIgnoreCase)))
                    .OrderBy(op => op.FechaRecepcion)
                    .ToList();
            }
        }

        public bool EstaIncluida(string nroOP)
        {
            return _incluidas.Contains(nroOP);
        }

        // Incluye las OP elegidas en la OS que se está armando. Devuelve true si todas existen y siguen Pendientes.
        public bool IncluirOrdenes(List<string> nrosOP)
        {
            foreach (var nro in nrosOP)
            {
                // Busca la OP con ese número, o null si no existe (FirstOrDefault).
                var op = _ordenesPreparacion.FirstOrDefault(o => o.NroOP == nro);
                if (op == null || op.Estado != Pendiente)
                    return false;
            }

            // Agrega solo las que todavía no estaban incluidas (Where).
            _incluidas.AddRange(nrosOP.Where(nro => !_incluidas.Contains(nro)));
            return true;
        }

        // Desmarca las OP elegidas de la OS que se está armando; las que no estaban incluidas se ignoran.
        public bool QuitarOrdenes(List<string> nrosOP)
        {
            // Saca de las incluidas cada N° que esté en nrosOP; es lo mismo que RemoveAll(nro => nrosOP.Contains(nro)).
            _incluidas.RemoveAll(nrosOP.Contains);
            return true;
        }

        public bool QuitarTodas()
        {
            _incluidas.Clear();
            return true;
        }

        // Filas de "Resumen consolidado de productos": una línea por SKU con la cantidad total de las OP incluidas.
        // Toma las OP incluidas (Where), junta todos sus productos (SelectMany), los agrupa por SKU (GroupBy),
        // los ordena por SKU (OrderBy) y de cada grupo arma una línea con la suma de cantidades (Select y Sum).
        public List<LineaProducto> ResumenConsolidado
        {
            get
            {
                return _ordenesPreparacion
                    .Where(op => _incluidas.Contains(op.NroOP))
                    .SelectMany(op => op.Productos)
                    .GroupBy(p => p.Sku)
                    .OrderBy(g => g.Key)
                    .Select(g => new LineaProducto { Sku = g.Key, Cantidad = g.Sum(p => p.Cantidad) })
                    .ToList();
            }
        }

        // Genera la OS: la registra Pendiente con el detalle por posición y pasa sus OP a En preparación.
        public bool GenerarOrdenSeleccion(out string nroOS)
        {
            nroOS = "";
            if (_incluidas.Count == 0) return false;

            // Si un SKU está en más de una posición, una línea por posición hasta cubrir la cantidad.
            var detalle = new List<LineaOrdenSeleccion>();
            foreach (var linea in ResumenConsolidado)
            {
                int restante = linea.Cantidad;
                // Recorre las posiciones que tienen stock de ese SKU (Where).
                foreach (var posicion in _stock.Where(s => s.Sku == linea.Sku && s.Cantidad > 0))
                {
                    if (restante == 0) break;

                    int cantidad = Math.Min(restante, posicion.Cantidad);
                    detalle.Add(new LineaOrdenSeleccion { Sku = linea.Sku, Cantidad = cantidad, Posicion = posicion.Posicion });
                    restante -= cantidad;
                }

                if (restante > 0) return false;
            }

            _ultimoNroOS++;
            nroOS = _ultimoNroOS.ToString();

            _ordenesSeleccion.Add(new OrdenSeleccion
            {
                NroOS = nroOS,
                Deposito = Deposito,
                Fecha = DateTime.Now,
                Estado = Pendiente,
                NrosOP = _incluidas.ToList(),
                Detalle = detalle
            });

            // Pasa a En preparación las OP incluidas en la OS (Where).
            foreach (var op in _ordenesPreparacion.Where(o => _incluidas.Contains(o.NroOP)))
                op.Estado = EnPreparacion;

            _incluidas.Clear();
            return true;
        }
    }
}
