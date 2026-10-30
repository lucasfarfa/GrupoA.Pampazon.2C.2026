using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    internal class RecepcionarOrdenEntregaModelo
    {
        private const string Preparacion = "Preparación";

        // Depósito del operario.
        private const string Deposito = "GBA";

        // Filas de "Órdenes de entrega emitidas": las OE Emitidas del depósito.
        // Filtra por depósito y estado Emitida (Where), las ordena por fecha de emisión (OrderBy y ThenBy)
        // y traduce cada una a la clase que usa la pantalla (Select).
        public List<OrdenEntrega> OrdenesEmitidas
        {
            get
            {
                return OrdenEntregaAlmacen.OrdenesEntrega
                    .Where(oe => oe.IdDeposito == Deposito && oe.Estado == EstadoOrdenEntregaEnum.Emitida)
                    .OrderBy(oe => oe.FechaEmision)
                    .ThenBy(oe => oe.NroOE)
                    .Select(oe => TraducirOrden(oe))
                    .ToList();
            }
        }

        // Confirma que Despacho recibió la OE: pasa a Pendiente de entrega y su mercadería de Preparación a Despacho.
        // Devuelve true si la OE existe, estaba Emitida y hay mercadería en Preparación para todos sus SKU.
        public bool ConfirmarRecepcion(int nroOE)
        {
            // Busca la OE Emitida del depósito con ese N°, o null si no está (FirstOrDefault).
            var oe = OrdenEntregaAlmacen.OrdenesEntrega.FirstOrDefault(o => o.NroOE == nroOE && o.IdDeposito == Deposito && o.Estado == EstadoOrdenEntregaEnum.Emitida);
            if (oe == null) return false;

            // Se controla todo antes de cambiar nada: si algo falla no queda grabado a medias (Any).
            var cantidades = CantidadesPorSku(oe);
            if (cantidades.Any(c => !HayEnPreparacion(oe, c.Sku, c.Cantidad))) return false;

            oe.Estado = EstadoOrdenEntregaEnum.PendienteDeEntrega;
            oe.FechaRecepcionDespacho = DateTime.Now;

            foreach (var cantidad in cantidades)
            {
                PasarDePreparacionADespacho(oe, cantidad.Sku, cantidad.Cantidad);
            }

            return true;
        }

        // Arma la OE que muestra la pantalla: el cliente sale del almacén de clientes,
        // y el nombre del transportista y los bultos, de las OP que lista la OE.
        private OrdenEntrega TraducirOrden(OrdenEntregaEntidad oe)
        {
            var ordenes = OrdenesDe(oe);

            return new OrdenEntrega
            {
                NroOE = oe.NroOE,
                Estado = EstadoOrdenEntrega.Emitida,
                Deposito = oe.IdDeposito,
                Cliente = BuscarCliente(oe.CuitCliente),
                // El transportista es el mismo en todas las OP de la OE: se toma de la primera (First).
                Transportista = new Transportista { DNI = oe.DNITransportista, NombreApellido = ordenes.First().NombreTransportista },
                FechaEmision = oe.FechaEmision,
                // Una línea por OP con su N° y sus bultos (Select).
                Lineas = ordenes.Select(op => new LineaOrdenEntrega { NroOP = op.NroOP, Bultos = op.Bultos }).ToList(),
                Ubicacion = Preparacion,
                FechaRecepcionDespacho = oe.FechaRecepcionDespacho
            };
        }

        // Busca el cliente por CUIT y toma su razón social (First).
        private Cliente BuscarCliente(long cuit)
        {
            var cliente = ClienteAlmacen.Clientes.First(c => c.Cuit == cuit);
            return new Cliente { Cuit = cliente.Cuit, RazonSocial = cliente.RazonSocial };
        }

        // OP que lista la OE (Where), ordenadas por N° (OrderBy).
        private List<OrdenPreparacionEntidad> OrdenesDe(OrdenEntregaEntidad oe)
        {
            return OrdenPreparacionAlmacen.OrdenesPreparacion
                .Where(op => oe.NrosOP.Contains(op.NroOP))
                .OrderBy(op => op.NroOP)
                .ToList();
        }

        // Cantidad por SKU de las OP de la OE: junta sus líneas (SelectMany), las agrupa por SKU (GroupBy)
        // y de cada grupo arma una línea con la suma de cantidades (Select y Sum).
        private List<LineaOrdenPreparacion> CantidadesPorSku(OrdenEntregaEntidad oe)
        {
            return OrdenesDe(oe)
                .SelectMany(op => op.Lineas)
                .GroupBy(l => l.Sku)
                .Select(g => new LineaOrdenPreparacion { Sku = g.Key, Cantidad = g.Sum(l => l.Cantidad) })
                .ToList();
        }

        // Mercadería del cliente de la OE en su depósito con ese SKU, o null si no hay (FirstOrDefault).
        private MercaderiaEntidad? BuscarMercaderia(OrdenEntregaEntidad oe, string sku)
        {
            return MercaderiaAlmacen.Mercaderias.FirstOrDefault(m => m.CuitCliente == oe.CuitCliente && m.Deposito == oe.IdDeposito && m.Sku == sku);
        }

        // Existe la mercadería y tiene en Preparación la cantidad que pasa a Despacho.
        private bool HayEnPreparacion(OrdenEntregaEntidad oe, string sku, int cantidad)
        {
            var mercaderia = BuscarMercaderia(oe, sku);
            return mercaderia != null && mercaderia.CantidadEnPreparacion >= cantidad;
        }

        // Resta la cantidad de Preparación y la suma a Despacho.
        private void PasarDePreparacionADespacho(OrdenEntregaEntidad oe, string sku, int cantidad)
        {
            var mercaderia = BuscarMercaderia(oe, sku);
            if (mercaderia == null) return;

            mercaderia.CantidadEnPreparacion -= cantidad;
            mercaderia.CantidadEnDespacho += cantidad;
        }
    }
}
