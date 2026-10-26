namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    // Fila de "Órdenes preparadas sin orden de entrega": OP de un mismo cliente, transportista y fecha de retiro.
    internal class GrupoOrdenes
    {
        public string Cliente { get; set; } = "";
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaRetiro { get; set; }
        public int CantidadOP { get; set; }
    }
}
