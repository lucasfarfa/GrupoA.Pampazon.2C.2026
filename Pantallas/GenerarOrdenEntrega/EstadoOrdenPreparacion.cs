namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    // Estados de una OP, en el orden en que los recorre.
    internal enum EstadoOrdenPreparacion
    {
        Pendiente,
        EnPreparacion,
        Preparada,
        EnEntrega,
        Despachada
    }
}
