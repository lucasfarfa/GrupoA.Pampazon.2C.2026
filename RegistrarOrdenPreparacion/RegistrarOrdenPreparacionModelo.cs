namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    internal class RegistrarOrdenPreparacionModelo
    {
        private const string Pendiente = "Pendiente";

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (el disponible baja al registrar, prueba A.12).
        private static readonly List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Nombre = "Mercadito S.A.", Cuit = "30-71234567-8" },
            new Cliente { Nombre = "MundoFOX S.R.L.", Cuit = "30-70987654-3" },
            new Cliente { Nombre = "Ferretería Norte S.A.", Cuit = "30-71112223-4" },
            new Cliente { Nombre = "Construcciones del Plata S.R.L.", Cuit = "30-70555444-1" }
        };

        private static readonly List<string> _depositos = new List<string> { "GBA", "ROS", "CBA", "MDZ" };

        // Ningún cliente tiene mercadería fuera de GBA.
        private static readonly List<Stock> _stock = new List<Stock>
        {
            new Stock { CuitCliente = "30-71234567-8", Deposito = "GBA", Sku = "CEM-50KG", Descripcion = "Bolsa de cemento 50 kg", Cantidad = 60 },
            new Stock { CuitCliente = "30-71234567-8", Deposito = "GBA", Sku = "CAL-25KG", Descripcion = "Bolsa de cal 25 kg", Cantidad = 50 },
            new Stock { CuitCliente = "30-70987654-3", Deposito = "GBA", Sku = "ZAP-0042", Descripcion = "Caja de zapatillas", Cantidad = 100 },
            new Stock { CuitCliente = "30-71112223-4", Deposito = "GBA", Sku = "TOR-M8", Descripcion = "Caja de tornillos M8 x 100", Cantidad = 500 },
            new Stock { CuitCliente = "30-70555444-1", Deposito = "GBA", Sku = "ARE-25KG", Descripcion = "Bolsa de arena 25 kg", Cantidad = 800 }
        };

        // OP Pendientes que comprometen stock: CEM-50KG 15, CAL-25KG 3 y ZAP-0042 24.
        private static readonly List<OrdenPreparacion> _ordenes = new List<OrdenPreparacion>
        {
            new OrdenPreparacion
            {
                NroOP = "101", CuitCliente = "30-71234567-8", Deposito = "GBA", Estado = Pendiente,
                Lineas = new List<LineaOrden> { new LineaOrden { Sku = "CEM-50KG", Cantidad = 10 } }
            },
            new OrdenPreparacion
            {
                NroOP = "102", CuitCliente = "30-71234567-8", Deposito = "GBA", Estado = Pendiente,
                Lineas = new List<LineaOrden>
                {
                    new LineaOrden { Sku = "CEM-50KG", Cantidad = 5 },
                    new LineaOrden { Sku = "CAL-25KG", Cantidad = 3 }
                }
            },
            new OrdenPreparacion
            {
                NroOP = "103", CuitCliente = "30-70987654-3", Deposito = "GBA", Estado = Pendiente,
                Lineas = new List<LineaOrden> { new LineaOrden { Sku = "ZAP-0042", Cantidad = 24 } }
            }
        };

        // Las OP 104 a 109 ya existen en las pantallas siguientes del circuito: la nueva OP arranca en 110.
        private static int _ultimoNroOP = 109;

        // Orden que se está cargando en la pantalla.
        private Cliente? _cliente;
        private string? _deposito;
        private readonly List<LineaOrden> _lineas = new List<LineaOrden>();

        public string? ClienteSeleccionado => _cliente?.Nombre;
        public string? DepositoSeleccionado => _deposito;
        public bool HayProductos => _lineas.Count > 0;

        public List<string> ObtenerClientes()
        {
            return _clientes.Select(c => c.Nombre).ToList();
        }

        public List<string> ObtenerDepositos()
        {
            return _depositos.ToList();
        }

        // Cambiar el cliente vacía la lista de productos (CU-01, 17.9).
        public bool SeleccionarCliente(string nombre, out string cuit)
        {
            cuit = "";
            var cliente = _clientes.FirstOrDefault(c => c.Nombre == nombre);
            if (cliente == null) return false;

            _cliente = cliente;
            _lineas.Clear();
            cuit = cliente.Cuit;
            return true;
        }

        // Cambiar el depósito vacía la lista de productos (CU-01, 17.9).
        public bool SeleccionarDeposito(string deposito)
        {
            if (!_depositos.Contains(deposito)) return false;

            _deposito = deposito;
            _lineas.Clear();
            return true;
        }

        // SKU que el cliente tiene en stock en el depósito elegidos (CU-01, paso 6).
        public List<string> ObtenerSkus()
        {
            return StockDelCliente().Select(s => s.Sku).OrderBy(s => s).ToList();
        }

        // Disponible = stock en almacén - cantidad comprometida por las OP Pendientes (CU-01, paso 11).
        public bool ObtenerDisponible(string sku, out int disponible)
        {
            disponible = 0;
            var stock = StockDelCliente().FirstOrDefault(s => s.Sku == sku);
            if (stock == null) return false;

            int comprometido = _ordenes
                .Where(o => o.CuitCliente == stock.CuitCliente && o.Deposito == stock.Deposito && o.Estado == Pendiente)
                .SelectMany(o => o.Lineas)
                .Where(l => l.Sku == sku)
                .Sum(l => l.Cantidad);

            disponible = stock.Cantidad - comprometido;
            return true;
        }

        // Devuelve true si el SKU es del cliente en el depósito, no está en la orden y la cantidad no supera el disponible.
        public bool AgregarProducto(string sku, int cantidad)
        {
            if (!ObtenerDisponible(sku, out int disponible)) return false;
            if (cantidad <= 0 || cantidad > disponible || _lineas.Any(l => l.Sku == sku)) return false;

            var stock = StockDelCliente().First(s => s.Sku == sku);
            _lineas.Add(new LineaOrden { Sku = sku, Descripcion = stock.Descripcion, Cantidad = cantidad });
            return true;
        }

        // Devuelve true si todos los SKU estaban en la orden.
        public bool QuitarProductos(List<string> skus)
        {
            if (skus.Any(sku => !_lineas.Any(l => l.Sku == sku))) return false;

            _lineas.RemoveAll(l => skus.Contains(l.Sku));
            return true;
        }

        public List<LineaOrden> ObtenerLineas()
        {
            return _lineas.ToList();
        }

        // Registra la OP Pendiente con los productos cargados; al quedar Pendiente compromete su stock (CU-01, pasos 27 y 28).
        // Deja el modelo vacío para una nueva orden.
        public bool Registrar(string modalidad, string dni, string nombreTransportista, DateTime fechaRetiro, out string nroOP)
        {
            nroOP = "";
            if (_cliente == null || _deposito == null || _lineas.Count == 0) return false;

            _ultimoNroOP++;
            nroOP = _ultimoNroOP.ToString();

            _ordenes.Add(new OrdenPreparacion
            {
                NroOP = nroOP,
                FechaRecepcion = DateTime.Now,
                CuitCliente = _cliente.Cuit,
                Deposito = _deposito,
                Modalidad = modalidad,
                DniTransportista = dni,
                NombreTransportista = nombreTransportista,
                FechaRetiro = fechaRetiro,
                Estado = Pendiente,
                Lineas = _lineas.ToList()
            });

            _cliente = null;
            _deposito = null;
            _lineas.Clear();
            return true;
        }

        private List<Stock> StockDelCliente()
        {
            return _stock.Where(s => s.CuitCliente == _cliente?.Cuit && s.Deposito == _deposito).ToList();
        }
    }
}
