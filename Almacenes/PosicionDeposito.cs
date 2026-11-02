using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    internal class PosicionDeposito
    {
        public int Sector { get; set; }
        public int Posicion { get; set; }
        public int Fila { get; set; }
        public List<CantidadPorPosicion> Contenido { get; set; } = new List<CantidadPorPosicion>();
    }
}
