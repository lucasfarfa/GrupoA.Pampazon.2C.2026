<<<<<<< Updated upstream
=======
using AdministracionDeposito;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion;
using GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion;
>>>>>>> Stashed changes
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
            Application.Run(new FrmMenuPrincipal());
            //Application.Run(new FrmRegistrarOrdenPreparacion());

<<<<<<< Updated upstream
    }
=======
            // Inicia el menú principal por defecto
            Application.Run(new MenuPrincipalForm());

            Application.Run(new RegistrarOrdenPreparacionForm());

        }
>>>>>>> Stashed changes
    }
}