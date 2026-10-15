# CU-06 · Recepcionar orden de entrega

| Ítem | Contenido |
| --- | --- |
| Nombre | Recepcionar orden de entrega |
| Actor | Operario de Despacho |
| Responsable | Operaciones – Jefatura del depósito |
| Objetivo | Que el Operario de Despacho registre que los bultos de una OE llegaron al depósito transitorio de Despacho, asumiendo la responsabilidad sobre esa mercadería. |
| Desencadenante | Preparación entrega en Despacho los bultos de una OE junto con el documento. |
| Precondición | Existe al menos una OE Emitida en el depósito (CU-05). El operario es usuario habilitado y tiene asignado el depósito. |

## Pasos

1. El Operario de Despacho abre la opción "Recepcionar orden de entrega".
2. El sistema muestra la lista de OE Emitidas del depósito: N° OE, transportista, cliente, fecha de emisión y N° de las OP que contiene.
3. El operario recibe los bultos y controla físicamente que estén todos los de la OE.
4. El operario selecciona la OE en la lista. Solo puede seleccionar una.
5. El operario presiona "Confirmar recepción en Despacho".
6. El sistema comprueba que haya una OE seleccionada.
7. El sistema pide confirmación con el mensaje "¿Confirma la recepción de la OE N° [número] en Despacho?" – aceptar / cancelar.
8. El operario selecciona aceptar.
9. El sistema registra la OE en estado Pendiente de entrega, con fecha, hora y usuario.
10. El sistema registra la mercadería de la OE en el depósito transitorio de Despacho, bajo su responsabilidad.
11. El sistema muestra el mensaje "Orden de entrega N° [número] recepcionada" y la quita de la lista.

## Excepciones

- **2.1** No hay OE Emitidas. **2.2** El sistema muestra "No hay órdenes de entrega para recepcionar". **2.3** El operario sale de la pantalla.
- **3.1** Faltan bultos de la OE. **3.2** El operario no confirma la recepción y lo informa a Preparación. **3.3** La OE queda Emitida hasta que se completen los bultos.
- **6.1** El sistema muestra "Debe seleccionar una orden de entrega". **6.2** Vuelve a 4.
- **8.1** El operario selecciona cancelar. **8.2** El sistema vuelve a la pantalla sin registrar la recepción. **8.3** Vuelve a 4.

## Resultado

| Ítem | Contenido |
| --- | --- |
| Requerimiento cumplido | Queda registrado el cambio de responsabilidad de Preparación a Despacho y la nueva ubicación física de la mercadería dentro del inventario. |
| Poscondición | La OE queda Pendiente de entrega: recién en este estado puede emitirse su remito (CU-07). Sus OP siguen En entrega. |
| Salida | El operario puede salir con "Cancelar" en cualquier momento. Como solo selecciona, no hay datos que se pierdan. |
| Prioridad | Alta. Sin esta confirmación no se puede emitir el remito, y la mercadería de terceros quedaría sin responsable registrado entre dos secciones. |
| Frecuencia y disponibilidad | Una vez por cada OE emitida; varias veces por día. Disponible en el horario operativo del depósito. |
| Interfaz | La lista muestra las OP de cada OE para que el operario controle los bultos rotulados contra el documento. "Actualizar" vuelve a leer la lista de OE Emitidas. |
| Casos de uso vinculados | CU-05: aporta las OE Emitidas. CU-07 Generar remito y despachar: toma las OE Pendientes de entrega. |
