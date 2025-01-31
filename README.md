# VirtuKeys - VR Game for Hand Rehabilitation

## Overview
VirtuKeys is a virtual reality (VR) piano game developed by Jakob Santer and Lukas Neururer. It enables users to interact with a virtual piano using real-time hand-tracking, allowing them to play without controllers. Pressing a piano key triggers the corresponding sound and affects the game score mechanics.

## Purpose and Rehabilitation Context
The game was initially developed to complement a robotic mirror therapy device, which is designed for patients suffering from hemiparesis, where one side of the body is weaker than the other. The device works by tracking the movements of the healthy hand and mirroring them to the impaired hand through a motorized system, thereby leveraging the mirror therapy effect to promote recovery. VirtuKeys can serve as a gamified extension of this therapy, increasing patient motivation and engagement but can also be used as a stand-alone device. While the game is compatible with the therapy device, it is also designed to function independently, making it accessible for anyone interested in hand-eye coordination training or VR-based musical interaction.

## Technology Stack
- Engine: Unity (Version 2022.3.11f1)
- XR Framework: OpenXR Plugin
- Interaction System: XR Core Utilities, XR Interaction Toolkit, XR Hands package
- Hand Tracking: Meta Quest 2 / Pro (real-time hand tracking with XRHandsSubsystem)
- Hardware Support: Standalone VR gameplay or integration with MiraPi for rehabilitation

## Gameplay Mechanics
The VirtuKeys game consists of a virtual piano with five functional white keys, which users can play with either their right or left hand. The black keys are present for aesthetic realism but are not interactive.

The game features dynamic note generation, where different colored notes (each representing a unique sound pitch) spawn randomly and move towards the player. The goal is to press the corresponding key at the right time to destroy the incoming note and earn points.

### Scoring System
- +3 points: If the user presses the correct key while the note is inside the key collider.
- -1 point: If a note reaches the out-of-bounds zone without being destroyed.
- Negative feedback sound: Plays when a note is missed to reinforce the error.

The game runs in an endless mode and can be restarted via the main menu.

## User Interface & Scene Management
VirtuKeys includes a UI-based main menu, allowing players to navigate between different scenes:

- START: Loads the game scene and begins the piano simulation.
- ABOUT: Displays a brief description of the game and its developers.
- EXIT: Closes the application.

During gameplay, users can return to the main menu by selecting the "Back to Menu" button located below the score display.

## Hand Tracking & Interaction System
VirtuKeys is built upon Unity’s XR Interaction Toolkit and supports hand-tracking via XR Origin Hands (XR Rig). The interaction system is based on colliders:

- Piano keys and notes use Box Colliders.
- User hand models use Capsule Colliders with triggers (attached to fingertips).
- Key interaction is managed by the KeyHandler script, which detects touch events and determines whether a note was hit or missed.

The Game Manager object handles note spawning, score tracking, and game logic adjustments.
