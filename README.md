# The Heart of the Kitchen

<p align="center">
  <img src="https://github.com/user-attachments/assets/46d60128-92f7-4fd6-ab28-e87684b5a9c9" width="400">
</p>

> “Are you tired of cooking food alone? Bring a friend and cook together in a fun XR kitchen adventure!”

---

# Introduction

The Heart of the Kitchen is a multiplayer XR cooking experience where players work together to complete cooking tasks inside an interactive kitchen environment. The project was developed in Unity using Meta Quest hand tracking, passthrough technology, and Photon Fusion networking.

The main goal of the project is making cooking feel more playful, social, and immersive through XR interaction. Instead of using traditional menus or pressing buttons on a flat screen, players physically interact with the environment using their hands. Players can grab flying ingredients, cut vegetables, cook food, place dishes onto plates, serve meals to the customer table, and interact naturally with kitchen objects.

The experience is designed especially for children, but it can also be enjoyed by beginner cooks, families, friends, or people looking for a collaborative XR activity. The goal is not only finishing the recipe, but also communicating, helping each other, and completing the cooking tasks together.

The project solves the problem of passive or single-player cooking games by making the cooking process collaborative and interactive. Players no longer cook alone. Instead, they coordinate tasks, communicate constantly, and work together throughout the experience. This creates a more engaging and social gameplay experience while also encouraging teamwork and communication.

The project focuses on creating immersive and playful XR interactions that combine hand tracking, collaboration, sound feedback, and mixed reality elements to make cooking feel more active and social.

From an educational perspective, the experience encourages players to communicate, cooperate, and solve tasks together in an active and playful way. Since players must coordinate their actions throughout the cooking process, the experience supports teamwork, communication, collaboration, and problem solving. The game also encourages creativity and hands-on interaction by allowing players to physically grab, move, shape, and prepare objects using hand tracking. Instead of passive gameplay, players stay physically and socially involved in the experience, helping create a more engaging and collaborative learning environment for children.

---

# Design Process   

## Planning Phase

At the beginning of the project, our main goal was creating a fun and interactive XR cooking experience that focuses on teamwork and physical interaction instead of traditional button-based gameplay. We wanted the experience to feel simple enough for children to understand while still being entertaining and immersive for other players as well.

During the planning process, we decided the experience should focus on:
- cooperation between players
- physical object interaction
- playful cooking activities
- communication between players
- immersive XR feedback

Instead of creating a realistic cooking simulator, we intentionally focused on making the environment more colorful, playful, and active. We wanted players to laugh, communicate, and physically interact with the kitchen instead of following strict realistic cooking rules.

<div align="center">
  <table>
      <tr>
      <td><img src="https://github.com/user-attachments/assets/54279b51-9f1f-4dc1-9460-df608a571b64" width="320"/></td>
      <td><img src="https://github.com/user-attachments/assets/6435f3de-733d-44e7-bc8a-1eb76709148e" width="320"/></td>
    </tr>
     <tr>
      <td><img src="https://github.com/user-attachments/assets/081fac1a-c221-453c-9963-120e283be1bb" width="320" height="220"/></td>
      <td><img src="https://github.com/user-attachments/assets/e48248e4-b095-402f-8d71-d1cf47a0ee95" width="320"/></td>
    </tr>
  </table>
</div>

---

## Architecture Overview

The project architecture was designed around cooperation, task flow, and interaction inside the kitchen environment.

The kitchen space was divided into three main areas:
- Kitchen Zone
- Pass Zone
- Front Zone

Each zone was created to support different cooking interactions and encourage communication between players throughout the experience.

### Kitchen Zone
The Kitchen Zone is the main preparation area where most cooking interactions happen. This area contains:
- ingredient station
- preparation station
- cooking station

### Pass Zone
The Pass Zone works as a transition area between different cooking activities. This area encourages collaboration by making players transfer ingredients, prepared food, and cooking items through the kitchen flow instead of completing everything in a single location.

### Front Zone
The Front Zone focuses on delivery and serving interactions. This area contains the delivery station where completed dishes are placed and served.

