namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class OrdenSeleccion
    {
        public int NroOS { get; set; }
        public EstadoOrdenSeleccion Estado { get; set; }
        public List<int> NrosOP { get; set; } = new List<int>();
        public DateTime? FechaHoraCumplida { get; set; }
        public List<LineaOrdenSeleccion> Detalle { get; set; } = new List<LineaOrdenSeleccion>();
    }

    internal class LineaOrdenSeleccion
    {
        public PosicionDeposito Posicion { get; set; } = new PosicionDeposito();
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
