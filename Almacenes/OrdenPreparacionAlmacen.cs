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
        public static List<OrdenPreparacionEntidad> OrdenesPreparacion { get; private set; }
        static OrdenPreparacionAlmacen()
        {
            if (File.Exists(@"Datos\OrdenPreparacion.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\OrdenPreparacion.json");
                OrdenesPreparacion = JsonSerializer.Deserialize<List<OrdenPreparacionEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }) ?? new List<OrdenPreparacionEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo OrdenPreparacion.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(OrdenesPreparacion, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\OrdenPreparacion.json", contenido);
        }
    }
}
