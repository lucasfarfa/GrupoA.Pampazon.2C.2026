using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class OrdenPreparacionEntidad
    {
        public int NroOP { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public long CuitCliente { get; set; }
        public string Deposito { get; set; } = "";
        public ModalidadEnum Modalidad { get; set; }
        public int DNITransportista { get; set; }
        public string NombreTransportista { get; set; } = "";
        public DateTime FechaRetiro { get; set; }
        public EstadoOrdenPreparacionEnum Estado { get; set; }
        public List<LineaOrdenPreparacion> Lineas { get; set; } = new List<LineaOrdenPreparacion>();
        public bool TomadaPreparacion { get; set; }
        public int Bultos { get; set; }
        public DateTime? FechaEmpaquetado { get; set; }
    }
}
