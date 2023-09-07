# 2023-2c Clase 3-Practica
## En Clase - Intro a Layouts y Validaciones
- Vimos como hacer un Layout con el fondo del océano
- Como anidar Layouts (_BaseLayout.cshtml --> _OceanoLayout.cshtml)
- Formulario Encuestas/EnviarRespuesta con validaciones

## Tarea Hacer un nuevo Formulario con validaciones y Layout
- Tienen libertad para elegir la tematica del formulario, donde puedan implementar todos los tipos de validaciones vistos en clase.
- Al momento de crear un layout hagan 2 layouts anidado como vimos en clase, pueden hacer que el layout elegido sea dinamico en base a lo elegido en su formulario (pueden usar una variable static para que quede guardada) y luego en la vista determinan el valor asi:
@{
    Layout = ViewData["Layout"] as string ?? "~/Views/Shared/_OceanoLayout.cshtml";
}


## Intrucciones
- Hacer un fork de este repositorio
- Crear Pull Request contra el repositorio original