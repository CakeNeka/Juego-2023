# In Aestus (nombre provisional)

### Diseño

- Top down survivor de naves

**Es como:** 
- Vampire Survivors 
- Brotato

#### Objetivo

- El jugador tiene que sobrevivir un tiempo determinado  
- Conforme avanza el tiempo el juego se vuelve difícil:    
    - Aparecen nuevos enemigos
    - El jugador desbloquea armas

#### Mecánicas

- **Movimiento**
    - flechas
- **Vida**
    - Objetos aleatorios recuperan vida.
- **Armas**
    1. Cañón: Disparo automático al enemigo más cercano, con proyectiles (prefabs).
    2. Cañón: Disparo en la dirección del movimiento
    3. Órbita en círculos entorno al personaje.
- **Enemigos**
    - Todos: Al contactar, aplicar fuerza sobre jugador
    - **a distancia**
    - **melé**

Control de masas

- Movimiento básico

### Aspectos técnicos

Diseño modular, es decir, 1 componente para cada función por ejemplo el **Objeto Jugador** tiene los componentes
- `Movement`
- `PlayerStats`
- **Armas**
    - `TrackingCannon`

- Patrón `ObjectPooler` para la instanciación de proyectiles

(escenas, controles, componentes)

### Desarrollo

- [devlog](./devlog/devlog.md)

### Dibujo

