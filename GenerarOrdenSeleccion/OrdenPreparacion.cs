using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion
{
    internal class OrdenPreparacion
    {
        public string NroOP { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string Modalidad { get; set; }
        public string Estado { get; set; }
        public List<LineaProducto> Productos { get; set; } = new List<LineaProducto>();
    }

    // Línea de mercadería de una OP; también es la fila del "Resumen consolidado de productos".
    internal class LineaProducto
    {
        public string Sku { get; set; }
        public int Cantidad { get; set; }
    }
}
