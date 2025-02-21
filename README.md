# Unlikely Heroes  
**Game Jam Submission**  
*DEFENSE Theme | Limitation: Only 1 Resource | February 20-22, 2025*

## Overview  
**Unlikely Heroes** challenges the defense genre by letting players embody different heroes, each with unique abilities, as they defend against waves of monsters. Players must strategically manage a shared resource to activate shields, power abilities, and defeat enemies while navigating through dynamic environments.  

---

## Key Contributions as a Gameplay Engineer  

### **Character Selection and Switching**  
  - Developed a character rotation system, allowing players to switch between heroes (bunny, pink, drag, wiz) with unique abilities and appearance.  

### **Pathfinding and Movement**  
  - Programmed an AI-driven pathfinding system for monsters, ensuring they follow the correct paths and interact with obstacles in the game world.  
  - Designed smooth movement transitions for both the player characters and enemies, reducing collision issues.

### **Combat Mechanics and Shield System**  
  - Implemented dynamic combat mechanics for heroes, including abilities tied to a shared resource (shield energy).  
  - Created a shield mechanic that allows the player to block attacks, with energy consumption based on shield usage.  

### **Enemy AI and Spawning Logic**  
  - Designed enemy AI to follow preset attack patterns, adjusting difficulty with each wave.  
  - Managed monster spawning to create escalating difficulty, ensuring a challenging progression throughout the game.  

### **Resource Management System**  
  - Coded a shared resource system, where shield energy is the only resource, requiring players to balance shield usage, attacks, and abilities.  
  - Adjusted resource generation and consumption rates to create a balanced gameplay loop.  

### **User Interface and Feedback**  
  - Created dynamic UI elements to display health, shield energy, and resource stats.  
  - Integrated sound effects for combat, shield activation, and monster attacks, providing clear player feedback.  

### **Audio and Visuals**  
  - Added immersive background music and sound effects for hero actions, enemy attacks, and level transitions.  
  - Applied visual effects to indicate shield activation, character changes, and health/damage states.  

---

## Challenges Overcome  

### **Character Switching Animation**  
  - **Issue**: Characters were switching abruptly without proper animations.  
    - **Solution**: Used coroutines and animation triggers to seamlessly transition between characters with smooth animations.  

### **Pathfinding Issues**  
  - **Issue**: Monsters were getting stuck or not following the correct paths.  
    - **Solution**: Adjusted pathfinding algorithms and added dynamic obstacle handling to ensure smooth enemy movement.

### **Shield Energy Management**  
  - **Issue**: The shield energy consumption was either too fast or too slow, creating an imbalance.  
    - **Solution**: Fine-tuned the shield's energy drain rate and regeneration to create a satisfying resource management loop.

### **Enemy Difficulty Balance**  
  - **Issue**: The game became too easy or too difficult based on enemy spawning rates.  
    - **Solution**: Implemented dynamic scaling of enemy health, attack strength, and spawn rates to ensure challenging but fair progression.

---

## Reflection  
**Unlikely Heroes** pushed me to balance complex resource management mechanics with smooth character switching and combat. The challenges of AI pathfinding, shield energy management, and dynamic difficulty scaling helped me refine my gameplay engineering skills while working within the constraints of the jam.

---

## Play the Game  
[Play Unlikely Heroes on Itch.io](#)
