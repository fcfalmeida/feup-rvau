# Slender VR

SlenderVR is a horror VR game for Android devices heavily inspired by the Slender series, which uses Google Cardboard and a Dualshock 4 controller. The player finds themselves in a forest and their goal is to collect the books scattered around the area without being caught by Slenderman. The books contain the necessary knowledge to perform a ritual to defeat Slenderman.

## Features

- Interaction based on gaze and Dualshock 4 buttons
- Ability to grab and throw objects according to looking direction
- Device location based weather - if it’s raining where the player is at, it will be raining in game as well
- AI controlled Slenderman
- 3 difficulty levels which change the number of books the player has to pick up to win, Slenderman’s movement speed and the force applied by objects thrown at Slenderman
- Camera jitter to indicate the presence of Slenderman

![SlenderVR_GIF](https://media.giphy.com/media/znA5DW2tsiovBzIRIR/giphy.gif)

## Controls

- **Left Analog stick up/down** - move forward/backwards
- **X button** - toggle flashlight on/off
- **O button** - object interaction / menu selection

## Getting Started

This project uses Unity version 2019.3.4f1. Simply clone this repository and add the directory to Unity Hub.  
If you simply want to play the game on your Android device, simply install the .apk and run it. The game requires a Google Cardboard viewer and a Dualshock 4 controller connected via bluetooth. If you want to enable device location based weather, manually give the app permission to access your location on your device settings. You can get the .apk under [releases](https://github.com/fcfalmeida/feup-rvau/releases).
