# CLAUDE.md

Guía para Claude Code (claude.ai/code) u otros agentes que trabajen en este repositorio. Se versiona en el repo para que todo el grupo trabaje con las mismas reglas.

## REGLA FUERTE (pedido del profesor)

**La firma de los métodos públicos de los modelos hacia los formularios no puede
cambiar.** Nombres, parámetros, tipos de retorno, propiedades públicas y
constructores quedan exactamente como están. Los miembros privados del modelo se
pueden cambiar libremente: son auxiliares y nadie más los ve.

## RESTRICCIÓN ESTRICTA – CODIFICACIÓN FINAL TP CAI

Esta restricción manda sobre cualquier otra indicación de este archivo, salvo las
excepciones aprobadas que figuran debajo.

ÚNICO alcance permitido:
- Modificar el funcionamiento INTERNO de la clase Modelo de la pantalla asignada.
- Crear las clases Entidad, Enum y Almacén (JSON) definidas en el diagrama de
  clases aprobado, sin agregar ni quitar atributos.

PROHIBIDO:
1. Modificar cualquier Form (designer, code-behind, controles, eventos).
2. Modificar la interfaz pública del Modelo: nombres, firmas y tipos de retorno
   de métodos públicos, propiedades públicas y constructores.
3. Modificar las clases que el Modelo recibe o devuelve al Form.
4. Modificar el Modelo de otra pantalla.
5. Fusionar Modelos, crear un Modelo común o compartir estado entre Modelos
   (static compartido, referencias cruzadas). La única comunicación entre
   pantallas es a través de los almacenes.
6. Hacer que una pantalla dependa de otra.
7. Modificar Program.cs o cualquier archivo fuera del Modelo, salvo las
   entidades y almacenes nuevos. Única excepción en Program.cs: invocar el
   método Guardar() de cada almacén.
8. Apartarse del diagrama de clases aprobado (nombres, tipos, relaciones).
9. Crear almacenes para clases auxiliares (LineaOrdenPreparacion,
   LineaOrdenSeleccion, PosicionDeposito, CantidadPorPosicion): van dentro de
   su entidad.
10. Corregir supuestos errores de etapas previas (CU, diagramas, pantallas,
    plan de pruebas) sin validarlos antes con el profesor.

EXCEPCIONES APROBADAS POR EL PROFESOR (revisión del 05/11/2026):
- Depósito activo: `DepositoAlmacen` tiene
  `public static string IdDepositoActivo { get; set; }`. Es el ÚNICO estado
  `static` compartido permitido.
- `MenuPrincipalForm.cs` (code-behind, no el Designer) se puede modificar SOLO
  para setear `DepositoAlmacen.IdDepositoActivo` antes de abrir cada pantalla.
  El menú no lleva modelo.
- Los modelos leen el depósito desde `DepositoAlmacen.IdDepositoActivo` en su
  parte privada, sin cambiar sus firmas públicas.
- `RegistrarOrdenPreparacion` NO usa el depósito del menú: el operario elige el
  depósito en su propio combo (`SeleccionarDeposito`).

FORMA DE TRABAJO CON LA IA:
- Se migra a los almacenes de a UNA pantalla por vez.
- La IA NO commitea. El programador revisa el diff (Git Changes → Comparar con
  la versión sin modificar) y verifica que no cambió ninguna firma pública, que
  solo se tocó la conexión del modelo con los almacenes y que no se perdió
  ninguna validación. Recién ahí se commitea.
- Si la IA dice "no puedo hacer esto porque…", no se le hace caso de una: se
  consulta primero con el profesor.

ANTE CUALQUIER DUDA:
Si algo no puede resolverse dentro del Modelo, NO busques un atajo.
Frená, explicá el problema y preguntá.

## Proyecto

Prototipo académico (Grupo A, 2C 2026) de un sistema de administración de depósito para "Pampazon S.A.". Es una aplicación de escritorio **WinForms** en C# (`net10.0-windows`, `Nullable` e `ImplicitUsings` habilitados). Todo el dominio, la UI y los comentarios están en español; mantener esa convención al nombrar clases, controles y mensajes. Son prototipos de pantallas con datos inventados, no casos reales.

