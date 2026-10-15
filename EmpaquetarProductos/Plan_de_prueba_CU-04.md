# Plan de prueba · Pantalla D · Empaquetar productos (CU-04)

**Usuario:** Operario de Preparación · **Depósito:** GBA · **Fecha actual de prueba:** 14/10/2026

## Situación de partida

OP 101 (recibida 14/10/2026 09:00) y OP 102 (14/10/2026 10:30) En preparación con su OS 501 Cumplida. OP 108 En preparación con su OS 503 Pendiente.

| N° OP | Cliente | Recepción | Modalidad | Detalle | Estado | OS |
| --- | --- | --- | --- | --- | --- | --- |
| 101 | Mercadito S.A. | 14/10/2026 09:00 | Fulfillment | CEM-50KG x 10 | En preparación | 501 Cumplida |
| 102 | Mercadito S.A. | 14/10/2026 10:30 | Fulfillment | CEM-50KG x 5 · CAL-25KG x 3 | En preparación | 501 Cumplida |
| 108 | Mercadito S.A. | 14/10/2026 12:00 | Fulfillment | CAL-25KG x 20 | En preparación | 503 Pendiente |

**Productos**

| SKU | Descripción |
| --- | --- |
| CEM-50KG | Bolsa de cemento 50 kg |
| CAL-25KG | Bolsa de cal 25 kg |

Ninguna de las tres OP tiene bultos cargados: el total de bultos lo calcula el sistema al asignar la OP (Fulfillment: suma de las cantidades; Palet cerrado: 1). Para repetir el plan hay que recargar esta base.

## Casos de prueba

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| D.1 | Orden (OP asignada automáticamente) | Numérico entero | 10 | No | No | OP En preparación con OS Cumplida y sin empaquetar | Asignación FIFO por fecha y hora de recepción | El operario no elige la OP: la asigna el sistema. | OP 101 y 102 disponibles | Asigna OP 101 |
|  |  |  |  |  |  |  |  |  | Después de empaquetar la 101 y la 102 (D.5), solo queda la OP 108 (OS 503 Pendiente) | No asigna. Mensaje "No hay órdenes para empaquetar". Campos vacíos. "Confirmar Empaquetado" deshabilitado |
| D.2 | Modalidad | Texto | 15 | No | No | Fulfillment / Palet cerrado | Lo completa el sistema | Campo de solo lectura. | OP 101 | Muestra "Fulfillment" |
| D.3 | Productos a empaquetar | Grilla (SKU, Descripción, Cantidad) | — | No | No | Detalle de la OP asignada | Lo completa el sistema | — | OP 101 | Muestra CEM-50KG · Bolsa de cemento 50 kg · 10 |
| D.4 | Total bultos | Numérico entero | — | No | No | Min 1, sin máximo | Lo calcula el sistema: Fulfillment, suma de las cantidades; Palet cerrado, 1 | Campo de solo lectura. El operario no carga los bultos. | OP 101 (CEM-50KG x 10) | Muestra "10" |
|  |  |  |  |  |  |  |  |  | OP 102 (CEM-50KG x 5 · CAL-25KG x 3) | Muestra "8" |
| D.5 | Botón "Confirmar Empaquetado" | Acción | — | — | — | — | — | Pide confirmación (CU-04, pasos 5 a 10). | OP 101 (10 bultos), confirma | Mensaje de confirmación "¿Confirma el empaquetado de la OP N° 101 en 10 bultos?". Se acepta. OP 101 pasa a Preparada con 10 bultos. Mensaje "Orden de preparación N° 101 preparada". Se asigna la OP 102 |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se registra el empaquetado. La OP 101 sigue en pantalla |
| D.6 | Botón "Cancelar" | Acción | — | — | — | — | — | También al cerrar la ventana. | Con la OP 101 asignada | Mensaje "No se registró el empaquetado". La OP 101 sigue En preparación y se vuelve a asignar al abrir la pantalla |

**Orden sugerido:** D.1 a D.4 con la OP 101 asignada → D.5 (cancelar, luego confirmar 101) → D.4 segundo caso y D.5 con la 102 → D.1 segundo caso (solo queda la 108) → D.6 recargando la base.

**Referencias de columnas:** Long = longitud · Edit = editable por el usuario (Sí/No) · Oblig = obligatorio (Sí/No) · — = no aplica.
