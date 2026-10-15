# Plan de prueba de pantallas · Procesamiento de órdenes de preparación

Plan por pantalla (hojas A a G del Excel). Cada dato que usan las pruebas está en **Datos base** o en la situación de partida de la hoja.

## Datos base

Datos ficticios comunes a todas las hojas. Fecha actual de prueba: 14/10/2026, salvo la hoja B, que usa fechas relativas (hoy y ayer). Depósito del usuario: GBA. Bultos de cada OP: Fulfillment = suma de las cantidades; Palet cerrado = 1. Cada hoja indica además su situación de partida.

### Clientes

| Cliente | Razón social | CUIT | Depósito con mercadería |
| --- | --- | --- | --- |
| Mercadito | Mercadito S.A. | 30-71234567-8 | GBA |
| MundoFOX | MundoFOX S.R.L. | 30-70987654-3 | GBA |
| Ferretería Norte | Ferretería Norte S.A. | 30-71112223-4 | GBA |
| Construcciones del Plata | Construcciones del Plata S.R.L. | 30-70555444-1 | GBA |

### Stock en GBA por SKU (partida de las hojas A, B y C; comprometido = OP 101, 102 y 103 Pendientes)

| SKU | Descripción | Cliente | Posiciones | Stock | Comprometido | Disponible |
| --- | --- | --- | --- | --- | --- | --- |
| CEM-50KG | Bolsa de cemento 50 kg | Mercadito S.A. | 2 | 60 | 15 | 45 |
| CAL-25KG | Bolsa de cal 25 kg | Mercadito S.A. | 1 | 50 | 3 | 47 |
| ZAP-0042 | Caja de zapatillas | MundoFOX S.R.L. | 1 | 100 | 24 | 76 |
| TOR-M8 | Caja de tornillos M8 x 100 | Ferretería Norte S.A. | 1 | 500 | 0 | 500 |
| ARE-25KG | Bolsa de arena 25 kg | Construcciones del Plata S.R.L. | 1 | 800 | 0 | 800 |

### Stock en GBA por posición (la suma por SKU coincide con la tabla anterior)

| SKU | Posición X-Y-Z | Stock en la posición |
| --- | --- | --- |
| CEM-50KG | 12-43-2 | 10 |
| CEM-50KG | 12-44-1 | 50 |
| CAL-25KG | 03-10-1 | 50 |
| ZAP-0042 | 12-05-1 | 100 |
| TOR-M8 | 05-12-1 | 500 |
| ARE-25KG | 09-03-2 | 800 |

### Transportistas

| DNI | Nombre |
| --- | --- |
| 24568779 | Jose Gomez |
| 32321987 | Daniel Baez |
| 20562667 | Alejo Cisterna |

### Órdenes de preparación usadas en las pruebas

| N° OP | Cliente | Recepción | Fecha de retiro | Modalidad | Transportista | Detalle |
| --- | --- | --- | --- | --- | --- | --- |
| 101 | Mercadito S.A. | 14/10/2026 09:00 | 20/10/2026 | Fulfillment | 24568779 | CEM-50KG x 10 |
| 102 | Mercadito S.A. | 14/10/2026 10:30 | 20/10/2026 | Fulfillment | 24568779 | CEM-50KG x 5 · CAL-25KG x 3 |
| 103 | MundoFOX S.R.L. | 13/10/2026 16:00 | 20/10/2026 | Palet cerrado | 24568779 | ZAP-0042 x 24 |
| 104 | Ferretería Norte S.A. | 12/10/2026 10:00 | 16/10/2026 | Fulfillment | 32321987 | TOR-M8 x 30 |
| 105 | Mercadito S.A. | 14/10/2026 11:00 | 21/10/2026 | Fulfillment | 24568779 | CAL-25KG x 10 |
| 106 | Construcciones del Plata S.R.L. | 12/10/2026 11:00 | 16/10/2026 | Fulfillment | 32321987 | ARE-25KG x 5 |
| 107 | Construcciones del Plata S.R.L. | 12/10/2026 11:30 | 16/10/2026 | Fulfillment | 32321987 | ARE-25KG x 4 |
| 108 | Mercadito S.A. | 14/10/2026 12:00 | 22/10/2026 | Fulfillment | 24568779 | CAL-25KG x 20 |
| 109 | Mercadito S.A. | 13/10/2026 15:00 | 17/10/2026 | Fulfillment | 24568779 | CAL-25KG x 5 |
| 110 | MundoFOX S.R.L. | 12/10/2026 14:00 | 15/10/2026 | Palet cerrado | 20562667 | ZAP-0042 x 6 |

### Otros documentos de partida (los estados exactos por hoja están en su situación de partida)

