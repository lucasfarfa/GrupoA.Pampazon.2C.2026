namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class OrdenSeleccion
    {
        public int NroOS { get; set; }
        public string Deposito { get; set; } = "";
        public DateTime Fecha { get; set; }
        public EstadoOrdenSeleccion Estado { get; set; }
        public List<int> NrosOP { get; set; } = new List<int>();
        public List<LineaOrdenSeleccion> Lineas { get; set; } = new List<LineaOrdenSeleccion>();
    }

    // Mercadería a retirar: una línea por SKU y posición donde está almacenado.
    internal class LineaOrdenSeleccion
    {
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
        public PosicionDeposito Posicion { get; set; } = new PosicionDeposito();
    }
}
