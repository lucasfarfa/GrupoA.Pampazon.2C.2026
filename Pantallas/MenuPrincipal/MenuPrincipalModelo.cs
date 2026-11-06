using GrupoA.PampazonSA.AdministracionDeposito.Almacenes;

namespace GrupoA.PampazonSA.AdministracionDeposito.MenuPrincipal
{
    // Modelo del menú principal: expone los depósitos del almacén y guarda el elegido.
    internal class MenuPrincipalModelo
    {
        // Códigos de los depósitos de Deposito.json, para cargar el combo.
        public List<string> Depositos => DepositoAlmacen.Depositos.Select(d => d.IdDeposito).ToList();

        // Depósito elegido en el menú; "" hasta que se elige uno.
        public string DepositoSeleccionado { get; private set; } = "";

        // Regla: el depósito tiene que existir en Deposito.json.
        public bool ExisteDeposito(string idDeposito) => Depositos.Contains(idDeposito);

        // Deja el depósito elegido como depósito activo para las pantallas.
        public bool SeleccionarDeposito(string idDeposito)
        {
            if (!ExisteDeposito(idDeposito)) return false;

            DepositoSeleccionado = idDeposito;
            DepositoAlmacen.IdDepositoActivo = idDeposito;
            return true;
        }
    }
}
