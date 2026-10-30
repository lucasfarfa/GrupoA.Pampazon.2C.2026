using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class MercaderiaAlmacen
    {
        // Los enums se guardan con su nombre en el JSON, no con su número.
        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        // Expone una lista de MercaderiaEntidad
        public static List<MercaderiaEntidad> Mercaderias { get; private set; }
        static MercaderiaAlmacen()
        {
            if (File.Exists(@"Datos\Mercaderia.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\Mercaderia.json");
                Mercaderias = JsonSerializer.Deserialize<List<MercaderiaEntidad>>(contenido, Opciones) ?? new List<MercaderiaEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo Mercaderia.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(Mercaderias, Opciones);
            File.WriteAllText(@"Datos\Mercaderia.json", contenido);
        }
    }
}
