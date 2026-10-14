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
        public string Patente { get; set; }
        public DateTime FechaCarga { get; set; }
        public string Estado { get; set; }
        public List<LineaOrden> Lineas { get; set; } = new();
    }

    internal class RegistrarOrdenPreparacionModelo
    {
        private static readonly List<ClienteOrden> _clientes = new()
        {
            new ClienteOrden { Nombre = "Mercadito S.A.", Cuit = "30-71234567-8" },
            new ClienteOrden { Nombre = "Construcciones del Plata S.R.L.", Cuit = "30-70123456-1" },
            new ClienteOrden { Nombre = "Ferretería Norte S.A.", Cuit = "30-68901234-5" }
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

        private static readonly List<OrdenRegistrada> _ordenes = new();
        private static int _ultimoNumero = 144;

        public List<ClienteOrden> ObtenerClientes() => _clientes.ToList();

        public List<string> ObtenerDepositos() => _depositos.ToList();

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
    }
}