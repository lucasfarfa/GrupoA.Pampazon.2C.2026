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

        private List<OrdenSeleccion> _ordenesSeleccion = new List<OrdenSeleccion>
        {
            new OrdenSeleccion { NroOS = "501", Estado = Cumplida },
            new OrdenSeleccion { NroOS = "503", Estado = Pendiente }
        };

        private List<OrdenPreparacion> _ordenesPreparacion = new List<OrdenPreparacion>
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

        public string NroOPAsignada
        {
            get
            {
                if (_ordenAsignada == null) return "";
                return _ordenAsignada.NroOP;
            }
        }

        // Total de bultos a mostrar. Palet cerrado: un bulto (el palet).
        // Fulfillment: un bulto por unidad, o sea la suma de las cantidades de los productos (Sum).
        public int TotalBultos
        {
            get
            {
                if (_ordenAsignada == null) return 0;
                if (_ordenAsignada.Modalidad == PaletCerrado) return 1;
                return _ordenAsignada.Productos.Sum(p => p.Cantidad);
            }
        }

        // Asigna al puesto la próxima OP a empaquetar; devuelve false si no hay ninguna.
        // Filtra las OP En preparación cuya OS esté Cumplida (Where + Any), las ordena de la más vieja a la más nueva
        // por fecha de recepción (OrderBy, FIFO) y toma la primera, o null si no queda ninguna (FirstOrDefault).
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

        public List<ProductoOrden> ProductosAsignados
        {
            get
            {
                if (_ordenAsignada == null) return new List<ProductoOrden>();
                return _ordenAsignada.Productos.ToList();
            }
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
