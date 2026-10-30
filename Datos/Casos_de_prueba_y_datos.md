# Casos de prueba y datos

Todas las pantallas leen el mismo juego de datos de `Datos/`. Cada OP tiene un solo estado, así que cada pantalla trabaja con las órdenes que le corresponden a su etapa. Para que los resultados coincidan con esta guía, las pruebas parten de los datos sin modificar.

## Qué hay cargado

| Almacén | Cantidad | Detalle |
| --- | --- | --- |
| `Cliente` | 6 | Los 4 del plan, más Distribuidora del Litoral S.A. y Almacenes de Cuyo S.R.L. |
| `Deposito` | 4 | GBA, ROS y CBA con posiciones. MDZ sin posiciones |
| `Mercaderia` | 14 | CEM-50KG, CAL-25KG y ZAP-0042 repetidos entre clientes. Poco stock: YER-1KG (3) y CAL-25KG de Ferretería Norte (5) |
| `OrdenPreparacion` | 30 | 5 Pendientes, 7 En preparación, 4 Preparadas, 11 En entrega, 3 Cumplidas. GBA, ROS y CBA. Ambas modalidades |
| `OrdenSeleccion` | 7 | 3 Pendientes (501, 502, 506) y 4 Cumplidas (500, 503, 504, 505) |
| `OrdenEntrega` | 11 | 2 Emitidas, 5 Pendientes de entrega, 2 Remito emitido, 2 Cumplidas |
| `Remito` | 4 | 2 Emitidos (R-410, R-411) y 2 Cumplidos (R-408, R-409) |

Próximos números: OP 131, OS 507, OE 712, R-412.

## Qué orden usa cada pantalla

| Hoja | Pantalla | Datos de partida (GBA) |
| --- | --- | --- |
| A | Registrar OP | Mercadito S.A.: CEM-50KG disponible 45, CAL-25KG disponible 47. Sin mercadería en ROS |
| B | Generar OS | OP 101, 102 (recibidas el 14/10) y 103 (recibida el 13/10). ROS: OP 111. CBA: OP 112 |
| C | Preparar productos | OS 501 (OP 104 y 113) y OS 502 (OP 114) |
| D | Empaquetar | OP 105, 108 y 115, en ese orden. OS 503 Cumplida |
| E | Generar OE | OP 106, 107, 117 y 118 Preparadas sin OE |
| F | Recepcionar OE | OE 701 y 702 Emitidas. OE 700 no se lista |
| G | Remito y despacho | Jose Gomez: OE 700, 704, 706. Daniel Baez: OE 703, 705. Alejo Cisterna: R-410 y R-411. DNI 22333444: no existe |

## Qué cambia cada caso en los JSON

Solo se listan los casos que graban. Los rechazos y las cancelaciones no cambian ningún archivo.

