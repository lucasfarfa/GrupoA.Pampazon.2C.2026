using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class GenerarOrdenSeleccionModelo
    {
        // Filtros aplicados con "Buscar"; al abrir, sin filtro de fechas.
        private string _cliente = "";
        private DateTime? _desde;
        private DateTime? _hasta;
        private Modalidad? _modalidad;

        // OP incluidas en la OS en armado.
        private List<int> _incluidas = new List<int>();

        // Depósito elegido en el menú principal; null hasta que se selecciona uno válido.
        public string? Deposito { get; private set; }

        // Elige el depósito con el que trabaja la pantalla. Devuelve false si el código no es uno de los depósitos del almacén
        // (Any: ¿hay algún depósito con ese código?).
        public bool SeleccionarDeposito(string deposito)
        {
            if (!DepositoAlmacen.Depositos.Any(d => d.IdDeposito == deposito)) return false;

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
                        && op.Cliente.RazonSocial.Contains(_cliente, StringComparison.OrdinalIgnoreCase)
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
                return OrdenesIncluidas()
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

            // Se arma todo el detalle antes de grabar: si a algún producto le falta mercadería, no queda nada a medias.
            var detalle = new List<LineaOrdenSeleccion>();
            foreach (var producto in ProductosPorCliente())
            {
                if (!AgregarPosiciones(detalle, producto.Cliente.Cuit, producto.Sku, producto.Cantidad)) return false;
            }

            var orden = new OrdenSeleccion
            {
                NroOS = ProximoNroOS(),
                Deposito = Deposito,
                FechaEmision = DateTime.Now,
                Estado = EstadoOrdenSeleccion.Pendiente,
                NrosOP = _incluidas.ToList(),
                Lineas = detalle
            };

            OrdenSeleccionAlmacen.OrdenesSeleccion.Add(TraducirOrdenSeleccion(orden));

            // Pasa a En preparación las OP incluidas en la OS (Where).
            foreach (var op in OrdenPreparacionAlmacen.OrdenesPreparacion.Where(o => orden.NrosOP.Contains(o.NroOP)))
            {
                op.Estado = EstadoOrdenPreparacionEnum.EnPreparacion;
            }

            nroOS = orden.NroOS;
            _incluidas.Clear();
            return true;
        }

        // OP Pendientes del depósito elegido, traducidas a la clase que usa la pantalla.
        // Filtra por depósito y estado (Where) y traduce cada una (Select).
        private List<OrdenPreparacion> OrdenesDelDeposito()
        {
            return OrdenPreparacionAlmacen.OrdenesPreparacion
                .Where(op => op.Deposito == Deposito && op.Estado == EstadoOrdenPreparacionEnum.Pendiente)
                .Select(op => TraducirOrden(op))
                .ToList();
        }

        // OP del depósito incluidas en la OS en armado (Where).
        private List<OrdenPreparacion> OrdenesIncluidas()
        {
            return OrdenesDelDeposito().Where(op => _incluidas.Contains(op.NroOP)).ToList();
        }

        // Cantidad a retirar por cliente y SKU: la mercadería de cada cliente está en sus propias posiciones.
        // De cada OP incluida arma un par cliente-línea (SelectMany), los agrupa por CUIT y SKU (GroupBy),
        // los ordena por SKU y cliente (OrderBy y ThenBy) y suma las cantidades de cada grupo (Select y Sum).
        private List<(Cliente Cliente, string Sku, int Cantidad)> ProductosPorCliente()
        {
            return OrdenesIncluidas()
                .SelectMany(op => op.Lineas, (op, linea) => (op.Cliente, linea.Sku, linea.Cantidad))
                .GroupBy(p => (p.Cliente.Cuit, p.Sku))
                .OrderBy(g => g.Key.Sku)
                .ThenBy(g => g.Key.Cuit)
                .Select(g => (g.First().Cliente, g.Key.Sku, g.Sum(p => p.Cantidad)))
                .ToList();
        }

        // Si un SKU del cliente está en más de una posición, agrega una línea por posición hasta cubrir la cantidad.
        // Recorre las posiciones del cliente con ese SKU (Where) ordenadas por X-Y-Z (OrderBy y ThenBy)
        // y de cada una toma lo que queda libre después de lo asignado en OS Pendientes (CU-02, paso 17).
        // Devuelve false si entre todas sus posiciones no alcanza.
        private bool AgregarPosiciones(List<LineaOrdenSeleccion> detalle, long cuit, string sku, int cantidadPedida)
        {
            int restante = cantidadPedida;
            foreach (var stock in StockDelCliente(cuit).Where(s => s.Sku == sku)
                         .OrderBy(s => s.Posicion.Sector).ThenBy(s => s.Posicion.Posicion).ThenBy(s => s.Posicion.Fila))
            {
                if (restante == 0) break;

                int libre = stock.Cantidad - AsignadoEnOSPendientes(cuit, sku, stock.Posicion);
                if (libre <= 0) continue;

                int cantidad = Math.Min(restante, libre);
                detalle.Add(new LineaOrdenSeleccion { CuitCliente = cuit, Sku = sku, Cantidad = cantidad, Posicion = stock.Posicion });
                restante -= cantidad;
            }

            return restante == 0;
        }

        // Lo ya asignado a esa posición, cliente y SKU en las OS Pendientes del depósito (CU-02, paso 17).
        // Toma las OS Pendientes del depósito (Where), junta sus líneas (SelectMany),
        // se queda con las de esa posición, cliente y SKU (Where) y suma sus cantidades (Sum).
        private int AsignadoEnOSPendientes(long cuit, string sku, PosicionDeposito posicion)
        {
            return OrdenSeleccionAlmacen.OrdenesSeleccion
                .Where(os => os.Deposito == Deposito && os.Estado == EstadoOrdenSeleccionEnum.Pendiente)
                .SelectMany(os => os.Lineas)
                .Where(l => l.CuitCliente == cuit && l.Sku == sku
                    && l.Sector == posicion.Sector && l.Posicion == posicion.Posicion && l.Fila == posicion.Fila)
                .Sum(l => l.Cantidad);
        }

        // Registros de stock del cliente en las posiciones del depósito elegido.
        // Busca el depósito (FirstOrDefault) y de cada posición toma el contenido del cliente (SelectMany y Where),
        // traducido a la clase que usa la pantalla.
        private List<CantidadPosicion> StockDelCliente(long cuit)
        {
            var deposito = DepositoAlmacen.Depositos.FirstOrDefault(d => d.IdDeposito == Deposito);
            if (deposito == null) return new List<CantidadPosicion>();

            return deposito.Posiciones
                .SelectMany(p => p.Contenido.Where(c => c.CuitCliente == cuit), (p, c) => new CantidadPosicion
                {
                    Sku = c.Sku,
                    Cantidad = c.Cantidad,
                    Posicion = new PosicionDeposito { Sector = p.Sector, Posicion = p.Posicion, Fila = p.Fila }
                })
                .ToList();
        }

        // Arma la OP que muestra la pantalla: el cliente sale del almacén de clientes.
        // Solo se traducen OP Pendientes; una línea por cada línea de la OP, con su SKU y su cantidad (Select).
        private OrdenPreparacion TraducirOrden(OrdenPreparacionEntidad op)
        {
            return new OrdenPreparacion
            {
                NroOP = op.NroOP,
                Deposito = op.Deposito,
                Cliente = BuscarCliente(op.CuitCliente),
                FechaRecepcion = op.FechaRecepcion,
                Modalidad = TraducirModalidad(op.Modalidad),
                Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = op.Lineas.Select(l => new LineaOrdenPreparacion { Sku = l.Sku, Cantidad = l.Cantidad }).ToList()
            };
        }

        // Arma la OS que se graba en el almacén a partir de la OS armada en la pantalla:
        // de cada línea guarda la posición en datos sueltos, el cliente, el SKU y la cantidad (Select).
        private OrdenSeleccionEntidad TraducirOrdenSeleccion(OrdenSeleccion orden)
        {
            return new OrdenSeleccionEntidad
            {
                NroOS = orden.NroOS,
                Deposito = orden.Deposito,
                FechaEmision = orden.FechaEmision,
                Estado = TraducirEstado(orden.Estado),
                NrosOP = orden.NrosOP.ToList(),
                Lineas = orden.Lineas.Select(l => new Almacenes.LineaOrdenSeleccion
                {
                    Sector = l.Posicion.Sector,
                    Posicion = l.Posicion.Posicion,
                    Fila = l.Posicion.Fila,
                    CuitCliente = l.CuitCliente,
                    Sku = l.Sku,
                    Cantidad = l.Cantidad
                }).ToList()
            };
        }

        // Busca el cliente por CUIT y toma su razón social (First).
        private Cliente BuscarCliente(long cuit)
        {
            var cliente = ClienteAlmacen.Clientes.First(c => c.Cuit == cuit);
            return new Cliente { Cuit = cliente.Cuit, RazonSocial = cliente.RazonSocial };
        }

        // Pasa la modalidad del almacén a la de la pantalla (tienen los mismos valores).
        private Modalidad TraducirModalidad(ModalidadEnum modalidad)
        {
            return modalidad == ModalidadEnum.PaletCerrado ? Modalidad.PaletCerrado : Modalidad.Fulfillment;
        }

        // Pasa el estado de la OS de la pantalla al del almacén: esta pantalla solo genera OS Pendientes.
        private EstadoOrdenSeleccionEnum TraducirEstado(EstadoOrdenSeleccion estado)
        {
            return EstadoOrdenSeleccionEnum.Pendiente;
        }

        // El N° de OS es correlativo: el mayor del almacén más uno (Max), o 1 si no hay ninguna (DefaultIfEmpty).
        private int ProximoNroOS()
        {
            return OrdenSeleccionAlmacen.OrdenesSeleccion.Select(os => os.NroOS).DefaultIfEmpty(0).Max() + 1;
        }
    }
}
