namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class GenerarOrdenSeleccionModelo
    {
        private List<string> _depositos = new List<string> { "GBA", "ROS", "CBA", "MDZ" };

        // Todas las OP de prueba son de GBA. Fechas relativas al día de hoy para que los datos sirvan cualquier día.
        private List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion { Deposito = "GBA", NroOP = 101, Cliente = "Mercadito S.A.", FechaRecepcion = DateTime.Today.AddHours(9), Modalidad = Modalidad.Fulfillment, Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = new List<LineaOrdenPreparacion> { new LineaOrdenPreparacion { Sku = "CEM-50KG", Cantidad = 10 } } },
            new OrdenPreparacion { Deposito = "GBA", NroOP = 102, Cliente = "Mercadito S.A.", FechaRecepcion = DateTime.Today.AddHours(10.5), Modalidad = Modalidad.Fulfillment, Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = new List<LineaOrdenPreparacion> { new LineaOrdenPreparacion { Sku = "CEM-50KG", Cantidad = 5 }, new LineaOrdenPreparacion { Sku = "CAL-25KG", Cantidad = 3 } } },
            new OrdenPreparacion { Deposito = "GBA", NroOP = 103, Cliente = "MundoFOX S.R.L.", FechaRecepcion = DateTime.Today.AddDays(-1).AddHours(16), Modalidad = Modalidad.PaletCerrado, Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = new List<LineaOrdenPreparacion> { new LineaOrdenPreparacion { Sku = "ZAP-0042", Cantidad = 24 } } }
        };

        // Registro de stock del depósito. CEM-50KG está en dos posiciones
        private List<StockPosicion> _stock = new List<StockPosicion>
        {
            new StockPosicion { Sku = "CEM-50KG", Posicion = new PosicionDeposito { Sector = 12, Posicion = 43, Fila = 2 }, Cantidad = 10 },
            new StockPosicion { Sku = "CEM-50KG", Posicion = new PosicionDeposito { Sector = 12, Posicion = 44, Fila = 1 }, Cantidad = 50 },
            new StockPosicion { Sku = "CAL-25KG", Posicion = new PosicionDeposito { Sector = 3, Posicion = 10, Fila = 1 }, Cantidad = 50 },
            new StockPosicion { Sku = "ZAP-0042", Posicion = new PosicionDeposito { Sector = 12, Posicion = 5, Fila = 1 }, Cantidad = 100 }
        };

        private List<OrdenSeleccion> _ordenesSeleccion = new List<OrdenSeleccion>();
        private int _ultimoNroOS = 300;

        // Filtros aplicados con "Buscar"; al abrir, sin filtro de fechas.
        private string _cliente = "";
        private DateTime? _desde;
        private DateTime? _hasta;
        private Modalidad? _modalidad;

        // OP incluidas en la OS en armado.
        private List<int> _incluidas = new List<int>();

        // Depósito elegido en el menú principal; null hasta que se selecciona uno válido.
        public string? Deposito { get; private set; }

        // Elige el depósito con el que trabaja la pantalla. Devuelve false si el código no es uno de los depósitos.
        public bool SeleccionarDeposito(string deposito)
        {
            if (!_depositos.Contains(deposito)) return false;

            Deposito = deposito;
            return true;
        }

        public int CantidadIncluidas => _incluidas.Count;

        public List<Modalidad> Modalidades => Enum.GetValues<Modalidad>().ToList();

        // Para avisar al abrir si no hay ninguna OP Pendiente en el depósito (Any: ¿hay alguna OP en estado Pendiente?).
        public bool HayOrdenesPendientes => OrdenesDelDeposito().Any(op => op.Estado == EstadoOrdenPreparacion.Pendiente);

        // Si están las dos fechas, la desde no puede ser posterior a la hasta (null = sin límite en esa fecha).
        public bool FechasValidas(DateTime? desde, DateTime? hasta)
        {
            return desde == null || hasta == null || desde.Value.Date <= hasta.Value.Date;
        }

        // La modalidad null no filtra; si no, tiene que ser una de las definidas.
        public bool ModalidadValida(Modalidad? modalidad)
        {
            return modalidad == null || Enum.IsDefined(modalidad.Value);
        }

        // Hay al menos una OP elegida.
        public bool HayOrdenes(List<int> nrosOP)
        {
            return nrosOP.Count > 0;
        }

        // Guarda los filtros. Devuelve true si las fechas y la modalidad son válidas.
        public bool Filtrar(string cliente, DateTime? desde, DateTime? hasta, Modalidad? modalidad)
        {
            if (!FechasValidas(desde, hasta) || !ModalidadValida(modalidad)) return false;

            _cliente = cliente;
            _desde = desde?.Date;
            _hasta = hasta?.Date;
            _modalidad = modalidad;
            return true;
        }

        // Filas de la grilla de OP: las Pendientes del depósito que cumplen los filtros guardados.
        // Se queda con las que cumplen estado, cliente, fechas y modalidad (Where; un filtro vacío o null no filtra)
        // y las ordena por fecha de recepción (OrderBy).
        public List<OrdenPreparacion> OrdenesFiltradas
        {
            get
            {
                return OrdenesDelDeposito()
                    .Where(op => op.Estado == EstadoOrdenPreparacion.Pendiente
                        && op.Cliente.Contains(_cliente, StringComparison.OrdinalIgnoreCase)
                        && (_desde == null || op.FechaRecepcion.Date >= _desde)
                        && (_hasta == null || op.FechaRecepcion.Date <= _hasta)
                        && (_modalidad == null || op.Modalidad == _modalidad))
                    .OrderBy(op => op.FechaRecepcion)
                    .ToList();
            }
        }

        public bool EstaIncluida(int nroOP)
        {
            return _incluidas.Contains(nroOP);
        }

        // Incluye las OP elegidas en la OS que se está armando. Devuelve true si hay al menos una y todas existen y siguen Pendientes.
        public bool IncluirOrdenes(List<int> nrosOP)
        {
            if (!HayOrdenes(nrosOP)) return false;

            foreach (var nro in nrosOP)
            {
                // Busca la OP del depósito con ese número, o null si no existe (FirstOrDefault).
                var op = OrdenesDelDeposito().FirstOrDefault(o => o.NroOP == nro);
                if (op == null || op.Estado != EstadoOrdenPreparacion.Pendiente)
                    return false;
            }

            // Agrega solo las que todavía no estaban incluidas (Where).
            _incluidas.AddRange(nrosOP.Where(nro => !_incluidas.Contains(nro)));
            return true;
        }

        // Desmarca las OP elegidas de la OS que se está armando; las que no estaban incluidas se ignoran.
        // Devuelve true si hay al menos una.
        public bool QuitarOrdenes(List<int> nrosOP)
        {
            if (!HayOrdenes(nrosOP)) return false;

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
        public List<LineaOrdenPreparacion> ResumenConsolidado
        {
            get
            {
                return OrdenesDelDeposito()
                    .Where(op => _incluidas.Contains(op.NroOP))
                    .SelectMany(op => op.Lineas)
                    .GroupBy(p => p.Sku)
                    .OrderBy(g => g.Key)
                    .Select(g => new LineaOrdenPreparacion { Sku = g.Key, Cantidad = g.Sum(p => p.Cantidad) })
                    .ToList();
            }
        }

        // Genera la OS: la registra Pendiente con el detalle por posición y pasa sus OP a En preparación.
        public bool GenerarOrdenSeleccion(out int nroOS)
        {
            nroOS = 0;
            if (Deposito == null || _incluidas.Count == 0) return false;

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
            nroOS = _ultimoNroOS;

            _ordenesSeleccion.Add(new OrdenSeleccion
            {
                NroOS = nroOS,
                Deposito = Deposito,
                FechaEmision = DateTime.Now,
                Estado = EstadoOrdenSeleccion.Pendiente,
                NrosOP = _incluidas.ToList(),
                Lineas = detalle
            });

            // Pasa a En preparación las OP incluidas en la OS (Where).
            foreach (var op in _ordenesPreparacion.Where(o => _incluidas.Contains(o.NroOP)))
                op.Estado = EstadoOrdenPreparacion.EnPreparacion;

            _incluidas.Clear();
            return true;
        }

        // OP del depósito elegido (Where).
        private List<OrdenPreparacion> OrdenesDelDeposito()
        {
            return _ordenesPreparacion.Where(op => op.Deposito == Deposito).ToList();
        }
    }
}
