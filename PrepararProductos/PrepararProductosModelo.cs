using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    public class PrepararProductosModelo
    {
        public string Deposito { get; private set; }
        public List<OrdenSeleccion> OrdenesSeleccion { get; } = new List<OrdenSeleccion>();
        public List<StockPosicion> Stock { get; } = new List<StockPosicion>();

        public PrepararProductosModelo()
        {
            Deposito = "GBA";
            CargarDatosPrueba();
        }

        public List<OrdenSeleccion> GetOrdenesPendientes()
        {
            return OrdenesSeleccion
                .Where(os => os.Estado.Equals(EstadoOrdenSeleccion.Pendiente))
                .OrderBy(os => os.FechaEmision)
                .ToList();
        }

        public OrdenSeleccion GetOrdenSeleccion(string osId)
        {
            if (osId == null) return null;
            return OrdenesSeleccion.FirstOrDefault(os => os.Id == osId);
        }

        public List<LineaPicking> GetLineasOrdenadas(string osId)
        {
            var os = GetOrdenSeleccion(osId);
            if (os == null) return new List<LineaPicking>();
            return os.Lineas.OrderBy(l => l.Posicion).ToList();
        }

        public string ConfirmarEntregaAPreparacion(string osId)
        {
            var os = GetOrdenSeleccion(osId);
            if (os == null)
                return "La orden de selección no existe.";

            if (os.Estado == EstadoOrdenSeleccion.Cumplida)
                return "La orden de selección " + os.Id + " ya está cumplida.";

            var faltantes = new List<string>();
            foreach (var linea in os.Lineas)
            {
                var stock = BuscarStock(linea.Posicion, linea.Sku);
                int disponible = stock == null ? 0 : stock.Cantidad;
                if (disponible < linea.Cantidad)
                {
                    faltantes.Add("- " + linea.Sku + " en " + linea.Posicion +
                                  ": se necesitan " + linea.Cantidad + ", hay " + disponible);
                }
            }

            if (faltantes.Count > 0)
            {
                return "No hay stock suficiente en el almacén para:\n" + string.Join("\n", faltantes);
            }

            foreach (var linea in os.Lineas)
            {
                BuscarStock(linea.Posicion, linea.Sku).Cantidad -= linea.Cantidad;
            }

            os.Estado = EstadoOrdenSeleccion.Cumplida;
            return null;
        }

        private StockPosicion BuscarStock(string posicion, string sku)
        {
            return Stock.FirstOrDefault(s => s.Posicion == posicion && s.Sku == sku);
        }

        private void CargarDatosPrueba()
        {
            OrdenesSeleccion.Clear();
            Stock.Clear();

            var os32 = new OrdenSeleccion
            {
                Id = "OS-000032",
                FechaEmision = new DateTime(2026, 10, 9, 9, 30, 0),
                Estado = EstadoOrdenSeleccion.Pendiente
            };
            os32.OrdenesPreparacion.AddRange(new[] { "OP-000141", "OP-000142", "OP-000143" });
            os32.Lineas.AddRange(new[]
            {
                new LineaPicking { Posicion = "12-43-2", Cliente = "Mercadito S.A.", Sku = "CEM-50",   Descripcion = "Bolsa de cemento x 50 kg",      Cantidad = 4, Modalidad = "FulFillment" },
                new LineaPicking { Posicion = "12-44-1", Cliente = "Mercadito S.A.", Sku = "CAL-25",   Descripcion = "Bolsa de cal hidratada x 25 kg", Cantidad = 5, Modalidad = "FulFillment" },
                new LineaPicking { Posicion = "03-10-3", Cliente = "MundoFOX S.A.",  Sku = "TV-55-4K", Descripcion = "Smart TV 55\" 4K",               Cantidad = 4, Modalidad = "Palet Cerrado" }
            });

            OrdenesSeleccion.Add(os32);

            Stock.AddRange(new[]
            {
                new StockPosicion { Posicion = "12-43-2", Sku = "CEM-50",   Cantidad = 1000 },
                new StockPosicion { Posicion = "12-44-1", Sku = "CAL-25",   Cantidad = 340 },
                new StockPosicion { Posicion = "03-10-3", Sku = "TV-55-4K", Cantidad = 12 }
            });
        }
    }

    public enum EstadoOrdenSeleccion
    {
        Pendiente,
        Cumplida
    }

    public class OrdenSeleccion
    {
        public string Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public EstadoOrdenSeleccion Estado { get; set; }
        public List<string> OrdenesPreparacion { get; } = new List<string>();
        public List<LineaPicking> Lineas { get; } = new List<LineaPicking>();
    }

    public class LineaPicking
    {
        public string Posicion { get; set; }
        public string Cliente { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Modalidad { get; set; }
    }

    public class StockPosicion
    {
        public string Posicion { get; set; }
        public string Sku { get; set; }
        public int Cantidad { get; set; }
    }
}