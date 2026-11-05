using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class PrepararProductosModelo
    {
        private int? _nroOsSeleccionada;

        // Depósito del operario: el que se eligió en el menú principal.
        public string Deposito => DepositoAlmacen.IdDepositoActivo;

        // Lista del combo "Orden de selección": N° de las OS Pendientes del depósito.
        // Las ordena por número (OrderBy) y toma solo el N° (Select).
        public List<int> NrosOSPendientes
        {
            get
            {
                return OrdenesPendientes()
                    .OrderBy(o => o.NroOS)
                    .Select(o => o.NroOS)
                    .ToList();
            }
        }

        // N° de la OS elegida, para volver a marcarla en el combo; null si no hay ninguna.
        // Busca la OS elegida si sigue Pendiente, o null si no la encuentra (FirstOrDefault).
        public int? OrdenSeleccionada
        {
            get
            {
                var os = OrdenesPendientes().FirstOrDefault(o => o.NroOS == _nroOsSeleccionada);
                if (os == null) return null;
                return os.NroOS;
            }
        }

        // Elige la OS para mostrar su detalle. Devuelve true si sigue Pendiente
        // (Any: ¿hay alguna OS Pendiente con ese N°?).
        public bool SeleccionarOrden(int nro)
        {
            if (!OrdenesPendientes().Any(o => o.NroOS == nro))
                return false;

            _nroOsSeleccionada = nro;
            return true;
        }

        // Filas del detalle de la OS elegida, en el orden de recorrido del depósito: sector, posición y fila.
        // Busca la OS elegida (FirstOrDefault), la traduce a la clase de la pantalla
        // y ordena sus líneas por sector, posición y fila (OrderBy y ThenBy).
        public List<LineaOrdenSeleccion> Lineas
        {
            get
            {
                var os = OrdenesPendientes().FirstOrDefault(o => o.NroOS == _nroOsSeleccionada);
                if (os == null) return new List<LineaOrdenSeleccion>();

                return TraducirOrden(os).Lineas
                    .OrderBy(l => l.Posicion.Sector)
                    .ThenBy(l => l.Posicion.Posicion)
                    .ThenBy(l => l.Posicion.Fila)
                    .ToList();
            }
        }

        // Registra la entrega a Preparación: la OS pasa a Cumplida, se descuenta lo retirado de cada posición
        // y la mercadería pasa de comprometida a en preparación.
        // Devuelve false si la OS no está Pendiente, si alguna posición no tiene el SKU del cliente o no le alcanza,
        // o si falta la mercadería de alguna línea.
        // Las OP no cambian de estado: siguen En preparación hasta que se empaquetan.
        public bool ConfirmarEntrega(int nro)
        {
            // Busca la OS si sigue Pendiente, o null si no (FirstOrDefault).
            var os = OrdenesPendientes().FirstOrDefault(o => o.NroOS == nro);
            if (os == null) return false;

            // Se controla todo antes de cambiar nada: si alguna línea falla no se descuenta nada (Any).
            if (os.Lineas.Any(l => !AlcanzaEnPosicion(os, l) || BuscarMercaderia(os, l) == null)) return false;

            foreach (var linea in os.Lineas)
            {
                RetirarDePosicion(os, linea);
                PasarAPreparacion(os, linea);
            }

            os.Estado = EstadoOrdenSeleccionEnum.Cumplida;
            os.FechaCumplida = DateTime.Now;
            if (_nroOsSeleccionada == nro)
                _nroOsSeleccionada = null;

            return true;
        }

        // OS Pendientes del depósito (Where).
        private List<OrdenSeleccionEntidad> OrdenesPendientes()
        {
            return OrdenSeleccionAlmacen.OrdenesSeleccion
                .Where(o => o.Deposito == Deposito && o.Estado == EstadoOrdenSeleccionEnum.Pendiente)
                .ToList();
        }

        // Arma la OS que muestra la pantalla: cada línea con su posición, SKU y cantidad (Select).
        private OrdenSeleccion TraducirOrden(OrdenSeleccionEntidad os)
        {
            return new OrdenSeleccion
            {
                NroOS = os.NroOS,
                Estado = EstadoOrdenSeleccion.Pendiente,
                NrosOP = os.NrosOP.ToList(),
                FechaCumplida = os.FechaCumplida,
                Lineas = os.Lineas.Select(l => new LineaOrdenSeleccion
                {
                    Posicion = new PosicionDeposito { Sector = l.Sector, Posicion = l.Posicion, Fila = l.Fila },
                    Sku = l.Sku,
                    Cantidad = l.Cantidad
                }).ToList()
            };
        }

        // Contenido de la posición de la línea con el cliente y el SKU de la línea, o null si no hay.
        // Busca el depósito de la OS (FirstOrDefault), la posición por sector, posición y fila (FirstOrDefault)
        // y dentro de ella el cliente y el SKU (FirstOrDefault).
        private CantidadPorPosicion? BuscarEnPosicion(OrdenSeleccionEntidad os, Almacenes.LineaOrdenSeleccion linea)
        {
            var deposito = DepositoAlmacen.Depositos.FirstOrDefault(d => d.IdDeposito == os.Deposito);
            var posicion = deposito?.Posiciones.FirstOrDefault(p => p.Sector == linea.Sector && p.Posicion == linea.Posicion && p.Fila == linea.Fila);
            return posicion?.Contenido.FirstOrDefault(c => c.CuitCliente == linea.CuitCliente && c.Sku == linea.Sku);
        }

        // La posición tiene el SKU del cliente y le alcanza para lo que se retira.
        private bool AlcanzaEnPosicion(OrdenSeleccionEntidad os, Almacenes.LineaOrdenSeleccion linea)
        {
            var contenido = BuscarEnPosicion(os, linea);
            return contenido != null && contenido.Cantidad >= linea.Cantidad;
        }

        // Mercadería del cliente de la línea en el depósito de la OS con ese SKU, o null si no hay (FirstOrDefault).
        private MercaderiaEntidad? BuscarMercaderia(OrdenSeleccionEntidad os, Almacenes.LineaOrdenSeleccion linea)
        {
            return MercaderiaAlmacen.Mercaderias.FirstOrDefault(m => m.CuitCliente == linea.CuitCliente && m.Deposito == os.Deposito && m.Sku == linea.Sku);
        }

        // Descuenta de la posición lo que se retira.
        private void RetirarDePosicion(OrdenSeleccionEntidad os, Almacenes.LineaOrdenSeleccion linea)
        {
            var contenido = BuscarEnPosicion(os, linea);
            if (contenido == null) return;

            contenido.Cantidad -= linea.Cantidad;
        }

        // Resta la cantidad de lo comprometido y la suma a lo que está en preparación.
        private void PasarAPreparacion(OrdenSeleccionEntidad os, Almacenes.LineaOrdenSeleccion linea)
        {
            var mercaderia = BuscarMercaderia(os, linea);
            if (mercaderia == null) return;

            mercaderia.CantidadComprometida -= linea.Cantidad;
            mercaderia.CantidadEnPreparacion += linea.Cantidad;
        }
    }
}