| Documento | Tipo | Estado | Contenido | Se usa en hoja |
| --- | --- | --- | --- | --- |
| 501 | OS | Pendiente (en D: Cumplida) | OP 101 y 102 | C, D |
| 502 | OS | Pendiente | OP 103 | C |
| 503 | OS | Pendiente | OP 108 | D |
| 700 | OE | Pendiente de entrega | OP 109 · Mercadito S.A. · Jose Gomez · 5 bultos | F |
| 701 | OE | Emitida (en G: Pendiente de entrega) | OP 101 y 102 · Mercadito S.A. · Jose Gomez · 18 bultos | F, G |
| 702 | OE | Emitida (en G: Pendiente de entrega) | OP 103 · MundoFOX S.R.L. · Jose Gomez · 1 bulto | F, G |
| 703 | OE | Pendiente de entrega | OP 104 · Ferretería Norte S.A. · Daniel Baez · 30 bultos | G |
| 704 | OE | Pendiente de entrega | OP 105 · Mercadito S.A. · Jose Gomez · 10 bultos | G |
| 705 | OE | Pendiente de entrega | OP 106 y 107 · Construcciones del Plata S.R.L. · Daniel Baez · 9 bultos | G |
| 710 | OE | Remito emitido | OP 110 · MundoFOX S.R.L. · Alejo Cisterna · 1 bulto | G |
| R-410 | Remito | Emitido (sin firmar) | OE 710 · Alejo Cisterna (20562667) | G |

### Hojas del plan

| Hoja | Pantalla | Caso de uso |
| --- | --- | --- |
| A - Registrar OP | Registrar orden de preparación | CU-01 |
| B - Generar OS | Generar orden de selección | CU-02 |
| C - Preparar productos | Preparar productos | CU-03 |
| D - Empaquetar | Empaquetar productos | CU-04 |
| E - Generar OE | Generar orden de entrega | CU-05 |
| F - Recepcionar OE | Recepcionar orden de entrega | CU-06 |
| G - Remito y despacho | Generar remito y despachar | CU-07 |

## A · Registrar orden de preparación (CU-01) · Usuario: Empleado de Atención al Cliente

