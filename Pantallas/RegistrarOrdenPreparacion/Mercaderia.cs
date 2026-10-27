namespace GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion
{
    // Mercadería en almacén de un SKU de un cliente en un depósito.
    internal class Mercaderia
    {
        public Cliente Cliente { get; set; } = new Cliente();
        public string Deposito { get; set; } = "";
        public string Sku { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
