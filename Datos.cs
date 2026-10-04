using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdenesPreparacion;

// ---------------------------------------------------------------
// MODELOS
// ---------------------------------------------------------------
public class Operador
{
    public string Nombre { get; set; }
    public string Deposito { get; set; }
}

public class Cliente
{
    public string RazonSocial { get; set; }
    public string Cuit { get; set; }                   // formato 30-12345678-9
    public string NroContrato { get; set; }
    public bool ContratoVigente { get; set; }
    public int AnticipacionMinimaHoras { get; set; }   // regla operativa del contrato
    public List<string> SkusDeclarados { get; set; } = new();
}

public class SkuDeclarado
{
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    public bool Habilitado { get; set; }
}

// Las propiedades públicas permiten el enlace (binding) con el DataGridView
public class ItemOrden
{
    public string Sku { get; set; }
    public string Descripcion { get; set; }
    public int Cantidad { get; set; }
}

public class OrdenPreparacion
{
    public int Numero { get; set; }
    public string CuitCliente { get; set; }
    public string RazonSocial { get; set; }
    public string NroContrato { get; set; }
    public string Operador { get; set; }
    public string Deposito { get; set; }
    public DateTime FechaCarga { get; set; }
    public DateTime FechaRequerida { get; set; }
    public string Referencia { get; set; }
    public string Destinatario { get; set; }
    public string Domicilio { get; set; }
    public string Estado { get; set; }                 // "Pendiente"
    public List<ItemOrden> Items { get; set; } = new();
}

// ---------------------------------------------------------------
// MENSAJES
// Los textos son un punto de partida: asignen ustedes los códigos MSG-xx
// en el mismo orden en que aparecen en las excepciones del caso de uso.
// ---------------------------------------------------------------
public static class Msg
{
    public const string CuitInvalido = "El CUIT debe tener 11 dígitos.";
    public const string ClienteNoRegistrado = "El CUIT ingresado no corresponde a un cliente registrado.";
    public const string ContratoNoVigente = "El contrato del cliente no se encuentra vigente. No es posible registrar órdenes de preparación.";
    public const string SkuInvalido = "El SKU ingresado no está declarado o no está habilitado para este cliente. Verifique el código.";
    public const string CantidadInvalida = "La cantidad debe ser un número entero mayor a cero.";
    public const string CamposObligatorios = "Debe completar fecha y hora requerida, destinatario, domicilio de entrega y al menos un ítem.";
    public const string AnticipacionMinima = "La fecha y hora requerida no respeta la anticipación mínima de {0} horas establecida en el contrato.";
    public const string StockInsuficiente = "Stock insuficiente para el SKU {0}: solicitado {1}, disponible {2}. Ajuste la cantidad.";
    public const string ConfirmaEnvio = "¿Confirma el registro de la orden de preparación?";
    public const string OrdenRegistrada = "La orden de preparación N° {0} fue validada y registrada en estado Pendiente.";
    public const string ConfirmaSalida = "¿Desea salir? Se perderán los datos no confirmados.";
    public const string SinRegistro = "No se ha registrado ninguna orden de preparación.";
    public const string ErrorRegistro = "No fue posible registrar la orden. Intente nuevamente.";
}

// ---------------------------------------------------------------
// REPOSITORIO SIMULADO (en memoria)
// En el sistema real serían las consultas / actualizaciones a:
//   AL1 Padrón de clientes y contratos
//   AL2 Maestro de inventario y ubicaciones
//   AL7 Cola de órdenes de preparación
// ---------------------------------------------------------------
public static class Repositorio
{
    // Depósitos disponibles en el menú de inicio
    public static readonly List<string> Depositos = new()
    {
        "Depósito Buenos Aires",
        "Depósito Avellaneda",
        "Depósito Rosario"
    };

    // Lo setea el menú de inicio cuando el operador elige el depósito
    public static string DepositoActual { get; set; } = "Depósito Buenos Aires";