| Caso | Acción | `OrdenPreparacion` | `OrdenSeleccion` | `OrdenEntrega` | `Remito` | `Deposito` | `Mercaderia` |
| --- | --- | --- | --- | --- | --- | --- | --- |
| A.12 | Mercadito, GBA, CEM-50KG x 20 | Alta OP 131 Pendiente | — | — | — | — | CEM-50KG comprometida 15 → 35 (disponible 25) |
| B.9 | Generar OS con OP 101 y 102 | 101 y 102 → En preparación | Alta OS 507 Pendiente: CEM-50KG 10 en 12-43-2, 5 en 12-44-1; CAL-25KG 3 en 03-10-1 | — | — | — | — |
| B.12 | Generar OS con OP 101, 102 y 103 | Las tres → En preparación | Alta OS 507 Pendiente | — | — | — | — |
| C.4 | Confirmar OS 501 | — | 501 → Cumplida, con fecha | — | — | 05-12-1 TOR-M8 500 → 470. 07-02-1 CLA-2P 10 → 0. 07-03-1 CLA-2P 20 → 15 | TOR-M8 comprometida 30 → 0, en preparación 0 → 30. CLA-2P comprometida 15 → 0, en preparación 0 → 15 |
| D.1 | Asignar OP 105 | `TomadaPreparacion` true | — | — | — | — | — |
| D.5 | Confirmar OP 105 (10 bultos) | 105 → Preparada, `Bultos` 10, `FechaEmpaquetado` | — | — | — | — | — |
| D.6 | Cancelar con OP 105 asignada | `TomadaPreparacion` false | — | — | — | — | — |
| E.2 | Grupo Construcciones del Plata, retiro 16/10 | 106 y 107 → En entrega | — | Alta OE 712 Emitida | — | — | — |
| F.4 | Recepcionar OE 701 | — | — | 701 → Pendiente de entrega, con `FechaRecepcionDespacho` | — | — | CEM-50KG de Mercadito: en preparación 12 → 0, en despacho 0 → 12. CAL-25KG de Mercadito: en preparación 36 → 30, en despacho 15 → 21 |
| G.5 | Emitir con OE 700, 704 y 706 | — | — | Las tres → Remito emitido | Alta R-412 (Mercadito) y R-413 (MundoFOX) Emitidos | — | — |
| G.7 | Confirmar R-412 y R-413 | 109, 123 y 126 → Cumplida | — | 700, 704 y 706 → Cumplida | Cumplidos, con fecha | — | CAL-25KG de Mercadito: en despacho 15 → 0. ZAP-0042 de MundoFOX: en despacho 10 → 6 |
| G.7 | Confirmar R-410 | 110 → Cumplida | — | 710 → Cumplida | Cumplido, con fecha | — | ZAP-0042 de MundoFOX: en despacho 10 → 4 |

## Resultados esperados con estos datos

- **B:** "ayer" es 13/10/2026 y "hoy" es 14/10/2026. Hay que elegir esas fechas en los filtros, porque las recepciones son fijas.
- **C.3, OS 501:** 05-12-1 TOR-M8 30 · 07-02-1 CLA-2P 10 · 07-03-1 CLA-2P 5. OS 502: 12-05-1 ZAP-0042 10.
- **D:** se asigna 105 (Fulfillment, 10 bultos), después 108 (Fulfillment, 20 bultos) y 115 (Palet cerrado, 1 bulto). Después ya no hay órdenes para empaquetar, si la OS 501 y la 502 siguen Pendientes.
- **E.1:** 3 filas: Construcciones del Plata · Daniel Baez · 16/10 · 2 — Construcciones del Plata · Daniel Baez · 17/10 · 1 — MundoFOX · Jose Gomez · 16/10 · 1.
- **G.3:** Jose Gomez ve Mercadito 700 (OP 109 · 5), Mercadito 704 (OP 123 · 10) y MundoFOX 706 (OP 126 · 1). Daniel Baez ve Construcciones del Plata 705 (OP 124, 125 · 9) y Ferretería Norte 703 (OP 122 · 30).
- **G.1:** con 20562667 no hay OE pendientes y se ven R-410 y R-411.

## Casos agregados

No están en la planilla: los habilitan los datos nuevos. Si no se indica otra cosa, el depósito es GBA y se parte de los datos sin modificar.

