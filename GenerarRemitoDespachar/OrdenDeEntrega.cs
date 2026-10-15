using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar
{
    internal class OrdenDeEntrega
    {
        public string NroOE {  get; set; }
        public string Cliente { get; set; }
        public string OrdenesPreparacion { get; set; }
        public int Bultos { get; set; }
        public string DniTransportista { get; set; }
        public string Estado { get; set; }
    }
}
