namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class PrepararProductosModelo
    {
        private const string Pendiente = "Pendiente";
        private const string Cumplida = "Cumplida";

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (OS Cumplida, prueba C.2).
        private static readonly List<OrdenSeleccion> _ordenes = new List<OrdenSeleccion>
        {
            new OrdenSeleccion
            {
                Nro = "501",
                Estado = Pendiente,
                OrdenesPreparacion = "101, 102",
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
                OrdenesPreparacion = "103",
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

        // CU-03, 2. OS Pendientes del depósito, por número.
        public List<string> ObtenerOrdenesPendientes()
        {
            return _ordenes
                .Where(o => o.Estado == Pendiente)
                .OrderBy(o => int.Parse(o.Nro))
                .Select(o => o.Nro)
                .ToList();
        }

        public bool ObtenerOrdenSeleccionada(out string nro)
        {
            var os = _ordenes.FirstOrDefault(o => o.Nro == _nroOsSeleccionada && o.Estado == Pendiente);
            if (os == null)
            {
                nro = "";
                return false;
            }

            nro = os.Nro;
            return true;
        }

        // CU-03, 3. Deja elegida la OS si sigue Pendiente.
        public bool SeleccionarOrden(string nro)
        {
            if (!_ordenes.Any(o => o.Nro == nro && o.Estado == Pendiente))
                return false;

            _nroOsSeleccionada = nro;
            return true;
        }

        // CU-03, 4 y 5. Líneas de la OS elegida, ordenadas por sector, posición y fila.
        public List<LineaMercaderia> ObtenerLineas()
        {
            var os = _ordenes.FirstOrDefault(o => o.Nro == _nroOsSeleccionada && o.Estado == Pendiente);
            if (os == null) return new List<LineaMercaderia>();

            return os.Lineas
                .OrderBy(l => ClaveRecorrido(l.Posicion))
                .ToList();
        }

        // CU-03, 11 y 12. La OS pasa a Cumplida y se descuenta el stock de cada posición.
        // Las OP no cambian de estado: siguen En preparación hasta CU-04.
        public bool ConfirmarEntrega(string nro)
        {
            var os = _ordenes.FirstOrDefault(o => o.Nro == nro && o.Estado == Pendiente);
            if (os == null) return false;

            var stocks = new List<StockPosicion>();
            foreach (var linea in os.Lineas)
            {
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
