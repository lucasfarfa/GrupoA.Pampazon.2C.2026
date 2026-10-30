using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class DepositoEntidad
    {
        public string IdDeposito { get; set; } = "";
        public List<PosicionDeposito> Posiciones { get; set; } = new List<PosicionDeposito>();
    }
}
