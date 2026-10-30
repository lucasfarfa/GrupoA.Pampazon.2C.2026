using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class DepositoAlmacen
    {
        // Los enums se guardan con su nombre en el JSON, no con su número.
        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        // Expone una lista de DepositoEntidad
        public static List<DepositoEntidad> Depositos { get; private set; }
        static DepositoAlmacen()
        {
            if (File.Exists(@"Datos\Deposito.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\Deposito.json");
                Depositos = JsonSerializer.Deserialize<List<DepositoEntidad>>(contenido, Opciones) ?? new List<DepositoEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo Deposito.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(Depositos, Opciones);
            File.WriteAllText(@"Datos\Deposito.json", contenido);
        }
    }
}