This station-based structure also helped simplify multiplayer interactions because the gameplay flow became clearer and easier to follow inside the shared XR environment.

<p align="center">
  <img src="https://github.com/user-attachments/assets/0363f94d-e100-4e2c-a4ac-b55199290aa8" width="800">
</p>

---

## Interaction Design   ??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????

One of the biggest design goals was reducing traditional UI usage. We wanted players to interact directly with the environment instead of constantly opening menus or pressing controller buttons.

Because of this, we designed interactions such as:
- opening recipe instructions through an animated book
- grabbing flying ingredients using hand tracking
- cutting ingredients with a knife
- carrying bowls and plates with hands
- serving plates to the customer table
- turning off kitchen lights using a button
- following glowing footprints to discover the recipe book

At the beginning of the experience, players first interact with a button inside the kitchen environment. When the button is pressed, the kitchen lights turn off and glowing footprints appear on the floor. Players must follow these footprints to discover the recipe book hidden inside the environment.

After finding the recipe book, players touch the book to open the recipe instructions and learn what tasks they need to complete next. We designed this interaction to replace traditional menus and make the beginning of the experience feel more immersive, interactive, and exploratory inside XR.

We selected hand tracking because it felt more natural and easier to understand, especially for children. During testing, we noticed that players quickly understood interactions when they could physically touch and move objects instead of using abstract button inputs.

Another important interaction combines real-world objects with virtual XR feedback. During one of the cooking tasks, players use real play-doh and physically shape it with their hands. They must flatten the dough, check if it fits the correct hole shape, and place it correctly into the station. After the task is completed, the real interaction transforms into a virtual chicken food object inside the XR environment.

We added this interaction to make the experience feel more immersive and creative for children. Instead of only interacting with virtual objects, players can physically touch and shape a real material and immediately see the result appear inside the virtual world. This creates a stronger connection between physical interaction and XR gameplay.


---

# Development Process   WE NEED TO IMPROVE HEREEEEEE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

The project was developed in Unity using:
- Meta XR SDK
- Photon Fusion networking
- Oculus Passthrough
- C# scripting

The multiplayer system was built using Photon Fusion so both players could interact inside the same shared kitchen environment. We synchronized gameplay events, object interactions, UI changes, lighting systems, and cooking progress between players.

We also implemented:
- floating ingredient systems
- physics-based interactions
- play-doh to virtual food interaction
- cutting ingredients with a knife
- recipe systems
- passthrough lighting interactions
- particle effects
- sound effects

During development, we continuously tested the interactions to make sure they felt intuitive and physically understandable inside XR.

---

# Challenges and Solutions  ADD HERE TANGIBLE CHALLENGES AND SOLUTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

One of the biggest challenges during development was deciding which mechanics should feel realistic and which ones should feel more playful and entertaining. Since the experience was mainly designed for children, we realized that fully realistic cooking interactions were sometimes less engaging than exaggerated physical interactions. Because of this, we focused more on interactions that felt active, fun, and immersive rather than perfectly realistic.

Another challenge was keeping the gameplay simple while still making the tasks interesting and collaborative. During early testing, some interactions felt too complicated or required too many instructions. To solve this, we simplified the gameplay flow and focused more on direct hand interaction instead of complex menus or controls.

Creating a strong feeling of cooperation was also an important challenge. We did not want the experience to feel like two separate single-player activities happening at the same time. Instead, we wanted players to depend on each other and communicate throughout the cooking process.

One of the most technically challenging parts of the project was creating interactions between virtual and physical objects. During the play-doh task, players physically shape a real object and then see it transform into a virtual food object inside the XR environment. Creating a smooth connection between physical interaction and virtual feedback required a lot of testing to make the interaction feel understandable and immersive.

Another challenge was the colocation setup. In the beginning, the colocation system did not work reliably, and players sometimes saw objects in different positions inside the shared environment. Because the experience depends heavily on cooperation and shared interaction, it was important that both players saw the same kitchen layout and object positions. To improve this, we tested the shared space setup multiple times, adjusted synchronization behavior, and improved networking communication until the environment became more stable and consistent between both headsets.