**Situación de partida:** Fecha actual de prueba: 14/10/2026. OP Pendientes en GBA: 101, 102 y 103 (comprometen CEM-50KG 15, CAL-25KG 3 y ZAP-0042 24). Stock en GBA: CEM-50KG 60 (comprometido 15, disponible 45), CAL-25KG 50 (comprometido 3, disponible 47), ZAP-0042 100 (comprometido 24, disponible 76). Clientes y transportistas según la hoja "Datos base".

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| A.1 | Cliente | Lista desplegable | 50 | Sí | Sí | Clientes con contrato vigente (archivo de clientes) | Debe elegirse de la lista; no admite texto libre | Al elegirlo se completa el CUIT. Si se cambia con productos cargados, pide confirmación y vacía la lista (CU-01, exc. 17.4). | (sin seleccionar) + Registrar OP | Rechazo. Mensaje "Debe completar: Cliente" |
|  |  |  |  |  |  |  |  |  | Mercadito S.A. | Se acepta. Muestra CUIT 30-71234567-8 |
|  |  |  |  |  |  |  |  |  | Cambio a MundoFOX S.R.L. con CEM-50KG ya cargado | Pide confirmación. Aceptar: vacía la lista. Cancelar: queda Mercadito S.A. |
| A.2 | CUIT del cliente | Alfanumérico (XX-XXXXXXXX-X) | 13 | No | No | CUIT del cliente elegido | Lo completa el sistema | Campo de solo lectura. | Cliente Mercadito S.A. | Muestra 30-71234567-8 |
|  |  |  |  |  |  |  |  |  | Intento de escribir en el campo | No permite modificar |
| A.3 | Depósito | Lista desplegable | 30 | Sí | Sí | GBA, ROS, CBA, MDZ | Debe elegirse de la lista; el cliente debe tener mercadería en el depósito | Al elegirlo se cargan en SKU los productos del cliente con stock en ese depósito. | (sin seleccionar) + Registrar OP | Rechazo. Mensaje "Debe completar: Depósito" |
|  |  |  |  |  |  |  |  |  | GBA (cliente Mercadito S.A.) | Se acepta. La lista de SKU muestra CEM-50KG y CAL-25KG |
|  |  |  |  |  |  |  |  |  | ROS (cliente Mercadito S.A.) | Rechazo. Mensaje "El cliente no tiene mercadería en el depósito seleccionado" |
| A.4 | Modalidad | Opción (botones de radio) | — | Sí | Sí | Fulfillment / Palet cerrado | Debe marcarse una opción | Solo una opción puede estar marcada. | Ninguna marcada + Registrar OP | Rechazo. Mensaje "Debe completar: Modalidad" |
|  |  |  |  |  |  |  |  |  | Fulfillment | Se acepta |
|  |  |  |  |  |  |  |  |  | Palet cerrado | Se acepta |
| A.5 | DNI del transportista autorizado | Numérico entero | 8 | Sí | Sí | 7 u 8 dígitos (Min 1000000 – Max 99999999) | Solo dígitos, sin puntos ni signos | Despacho lo usa para identificar al transportista (CU-07). | (vacío) + Registrar OP | Rechazo. Mensaje "Debe completar: DNI" |
|  |  |  |  |  |  |  |  |  | 24568779 | Se acepta |
|  |  |  |  |  |  |  |  |  | 7654321 | Se acepta |
|  |  |  |  |  |  |  |  |  | 123456 | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
|  |  |  |  |  |  |  |  |  | 24.568.779 | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
|  |  |  |  |  |  |  |  |  | 2456877A | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
|  |  |  |  |  |  |  |  |  | 245687790 | No permite ingresar más de 8 caracteres |
| A.6 | Nombre del transportista | Alfabético | 60 | Sí | Sí | Letras, espacios, apóstrofos y guiones | No puede quedar vacío ni con solo espacios | — | (vacío) + Registrar OP | Rechazo. Mensaje "Debe completar: Nombre del transportista" |
|  |  |  |  |  |  |  |  |  | "   " (solo espacios) | Rechazo. Mensaje "Debe completar: Nombre del transportista" |
|  |  |  |  |  |  |  |  |  | Jose Gomez | Se acepta |
|  |  |  |  |  |  |  |  |  | María O'Connor | Se acepta |
|  |  |  |  |  |  |  |  |  | Jose123 | Rechazo. Mensaje "El nombre solo admite letras, espacios, apóstrofos y guiones" |
| A.7 | Fecha de retiro | Fecha (dd/mm/aaaa) | 10 | Sí | Sí | Mayor o igual a la fecha actual | Fecha válida de calendario; no anterior a hoy | Se recomienda un selector de fecha en lugar de texto libre. | (vacío) + Registrar OP | Rechazo. Mensaje "Debe completar: Fecha de retiro" |
|  |  |  |  |  |  |  |  |  | 13/10/2026 | Rechazo. Mensaje "La fecha de retiro no puede ser anterior a hoy" |
|  |  |  |  |  |  |  |  |  | 14/10/2026 | Se acepta |
|  |  |  |  |  |  |  |  |  | 20/10/2026 | Se acepta |
|  |  |  |  |  |  |  |  |  | 31/02/2026 | Rechazo. Mensaje "Fecha inválida" |
|  |  |  |  |  |  |  |  |  | abc | Rechazo. Mensaje "Fecha inválida" |
| A.8 | SKU | Lista desplegable | 20 | Sí | Sí (para agregar) | SKU del cliente con stock en el depósito elegido | No puede repetirse en la orden | Al elegirlo se muestra el disponible (A.9). | (sin seleccionar) + Agregar | Rechazo. Mensaje "Debe seleccionar un SKU" |
|  |  |  |  |  |  |  |  |  | CEM-50KG | Se acepta. Muestra disponible 45 |
|  |  |  |  |  |  |  |  |  | CEM-50KG cuando ya está en la lista + Agregar | Rechazo. Mensaje "El SKU ya está en la orden. Quítelo de la lista para cambiar la cantidad" |
| A.9 | Disponible | Numérico entero | 7 | No | No | Stock en almacén − cantidad comprometida | Lo calcula el sistema | Campo de solo lectura. | SKU CEM-50KG (stock 60, comprometido 15) | Muestra 45 |
|  |  |  |  |  |  |  |  |  | SKU CAL-25KG (stock 50, comprometido 3) | Muestra 47 |
| A.10 | Cantidad | Numérico entero | 7 | Sí | Sí (para agregar) | Min 1 – Max: disponible del SKU | Entero positivo, no mayor al disponible | Pruebas con SKU CEM-50KG (disponible 45). | (vacío) + Agregar | Rechazo. Mensaje "La cantidad debe ser un número entero mayor a cero" |
|  |  |  |  |  |  |  |  |  | 0 | Rechazo. Mensaje "La cantidad debe ser un número entero mayor a cero" |
|  |  |  |  |  |  |  |  |  | -5 | Rechazo. Mensaje "La cantidad debe ser un número entero mayor a cero" |
|  |  |  |  |  |  |  |  |  | 2,5 | Rechazo. Mensaje "La cantidad debe ser un número entero mayor a cero" |
|  |  |  |  |  |  |  |  |  | A | Rechazo. Mensaje "La cantidad debe ser un número entero mayor a cero" |
|  |  |  |  |  |  |  |  |  | 1 | Se acepta |
|  |  |  |  |  |  |  |  |  | 45 | Se acepta |
|  |  |  |  |  |  |  |  |  | 46 | Rechazo. Mensaje "La cantidad supera el disponible del SKU CEM-50KG: 45 unidades" |
| A.11 | Productos a preparar | Grilla (SKU, Descripción, Cantidad) | — | No | Sí (al menos 1 línea) | Líneas agregadas con "Agregar" | Debe tener al menos un producto para registrar | Se modifica solo con "Agregar" y "Quitar seleccionado". | Lista vacía + Registrar OP | Rechazo. Mensaje "Debe agregar al menos un producto" |
|  |  |  |  |  |  |  |  |  | Línea CEM-50KG seleccionada + Quitar seleccionado | Se quita la línea |
|  |  |  |  |  |  |  |  |  | Ninguna línea seleccionada + Quitar seleccionado | Mensaje "Seleccione un producto de la lista" |
| A.12 | Botón "Registrar OP" | Acción | — | — | — | — | Valida todos los campos antes de registrar | Pide confirmación antes de registrar (CU-01, pasos 18 a 27). | Mercadito S.A. / GBA / Fulfillment / 24568779 / Jose Gomez / 20/10/2026 / CEM-50KG x 20, confirma | Se acepta. OP registrada en estado Pendiente. Mensaje "Orden de preparación N° [n] registrada". Disponible de CEM-50KG pasa a 25 |
|  |  |  |  |  |  |  |  |  | Mismo caso; se cancela la confirmación | No se registra la OP. Los datos quedan cargados |
| A.13 | Botón "Cancelar" | Acción | — | — | — | — | — | — | Con datos cargados | Pide confirmación "No se registró ninguna orden de preparación. ¿Desea salir?" |
|  |  |  |  |  |  |  |  |  | Sin datos cargados | Cierra la pantalla |

