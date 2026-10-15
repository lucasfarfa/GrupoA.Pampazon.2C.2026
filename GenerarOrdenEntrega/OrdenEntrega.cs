namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    internal class OrdenEntrega
    {
        public string NroOE { get; set; } = "";
        public string Estado { get; set; } = "";
        public string Deposito { get; set; } = "";
        public DateTime FechaEmision { get; set; }
        public string Cliente { get; set; } = "";
        public string DniTransportista { get; set; } = "";
        public string NombreTransportista { get; set; } = "";
        public DateTime FechaRetiro { get; set; }
        public List<LineaOrdenEntrega> Lineas { get; set; } = new List<LineaOrdenEntrega>();
    }

    // OP incluida en la OE con sus bultos.
    internal class LineaOrdenEntrega
    {
        public string NroOP { get; set; } = "";
        public int Bultos { get; set; }
    }
}
