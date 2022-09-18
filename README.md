# Hackadelic

## Summary

This repository is the product of the **BEST** hacking boys and girls from the Hackathon 2022. We develop a software for the elevator. During the ride, the user will see a floor map of the targeted level. There, he can play *Where is Waldo?* Shortly before the end of the ride, a leaderboard is presented to the user to see how well he knows the people from the office.

## Requirements

- Visual Studio Code with Unity Debugger Extension
- Unity 2021.3.10f1

## Setup

Open the folder *Hackadelic* with Unity 2021.3.10f1. Copy the folder Database onto your desktop. It works only on Windows. The game conntects to the websocket `wss://hack2.myport.guide/` and checks the state of elevator `liftState:1.1.1`. When the elevator closes the door, the game will be started. Opening the elevator door, finishes the game and adds the score to a leaderboard.