## B · Generar orden de selección (CU-02) · Usuario: Jefe de Preparación

**Situación de partida:** Fechas relativas: hoy y ayer. OP Pendientes en GBA: 101 y 102 (Mercadito S.A., recibidas hoy, Fulfillment) y 103 (MundoFOX S.R.L., recibida ayer, Palet cerrado). Stock y posiciones para generar la OS: CEM-50KG 10 en 12-43-2 y 50 en 12-44-1 (se toma en ese orden), CAL-25KG 50 en 03-10-1, ZAP-0042 100 en 12-05-1.

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| B.1 | Depósito | Texto | 30 | No | No | Depósito asignado al usuario | Lo completa el sistema | Campo de solo lectura. | Usuario del depósito GBA | Muestra "GBA" |
| B.2 | Cliente (filtro) | Alfanumérico | 50 | Sí | No | Texto libre; busca clientes que contengan el texto | — | Vacío no filtra por cliente. | (vacío), fechas ayer a hoy | Se acepta. Lista OP 103, 101 y 102 |
|  |  |  |  |  |  |  |  |  | Merca | Se acepta. Lista OP 101 y 102 |
|  |  |  |  |  |  |  |  |  | ZZZ | Mensaje "No hay órdenes pendientes para los filtros ingresados" |
| B.3 | Fecha desde | Fecha (selector con tilde) | 10 | Sí | No | Por defecto, la fecha actual (tildada) | Si las dos fechas están tildadas, no posterior a Fecha hasta | Filtra por fecha de recepción de la OP. Destildada no filtra por esa fecha. | hoy (hasta hoy) | Se acepta. Lista OP 101 y 102 |
|  |  |  |  |  |  |  |  |  | ayer (hasta hoy) | Se acepta. Lista OP 103, 101 y 102 |
|  |  |  |  |  |  |  |  |  | Destildada (hasta hoy) | Se acepta. Lista OP 103, 101 y 102 |
|  |  |  |  |  |  |  |  |  | mañana (hasta hoy) | Rechazo. Mensaje "La fecha desde no puede ser posterior a la fecha hasta" |
| B.4 | Fecha hasta | Fecha (selector con tilde) | 10 | Sí | No | Por defecto, la fecha actual (tildada) | Si las dos fechas están tildadas, no anterior a Fecha desde | Destildada no filtra por esa fecha. | hoy (desde hoy) | Se acepta |
|  |  |  |  |  |  |  |  |  | ayer (desde hoy) | Rechazo. Mensaje "La fecha desde no puede ser posterior a la fecha hasta" |
|  |  |  |  |  |  |  |  |  | Destildada (desde ayer) | Se acepta. Lista OP 103, 101 y 102 |
| B.5 | Modalidad (filtro) | Alfanumérico | 15 | Sí | No | Vacío, Fulfillment o Palet cerrado | Debe coincidir con una modalidad existente, sin distinguir mayúsculas | Texto libre o elegido de la lista: se valida contra los valores posibles al presionar "Buscar" (CU-02, exc. 4.4). | (vacío) | Se acepta. No filtra por modalidad |
|  |  |  |  |  |  |  |  |  | Palet cerrado (desde ayer) | Se acepta. Lista OP 103 |
|  |  |  |  |  |  |  |  |  | fulfillment (en minúsculas) | Se acepta. Lista OP 101 y 102 |
|  |  |  |  |  |  |  |  |  | Pallet | Rechazo. Mensaje "Modalidad inválida" |
| B.6 | Botón "Buscar" | Acción | — | — | — | — | — | — | Filtros válidos | Muestra las OP Pendientes que cumplen los filtros, ordenadas por fecha de recepción |
|  |  |  |  |  |  |  |  |  | OP ya incluida en otra OS (En preparación), p. ej. 101 y 102 después de B.9 | No aparece en la lista |
| B.7 | Órdenes de preparación pendientes | Grilla con selección múltiple; el tilde indica OP incluida | — | No | Sí (al menos 1 OP incluida) | OP Pendientes del depósito | — | Se opera con Agregar Seleccionadas / Quitar Seleccionadas / Agregar Todo / Quitar Todo. El tilde lo pone el sistema; no se puede tildar a mano. | OP 101 y 102 seleccionadas + Agregar Seleccionadas | Quedan tildadas como incluidas. El resumen consolidado se actualiza |
|  |  |  |  |  |  |  |  |  | Ninguna seleccionada + Agregar Seleccionadas | Mensaje "Seleccione al menos una orden" |
|  |  |  |  |  |  |  |  |  | Agregar Todo con OP 103, 101 y 102 listadas | Se incluyen las tres |
|  |  |  |  |  |  |  |  |  | OP 102 incluida y seleccionada + Quitar Seleccionadas | Se destilda y se restan sus SKU del consolidado |
|  |  |  |  |  |  |  |  |  | Quitar Todo | Se destildan todas. El consolidado queda vacío |
|  |  |  |  |  |  |  |  |  | Clic en el tilde de una OP | El tilde no cambia |
| B.8 | Resumen consolidado de productos | Grilla (SKU, Cantidad total) | — | No | No | Suma por SKU de las OP incluidas | Lo calcula el sistema | La posición X-Y-Z no se muestra en el prototipo; el sistema la asigna al generar la OS. | OP 101 y 102 incluidas | CAL-25KG: 3 · CEM-50KG: 15 |
| B.9 | Botón "Generar Orden de Selección" | Acción | — | — | — | — | Al menos una OP incluida | Pide confirmación (CU-02, pasos 10 a 16). | Sin OP incluidas | Rechazo. Mensaje "Debe agregar al menos una orden de preparación" |
|  |  |  |  |  |  |  |  |  | OP 101 y 102 incluidas, confirma | Se acepta. OS registrada Pendiente: CEM-50KG 10 en 12-43-2 y 5 en 12-44-1, CAL-25KG 3 en 03-10-1. OP 101 y 102 pasan a En preparación. Mensaje "Orden de selección N° [n] generada" |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se genera la OS. Las OP siguen incluidas |
| B.10 | Botón "Cancelar" | Acción | — | — | — | — | — | También al cerrar la ventana. | Con OP incluidas | Pide confirmación "No se generó ninguna orden de selección. ¿Desea salir?" |
|  |  |  |  |  |  |  |  |  | Sin OP incluidas | Cierra la pantalla |
| B.11 | Botón "Limpiar filtros" | Acción | — | — | — | — | — | Las OP incluidas se mantienen (CU-02, exc. 3.1). | Cliente "Merca", Modalidad "Fulfillment", desde ayer, con OP 101 incluida | Cliente y Modalidad vacíos, fechas tildadas en hoy. Lista OP 101 (tildada) y 102 |
| B.12 | Apertura de la pantalla sin OP Pendientes | Acción | — | — | — | — | — | CU-02, exc. 2.1. Deja sin OP Pendientes: para repetir el plan de B hay que recargar su base. | Ejecutar última, con la base de B sin cambios: destildar Fecha desde, Agregar Todo (OP 103, 101 y 102), generar y confirmar la OS; salir y volver a entrar | Mensaje "No hay órdenes de preparación pendientes" |

