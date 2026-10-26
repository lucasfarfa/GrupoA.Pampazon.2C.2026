namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    internal class RegistrarOrdenPreparacionModelo
    {

        private List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Nombre = "Mercadito S.A.", Cuit = 30712345678 },
            new Cliente { Nombre = "MundoFOX S.R.L.", Cuit = 30709876543 },
            new Cliente { Nombre = "Ferretería Norte S.A.", Cuit = 30711122234 },
            new Cliente { Nombre = "Construcciones del Plata S.R.L.", Cuit = 30705554441 }
        };

        private List<string> _depositos = new List<string> { "GBA", "ROS", "CBA", "MDZ" };

        // Ningún cliente tiene mercadería fuera de GBA.
        private List<Stock> _stock = new List<Stock>
        {
            new Stock { CuitCliente = 30712345678, Deposito = "GBA", Sku = "CEM-50KG", Descripcion = "Bolsa de cemento 50 kg", Cantidad = 60 },
            new Stock { CuitCliente = 30712345678, Deposito = "GBA", Sku = "CAL-25KG", Descripcion = "Bolsa de cal 25 kg", Cantidad = 50 },
            new Stock { CuitCliente = 30709876543, Deposito = "GBA", Sku = "ZAP-0042", Descripcion = "Caja de zapatillas", Cantidad = 100 },
            new Stock { CuitCliente = 30711122234, Deposito = "GBA", Sku = "TOR-M8", Descripcion = "Caja de tornillos M8 x 100", Cantidad = 500 },
            new Stock { CuitCliente = 30705554441, Deposito = "GBA", Sku = "ARE-25KG", Descripcion = "Bolsa de arena 25 kg", Cantidad = 800 }
        };

        // OP Pendientes que comprometen stock: CEM-50KG 15, CAL-25KG 3 y ZAP-0042 24.
        private List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion
            {
                NroOP = 101, CuitCliente = 30712345678, Deposito = "GBA", Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = new List<LineaOrdenPreparacion> { new LineaOrdenPreparacion { Sku = "CEM-50KG", Cantidad = 10 } }
            },
            new OrdenPreparacion
            {
                NroOP = 102, CuitCliente = 30712345678, Deposito = "GBA", Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = new List<LineaOrdenPreparacion>
                {
                    new LineaOrdenPreparacion { Sku = "CEM-50KG", Cantidad = 5 },
                    new LineaOrdenPreparacion { Sku = "CAL-25KG", Cantidad = 3 }
                }
            },
            new OrdenPreparacion
            {
                NroOP = 103, CuitCliente = 30709876543, Deposito = "GBA", Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = new List<LineaOrdenPreparacion> { new LineaOrdenPreparacion { Sku = "ZAP-0042", Cantidad = 24 } }
            }
        };

        // Las OP 104 a 109 ya existen en las pantallas siguientes del circuito: la nueva OP arranca en 110.
        private int _ultimoNroOP = 109;

        // Orden que se está cargando en la pantalla.
        private Cliente? _cliente;
        private string? _deposito;
        private string? _sku;
        private List<LineaOrdenPreparacion> _lineas = new List<LineaOrdenPreparacion>();

        public string? ClienteSeleccionado => _cliente?.Nombre;
        public string? DepositoSeleccionado => _deposito;
        public string? SkuSeleccionado => _sku;
        public bool HayProductos => _lineas.Count > 0;

        // Nombres para la lista "Cliente": de cada cliente toma solo el nombre (Select).
        public List<string> Clientes => _clientes.Select(c => c.Nombre).ToList();
        public List<string> Depositos => _depositos.ToList();

        // Elige el cliente y devuelve su CUIT para mostrarlo. Cambiar el cliente vacía la lista de productos.
        public bool SeleccionarCliente(string nombre, out long cuit)
        {
            cuit = 0;
            // Busca el cliente con ese nombre, o null si no existe (FirstOrDefault).
            var cliente = _clientes.FirstOrDefault(c => c.Nombre == nombre);
            if (cliente == null) return false;

            _cliente = cliente;
            _sku = null;
            _lineas.Clear();
            cuit = cliente.Cuit;
            return true;
        }

        // Cambiar el depósito vacía la lista de productos (CU-01, 17.9).
        public bool SeleccionarDeposito(string deposito)
        {
            if (!_depositos.Contains(deposito)) return false;

            _deposito = deposito;
            _sku = null;
            _lineas.Clear();
            return true;
        }

        // SKU para la lista "SKU": los que el cliente tiene en stock en el depósito elegido.
        // De cada registro de stock toma el SKU (Select) y los ordena alfabéticamente (OrderBy).
        public List<string> Skus => StockDelCliente().Select(s => s.Sku).OrderBy(s => s).ToList();

        // Elige el SKU para mostrar su disponible. Devuelve true si el cliente lo tiene en stock en el depósito
        // (Any: ¿hay algún registro de stock con ese SKU?).
        public bool SeleccionarSku(string sku)
        {
            if (!StockDelCliente().Any(s => s.Sku == sku)) return false;

            _sku = sku;
            return true;
        }

        // Cantidad que se puede pedir del SKU elegido: stock en almacén menos lo comprometido por las OP Pendientes.
        public int Disponible
        {
            get
            {
                // Busca el registro de stock del SKU elegido, o null si no hay (FirstOrDefault).
                var stock = StockDelCliente().FirstOrDefault(s => s.Sku == _sku);
                if (stock == null) return 0;

                // De las OP Pendientes del cliente en el depósito (Where) junta todas sus líneas (SelectMany),
                // se queda con las del SKU elegido (Where) y suma sus cantidades (Sum).
                int comprometido = _ordenesPreparacion
                    .Where(o => o.CuitCliente == stock.CuitCliente && o.Deposito == stock.Deposito && o.Estado == EstadoOrdenPreparacion.Pendiente)
                    .SelectMany(o => o.Lineas)
                    .Where(l => l.Sku == _sku)
                    .Sum(l => l.Cantidad);

                return stock.Cantidad - comprometido;
            }
        }

        // Para avisar si el SKU elegido ya está en "Productos a preparar" (Any: ¿hay alguna línea con ese SKU?).
        public bool SkuYaAgregado => _lineas.Any(l => l.Sku == _sku);

        // La cantidad a pedir es mayor a cero.
        public bool CantidadValida(int cantidad)
        {
            return cantidad > 0;
        }

        // La cantidad a pedir no supera el disponible del SKU elegido.
        public bool CantidadDisponible(int cantidad)
        {
            return cantidad <= Disponible;
        }

        // Hay al menos un SKU elegido de "Productos a preparar".
        public bool HaySkus(List<string> skus)
        {
            return skus.Count > 0;
        }

        // Agrega el SKU elegido a "Productos a preparar" y deja de tenerlo elegido.
        // Devuelve true si hay un SKU elegido, no está en la orden y la cantidad es válida y no supera el disponible.
        public bool AgregarProducto(int cantidad)
        {
            // Busca el registro de stock del SKU elegido para tomar su descripción (FirstOrDefault).
            var stock = StockDelCliente().FirstOrDefault(s => s.Sku == _sku);
            if (stock == null) return false;
            if (!CantidadValida(cantidad) || !CantidadDisponible(cantidad) || SkuYaAgregado) return false;

            _lineas.Add(new LineaOrdenPreparacion { Sku = stock.Sku, Descripcion = stock.Descripcion, Cantidad = cantidad });
            _sku = null;
            return true;
        }

        // Saca de "Productos a preparar" los SKU elegidos. Devuelve true si hay al menos uno y todos estaban en la orden.
        public bool QuitarProductos(List<string> skus)
        {
            if (!HaySkus(skus)) return false;

            // Si algún SKU de la lista (Any) no está entre las líneas cargadas (!Any), no se quita nada.
            if (skus.Any(sku => !_lineas.Any(l => l.Sku == sku))) return false;

            // Borra las líneas cuyo SKU esté en la lista (RemoveAll).
            _lineas.RemoveAll(l => skus.Contains(l.Sku));
            return true;
        }

        public List<LineaOrdenPreparacion> Lineas => _lineas.ToList();

        // Un DNI tiene 7 u 8 dígitos.
        public bool DniValido(int dni)
        {
            return dni >= 1_000_000 && dni <= 99_999_999;
        }

        // El nombre del transportista no está vacío.
        public bool NombreCompleto(string nombre)
        {
            return nombre.Trim() != "";
        }

        // El nombre solo admite letras, espacios, apóstrofos y guiones (All: ¿todos los caracteres cumplen?).
        public bool NombreValido(string nombre)
        {
            return NombreCompleto(nombre) && nombre.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-');
        }

        // La fecha de retiro no puede ser anterior a hoy.
        public bool FechaRetiroValida(DateTime fechaRetiro)
        {
            return fechaRetiro.Date >= DateTime.Today;
        }

        // La modalidad es Fulfillment o Palet cerrado.
        public bool ModalidadValida(string modalidad)
        {
            return modalidad == "Fulfillment" || modalidad == "Palet cerrado";
        }

        // Registra la OP Pendiente con los productos cargados; al quedar Pendiente compromete su stock (CU-01, pasos 27 y 28).
        // Devuelve true si hay cliente, depósito y productos, y la modalidad y los datos del transportista y del retiro son válidos.
        // Deja el modelo vacío para una nueva orden.
        public bool Registrar(string modalidad, int dni, string nombreTransportista, DateTime fechaRetiro, out int nroOP)
        {
            nroOP = 0;
            if (_cliente == null || _deposito == null || _lineas.Count == 0) return false;
            if (!ModalidadValida(modalidad) || !DniValido(dni) || !NombreValido(nombreTransportista) || !FechaRetiroValida(fechaRetiro))
                return false;

            _ultimoNroOP++;
            nroOP = _ultimoNroOP;

            _ordenesPreparacion.Add(new OrdenPreparacion
            {
                NroOP = nroOP,
                FechaRecepcion = DateTime.Now,
                CuitCliente = _cliente.Cuit,
                Deposito = _deposito,
                Modalidad = modalidad,
                Transportista = new Transportista { DNI = dni, NombreApellido = nombreTransportista },
                FechaRetiro = fechaRetiro,
                Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = _lineas.ToList()
            });

            _cliente = null;
            _deposito = null;
            _sku = null;
            _lineas.Clear();
            return true;
        }

        // Registros de stock del cliente elegido en el depósito elegido (Where).
        private List<Stock> StockDelCliente()
        {
            return _stock.Where(s => s.CuitCliente == _cliente?.Cuit && s.Deposito == _deposito).ToList();
        }
    }
}
