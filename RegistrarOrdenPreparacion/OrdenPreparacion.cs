namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    internal class OrdenPreparacion
    {
        public int NroOP { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public long CuitCliente { get; set; }
        public string Deposito { get; set; } = "";
        public string Modalidad { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaRetiro { get; set; }
        public string Estado { get; set; } = "";
        public List<LineaOrden> Lineas { get; set; } = new List<LineaOrden>();
    }

    // Fila de "Productos a preparar".
    internal class LineaOrden
    {
        public string Sku { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