## Comandos

```bash
dotnet build GrupoA.PampazonSA.AdministracionDeposito.slnx
dotnet run --project GrupoA.PampazonSA.AdministracionDeposito.csproj
```

No hay proyecto de tests ni linter. Las pruebas son manuales, siguiendo el plan de pruebas de cada pantalla.

## Arquitectura

Un único proyecto. Cada **caso de uso** vive en su propia carpeta dentro de `Pantallas/` y namespace (`GrupoA.PampazonSA.AdministracionDeposito.<CasoDeUso>`). Pantallas actuales: `RegistrarOrdenPreparacion` (CU-01), `GenerarOrdenSeleccion`, `PrepararProductos`, `EmpaquetarProductos`, `GenerarOrdenEntrega` (CU-05), `RecepcionarOrdenEntrega` (CU-06), `GenerarRemitoDespachar` y `MenuPrincipal`.

Archivos de cada caso de uso:

- `<CasoDeUso>Form.cs` — la pantalla: validaciones de entrada y actualización de controles.
- `<CasoDeUso>Form.Designer.cs` — generado por el diseñador de VS. **Las pantallas no se modifican bajo ningún concepto**: no se cambian controles, textos, columnas, tamaños ni propiedades. El Designer solo se toca para suscribir eventos (líneas `+=`); si se borra un manejador del `.cs`, borrar también su suscripción acá o el diseñador falla. Si el CU o el plan piden algo que la pantalla no tiene, se ajustan el CU y el plan, nunca la pantalla.
- `<CasoDeUso>Modelo.cs` — lógica de negocio y datos de prueba hardcodeados en memoria. Las clases de dominio de la pantalla van en archivos aparte dentro de la carpeta (p. ej. `Pantallas/GenerarRemitoDespachar/Remito.cs`).
- Documentación en la misma carpeta (donde exista): el caso de uso (`CU-XX_<nombre>.md`) y el plan de pruebas (`Plan_de_prueba_CU-XX.md`, o `Plan pruebas <nombre>.xlsx`).

Reglas de alcance:

- **Los casos de uso no comparten modelo ni clases.** Está prohibido usar clases de otras carpetas: si hace falta una que ya existe en otro caso de uso (p. ej. `Transportista`, `Cliente`, `OrdenPreparacion`), se crea de nuevo en la carpeta de la pantalla actual, con su namespace. Nunca agregar `using` hacia namespaces de otros casos de uso.
- **Se trabaja exclusivamente en la pantalla indicada** por el usuario (su carpeta), salvo que diga lo contrario. No se tocan otras pantallas, ni el menú, ni `Program.cs`. Antes de editar un archivo, verificar que esté en la carpeta de la pantalla actual.
- **El código previo de una pantalla no es confiable** (viene de otro desarrollador y de versiones preliminares): se lee, pero se diseña desde el CU y el plan, y se reescribe si hace falta. No se toma como referencia.

`MenuPrincipalForm` tiene un botón por pantalla que la abre con `ShowDialog()`. `Program.cs` arranca el menú principal; no se modifica (solo se le cambió el `using` del namespace del menú).

## Forma de desarrollar (reglas del profesor)

La referencia de este patrón es `GenerarRemitoDespachar`: es **la** pantalla modelo del comportamiento form ↔ modelo que se busca. Ante cualquier duda de patrón (`if (!_modelo.X()) return;`, `RefrescarListas()`, `Tag` con la clave, `FormClosing`, estado en el modelo), se hace lo que hace esa pantalla — copiando el patrón, nunca sus clases. **Excepción (corrección del profesor):** en esa pantalla las validaciones de negocio todavía están en el form y el DNI es `string`; en eso no es referencia: mandan las reglas de "Tipos de datos" y "Validaciones" de abajo. Las pantallas más viejas (`RegistrarOrdenPreparacion`, `PrepararProductos`) usan otro estilo (métodos que devuelven `string` de error): no tomarlas como modelo.

