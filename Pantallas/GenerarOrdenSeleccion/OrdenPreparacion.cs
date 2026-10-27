namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class OrdenPreparacion
    {
        public int NroOP { get; set; }
        public string Deposito { get; set; } = "";
        public Cliente Cliente { get; set; } = new Cliente();
        public DateTime FechaRecepcion { get; set; }
        public Modalidad Modalidad { get; set; }
        public EstadoOrdenPreparacion Estado { get; set; }
        public List<LineaOrdenPreparacion> Lineas { get; set; } = new List<LineaOrdenPreparacion>();
    }

    // Línea de mercadería de una OP; también es la fila del "Resumen consolidado de productos".
    internal class LineaOrdenPreparacion
    {
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
