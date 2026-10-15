using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega
{
    public class GrupoOPModel
    {
        public string Cliente { get; set; }
        public string Transportista { get; set; }
        public DateTime FechaRetiro { get; set; }
        public int CantidadOP { get; set; }
    }

    internal class GenerarOrdenDeEntregaModelo
    {
        private static readonly List<GrupoOPModel> _pendientes = new List<GrupoOPModel>
        {
            new GrupoOPModel { Cliente = "Mercadito S.A.", Transportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 20), CantidadOP = 2 },
            new GrupoOPModel { Cliente = "Mercadito S.A.", Transportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 21), CantidadOP = 1 },
            new GrupoOPModel { Cliente = "MundoFOX S.R.L.", Transportista = "Jose Gomez", FechaRetiro = new DateTime(2026, 10, 20), CantidadOP = 1 }
        };

        private static int _ultimoNumero = 700;

        public List<GrupoOPModel> ObtenerGruposPendientes()
        {
            return _pendientes.ToList();
        }

        public bool GenerarOE(List<GrupoOPModel> gruposSeleccionados, out List<string> resumenGeneradas)
        {
            resumenGeneradas = new List<string>();

            if (gruposSeleccionados == null || gruposSeleccionados.Count == 0)
                return false;

            foreach (var grupo in gruposSeleccionados)
            {
                _ultimoNumero++;
                string numeroOE = _ultimoNumero.ToString();
                resumenGeneradas.Add($"Orden de entrega N° {numeroOE} generada para {grupo.Cliente} (Transportista: {grupo.Transportista}, Retiro: {grupo.FechaRetiro:dd/MM/yyyy})");

                _pendientes.Remove(grupo);
            }

            return true;
        }
    }
}