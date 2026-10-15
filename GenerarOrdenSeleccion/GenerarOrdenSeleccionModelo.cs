using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class GenerarOrdenSeleccionModelo
    {
        private const string Pendiente = "Pendiente";
        private const string EnPreparacion = "En preparación";

        private static readonly List<string> _modalidades = new List<string> { "Fulfillment", "Palet cerrado" };

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (exc. 2.1: OP ya pasadas a En preparación).
        // Fechas relativas al día de hoy para que el plan de pruebas se pueda repetir cualquier día.
        private static readonly List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion { NroOP = "101", Cliente = "Mercadito S.A.", FechaRecepcion = DateTime.Today.AddHours(9), Modalidad = "Fulfillment", Estado = Pendiente,
                Productos = new List<LineaProducto> { new LineaProducto { Sku = "CEM-50KG", Cantidad = 10 } } },
            new OrdenPreparacion { NroOP = "102", Cliente = "Mercadito S.A.", FechaRecepcion = DateTime.Today.AddHours(10.5), Modalidad = "Fulfillment", Estado = Pendiente,
                Productos = new List<LineaProducto> { new LineaProducto { Sku = "CEM-50KG", Cantidad = 5 }, new LineaProducto { Sku = "CAL-25KG", Cantidad = 3 } } },
            new OrdenPreparacion { NroOP = "103", Cliente = "MundoFOX S.R.L.", FechaRecepcion = DateTime.Today.AddDays(-1).AddHours(16), Modalidad = "Palet cerrado", Estado = Pendiente,
                Productos = new List<LineaProducto> { new LineaProducto { Sku = "ZAP-0042", Cantidad = 24 } } }
        };

        // Registro de stock del depósito. CEM-50KG está en dos posiciones (CU-02, paso 14).
        private static readonly List<PosicionStock> _stock = new List<PosicionStock>
        {
            new PosicionStock { Sku = "CEM-50KG", Posicion = "12-43-2", Cantidad = 10 },
            new PosicionStock { Sku = "CEM-50KG", Posicion = "12-44-1", Cantidad = 50 },
            new PosicionStock { Sku = "CAL-25KG", Posicion = "03-10-1", Cantidad = 50 },
            new PosicionStock { Sku = "ZAP-0042", Posicion = "12-05-1", Cantidad = 100 }
        };

        private static readonly List<OrdenSeleccion> _ordenesSeleccion = new List<OrdenSeleccion>();
        private static int _ultimoNroOS = 300;

        // Filtros aplicados con "Buscar"; al abrir, fechas en el día de hoy (CU-02, paso 2).
        private string _cliente = "";
        private DateTime? _desde = DateTime.Today;
        private DateTime? _hasta = DateTime.Today;
        private string _modalidad = "";

        // OP incluidas en la OS en armado.
        private readonly List<string> _incluidas = new List<string>();

        public string Deposito { get; private set; } = "GBA";

        public List<OrdenPreparacion> OrdenesPreparacion => _ordenesPreparacion;
        public List<PosicionStock> Stock => _stock;
        public List<OrdenSeleccion> OrdenesSeleccion => _ordenesSeleccion;

        public int CantidadIncluidas => _incluidas.Count;

        public List<string> ObtenerModalidades()
        {
            return _modalidades.ToList();
        }

        // Devuelve true si hay al menos una OP Pendiente en el depósito (CU-02, exc. 2.1).
        public bool HayOrdenesPendientes()
        {
            return OrdenesPreparacion.Any(op => op.Estado == Pendiente);
        }

        // Guarda los filtros (ya validados por el form; null = sin límite en esa fecha) y
        // devuelve true si hay OP Pendientes que los cumplen.
        public bool Filtrar(string cliente, DateTime? desde, DateTime? hasta, string modalidad, out List<OrdenPreparacion> ordenes)
        {
            _cliente = cliente;
            _desde = desde?.Date;
            _hasta = hasta?.Date;
            _modalidad = modalidad;

            ordenes = ObtenerOrdenesFiltradas();
            return ordenes.Count > 0;
        }

        // OP Pendientes que cumplen los filtros guardados, ordenadas por fecha de recepción (CU-02, paso 5).
        public List<OrdenPreparacion> ObtenerOrdenesFiltradas()
        {
            return OrdenesPreparacion
                .Where(op => op.Estado == Pendiente
                    && op.Cliente.Contains(_cliente, StringComparison.OrdinalIgnoreCase)
                    && (_desde == null || op.FechaRecepcion.Date >= _desde)
                    && (_hasta == null || op.FechaRecepcion.Date <= _hasta)
                    && (_modalidad == "" || op.Modalidad.Equals(_modalidad, StringComparison.OrdinalIgnoreCase)))
                .OrderBy(op => op.FechaRecepcion)
                .ToList();
        }

        public bool EstaIncluida(string nroOP)
        {
            return _incluidas.Contains(nroOP);
        }

        // Devuelve true si todas las OP existen y siguen Pendientes. Las que ya estaban incluidas quedan igual.
        public bool IncluirOrdenes(List<string> nrosOP)
        {
            foreach (var nro in nrosOP)
            {
                var op = OrdenesPreparacion.FirstOrDefault(o => o.NroOP == nro);
                if (op == null || op.Estado != Pendiente)
                    return false;
            }

            _incluidas.AddRange(nrosOP.Where(nro => !_incluidas.Contains(nro)));
            return true;
        }

        // Desmarca las OP incluidas de la lista; las que no estaban incluidas se ignoran (CU-02, exc. 9.2).
        public bool QuitarOrdenes(List<string> nrosOP)
        {
            _incluidas.RemoveAll(nrosOP.Contains);
            return true;
        }

        public void QuitarTodas()
        {
            _incluidas.Clear();
        }

        // Una línea por SKU con la cantidad total de las OP incluidas (CU-02, paso 8).
        public List<LineaProducto> ObtenerResumenConsolidado()
        {
            return OrdenesPreparacion
                .Where(op => _incluidas.Contains(op.NroOP))
                .SelectMany(op => op.Productos)
                .GroupBy(p => p.Sku)
                .OrderBy(g => g.Key)
                .Select(g => new LineaProducto { Sku = g.Key, Cantidad = g.Sum(p => p.Cantidad) })
                .ToList();
        }

        // Registra la OS Pendiente con el detalle por posición y pasa las OP a En preparación (CU-02, pasos 14 y 15).
        public bool GenerarOrdenSeleccion(out string nroOS)
        {
            nroOS = "";
            if (_incluidas.Count == 0) return false;

            // Si un SKU está en más de una posición, una línea por posición hasta cubrir la cantidad.
            var detalle = new List<LineaOrdenSeleccion>();
            foreach (var linea in ObtenerResumenConsolidado())
            {
                int restante = linea.Cantidad;
                foreach (var posicion in Stock.Where(s => s.Sku == linea.Sku && s.Cantidad > 0))
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

            OrdenesSeleccion.Add(new OrdenSeleccion
            {
                NroOS = nroOS,
                Deposito = Deposito,
                Fecha = DateTime.Now,
                Estado = Pendiente,
                NrosOP = _incluidas.ToList(),
                Detalle = detalle
            });

            foreach (var op in OrdenesPreparacion.Where(o => _incluidas.Contains(o.NroOP)))
                op.Estado = EnPreparacion;

            _incluidas.Clear();
            return true;
        }
    }
}