## C · Preparar productos (CU-03) · Usuario: Operario de Almacén

**Situación de partida:** OS Pendientes en GBA: 501 (OP 101 y 102: CEM-50KG 10 en 12-43-2, CEM-50KG 5 en 12-44-1 y CAL-25KG 3 en 03-10-1) y 502 (OP 103: ZAP-0042 24 en 12-05-1). Stock según "Datos base".

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C.1 | Depósito | Texto | 30 | No | No | Depósito asignado al usuario | Lo completa el sistema | Campo de solo lectura. | Usuario del depósito GBA | Muestra "GBA" |
| C.2 | Orden de selección | Lista desplegable | 10 | Sí | Sí (para confirmar) | OS Pendientes del depósito | Debe elegirse de la lista | Al elegir una OS se carga su mercadería en C.3. | Situación de partida | Lista OS 501 y 502 |
|  |  |  |  |  |  |  |  |  | OS ya Cumplida (501 después de C.4) | No aparece en la lista |
|  |  |  |  |  |  |  |  |  | Sin OS Pendientes (después de confirmar 501 y 502) | Mensaje "No hay órdenes de selección pendientes". "Confirmar entrega a Preparación" deshabilitado |
| C.3 | Mercadería a retirar del almacén | Grilla (Posición X-Y-Z, SKU, Cantidad) | — | No | No | Líneas de la OS elegida | Ordenada por sector, posición y fila para el recorrido más corto | Muestra solo qué buscar y dónde. El operario no carga datos. | OS 501 | Muestra, en este orden: 03-10-1 CAL-25KG 3 · 12-43-2 CEM-50KG 10 · 12-44-1 CEM-50KG 5 |
|  |  |  |  |  |  |  |  |  | OS 502 | Muestra 12-05-1 ZAP-0042 24 |
|  |  |  |  |  |  |  |  |  | Sin OS elegida | Grilla vacía |
| C.4 | Botón "Confirmar entrega a Preparación" | Acción | — | — | — | — | Una OS elegida | Pide confirmación (CU-03, pasos 7 a 14). | Sin OS elegida | Rechazo. Mensaje "Debe seleccionar una orden de selección" |
|  |  |  |  |  |  |  |  |  | OS 501, confirma | Se acepta. OS 501 pasa a Cumplida. Stock: CEM-50KG 60 → 45 (12-43-2: 10 → 0; 12-44-1: 50 → 45), CAL-25KG 50 → 47 (03-10-1). Mensaje "Entrega a Preparación registrada". La OS 501 sale de la lista y la grilla queda vacía. La OS 502 sigue Pendiente |
|  |  |  |  |  |  |  |  |  | OS 502, se cancela la confirmación | No se registra la entrega. La OS 502 sigue Pendiente y seleccionada |
| C.5 | Botón "Cancelar" | Acción | — | — | — | — | — | — | Antes de confirmar | Mensaje "No se registró la entrega a Preparación". La OS sigue Pendiente |

