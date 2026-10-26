namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    internal class OrdenEntrega
    {
        public int NroOE { get; set; }
        public EstadoOrdenEntrega Estado { get; set; }
        public string Deposito { get; set; } = "";
        public DateTime FechaEmision { get; set; }
        public string Cliente { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaRetiro { get; set; }
        public List<LineaOrdenEntrega> Lineas { get; set; } = new List<LineaOrdenEntrega>();
    }

    // OP incluida en la OE con sus bultos.
    internal class LineaOrdenEntrega
    {
        public int NroOP { get; set; }
        public int Bultos { get; set; }
    }
}
