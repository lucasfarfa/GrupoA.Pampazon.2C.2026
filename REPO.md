# Pampazon S.A. — Administración de Depósito (Grupo A, 2C 2026)

Prototipo de escritorio en **WinForms (C#, .NET 10)** con las pantallas del circuito de un depósito: desde que el cliente pide preparar mercadería hasta que el transportista la retira con el remito firmado. Los datos son inventados y viven en memoria.

```bash
dotnet build GrupoA.PampazonSA.AdministracionDeposito.slnx
dotnet run --project GrupoA.PampazonSA.AdministracionDeposito.csproj
```

## Qué pantallas pesan más (para revisarlas)

Líneas de código sin contar el Designer ni las líneas en blanco. "Miembros del modelo" son las propiedades y métodos públicos que el form puede usar.

| Pantalla | Form | Modelo | Clases de datos | **Total** | Miembros del modelo | Para revisar |
|---|---|---|---|---|---|---|
| CU-01 Registrar OP | 220 | 166 | 50 (4 archivos) | **436** | 15 | 🔴 La más larga |
| CU-02 Generar Orden de Selección | 169 | 159 | 56 (3 archivos) | **384** | 13 | 🔴 Larga |
| CU-07 Generar remito y despachar | 144 | 174 | 50 (3 archivos) | **368** | 10 | 🔴 Larga |
| CU-03 Preparar productos | 85 | 117 | 26 (2 archivos) | **228** | 6 | 🟡 Media |
| CU-05 Generar Orden de Entrega | 71 | 102 | 54 (4 archivos) | **227** | 3 | 🟡 Media |
| CU-04 Empaquetar productos | 71 | 99 | 31 (3 archivos) | **201** | 6 | 🟡 Media |
| CU-06 Recepcionar Orden de Entrega | 66 | 43 | 25 (2 archivos) | **134** | 2 | 🟢 La más corta |

**Las más pesadas: más lentas de revisar**
- **CU-01 Registrar OP:** es la que más campos valida (cliente, depósito, modalidad, DNI, nombre, fecha, cantidad). Además maneja tres elecciones encadenadas (cliente → depósito → SKU) y calcula el disponible restando lo comprometido por otras OP.
- **CU-02 Generar Orden de Selección:** tiene filtros por cliente, fechas y modalidad, incluir y quitar OP, el resumen consolidado por SKU (la consulta LINQ más compleja del proyecto) y el reparto de cada SKU entre posiciones al generar la OS.
- **CU-07 Generar remito y despachar:** tiene tres listas que se mueven entre sí (OE pendientes → remitos a emitir → remitos pendientes de firma), agrupa las OE por cliente y cambia el estado de remitos, OE y OP al confirmar.

**Las medianas**
- **CU-03 Preparar productos:** un combo, un detalle ordenado por posición y una sola acción. Hay que prestar atención al manejo del combo al recargar y al descuento de stock.
- **CU-05 Generar Orden de Entrega:** el modelo es corto, pero agrupa las OP con una clave armada (`"cliente|dni|fecha"`). El form además resuelve que se marque una sola fila.
- **CU-04 Empaquetar productos:** sin entradas del usuario. Asigna la OP por FIFO y la confirma; lo único con lógica es `TotalBultos` y la consulta FIFO.

**La más liviana: la más rápida de mirar**
- **CU-06 Recepcionar Orden de Entrega:** una lista y un botón de confirmar. Sirve para ver el patrón form ↔ modelo en su forma más simple antes de pasar a las demás.

**Orden sugerido para leer el código:** CU-06 → CU-04 → CU-05 → CU-03 → CU-07 → CU-02 → CU-01.

## Cómo está armado

Cada pantalla (caso de uso) tiene su propia carpeta con:

| Archivo | Qué es |
|---|---|
| `<Pantalla>Form.cs` | La pantalla. Valida lo que escribe o elige el usuario, le pide cosas al modelo y muestra lo que el modelo devuelve. |
| `<Pantalla>Form.Designer.cs` | Los controles, generados por Visual Studio. No se modifica. |
| `<Pantalla>Modelo.cs` | La lógica y los datos de prueba. No conoce WinForms. |
| Clases de datos (`Remito.cs`, `OrdenPreparacion.cs`, …) | Solo propiedades. Representan las entidades que usa esa pantalla. |

Reglas que se repiten en todas las pantallas:

- **Form → modelo:** el form valida y después llama al modelo con datos simples (`string`, `int`, `DateTime`, `List<string>`), nunca con controles. Para saber qué fila de una lista eligió el usuario, la clave se guarda en `item.Tag`.
- **Modelo → form:** las **propiedades** son lo que la pantalla necesita mostrar (listas, totales, estado). Los **métodos** son lo que la pantalla hace (acciones) y devuelven `bool`: el form solo actualiza la pantalla si es `true` (`if (!_modelo.Accion(...)) return;`).
- **`RefrescarListas()`:** cada form vuelve a cargar sus listas desde las propiedades del modelo después de cada cambio.
- **Datos de prueba en el modelo:** son campos comunes (sin `static`) y vuelven a su estado inicial cada vez que se abre la pantalla. En el prototipo cada pantalla se prueba en una sola apertura; la persistencia se agrega en una entrega posterior.
- **Cada pantalla tiene sus propios datos y clases.** No se comparten entre carpetas: una OP registrada en una pantalla no aparece en otra.
- **Clases de datos:** una propiedad, un valor. Varios valores van en una lista (`List<string> NrosOP`) y los datos que van juntos forman un objeto (`Transportista` con `DNI` y `NombreApellido`).

## El circuito

```
Registrar OP ─► Generar Orden de Selección ─► Preparar productos ─► Empaquetar productos
   (CU-01)            (CU-02)                      (CU-03)               (CU-04)
                                                                            │
  Generar remito y despachar ◄─ Recepcionar Orden de Entrega ◄─ Generar Orden de Entrega
         (CU-07)                        (CU-06)                         (CU-05)
```

Estados de una **orden de preparación (OP)** a lo largo del circuito: Pendiente → En preparación → Preparada → En entrega → Despachada.

## Menú principal (`MenuPrincipal`)

Tiene un botón por pantalla y la abre con `ShowDialog()`. También tiene un combo de depósito (GBA, ROS, CBA; por defecto ROS) que solo se le pasa a *Generar Orden de Selección*. `MenuPrincipalModelo` está vacío.

---

## CU-01 · Registrar Orden de Preparación (`RegistrarOrdenPreparacion`)

**Qué hace:** Atención al Cliente carga una OP: elige cliente y depósito, agrega productos con su cantidad (sin superar el disponible), completa modalidad, transportista y fecha de retiro, y la registra en estado Pendiente.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Abrir | `Clientes`, `Depositos` para cargar los combos |
| Elegir cliente | `SeleccionarCliente(nombre, out cuit)` → muestra el CUIT; después `Skus` y `Lineas` |
| Elegir depósito | `SeleccionarDeposito(deposito)` → recarga `Skus` y `Lineas` |
| Elegir SKU | `SeleccionarSku(sku)` → muestra `Disponible` |
| Agregar | Valida con `Disponible` y `SkuYaAgregado`; después `AgregarProducto(cantidad)` |
| Quitar seleccionado | `QuitarProductos(skus)` |
| Registrar OP | Valida todos los campos y `HayProductos`; después `Registrar(modalidad, dni, nombre, fechaRetiro, out nroOP)` |
| Cambiar cliente/depósito o cerrar con productos | `HayProductos`, `ClienteSeleccionado`, `DepositoSeleccionado` para decidir si pregunta |

**Cómo funciona el modelo (`RegistrarOrdenPreparacionModelo`)**

- *Datos de prueba:* `_clientes` (4 clientes), `_depositos` (GBA, ROS, CBA, MDZ), `_stock` (todo en GBA), `_ordenes` (OP 101, 102 y 103 Pendientes, que comprometen stock) y `_ultimoNroOP = 109` (la próxima OP es la 110).
- *Estado de la pantalla:* `_cliente`, `_deposito`, `_sku` y `_lineas` (la orden que se está cargando).
- *Propiedades:*
  - `Clientes`, `Depositos`: listas para los combos.
  - `Skus`: SKU que el cliente tiene en stock en el depósito elegido.
  - `Disponible`: stock del SKU elegido menos lo comprometido por las OP Pendientes de ese cliente y depósito.
  - `SkuYaAgregado`: si el SKU elegido ya está en la lista.
  - `Lineas`: la grilla "Productos a preparar".
  - `HayProductos`, `ClienteSeleccionado`, `DepositoSeleccionado`.
- *Métodos (acciones):*
  - `SeleccionarCliente` / `SeleccionarDeposito`: guardan la elección y vacían la lista de productos.
  - `SeleccionarSku`: guarda el SKU si el cliente lo tiene en stock.
  - `AgregarProducto(cantidad)`: agrega el SKU elegido si no supera el disponible y no estaba agregado.
  - `QuitarProductos(skus)`: saca esas líneas.
  - `Registrar(...)`: numera la OP, la guarda Pendiente (con eso compromete el stock) y deja el modelo vacío para otra orden.
  - `StockDelCliente()` (privado): stock del cliente elegido en el depósito elegido.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `Cliente` | Nombre y CUIT de cada cliente; el CUIT relaciona al cliente con su stock y sus OP. |
| `Stock` | Cantidad en almacén de un SKU de un cliente en un depósito. |
| `OrdenPreparacion` | La OP registrada: número, cliente (CUIT), depósito, modalidad, transportista, fecha de retiro, estado y líneas. |
| `LineaOrden` | Una fila de "Productos a preparar": SKU, descripción y cantidad. |
| `Transportista` | DNI y nombre del transportista que va a retirar. |

---

## CU-02 · Generar Orden de Selección (`GenerarOrdenSeleccion`)

**Qué hace:** el supervisor filtra las OP Pendientes (cliente, fechas, modalidad), elige cuáles incluir y genera una orden de selección (OS) que dice qué SKU sacar de qué posición del depósito. Las OP incluidas pasan a En preparación.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Abrir | `Deposito`, `Modalidades`, `HayOrdenesPendientes`; después `Filtrar("", hoy, hoy, "")` |
| Buscar | Valida fechas y modalidad (con `Modalidades`); después `Filtrar(cliente, desde, hasta, modalidad)` |
| Limpiar filtros | `Filtrar("", hoy, hoy, "")` |
| Agregar / Agregar todo | `IncluirOrdenes(nrosOP)` |
| Quitar / Quitar todo | `QuitarOrdenes(nrosOP)` / `QuitarTodas()` |
| Tilde de cada OP | `EstaIncluida(nroOP)` (el usuario no puede tildar a mano) |
| Generar OS | `CantidadIncluidas` para validar y confirmar; después `GenerarOrdenSeleccion(out nroOS)` |
| Refrescar | `OrdenesFiltradas` (grilla de OP) y `ResumenConsolidado` (total por SKU) |
| Cerrar | `CantidadIncluidas` para avisar si había OP incluidas |

**Cómo funciona el modelo (`GenerarOrdenSeleccionModelo`)**

- *Datos de prueba:* `_modalidades`, `_ordenesPreparacion` (101 y 102 de hoy, 103 de ayer), `_stock` por posición (CEM-50KG en dos posiciones), `_ordenesSeleccion` y `_ultimoNroOS = 300`.
- *Estado de la pantalla:* los filtros (`_cliente`, `_desde`, `_hasta`, `_modalidad`) y `_incluidas` (OP de la OS en armado). El depósito llega por constructor desde el menú.
- *Propiedades:*
  - `Deposito`, `Modalidades`, `HayOrdenesPendientes`, `CantidadIncluidas`.
  - `OrdenesFiltradas`: OP Pendientes que cumplen los filtros, por fecha de recepción.
  - `ResumenConsolidado`: una línea por SKU con la cantidad total de las OP incluidas.
- *Métodos (acciones):*
  - `Filtrar(...)`: guarda los filtros y devuelve si hay OP que los cumplen.
  - `IncluirOrdenes` / `QuitarOrdenes` / `QuitarTodas`: arman la OS.
  - `EstaIncluida(nroOP)`: consulta si una OP está incluida (se usa para el tilde).
  - `GenerarOrdenSeleccion(out nroOS)`: reparte cada SKU entre las posiciones con stock hasta cubrir la cantidad, registra la OS Pendiente y pasa las OP a En preparación.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `OrdenPreparacion` | Las OP que se filtran e incluyen: número, cliente, fecha de recepción, modalidad, estado y productos. |
| `LineaProducto` | Un SKU con su cantidad: línea de una OP y fila del resumen consolidado. |
| `PosicionStock` | Cantidad de un SKU en una posición X-Y-Z del depósito. |
| `OrdenSeleccion` | La OS generada: número, depósito, fecha, estado, OP incluidas y detalle. |
| `LineaOrdenSeleccion` | Qué SKU y cuánto sacar de cada posición. |

---

## CU-03 · Preparar productos (`PrepararProductos`)

**Qué hace:** el operario de Almacén elige una OS Pendiente, ve qué retirar de cada posición en el orden de recorrido del depósito y confirma que entregó todo a Preparación. La OS pasa a Cumplida y se descuenta el stock.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Abrir | `Deposito`; después `OrdenesPendientes` (avisa si no hay) |
| Elegir OS en el combo | `SeleccionarOrden(nro)` |
| Confirmar | `ConfirmarEntrega(nro)`; después `OrdenesPendientes` para avisar si no quedan |
| Refrescar | `OrdenesPendientes` (combo), `OrdenSeleccionada` (cuál marcar), `Lineas` (detalle) |
| Cerrar | `OrdenSeleccionada` para avisar si quedó una OS elegida sin confirmar |

**Cómo funciona el modelo (`PrepararProductosModelo`)**

- *Datos de prueba:* `_ordenes` (OS 501 y 502 Pendientes con su mercadería por posición) y `_stock` por posición.
- *Estado de la pantalla:* `_nroOsSeleccionada`.
- *Propiedades:*
  - `Deposito` (GBA).
  - `OrdenesPendientes`: números de las OS Pendientes.
  - `OrdenSeleccionada`: número de la OS elegida o `""`.
  - `Lineas`: mercadería de la OS elegida, ordenada por sector, posición y fila.
- *Métodos (acciones):*
  - `SeleccionarOrden(nro)`: guarda la OS elegida si sigue Pendiente.
  - `ConfirmarEntrega(nro)`: verifica que exista el stock de todas las posiciones, lo descuenta, pasa la OS a Cumplida con fecha y hora, y deja de tenerla elegida. Las OP siguen En preparación.
  - `ClaveRecorrido(posicion)` (privado): separa `"12-43-2"` en sector, posición y fila para ordenar.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `OrdenSeleccion` | La OS: número, estado, OP que incluye, fecha de cumplida y líneas. |
| `LineaMercaderia` | Una fila del detalle: posición, SKU y cantidad a retirar. |
| `StockPosicion` | Stock de un SKU en una posición; es lo que se descuenta al confirmar. |

---

## CU-04 · Empaquetar productos (`EmpaquetarProductos`, namespace `CU04EmpaquetarProductos`)

**Qué hace:** al abrir, la pantalla asigna al puesto la OP más antigua (FIFO) que está En preparación y cuya OS ya está Cumplida. Muestra sus productos y el total de bultos. Al confirmar, la OP pasa a Preparada y se asigna la siguiente.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Abrir / después de empaquetar | `AsignarSiguienteOrden(out orden)` → muestra número y modalidad; `TotalBultos`; `ProductosAsignados` |
| Empaquetar | `NroOPAsignada` y `TotalBultos` para la confirmación; después `ConfirmarEmpaquetado(out nroOP)` |
| Cerrar | `HayOrdenAsignada` para avisar que no se registró el empaquetado |

**Cómo funciona el modelo (`EmpaquetarProductosModelo`)**

- *Datos de prueba:* `_ordenesSeleccion` (501 Cumplida, 503 Pendiente) y `_ordenesPreparacion` (101 y 102 de la OS 501; 108 de la OS 503).
- *Estado de la pantalla:* `_ordenAsignada`.
- *Propiedades:*
  - `HayOrdenAsignada`, `NroOPAsignada`.
  - `TotalBultos`: Palet cerrado = 1 bulto; Fulfillment = un bulto por unidad.
  - `ProductosAsignados`: productos de la OP asignada.
- *Métodos (acciones):*
  - `AsignarSiguienteOrden(out orden)`: elige la OP por FIFO; devuelve `false` si no hay ninguna.
  - `ConfirmarEmpaquetado(out nroOP)`: guarda bultos y fecha, pasa la OP a Preparada y la libera del puesto.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `OrdenPreparacion` | La OP a empaquetar: número, fecha de recepción, modalidad, OS a la que pertenece, estado, productos, bultos y fecha de empaquetado. |
| `ProductoOrden` | Una fila de productos: SKU, descripción y cantidad. |
| `OrdenSeleccion` | Solo número y estado: sirve para saber si la OS de la OP ya está Cumplida. |

---

## CU-05 · Generar Orden de Entrega (`GenerarOrdenEntrega`)

**Qué hace:** muestra las OP Preparadas sin orden de entrega, agrupadas por cliente, transportista y fecha de retiro. El operario marca un grupo y genera una orden de entrega (OE) Emitida con esas OP, que pasan a En entrega.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Abrir / refrescar | `Grupos` (avisa si no hay ninguno) |
| Generar orden | `ObtenerGrupo(clave, out grupo)` para el mensaje de confirmación; después `GenerarOrdenEntrega(clave, out nroOE)` |

Marcar una sola fila (y que hacer clic en la fila también la marque) lo resuelve el form, sin el modelo.

**Cómo funciona el modelo (`GenerarOrdenEntregaModelo`)**

- *Datos de prueba:* `_ordenesPreparacion` (todas con el transportista Jose Gomez; 101, 102, 103 y 105 Preparadas; 109 ya En entrega), `_ordenesEntrega` (OE 700) y `_ultimoNroOE = 700`.
- *Propiedades:* `Grupos`: un grupo por cliente + DNI del transportista + fecha de retiro, con la cantidad de OP.
- *Métodos (acciones):*
  - `ObtenerGrupo(clave, out grupo)`: datos del grupo marcado.
  - `GenerarOrdenEntrega(clave, out nroOE)`: numera la OE, la registra Emitida con una línea por OP y pasa esas OP a En entrega.
  - `OrdenesSinOE()` y `Clave(op)` (privados): OP Preparadas del depósito sin OE, y la clave `"cliente|dni|fecha"` que identifica a cada grupo.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `OrdenPreparacion` | Las OP Preparadas: número, depósito, cliente, transportista, fecha de retiro, bultos, estado y OE asignada. |
| `GrupoOrdenes` | Una fila de la grilla: clave, cliente, nombre del transportista, fecha de retiro y cantidad de OP. |
| `OrdenEntrega` | La OE generada: número, estado, depósito, fecha de emisión, cliente, transportista, fecha de retiro y líneas. |
| `LineaOrdenEntrega` | Cada OP de la OE con sus bultos. |
| `Transportista` | DNI y nombre del transportista. |

---

## CU-06 · Recepcionar Orden de Entrega (`RecepcionarOrdenEntrega`)

**Qué hace:** Despacho ve las OE Emitidas de su depósito, elige una y confirma que recibió la mercadería. La OE pasa a Pendiente de entrega y su mercadería queda en el depósito transitorio de Despacho.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Abrir / Actualizar | `OrdenesEmitidas` (avisa si no hay) |
| Confirmar | `ConfirmarRecepcion(nroOE)` |

**Cómo funciona el modelo (`RecepcionarOrdenEntregaModelo`)**

- *Datos de prueba:* `_ordenesEntrega` (todas de Jose Gomez; 700 ya recepcionada; 701 y 702 Emitidas).
- *Propiedades:* `OrdenesEmitidas`: OE Emitidas del depósito, por número.
- *Métodos (acciones):* `ConfirmarRecepcion(nroOE)`: pasa la OE a Pendiente de entrega, cambia su ubicación a Despacho y guarda la fecha de recepción.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `OrdenEntrega` | La OE: número, estado, depósito, cliente, transportista, fecha de emisión, OP que incluye, bultos, ubicación y fecha de recepción. |
| `Transportista` | DNI y nombre; el nombre se muestra en la grilla. |

---

## CU-07 · Generar remito y despachar (`GenerarRemitoDespachar`) — pantalla de referencia del profesor

**Qué hace:** Despacho busca al transportista por DNI y ve sus OE pendientes. Elige cuáles despachar (se arma un remito por cliente) y emite los remitos. Cuando el transportista entrega la copia firmada, se confirma la entrega: el remito queda Cumplido, sus OE Cumplidas y sus OP Despachadas.

**Qué le pide al modelo**

| Acción en pantalla | Llamada al modelo |
|---|---|
| Buscar órdenes | `LimpiarBusqueda()`; valida el DNI; `BuscarTransportista(dni, out transportista)` → muestra el nombre; `OrdenesPendientes` para avisar si no hay |
| Seleccionar | `SeleccionarOrdenes(nrosOE)` |
| Deseleccionar | `DeseleccionarOrdenes(nrosOE)` (el `Tag` de cada remito guarda la lista de sus OE) |
| Emitir remitos | `EmitirRemitos()` |
| Confirmar entrega con firma | `ConfirmarEntrega(nrosRemito)` |
| Refrescar | `OrdenesPendientes`, `RemitosAEmitir`, `RemitosPendientesFirma` |
| Cerrar | `HaySeleccion` para avisar que no se emitió ningún remito |

**Cómo funciona el modelo (`GenerarRemitoDespacharModelo`)**

- *Datos de prueba:* `_transportistas` (Jose Gomez, Alejo Cisterna y Daniel Baez); `_ordenesEntrega` (701 a 705 y 710); `_remitos` (R-410 Emitido); `_opsDespachadas`; `_ultimoNroRemito = 410`.
- *Estado de la pantalla:* `_transportista` (el buscado) y `_seleccionadas` (OE elegidas para remitir).
- *Propiedades:*
  - `HaySeleccion`.
  - `OrdenesPendientes`: OE Pendientes de entrega del transportista que todavía no se eligieron.
  - `RemitosAEmitir`: un remito por cliente con sus OE elegidas.
  - `RemitosPendientesFirma`: remitos Emitidos del transportista.
- *Métodos (acciones):*
  - `LimpiarBusqueda()`: descarta transportista y selección.
  - `BuscarTransportista(dni, out transportista)`: lo identifica por DNI.
  - `SeleccionarOrdenes` / `DeseleccionarOrdenes`: pasan OE entre "pendientes" y "a remitir".
  - `EmitirRemitos()`: crea un remito Emitido por cliente (con sus OE, OP y total de bultos) y pasa esas OE a Remito emitido.
  - `ConfirmarEntrega(nrosRemito)`: remitos a Cumplido, sus OE a Cumplida y sus OP a Despachadas.

**Clases**

| Clase | Para qué se usa |
|---|---|
| `Transportista` | DNI y nombre; se busca por DNI y se asigna a OE y remitos. |
| `OrdenDeEntrega` | Las OE a despachar: número, cliente, OP que incluye, bultos, transportista y estado. |
| `Remito` | El remito emitido: número, fecha, cliente, transportista, OE, OP, total de bultos, estado y fecha de cumplido. |
| `RemitoAEmitir` | Una fila de "Se emitirán los siguientes remitos": cliente y sus OE elegidas. |
