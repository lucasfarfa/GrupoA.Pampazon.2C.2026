using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class OrdenPreparacionAlmacen
    {
        // Los enums se guardan con su nombre en el JSON, no con su número.
        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        // Expone una lista de OrdenPreparacionEntidad
        public static List<OrdenPreparacionEntidad> OrdenesPreparacion { get; private set; }
        static OrdenPreparacionAlmacen()
        {
            if (File.Exists(@"Datos\OrdenPreparacion.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\OrdenPreparacion.json");
                OrdenesPreparacion = JsonSerializer.Deserialize<List<OrdenPreparacionEntidad>>(contenido, Opciones) ?? new List<OrdenPreparacionEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo OrdenPreparacion.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(OrdenesPreparacion, Opciones);
            File.WriteAllText(@"Datos\OrdenPreparacion.json", contenido);
        }
    }
}