We also faced challenges with hand tracking and physics interactions. Some objects behaved unexpectedly, clipped through hands, or moved incorrectly during multiplayer synchronization. To improve this, we adjusted rigidbody settings, improved collision handling, and simplified some interactions to make them more stable and reliable inside XR.

Throughout the project, many design decisions evolved based on testing and interaction feedback. Over time, the systems became simpler, more physical, and more playful compared to the original prototype ideas.

---

# Features and Functionalities

The Heart of the Kitchen combines multiplayer cooperation, XR interaction, hand tracking, and immersive cooking mechanics inside an interactive kitchen environment.

## Core Features

### Multiplayer XR Cooking Experience
- shared multiplayer kitchen
- real-time synchronization using Photon Fusion
- collaborative cooking tasks
- colocation-based shared XR environment

---

### Hand Tracking Interaction
Players interact mainly using their hands instead of controllers.

Players can:
- grab ingredients
- hold objects
- carry bowls and plates
- cut ingredients
- interact naturally with the kitchen environment

---

### Interactive Beginning System

- players press a button to turn off the lights
- glowing footprints appear
- players follow the footprints
- players discover the recipe book
- touching the recipe book starts the recipe instructions

SCREENSHOT HERE

---

### Flying Ingredient System
Ingredients float around the environment and players must catch and collect them.

Features:
- floating animation system
- grab interactions
- bowl collection system
- gravity interaction after collection

<div align="center">
  <table>
      <tr>
      <td><img src="https://github.com/user-attachments/assets/c01ed3a8-a719-4e43-a7da-d5ec98a7edc7" width="220"/></td>
      <td><img src="https://github.com/user-attachments/assets/6570b160-bbd9-4188-a7b3-c3ffdb4d7d20" width="220"/></td>
    </tr>
  </table>
</div>

---

### Real and Virtual Interaction Combination
Players:
1. use real play-doh
2. shape it with their hands
3. place it into the correct hole
4. trigger a virtual chicken food object inside XR

<div align="center">
  <table>
    <tr>
      <td><img src="https://github.com/user-attachments/assets/7e8a35a0-656e-4da8-a0be-e50c3cb6078e" width="220"/></td>
      <td><img src="https://github.com/user-attachments/assets/47a5097d-e121-4af3-b39e-2b109408e1fa" width="220"/></td>
      <td><img src="https://github.com/user-attachments/assets/042a1976-617c-4c8f-92b7-69e3118bc845" width="220"/></td>
      <td><img src="https://github.com/user-attachments/assets/2ae7dfb7-435a-4ca9-a603-b4283c66bf78" width="220"/></td>
    </tr>
  </table>
</div>

---

### Knife Cutting Interaction
Features:
- knife collision interaction
- ingredient transformation system
- particle effects while cutting
- sound effects during cutting
- object replacement after cutting

<div align="center">
  <table>
    <tr>
      <td><img src="https://github.com/user-attachments/assets/40b7ccce-7491-486b-9125-4d6e9c247e96" width="220"/></td>
      <td><img src="https://github.com/user-attachments/assets/7d8f9a20-5339-4eb1-a943-58c007cea784" width="220"/></td>
    </tr>
  </table>
</div>

---

### Cooking System
Features:
- stove interaction
- cooking interactions
- cooking sound effects
- particle effects during cooking

<p align="center">
  <img src="https://github.com/user-attachments/assets/1b58c3f7-fd7f-48a3-97cd-02b86412f157" width="400">
</p>

---

### Recipe and Instruction System
Features:
- recipe book interaction
- recipe page instructions
- world-space XR UI

SCREENSHOT HERE

---

### Dynamic Audio Feedback
Features:
- ambient kitchen sounds
- cutting sounds
- cooking sounds
- background music
- interaction sound feedback

---

### Passthrough and XR Environment
Features:
- passthrough lighting changes
- mixed reality interaction
- XR environmental immersion

SCREENSHOT HERE

---

# Demo / Video

PROJECT DEMO LINK HERE

---

# Installation

ADD INSTALLATION HERE

---

# Usage

ADD USAGE HERE

---

# References

ADD REFERENCES HERE

---

# Contributors

ADD CONTRIBUTORS HERE

