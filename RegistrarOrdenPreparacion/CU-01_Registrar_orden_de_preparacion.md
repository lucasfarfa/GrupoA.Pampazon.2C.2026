# CU-01 · Registrar orden de preparación

| Ítem | Contenido |
| --- | --- |
| Nombre | Registrar orden de preparación |
| Actor | Empleado de Atención al Cliente |
| Responsable | Gestión Comercial – Atención al Cliente |
| Objetivo | Que el Empleado de Atención al Cliente registre el pedido de salida de mercadería de un cliente, asignándolo al depósito que lo va a cumplir, y que el sistema comprometa el stock pedido. |
| Desencadenante | El cliente envía una orden de preparación con la mercadería que quiere retirar, el depósito, la modalidad, el transportista autorizado y la fecha de retiro. |
| Precondición | El cliente tiene contrato vigente y mercadería almacenada en el depósito. Los SKU están declarados según el nomenclador. El empleado es usuario habilitado del sistema. |

## Pasos

1. El Empleado de Atención al Cliente abre la opción "Registrar orden de preparación".
2. El sistema muestra la pantalla con la lista de clientes, la lista de depósitos y el resto de los campos vacíos.
3. El empleado selecciona el cliente.
4. El sistema muestra el CUIT del cliente, obtenido del archivo de clientes.
5. El empleado selecciona el depósito.
6. El sistema carga en la lista de SKU los productos que el cliente tiene en stock en ese depósito.
7. El empleado selecciona la modalidad: Fulfillment o Palet cerrado.
8. El empleado ingresa el DNI y el nombre del transportista autorizado.
9. El empleado ingresa la fecha de retiro.
10. El empleado selecciona un SKU.
11. El sistema muestra la cantidad disponible de ese SKU para el cliente en el depósito (stock en almacén menos cantidad comprometida por otras OP).
12. El empleado ingresa la cantidad y presiona "Agregar".
13. El sistema comprueba que la cantidad sea un número entero mayor a cero.
14. El sistema comprueba que la cantidad no supere el disponible.
15. El sistema comprueba que el SKU no esté ya en la lista.
16. El sistema agrega el SKU y la cantidad a la lista "Productos a preparar" y deja vacíos los campos SKU y Cantidad.
17. El empleado repite los pasos 10 a 16 por cada producto de la orden.
18. El empleado presiona "Registrar OP".
19. El sistema comprueba que estén cargados cliente, depósito, modalidad, DNI, nombre del transportista y fecha de retiro.
20. El sistema comprueba que el DNI tenga 7 u 8 dígitos numéricos.
21. El sistema comprueba que el nombre del transportista tenga solo letras, espacios, apóstrofos y guiones.
22. El sistema comprueba que la fecha de retiro sea una fecha válida con formato dd/mm/aaaa.
23. El sistema comprueba que la fecha de retiro no sea anterior a la fecha actual.
24. El sistema comprueba que la lista tenga al menos un producto.
25. El sistema pide confirmación con el mensaje "¿Confirma el registro de la orden de preparación?" – aceptar / cancelar.
26. El empleado selecciona aceptar.
27. El sistema asigna el número de OP y la registra en estado Pendiente, con fecha de recepción, cliente, depósito, modalidad, DNI y nombre del transportista, fecha de retiro y detalle de SKU y cantidades.
28. El sistema compromete la cantidad de cada SKU de la OP.
29. El sistema muestra el mensaje "Orden de preparación N° [número] registrada" y deja la pantalla vacía para una nueva orden.

## Excepciones

- **6.1** El sistema muestra "El cliente no tiene mercadería en el depósito seleccionado". **6.2** Vuelve a 5.
- **12.1** El empleado presiona "Agregar" sin un SKU seleccionado. **12.2** El sistema muestra "Debe seleccionar un SKU". **12.3** Vuelve a 10.
- **13.1** El sistema muestra "La cantidad debe ser un número entero mayor a cero". **13.2** Vuelve a 12.
- **14.1** El sistema muestra "La cantidad supera el disponible del SKU [SKU]: [disponible] unidades". **14.2** Vuelve a 12.
- **15.1** El sistema muestra "El SKU ya está en la orden. Quítelo de la lista para cambiar la cantidad". **15.2** Vuelve a 10.
- **17.1** El empleado selecciona un producto de la lista y presiona "Quitar seleccionado". **17.2** El sistema lo quita de la lista. **17.3** Vuelve a 10.
- **17.4** El empleado presiona "Quitar seleccionado" sin un producto seleccionado. **17.5** El sistema muestra "Seleccione un producto de la lista". **17.6** Vuelve a 10.
- **17.7** El empleado cambia el cliente o el depósito con productos ya cargados. **17.8** El sistema muestra "Se quitarán los productos cargados. ¿Desea continuar?" – aceptar / cancelar. **17.9** Si acepta, el sistema vacía la lista y vuelve a 4; si cancela, mantiene el cliente y el depósito anteriores.
- **19.1** El sistema muestra "Debe completar: [campos faltantes]". **19.2** Vuelve al paso del primer campo faltante (3, 5, 7, 8 o 9).
- **20.1** El sistema muestra "El DNI debe tener 7 u 8 dígitos numéricos". **20.2** Vuelve a 8.
- **21.1** El sistema muestra "El nombre solo admite letras, espacios, apóstrofos y guiones". **21.2** Vuelve a 8.
- **22.1** El sistema muestra "Fecha inválida". **22.2** Vuelve a 9.
- **23.1** El sistema muestra "La fecha de retiro no puede ser anterior a hoy". **23.2** Vuelve a 9.
- **24.1** El sistema muestra "Debe agregar al menos un producto". **24.2** Vuelve a 10.
- **26.1** El empleado selecciona cancelar. **26.2** El sistema vuelve a la pantalla con los datos cargados, sin registrar la OP. **26.3** Vuelve a 10.

## Resultado

| Ítem | Contenido |
| --- | --- |
| Requerimiento cumplido | La OP queda registrada en el depósito que la va a cumplir y el stock pedido queda comprometido, de modo que no se puede prometer dos veces. |
| Poscondición | La OP queda Pendiente y aparece en CU-02 para ese depósito. El disponible de cada SKU baja en la cantidad pedida. La OP no se puede modificar desde esta pantalla. |
| Salida | El empleado puede salir con "Cancelar" en cualquier momento. Si hay datos cargados, el sistema muestra "No se registró ninguna orden de preparación. ¿Desea salir?" – aceptar / cancelar. También puede salir después del paso 29. |
| Prioridad | Alta. Es la entrada de todo el circuito de salida: sin OP registrada no hay OS, empaquetado ni despacho. |
| Frecuencia y disponibilidad | Se usa cada vez que llega una orden de un cliente, varias veces por día. Un solo cliente puede enviar cientos de OP en un día (el relevamiento da el ejemplo de 400). Debe estar disponible en el horario de Atención al Cliente. |
| Interfaz | Cliente, depósito y SKU se eligen de listas para evitar errores de tipeo. CUIT y disponible se muestran sin poder editarse. La misma pantalla sirve para todos los depósitos del país. |
| Casos de uso vinculados | CU-02 Generar orden de selección: toma las OP Pendientes. Recepcionar productos (fuera de esta entrega): aporta el stock en almacén. |
