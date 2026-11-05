using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
        private OrdenPreparacion? _ordenAsignada;   // OP asignada al puesto (CU-04, paso 2)

        // Depósito del operario: el que se eligió en el menú principal.
        private string Deposito => DepositoAlmacen.IdDepositoActivo;

        public bool HayOrdenAsignada => _ordenAsignada != null;

        public int NroOPAsignada
        {
            get
            {
                if (_ordenAsignada == null) return 0;
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
                if (_ordenAsignada.Modalidad == Modalidad.PaletCerrado) return 1;
                return _ordenAsignada.Lineas.Sum(p => p.Cantidad);
            }
        }

        // Asigna al puesto la próxima OP a empaquetar y la marca como tomada; devuelve false si no hay ninguna.
        // Filtra las OP del depósito En preparación, no tomadas por otro puesto, cuya OS esté Cumplida (Where),
        // las ordena de la más vieja a la más nueva por fecha de recepción (OrderBy, FIFO), toma la primera,
        // o null si no queda ninguna (FirstOrDefault), y la traduce a la clase que usa la pantalla.
        public bool AsignarSiguienteOrden(out OrdenPreparacion? orden)
        {
            orden = null;
            var op = OrdenPreparacionAlmacen.OrdenesPreparacion
                .Where(o => o.Deposito == Deposito
                         && o.Estado == EstadoOrdenPreparacionEnum.EnPreparacion
                         && !o.TomadaPreparacion
                         && BuscarOrdenSeleccion(o.NroOP)?.Estado == EstadoOrdenSeleccionEnum.Cumplida)
                .OrderBy(o => o.FechaRecepcion)
                .FirstOrDefault();

            if (op != null)
            {
                op.TomadaPreparacion = true;
                orden = TraducirOrden(op);
            }

            _ordenAsignada = orden;
            return orden != null;
        }

        public List<LineaOrdenPreparacion> Lineas
        {
            get
            {
                if (_ordenAsignada == null) return new List<LineaOrdenPreparacion>();
                return _ordenAsignada.Lineas.ToList();
            }
        }

        // Registra la OP asignada como Preparada con sus bultos, fecha y hora (CU-04, paso 8).
        public bool ConfirmarEmpaquetado(out int nroOP)
        {
            nroOP = 0;
            if (_ordenAsignada == null || _ordenAsignada.Estado != EstadoOrdenPreparacion.EnPreparacion) return false;

            // Busca en el almacén la OP asignada si sigue En preparación, o null si no (FirstOrDefault).
            var op = OrdenPreparacionAlmacen.OrdenesPreparacion
                .FirstOrDefault(o => o.NroOP == _ordenAsignada.NroOP && o.Estado == EstadoOrdenPreparacionEnum.EnPreparacion);
            if (op == null) return false;

            _ordenAsignada.Bultos = TotalBultos;
            _ordenAsignada.FechaEmpaquetado = DateTime.Now;
            _ordenAsignada.Estado = EstadoOrdenPreparacion.Preparada;

            op.Bultos = _ordenAsignada.Bultos;
            op.FechaEmpaquetado = _ordenAsignada.FechaEmpaquetado;
            op.Estado = EstadoOrdenPreparacionEnum.Preparada;

            nroOP = _ordenAsignada.NroOP;
            _ordenAsignada = null;
            return true;
        }

        // Libera la OP asignada al puesto sin empaquetarla: deja de estar tomada y vuelve a quedar disponible
        // para la próxima asignación. Sigue En preparación (CU-04, cancelar).
        // Devuelve true si había una OP asignada y sigue En preparación en el almacén.
        public bool LiberarOrdenAsignada()
        {
            if (_ordenAsignada == null) return false;

            // Busca en el almacén la OP asignada si sigue En preparación, o null si no (FirstOrDefault).
            var op = OrdenPreparacionAlmacen.OrdenesPreparacion
                .FirstOrDefault(o => o.NroOP == _ordenAsignada.NroOP && o.Estado == EstadoOrdenPreparacionEnum.EnPreparacion);
            if (op == null) return false;

            op.TomadaPreparacion = false;
            _ordenAsignada = null;
            return true;
        }

        // OS que incluye la OP con ese N°, o null si no está en ninguna (FirstOrDefault).
        private OrdenSeleccionEntidad? BuscarOrdenSeleccion(int nroOP)
        {
            return OrdenSeleccionAlmacen.OrdenesSeleccion.FirstOrDefault(os => os.NrosOP.Contains(nroOP));
        }

        // Arma la OP que muestra la pantalla: el N° de OS sale de la OS que la incluye,
        // y la descripción de cada producto, de la mercadería del cliente en el depósito (Select).
        private OrdenPreparacion TraducirOrden(OrdenPreparacionEntidad op)
        {
            return new OrdenPreparacion
            {
                NroOP = op.NroOP,
                FechaRecepcion = op.FechaRecepcion,
                Modalidad = TraducirModalidad(op.Modalidad),
                NroOS = BuscarOrdenSeleccion(op.NroOP)?.NroOS ?? 0,
                Estado = EstadoOrdenPreparacion.EnPreparacion,
                Lineas = op.Lineas.Select(l => new LineaOrdenPreparacion { Sku = l.Sku, Descripcion = BuscarDescripcion(op, l.Sku), Cantidad = l.Cantidad }).ToList(),
                Bultos = op.Bultos,
                FechaEmpaquetado = op.FechaEmpaquetado
            };
        }

        // Descripción de la mercadería del cliente de la OP en su depósito con ese SKU (FirstOrDefault); "" si no hay.
        private string BuscarDescripcion(OrdenPreparacionEntidad op, string sku)
        {
            var mercaderia = MercaderiaAlmacen.Mercaderias.FirstOrDefault(m => m.CuitCliente == op.CuitCliente && m.Deposito == op.Deposito && m.Sku == sku);
            return mercaderia?.Descripcion ?? "";
        }

        // Pasa la modalidad del almacén a la de la pantalla (tienen los mismos valores).
        private Modalidad TraducirModalidad(ModalidadEnum modalidad)
        {
            return modalidad == ModalidadEnum.PaletCerrado ? Modalidad.PaletCerrado : Modalidad.Fulfillment;
        }
    }
}