## D · Empaquetar productos (CU-04) · Usuario: Operario de Preparación

**Situación de partida:** OP 101 (recibida 14/10/2026 09:00) y OP 102 (14/10/2026 10:30) En preparación con su OS 501 Cumplida. OP 108 En preparación con su OS 503 Pendiente. Bultos: Fulfillment = suma de las cantidades de la OP; Palet cerrado = 1.

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| D.1 | Orden (OP asignada automáticamente) | Numérico entero | 10 | No | No | OP En preparación con OS Cumplida y sin empaquetar | Asignación FIFO por fecha y hora de recepción | El operario no elige la OP: la asigna el sistema. | OP 101 y 102 disponibles | Asigna OP 101 |
|  |  |  |  |  |  |  |  |  | Después de empaquetar la 101 y la 102 (D.5), solo queda la OP 108 (OS 503 Pendiente) | No asigna. Mensaje "No hay órdenes para empaquetar". "Confirmar Empaquetado" deshabilitado. Campos vacíos |
| D.2 | Modalidad | Texto | 15 | No | No | Fulfillment / Palet cerrado | Lo completa el sistema | Campo de solo lectura. | OP 101 | Muestra "Fulfillment" |
| D.3 | Productos a empaquetar | Grilla (SKU, Descripción, Cantidad) | — | No | No | Detalle de la OP asignada | Lo completa el sistema | — | OP 101 | Muestra CEM-50KG · Bolsa de cemento 50 kg · 10 |
| D.4 | Total bultos | Numérico entero | — | No | No | Fulfillment: suma de las cantidades de la OP. Palet cerrado: 1 | Lo calcula el sistema | Campo de solo lectura. El operario arma la cantidad de bultos indicada. | OP 101 (CEM-50KG x 10) | Muestra "10" |
|  |  |  |  |  |  |  |  |  | OP 102 (CEM-50KG x 5 · CAL-25KG x 3) | Muestra "8" |
| D.5 | Botón "Confirmar Empaquetado" | Acción | — | — | — | — | — | Pide confirmación (CU-04, pasos 5 a 10). | OP 101, confirma | Se acepta. Mensaje de confirmación "¿Confirma el empaquetado de la OP N° 101 en 10 bultos?". OP 101 pasa a Preparada con 10 bultos. Mensaje "Orden de preparación N° 101 preparada". Se asigna la OP 102 |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se registra el empaquetado. La OP 101 sigue en pantalla |
| D.6 | Botón "Cancelar" | Acción | — | — | — | — | — | También al cerrar la ventana. | Con la OP 101 asignada | Mensaje "No se registró el empaquetado". La OP 101 sigue En preparación y se vuelve a asignar al abrir la pantalla |

## E · Generar orden de entrega (CU-05) · Usuario: Operario de Preparación

