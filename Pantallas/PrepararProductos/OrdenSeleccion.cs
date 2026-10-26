namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class OrdenSeleccion
    {
        public int Nro { get; set; }
        public string Estado { get; set; } = "";
        public List<int> NrosOP { get; set; } = new List<int>();
        public DateTime? FechaHoraCumplida { get; set; }
        public List<LineaMercaderia> Lineas { get; set; } = new List<LineaMercaderia>();
    }

    internal class LineaMercaderia
    {
        public PosicionDeposito Posicion { get; set; } = new PosicionDeposito();
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
