using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class RemitoEntidad
    {
        public int NroRemito { get; set; }
        public DateTime FechaEmision { get; set; }
        public EstadoRemitoEnum Estado { get; set; }
        public List<int> NrosOE { get; set; } = new List<int>();
        public DateTime? FechaCumplida { get; set; }
        public long CuitCliente { get; set; }
        public int DNITransportista { get; set; }
        public string IdDeposito { get; set; } = "";
    }
}