El código es de muchas funciones chiquitas. Al profesor no le gusta, pero pidió explícitamente **no cambiar esa estructura**: no fusionar ni reorganizar métodos por estilo.

**Tipos de datos (según el negocio, no "lo más cómodo")**
- Cada dato lleva el tipo que le corresponde en el negocio, en las clases de datos, en las propiedades del modelo y en los parámetros de sus métodos.
- Criterio: si el dato se usa para **identificar, buscar, comparar, ordenar o calcular**, lleva su tipo real. Si es **solo informativo** (se muestra y nadie opera con él, p. ej. un teléfono de contacto), puede ser `string`.
- Un número nunca se guarda como `string`. `string` para un código solo si es alfanumérico de verdad, y hay que poder justificarlo.
- Ejemplos de este negocio:
  - **DNI** (transportista, etc.): `int`. Se usa para identificar y buscar.
  - **N° de OP, OS, OE**: `int`. Son correlativos numéricos que genera el sistema (`List<int> NrosOP`, `out int nroOP`, `item.Tag` guarda el `int`).
  - **N° de remito**: `int`. También es un correlativo del sistema; el prefijo "R-" es solo cómo se muestra y lo agrega el form (`"R-" + remito.NroRemito`).
  - **Estados**: un `enum` por entidad (`EstadoOrdenPreparacion`, `EstadoOrdenSeleccion`, `EstadoOrdenEntrega`, `EstadoRemito`) en un archivo propio de cada carpeta, solo con los valores que usa esa pantalla (más adelante va a haber un único enum compartido). Nada de `const string` para estados.
  - **CUIT**: `long` si se usa para identificar al cliente (11 dígitos no entran en `int`); si es solo informativo, `string`.
  - **Cliente**: si se agrupa, busca o compara por cliente, es un objeto `Cliente` (`long Cuit`, `string Nombre`) y se identifica por `Cuit`; el nombre es solo para mostrar y ordenar (p. ej. `GenerarOrdenEntrega(long cuitCliente, ...)`, `GroupBy(oe => oe.Cliente.Cuit)`). Para que el diagrama de clases sea uniforme, el cliente de una orden es `Cliente` en todas las pantallas, aunque solo se muestre; un filtro de texto libre busca en `Cliente.Nombre` (`Contains`).
  - **Modalidad**: `enum Modalidad { Fulfillment, PaletCerrado }` en un archivo propio de cada carpeta que la use. El texto visible ("Palet cerrado") lo arma el form con un método `TextoModalidad(...)`; si el usuario la escribe o elige en un combo, el form convierte el texto al enum y avisa si no coincide.
  - **Depósito**: código `string` ("GBA", "ROS", "CBA", "MDZ"): es un dato maestro alfanumérico que puede crecer, no un `enum`. El menú pasa el código (no el texto visible del combo) y el modelo lo valida con `SeleccionarDeposito(string)` contra su lista de depósitos.
  - **Nombres comunes entre pantallas**: el cliente de una orden es `Cliente Cliente`; los renglones de una orden se llaman `Lineas`; `FechaEmision` es cuando se crea un documento y `FechaCumplida` cuando se cierra (la OP conserva `FechaRecepcion`, `FechaRetiro` y `FechaEmpaquetado`).
  - Cualquier otro dato con un conjunto fijo de valores que se use para decidir o filtrar va como `enum`, no como `string` ni `const string`.
  - Cantidades y bultos: `int`. Fechas: `DateTime`.
- Ante un dato cuyo tipo no se pueda deducir sin conocer el negocio, preguntar al usuario antes de elegir.

