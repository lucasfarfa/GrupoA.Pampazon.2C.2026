namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    internal class OrdenPreparacion
    {
        public int NroOP { get; set; }
        public string Deposito { get; set; } = "";
        public Cliente Cliente { get; set; } = new Cliente();
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaRetiro { get; set; }
        public int Bultos { get; set; }
        public EstadoOrdenPreparacion Estado { get; set; }
        public int? NroOE { get; set; }
    }
}
