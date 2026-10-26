namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    // Estados de una OE, en el orden en que los recorre.
    internal enum EstadoOrdenEntrega
    {
        Emitida,
        PendienteEntrega,
        RemitoEmitido,
        Cumplida
    }
}
