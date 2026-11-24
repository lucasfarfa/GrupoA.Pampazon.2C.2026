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

        // Total de bultos a mostrar.
        // Palet cerrado: cada palet sale tal como entró, así que es un bulto por palet: suma de cantidad / unidades por palet (Sum).
        // Fulfillment: cada producto se embala en cajas: suma de cantidad / unidades por bulto redondeado hacia arriba (Sum).
        // Si la mercadería no tiene definido el palet o la caja (0), cada unidad cuenta como un bulto.
        public int TotalBultos
        {
            get
            {
                if (_ordenAsignada == null) return 0;
                if (_ordenAsignada.Modalidad == Modalidad.PaletCerrado)
                    return _ordenAsignada.Lineas.Sum(p => p.Cantidad / Math.Max(1, p.UnidadesPorPalet));
                return _ordenAsignada.Lineas.Sum(p => (int)Math.Ceiling((double)p.Cantidad / Math.Max(1, p.UnidadesPorBulto)));
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
        // y la descripción y el embalaje (unidades por caja y por palet) de cada producto,
        // de la mercadería del cliente en el depósito (Select).
        private OrdenPreparacion TraducirOrden(OrdenPreparacionEntidad op)
        {
            return new OrdenPreparacion
            {
                NroOP = op.NroOP,
                FechaRecepcion = op.FechaRecepcion,
                Modalidad = TraducirModalidad(op.Modalidad),
                NroOS = BuscarOrdenSeleccion(op.NroOP)?.NroOS ?? 0,
                Estado = EstadoOrdenPreparacion.EnPreparacion,
                Lineas = op.Lineas.Select(l => TraducirLinea(op, l)).ToList(),
                Bultos = op.Bultos,
                FechaEmpaquetado = op.FechaEmpaquetado
            };
        }

        // Arma la línea que muestra la pantalla con los datos de la mercadería; sin mercadería, descripción vacía y embalaje 0.
        private LineaOrdenPreparacion TraducirLinea(OrdenPreparacionEntidad op, Almacenes.LineaOrdenPreparacion linea)
        {
            var mercaderia = BuscarMercaderia(op, linea.Sku);
            return new LineaOrdenPreparacion
            {
                Sku = linea.Sku,
                Descripcion = mercaderia?.Descripcion ?? "",
                Cantidad = linea.Cantidad,
                UnidadesPorBulto = mercaderia?.UnidadesPorBulto ?? 0,
                UnidadesPorPalet = mercaderia?.UnidadesPorPalet ?? 0
            };
        }

        // Mercadería del cliente de la OP en su depósito con ese SKU, o null si no hay (FirstOrDefault).
        private MercaderiaEntidad? BuscarMercaderia(OrdenPreparacionEntidad op, string sku)
        {
            return MercaderiaAlmacen.Mercaderias.FirstOrDefault(m => m.CuitCliente == op.CuitCliente && m.Deposito == op.Deposito && m.Sku == sku);
        }

        // Pasa la modalidad del almacén a la de la pantalla (tienen los mismos valores).
        private Modalidad TraducirModalidad(ModalidadEnum modalidad)
        {
            return modalidad == ModalidadEnum.PaletCerrado ? Modalidad.PaletCerrado : Modalidad.Fulfillment;
        }
    }
}
