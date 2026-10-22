namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class PrepararProductosModelo
    {
        private const string Pendiente = "Pendiente";
        private const string Cumplida = "Cumplida";

        private static readonly List<OrdenSeleccion> _ordenes = new List<OrdenSeleccion>
        {
            new OrdenSeleccion
            {
                Nro = "501",
                Estado = Pendiente,
                NrosOP = new List<string> { "101", "102" },
                Lineas =
                {
                    new LineaMercaderia { Posicion = "12-43-2", Sku = "CEM-50KG", Cantidad = 10 },
                    new LineaMercaderia { Posicion = "12-44-1", Sku = "CEM-50KG", Cantidad = 5 },
                    new LineaMercaderia { Posicion = "03-10-1", Sku = "CAL-25KG", Cantidad = 3 }
                }
            },
            new OrdenSeleccion
            {
                Nro = "502",
                Estado = Pendiente,
                NrosOP = new List<string> { "103" },
                Lineas =
                {
                    new LineaMercaderia { Posicion = "12-05-1", Sku = "ZAP-0042", Cantidad = 24 }
                }
            }
        };

        private static readonly List<StockPosicion> _stock = new List<StockPosicion>
        {
            new StockPosicion { Sku = "CEM-50KG", Posicion = "12-43-2", Cantidad = 10 },
            new StockPosicion { Sku = "CEM-50KG", Posicion = "12-44-1", Cantidad = 50 },
            new StockPosicion { Sku = "CAL-25KG", Posicion = "03-10-1", Cantidad = 50 },
            new StockPosicion { Sku = "ZAP-0042", Posicion = "12-05-1", Cantidad = 100 }
        };

        private string? _nroOsSeleccionada;

        public string Deposito => "GBA";

        // Lista del combo "Orden de selección": N° de las OS Pendientes del depósito.
        // Filtra las Pendientes (Where), las ordena por número (OrderBy) y toma solo el N° (Select).
        public List<string> OrdenesPendientes
        {
            get
            {
                return _ordenes
                    .Where(o => o.Estado == Pendiente)
                    .OrderBy(o => int.Parse(o.Nro))
                    .Select(o => o.Nro)
                    .ToList();
            }
        }

        // N° de la OS elegida, para volver a marcarla en el combo; "" si no hay ninguna.
        // Busca la OS elegida si sigue Pendiente, o null si no la encuentra (FirstOrDefault).
        public string OrdenSeleccionada
        {
            get
            {
                var os = _ordenes.FirstOrDefault(o => o.Nro == _nroOsSeleccionada && o.Estado == Pendiente);
                if (os == null) return "";
                return os.Nro;
            }
        }

        // Elige la OS para mostrar su detalle. Devuelve true si sigue Pendiente
        // (Any: ¿hay alguna OS con ese N° en estado Pendiente?).
        public bool SeleccionarOrden(string nro)
        {
            if (!_ordenes.Any(o => o.Nro == nro && o.Estado == Pendiente))
                return false;

            _nroOsSeleccionada = nro;
            return true;
        }

        // Filas del detalle de la OS elegida, en el orden de recorrido del depósito: sector, posición y fila.
        // Busca la OS elegida (FirstOrDefault) y ordena sus líneas por la posición X-Y-Z (OrderBy con ClaveRecorrido).
        public List<LineaMercaderia> Lineas
        {
            get
            {
                var os = _ordenes.FirstOrDefault(o => o.Nro == _nroOsSeleccionada && o.Estado == Pendiente);
                if (os == null) return new List<LineaMercaderia>();

                return os.Lineas
                    .OrderBy(l => ClaveRecorrido(l.Posicion))
                    .ToList();
            }
        }

        // Registra la entrega a Preparación: la OS pasa a Cumplida y se descuenta el stock de cada posición.
        // Las OP no cambian de estado: siguen En preparación hasta que se empaquetan.
        public bool ConfirmarEntrega(string nro)
        {
            // Busca la OS si sigue Pendiente, o null si no (FirstOrDefault).
            var os = _ordenes.FirstOrDefault(o => o.Nro == nro && o.Estado == Pendiente);
            if (os == null) return false;

            var stocks = new List<StockPosicion>();
            foreach (var linea in os.Lineas)
            {
                // Busca el stock de la posición y el SKU de la línea (FirstOrDefault).
                var stock = _stock.FirstOrDefault(s => s.Posicion == linea.Posicion && s.Sku == linea.Sku);
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

        // Posición X-Y-Z: sector, posición, fila.
        private static (int Sector, int Posicion, int Fila) ClaveRecorrido(string posicion)
        {
            string[] partes = posicion.Split('-');
            return (int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]));
        }
    }
}
