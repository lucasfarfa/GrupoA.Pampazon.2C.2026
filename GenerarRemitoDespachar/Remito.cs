namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class Remito
    {
        public string NroRemito { get; set; } = "";
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public List<int> NrosOE { get; set; } = new List<int>();
        public List<int> NrosOP { get; set; } = new List<int>();
        public int TotalBultos { get; set; }
        public string Estado { get; set; } = "";
        public DateTime? FechaCumplido { get; set; }
    }

    // Fila de "Se emitirán los siguientes remitos": un remito por cliente.
    internal class RemitoAEmitir
    {
        public string Cliente { get; set; } = "";
        public List<int> NrosOE { get; set; } = new List<int>();
    }
}
