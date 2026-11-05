using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupoA.PampazonSA.AdministracionDeposito.Almacenes
{
    static class DepositoAlmacen
    {
        // Expone una lista de DepositoEntidad
        public static List<DepositoEntidad> Depositos { get; private set; }

        // Depósito elegido en el menú principal; las pantallas leen de acá en qué depósito trabajan.
        public static string IdDepositoActivo { get; set; } = "GBA";
        static DepositoAlmacen()
        {
            if (File.Exists(@"Datos\Deposito.json"))
            {
                // Load
                string contenido = File.ReadAllText(@"Datos\Deposito.json");
                Depositos = JsonSerializer.Deserialize<List<DepositoEntidad>>(contenido, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }) ?? new List<DepositoEntidad>();
            }
            else // no existe...
            {
                // ni me complico tiro una ex
                throw new ApplicationException($"No se encuentra el archivo Deposito.json");
            }
        }

        public static void Guardar()
        {
            string contenido = JsonSerializer.Serialize(Depositos, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
            File.WriteAllText(@"Datos\Deposito.json", contenido);
        }
    }
}
