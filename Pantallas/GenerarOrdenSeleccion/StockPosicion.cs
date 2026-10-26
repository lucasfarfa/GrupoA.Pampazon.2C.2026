namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    // Registro de stock: cantidad de un SKU en una posición X-Y-Z del depósito.
    internal class StockPosicion
    {
        public string Sku { get; set; } = "";
        public PosicionDeposito Posicion { get; set; } = new PosicionDeposito();
        public int Cantidad { get; set; }
    }
}
