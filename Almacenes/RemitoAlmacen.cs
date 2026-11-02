using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class RemitoAlmacen
    {
        // Expone una lista de RemitoEntidad
        public static List<RemitoEntidad> Remitos { get; private set; }
        static RemitoAlmacen()
        {
            if (File.Exists(@"Datos\Remito.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\Remito.json");
                Remitos = JsonSerializer.Deserialize<List<RemitoEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }) ?? new List<RemitoEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo Remito.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(Remitos, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\Remito.json", contenido);
        }
    }
}
