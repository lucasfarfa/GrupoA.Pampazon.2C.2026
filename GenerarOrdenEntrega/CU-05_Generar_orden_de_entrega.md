# CU-05 · Generar orden de entrega

| Ítem | Contenido |
| --- | --- |
| Nombre | Generar orden de entrega |
| Actor | Operario de Preparación |
| Responsable | Operaciones – Jefatura del depósito |
| Objetivo | Que el Operario de Preparación consolide en una orden de entrega las OP Preparadas de un mismo cliente, transportista y fecha de retiro, para trasladarlas a Despacho. |
| Desencadenante | Hay OP Preparadas sin orden de entrega y el operario decide pasarlas a Despacho. |
| Precondición | Existe al menos una OP Preparada sin OE en el depósito (CU-04). El operario es usuario habilitado y tiene asignado el depósito. |

## Pasos

1. El Operario de Preparación abre la opción "Generar orden de entrega".
2. El sistema busca las OP Preparadas del depósito que no tienen OE.
3. El sistema las agrupa por cliente, DNI del transportista y fecha de retiro.
4. El sistema muestra una fila por grupo: cliente, transportista, fecha de retiro y cantidad de OP.
5. El operario marca una fila. Solo puede quedar una fila marcada: si marca otra, el sistema desmarca la anterior.
6. El operario presiona "Generar Orden de Entrega".
7. El sistema comprueba que haya una fila marcada.
8. El sistema pide confirmación con el mensaje "¿Confirma la orden de entrega para [cliente], transportista [nombre], retiro [fecha], con [cantidad] OP?" – aceptar / cancelar.
9. El operario selecciona aceptar.
10. El sistema asigna el número de OE y la registra en estado Emitida, con depósito, fecha de emisión, cliente, DNI y nombre del transportista, fecha de retiro, OP incluidas y bultos de cada OP.
11. El sistema pasa las OP incluidas a estado En entrega.
12. El sistema muestra el mensaje "Orden de entrega N° [número] generada" y quita la fila de la lista.
13. El operario traslada los bultos rotulados al área de Despacho junto con la OE.

## Excepciones

- **2.1** No hay OP Preparadas sin OE. **2.2** El sistema muestra "No hay órdenes preparadas pendientes de orden de entrega". **2.3** El operario sale de la pantalla.
- **7.1** El sistema muestra "Debe seleccionar un grupo de órdenes". **7.2** Vuelve a 5.
- **9.1** El operario selecciona cancelar. **9.2** El sistema vuelve a la pantalla sin generar la OE. **9.3** Vuelve a 5.

## Resultado

| Ítem | Contenido |
| --- | --- |
| Requerimiento cumplido | Las OP Preparadas de un mismo cliente, transportista y fecha de retiro quedan consolidadas en una OE que habilita a Despacho a entregarlas. |
| Poscondición | La OE queda Emitida y aparece en CU-06. Sus OP quedan En entrega y no pueden incluirse en otra OE. La mercadería sigue bajo responsabilidad de Preparación hasta que Despacho confirme la recepción. |
| Salida | El operario puede salir con "Cerrar" en cualquier momento. Como solo selecciona, no hay datos que se pierdan. |
| Prioridad | Alta. La OE es el documento que habilita a Despacho a entregar la mercadería al transportista. |
| Frecuencia y disponibilidad | Varias veces por día. La OE se arma con lo que ya está preparado, sin esperar todas las OP de un cliente, para no generar cuellos de botella en Preparación. Disponible en el horario operativo del depósito. |
| Interfaz | El operario no arma la OE a mano: el sistema propone los grupos, así una OE no puede mezclar clientes, transportistas ni fechas de retiro. Una fila marcada genera una OE. |
| Casos de uso vinculados | CU-04: aporta las OP Preparadas. CU-06 Recepcionar orden de entrega: confirma su llegada a Despacho. CU-07 Generar remito y despachar: la cierra. |
