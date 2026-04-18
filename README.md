# Real-World Third Person AR Game with Haptic Feedback

A semester-long project combining Unity and hardware to create an augmented reality game with real physical feedback.

---

## Overview

This project turns a real environment into a third-person AR game experience.

Using a custom rig and webcam setup, the player is shown from a third-person point of view while virtual enemies are spawned into the scene. These enemies can shoot at the player, and the player can shoot back. What makes the project stand out is the haptic feedback system that connects in-game hits to real-world physical feedback.

---

## How It Works

[Unity Game]
     ↓ (WebSockets)
[ESP32]
     ↓ (Serial / Signal)
[Arduino Uno]
     ↓
[Relay Module]
     ↓
[TENS Unit]
     ↓
[Player Feedback]

1. Enemies are spawned into the game using a cowboy spawner object  
2. The enemies can attack the player, and the player can shoot back  
3. Collision objects on the player detect when a hit happens  
4. When a collider is hit, it sends that information to the Arduino manager in Unity  
5. The Arduino manager sends the data to the ESP32  
6. The ESP32 sends a signal to the Arduino Uno  
7. The Arduino turns on or off specific relays based on the signal it receives  
8. The relay module triggers the correct TENS pad  
9. The player feels physical feedback based on where they were hit  

---

## Features

- Third-Person Real-World View  
  A custom rig and webcam provide a live third-person perspective  

- Augmented Reality Gameplay  
  Virtual enemies are spawned into the player's real environment  

- Combat System  
  Enemies can shoot at the player, and the player can shoot back  

- Hit Detection with Colliders  
  Player colliders detect which body part was hit and pass that information through the system  

- Real Haptic Feedback  
  In-game hits are translated into physical feedback through the TENS setup  

- Real-Time Communication  
  WebSockets are used to send data from the Unity game to the ESP32  

---

## Tech Stack

**Software**
- Unity (C#)
- WebSockets  

**Hardware (used in the full system)**
- ESP32  
- Arduino Uno  
- Relay module  
- TENS unit  
- Webcam  
- Custom rig  

---

## Hardware Setup

Safety Notice  
This project involves a modified TENS unit. Use caution when working with electrical stimulation devices. Ensure proper isolation using relays and never directly connect microcontrollers to the TENS output.

- Unity sends hit data through the Arduino manager  
- ESP32 receives the data over WiFi  
- ESP32 forwards signals to the Arduino  
- Arduino controls which relays are activated  
- Relays safely trigger the corresponding TENS pads  
- Each relay corresponds to a different body region  

---

## Note

I forgot to include the Arduino and ESP32 code in this repo. If you're interested or want to see the full system, feel free to reach out:

Discord: huterrat  
Email: n13arthurteng@gmail.com
