# CU-04 · Empaquetar productos

| Ítem | Contenido |
| --- | --- |
| Nombre | Empaquetar productos |
| Actor | Operario de Preparación |
| Responsable | Operaciones – Jefatura del depósito |
| Objetivo | Que el Operario de Preparación arme y rotule los bultos de cada OP (o revise la mercadería si es palet cerrado) y confirme el empaquetado. El operario no carga datos: el sistema calcula los bultos y el operario confirma. |
| Desencadenante | El operario queda libre en su puesto y hay OP cuya mercadería ya entregó Almacén. |
| Precondición | Existe al menos una OP En preparación cuya OS está Cumplida (CU-03). El operario es usuario habilitado. |

## Pasos

1. El Operario de Preparación abre la opción "Empaquetar productos".
2. El sistema asigna la OP más antigua por fecha de recepción (FIFO) que esté En preparación, con su OS Cumplida y todavía no empaquetada.
3. El sistema muestra el número de OP, la modalidad, los productos a empaquetar (SKU, descripción y cantidad) y el total de bultos: en Fulfillment, la suma de las cantidades; en Palet cerrado, 1.
4. El operario arma la cantidad de bultos indicada y rotula cada bulto con el número de OP. Si la modalidad es Palet cerrado, solo revisa la mercadería y rotula el palet.
5. El operario presiona "Confirmar Empaquetado".
6. El sistema pide confirmación con el mensaje "¿Confirma el empaquetado de la OP N° [número] en [bultos] bultos?" – aceptar / cancelar.
7. El operario selecciona aceptar.
8. El sistema registra la OP en estado **Preparada**, con cantidad de bultos, fecha y hora.
9. El sistema muestra el mensaje "Orden de preparación N° [número] preparada".
10. Vuelve a 2 para asignar la siguiente OP.

## Excepciones

- **2.1** No hay OP para empaquetar. **2.2** El sistema muestra "No hay órdenes para empaquetar", deshabilita "Confirmar Empaquetado" y limpia los campos. **2.3** El operario sale de la pantalla.
- **4.1** La mercadería recibida no coincide con la de la OP. **4.2** El operario no confirma e informa al Jefe de Preparación. **4.3** El tratamiento de la diferencia queda fuera de esta entrega.
- **7.1** El operario selecciona cancelar. **7.2** El sistema vuelve a la pantalla sin registrar el empaquetado. **7.3** Vuelve a 4.

## Resultado

| Ítem | Contenido |
| --- | --- |
| Requerimiento cumplido | La OP está embalada y rotulada, con su cantidad de bultos registrada, lista para agruparse en una orden de entrega. |
| Poscondición | La OP queda **Preparada** y aparece en CU-05. Su cantidad de bultos queda disponible para Despacho (CU-07). |
| Salida | El operario puede salir con "Cancelar" (o cerrando la ventana) antes del paso 7. El sistema muestra "No se registró el empaquetado"; la OP sigue En preparación y se vuelve a asignar al abrir la pantalla. |
| Prioridad | Alta. Es la operación "Empaquetado" que pide el requerimiento y la base del cargo variable por Fulfillment. |
| Frecuencia y disponibilidad | Una vez por cada OP. Se usa durante todo el día en 1 a 5 puestos en simultáneo, según la cantidad de órdenes. Disponible en el horario operativo del depósito. |
| Interfaz | La pantalla responde "qué cosas guardo y en qué caja". El operario no elige la OP: la asigna el sistema. El operario no carga datos: el sistema calcula los bultos y el operario confirma. |
| Casos de uso vinculados | CU-03: deja la mercadería en Preparación. CU-05 Generar orden de entrega: agrupa las OP Preparadas. |
