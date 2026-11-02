using GrupoA.PampazonSA.AdministracionDeposito.EmpaquetarProductos;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenEntrega;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarOrdenSeleccion;
using GrupoA.PampazonSA.AdministracionDeposito.GenerarRemitoDespachar;
using GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos;
using GrupoA.PampazonSA.AdministracionDeposito.RegistrarOrdenPreparacion;
using GrupoA.PampazonSA.AdministracionDeposito.MenuPrincipal;
using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

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

            // Guarda todo al cerrar
            ClienteAlmacen.Guardar();
            DepositoAlmacen.Guardar();
            MercaderiaAlmacen.Guardar();
            OrdenPreparacionAlmacen.Guardar();
            OrdenSeleccionAlmacen.Guardar();
            OrdenEntregaAlmacen.Guardar();
            RemitoAlmacen.Guardar();
        }
    }
}