    // AL1: clientes y contratos
    private static readonly List<Cliente> _clientes = new()
    {
        new Cliente   // cliente "normal": sirve para el camino feliz
        {
            RazonSocial = "Cliente Ejemplo S.A.", Cuit = "30-12345678-9", NroContrato = "CT-0042",
            ContratoVigente = true, AnticipacionMinimaHoras = 24,
            SkusDeclarados = new() { "SKU-10025", "SKU-20310", "SKU-30077", "SKU-99999" }
        },
        new Cliente   // contrato vencido: prueba la excepción del paso 4
        {
            RazonSocial = "Distribuidora Vencida S.R.L.", Cuit = "30-98765432-1", NroContrato = "CT-0013",
            ContratoVigente = false, AnticipacionMinimaHoras = 24,
            SkusDeclarados = new() { "SKU-10025" }
        },
        new Cliente   // solo declaró un SKU: prueba "SKU no declarado para este cliente"
        {
            RazonSocial = "Alimentos del Sur S.A.", Cuit = "30-55555555-5", NroContrato = "CT-0057",
            ContratoVigente = true, AnticipacionMinimaHoras = 48,
            SkusDeclarados = new() { "SKU-10025" }
        }
    };

    // Catálogo de SKUs
    private static readonly Dictionary<string, SkuDeclarado> _skus = new()
    {
        ["SKU-10025"] = new SkuDeclarado { Codigo = "SKU-10025", Descripcion = "Yerba mate 1 kg", Habilitado = true },
        ["SKU-20310"] = new SkuDeclarado { Codigo = "SKU-20310", Descripcion = "Aceite de girasol 900 ml", Habilitado = true },
        ["SKU-30077"] = new SkuDeclarado { Codigo = "SKU-30077", Descripcion = "Fideos tallarín 500 g", Habilitado = true },
        ["SKU-99999"] = new SkuDeclarado { Codigo = "SKU-99999", Descripcion = "Producto dado de baja", Habilitado = false }
    };

    // AL2: stock disponible por SKU
    private static readonly Dictionary<string, int> _stock = new()
    {
        ["SKU-10025"] = 500,
        ["SKU-20310"] = 50,     // a propósito bajo: pedir 60 dispara la excepción de stock
        ["SKU-30077"] = 300,
        ["SKU-99999"] = 0
    };

    // AL7: cola de órdenes de preparación
    private static readonly List<OrdenPreparacion> _colaOrdenes = new();
    private static int _ultimoNumero = 0;

    // El operador trabaja en el depósito elegido en el menú de inicio
    public static Operador ObtenerOperadorActual() =>
        new Operador { Nombre = "Juan Pérez", Deposito = DepositoActual };

    public static string SoloDigitos(string texto) =>
        new string((texto ?? "").Where(char.IsDigit).ToArray());

    // Acepta el CUIT con o sin guiones
    public static Cliente BuscarClientePorCuit(string cuit) =>
        _clientes.FirstOrDefault(c => SoloDigitos(c.Cuit) == SoloDigitos(cuit));

    // El SKU tiene que estar en la declaración del cliente y existir en el catálogo
    public static SkuDeclarado BuscarSku(Cliente cliente, string codigo)
    {
        if (!cliente.SkusDeclarados.Contains(codigo)) return null;
        return _skus.TryGetValue(codigo, out var sku) ? sku : null;
    }

    public static int StockDisponible(string codigo) =>
        _stock.TryGetValue(codigo, out var s) ? s : 0;

    // Asigna número correlativo, deja la orden en estado Pendiente y la guarda en AL7.
    // Con una base de datos real, esto va dentro de UNA transacción (todo o nada).
    public static int RegistrarOrden(OrdenPreparacion orden)
    {
        orden.Numero = ++_ultimoNumero;
        orden.Estado = "Pendiente";
        _colaOrdenes.Add(orden);
        return orden.Numero;
    }
}