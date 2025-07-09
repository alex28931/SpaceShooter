# 🚀 2D Space Shooter – C# Project

A fast-paced 2D space shooter developed in C#, featuring object pooling, a custom collision engine, and dynamic local multiplayer input support. Designed with clean object-oriented principles for flexibility and scalability.

## 🎮 Gameplay Overview

- **Spaceship Combat**  
  Control a spaceship, dodge enemy fire, collect power-ups, and destroy waves of enemies in a fast-scrolling space environment.

- **Object Pooling System**  
  All bullets (player and enemy), enemy ships, and power-ups are managed through object pools to maximize performance and avoid costly runtime instantiation.

- **Custom Collision Engine**  
  A lightweight physics system handles collision detection between ships, bullets, and power-ups without relying on external frameworks.

- **Dynamic Local Multiplayer**  
  Supports up to 2 players:
  - **Player 1**: Uses **gamepad if connected**, otherwise defaults to **keyboard**
  - **Player 2**: Always uses **keyboard**

- **Power-Up System**  
  Multiple power-ups grant gameplay bonuses (e.g. faster fire rate, shields), and are fully pooled and reusable.

## 🕹️ Controls

### Player 1
- **Gamepad connected** →  
  - **Left Stick** → Move  
  - **RT Button** → Fire

- **No Gamepad** →  
  - **WASD / Arrow Keys** → Move  
  - **Spacebar** → Fire

### Player 2 (Keyboard Only)
- **WASD / Arrow Keys** → Move  
- **Spacebar** → Fire

## 🧱 Technologies & Architecture

- **C#**
- **Object-Oriented Design**
- **Object Pooling Pattern**
- **Custom Collision Detection**
- **Modular Game Loop**
- **Input Management (Keyboard + Gamepad)**

## 🎯 Development Highlights

- Implemented a memory-efficient architecture with reusable object pools  
- Designed a fallback input system to support dynamic control assignment  
- Built a standalone 2D collision engine to track and resolve in-game interactions  
- Applied clean OOP principles for maintainability and system expansion

## 🎞️ Gameplay Preview

![Gameplay](Gifs/Gameplay.gif)
