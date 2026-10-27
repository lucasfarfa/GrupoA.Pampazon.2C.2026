namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    internal class CantidadPosicion
    {
        public string Sku { get; set; } = "";
        public PosicionDeposito Posicion { get; set; } = new PosicionDeposito();
        public int Cantidad { get; set; }
    }
}