| Caso | Pantalla | Qué prueba | Datos de prueba | Resultado esperado | Qué cambia en los JSON |
| --- | --- | --- | --- | --- | --- |
| N.1 | Registrar OP | SKU por cliente | Construcciones del Plata, CEM-50KG | Lista ARE-25KG y CEM-50KG. Disponible 30, no 45 como Mercadito | — |
| N.2 | Registrar OP | SKU por cliente | Ferretería Norte | Lista CAL-25KG, CLA-2P y TOR-M8 | — |
| N.3 | Registrar OP | Poco stock | Almacenes de Cuyo, CBA, YER-1KG, cantidad 2 | Disponible 1. Rechazo: "La cantidad supera el disponible del SKU YER-1KG: 1 unidades" | — |
| N.4 | Registrar OP | Poco stock | Ferretería Norte, CAL-25KG, cantidad 5, confirma | Se acepta. Disponible 0 | Alta OP 131 Pendiente. CAL-25KG de Ferretería Norte: comprometida 0 → 5 |
| N.5 | Registrar OP | Mismo cliente en otro depósito | Mercadito, CBA | Lista CAL-25KG. Disponible 25 | — |
| N.6 | Registrar OP | Mismo SKU en otro depósito | MundoFOX, ROS, ZAP-0042 | Disponible 60. En GBA es 66 | — |
| N.7 | Registrar OP | Depósito sin mercadería | Cualquier cliente, MDZ | Rechazo: "El cliente no tiene mercadería en el depósito seleccionado" | — |
| N.8 | Generar OS | Filtro por depósito | Depósito ROS, sin filtro de fechas | Lista solo la OP 111 | — |
| N.9 | Generar OS | Otro depósito | Depósito ROS, OP 111, confirma | OS registrada Pendiente: ARR-1KG 40 en 01-01-1 | Alta OS 507 Pendiente. OP 111 → En preparación |
| N.10 | Generar OS | Depósito sin OP | Depósito MDZ | Mensaje "No hay órdenes de preparación pendientes" | — |
| N.11 | Preparar productos | Filtro por depósito | Depósito GBA | Lista OS 501 y 502. No lista la OS 506 de ROS | — |
| N.12 | Empaquetar | Palet cerrado | OP 115 (ZAP-0042 x 12), confirma | Total bultos 1 | OP 115 → Preparada, `Bultos` 1, `FechaEmpaquetado` |
| N.13 | Generar OE | Palet cerrado | Grupo MundoFOX · Jose Gomez · 16/10, confirma | OE con 1 OP y 1 bulto | Alta OE 712 Emitida. OP 118 → En entrega |
| N.14 | Recepcionar OE | OE de un solo cliente | OE 702, confirma | Sale de la lista. Queda la OE 701 | 702 → Pendiente de entrega. ZAP-0042 de MundoFOX: en preparación 22 → 14, en despacho 10 → 18 |
| N.15 | Remito y despacho | Dos remitos de un transportista | DNI 32321987, OE 705 y 703, confirma | Dos remitos: Construcciones del Plata y Ferretería Norte | 703 y 705 → Remito emitido. Alta R-412 y R-413 Emitidos |
| N.16 | Remito y despacho | Firma de varios remitos | DNI 20562667, R-410 y R-411, confirma | Los dos salen de la lista | R-410 y R-411 → Cumplidos. OE 710 y 711 → Cumplida. OP 110 y 127 → Cumplida. ZAP-0042 de MundoFOX: en despacho 10 → 4. ARE-25KG: en despacho 11 → 9 |
| N.17 | Remito y despacho | Documentos ya cerrados | DNI 32321987 | No lista las OE 708 y 709 ni el R-409 | — |

## Circuito completo

La OP 101 va de Pendiente a Cumplida usando las pantallas:

| Paso | Pantalla | Resultado |
| --- | --- | --- |
| 1 | Generar OS, depósito GBA | Incluir OP 101 y 102 → OS 507. Las OP pasan a En preparación |
| 2 | Preparar productos | Confirmar OS 507 → Cumplida. Baja el stock: 12-43-2 de 10 a 0, 12-44-1 de 50 a 45, 03-10-1 de 50 a 47 |
| 3 | Empaquetar | La OP 101 se asigna primero por FIFO → Preparada con 10 bultos. La 102 queda con 8 |
| 4 | Generar OE | Grupo Mercadito · Jose Gomez · 20/10 → OE 712 Emitida. Las OP pasan a En entrega |
| 5 | Recepcionar OE | OE 712 → Pendiente de entrega |
| 6 | Generar remito | DNI 24568779, OE 712 → R-412 Emitido. La OE pasa a Remito emitido |
| 7 | Generar remito | Confirmar R-412 → Cumplido. OE 712 y OP 101 y 102 → Cumplida |

Ninguna pantalla depende de otra: cada una lee del almacén lo que dejó la anterior.
