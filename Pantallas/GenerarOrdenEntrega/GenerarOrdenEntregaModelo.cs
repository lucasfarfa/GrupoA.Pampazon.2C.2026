using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    internal class GenerarOrdenEntregaModelo
    {
        // Depósito del operario: el que se eligió en el menú principal.
        private string Deposito => DepositoAlmacen.IdDepositoActivo;

        // Filas de "Órdenes preparadas sin orden de entrega": un grupo por cliente, transportista y fecha de retiro.
        // Agrupa las OP Preparadas sin OE por esa clave (GroupBy; el cliente por CUIT y el transportista por DNI); de cada
        // grupo toma los datos de la primera OP y cuenta cuántas tiene (Select, First y Count), y los ordena por nombre
        // del cliente y fecha de retiro (OrderBy y ThenBy).
        public List<GrupoOrdenes> Grupos
        {
            get
            {
                return OrdenesSinOE()
                    .GroupBy(op => new { op.Cliente.Cuit, op.Transportista.DNI, op.FechaRetiro })
                    .Select(g => new GrupoOrdenes
                    {
                        Cliente = g.First().Cliente,
                        Transportista = g.First().Transportista,
                        FechaRetiro = g.First().FechaRetiro,
                        CantidadOP = g.Count()
                    })
                    .OrderBy(g => g.Cliente.RazonSocial)
                    .ThenBy(g => g.FechaRetiro)
                    .ToList();
            }
        }

        // Genera la OE: la registra Emitida con las OP del grupo (CUIT del cliente, DNI del transportista y fecha de retiro) y las pasa a En entrega.
        // Devuelve true si el grupo todavía tiene OP Preparadas sin OE.
        public bool GenerarOrdenEntrega(long cuitCliente, int dniTransportista, DateTime fechaRetiro, out int nroOE)
        {
            nroOE = 0;
            // OP del grupo (Where), ordenadas por N° (OrderBy).
            var ordenes = OrdenesSinOE()
                .Where(op => op.Cliente.Cuit == cuitCliente && op.Transportista.DNI == dniTransportista && op.FechaRetiro == fechaRetiro)
                .OrderBy(op => op.NroOP)
                .ToList();
            if (ordenes.Count == 0) return false;

            // Cliente, transportista y fecha de retiro son iguales en todo el grupo: se toman de la primera OP (First).
            var primera = ordenes.First();
            var orden = new OrdenEntrega
            {
                NroOE = ProximoNroOE(),
                Estado = EstadoOrdenEntrega.Emitida,
                Deposito = Deposito,
                FechaEmision = DateTime.Now,
                Cliente = primera.Cliente,
                Transportista = primera.Transportista,
                FechaRetiro = primera.FechaRetiro,
                // Una línea por OP con su N° y sus bultos (Select).
                Lineas = ordenes.Select(op => new LineaOrdenEntrega { NroOP = op.NroOP, Bultos = op.Bultos }).ToList()
            };

            OrdenEntregaAlmacen.OrdenesEntrega.Add(TraducirOrdenEntrega(orden));

            // Pasa a En entrega en el almacén las OP de la OE (Where).
            foreach (var op in OrdenPreparacionAlmacen.OrdenesPreparacion.Where(o => ordenes.Any(op => op.NroOP == o.NroOP)))
            {
                op.Estado = EstadoOrdenPreparacionEnum.EnEntrega;
            }

            nroOE = orden.NroOE;
            return true;
        }

        // OP Preparadas del depósito que todavía no están en ninguna OE (Where), traducidas a la clase que usa la pantalla (Select).
        private List<OrdenPreparacion> OrdenesSinOE()
        {
            return OrdenPreparacionAlmacen.OrdenesPreparacion
                .Where(op => op.Deposito == Deposito && op.Estado == EstadoOrdenPreparacionEnum.Preparada && BuscarOrdenEntrega(op.NroOP) == null)
                .Select(op => TraducirOrden(op))
                .ToList();
        }

        // OE que incluye la OP con ese N°, o null si no está en ninguna (FirstOrDefault).
        private OrdenEntregaEntidad? BuscarOrdenEntrega(int nroOP)
        {
            return OrdenEntregaAlmacen.OrdenesEntrega.FirstOrDefault(oe => oe.NrosOP.Contains(nroOP));
        }

        // Arma la OP que usa la pantalla: el cliente sale del almacén de clientes y el transportista, de los datos de la OP.
        // Solo se traducen OP Preparadas.
        private OrdenPreparacion TraducirOrden(OrdenPreparacionEntidad op)
        {
            return new OrdenPreparacion
            {
                NroOP = op.NroOP,
                Deposito = op.Deposito,
                Cliente = BuscarCliente(op.CuitCliente),
                Transportista = new Transportista { DNI = op.DNITransportista, NombreApellido = op.NombreTransportista },
                FechaRetiro = op.FechaRetiro,
                Bultos = op.Bultos,
                Estado = EstadoOrdenPreparacion.Preparada,
                NroOE = BuscarOrdenEntrega(op.NroOP)?.NroOE
            };
        }

        // Arma la OE que se graba en el almacén a partir de la OE armada en la pantalla:
        // del cliente y del transportista guarda solo sus claves, y de las líneas, el N° de cada OP (Select).
        // La fecha de retiro del grupo es la fecha de entrega al transportista.
        private OrdenEntregaEntidad TraducirOrdenEntrega(OrdenEntrega orden)
        {
            return new OrdenEntregaEntidad
            {
                NroOE = orden.NroOE,
                FechaEmision = orden.FechaEmision,
                Estado = TraducirEstado(orden.Estado),
                NrosOP = orden.Lineas.Select(l => l.NroOP).ToList(),
                IdDeposito = orden.Deposito,
                CuitCliente = orden.Cliente.Cuit,
                DNITransportista = orden.Transportista.DNI,
                FechaEntregaTransportista = orden.FechaRetiro
            };
        }

        // Busca el cliente por CUIT y toma su razón social (First).
        private Cliente BuscarCliente(long cuit)
        {
            var cliente = ClienteAlmacen.Clientes.First(c => c.Cuit == cuit);
            return new Cliente { Cuit = cliente.Cuit, RazonSocial = cliente.RazonSocial };
        }

        // Pasa el estado de la OE de la pantalla al del almacén (en el almacén, Pendiente de entrega se llama PendienteDeEntrega).
        private EstadoOrdenEntregaEnum TraducirEstado(EstadoOrdenEntrega estado)
        {
            return estado == EstadoOrdenEntrega.PendienteEntrega ? EstadoOrdenEntregaEnum.PendienteDeEntrega : EstadoOrdenEntregaEnum.Emitida;
        }

        // El N° de OE es correlativo: el mayor del almacén más uno (Max), o 1 si no hay ninguna (DefaultIfEmpty).
        private int ProximoNroOE()
        {
            return OrdenEntregaAlmacen.OrdenesEntrega.Select(oe => oe.NroOE).DefaultIfEmpty(0).Max() + 1;
        }
    }
}
