namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class OrdenDeEntrega
    {
        public string NroOE { get; set; } = "";
        public string Cliente { get; set; } = "";
        public List<string> NrosOP { get; set; } = new List<string>();
        public int Bultos { get; set; }
        public Transportista Transportista { get; set; } = new Transportista();
        public string Estado { get; set; } = "";
    }
}
