using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class GenerarRemitoDespacharModelo
    {
        private const string PendienteEntrega = "Pendiente de entrega";
        private const string RemitoEmitido = "Remito emitido";
        private const string Emitido = "Emitido";
        private const string Cumplido = "Cumplido";
        private const string Cumplida = "Cumplida";

        private static readonly Transportista _joseGomez = new Transportista { DNI = "24568779", NombreApellido = "Jose Gomez" };
        private static readonly Transportista _alejoCisterna = new Transportista { DNI = "20562667", NombreApellido = "Alejo Cisterna" };
        private static readonly Transportista _danielBaez = new Transportista { DNI = "32321987", NombreApellido = "Daniel Baez" };

        private static readonly List<Transportista> _transportistas = new List<Transportista> { _joseGomez, _alejoCisterna, _danielBaez };

        private static readonly List<OrdenDeEntrega> _ordenesEntrega = new List<OrdenDeEntrega>
        {
            new OrdenDeEntrega { NroOE = "701", Cliente = "Mercadito S.A.", NrosOP = new List<string> { "101", "102" }, Bultos = 18, Transportista = _joseGomez, Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "704", Cliente = "Mercadito S.A.", NrosOP = new List<string> { "105" }, Bultos = 10, Transportista = _joseGomez, Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "702", Cliente = "MundoFOX S.R.L.", NrosOP = new List<string> { "103" }, Bultos = 1, Transportista = _joseGomez, Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "710", Cliente = "MundoFOX S.R.L.", NrosOP = new List<string> { "110" }, Bultos = 1, Transportista = _alejoCisterna, Estado = RemitoEmitido },
            new OrdenDeEntrega { NroOE = "703", Cliente = "Ferretería Norte S.A.", NrosOP = new List<string> { "104" }, Bultos = 30, Transportista = _danielBaez, Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "705", Cliente = "Construcciones del Plata S.R.L.", NrosOP = new List<string> { "106", "107" }, Bultos = 9, Transportista = _danielBaez, Estado = PendienteEntrega }
        };

        private static readonly List<Remito> _remitos = new List<Remito>
        {
            new Remito { NroRemito = "R-410", Fecha = DateTime.Today.AddDays(-1), Cliente = "MundoFOX S.R.L.", Transportista = _alejoCisterna, NrosOE = new List<string> { "710" }, NrosOP = new List<string> { "110" }, TotalBultos = 1, Estado = Emitido }
        };

        // OP que pasaron a Despachada al confirmar la entrega.
        private static readonly List<string> _opsDespachadas = new List<string>();
        private static int _ultimoNroRemito = 410;

        private Transportista? _transportista;   // transportista identificado con "Buscar órdenes"
        private readonly List<string> _seleccionadas = new List<string>();

        public bool HaySeleccion => _seleccionadas.Count > 0;

        // Identifica al transportista para cargar sus documentos. Devuelve true si existe uno con ese DNI (ya validado por el form).
        public bool BuscarTransportista(string dni, out Transportista? transportista)
        {
            // Busca el transportista con ese DNI, o null si no hay ninguno (FirstOrDefault).
            transportista = _transportistas.FirstOrDefault(t => t.DNI == dni);
            _transportista = transportista;
            return transportista != null;
        }

        // Filas de "Órdenes de entrega pendientes": las del transportista buscado que todavía no se eligieron.
        // Filtra por transportista, estado Pendiente de entrega y no seleccionadas (Where)
        // y ordena por cliente y después por N° de OE (OrderBy y ThenBy).
        public List<OrdenDeEntrega> OrdenesPendientes
        {
            get
            {
                return _ordenesEntrega
                    .Where(oe => oe.Transportista.DNI == _transportista?.DNI && oe.Estado == PendienteEntrega && !_seleccionadas.Contains(oe.NroOE))
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
        // Devuelve true si todas las OE existen, siguen pendientes y no estaban seleccionadas.
        public bool SeleccionarOrdenes(List<string> nrosOE)
        {
            foreach (var nro in nrosOE)
            {
                // Busca la OE con ese número, o null si no existe (FirstOrDefault).
                var oe = _ordenesEntrega.FirstOrDefault(o => o.NroOE == nro);
                if (oe == null || oe.Estado != PendienteEntrega || _seleccionadas.Contains(nro))
                    return false;
            }

            _seleccionadas.AddRange(nrosOE);
            return true;
        }

        // Devuelve las OE elegidas a "Órdenes de entrega pendientes". Devuelve true si todas estaban seleccionadas.
        public bool DeseleccionarOrdenes(List<string> nrosOE)
        {
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
                    NroRemito = "R-" + _ultimoNroRemito,
                    Fecha = DateTime.Now,
                    Cliente = grupo.Key,
                    Transportista = _transportista,
                    // Lista con el N° de cada OE del grupo (Select), lista con todas las OP de esas OE juntas
                    // (SelectMany) y suma de sus bultos (Sum).
                    NrosOE = grupo.Select(oe => oe.NroOE).ToList(),
                    NrosOP = grupo.SelectMany(oe => oe.NrosOP).ToList(),
                    TotalBultos = grupo.Sum(oe => oe.Bultos),
                    Estado = Emitido
                });

                foreach (var oe in grupo)
                    oe.Estado = RemitoEmitido;
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
                    .Where(r => r.Transportista.DNI == _transportista?.DNI && r.Estado == Emitido)
                    .OrderBy(r => r.NroRemito)
                    .ToList();
            }
        }

        // Confirma la entrega firmada: los remitos pasan a Cumplidos, sus OE a Cumplidas y sus OP a Despachadas.
        // Devuelve true si todos los remitos existen y estaban Emitidos.
        public bool ConfirmarEntrega(List<string> nrosRemito)
        {
            // Busca los remitos elegidos (Where); si falta alguno o alguno no está Emitido (Any), no confirma nada.
            var remitos = _remitos.Where(r => nrosRemito.Contains(r.NroRemito)).ToList();
            if (remitos.Count != nrosRemito.Count || remitos.Any(r => r.Estado != Emitido))
                return false;

            foreach (var remito in remitos)
            {
                remito.Estado = Cumplido;
                remito.FechaCumplido = DateTime.Now;

                // Pasa a Cumplida cada OE que figura en el remito (Where).
                foreach (var oe in _ordenesEntrega.Where(o => remito.NrosOE.Contains(o.NroOE)))
                {
                    oe.Estado = Cumplida;
                }

                _opsDespachadas.AddRange(remito.NrosOP);
            }

            return true;
        }
    }
}
