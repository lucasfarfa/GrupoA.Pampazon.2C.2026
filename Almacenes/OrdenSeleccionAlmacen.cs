using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class OrdenSeleccionAlmacen
    {
        // Expone una lista de OrdenSeleccionEntidad
        public static List<OrdenSeleccionEntidad> OrdenesSeleccion { get; private set; }
        static OrdenSeleccionAlmacen()
        {
            if (File.Exists(@"Datos\OrdenSeleccion.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\OrdenSeleccion.json");
                OrdenesSeleccion = JsonSerializer.Deserialize<List<OrdenSeleccionEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }) ?? new List<OrdenSeleccionEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo OrdenSeleccion.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(OrdenesSeleccion, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\OrdenSeleccion.json", contenido);
        }
    }
}
