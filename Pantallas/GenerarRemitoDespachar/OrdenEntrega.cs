namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class OrdenEntrega
    {
        public int NroOE { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public List<LineaOrdenEntrega> Lineas { get; set; } = new List<LineaOrdenEntrega>();
        public Transportista Transportista { get; set; } = new Transportista();
        public EstadoOrdenEntrega Estado { get; set; }
    }

    // OP incluida en la OE con sus bultos.
    internal class LineaOrdenEntrega
    {
        public int NroOP { get; set; }
        public int Bultos { get; set; }
    }
}
