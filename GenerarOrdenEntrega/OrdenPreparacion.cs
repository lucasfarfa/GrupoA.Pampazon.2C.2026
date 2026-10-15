namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    internal class OrdenPreparacion
    {
        public string NroOP { get; set; } = "";
        public string Deposito { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string DniTransportista { get; set; } = "";
        public string NombreTransportista { get; set; } = "";
        public DateTime FechaRetiro { get; set; }
        public int Bultos { get; set; }
        public string Estado { get; set; } = "";
        public string? NroOE { get; set; }
    }
}
