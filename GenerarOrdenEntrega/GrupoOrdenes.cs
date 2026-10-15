namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    // Fila de "Órdenes preparadas sin orden de entrega": OP de un mismo cliente, transportista y fecha de retiro.
    internal class GrupoOrdenes
    {
        public string Clave { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string NombreTransportista { get; set; } = "";
        public DateTime FechaRetiro { get; set; }
        public int CantidadOP { get; set; }
    }
}
