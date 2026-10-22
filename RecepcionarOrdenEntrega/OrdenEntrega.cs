namespace GrupoA.PampazonSA.AdministracionDeposito.RecepcionarOrdenEntrega
{
    internal class OrdenEntrega
    {
        public string NroOE { get; set; } = "";
        public string Estado { get; set; } = "";
        public string Deposito { get; set; } = "";
        public string Cliente { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaEmision { get; set; }
        public List<string> NrosOP { get; set; } = new List<string>();
        public int Bultos { get; set; }

        // Dónde está la mercadería: en Preparación hasta que Despacho confirma la recepción.
        public string Ubicacion { get; set; } = "";
        public DateTime? FechaRecepcion { get; set; }
    }
}
