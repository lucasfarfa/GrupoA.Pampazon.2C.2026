namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    internal class OrdenEntrega
    {
        public int NroOE { get; set; }
        public EstadoOrdenEntrega Estado { get; set; }
        public string Deposito { get; set; } = "";
        public string Cliente { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaEmision { get; set; }
        public List<LineaOrdenEntrega> Lineas { get; set; } = new List<LineaOrdenEntrega>();

        // Dónde está la mercadería: en Preparación hasta que Despacho confirma la recepción.
        public string Ubicacion { get; set; } = "";
        public DateTime? FechaRecepcionDespacho { get; set; }
    }

    // OP incluida en la OE con sus bultos.
    internal class LineaOrdenEntrega
    {
        public int NroOP { get; set; }
        public int Bultos { get; set; }
    }
}
