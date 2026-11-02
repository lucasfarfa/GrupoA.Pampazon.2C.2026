using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class OrdenEntregaAlmacen
    {
        // Expone una lista de OrdenEntregaEntidad
        public static List<OrdenEntregaEntidad> OrdenesEntrega { get; private set; }
        static OrdenEntregaAlmacen()
        {
            if (File.Exists(@"Datos\OrdenEntrega.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\OrdenEntrega.json");
                OrdenesEntrega = JsonSerializer.Deserialize<List<OrdenEntregaEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }) ?? new List<OrdenEntregaEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo OrdenEntrega.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(OrdenesEntrega, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\OrdenEntrega.json", contenido);
        }
    }
}
