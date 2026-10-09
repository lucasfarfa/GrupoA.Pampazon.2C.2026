using AdministracionDeposito;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion;
using OrdenesPreparacion;

namespace GrupoA.PampazonSA.AdministracionDeposito
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Inicia el menú principal por defecto
            Application.Run(new MenuPrincipalForm());
       
        }
    }
}