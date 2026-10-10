using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    internal class ClienteOrden
    {
        public string Nombre { get; set; }
        public string Cuit { get; set; }
    }

    // Producto que se puede pedir para un cliente en un depósito
    internal class ProductoStock
    {
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public int Disponible { get; set; }
    }

    // Fila de la grilla "Productos a preparar" (las propiedades públicas permiten el enlace con la grilla)
    internal class LineaOrden
    {
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Disponible { get; set; }
    }

    internal class OrdenRegistrada
    {
        public string Numero { get; set; }
        public ClienteOrden Cliente { get; set; }
        public string Deposito { get; set; }
        public string Modalidad { get; set; }
        public string Dni { get; set; }
        public string Patente { get; set; }
        public DateTime FechaCarga { get; set; }
        public string Estado { get; set; }
        public List<LineaOrden> Lineas { get; set; } = new();
    }

    // ---------------------------------------------------------------
    // Modelo: reglas de negocio de "Registrar orden de preparación".
    // Los datos de ejemplo están acá, en memoria. Cuando haya base de datos,
    // se reemplazan solamente los métodos que los leen y los guardan.
    // ---------------------------------------------------------------
    internal class RegistrarOrdenPreparacionModelo
    {
        // ===== DATOS DE EJEMPLO (reemplazar por la base cuando exista) =====

        private static readonly List<ClienteOrden> _clientes = new()
        {
            new ClienteOrden { Nombre = "Mercadito S.A.",                 Cuit = "30-71234567-8" },
            new ClienteOrden { Nombre = "Construcciones del Plata S.R.L.", Cuit = "30-70123456-1" },
            new ClienteOrden { Nombre = "Ferretería Norte S.A.",          Cuit = "30-68901234-5" }
        };

        private static readonly List<string> _depositos = new() { "GBA", "Rosario", "Córdoba" };

        private static readonly Dictionary<string, string> _catalogo = new()
        {
            ["CEM-50"] = "Bolsa de cemento x 50 kg",
            ["CAL-25"] = "Bolsa de cal hidratada x 25 kg",
            ["LAD-18"] = "Ladrillo hueco 18x18x33 (unidad)",
            ["ARE-1M"] = "Arena fina, bolsón de 1 m³",
            ["HIE-8"] = "Hierro nervado 8 mm x 12 m"
        };

        // Stock del cliente en cada depósito: (CUIT, depósito, SKU) -> cantidad almacenada
        private static readonly Dictionary<(string Cuit, string Deposito, string Sku), int> _stock = new()
        {
            [("30-71234567-8", "GBA", "CEM-50")] = 1000,
            [("30-71234567-8", "GBA", "CAL-25")] = 340,
            [("30-71234567-8", "GBA", "LAD-18")] = 2500,
            [("30-71234567-8", "Rosario", "CEM-50")] = 400,
            [("30-71234567-8", "Rosario", "ARE-1M")] = 60,
            [("30-70123456-1", "GBA", "CEM-50")] = 150,
            [("30-70123456-1", "GBA", "HIE-8")] = 800,
            [("30-70123456-1", "Rosario", "HIE-8")] = 300,
            [("30-68901234-5", "GBA", "CAL-25")] = 90,
            [("30-68901234-5", "GBA", "ARE-1M")] = 20
        };

        // Órdenes registradas durante la ejecución (comprometen stock)
        private static readonly List<OrdenRegistrada> _ordenes = new();
        private static int _ultimoNumero = 144;      // la primera orden será OP-000145

        // ===== CONSULTAS =====

        public List<ClienteOrden> ObtenerClientes() => _clientes.ToList();

        public List<string> ObtenerDepositos() => _depositos.ToList();

        // Productos que el cliente tiene almacenados en ese depósito
        public List<ProductoStock> ObtenerProductos(ClienteOrden cliente, string deposito)
        {
            return _stock.Keys
                .Where(k => k.Cuit == cliente.Cuit && k.Deposito == deposito)
                .OrderBy(k => k.Sku)
                .Select(k => new ProductoStock
                {
                    Sku = k.Sku,
                    Descripcion = _catalogo[k.Sku],
                    Disponible = ObtenerDisponible(cliente, deposito, k.Sku)
                })
                .ToList();
        }

        // Disponible = stock del cliente en el depósito - cantidades ya comprometidas por otras órdenes
        public int ObtenerDisponible(ClienteOrden cliente, string deposito, string sku)
        {
            _stock.TryGetValue((cliente.Cuit, deposito, sku), out int almacenado);

            int comprometido = _ordenes
                .Where(o => o.Cliente.Cuit == cliente.Cuit && o.Deposito == deposito)
                .SelectMany(o => o.Lineas)
                .Where(l => l.Sku == sku)
                .Sum(l => l.Cantidad);

            return almacenado - comprometido;
        }

        // ===== VALIDACIONES =====

        // DNI: 7 u 8 dígitos
        public static bool DniValido(string dni) =>
            Regex.IsMatch((dni ?? "").Trim(), @"^\d{7,8}$");

        // Patente: formato nuevo (AB123CD) o anterior (ABC123)
        public static bool PatenteValida(string patente) =>
            Regex.IsMatch((patente ?? "").Trim().ToUpper(), @"^([A-Z]{2}\d{3}[A-Z]{2}|[A-Z]{3}\d{3})$");

        // ===== REGISTRO =====

        // Registra la orden en estado Pendiente y compromete el stock. Devuelve el número de orden.
        // Con una base de datos real, todo esto va dentro de una única transacción.
        public string RegistrarOrden(ClienteOrden cliente, string deposito, string modalidad,
                                     string dni, string patente, IEnumerable<LineaOrden> lineas)
        {
            var copia = lineas
                .Select(l => new LineaOrden { Sku = l.Sku, Descripcion = l.Descripcion, Cantidad = l.Cantidad, Disponible = l.Disponible })
                .ToList();

            // Se vuelve a verificar el stock: otra orden pudo haberlo comprometido mientras se cargaba esta
            foreach (var l in copia)
            {
                int disponible = ObtenerDisponible(cliente, deposito, l.Sku);
                if (l.Cantidad > disponible)
                    throw new InvalidOperationException(
                        $"Stock insuficiente para {l.Sku}: solicitado {l.Cantidad}, disponible {disponible}.");
            }

            _ultimoNumero++;
            var orden = new OrdenRegistrada
            {
                Numero = $"OP-{_ultimoNumero:000000}",
                Cliente = cliente,
                Deposito = deposito,
                Modalidad = modalidad,
                Dni = dni.Trim(),
                Patente = patente.Trim().ToUpper(),
                FechaCarga = DateTime.Now,
                Estado = "Pendiente",
                Lineas = copia
            };
            _ordenes.Add(orden);
            return orden.Numero;
        }
    }
}
