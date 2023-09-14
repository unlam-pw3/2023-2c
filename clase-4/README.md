# 2023-2c Clase 4-POO + Web Api "Juego de Rol con Personajes, Armas y Objetos"
## En Clase - Intro a POO  y Web Api
- Vimos como hacer una Api de Personajes y Armas
- Agregamos unit tests
- Vimos Swagger
- Vimos Postman

# Enunciado en Clase "Juego de Rol con Personajes, Armas y Objetos": 

En este ejercicio, se te pide que diseñes y desarrolles un juego de rol (RPG) en el que los jugadores pueden crear sus propios personajes, equiparlos con armas y objetos mágicos, y participar en emocionantes aventuras en un mundo lleno de desafíos.

## Funcionalidades Requeridas

1. **Creación de Personajes:** Los jugadores deben poder crear nuevos personajes con las siguientes propiedades:
   - Nombre
   - Nivel de experiencia (XP)
   - Puntos de salud (HP)

2. **Equipamiento de Armas:** Debe existir un conjunto de armas disponibles en el juego, cada una con las siguientes propiedades:
   - Nombre
   - Poder de ataque (PoderAtaque)
   
   Los jugadores deben poder equipar a sus personajes con armas.

3. **Uso de Objetos Mágicos:** Debe haber una variedad de objetos mágicos disponibles, cada uno con las siguientes propiedades:
   - Nombre
   - Efecto mágico (Efecto)
   
   Los jugadores deben poder utilizar estos objetos mágicos en sus personajes para obtener efectos especiales.

4. **Combate:** Los personajes deben poder atacar a enemigos usando las armas equipadas. Cuando un personaje ataca a otro, el enemigo sufre daño basado en el poder de ataque del arma.

5. **Progreso del Personaje:** Debe llevarse un registro del progreso de los personajes, incluyendo su nivel de experiencia (XP) y su equipamiento (armas y objetos mágicos).

## Tareas a Realizar

- Crear nueva Api para Objetos Magicos que contenga una PocionCuracion y un Veneno con los endpoints:
- - get
- - usar
- - put (actualizar)
- Agregar en la collection de postman (Clase4.POO.WebApi.postman_collection.json) esto endpoints con un ejemplo
- Agregar unit tests para Veneno

## Intrucciones
- Hacer un fork de este repositorio
- Crear Pull Request contra el repositorio original