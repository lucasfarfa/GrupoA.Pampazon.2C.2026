namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
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