**Situación de partida:** OP Preparadas sin OE, todas con transportista Jose Gomez (DNI 24568779): 101 (10 bultos) y 102 (8 bultos) de Mercadito S.A. con retiro 20/10/2026; 105 (10 bultos) de Mercadito S.A. con retiro 21/10/2026; 103 (1 bulto) de MundoFOX S.R.L. con retiro 20/10/2026.

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| E.1 | Órdenes preparadas sin orden de entrega | Grilla con selección simple (Cliente, Transportista, Fecha retiro, Cantidad OP) | — | No | Sí (una fila) | Grupos de OP Preparadas sin OE | Agrupa por cliente + DNI del transportista + fecha de retiro | Una fila seleccionada genera una OE. | Situación de partida | Muestra 3 filas: Mercadito S.A. · Jose Gomez · 20/10/2026 · 2 — Mercadito S.A. · Jose Gomez · 21/10/2026 · 1 — MundoFOX S.R.L. · Jose Gomez · 20/10/2026 · 1 |
|  |  |  |  |  |  |  |  |  | OP Preparada que ya tiene OE | No aparece en ningún grupo |
|  |  |  |  |  |  |  |  |  | Sin OP Preparadas sin OE | Mensaje "No hay órdenes preparadas pendientes de orden de entrega" |
| E.2 | Botón "Generar Orden de Entrega" | Acción | — | — | — | — | Una fila seleccionada | Pide confirmación (CU-05, pasos 6 a 12). | Sin fila seleccionada | Rechazo. Mensaje "Debe seleccionar un grupo de órdenes" |
|  |  |  |  |  |  |  |  |  | Fila Mercadito S.A. · 20/10/2026, confirma | Se acepta. OE registrada Emitida con OP 101 y 102 y sus bultos. Las OP pasan a En entrega. Mensaje "Orden de entrega N° [n] generada". La fila desaparece |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se genera la OE |
| E.3 | Botón "Cerrar" | Acción | — | — | — | — | — | — | En cualquier momento | Cierra la pantalla sin cambios |

## F · Recepcionar orden de entrega (CU-06) · Usuario: Operario de Despacho

**Situación de partida:** OE Emitidas en GBA: 701 (Mercadito S.A., Jose Gomez, OP 101 y 102) y 702 (MundoFOX S.R.L., Jose Gomez, OP 103). OE 700 ya está Pendiente de entrega.

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| F.1 | Depósito | Texto | 30 | No | No | Depósito asignado al usuario | Lo completa el sistema | Campo de solo lectura. | Usuario del depósito GBA | Muestra "GBA" |
| F.2 | Órdenes de Entrega emitidas | Grilla con selección simple (N° OE, Transportista, Cliente, Fecha emisión, N° OP) | — | No | Sí (una fila) | OE Emitidas del depósito | — | Permite controlar los bultos rotulados contra las OP de la OE. | Situación de partida | Muestra OE 701 y 702 con sus datos. No muestra la OE 700 |
|  |  |  |  |  |  |  |  |  | Sin OE Emitidas | Mensaje "No hay órdenes de entrega para recepcionar" |
| F.3 | Botón "Actualizar Órdenes" | Acción | — | — | — | — | — | — | Con la lista cargada, sin cambios + Actualizar Órdenes | La lista se vuelve a cargar con las mismas OE emitidas (701 y 702) |
| F.4 | Botón "Confirmar recepción en Despacho" | Acción | — | — | — | — | Una OE seleccionada | Pide confirmación (CU-06, pasos 5 a 11). | Sin OE seleccionada | Rechazo. Mensaje "Debe seleccionar una orden de entrega" |
|  |  |  |  |  |  |  |  |  | OE 701 seleccionada, confirma | Se acepta. OE 701 pasa a Pendiente de entrega. Su mercadería queda en el depósito transitorio de Despacho. Mensaje "Orden de entrega N° 701 recepcionada". Sale de la lista |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se registra la recepción. La OE sigue Emitida |
| F.5 | Botón "Cancelar" | Acción | — | — | — | — | — | — | En cualquier momento | Cierra la pantalla sin cambios |

## G · Generar remito y despachar (CU-07) · Usuario: Operario de Despacho

