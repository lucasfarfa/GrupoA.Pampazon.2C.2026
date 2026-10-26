namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
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
