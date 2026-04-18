# 3rd person irl

A semester-long project combining Unity, computer vision, and embedded systems to create an immersive augmented reality game with real physical feedback.

---

## Overview

This project turns your real environment into a third-person AR battlefield.

Using a custom camera rig, players see themselves from a third-person perspective while interacting with virtual enemies spawned into their physical space. The system goes beyond visuals — players physically feel in-game damage through haptic feedback.

---

## How It Works

[Unity Game]
     ↓ (WebSockets)
[ESP32]
     ↓ (Serial)
[Arduino Uno]
     ↓ (Relay Module)
[TENS Unit]
     ↓
[Player (Physical Feedback)]

1. The Unity game detects when the player is hit  
2. A WebSocket message is sent to the ESP32  
3. ESP32 forwards the signal to the Arduino Uno  
4. Arduino activates a relay corresponding to a body part  
5. The relay triggers the TENS unit  
6. The player feels the hit in real life  

---

## Features

- Third-Person Real-World View  
  Custom rig + webcam provides a live third-person perspective  

- Augmented Reality Gameplay  
  Enemies spawn into the real world and interact with the player  

- Interactive Combat System  
  Players can shoot and be attacked in real time  

- Real Haptic Feedback  
  Physical stimulation is triggered based on in-game events  

- Low-Latency Communication  
  WebSockets used for real-time data transfer  

---

## Tech Stack

**Software**
- Unity (C#)
- WebSockets (real-time communication)

**Hardware (used in full system)**
- ESP32 (WiFi communication)
- Arduino Uno (control logic)
- Relay Module (safe switching)
- TENS Unit (haptic feedback)
- Webcam (third-person tracking)

---

## Hardware Setup

Safety Notice  
This project involves a modified TENS unit. Use caution when working with electrical stimulation devices. Ensure proper isolation using relays and never directly connect microcontrollers to the TENS output.

- TENS wires are routed through a relay module  
- Arduino controls relays to safely trigger specific pads  
- Each relay corresponds to a limb (left arm, right arm, etc.)  

---

## Demo

Add videos or GIFs here

---

## Challenges

- Maintaining low latency between game events and physical feedback  
- Designing a safe interface between low-voltage microcontrollers and TENS output  
- Synchronizing real-world positioning with virtual interactions  
- Debugging multi-device communication (Unity ↔ ESP32 ↔ Arduino)  

---

## Future Improvements

- Improve tracking accuracy and positioning  
- Reduce latency in communication pipeline  
- Expand to full-body feedback system  
- Add multiplayer or cooperative gameplay  
- Replace webcam with more advanced tracking (e.g., depth sensors)  

---

## What I Learned

- Real-time system design (WebSockets vs HTTP)  
- Hardware-software integration  
- Embedded systems communication  
- Safety considerations in physical computing  
- Building interactive AR experiences  

---

## Repository Structure

/unity-game → Unity project files

---

## Note

I forgot to include the Arduino and ESP32 code in this repo. If you're interested or want to see the full system, feel free to reach out:

Discord: huterrat  
Email: n13arthurteng@gmail.com