**Validaciones (van en el modelo)**
- **Todo lo que se pueda validar en el modelo, va al modelo**: rangos y formatos de negocio (p. ej. DNI de 7 u 8 dígitos = entre 1.000.000 y 99.999.999), campos de texto vacíos, listas vacías, existencia de entidades, estados permitidos.
- **En el form queda solo lo que obligan los tipos**: convertir el texto del control al tipo correcto (`int.TryParse`, etc.) y avisar si la conversión falla, para pasarle al modelo el tipo correcto. También quedan en el form las confirmaciones OK/Cancelar (son interacción con el usuario).
- **Cómo se entera el form del mensaje:** el modelo expone **métodos de validación** que devuelven `bool`, uno por regla (p. ej. `public bool DniValido(int dni)`, `public bool ExisteTransportista(int dni)`, `public bool HayOrdenes(List<int> nrosOE)`). El form llama a cada uno antes de la acción y, si da `false`, muestra el mensaje textual del plan y hace `return`. El texto del mensaje vive en el form; la regla, en el modelo.
- En una lista de **selección simple** (`MultiSelect = false`), "no hay nada seleccionado" queda en el form: no hay ningún dato para convertir ni para enviarle al modelo. En una lista de selección múltiple, el form arma la lista de claves y el modelo valida que no esté vacía (p. ej. `HayOrdenes(nrosOE)`).
- El método de acción **vuelve a validar** lo que necesita (no confía en que el form llamó a las validaciones) y devuelve `false` si algo no se cumple. Es el método que el profesor mira primero: tiene que recibir parámetros de tipos correctos y contener sus validaciones.

Ejemplo:
```csharp
// Form
if (!int.TryParse(textDNITransportista.Text.Trim(), out int dni))
{
    MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos", Text);
    return;
}
if (!_modelo.DniValido(dni))
{
    MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos", Text);
    return;
}
if (!_modelo.BuscarTransportista(dni, out Transportista? transportista) || transportista == null) { ... }

// Modelo
public bool DniValido(int dni) => dni >= 1_000_000 && dni <= 99_999_999;

public bool BuscarTransportista(int dni, out Transportista? transportista)
{
    transportista = null;
    if (!DniValido(dni)) return false;
    ...
}
```

**Form**
- Convierte las entradas al tipo correcto y llama a las validaciones del modelo antes de cada acción (ver "Validaciones").
- Todo cambio se envía al modelo. El modelo responde `bool`: solo si devuelve `true` se actualiza la pantalla. Patrón: `if (!_modelo.Accion(...)) return;` y después refrescar.
- Las listas se recargan siempre desde lo que devuelve el modelo (un método `RefrescarListas()`), no se agregan ni quitan ítems a mano.
- **Nunca se envían controles al modelo** (ni `TextBox`, ni `DateTimePicker`, ni `ListViewItem`). Solo datos nativos con su tipo de negocio (`int`, `long`, `string`, `DateTime`, `List<int>`) o clases que contengan solo esos tipos. Para identificar un ítem de un `ListView`, guardar su clave (con su tipo, p. ej. el `int` del N° de OE) en `item.Tag` y enviar esa clave.
- **El único campo del form es `_modelo`.** No guardar estado de la pantalla en variables del form (p. ej. el DNI buscado o la selección): ese estado vive en el modelo. Las variables locales dentro de un método están bien.

**Modelo**
- No conoce WinForms.
- **Propiedades = lo que la pantalla necesita** (listas para cargar, datos a mostrar, estado como `HaySeleccion`): `public List<Remito> RemitosPendientesFirma { get { ... } }`. No usar métodos `Obtener...()` para esto.
- **Métodos = lo que la pantalla hace** (acciones): devuelven `bool`, con `out` solo para el resultado de la acción (p. ej. el N° generado). Patrón: `SeleccionarOrdenes(...)`, `EmitirRemitos()`. Además, los **métodos de validación** `bool` que usa el form (ver "Validaciones").
- Datos de prueba en campos comunes, **sin `static`**: en el prototipo cada pantalla se prueba en una sola apertura, así que los datos pueden volver a su estado inicial al reabrirla. La persistencia en memoria se agrega en una entrega posterior. Sin `static`, un campo no puede usar otro en su inicialización: los objetos compartidos (p. ej. el transportista) se escriben en cada registro.
- Si un caso "no debería pasar nunca" en el prototipo, no inventar manejo: el modelo devuelve `false` y el form hace `return`.

