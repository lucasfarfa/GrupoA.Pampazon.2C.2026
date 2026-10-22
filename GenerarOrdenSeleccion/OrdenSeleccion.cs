using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class OrdenSeleccion
    {
        public string NroOS { get; set; } = "";
        public string Deposito { get; set; } = "";
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = "";
        public List<string> NrosOP { get; set; } = new List<string>();
        public List<LineaOrdenSeleccion> Detalle { get; set; } = new List<LineaOrdenSeleccion>();
    }

    // Mercadería a retirar: una línea por SKU y posición donde está almacenado.
    internal class LineaOrdenSeleccion
    {
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
        public string Posicion { get; set; } = "";
    }
}
