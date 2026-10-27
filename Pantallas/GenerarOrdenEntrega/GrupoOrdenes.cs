namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    // Fila de "Órdenes preparadas sin orden de entrega": OP de un mismo cliente, transportista y fecha de retiro.
    internal class GrupoOrdenes
    {
        public Cliente Cliente { get; set; } = new Cliente();
        public Transportista Transportista { get; set; } = new Transportista();
        public DateTime FechaRetiro { get; set; }
        public int CantidadOP { get; set; }
    }
}
