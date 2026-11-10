using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    internal class RegistrarOrdenPreparacionModelo
    {
        // Orden que se está cargando en la pantalla.
        private Cliente? _cliente;
        private string? _deposito;
        private string? _sku;
        private List<LineaOrdenPreparacion> _lineas = new List<LineaOrdenPreparacion>();

        public string? ClienteSeleccionado => _cliente?.RazonSocial;
        public string? DepositoSeleccionado => _deposito;
        public string? SkuSeleccionado => _sku;
        public bool HayProductos => _lineas.Count > 0;

        // Nombres para la lista "Cliente": de cada cliente del almacén toma solo la razón social (Select).
        public List<string> Clientes => ClienteAlmacen.Clientes.Select(c => c.RazonSocial).ToList();

        // Códigos para la lista "Depósito": de cada depósito del almacén toma su código (Select).
        // Esta pantalla no usa el depósito del menú: el operario lo elige acá.
        public List<string> Depositos => DepositoAlmacen.Depositos.Select(d => d.IdDeposito).ToList();

        // Elige el cliente y devuelve su CUIT para mostrarlo. Cambiar el cliente vacía la lista de productos.
        public bool SeleccionarCliente(string nombre, out long cuit)
        {
            cuit = 0;
            // Busca el cliente con esa razón social en el almacén, o null si no existe (FirstOrDefault).
            var cliente = ClienteAlmacen.Clientes.FirstOrDefault(c => c.RazonSocial == nombre);
            if (cliente == null) return false;

            _cliente = TraducirCliente(cliente);
            _sku = null;
            _lineas.Clear();
            cuit = cliente.Cuit;
            return true;
        }

        // Cambiar el depósito vacía la lista de productos (CU-01, 20.9).
        public bool SeleccionarDeposito(string deposito)
        {
            if (!Depositos.Contains(deposito)) return false;

            _deposito = deposito;
            _sku = null;
            _lineas.Clear();
            return true;
        }

        // SKU para la lista "SKU": los que el cliente tiene con cantidad mayor a cero en alguna posición del depósito
        // elegido (CU-01, paso 8). Filtra la mercadería con stock en posiciones (Where), toma el SKU (Select)
        // y los ordena alfabéticamente (OrderBy).
        public List<string> Skus => MercaderiaDelCliente()
            .Where(m => CantidadEnPosiciones(m) > 0)
            .Select(m => m.Sku)
            .OrderBy(s => s)
            .ToList();

        // Elige el SKU para mostrar su disponible. Devuelve true si el cliente tiene ese SKU con stock
        // en alguna posición del depósito (Any: ¿hay alguna mercadería con ese SKU y cantidad mayor a cero?).
        public bool SeleccionarSku(string sku)
        {
            if (!MercaderiaDelCliente().Any(m => m.Sku == sku && CantidadEnPosiciones(m) > 0)) return false;

            _sku = sku;
            return true;
        }

        // Cantidad que se puede pedir del SKU elegido: lo que hay en las posiciones del depósito
        // menos lo comprometido por las OP Pendientes.
        public int Disponible
        {
            get
            {
                var mercaderia = BuscarMercaderia(_sku);
                if (mercaderia == null) return 0;

                return CantidadEnPosiciones(mercaderia) - mercaderia.CantidadComprometida;
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
            // La mercadería del SKU elegido da la descripción de la línea.
            var mercaderia = BuscarMercaderia(_sku);
            if (mercaderia == null) return false;
            if (!CantidadValida(cantidad) || !CantidadDisponible(cantidad) || SkuYaAgregado) return false;

            _lineas.Add(new LineaOrdenPreparacion { Sku = mercaderia.Sku, Descripcion = mercaderia.Descripcion, Cantidad = cantidad });
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
        public bool ModalidadValida(Modalidad modalidad)
        {
            return Enum.IsDefined(modalidad);
        }

        // Registra la OP Pendiente con los productos cargados; al quedar Pendiente compromete su stock (CU-01, pasos 31 y 32).
        // Devuelve true si hay cliente, depósito y productos, y la modalidad y los datos del transportista y del retiro son válidos.
        // Deja el modelo vacío para una nueva orden.
        public bool Registrar(Modalidad modalidad, int dni, string nombreTransportista, DateTime fechaRetiro, out int nroOP)
        {
            nroOP = 0;
            if (_cliente == null || _deposito == null || _lineas.Count == 0) return false;
            if (!ModalidadValida(modalidad) || !DniValido(dni) || !NombreValido(nombreTransportista) || !FechaRetiroValida(fechaRetiro))
                return false;

            // Se controla todo antes de cambiar nada: si a alguna línea le falta su mercadería no queda grabado a medias (Any).
            if (_lineas.Any(l => BuscarMercaderia(l.Sku) == null)) return false;

            var orden = new OrdenPreparacion
            {
                NroOP = ProximoNroOP(),
                FechaRecepcion = DateTime.Now,
                Cliente = _cliente,
                Deposito = _deposito,
                Modalidad = modalidad,
                Transportista = new Transportista { DNI = dni, NombreApellido = nombreTransportista },
                FechaRetiro = fechaRetiro,
                Estado = EstadoOrdenPreparacion.Pendiente,
                Lineas = _lineas.ToList()
            };

            OrdenPreparacionAlmacen.OrdenesPreparacion.Add(TraducirOrden(orden));

            foreach (var linea in orden.Lineas)
            {
                Comprometer(linea.Sku, linea.Cantidad);
            }

            nroOP = orden.NroOP;

            _cliente = null;
            _deposito = null;
            _sku = null;
            _lineas.Clear();
            return true;
        }

        // Arma el cliente que usa la pantalla a partir del cliente del almacén.
        private Cliente TraducirCliente(ClienteEntidad cliente)
        {
            return new Cliente { Cuit = cliente.Cuit, RazonSocial = cliente.RazonSocial };
        }

        // Arma la OP que se graba en el almacén a partir de la OP que se cargó en la pantalla:
        // del cliente y del transportista guarda sus datos sueltos, y de cada línea, su SKU y su cantidad (Select).
        private OrdenPreparacionEntidad TraducirOrden(OrdenPreparacion orden)
        {
            return new OrdenPreparacionEntidad
            {
                NroOP = orden.NroOP,
                FechaRecepcion = orden.FechaRecepcion,
                CuitCliente = orden.Cliente.Cuit,
                Deposito = orden.Deposito,
                Modalidad = TraducirModalidad(orden.Modalidad),
                DNITransportista = orden.Transportista.DNI,
                NombreTransportista = orden.Transportista.NombreApellido,
                FechaRetiro = orden.FechaRetiro,
                Estado = TraducirEstado(orden.Estado),
                Lineas = orden.Lineas.Select(l => new Almacenes.LineaOrdenPreparacion { Sku = l.Sku, Cantidad = l.Cantidad }).ToList()
            };
        }

        // Pasa la modalidad de la pantalla a la del almacén (tienen los mismos valores).
        private ModalidadEnum TraducirModalidad(Modalidad modalidad)
        {
            return modalidad == Modalidad.PaletCerrado ? ModalidadEnum.PaletCerrado : ModalidadEnum.Fulfillment;
        }

        // Pasa el estado de la pantalla al del almacén: busca el estado del almacén con el mismo nombre (Enum.Parse).
        private EstadoOrdenPreparacionEnum TraducirEstado(EstadoOrdenPreparacion estado)
        {
            return Enum.Parse<EstadoOrdenPreparacionEnum>(estado.ToString());
        }

        // Mercadería del cliente elegido en el depósito elegido (Where).
        private List<MercaderiaEntidad> MercaderiaDelCliente()
        {
            return MercaderiaAlmacen.Mercaderias
                .Where(m => m.CuitCliente == _cliente?.Cuit && m.Deposito == _deposito)
                .ToList();
        }

        // Mercadería del cliente elegido en el depósito elegido con ese SKU, o null si no hay (FirstOrDefault).
        private MercaderiaEntidad? BuscarMercaderia(string? sku)
        {
            return MercaderiaDelCliente().FirstOrDefault(m => m.Sku == sku);
        }

        // Cantidad de la mercadería guardada en las posiciones de su depósito: busca el depósito (FirstOrDefault),
        // junta el contenido de todas sus posiciones (SelectMany), se queda con el del cliente y SKU (Where) y lo suma (Sum).
        private int CantidadEnPosiciones(MercaderiaEntidad mercaderia)
        {
            var deposito = DepositoAlmacen.Depositos.FirstOrDefault(d => d.IdDeposito == mercaderia.Deposito);
            if (deposito == null) return 0;

            return deposito.Posiciones
                .SelectMany(p => p.Contenido)
                .Where(c => c.CuitCliente == mercaderia.CuitCliente && c.Sku == mercaderia.Sku)
                .Sum(c => c.Cantidad);
        }

        // Suma la cantidad de la nueva OP a lo comprometido de su mercadería.
        private void Comprometer(string sku, int cantidad)
        {
            var mercaderia = BuscarMercaderia(sku);
            if (mercaderia == null) return;

            mercaderia.CantidadComprometida += cantidad;
        }

        // El N° de OP es correlativo: el mayor del almacén más uno (Max), o 1 si no hay ninguna (DefaultIfEmpty).
        private int ProximoNroOP()
        {
            return OrdenPreparacionAlmacen.OrdenesPreparacion.Select(op => op.NroOP).DefaultIfEmpty(0).Max() + 1;
        }
    }
}
