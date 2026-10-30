using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class MercaderiaEntidad
    {
        public long CuitCliente { get; set; }
        public string Deposito { get; set; } = "";
        public string Sku { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int CantidadComprometida { get; set; }
        public int CantidadEnPreparacion { get; set; }
        public int CantidadEnDespacho { get; set; }
    }
}
