# JecnaKombat

**JecnaKombat** is an exciting 2D fighting game where players battle against each other using a variety of attacks and defenses. The game features AI enemies that follow and attack the player, as well as player characters with health and stamina mechanics.

## Features
- Two player characters with unique sprites and attacks.
- AI enemies that follow and attack the player.
- Health and stamina mechanics for both players and enemies.
- Respawning enemies after a set time period.

## Installation

To play JecnaKombat, follow these steps:

1. Download the game file `JecnaKombat.exe`.
2. Run `JecnaKombat.exe` to start the game.

## Controls

### Player 1
- **Move:** WASD keys
- **Block:** Hold `X`
- **Box Attack:** Press `,`
- **Leg Attack:** Press `.`

### Player 2
- **Move:** Arrow keys
- **Block:** Hold `M`
- **Box Attack:** Press `,`
- **Leg Attack:** Press `.`

### General
- **Exit Game:** Esc key

## Game Mechanics

### Health and Stamina
- Each player and AI enemy has a health bar.
- Players can block attacks to reduce damage taken.
- Blocking drains stamina, which regenerates over time when not blocking.

### Attacks
- Players can perform box and leg attacks.
- Each attack has a cooldown period before it can be used again.
- AI enemies can follow the player and perform attacks.

### Respawning
- AI enemies respawn at a designated spawn point 5 seconds after being defeated.

## Development

### Player Scripts
- **HP2.cs:** Manages player health, blocking, and stamina.
- **PlayerCombat2.cs:** Handles player attacks and cooldowns.

### AI Scripts
- **EnemyAI.cs:** Controls enemy movement, attacking, and respawning.

## Known Issues
- None reported yet. Please report any bugs you encounter.

## License
This project is licensed under the MIT License.

## Acknowledgments
- Thanks to all contributors and testers who helped develop this game.

---

Enjoy playing JecnaKombat!
