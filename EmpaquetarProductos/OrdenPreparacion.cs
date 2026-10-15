namespace GrupoA.PampazonSA.AdministracionDeposito.CU04EmpaquetarProductos
{
    internal class OrdenPreparacion
    {
        public string NroOP { get; set; } = "";
        public DateTime FechaRecepcion { get; set; }
        public string Modalidad { get; set; } = "";
        public string NroOS { get; set; } = "";
        public string Estado { get; set; } = "";
        public List<ProductoOrden> Productos { get; set; } = new List<ProductoOrden>();
        public int Bultos { get; set; }
        public DateTime? FechaEmpaquetado { get; set; }
    }
}
