using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class CantidadPorPosicion
    {
        public long CuitCliente { get; set; }
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
