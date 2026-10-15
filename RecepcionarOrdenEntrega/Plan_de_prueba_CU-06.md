# Plan de prueba · Pantalla F · Recepcionar orden de entrega (CU-06)

**Usuario:** Operario de Despacho · **Depósito:** GBA · **Fecha actual de prueba:** 14/10/2026

## Situación de partida

OE Emitidas en GBA: 701 (Mercadito S.A., Jose Gomez, OP 101 y 102) y 702 (MundoFOX S.R.L., Jose Gomez, OP 103). OE 700 ya está Pendiente de entrega.

| N° OE | Estado | Cliente | Transportista (DNI) | Fecha de emisión | OP | Bultos |
| --- | --- | --- | --- | --- | --- | --- |
| 700 | Pendiente de entrega | Mercadito S.A. | Jose Gomez (24568779) | 14/10/2026 | 109 | 5 |
| 701 | Emitida | Mercadito S.A. | Jose Gomez (24568779) | 14/10/2026 | 101, 102 | 18 |
| 702 | Emitida | MundoFOX S.R.L. | Jose Gomez (24568779) | 14/10/2026 | 103 | 1 |

Las OP de las OE están En entrega. Datos de cada OP en el plan general (Datos base).


## Casos de prueba

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| F.1 | Órdenes de Entrega emitidas | Grilla con selección simple (N° OE, Transportista, Cliente, Fecha emisión, N° OP) | — | No | Sí (una fila) | OE Emitidas del depósito | — | Permite controlar los bultos rotulados contra las OP de la OE. | Situación de partida | Muestra OE 701 y 702 con sus datos. No muestra la OE 700 |
|  |  |  |  |  |  |  |  |  | Sin OE Emitidas | Mensaje "No hay órdenes de entrega para recepcionar" |
| F.2 | Botón "Actualizar" | Acción | — | — | — | — | — | — | Con la lista cargada, sin cambios + Actualizar | La lista se vuelve a cargar con las mismas OE emitidas (701 y 702) |
| F.3 | Botón "Confirmar recepción en Despacho" | Acción | — | — | — | — | Una OE seleccionada | Pide confirmación (CU-06, pasos 5 a 11). | Sin OE seleccionada | Rechazo. Mensaje "Debe seleccionar una orden de entrega" |
|  |  |  |  |  |  |  |  |  | OE 701 seleccionada, confirma | Se acepta. OE 701 pasa a Pendiente de entrega. Su mercadería queda en el depósito transitorio de Despacho. Mensaje "Orden de entrega N° 701 recepcionada". Sale de la lista |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se registra la recepción. La OE sigue Emitida |
| F.4 | Botón "Cancelar" | Acción | — | — | — | — | — | — | En cualquier momento | Cierra la pantalla sin cambios |

**Orden sugerido:** F.1 primer caso y F.2 → F.3 sin OE, cancelar, y luego confirmar 701 → confirmar 702 → F.1 segundo caso (sin OE Emitidas). Para repetir el plan hay que recargar la base.

**Referencias de columnas:** Long = longitud · Edit = editable por el usuario (Sí/No) · Oblig = obligatorio (Sí/No) · — = no aplica.
