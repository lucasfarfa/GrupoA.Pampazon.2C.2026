using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    // Modelo de la pantalla de picking (Almacén).
    // La Orden de Selección ya viene consolidada desde "Generar Orden de Selección":
    // una línea por producto y posición, con la suma de las órdenes de preparación incluidas.
    // Almacén retira esa mercadería, la entrega a Preparación y da la OS por cumplida.
    public class PrepararProductosModelo
    {
        // Depósito del operador (en el sistema real sale de la sesión / configuración del puesto).
        public string Deposito { get; private set; }

        public List<OrdenSeleccion> OrdenesSeleccion { get; } = new List<OrdenSeleccion>();

        // Stock del almacén por posición y SKU (solo lo necesario para descontar al cumplir la OS).
        public List<StockPosicion> Stock { get; } = new List<StockPosicion>();

        public PrepararProductosModelo()
        {
            Deposito = "GBA";
            CargarDatosPrueba();
        }

        // OS que Almacén todavía tiene que preparar, de la más vieja a la más nueva.
        public List<OrdenSeleccion> GetOrdenesPendientes()
        {
            return OrdenesSeleccion
                .Where(os => os.Estado == EstadoOrdenSeleccion.Pendiente)
                .OrderBy(os => os.FechaEmision)
                .ToList();
        }

        public OrdenSeleccion GetOrdenSeleccion(string osId)
        {
            if (osId == null) return null;
            return OrdenesSeleccion.FirstOrDefault(os => os.Id == osId);
        }

        // Detalle a retirar, ordenado por posición para hacer el recorrido de una sola vez.
        public List<LineaPicking> GetLineasOrdenadas(string osId)
        {
            var os = GetOrdenSeleccion(osId);
            if (os == null) return new List<LineaPicking>();
            return os.Lineas.OrderBy(l => l.Posicion).ToList();
        }

        // Almacén confirma que entregó la mercadería a Preparación:
        // la OS pasa a Cumplida y se descuenta el stock del almacén.
        // Las órdenes de preparación NO cambian de estado: siguen "En preparación"
        // hasta que se empaquetan (pantalla Empaquetar).
        // Devuelve null si salió bien, o el motivo por el que no se pudo confirmar.
        public string ConfirmarEntregaAPreparacion(string osId)
        {
            var os = GetOrdenSeleccion(osId);
            if (os == null)
                return "La orden de selección no existe.";

            if (os.Estado == EstadoOrdenSeleccion.Cumplida)
                return "La orden de selección " + os.Id + " ya está cumplida.";

            // Primero se valida todo, después se descuenta: o se descuenta todo o nada.
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

        // Datos de prueba para el prototipo (mismos ejemplos que el resto de las pantallas).
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
                new LineaPicking { Posicion = "12-43-2", Cliente = "Mercadito S.A.", Sku = "CEM-50",   Descripcion = "Bolsa de cemento x 50 kg",      Cantidad = 4, Unidad = "Unidad" },
                new LineaPicking { Posicion = "12-44-1", Cliente = "Mercadito S.A.", Sku = "CAL-25",   Descripcion = "Bolsa de cal hidratada x 25 kg", Cantidad = 5, Unidad = "Unidad" },
                new LineaPicking { Posicion = "03-10-3", Cliente = "MundoFOX S.A.",  Sku = "TV-55-4K", Descripcion = "Smart TV 55\" 4K",               Cantidad = 4, Unidad = "Palet" }
            });

            var os33 = new OrdenSeleccion
            {
                Id = "OS-000033",
                FechaEmision = new DateTime(2026, 10, 9, 15, 0, 0),
                Estado = EstadoOrdenSeleccion.Pendiente
            };
            os33.OrdenesPreparacion.AddRange(new[] { "OP-000146", "OP-000147" });
            os33.Lineas.AddRange(new[]
            {
                new LineaPicking { Posicion = "05-02-1", Cliente = "Mercadito S.A.", Sku = "TEJ-COL",  Descripcion = "Teja colonial",       Cantidad = 120, Unidad = "Unidad" },
                new LineaPicking { Posicion = "07-11-2", Cliente = "MundoFOX S.A.",  Sku = "HEL-300",  Descripcion = "Heladera 300 litros", Cantidad = 2,   Unidad = "Unidad" }
            });

            // OS pensada para probar el rechazo por falta de stock (pide 10 y en la posición hay 3).
            var os34 = new OrdenSeleccion
            {
                Id = "OS-000034",
                FechaEmision = new DateTime(2026, 10, 10, 9, 0, 0),
                Estado = EstadoOrdenSeleccion.Pendiente
            };
            os34.OrdenesPreparacion.Add("OP-000150");
            os34.Lineas.Add(new LineaPicking { Posicion = "09-01-1", Cliente = "MundoFOX S.A.", Sku = "MIC-20", Descripcion = "Microondas 20 litros", Cantidad = 10, Unidad = "Unidad" });

            // OS ya cumplida: no tiene que aparecer en la lista.
            var os31 = new OrdenSeleccion
            {
                Id = "OS-000031",
                FechaEmision = new DateTime(2026, 10, 8, 9, 0, 0),
                Estado = EstadoOrdenSeleccion.Cumplida
            };
            os31.OrdenesPreparacion.Add("OP-000138");
            os31.Lineas.Add(new LineaPicking { Posicion = "12-43-2", Cliente = "Mercadito S.A.", Sku = "CEM-50", Descripcion = "Bolsa de cemento x 50 kg", Cantidad = 10, Unidad = "Unidad" });

            OrdenesSeleccion.AddRange(new[] { os31, os32, os33, os34 });

            Stock.AddRange(new[]
            {
                new StockPosicion { Posicion = "12-43-2", Sku = "CEM-50",   Cantidad = 1000 },
                new StockPosicion { Posicion = "12-44-1", Sku = "CAL-25",   Cantidad = 340 },
                new StockPosicion { Posicion = "03-10-3", Sku = "TV-55-4K", Cantidad = 12 },
                new StockPosicion { Posicion = "05-02-1", Sku = "TEJ-COL",  Cantidad = 500 },
                new StockPosicion { Posicion = "07-11-2", Sku = "HEL-300",  Cantidad = 8 },
                new StockPosicion { Posicion = "09-01-1", Sku = "MIC-20",   Cantidad = 3 }
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

        // Números de las órdenes de preparación agrupadas en esta OS (solo para mostrar).
        public List<string> OrdenesPreparacion { get; } = new List<string>();

        // Detalle consolidado: una línea por producto y posición.
        public List<LineaPicking> Lineas { get; } = new List<LineaPicking>();
    }

    public class LineaPicking
    {
        public string Posicion { get; set; }   // X-Y-Z, por ejemplo 12-43-2
        public string Cliente { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }     // "Unidad" (fulfillment) o "Palet" (palet cerrado)
    }

    public class StockPosicion
    {
        public string Posicion { get; set; }
        public string Sku { get; set; }
        public int Cantidad { get; set; }
    }
}