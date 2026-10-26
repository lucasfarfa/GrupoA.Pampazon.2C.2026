namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class OrdenDeEntrega
    {
        public int NroOE { get; set; }
        public string Cliente { get; set; } = "";
        public List<int> NrosOP { get; set; } = new List<int>();
        public int Bultos { get; set; }
        public Transportista Transportista { get; set; } = new Transportista();
        public string Estado { get; set; } = "";
    }
}
