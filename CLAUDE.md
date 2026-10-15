# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Proyecto

Prototipo académico (Grupo A, 2C 2026) de un sistema de administración de depósito para "Pampazon S.A.". Es una aplicación de escritorio **WinForms** en C# (`net10.0-windows`, `Nullable` e `ImplicitUsings` habilitados). Todo el dominio, la UI y los comentarios están en español; mantener esa convención al nombrar clases, controles y mensajes.

## Comandos

```bash
dotnet build GrupoA.PampazonSA.AdministracionDeposito.slnx
dotnet run --project GrupoA.PampazonSA.AdministracionDeposito.csproj
```

No hay proyecto de tests ni linter configurado. Los formularios se diseñan normalmente con el diseñador de Visual Studio.

## Arquitectura

Un único proyecto. Cada **caso de uso** del depósito vive en su propia carpeta y namespace (`GrupoA.PampazonSA.AdministracionDeposito.<CasoDeUso>`), con este patrón:

- `<CasoDeUso>Form.cs` — lógica de la pantalla (manejadores de eventos, binding a controles).
- `<CasoDeUso>Form.Designer.cs` — generado por el diseñador de VS; no editarlo a mano salvo que sea imprescindible. Los controles tienen nombres descriptivos (p. ej. `cboCliente`, `NombreEmpleadoLabel`) que el código del Form referencia.
- `<CasoDeUso>Modelo.cs` — lógica de negocio y **datos de prueba en memoria** (listas/diccionarios estáticos o cargados en el constructor). No hay base de datos ni persistencia: cada modelo es autosuficiente y define sus propias clases de dominio (a veces en el mismo archivo, a veces en archivos aparte dentro de la carpeta, p. ej. `GenerarRemitoDespachar/Remito.cs`).
- El Form instancia su Modelo como campo (`private readonly XModelo _modelo = new();`) y le delega toda validación y cálculo; los métodos del modelo suelen devolver un `string` con el mensaje de error (o null/vacío si salió bien) para que el Form lo muestre en un `MessageBox`.

Los casos de uso no comparten modelo ni clases de dominio entre sí (p. ej. hay distintas representaciones de "orden" y "línea" por carpeta). El flujo del negocio es: Registrar Orden de Preparación → Generar Orden de Selección → Preparar Productos → Empaquetar Productos → Generar Orden de Entrega / Generar Remito y Despachar; además Recepcionar Orden de Entrega.

`RegistrarOrdenPreparacion` y `PrepararProductos` son los casos más completos y sirven de referencia de estilo (por ejemplo, el flag `_cargando` para ignorar eventos de `SelectedIndexChanged` mientras se cargan combos, y `BindingList<T>` para grillas).

## Particularidades

- `Program.cs` arranca directamente el formulario que se está desarrollando (hoy `RegistrarOrdenPreparacionForm`); el `MenuPrincipalForm` está comentado y sus botones aún no navegan. Cambiar el `Application.Run(...)` para probar otra pantalla.
- `MenuPrincipal` usa el namespace `OrdenesPreparacion` (inconsistente con el resto) y `EmpaquetarProductos` usa `...CU04EmpaquetarProductos`.
- La carpeta `.vs/` está versionada en git aunque figura en `.gitignore`; no agregar cambios de esos archivos en los commits.
- Se trabaja con una rama por pantalla/prototipo (p. ej. `protitipo/generar-remito-despachar`) y PRs contra `main`.
