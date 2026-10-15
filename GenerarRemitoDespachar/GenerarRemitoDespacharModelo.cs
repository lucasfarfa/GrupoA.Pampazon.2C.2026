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

        // Estáticos: los datos se mantienen entre aperturas de la pantalla (remitos sin firmar, prueba G.8).
        private static readonly List<Transportista> _transportistas = new List<Transportista>
        {
            new Transportista {DNI = "24568779", NombreApellido = "Jose Gomez" },
            new Transportista {DNI = "20562667", NombreApellido = "Alejo Cisterna" },
            new Transportista {DNI = "32321987", NombreApellido = "Daniel Baez" }
        };

        // Datos de la situación de partida del plan de pruebas (hoja G).
        private static readonly List<OrdenDeEntrega> _ordenesEntrega = new List<OrdenDeEntrega>
        {
            new OrdenDeEntrega { NroOE = "701", Cliente = "Mercadito S.A.", OrdenesPreparacion = "101, 102", Bultos = 18, DniTransportista = "24568779", Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "704", Cliente = "Mercadito S.A.", OrdenesPreparacion = "105", Bultos = 10, DniTransportista = "24568779", Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "702", Cliente = "MundoFOX S.R.L.", OrdenesPreparacion = "103", Bultos = 1, DniTransportista = "24568779", Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "710", Cliente = "MundoFOX S.R.L.", OrdenesPreparacion = "110", Bultos = 1, DniTransportista = "20562667", Estado = RemitoEmitido },
            new OrdenDeEntrega { NroOE = "703", Cliente = "Ferretería Norte S.A.", OrdenesPreparacion = "104", Bultos = 30, DniTransportista = "32321987", Estado = PendienteEntrega },
            new OrdenDeEntrega { NroOE = "705", Cliente = "Construcciones del Plata S.R.L.", OrdenesPreparacion = "106, 107", Bultos = 9, DniTransportista = "32321987", Estado = PendienteEntrega }
        };

        private static readonly List<Remito> _remitos = new List<Remito>
        {
            new Remito { NroRemito = "R-410", Fecha = DateTime.Today.AddDays(-1), Cliente = "MundoFOX S.R.L.", DniTransportista = "20562667", NombreTransportista = "Alejo Cisterna", OrdenesEntrega = "710", OrdenesPreparacion = "110", TotalBultos = 1, Estado = Emitido }
        };

        // OP que pasaron a Despachada al confirmar la entrega.
        private static readonly List<string> _opsDespachadas = new List<string>();
        private static int _ultimoNroRemito = 410;

        private Transportista? _transportista;   // transportista identificado con "Buscar órdenes"
        private readonly List<string> _seleccionadas = new List<string>();

        public List<Transportista> Transportistas => _transportistas;
        public List<OrdenDeEntrega> OrdenesEntrega => _ordenesEntrega;
        public List<Remito> Remitos => _remitos;
        public List<string> OPsDespachadas => _opsDespachadas;

        public bool HaySeleccion => _seleccionadas.Count > 0;

        // Devuelve true si existe un transportista con ese DNI (ya validado por el form) y lo deja identificado.
        public bool BuscarTransportista(string dni, out Transportista? transportista)
        {
            transportista = Transportistas.FirstOrDefault(t => t.DNI == dni);
            _transportista = transportista;
            return transportista != null;
        }

        // Devuelve true si el transportista identificado tiene al menos una OE pendiente de entrega sin seleccionar.
        public bool BuscarOrdenesPendientes(out List<OrdenDeEntrega> ordenes)
        {
            ordenes = OrdenesEntrega
                .Where(oe => oe.DniTransportista == _transportista?.DNI && oe.Estado == PendienteEntrega && !_seleccionadas.Contains(oe.NroOE))
                .OrderBy(oe => oe.Cliente)
                .ThenBy(oe => oe.NroOE)
                .ToList();
            return ordenes.Count > 0;
        }

        // Descarta el transportista identificado y la selección (nueva búsqueda).
        public void LimpiarBusqueda()
        {
            _transportista = null;
            _seleccionadas.Clear();
        }

        // Devuelve true si todas las OE existen, siguen pendientes y no estaban seleccionadas.
        public bool SeleccionarOrdenes(List<string> nrosOE)
        {
            foreach (var nro in nrosOE)
            {
                var oe = OrdenesEntrega.FirstOrDefault(o => o.NroOE == nro);
                if (oe == null || oe.Estado != PendienteEntrega || _seleccionadas.Contains(nro))
                    return false;
            }

            _seleccionadas.AddRange(nrosOE);
            return true;
        }

        // Devuelve true si todas las OE estaban seleccionadas.
        public bool DeseleccionarOrdenes(List<string> nrosOE)
        {
            if (nrosOE.Any(nro => !_seleccionadas.Contains(nro)))
                return false;

            _seleccionadas.RemoveAll(nrosOE.Contains);
            return true;
        }

        // Un remito por cliente con las OE seleccionadas de ese cliente.
        public List<RemitoAEmitir> ObtenerRemitosAEmitir()
        {
            return OrdenesEntrega
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

        // Genera un remito Emitido por cliente y pasa sus OE a Remito emitido (CU-07, pasos 13 y 14).
        public bool EmitirRemitos()
        {
            if (_seleccionadas.Count == 0 || _transportista == null) return false;

            var porCliente = OrdenesEntrega
                .Where(oe => _seleccionadas.Contains(oe.NroOE))
                .GroupBy(oe => oe.Cliente)
                .OrderBy(g => g.Key);

            foreach (var grupo in porCliente)
            {
                _ultimoNroRemito++;

                Remitos.Add(new Remito
                {
                    NroRemito = "R-" + _ultimoNroRemito,
                    Fecha = DateTime.Now,
                    Cliente = grupo.Key,
                    DniTransportista = _transportista.DNI,
                    NombreTransportista = _transportista.NombreApellido,
                    OrdenesEntrega = string.Join(", ", grupo.Select(oe => oe.NroOE)),
                    OrdenesPreparacion = string.Join(", ", grupo.Select(oe => oe.OrdenesPreparacion)),
                    TotalBultos = grupo.Sum(oe => oe.Bultos),
                    Estado = Emitido
                });

                foreach (var oe in grupo)
                    oe.Estado = RemitoEmitido;
            }

            _seleccionadas.Clear();
            return true;
        }

        public List<Remito> ObtenerRemitosPendientesFirma()
        {
            return Remitos
                .Where(r => r.DniTransportista == _transportista?.DNI && r.Estado == Emitido)
                .OrderBy(r => r.NroRemito)
                .ToList();
        }

        // Registra los remitos como Cumplidos, sus OE como Cumplidas y sus OP como Despachadas (CU-07, paso 20).
        // Devuelve true si todos los remitos existen y estaban Emitidos.
        public bool ConfirmarEntrega(List<string> nrosRemito)
        {
            var remitos = Remitos.Where(r => nrosRemito.Contains(r.NroRemito)).ToList();
            if (remitos.Count != nrosRemito.Count || remitos.Any(r => r.Estado != Emitido))
                return false;

            foreach (var remito in remitos)
            {
                remito.Estado = Cumplido;
                remito.FechaCumplido = DateTime.Now;

                var nrosOE = remito.OrdenesEntrega.Split(", ");
                foreach (var oe in OrdenesEntrega.Where(o => nrosOE.Contains(o.NroOE)))
                {
                    oe.Estado = Cumplida;
                }

                OPsDespachadas.AddRange(remito.OrdenesPreparacion.Split(", "));
            }

            return true;
        }
    }
}
