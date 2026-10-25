namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class Remito
    {
        public string NroRemito { get; set; } = "";
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public List<string> NrosOE { get; set; } = new List<string>();
        public List<string> NrosOP { get; set; } = new List<string>();
        public int TotalBultos { get; set; }
        public string Estado { get; set; } = "";
        public DateTime? FechaCumplido { get; set; }
    }

    // Fila de "Se emitirán los siguientes remitos": un remito por cliente.
    internal class RemitoAEmitir
    {
        public string Cliente { get; set; } = "";
        public List<string> NrosOE { get; set; } = new List<string>();
    }
}
