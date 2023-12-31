<h1 align="center">TONK</h1>

<h3 align="center"><i>Turbo Omega Nitro Knight</i></h3>

<div align="center">
<img src="devlog/1702139325837.gif" alt="green tonk" align="center" width="100"/>
</div>

<br>

<pre align="center">
 _________  ________  ________   ___  __        
|\___   ___\\   __  \|\   ___  \|\  \|\  \      
\|___ \  \_\ \  \|\  \ \  \\ \  \ \  \/  /|_    
     \ \  \ \ \  \\\  \ \  \\ \  \ \   ___  \   
      \ \  \ \ \  \\\  \ \  \\ \  \ \  \\ \  \  
       \ \__\ \ \_______\ \__\\ \__\ \__\\ \__\ 
        \|__|  \|_______|\|__| \|__|\|__| \|__| 

</pre>



## Diseño

- Top down survivor de Tanques.

**Es como:** 
- Vampire Survivors 
- Brotato

### Objetivo

- El jugador tiene que sobrevivir un tiempo determinado  
- Conforme avanza el tiempo el juego se vuelve difícil:    
    - Aparecen nuevos enemigos
    - El jugador desbloquea armas

### Mecánicas

- **Movimiento**
    - El jugador (un tanque) se maneja con las flechas ✔
- **Vida**
    - Sistema de *salud* clásico (puntos de vida) para jugador y enemigos ✔
    - Objetos de aparición aleatoria recuperan la vida del jugador
    - Cada personaje tiene una barra de vida (¿con números?) ✔
- **Armas**: El disparo es siempre automático, el jugador solo controla movimiento
    1. Cañón rotatorio: Disparo automático al enemigo más cercano, con proyectiles (prefabs). ✔
        - Balas atraviesan a los enemigos
        - Más velocidad, menos daño.
    2. Cañón frontal: Disparo en la dirección del movimiento
        - Balas explotan al impactar (daño de área)
        - Menos velocidad, mas daño.
    3. Escudo: Orbita en círculos entorno al personaje.
- **Enemigos**
    - Movimiento: Hacia el jugador ✔
    - Todos: Daño de contacto ✔
    - Aparición: fuera de la visión del jugador 
    - Desaparición: OutOfBounds (¿Hacer área más grande?, ¿eliminarlos de otra forma?)
    - Los enemigos dropean **puntos** y **objetos**

**Adicional** (se hará si da tiempo)
- Enemigos dropean experiencia
- Cada nivel, subir **velocidad**, **vida** o **daño**
- Cuando se acabe el tiempo --> BOSS

## Aspectos técnicos

Diseño modular, es decir, 1 componente para cada función por ejemplo el **Objeto Jugador** tiene los componentes
- `Movement`
- `PlayerStats`
- **Armas**
    - `TrackingCannon` (Daño por impacto, )
    - `FrontCannon` (¿Daño de área?)
- Patrón `ObjectPooler` para la instanciación de proyectiles

(escenas, controles, componentes)

## Desarrollo

- [Devlog](./devlog/devlog.md)
- [Presentación](https://cakeneka.github.io/Juego-2023/devlog)

## Capturas

> ![](./devlog/media/Enemy_mov.gif)

> ![](./devlog/media/Enemy_res.gif)

> ![](./devlog/media/tank_color_changer.gif)



## Recursos utilizados

- [Tutorial para desarrollar un clon de **Vampire Survivors**](https://www.youtube.com/playlist?list=PLgXA5L5ma2Bveih0btJV58REE2mzfQLOQ)
- [Página para generar efectos de sonido](https://sfxr.me/)
- [Tutorial para AudioManager, de CodeMonkey](https://www.youtube.com/watch?v=QL29aTa7J5Q)
