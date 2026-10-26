namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class GenerarRemitoDespacharModelo
    {
        private List<Transportista> _transportistas = new List<Transportista>
        {
            new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" },
            new Transportista { DNI = 20562667, NombreApellido = "Alejo Cisterna" },
            new Transportista { DNI = 32321987, NombreApellido = "Daniel Baez" }
        };

        private List<OrdenEntrega> _ordenesEntrega = new List<OrdenEntrega>
        {
            new OrdenEntrega { NroOE = 701, Cliente = "Mercadito S.A.", Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 101, Bultos = 10 }, new LineaOrdenEntrega { NroOP = 102, Bultos = 8 } }, Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, Estado = EstadoOrdenEntrega.PendienteEntrega },
            new OrdenEntrega { NroOE = 704, Cliente = "Mercadito S.A.", Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 105, Bultos = 10 } }, Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, Estado = EstadoOrdenEntrega.PendienteEntrega },
            new OrdenEntrega { NroOE = 702, Cliente = "MundoFOX S.R.L.", Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 103, Bultos = 1 } }, Transportista = new Transportista { DNI = 24568779, NombreApellido = "Jose Gomez" }, Estado = EstadoOrdenEntrega.PendienteEntrega },
            new OrdenEntrega { NroOE = 710, Cliente = "MundoFOX S.R.L.", Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 110, Bultos = 1 } }, Transportista = new Transportista { DNI = 20562667, NombreApellido = "Alejo Cisterna" }, Estado = EstadoOrdenEntrega.RemitoEmitido },
            new OrdenEntrega { NroOE = 703, Cliente = "Ferretería Norte S.A.", Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 104, Bultos = 30 } }, Transportista = new Transportista { DNI = 32321987, NombreApellido = "Daniel Baez" }, Estado = EstadoOrdenEntrega.PendienteEntrega },
            new OrdenEntrega { NroOE = 705, Cliente = "Construcciones del Plata S.R.L.", Lineas = new List<LineaOrdenEntrega> { new LineaOrdenEntrega { NroOP = 106, Bultos = 5 }, new LineaOrdenEntrega { NroOP = 107, Bultos = 4 } }, Transportista = new Transportista { DNI = 32321987, NombreApellido = "Daniel Baez" }, Estado = EstadoOrdenEntrega.PendienteEntrega }
        };

        private List<Remito> _remitos = new List<Remito>
        {
            new Remito { NroRemito = 410, Fecha = DateTime.Today.AddDays(-1), Cliente = "MundoFOX S.R.L.", Transportista = new Transportista { DNI = 20562667, NombreApellido = "Alejo Cisterna" }, NrosOE = new List<int> { 710 }, NrosOP = new List<int> { 110 }, TotalBultos = 1, Estado = EstadoRemito.Emitido }
        };

        // OP que pasaron a Despachada al confirmar la entrega.
        private List<int> _opsDespachadas = new List<int>();
        private int _ultimoNroRemito = 410;

        private Transportista? _transportista;   // transportista identificado con "Buscar órdenes"
        private List<int> _seleccionadas = new List<int>();

        public bool HaySeleccion => _seleccionadas.Count > 0;

        // Un DNI tiene 7 u 8 dígitos.
        public bool DniValido(int dni)
        {
            return dni >= 1_000_000 && dni <= 99_999_999;
        }

        // Hay al menos una OE elegida.
        public bool HayOrdenes(List<int> nrosOE)
        {
            return nrosOE.Count > 0;
        }

        // Hay al menos un remito elegido.
        public bool HayRemitos(List<int> nrosRemito)
        {
            return nrosRemito.Count > 0;
        }

        // Identifica al transportista para cargar sus documentos. Devuelve true si el DNI es válido y existe un transportista con él.
        public bool BuscarTransportista(int dni, out Transportista? transportista)
        {
            transportista = null;
            if (!DniValido(dni)) return false;

            // Busca el transportista con ese DNI, o null si no hay ninguno (FirstOrDefault).
            transportista = _transportistas.FirstOrDefault(t => t.DNI == dni);
            _transportista = transportista;
            return transportista != null;
        }

        // Filas de "Órdenes de entrega pendientes": las del transportista buscado que todavía no se eligieron.
        // Filtra por transportista, estado Pendiente de entrega y no seleccionadas (Where)
        // y ordena por cliente y después por N° de OE (OrderBy y ThenBy).
        public List<OrdenEntrega> OrdenesPendientes
        {
            get
            {
                return _ordenesEntrega
                    .Where(oe => oe.Transportista.DNI == _transportista?.DNI && oe.Estado == EstadoOrdenEntrega.PendienteEntrega && !_seleccionadas.Contains(oe.NroOE))
                    .OrderBy(oe => oe.Cliente)
                    .ThenBy(oe => oe.NroOE)
                    .ToList();
            }
        }

        // Descarta el transportista identificado y la selección (nueva búsqueda).
        public bool LimpiarBusqueda()
        {
            _transportista = null;
            _seleccionadas.Clear();
            return true;
        }

        // Pasa las OE elegidas a "Se emitirán los siguientes remitos".
        // Devuelve true si hay al menos una OE y todas existen, siguen pendientes y no estaban seleccionadas.
        public bool SeleccionarOrdenes(List<int> nrosOE)
        {
            if (!HayOrdenes(nrosOE)) return false;

            foreach (var nro in nrosOE)
            {
                // Busca la OE con ese número, o null si no existe (FirstOrDefault).
                var oe = _ordenesEntrega.FirstOrDefault(o => o.NroOE == nro);
                if (oe == null || oe.Estado != EstadoOrdenEntrega.PendienteEntrega || _seleccionadas.Contains(nro))
                    return false;
            }

            _seleccionadas.AddRange(nrosOE);
            return true;
        }

        // Devuelve las OE elegidas a "Órdenes de entrega pendientes". Devuelve true si hay al menos una y todas estaban seleccionadas.
        public bool DeseleccionarOrdenes(List<int> nrosOE)
        {
            if (!HayOrdenes(nrosOE)) return false;

            // Si alguna OE de la lista no está seleccionada (Any), no se deselecciona nada.
            if (nrosOE.Any(nro => !_seleccionadas.Contains(nro)))
                return false;

            // Saca de la selección cada N° que esté en nrosOE; es lo mismo que RemoveAll(nro => nrosOE.Contains(nro)).
            _seleccionadas.RemoveAll(nrosOE.Contains);
            return true;
        }

        // Filas de "Se emitirán los siguientes remitos": un remito por cliente con sus OE seleccionadas.
        // Toma las OE seleccionadas (Where), las agrupa por cliente (GroupBy), ordena los grupos por cliente (OrderBy)
        // y de cada grupo arma un remito con el cliente y sus N° de OE ordenados (Select).
        public List<RemitoAEmitir> RemitosAEmitir
        {
            get
            {
                return _ordenesEntrega
                    .Where(oe => _seleccionadas.Contains(oe.NroOE))
                    .GroupBy(oe => oe.Cliente)
                    .OrderBy(g => g.Key)
                    .Select(g => new RemitoAEmitir
                    {
                        Cliente = g.Key,
                        NrosOE = g.Select(oe => oe.NroOE).OrderBy(n => n).ToList()
                    })
                    .ToList();
            }
        }

        // Emite los remitos: genera uno Emitido por cliente y pasa sus OE a Remito emitido.
        public bool EmitirRemitos()
        {
            if (_seleccionadas.Count == 0 || _transportista == null) return false;

            // Agrupa las OE seleccionadas (Where) por cliente (GroupBy), ordenadas por cliente (OrderBy): cada grupo es un remito.
            var porCliente = _ordenesEntrega
                .Where(oe => _seleccionadas.Contains(oe.NroOE))
                .GroupBy(oe => oe.Cliente)
                .OrderBy(g => g.Key);

            foreach (var grupo in porCliente)
            {
                _ultimoNroRemito++;

                _remitos.Add(new Remito
                {
                    NroRemito = _ultimoNroRemito,
                    Fecha = DateTime.Now,
                    Cliente = grupo.Key,
                    Transportista = _transportista,
                    // Lista con el N° de cada OE del grupo (Select), lista con las OP de todas las líneas de esas OE
                    // (SelectMany) y suma de los bultos de esas líneas (Sum).
                    NrosOE = grupo.Select(oe => oe.NroOE).ToList(),
                    NrosOP = grupo.SelectMany(oe => oe.Lineas).Select(l => l.NroOP).ToList(),
                    TotalBultos = grupo.SelectMany(oe => oe.Lineas).Sum(l => l.Bultos),
                    Estado = EstadoRemito.Emitido
                });

                foreach (var oe in grupo)
                    oe.Estado = EstadoOrdenEntrega.RemitoEmitido;
            }

            _seleccionadas.Clear();
            return true;
        }

        // Filas de "Remitos pendientes de firma" del transportista buscado.
        // Filtra los remitos del transportista que siguen Emitidos (Where) y los ordena por N° (OrderBy).
        public List<Remito> RemitosPendientesFirma
        {
            get
            {
                return _remitos
                    .Where(r => r.Transportista.DNI == _transportista?.DNI && r.Estado == EstadoRemito.Emitido)
                    .OrderBy(r => r.NroRemito)
                    .ToList();
            }
        }

        // Confirma la entrega firmada: los remitos pasan a Cumplidos, sus OE a Cumplidas y sus OP a Despachadas.
        // Devuelve true si hay al menos un remito y todos existen y estaban Emitidos.
        public bool ConfirmarEntrega(List<int> nrosRemito)
        {
            if (!HayRemitos(nrosRemito)) return false;

            // Busca los remitos elegidos (Where); si falta alguno o alguno no está Emitido (Any), no confirma nada.
            var remitos = _remitos.Where(r => nrosRemito.Contains(r.NroRemito)).ToList();
            if (remitos.Count != nrosRemito.Count || remitos.Any(r => r.Estado != EstadoRemito.Emitido))
                return false;

            foreach (var remito in remitos)
            {
                remito.Estado = EstadoRemito.Cumplido;
                remito.FechaCumplido = DateTime.Now;

                // Pasa a Cumplida cada OE que figura en el remito (Where).
                foreach (var oe in _ordenesEntrega.Where(o => remito.NrosOE.Contains(o.NroOE)))
                {
                    oe.Estado = EstadoOrdenEntrega.Cumplida;
                }

                _opsDespachadas.AddRange(remito.NrosOP);
            }

            return true;
        }
    }
}
