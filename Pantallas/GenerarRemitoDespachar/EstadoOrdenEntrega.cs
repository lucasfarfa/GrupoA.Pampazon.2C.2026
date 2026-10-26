namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
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
