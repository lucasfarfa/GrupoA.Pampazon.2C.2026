namespace GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos
{
    internal class OrdenPreparacion
    {
        public int NroOP { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public Modalidad Modalidad { get; set; }
        public int NroOS { get; set; }
        public EstadoOrdenPreparacion Estado { get; set; }
        public List<LineaOrdenPreparacion> Lineas { get; set; } = new List<LineaOrdenPreparacion>();
        public int Bultos { get; set; }
        public DateTime? FechaEmpaquetado { get; set; }
    }
}
