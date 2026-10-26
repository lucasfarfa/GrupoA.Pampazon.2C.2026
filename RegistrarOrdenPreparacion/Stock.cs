namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    // Stock en almacén de un SKU de un cliente en un depósito.
    internal class Stock
    {
        public long CuitCliente { get; set; }
        public string Deposito { get; set; } = "";
        public string Sku { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
