using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class OrdenEntregaEntidad
    {
        public int NroOE { get; set; }
        public DateTime FechaEmision { get; set; }
        public EstadoOrdenEntregaEnum Estado { get; set; }
        public List<int> NrosOP { get; set; } = new List<int>();
        public DateTime? FechaRecepcionDespacho { get; set; }
        public string IdDeposito { get; set; } = "";
        public long CuitCliente { get; set; }
        public int DNITransportista { get; set; }
        public DateTime FechaEntregaTransportista { get; set; }
    }
}
