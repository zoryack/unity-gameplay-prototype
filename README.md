# Last Combat - Unity Top-Down Shooter Prototype

A fast-paced, mechanically driven Top-Down Shooter prototype built in Unity using C#. This project focuses on implementing structured player input handling, modular ability cooldown systems, and responsive enemy AI.

>  **Watch the Gameplay Video:** [https://youtu.be/VOGvjOmI5yk]

---

##  Key Features & Gameplay Mechanics

*   **Advanced Player Movement:** Responsive top-down movement integrated with a specialized directional **Dash mechanics** (`DashCd.cs`) with independent cooldown management.
*   **Modular Ability System:** A hero-shooter style ability framework mapping distinct skills to standard hotkeys (**Q, E, R** abilities managed via `QCd.cs`, `Ecd.cs`, and `Rcd.cs`) ensuring clean cooldown tracking and UI synchronization.
*   **Dynamic Weapon Configurations:** Iterative weapon progression logic featuring multiple weapon types (`PlayerWeapon`, `PlayerWeapon1`, `PlayerWeapon2`, `PlayerWeapon3`) and scaling bullet parameters (`Bullet`, `Bullet1`, `Bullet2`, `Bullet3`).
*   **Enemy AI Behaviors:** Independent state behaviors for NPCs, including relentless tracking algorithms (`EnemyFollow.cs`) and explosive burst-movement indicators (`EnemyDash.cs`).
*   **Scalable Architecture:** Game loop infrastructure supported by an automated wave spawner (`SpawnEnemies.cs`), precise session timers (`Timer.cs`), and a scalable UI layer (`UIManager.cs`) linking floating world-space health bars (`FloatingHealthBar.cs`) to entity health states.

---

##  Technical Stack & Architecture

*   **Game Engine:** Unity (C#)
*   **Design Paradigm:** Object-Oriented Programming (OOP) with an event-driven focus for decouple UI and state updates.
*   **Architecture Pattern:** Component-based system utilizing custom inspectors for designer-facing tweakable parameters.
*   **Version Control:** Managed strictly via Git and GitHub.

---

##  Code Overview

The core logic of the prototype is structured within the `/Scripts` directory:

*   `PlayerController.cs`: Handles standard coordinate calculations, look-at mouse rotations, and firing states.
*   `Health.cs`: Consolidated health component tracking damage mitigation and invoking state-change events.
*   `SpawnEnemies.cs`: Coordinates localized algorithmic enemy spawning based on configurable parameters.
*   `FollowCamera.cs`: Smooth target-tracking camera behavior using interpolated smoothing vectors.

---

##  Code Style & Practices

*   **Clean & Modular:** Separation of concerns between UI representation, entity stats, and input logic.
*   **Performance Minded:** Optimized raycasting parameters and efficient object state pooling practices.
*   **Readable:** Rigorous naming conventions and fully commented architecture prepared for team scalability.
