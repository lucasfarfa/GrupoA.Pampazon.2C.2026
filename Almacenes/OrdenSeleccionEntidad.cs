using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class OrdenSeleccionEntidad
    {
        public int NroOS { get; set; }
        public string Deposito { get; set; } = "";
        public DateTime FechaEmision { get; set; }
        public EstadoOrdenSeleccionEnum Estado { get; set; }
        public List<int> NrosOP { get; set; } = new List<int>();
        public List<LineaOrdenSeleccion> Lineas { get; set; } = new List<LineaOrdenSeleccion>();
        public DateTime? FechaCumplida { get; set; }
    }
}
