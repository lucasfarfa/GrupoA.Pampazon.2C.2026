using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    // Registro de stock: cantidad de un SKU en una posición X-Y-Z del depósito.
    internal class PosicionStock
    {
        public string Sku { get; set; }
        public string Posicion { get; set; }
        public int Cantidad { get; set; }
    }
}
