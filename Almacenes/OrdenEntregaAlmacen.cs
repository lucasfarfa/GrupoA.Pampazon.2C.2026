using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class OrdenEntregaAlmacen
    {
        // Los estados se guardan con su nombre en el JSON ("Emitida"), no con su número.
        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        // Expone una lista de OrdenEntregaEntidad
        public static List<OrdenEntregaEntidad> OrdenesEntrega { get; private set; }
        static OrdenEntregaAlmacen()
        {
            if (File.Exists(@"Datos\OrdenEntrega.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\OrdenEntrega.json");
                OrdenesEntrega = JsonSerializer.Deserialize<List<OrdenEntregaEntidad>>(contenido, Opciones) ?? new List<OrdenEntregaEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo OrdenEntrega.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(OrdenesEntrega, Opciones);
            File.WriteAllText(@"Datos\OrdenEntrega.json", contenido);
        }
    }
}
