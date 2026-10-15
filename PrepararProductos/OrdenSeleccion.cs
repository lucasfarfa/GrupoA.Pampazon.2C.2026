namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class OrdenSeleccion
    {
        public string Nro { get; set; } = "";
        public string Estado { get; set; } = "";
        public string OrdenesPreparacion { get; set; } = "";
        public DateTime? FechaHoraCumplida { get; set; }
        public List<LineaMercaderia> Lineas { get; } = new List<LineaMercaderia>();
    }

    internal class LineaMercaderia
    {
        public string Posicion { get; set; } = "";
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
