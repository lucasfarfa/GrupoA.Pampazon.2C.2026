namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class PrepararProductosModelo
    {
        private const string Pendiente = "Pendiente";
        private const string Cumplida = "Cumplida";

        private List<OrdenSeleccion> _ordenes = new List<OrdenSeleccion>
        {
            new OrdenSeleccion
            {
                Nro = 501,
                Estado = Pendiente,
                NrosOP = new List<int> { 101, 102 },
                Lineas =
                {
                    new LineaMercaderia { Posicion = new PosicionDeposito { Sector = 12, Posicion = 43, Fila = 2 }, Sku = "CEM-50KG", Cantidad = 10 },
                    new LineaMercaderia { Posicion = new PosicionDeposito { Sector = 12, Posicion = 44, Fila = 1 }, Sku = "CEM-50KG", Cantidad = 5 },
                    new LineaMercaderia { Posicion = new PosicionDeposito { Sector = 3, Posicion = 10, Fila = 1 }, Sku = "CAL-25KG", Cantidad = 3 }
                }
            },
            new OrdenSeleccion
            {
                Nro = 502,
                Estado = Pendiente,
                NrosOP = new List<int> { 103 },
                Lineas =
                {
                    new LineaMercaderia { Posicion = new PosicionDeposito { Sector = 12, Posicion = 5, Fila = 1 }, Sku = "ZAP-0042", Cantidad = 24 }
                }
            }
        };

        private List<StockPosicion> _stock = new List<StockPosicion>
        {
            new StockPosicion { Sku = "CEM-50KG", Posicion = new PosicionDeposito { Sector = 12, Posicion = 43, Fila = 2 }, Cantidad = 10 },
            new StockPosicion { Sku = "CEM-50KG", Posicion = new PosicionDeposito { Sector = 12, Posicion = 44, Fila = 1 }, Cantidad = 50 },
            new StockPosicion { Sku = "CAL-25KG", Posicion = new PosicionDeposito { Sector = 3, Posicion = 10, Fila = 1 }, Cantidad = 50 },
            new StockPosicion { Sku = "ZAP-0042", Posicion = new PosicionDeposito { Sector = 12, Posicion = 5, Fila = 1 }, Cantidad = 100 }
        };

        private int? _nroOsSeleccionada;

        public string Deposito => "GBA";

        // Lista del combo "Orden de selección": N° de las OS Pendientes del depósito.
        // Filtra las Pendientes (Where), las ordena por número (OrderBy) y toma solo el N° (Select).
        public List<int> OrdenesPendientes
        {
            get
            {
                return _ordenes
                    .Where(o => o.Estado == Pendiente)
                    .OrderBy(o => o.Nro)
                    .Select(o => o.Nro)
                    .ToList();
            }
        }

        // N° de la OS elegida, para volver a marcarla en el combo; null si no hay ninguna.
        // Busca la OS elegida si sigue Pendiente, o null si no la encuentra (FirstOrDefault).
        public int? OrdenSeleccionada
        {
            get
            {
                var os = _ordenes.FirstOrDefault(o => o.Nro == _nroOsSeleccionada && o.Estado == Pendiente);
                if (os == null) return null;
                return os.Nro;
            }
        }

        // Elige la OS para mostrar su detalle. Devuelve true si sigue Pendiente
        // (Any: ¿hay alguna OS con ese N° en estado Pendiente?).
        public bool SeleccionarOrden(int nro)
        {
            if (!_ordenes.Any(o => o.Nro == nro && o.Estado == Pendiente))
                return false;

            _nroOsSeleccionada = nro;
            return true;
        }

        // Filas del detalle de la OS elegida, en el orden de recorrido del depósito: sector, posición y fila.
        // Busca la OS elegida (FirstOrDefault) y ordena sus líneas por sector, posición y fila (OrderBy y ThenBy).
        public List<LineaMercaderia> Lineas
        {
            get
            {
                var os = _ordenes.FirstOrDefault(o => o.Nro == _nroOsSeleccionada && o.Estado == Pendiente);
                if (os == null) return new List<LineaMercaderia>();

                return os.Lineas
                    .OrderBy(l => l.Posicion.Sector)
                    .ThenBy(l => l.Posicion.Posicion)
                    .ThenBy(l => l.Posicion.Fila)
                    .ToList();
            }
        }

        // Registra la entrega a Preparación: la OS pasa a Cumplida y se descuenta el stock de cada posición.
        // Las OP no cambian de estado: siguen En preparación hasta que se empaquetan.
        public bool ConfirmarEntrega(int nro)
        {
            // Busca la OS si sigue Pendiente, o null si no (FirstOrDefault).
            var os = _ordenes.FirstOrDefault(o => o.Nro == nro && o.Estado == Pendiente);
            if (os == null) return false;

            var stocks = new List<StockPosicion>();
            foreach (var linea in os.Lineas)
            {
                // Busca el stock de la posición y el SKU de la línea (FirstOrDefault).
                var stock = _stock.FirstOrDefault(s => s.Posicion.Sector == linea.Posicion.Sector
                                                    && s.Posicion.Posicion == linea.Posicion.Posicion
                                                    && s.Posicion.Fila == linea.Posicion.Fila
                                                    && s.Sku == linea.Sku);
                if (stock == null) return false;
                stocks.Add(stock);
            }

            for (int i = 0; i < os.Lineas.Count; i++)
                stocks[i].Cantidad -= os.Lineas[i].Cantidad;

            os.Estado = Cumplida;
            os.FechaHoraCumplida = DateTime.Now;
            if (_nroOsSeleccionada == nro)
                _nroOsSeleccionada = null;

            return true;
        }
    }
}
