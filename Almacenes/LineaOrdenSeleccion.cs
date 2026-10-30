using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class LineaOrdenSeleccion
    {
        public int Sector { get; set; }
        public int Posicion { get; set; }
        public int Fila { get; set; }
        public long CuitCliente { get; set; }
        public string Sku { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
