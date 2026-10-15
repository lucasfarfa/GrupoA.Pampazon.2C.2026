# Plan de prueba · Pantalla A · Registrar orden de preparación (CU-01)

**Usuario:** Empleado de Atención al Cliente · **Fecha actual de prueba:** 14/10/2026

## Situación de partida

Fecha actual de prueba: 14/10/2026. OP Pendientes en GBA: 101, 102 y 103 (comprometen CEM-50KG 15, CAL-25KG 3 y ZAP-0042 24). Stock en GBA: CEM-50KG 60 (comprometido 15, disponible 45), CAL-25KG 50 (comprometido 3, disponible 47), ZAP-0042 100 (comprometido 24, disponible 76). Clientes y transportistas según la hoja "Datos base".

**Clientes**

| Cliente | CUIT | Depósito con mercadería |
| --- | --- | --- |
| Mercadito S.A. | 30-71234567-8 | GBA |
| MundoFOX S.R.L. | 30-70987654-3 | GBA |
| Ferretería Norte S.A. | 30-71112223-4 | GBA |
| Construcciones del Plata S.R.L. | 30-70555444-1 | GBA |

Depósitos de la lista: GBA, ROS, CBA, MDZ (relevamiento). Ningún cliente tiene mercadería fuera de GBA.

**Stock en GBA**

| SKU | Descripción | Cliente | Stock | Comprometido | Disponible |
| --- | --- | --- | --- | --- | --- |
| CEM-50KG | Bolsa de cemento 50 kg | Mercadito S.A. | 60 | 15 | 45 |
| CAL-25KG | Bolsa de cal 25 kg | Mercadito S.A. | 50 | 3 | 47 |
| ZAP-0042 | Caja de zapatillas | MundoFOX S.R.L. | 100 | 24 | 76 |
| TOR-M8 | Caja de tornillos M8 x 100 | Ferretería Norte S.A. | 500 | 0 | 500 |
| ARE-25KG | Bolsa de arena 25 kg | Construcciones del Plata S.R.L. | 800 | 0 | 800 |

Comprometido = OP 101 (CEM-50KG x 10), 102 (CEM-50KG x 5 · CAL-25KG x 3) y 103 (ZAP-0042 x 24), Pendientes.

## Casos de prueba

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| A.1 | Cliente | Lista desplegable | 50 | Sí | Sí | Clientes con contrato vigente (archivo de clientes) | Debe elegirse de la lista; no admite texto libre | Al elegirlo se completa el CUIT. Si se cambia con productos cargados, pide confirmación y vacía la lista (CU-01, exc. 17.7). | (sin seleccionar) + Registrar OP | Rechazo. Mensaje "Debe completar: Cliente" |
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
|  |  |  |  |  |  |  |  |  | 245687790 | Rechazo. Mensaje "El DNI debe tener 7 u 8 dígitos numéricos" |
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
| A.12 | Botón "Registrar OP" | Acción | — | — | — | — | Valida todos los campos antes de registrar | Pide confirmación antes de registrar (CU-01, pasos 18 a 29). | Mercadito S.A. / GBA / Fulfillment / 24568779 / Jose Gomez / 20/10/2026 / CEM-50KG x 20, confirma | Se acepta. OP registrada en estado Pendiente. Mensaje "Orden de preparación N° [n] registrada". Disponible de CEM-50KG pasa a 25 |
|  |  |  |  |  |  |  |  |  | Mismo caso; se cancela la confirmación | No se registra la OP. Los datos quedan cargados |
| A.13 | Botón "Cancelar" | Acción | — | — | — | — | — | — | Con datos cargados | Pide confirmación "No se registró ninguna orden de preparación. ¿Desea salir?" |
|  |  |  |  |  |  |  |  |  | Sin datos cargados | Cierra la pantalla |

**Orden sugerido:** campos A.1 a A.11 en cualquier orden → A.12 cancelando la confirmación → A.12 confirmando (cambia el disponible de CEM-50KG a 25). Para repetir el plan hay que reiniciar la aplicación.

**Referencias de columnas:** Long = longitud · Edit = editable por el usuario (Sí/No) · Oblig = obligatorio (Sí/No) · — = no aplica.