**Situación de partida:** OE Pendientes de entrega. Jose Gomez (DNI 24568779): 701 (Mercadito S.A., OP 101 y 102, 18 bultos), 704 (Mercadito S.A., OP 105, 10 bultos) y 702 (MundoFOX S.R.L., OP 103, 1 bulto). Daniel Baez (DNI 32321987): 703 (Ferretería Norte S.A., OP 104, 30 bultos) y 705 (Construcciones del Plata S.R.L., OP 106 y 107, 9 bultos). Alejo Cisterna (DNI 20562667): sin OE pendientes, con el remito R-410 emitido sin firmar. DNI 22333444: no corresponde a ningún transportista.

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| G.1 | DNI del transportista | Numérico entero | 8 | Sí | Sí | 7 u 8 dígitos (Min 1000000 – Max 99999999) | Solo dígitos, sin puntos ni signos | Se busca con "Buscar órdenes". Cada búsqueda limpia el nombre y las tres listas (CU-07, paso 3). | (vacío) + Buscar órdenes | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
|  |  |  |  |  |  |  |  |  | 123456 | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
|  |  |  |  |  |  |  |  |  | 2456877A | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
|  |  |  |  |  |  |  |  |  | 24568779 | Se acepta. Muestra nombre y las OE 701, 704 y 702 |
|  |  |  |  |  |  |  |  |  | 32321987 | Se acepta. Muestra nombre y las OE 705 y 703 |
|  |  |  |  |  |  |  |  |  | 22333444 | Mensaje "No hay órdenes de entrega pendientes para el DNI 22333444" |
|  |  |  |  |  |  |  |  |  | 20562667 | Mensaje "No hay órdenes de entrega pendientes para el DNI 20562667". Muestra R-410 en remitos pendientes de firma |
|  |  |  |  |  |  |  |  |  | 32321987 después de buscar 24568779 y seleccionar OE | Se limpian el nombre y las tres listas. Muestra los datos de Daniel Baez |
| G.2 | Nombre del transportista | Texto | 60 | No | No | Nombre registrado del transportista | Lo completa el sistema | Campo de solo lectura. | DNI 24568779 | Muestra "Jose Gomez" |
|  |  |  |  |  |  |  |  |  | DNI 32321987 | Muestra "Daniel Baez" |
| G.3 | Órdenes de entrega pendientes de entrega | Grilla con selección múltiple (Cliente, N° OE, OP, Bultos) | — | No | Sí (al menos 1 OE) | OE Pendientes de entrega del transportista | Ordenada por cliente | Se opera con "Seleccionar". | DNI 24568779 | Muestra Mercadito S.A. 701 (OP 101, 102 · 18 bultos), Mercadito S.A. 704 (OP 105 · 10), MundoFOX S.R.L. 702 (OP 103 · 1) |
|  |  |  |  |  |  |  |  |  | DNI 32321987 | Muestra Construcciones del Plata S.R.L. 705 (OP 106, 107 · 9), Ferretería Norte S.A. 703 (OP 104 · 30) |
|  |  |  |  |  |  |  |  |  | OE 701, 704 y 702 seleccionadas + Seleccionar | Salen de esta lista y pasan a "Se emitirán los siguientes remitos" |
|  |  |  |  |  |  |  |  |  | Ninguna seleccionada + Seleccionar | Mensaje "Seleccione al menos una orden de entrega" |
| G.4 | Se emitirán los siguientes remitos | Grilla con selección múltiple (Cliente, OE incluidas) | — | No | No | Un remito por cliente de las OE seleccionadas | Lo calcula el sistema | Se opera con "Deseleccionar", que devuelve todas las OE del remito marcado. | OE 701, 704 y 702 seleccionadas | Muestra 2 filas: Mercadito S.A. · OE 701, 704 — MundoFOX S.R.L. · OE 702 |
|  |  |  |  |  |  |  |  |  | Fila MundoFOX S.R.L. marcada + Deseleccionar | La OE 702 vuelve a la primera lista. Queda 1 fila: Mercadito S.A. · OE 701, 704 |
|  |  |  |  |  |  |  |  |  | Ninguna fila marcada + Deseleccionar | No hace nada |
| G.5 | Botón "Emitir remitos" | Acción | — | — | — | — | Al menos una OE seleccionada | Pide confirmación (CU-07, pasos 9 a 15). | Sin OE seleccionadas | Rechazo. Mensaje "Debe seleccionar al menos una orden de entrega" |
|  |  |  |  |  |  |  |  |  | OE 701, 704 y 702, confirma | Se acepta. Mensaje de confirmación "Se emitirán 2 remitos. ¿Confirma?". Se emiten 2 remitos (Mercadito S.A. y MundoFOX S.R.L.) con OE, OP y total de bultos. Las OE pasan a Remito emitido. Los remitos aparecen en "Remitos pendientes de firma" |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se emiten remitos. Las OE siguen en la lista de remitos a emitir |
| G.6 | Remitos pendientes de firma | Grilla con selección múltiple (N° Remito) | — | No | Sí (al menos 1 remito) | Remitos Emitidos sin confirmar del transportista identificado | — | — | DNI 24568779 después de emitir | Muestra los 2 remitos emitidos. No muestra R-410 (otro transportista) |
|  |  |  |  |  |  |  |  |  | DNI 20562667 | Muestra R-410 |
| G.7 | Botón "Confirmar entrega y firma" | Acción | — | — | — | — | Al menos un remito seleccionado | Pide confirmación (CU-07, pasos 17 a 21). | Sin remito seleccionado | Rechazo. Mensaje "Debe seleccionar al menos un remito" |
|  |  |  |  |  |  |  |  |  | Los 2 remitos de Jose Gomez seleccionados, confirma | Se acepta. Remitos Cumplidos con fecha y hora. OE 701, 704 y 702 Cumplidas. OP 101, 102, 103 y 105 Despachadas. Mensaje "Entrega confirmada". Los remitos salen de la lista |
|  |  |  |  |  |  |  |  |  | R-410 de Alejo Cisterna seleccionado, confirma | Se acepta. R-410 Cumplido, sus OE Cumplidas y sus OP Despachadas |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se confirma. Los remitos siguen pendientes de firma |
| G.8 | Botón "Cancelar" | Acción | — | — | — | — | — | También se sale cerrando la ventana. | Con OE seleccionadas, antes de emitir | Mensaje "No se emitió ningún remito". Cierra la pantalla |
|  |  |  |  |  |  |  |  |  | Con remitos sin firmar | Cierra la pantalla. Los remitos quedan pendientes de firma para confirmarlos después |

**Referencias de columnas:** Long = longitud · Edit = editable por el usuario (Sí/No) · Oblig = obligatorio (Sí/No) · — = no aplica.
