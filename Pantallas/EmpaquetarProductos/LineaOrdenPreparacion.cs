namespace GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos
{
    internal class LineaOrdenPreparacion
    {
        public string Sku { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; }
        public int UnidadesPorBulto { get; set; }
        public int UnidadesPorPalet { get; set; }
    }
}
