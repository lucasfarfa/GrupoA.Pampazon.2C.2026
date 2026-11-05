using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class GenerarRemitoDespacharModelo
    {
        private Transportista? _transportista;   // transportista identificado con "Buscar órdenes"
        private List<int> _seleccionadas = new List<int>();

        // Depósito del operario: el que se eligió en el menú principal.
        private string Deposito => DepositoAlmacen.IdDepositoActivo;

        public bool HaySeleccion => _seleccionadas.Count > 0;

        // Un DNI tiene 7 u 8 dígitos.
        public bool DniValido(int dni)
        {
            return dni >= 1_000_000 && dni <= 99_999_999;
        }

        // Hay al menos una OE elegida.
        public bool HayOrdenes(List<int> nrosOE)
        {
            return nrosOE.Count > 0;
        }

        // Hay al menos un remito elegido.
        public bool HayRemitos(List<int> nrosRemito)
        {
            return nrosRemito.Count > 0;
        }

        // Identifica al transportista para cargar sus documentos. Devuelve true si el DNI es válido y existe un transportista con él.
        public bool BuscarTransportista(int dni, out Transportista? transportista)
        {
            transportista = null;
            if (!DniValido(dni)) return false;

            transportista = BuscarTransportistaPorDni(dni);
            _transportista = transportista;
            return transportista != null;
        }

        // Filas de "Órdenes de entrega pendientes": las del transportista buscado que todavía no se eligieron.
        // Filtra por transportista, estado Pendiente de entrega y no seleccionadas (Where)
        // y ordena por cliente y después por N° de OE (OrderBy y ThenBy).
        public List<OrdenEntrega> OrdenesPendientes
        {
            get
            {
                return OrdenesDelDeposito()
                    .Where(oe => oe.Transportista.DNI == _transportista?.DNI && oe.Estado == EstadoOrdenEntrega.PendienteEntrega && !_seleccionadas.Contains(oe.NroOE))
                    .OrderBy(oe => oe.Cliente.RazonSocial)
                    .ThenBy(oe => oe.NroOE)
                    .ToList();
            }
        }

        // Descarta el transportista identificado y la selección (nueva búsqueda).
        public bool LimpiarBusqueda()
        {
            _transportista = null;
            _seleccionadas.Clear();
            return true;
        }

        // Pasa las OE elegidas a "Se emitirán los siguientes remitos".
        // Devuelve true si hay al menos una OE y todas existen, siguen pendientes y no estaban seleccionadas.
        public bool SeleccionarOrdenes(List<int> nrosOE)
        {
            if (!HayOrdenes(nrosOE)) return false;

            foreach (var nro in nrosOE)
            {
                // Busca la OE del depósito con ese número, o null si no existe (FirstOrDefault).
                var oe = OrdenesDelDeposito().FirstOrDefault(o => o.NroOE == nro);
                if (oe == null || oe.Estado != EstadoOrdenEntrega.PendienteEntrega || _seleccionadas.Contains(nro))
                    return false;
            }

            _seleccionadas.AddRange(nrosOE);
            return true;
        }

        // Devuelve las OE elegidas a "Órdenes de entrega pendientes". Devuelve true si hay al menos una y todas estaban seleccionadas.
        public bool DeseleccionarOrdenes(List<int> nrosOE)
        {
            if (!HayOrdenes(nrosOE)) return false;

            // Si alguna OE de la lista no está seleccionada (Any), no se deselecciona nada.
            if (nrosOE.Any(nro => !_seleccionadas.Contains(nro)))
                return false;

            // Saca de la selección cada N° que esté en nrosOE; es lo mismo que RemoveAll(nro => nrosOE.Contains(nro)).
            _seleccionadas.RemoveAll(nrosOE.Contains);
            return true;
        }

        // Filas de "Se emitirán los siguientes remitos": un remito por cliente con sus OE seleccionadas.
        // Toma las OE seleccionadas (Where), las agrupa por CUIT del cliente (GroupBy), ordena los grupos por nombre del
        // cliente (OrderBy) y de cada grupo arma un remito con el cliente de la primera OE y sus N° de OE ordenados (Select y First).
        public List<RemitoAEmitir> RemitosAEmitir
        {
            get
            {
                return OrdenesDelDeposito()
                    .Where(oe => _seleccionadas.Contains(oe.NroOE))
                    .GroupBy(oe => oe.Cliente.Cuit)
                    .OrderBy(g => g.First().Cliente.RazonSocial)
                    .Select(g => new RemitoAEmitir
                    {
                        Cliente = g.First().Cliente,
                        NrosOE = g.Select(oe => oe.NroOE).OrderBy(n => n).ToList()
                    })
                    .ToList();
            }
        }

        // Emite los remitos: genera uno Emitido por cliente y pasa sus OE a Remito emitido.
        public bool EmitirRemitos()
        {
            if (_seleccionadas.Count == 0 || _transportista == null) return false;

            // Agrupa las OE seleccionadas (Where) por CUIT del cliente (GroupBy), ordenadas por nombre del cliente (OrderBy):
            // cada grupo es un remito.
            var porCliente = OrdenesDelDeposito()
                .Where(oe => _seleccionadas.Contains(oe.NroOE))
                .GroupBy(oe => oe.Cliente.Cuit)
                .OrderBy(g => g.First().Cliente.RazonSocial)
                .ToList();

            foreach (var grupo in porCliente)
            {
                var remito = new Remito
                {
                    NroRemito = ProximoNroRemito(),
                    FechaEmision = DateTime.Now,
                    // El cliente es el mismo en todo el grupo: se toma de la primera OE (First).
                    Cliente = grupo.First().Cliente,
                    Transportista = _transportista,
                    // Lista con el N° de cada OE del grupo (Select), lista con las OP de todas las líneas de esas OE
                    // (SelectMany) y suma de los bultos de esas líneas (Sum).
                    NrosOE = grupo.Select(oe => oe.NroOE).ToList(),
                    NrosOP = grupo.SelectMany(oe => oe.Lineas).Select(l => l.NroOP).ToList(),
                    TotalBultos = grupo.SelectMany(oe => oe.Lineas).Sum(l => l.Bultos),
                    Estado = EstadoRemito.Emitido
                };

                RemitoAlmacen.Remitos.Add(TraducirRemito(remito));

                // Pasa a Remito emitido en el almacén cada OE del remito (Where).
                foreach (var oe in OrdenEntregaAlmacen.OrdenesEntrega.Where(o => remito.NrosOE.Contains(o.NroOE)))
                {
                    oe.Estado = EstadoOrdenEntregaEnum.RemitoEmitido;
                }
            }

            _seleccionadas.Clear();
            return true;
        }

        // Filas de "Remitos pendientes de firma" del transportista buscado.
        // Filtra los remitos del depósito del transportista que siguen Emitidos (Where), los ordena por N° (OrderBy)
        // y traduce cada uno a la clase que usa la pantalla (Select).
        public List<Remito> RemitosPendientesFirma
        {
            get
            {
                return RemitoAlmacen.Remitos
                    .Where(r => r.IdDeposito == Deposito && r.DNITransportista == _transportista?.DNI && r.Estado == EstadoRemitoEnum.Emitido)
                    .OrderBy(r => r.NroRemito)
                    .Select(r => TraducirRemito(r))
                    .ToList();
            }
        }

        // Confirma la entrega firmada: los remitos pasan a Cumplidos, sus OE y sus OP a Cumplidas,
        // y la mercadería de esas OP sale de Despacho.
        // Devuelve true si hay al menos un remito, todos existen y estaban Emitidos, y hay en Despacho la mercadería de sus OP.
        public bool ConfirmarEntrega(List<int> nrosRemito)
        {
            if (!HayRemitos(nrosRemito)) return false;

            // Busca los remitos elegidos del depósito (Where); si falta alguno o alguno no está Emitido (Any), no confirma nada.
            var remitos = RemitoAlmacen.Remitos.Where(r => r.IdDeposito == Deposito && nrosRemito.Contains(r.NroRemito)).ToList();
            if (remitos.Count != nrosRemito.Count || remitos.Any(r => r.Estado != EstadoRemitoEnum.Emitido))
                return false;

            // Se controla todo antes de cambiar nada: si a alguna OP le falta mercadería en Despacho no queda grabado a medias (Any).
            var ordenes = OrdenesDeRemitos(remitos);
            if (ordenes.SelectMany(op => op.Lineas, (op, l) => (op, l)).Any(x => !HayEnDespacho(x.op, x.l.Sku, x.l.Cantidad)))
                return false;

            foreach (var remito in remitos)
            {
                remito.Estado = EstadoRemitoEnum.Cumplido;
                remito.FechaCumplida = DateTime.Now;

                // Pasa a Cumplida cada OE que figura en el remito (Where).
                foreach (var oe in OrdenEntregaAlmacen.OrdenesEntrega.Where(o => remito.NrosOE.Contains(o.NroOE)))
                {
                    oe.Estado = EstadoOrdenEntregaEnum.Cumplida;
                }
            }

            // Pasa a Cumplida cada OP de los remitos y saca su mercadería de Despacho.
            foreach (var op in ordenes)
            {
                op.Estado = EstadoOrdenPreparacionEnum.Cumplida;
                foreach (var linea in op.Lineas)
                {
                    SacarDeDespacho(op, linea.Sku, linea.Cantidad);
                }
            }

            return true;
        }

        // OE del depósito que ya recibió Despacho, traducidas a la clase que usa la pantalla (Where y Select).
        // Las Emitidas todavía no llegaron a Despacho: esta pantalla no las usa.
        private List<OrdenEntrega> OrdenesDelDeposito()
        {
            return OrdenEntregaAlmacen.OrdenesEntrega
                .Where(oe => oe.IdDeposito == Deposito && oe.Estado != EstadoOrdenEntregaEnum.Emitida)
                .Select(oe => TraducirOrden(oe))
                .ToList();
        }

        // Transportista con ese DNI, armado con el nombre que figura en sus OP (FirstOrDefault); null si no hay ninguna OP suya.
        private Transportista? BuscarTransportistaPorDni(int dni)
        {
            var op = OrdenPreparacionAlmacen.OrdenesPreparacion.FirstOrDefault(o => o.DNITransportista == dni);
            if (op == null) return null;

            return new Transportista { DNI = op.DNITransportista, NombreApellido = op.NombreTransportista };
        }

        // OP que lista la OE (Where), ordenadas por N° (OrderBy).
        private List<OrdenPreparacionEntidad> OrdenesDe(OrdenEntregaEntidad oe)
        {
            return OrdenPreparacionAlmacen.OrdenesPreparacion
                .Where(op => oe.NrosOP.Contains(op.NroOP))
                .OrderBy(op => op.NroOP)
                .ToList();
        }

        // OP de todas las OE de los remitos: busca las OE de cada remito (Where) y junta sus OP (SelectMany).
        private List<OrdenPreparacionEntidad> OrdenesDeRemitos(List<RemitoEntidad> remitos)
        {
            return OrdenEntregaAlmacen.OrdenesEntrega
                .Where(oe => remitos.Any(r => r.NrosOE.Contains(oe.NroOE)))
                .SelectMany(oe => OrdenesDe(oe))
                .ToList();
        }

        // Arma la OE que muestra la pantalla: el cliente sale del almacén de clientes, el transportista de su DNI,
        // y las líneas, de las OP que lista la OE con su N° y sus bultos (Select).
        private OrdenEntrega TraducirOrden(OrdenEntregaEntidad oe)
        {
            return new OrdenEntrega
            {
                NroOE = oe.NroOE,
                Cliente = BuscarCliente(oe.CuitCliente),
                Lineas = OrdenesDe(oe).Select(op => new LineaOrdenEntrega { NroOP = op.NroOP, Bultos = op.Bultos }).ToList(),
                Transportista = BuscarTransportistaPorDni(oe.DNITransportista) ?? new Transportista { DNI = oe.DNITransportista },
                Estado = TraducirEstado(oe.Estado)
            };
        }

        // Arma el remito que muestra la pantalla: las OP y los bultos salen de las OE que lista el remito
        // (Where, SelectMany y Sum).
        private Remito TraducirRemito(RemitoEntidad remito)
        {
            var lineas = OrdenesDelDeposito()
                .Where(oe => remito.NrosOE.Contains(oe.NroOE))
                .SelectMany(oe => oe.Lineas)
                .ToList();

            return new Remito
            {
                NroRemito = remito.NroRemito,
                FechaEmision = remito.FechaEmision,
                Cliente = BuscarCliente(remito.CuitCliente),
                Transportista = BuscarTransportistaPorDni(remito.DNITransportista) ?? new Transportista { DNI = remito.DNITransportista },
                NrosOE = remito.NrosOE.ToList(),
                NrosOP = lineas.Select(l => l.NroOP).ToList(),
                TotalBultos = lineas.Sum(l => l.Bultos),
                Estado = remito.Estado == EstadoRemitoEnum.Cumplido ? EstadoRemito.Cumplido : EstadoRemito.Emitido,
                FechaCumplida = remito.FechaCumplida
            };
        }

        // Arma el remito que se graba en el almacén a partir del remito armado en la pantalla:
        // del cliente y del transportista guarda solo sus claves. Las OP y los bultos salen de sus OE.
        private RemitoEntidad TraducirRemito(Remito remito)
        {
            return new RemitoEntidad
            {
                NroRemito = remito.NroRemito,
                FechaEmision = remito.FechaEmision,
                Estado = remito.Estado == EstadoRemito.Cumplido ? EstadoRemitoEnum.Cumplido : EstadoRemitoEnum.Emitido,
                NrosOE = remito.NrosOE.ToList(),
                FechaCumplida = remito.FechaCumplida,
                CuitCliente = remito.Cliente.Cuit,
                DNITransportista = remito.Transportista.DNI,
                IdDeposito = Deposito
            };
        }

        // Pasa el estado de la OE del almacén al de la pantalla (las Emitidas no llegan acá: ver OrdenesDelDeposito).
        private EstadoOrdenEntrega TraducirEstado(EstadoOrdenEntregaEnum estado)
        {
            if (estado == EstadoOrdenEntregaEnum.PendienteDeEntrega) return EstadoOrdenEntrega.PendienteEntrega;
            if (estado == EstadoOrdenEntregaEnum.RemitoEmitido) return EstadoOrdenEntrega.RemitoEmitido;
            return EstadoOrdenEntrega.Cumplida;
        }

        // Busca el cliente por CUIT y toma su razón social (First).
        private Cliente BuscarCliente(long cuit)
        {
            var cliente = ClienteAlmacen.Clientes.First(c => c.Cuit == cuit);
            return new Cliente { Cuit = cliente.Cuit, RazonSocial = cliente.RazonSocial };
        }

        // Mercadería del cliente de la OP en su depósito con ese SKU, o null si no hay (FirstOrDefault).
        private MercaderiaEntidad? BuscarMercaderia(OrdenPreparacionEntidad op, string sku)
        {
            return MercaderiaAlmacen.Mercaderias.FirstOrDefault(m => m.CuitCliente == op.CuitCliente && m.Deposito == op.Deposito && m.Sku == sku);
        }

        // Existe la mercadería y tiene en Despacho la cantidad que se entrega.
        private bool HayEnDespacho(OrdenPreparacionEntidad op, string sku, int cantidad)
        {
            var mercaderia = BuscarMercaderia(op, sku);
            return mercaderia != null && mercaderia.CantidadEnDespacho >= cantidad;
        }

        // Resta de Despacho la cantidad que se entrega.
        private void SacarDeDespacho(OrdenPreparacionEntidad op, string sku, int cantidad)
        {
            var mercaderia = BuscarMercaderia(op, sku);
            if (mercaderia == null) return;

            mercaderia.CantidadEnDespacho -= cantidad;
        }

        // El N° de remito es correlativo: el mayor del almacén más uno (Max), o 1 si no hay ninguno (DefaultIfEmpty).
        private int ProximoNroRemito()
        {
            return RemitoAlmacen.Remitos.Select(r => r.NroRemito).DefaultIfEmpty(0).Max() + 1;
        }
    }
}
