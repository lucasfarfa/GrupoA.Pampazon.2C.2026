using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class OrdenPreparacionAlmacen
    {
        // Expone una lista de OrdenPreparacionEntidad
        public static List<OrdenPreparacionEntidad> OrdenesPreparacion { get; private set; } = new List<OrdenPreparacionEntidad>();

        static OrdenPreparacionAlmacen()
        {
            Recargar();
        }

        public static void Recargar()
        {
            if (!File.Exists(@"Datos\OrdenPreparacion.json")) return;

            string contenido = File.ReadAllText(@"Datos\OrdenPreparacion.json");
            var desdeDisco = JsonSerializer.Deserialize<List<OrdenPreparacionEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
            if (desdeDisco == null) return;

            foreach (var opDisco in desdeDisco)
            {
                var opMemoria = OrdenesPreparacion.FirstOrDefault(o => o.NroOP == opDisco.NroOP);
                if (opMemoria != null)
                {
                    opMemoria.TomadaPreparacion = opDisco.TomadaPreparacion;
                    opMemoria.Estado = opDisco.Estado;
                    opMemoria.Bultos = opDisco.Bultos;
                    opMemoria.FechaEmpaquetado = opDisco.FechaEmpaquetado;
                }
                else
                {
                    OrdenesPreparacion.Add(opDisco);
                }
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(OrdenesPreparacion, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\OrdenPreparacion.json", contenido);
        }
    }
}
