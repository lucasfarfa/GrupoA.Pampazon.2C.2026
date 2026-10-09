using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoA.PampazonSA.AdministracionDeposito.PrepararProductos
{
    // Modelo sencillo: OrdenSeleccion -> varias OrdenPreparacion -> varios Producto
    // Nivel: junior. Solo datos, sin referencias a controles de UI.
    public class PrepararProductosModelo
    {
        public List<OrdenSeleccion> OrdenesSeleccion { get; } = new List<OrdenSeleccion>();

        public PrepararProductosModelo()
        {
            CargarDatosPrueba();
        }

        // Expose lookup helpers for the UI layer
        public OrdenPreparacion GetOrdenPreparacionById(string opId)
        {
            return FindOrdenPreparacion(opId);
        }

        public OrdenSeleccion GetOrdenSeleccionById(string osId)
        {
            if (osId == null) return null;
            return OrdenesSeleccion.FirstOrDefault(os => os.Id == osId);
        }

        // Datos de prueba simples para prototipo
        public void CargarDatosPrueba()
        {
            OrdenesSeleccion.Clear();

            var os1 = new OrdenSeleccion("OS-000001", "Orden seleccion 1");
            os1.OrdenesPreparacion.Add(new OrdenPreparacion("OP-0000001", "Cliente A", "SELECCIONADA"));
            os1.OrdenesPreparacion.Add(new OrdenPreparacion("OP-0000002", "Cliente B", "SELECCIONADA"));

            var os2 = new OrdenSeleccion("OS-000002", "Orden seleccion 2");
            os2.OrdenesPreparacion.Add(new OrdenPreparacion("OP-0000003", "Cliente C", "SELECCIONADA"));
            os2.OrdenesPreparacion.Add(new OrdenPreparacion("OP-0000004", "Cliente D", "SELECCIONADA"));

            // Productos asociados (simples)
            os1.OrdenesPreparacion[0].Productos.AddRange(new[] {
                new Producto("SKU-0000001","Teclado",10,"X0-Y1-Z2"),
                new Producto("SKU-0000002","Mouse",10,"X3-Y4-Z5"),
                new Producto("SKU-0000003","Usb",10,"X6-Y7-Z8")
            });

            os1.OrdenesPreparacion[1].Productos.AddRange(new[] {
                new Producto("SKU-0000004","Monitor",5,"X9-Y12-Z22"),
                new Producto("SKU-0000005","Motherboard",2,"X20-Y21-Z22")
            });

            os2.OrdenesPreparacion[0].Productos.AddRange(new[] {
                new Producto("SKU-0000006","CPU AMD",3,"X30-Y51-Z42")
            });

            os2.OrdenesPreparacion[1].Productos.AddRange(new[] {
                new Producto("SKU-0000007","CPU INTEL",1,"X40-Y41-Z42"),
                new Producto("SKU-0000008","Fuente X Watts",2,"X40-Y41-Z82")
            });

            OrdenesSeleccion.Add(os1);
            OrdenesSeleccion.Add(os2);
        }

        // Selecciona todas las OPs que estén en estado SELECCIONADA
        public void SeleccionarTodasOrdenesPendientes()
        {
            foreach (var op in OrdenesSeleccion.SelectMany(os => os.OrdenesPreparacion))
            {
                if (string.Equals(op.Estado, "SELECCIONADA", StringComparison.OrdinalIgnoreCase))
                {
                    op.IsSelected = true;
                }
            }
        }

        // Limpia selección de todas las OPs
        public void LimpiarSeleccionDeOrdenesPendientes()
        {
            foreach (var op in OrdenesSeleccion.SelectMany(os => os.OrdenesPreparacion))
            {
                op.IsSelected = false;
            }
        }

        // Iniciar picking para una OP (pasa SELECCIONADA -> EN_PROCESO)
        public bool IniciarPicking(string opId)
        {
            var op = FindOrdenPreparacion(opId);
            if (op == null) return false;
            if (!string.Equals(op.Estado, "SELECCIONADA", StringComparison.OrdinalIgnoreCase)) return false;
            op.Estado = "EN_PROCESO";
            return true;
        }

        // Finalizar picking para una OP (pasa EN_PROCESO -> PICKEADA) y actualiza su OS
        public bool FinalizarPicking(string opId)
        {
            var (op, _) = FindOrdenPreparacionWithParent(opId);
            if (op == null) return false;
            if (!string.Equals(op.Estado, "EN_PROCESO", StringComparison.OrdinalIgnoreCase)) return false;
            op.Estado = "PICKEADA";

            // Note: Do not auto-mark the parent OS as CUMPLIDA here.
            // The UI/user must explicitly close the OrdenSeleccion when ready.

            return true;
        }

        // Cambia estado manualmente (útil para pruebas)
        public bool CambiarEstadoOp(string opId, string nuevoEstado)
        {
            var op = FindOrdenPreparacion(opId);
            if (op == null) return false;
            op.Estado = nuevoEstado ?? op.Estado;
            return true;
        }

        // Valida si todas las OPs (en todas las OS) están PICKEADA
        public bool ValidarTodosCumplidos()
        {
            var allOps = OrdenesSeleccion.SelectMany(os => os.OrdenesPreparacion).ToList();
            if (allOps.Count == 0) return false;
            return allOps.All(op => string.Equals(op.Estado?.Trim(), "PICKEADA", StringComparison.OrdinalIgnoreCase));
        }

        // Obtener productos asociados a una OP
        public List<Producto> GetProductosParaOp(string opId)
        {
            var op = FindOrdenPreparacion(opId);
            if (op == null) return new List<Producto>();
            return op.Productos.Select(p => new Producto(p.Sku, p.Nombre, p.Cantidad, p.Ubicacion)).ToList();
        }

        // Alterna la selección de una OP
        public bool ToggleSeleccionOp(string opId)
        {
            var op = FindOrdenPreparacion(opId);
            if (op == null) return false;
            op.IsSelected = !op.IsSelected;
            return true;
        }

        // Helper: buscar OP
        private OrdenPreparacion FindOrdenPreparacion(string opId)
        {
            if (opId == null) return null;
            foreach (var os in OrdenesSeleccion)
            {
                var op = os.OrdenesPreparacion.FirstOrDefault(x => x.Id == opId);
                if (op != null) return op;
            }
            return null;
        }

        // Helper: buscar OP y su OS padre
        private (OrdenPreparacion op, OrdenSeleccion parent) FindOrdenPreparacionWithParent(string opId)
        {
            if (opId == null) return (null, null);
            foreach (var os in OrdenesSeleccion)
            {
                var op = os.OrdenesPreparacion.FirstOrDefault(x => x.Id == opId);
                if (op != null) return (op, os);
            }
            return (null, null);
        }
    }

    public class OrdenSeleccion
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        // Estados: PENDIENTE (inicial), CUMPLIDA
        public string Estado { get; set; }
        public List<OrdenPreparacion> OrdenesPreparacion { get; } = new List<OrdenPreparacion>();

        public OrdenSeleccion(string id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            Estado = "PENDIENTE";
        }
    }

    public class OrdenPreparacion
    {
        public string Id { get; set; }
        public string Cliente { get; set; }
        // Estados: SELECCIONADA (inicial), EN_PROCESO, PICKEADA
        public string Estado { get; set; }
        public bool IsSelected { get; set; }
        public List<Producto> Productos { get; } = new List<Producto>();

        public OrdenPreparacion(string id, string cliente, string estado)
        {
            Id = id;
            Cliente = cliente;
            Estado = estado;
            IsSelected = false;
        }
    }

    public class Producto
    {
        public string Sku { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public string Ubicacion { get; set; }

        public Producto(string sku, string nombre, decimal cantidad, string ubicacion)
        {
            Sku = sku;
            Nombre = nombre;
            Cantidad = cantidad;
            Ubicacion = ubicacion;
        }
    }
}
