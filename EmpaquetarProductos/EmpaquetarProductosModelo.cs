namespace GrupoA.PampazonSA.AdministracionDeposito.CU04EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
        private const string EnPreparacion = "En preparación";
        private const string Preparada = "Preparada";
        private const string Cumplida = "Cumplida";
        private const string Pendiente = "Pendiente";
        private const string PaletCerrado = "Palet cerrado";
        private const string Fulfillment = "Fulfillment";

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (prueba D.6).
        private static readonly List<OrdenSeleccion> _ordenesSeleccion = new List<OrdenSeleccion>
        {
            new OrdenSeleccion { NroOS = "501", Estado = Cumplida },
            new OrdenSeleccion { NroOS = "503", Estado = Pendiente }
        };

        private static readonly List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
        {
            new OrdenPreparacion
            {
                NroOP = "101", FechaRecepcion = new DateTime(2026, 10, 14, 9, 0, 0), Modalidad = Fulfillment, NroOS = "501", Estado = EnPreparacion,
                Productos = new List<ProductoOrden>
                {
                    new ProductoOrden { Sku = "CEM-50KG", Descripcion = "Bolsa de cemento 50 kg", Cantidad = 10 }
                }
            },
            new OrdenPreparacion
            {
                NroOP = "102", FechaRecepcion = new DateTime(2026, 10, 14, 10, 30, 0), Modalidad = Fulfillment, NroOS = "501", Estado = EnPreparacion,
                Productos = new List<ProductoOrden>
                {
                    new ProductoOrden { Sku = "CEM-50KG", Descripcion = "Bolsa de cemento 50 kg", Cantidad = 5 },
                    new ProductoOrden { Sku = "CAL-25KG", Descripcion = "Bolsa de cal 25 kg", Cantidad = 3 }
                }
            },
            new OrdenPreparacion
            {
                NroOP = "108", FechaRecepcion = new DateTime(2026, 10, 14, 12, 0, 0), Modalidad = Fulfillment, NroOS = "503", Estado = EnPreparacion,
                Productos = new List<ProductoOrden>
                {
                    new ProductoOrden { Sku = "CAL-25KG", Descripcion = "Bolsa de cal 25 kg", Cantidad = 20 }
                }
            }
        };

        private OrdenPreparacion? _ordenAsignada;   // OP asignada al puesto (CU-04, paso 2)

        public bool HayOrdenAsignada => _ordenAsignada != null;

        public string NroOPAsignada => _ordenAsignada?.NroOP ?? "";

        // Palet cerrado: un bulto (el palet). Fulfillment: un bulto por unidad (CU-04, paso 3).
        public int TotalBultos
        {
            get
            {
                if (_ordenAsignada == null) return 0;
                if (_ordenAsignada.Modalidad == PaletCerrado) return 1;
                return _ordenAsignada.Productos.Sum(p => p.Cantidad);
            }
        }

        // Asigna la OP más antigua por fecha de recepción (FIFO) En preparación y con su OS Cumplida (CU-04, paso 2).
        // Devuelve false si no hay ninguna (CU-04, exc. 2.1).
        public bool AsignarSiguienteOrden(out OrdenPreparacion? orden)
        {
            orden = _ordenesPreparacion
                .Where(op => op.Estado == EnPreparacion
                          && _ordenesSeleccion.Any(os => os.NroOS == op.NroOS && os.Estado == Cumplida))
                .OrderBy(op => op.FechaRecepcion)
                .FirstOrDefault();
            _ordenAsignada = orden;
            return orden != null;
        }

        public List<ProductoOrden> ObtenerProductosAsignados()
        {
            return _ordenAsignada?.Productos.ToList() ?? new List<ProductoOrden>();
        }

        // Registra la OP asignada como Preparada con sus bultos, fecha y hora (CU-04, paso 8).
        public bool ConfirmarEmpaquetado(out string nroOP)
        {
            nroOP = "";
            if (_ordenAsignada == null || _ordenAsignada.Estado != EnPreparacion) return false;

            _ordenAsignada.Bultos = TotalBultos;
            _ordenAsignada.FechaEmpaquetado = DateTime.Now;
            _ordenAsignada.Estado = Preparada;
            nroOP = _ordenAsignada.NroOP;
            _ordenAsignada = null;
            return true;
        }
    }
}