**Clases de datos** (clases auxiliares de la carpeta, p. ej. `Remito`, `OrdenSeleccion`)
- Solo propiedades `get; set;` (los `string` inicializados en `""`). Sin métodos: la lógica va en el modelo de la pantalla.
- **Una propiedad tiene un solo valor, salvo que sea otro objeto.** Nada de varios datos en un `string` (`"101, 102"`, `"cliente|dni"`). Los datos que van juntos forman un objeto: el transportista es `Transportista Transportista` (con `DNI` y `NombreApellido`), no `DniTransportista` + `NombreTransportista` sueltos. Ejemplo del profe: una dirección tiene `Calle`, `Altura` y `Localidad`, y `Localidad` es un objeto con `Nombre` y `Pais`.
- **Muchos objetos o valores van en una lista**: `List<int> NrosOP`, `List<LineaOrden> Lineas`. El texto con comas se arma solo en el form para mostrarlo (`string.Join(", ", oe.NrosOP)`).
- Cada propiedad con el tipo de negocio que le corresponde (ver "Tipos de datos"): `int DNI`, `int NroOP`, no `string`.

**Alcance: solo lo pedido**
- Implementar solo lo pedido. No agregar `MessageBox`, mensajes, `Focus()`, limpiezas de controles ni validaciones que no estén en el CU o el plan de pruebas.
- Lo que falte definir (p. ej. cómo responde la UI ante un DNI inválido o una entidad no encontrada) se marca con `// TODO` y `return`, sin inventar comportamiento.
- Lo que el prototipo no hace a propósito (imprimir, usuarios, movimientos de stock, detalle de mercadería, etc.) **no** lleva TODO: se omite.
- Los mensajes al usuario se copian textuales del plan de pruebas / CU.

## CU, plan de pruebas y código alineados

- Ante diferencias, **el plan de pruebas es la fuente de verdad**; después se ajustan el CU y el código para que digan lo mismo (pasos, excepciones, textos de mensajes y numeración).
- Si se saca una prueba del plan (p. ej. por no ser reproducible en el prototipo), sacarla también del CU y del código.
- Si el CU describe algo que la pantalla no tiene (p. ej. mostrar el depósito), se saca o ajusta en el CU (la pantalla no se modifica); no dejarlos distintos.
- Los comentarios del código que citan pasos del CU (`// CU-07, 4.2`) deben actualizarse si cambia la numeración.
- Los datos de prueba del modelo pueden diferir de los del plan (p. ej. otros nombres y DNI de transportistas); en ese caso la planilla se actualiza con los datos del modelo.
- Los planes vienen en `.xlsx` o en markdown. La planilla `.xlsx` la edita el usuario; para leerla no hay `openpyxl` instalado: abrir el `.xlsx` como zip y parsear `xl/sharedStrings.xml` y `xl/worksheets/sheet*.xml` con la librería estándar de Python.
- `Plan_de_prueba_general.md` (en la raíz) reúne las hojas A a G y los datos base comunes. Leerlo para mantener la coherencia entre pantallas (qué estados deja la anterior y qué espera la siguiente). **No se modifica**: si el plan de una pantalla cambia o queda inconsistente con el general, avisar al programador (quien está usando Claude u otro agente) que lo consulte con "LUCAS FARFALLINI".

## Git y particularidades

- Se trabaja con una rama por pantalla/prototipo (p. ej. `protitipo/generar-remito-despachar`) y PRs contra `main`.
- `CLAUDE.md` se versiona: los cambios de reglas se commitean como cualquier otro archivo.
- Los CU y planes de prueba de las pantallas 01, 05 y 06 se dejaron de versionar; figuran como archivos sin seguimiento (`??`). No agregarlos a los commits salvo pedido expreso.
- `.vs/`, `bin/`, `obj/` y `*.user` figuran en `.gitignore`; no incluir cambios de esos archivos en los commits.
