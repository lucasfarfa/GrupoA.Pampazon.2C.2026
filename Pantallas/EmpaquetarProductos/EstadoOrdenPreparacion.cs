namespace GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos
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
