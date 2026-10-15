using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    public class ClienteOrden
    {
        public string Nombre { get; set; }
        public string Cuit { get; set; }
    }

    public class ProductoStock
    {
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public int Disponible { get; set; }
    }

    public class LineaOrden
    {
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Disponible { get; set; }
    }

    public class OrdenRegistrada
    {
        public string Numero { get; set; }
        public ClienteOrden Cliente { get; set; }
        public string Deposito { get; set; }
        public string Modalidad { get; set; }
        public string Dni { get; set; }
        public string NombreTransportista { get; set; }
        public DateTime FechaRetiro { get; set; }
        public string Estado { get; set; }
        public List<LineaOrden> Lineas { get; set; } = new();
    }

    internal class RegistrarOrdenPreparacionModelo
    {
        private static readonly List<ClienteOrden> _clientes = new()
        {
            new ClienteOrden { Nombre = "Mercadito S.A.", Cuit = "30-71234567-8" },
            new ClienteOrden { Nombre = "MundoFOX S.R.L.", Cuit = "30-70987654-3" },
            new ClienteOrden { Nombre = "Ferretería Norte S.A.", Cuit = "30-71112223-4" },
            new ClienteOrden { Nombre = "Construcciones del Plata S.R.L.", Cuit = "30-70555444-1" }
        };

        private static readonly List<string> _depositos = new() { "GBA", "ROS", "CBA", "MDZ" };

        private static readonly Dictionary<string, string> _catalogo = new()
        {
            ["CEM-50KG"] = "Bolsa de cemento 50 kg",
            ["CAL-25KG"] = "Bolsa de cal 25 kg",
            ["ZAP-0042"] = "Caja de zapatillas",
            ["TOR-M8"] = "Caja de tornillos M8 x 100",
            ["ARE-25KG"] = "Bolsa de arena 25 kg"
        };

        // Stock base en GBA según Datos base
        private static readonly Dictionary<(string Cuit, string Deposito, string Sku), int> _stock = new()
        {
            [("30-71234567-8", "GBA", "CEM-50KG")] = 60,
            [("30-71234567-8", "GBA", "CAL-25KG")] = 50,
            [("30-70987654-3", "GBA", "ZAP-0042")] = 100,
            [("30-71112223-4", "GBA", "TOR-M8")] = 500,
            [("30-70555444-1", "GBA", "ARE-25KG")] = 800
        };

        // OP Pendientes iniciales que comprometen stock (OP 101, 102, 103)
        private static readonly List<OrdenRegistrada> _ordenes = new()
        {
            new OrdenRegistrada
            {
                Numero = "101",
                Cliente = new ClienteOrden { Nombre = "Mercadito S.A.", Cuit = "30-71234567-8" },
                Deposito = "GBA",
                Estado = "Pendiente",
                Lineas = new List<LineaOrden> { new LineaOrden { Sku = "CEM-50KG", Cantidad = 10 } }
            },
            new OrdenRegistrada
            {
                Numero = "102",
                Cliente = new ClienteOrden { Nombre = "Mercadito S.A.", Cuit = "30-71234567-8" },
                Deposito = "GBA",
                Estado = "Pendiente",
                Lineas = new List<LineaOrden>
                {
                    new LineaOrden { Sku = "CEM-50KG", Cantidad = 5 },
                    new LineaOrden { Sku = "CAL-25KG", Cantidad = 3 }
                }
            },
            new OrdenRegistrada
            {
                Numero = "103",
                Cliente = new ClienteOrden { Nombre = "MundoFOX S.R.L.", Cuit = "30-70987654-3" },
                Deposito = "GBA",
                Estado = "Pendiente",
                Lineas = new List<LineaOrden> { new LineaOrden { Sku = "ZAP-0042", Cantidad = 24 } }
            }
        };

        private static int _ultimoNumeroOp = 103;

        public List<ClienteOrden> ObtenerClientes() => _clientes.ToList();

        public List<string> ObtenerDepositos() => _depositos.ToList();

        public List<ProductoStock> ObtenerProductos(ClienteOrden cliente, string deposito)
        {
            if (cliente == null || string.IsNullOrEmpty(deposito)) return new List<ProductoStock>();

            return _stock.Keys
                .Where(k => k.Cuit == cliente.Cuit && k.Deposito == deposito)
                .OrderBy(k => k.Sku)
                .Select(k => new ProductoStock
                {
                    Sku = k.Sku,
                    Descripcion = _catalogo.ContainsKey(k.Sku) ? _catalogo[k.Sku] : k.Sku,
                    Disponible = ObtenerDisponible(cliente, deposito, k.Sku)
                })
                .ToList();
        }

        public int ObtenerDisponible(ClienteOrden cliente, string deposito, string sku)
        {
            var clave = (cliente.Cuit, deposito, sku);
            if (!_stock.ContainsKey(clave)) return 0;

            int stockBase = _stock[clave];

            int comprometido = _ordenes
                .Where(o => o.Cliente.Cuit == cliente.Cuit && o.Deposito == deposito && o.Estado == "Pendiente")
                .SelectMany(o => o.Lineas)
                .Where(l => l.Sku == sku)
                .Sum(l => l.Cantidad);

            return stockBase - comprometido;
        }

        public static bool DniValido(string dni)
        {
            return Regex.IsMatch(dni ?? "", @"^\d{7,8}$");
        }

        public bool Registrar(ClienteOrden cliente, string deposito, string modalidad, string dni, string nombreTransportista, DateTime fechaRetiro, List<LineaOrden> lineas, out string numeroOpAsignado)
        {
            numeroOpAsignado = string.Empty;

            if (cliente == null || string.IsNullOrWhiteSpace(deposito) || string.IsNullOrWhiteSpace(modalidad) ||
                !DniValido(dni) || string.IsNullOrWhiteSpace(nombreTransportista) || lineas == null || lineas.Count == 0)
            {
                return false;
            }

            _ultimoNumeroOp++;
            numeroOpAsignado = _ultimoNumeroOp.ToString();

            var nuevaOrden = new OrdenRegistrada
            {
                Numero = numeroOpAsignado,
                Cliente = cliente,
                Deposito = deposito,
                Modalidad = modalidad,
                Dni = dni,
                NombreTransportista = nombreTransportista,
                FechaRetiro = fechaRetiro,
                Estado = "Pendiente",
                Lineas = lineas.Select(l => new LineaOrden
                {
                    Sku = l.Sku,
                    Descripcion = l.Descripcion,
                    Cantidad = l.Cantidad,
                    Disponible = l.Disponible
                }).ToList()
            };

            _ordenes.Add(nuevaOrden);
            return true;
        }
    }
}
