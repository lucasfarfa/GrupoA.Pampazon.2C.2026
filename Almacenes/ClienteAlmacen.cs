using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class ClienteAlmacen
    {
        // Expone una lista de ClienteEntidad
        public static List<ClienteEntidad> Clientes { get; private set; }
        static ClienteAlmacen()
        {
            if (File.Exists(@"Datos\Cliente.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\Cliente.json");
                Clientes = JsonSerializer.Deserialize<List<ClienteEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }) ?? new List<ClienteEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo Cliente.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(Clientes, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\Cliente.json", contenido);
        }
    }
}
