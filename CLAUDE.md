# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Proyecto

Prototipo académico (Grupo A, 2C 2026) de un sistema de administración de depósito para "Pampazon S.A.". Es una aplicación de escritorio **WinForms** en C# (`net10.0-windows`, `Nullable` e `ImplicitUsings` habilitados). Todo el dominio, la UI y los comentarios están en español; mantener esa convención al nombrar clases, controles y mensajes. Son prototipos de pantallas con datos inventados, no casos reales.

## Comandos

```bash
dotnet build GrupoA.PampazonSA.AdministracionDeposito.slnx
dotnet run --project GrupoA.PampazonSA.AdministracionDeposito.csproj
```

No hay proyecto de tests ni linter configurado. Las pruebas son manuales, siguiendo el plan de pruebas de cada pantalla.

## Arquitectura

Un único proyecto. Cada **caso de uso** vive en su propia carpeta y namespace (`GrupoA.PampazonSA.AdministracionDeposito.<CasoDeUso>`):

- `<CasoDeUso>Form.cs` — la pantalla: validaciones de entrada y actualización de controles.
- `<CasoDeUso>Form.Designer.cs` — generado por el diseñador de VS. **Las pantallas no se modifican bajo ningún concepto**: no se cambian controles, textos, columnas, tamaños ni propiedades. El Designer solo se toca para suscribir eventos (líneas `+=`); si se borra un manejador del `.cs`, borrar también su suscripción acá o el diseñador falla. Si el CU o el plan piden algo que la pantalla no tiene, se ajustan el CU y el plan, nunca la pantalla.
- `<CasoDeUso>Modelo.cs` — lógica de negocio y datos de prueba hardcodeados en memoria. Las clases de dominio de la pantalla van en archivos aparte dentro de la carpeta (p. ej. `GenerarRemitoDespachar/Remito.cs`). Los casos de uso no comparten modelo ni clases entre sí.
- **Prohibido usar clases de otras carpetas.** Si hace falta una clase que ya existe en otro caso de uso (p. ej. `Transportista` o `Cliente` de `GenerarRemitoDespachar`), se crea de nuevo en la carpeta de la pantalla actual, con su namespace.
- **Se trabaja exclusivamente en la pantalla indicada** por el usuario (su carpeta), salvo que diga lo contrario. No se tocan otras pantallas, ni el menú, ni `Program.cs`.
- **El código previo de una pantalla no es confiable** (viene de otro desarrollador y de versiones preliminares): se revisa contra el CU y el plan y se reescribe si hace falta; no se toma como referencia.
- Documentación de la pantalla en la misma carpeta: el caso de uso (`CU-XX_<nombre>.md`) y el plan de pruebas (`Plan pruebas <nombre>.xlsx`).

`MenuPrincipalForm` tiene un botón por pantalla que la abre con `ShowDialog()`. `Program.cs` arranca directamente el formulario que se está probando; cambiar su `Application.Run(...)` según haga falta.

## Forma de desarrollar (reglas del profesor)

La referencia de este patrón es `GenerarRemitoDespachar`: es **la** pantalla modelo del comportamiento form ↔ modelo que se busca. Ante cualquier duda de patrón (validaciones en el form, `if (!_modelo.X()) return;`, `RefrescarListas()`, `Tag` con la clave, `FormClosing`, estado en el modelo, datos `static`), se hace lo que hace esa pantalla. Las pantallas más viejas (`RegistrarOrdenPreparacion`, `PrepararProductos`) usan otro estilo (validación en el modelo, métodos que devuelven `string` de error): no tomarlas como modelo.

**Form**
- Valida **todas** las entradas de datos (formato, campos vacíos, nada seleccionado en una lista, confirmaciones OK/Cancelar) antes de llamar al modelo.
- Todo cambio se envía al modelo. El modelo responde `bool`: solo si devuelve `true` se actualiza la pantalla. Patrón: `if (!_modelo.Accion(...)) return;` y después refrescar.
- Las listas se recargan siempre desde lo que devuelve el modelo (un método `RefrescarListas()`), no se agregan ni quitan ítems a mano.
- **Nunca se envían controles al modelo** (ni `TextBox`, ni `DateTimePicker`, ni `ListViewItem`). Solo datos nativos (`int`, `string`, `DateTime`, `List<string>`) o clases que contengan solo esos tipos. Para identificar un ítem de un `ListView`, guardar su clave (`string`) en `item.Tag` y enviar esa clave.
- **El único campo del form es `_modelo`.** No guardar estado de la pantalla en variables del form (p. ej. el DNI buscado o la selección): ese estado vive en el modelo. Las variables locales dentro de un método están bien.

**Modelo**
- No conoce WinForms. Expone métodos que devuelven `bool` (con `out` para los datos que el form necesita mostrar) y métodos `Obtener...()` que devuelven listas para cargar la pantalla.
- Datos de prueba en campos `static` para que se mantengan entre aperturas de la pantalla; el estado propio de la pantalla (selección, entidad buscada) en campos de instancia.
- Si un caso "no debería pasar nunca" en el prototipo, no inventar manejo: el modelo devuelve `false` y el form hace `return`.

**Alcance**
- Implementar solo lo pedido. No agregar mensajes, `Focus()`, limpiezas de controles ni validaciones que no estén en el CU o el plan de pruebas.
- Lo que falte definir se marca con `// TODO` y `return`, sin inventar comportamiento.
- Lo que el prototipo no hace a propósito (imprimir, usuarios, movimientos de stock, detalle de mercadería, etc.) **no** lleva TODO: se omite.
- Los mensajes al usuario se copian textuales del plan de pruebas / CU.

## CU, plan de pruebas y código alineados

- Ante diferencias, **el plan de pruebas es la fuente de verdad**; después se ajustan el CU y el código para que digan lo mismo (pasos, excepciones, textos de mensajes y numeración).
- Si se saca una prueba del plan (p. ej. por no ser reproducible en el prototipo), sacarla también del CU y del código.
- Si el CU describe algo que la pantalla no tiene (p. ej. mostrar el depósito), se saca o ajusta en el CU (la pantalla no se modifica); no dejarlos distintos.
- Los comentarios del código que citan pasos del CU (`// CU-07, 4.2`) deben actualizarse si cambia la numeración.
- Los datos de prueba del modelo pueden diferir de los del plan (p. ej. otros nombres y DNI de transportistas); en ese caso la planilla se actualiza con los datos del modelo.
- La planilla `.xlsx` la edita el usuario. Para leerla no hay `openpyxl` instalado: abrir el `.xlsx` como zip y parsear `xl/sharedStrings.xml` y `xl/worksheets/sheet*.xml` con la librería estándar de Python.
- El plan de pruebas tambien puede venir en formato markdown.
- `Plan_de_prueba_general.md` (en la raíz) reúne las hojas A a G y los datos base comunes. Leerlo para mantener la coherencia entre pantallas (qué estados deja la anterior y qué espera la siguiente). **No se modifica**: si el plan de una pantalla cambia o queda inconsistente con el general, avisar al programador (quien está usando Claude) que lo consulte con "LUCAS FARFALLINI".

## Particularidades

- `MenuPrincipal` usa el namespace `OrdenesPreparacion` (inconsistente con el resto) y `EmpaquetarProductos` usa `...CU04EmpaquetarProductos`.
- La carpeta `.vs/` está versionada en git aunque figura en `.gitignore`; no agregar cambios de esos archivos en los commits.
- Se trabaja con una rama por pantalla/prototipo (p. ej. `protitipo/generar-remito-despachar`) y PRs contra `main`.
