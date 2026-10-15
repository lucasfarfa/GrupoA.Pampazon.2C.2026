# Plan de prueba · Pantalla E · Generar orden de entrega (CU-05)

**Usuario:** Operario de Preparación · **Depósito:** GBA · **Fecha actual de prueba:** 14/10/2026

## Situación de partida

OP Preparadas sin OE, todas con transportista Jose Gomez (DNI 24568779): 101 (10 bultos) y 102 (8 bultos) de Mercadito S.A. con retiro 20/10/2026; 105 (10 bultos) de Mercadito S.A. con retiro 21/10/2026; 103 (1 bulto) de MundoFOX S.R.L. con retiro 20/10/2026.

| N° OP | Cliente | Transportista (DNI) | Fecha de retiro | Modalidad | Detalle | Bultos | Estado | OE |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 101 | Mercadito S.A. | Jose Gomez (24568779) | 20/10/2026 | Fulfillment | CEM-50KG x 10 | 10 | Preparada | — |
| 102 | Mercadito S.A. | Jose Gomez (24568779) | 20/10/2026 | Fulfillment | CEM-50KG x 5 · CAL-25KG x 3 | 8 | Preparada | — |
| 105 | Mercadito S.A. | Jose Gomez (24568779) | 21/10/2026 | Fulfillment | CAL-25KG x 10 | 10 | Preparada | — |
| 103 | MundoFOX S.R.L. | Jose Gomez (24568779) | 20/10/2026 | Palet cerrado | ZAP-0042 x 24 | 1 | Preparada | — |
| 109 | Mercadito S.A. | Jose Gomez (24568779) | 17/10/2026 | Fulfillment | CAL-25KG x 5 | 5 | En entrega | 700 |

La OP 109 ya tiene la OE 700: sirve para el caso "OP Preparada que ya tiene OE" (no debe aparecer en ningún grupo).


## Casos de prueba

| N° | Descripción | Tipo | Long | Edit | Oblig | Valores posibles | Validaciones | Observaciones | Datos de prueba | Resultado esperado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| E.1 | Órdenes preparadas sin orden de entrega | Grilla con casillas, una sola fila marcada (Cliente, Transportista, Fecha retiro, Cantidad OP) | — | No | Sí (una fila) | Grupos de OP Preparadas sin OE | Agrupa por cliente + DNI del transportista + fecha de retiro | Una fila marcada genera una OE. Solo se puede marcar una fila. | Situación de partida | Muestra 3 filas: Mercadito S.A. · Jose Gomez · 20/10/2026 · 2 — Mercadito S.A. · Jose Gomez · 21/10/2026 · 1 — MundoFOX S.R.L. · Jose Gomez · 20/10/2026 · 1 |
|  |  |  |  |  |  |  |  |  | OP Preparada que ya tiene OE | No aparece en ningún grupo |
|  |  |  |  |  |  |  |  |  | Se marca una fila y después otra | Queda marcada solo la última |
|  |  |  |  |  |  |  |  |  | Sin OP Preparadas sin OE | Mensaje "No hay órdenes preparadas pendientes de orden de entrega" |
| E.2 | Botón "Generar Orden de Entrega" | Acción | — | — | — | — | Una fila marcada | Pide confirmación (CU-05, pasos 6 a 12). | Sin fila marcada | Rechazo. Mensaje "Debe seleccionar un grupo de órdenes" |
|  |  |  |  |  |  |  |  |  | Fila Mercadito S.A. · 20/10/2026, confirma | Se acepta. OE registrada Emitida con OP 101 y 102 y sus bultos. Las OP pasan a En entrega. Mensaje "Orden de entrega N° [n] generada". La fila desaparece |
|  |  |  |  |  |  |  |  |  | Se cancela la confirmación | No se genera la OE |
| E.3 | Botón "Cerrar" | Acción | — | — | — | — | — | — | En cualquier momento | Cierra la pantalla sin cambios |

**Orden sugerido:** E.1 primer y segundo caso → E.2 sin fila, cancelar, y luego confirmar Mercadito 20/10 → generar las OE de las filas restantes → E.1 tercer caso (sin OP Preparadas sin OE). Para repetir el plan hay que recargar la base.

**Referencias de columnas:** Long = longitud · Edit = editable por el usuario (Sí/No) · Oblig = obligatorio (Sí/No) · — = no aplica.
