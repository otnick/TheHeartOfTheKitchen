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

From an educational perspective, the experience encourages players to communicate, cooperate, and solve tasks together in an active and playful way. Since players must coordinate their actions throughout the cooking process, the experience supports teamwork, communication, collaboration, and problem solving. The game also encourages creativity and hands-on interaction by allowing players to physically grab, move, and prepare objects using hand tracking. Instead of passive gameplay, players stay physically and socially involved in the experience, helping create a more engaging and collaborative learning environment for children.

---

# Design Process

## Early Concept Development

Before deciding on The Heart of the Kitchen, we explored several different multiplayer XR concepts. The common theme across these ideas was cooperation, communication, and asymmetric gameplay, where players would have different roles and responsibilities.

Some of the early concepts included:

- A two-room puzzle experience where one player acted as an instructor and the other completed tasks based on verbal instructions.
- A cave exploration scenario where players searched for gold while escaping an incoming cave collapse.
- Robot building lab
- Kitchen
- A church-themed cooperative experience.
- A flooding scenario where players had to cooperate under time pressure to prevent disaster.

After evaluating these ideas, we decided to focus on a cooking experience because it naturally supports teamwork, communication, physical interaction, and task sharing. Cooking also allowed us to combine playful activities with tangible interactions in a way that felt accessible and easy to understand for first-time XR users.

<p align="center">
<img src="https://github.com/user-attachments/assets/0bd3c174-da3a-4f8f-8bd9-a4d3da383c92"  width="400"/>
</p>

## Bodystorming

Before creating digital prototypes, we used bodystorming session to explore interaction ideas physically. Team members acted out different scenarios and roles, testing how players could communicate, move, and collaborate inside a shared XR environment.

Through bodystorming, we experimented with several concepts such as giving instructions between separate spaces, passing objects between players, solving tasks together, and using physical actions to affect another player's environment. This session helped us understand which interactions felt natural and engaging before investing time in implementation.

<p align="center">
<img src="https://github.com/user-attachments/assets/54279b51-9f1f-4dc1-9460-df608a571b64"/>
</p>

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
      <td><img src="https://github.com/user-attachments/assets/6435f3de-733d-44e7-bc8a-1eb76709148e" width="320"/></td>
      <td><img src="https://github.com/user-attachments/assets/e48248e4-b095-402f-8d71-d1cf47a0ee95" width="320"/></td>
    </tr>
  </table>
</div>

## Asset Research and Environment Planning

During the early stages of development, we also researched available assets that could support our vision for the project. We explored different kitchen environments, food models, sound effects, particle effects, and interaction assets to understand what could realistically be integrated into the experience.

This process helped us refine the scope of the project and influenced several design decisions. For example, the availability of kitchen-related assets supported our decision to move forward with a cooking theme, while the selection of food models and environment assets helped us create a playful and visually appealing atmosphere.

Researching assets early also allowed us to identify which features would need custom implementation, such as the flying ingredient system, recipe interactions, and multiplayer task synchronization.

<p align="center">
<img src="https://github.com/user-attachments/assets/081fac1a-c221-453c-9963-120e283be1bb"/>
</p>

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

We chose a station-based layout instead of allowing players to perform all actions in one location because it naturally encourages movement, cooperation, and communication. Players need to move through the kitchen together and understand the sequence of cooking tasks rather than completing everything from a single position.

<p align="center">
  <img src="https://github.com/user-attachments/assets/0363f94d-e100-4e2c-a4ac-b55199290aa8" width="800">
</p>

---

## Interaction Design 

One of the biggest design goals was reducing traditional UI usage. We wanted players to interact directly with the environment instead of constantly opening menus or pressing controller buttons.

For this reason, we chose an interactive recipe book instead of a floating menu. A floating menu would have been easier to implement, but it would constantly pull players out of the kitchen environment. By using a physical recipe book, the instructions become part of the world and encourage exploration.

At the beginning of the experience, players press a button that turns off the kitchen lights. This reveals glowing footprints that guide players to the recipe book. We chose this approach because we wanted players to discover the instructions naturally rather than immediately displaying a tutorial screen. This creates a stronger feeling of exploration and curiosity.

We also decided to use hand tracking instead of controllers. Since the experience is aimed primarily at children, hand tracking felt more intuitive and required less learning. Players can naturally grab ingredients, carry objects, and interact with the environment using familiar hand movements.

Another important design decision was combining physical and virtual interactions through the play-doh task. Instead of only manipulating virtual objects, players physically shape a real material and see the result appear as a virtual chicken inside the XR environment. We chose this interaction because it strengthens the connection between the real and virtual worlds and highlights the unique possibilities of XR experiences.


---

## Development Process

We started by creating a basic kitchen environment and testing different interaction ideas. Rather than implementing every feature at once, we focused on building and testing one interaction at a time.

The first prototypes focused on core interactions such as grabbing objects, moving ingredients, and creating a simple multiplayer environment. Once the foundation was working, we gradually introduced additional mechanics including flying ingredients, recipe guidance, food preparation tasks, cooking interactions, particle effects, and sound feedback.

The project was developed in Unity using Meta XR SDK, Photon Fusion networking, Oculus Passthrough, and C#. Photon Fusion was used to synchronize gameplay events and object interactions between players in real time. This allowed both players to share the same cooking experience and work toward a common goal.

Several features evolved significantly during development. For example, the introduction sequence originally relied on direct instructions, but later evolved into an exploration activity where players turn off the lights, follow glowing footprints, and discover the recipe book themselves. Similarly, the cooking tasks became more interactive over time through the addition of hand tracking, cutting interactions, particle effects, and audio feedback.

Throughout development, we continuously tested interactions to evaluate usability, immersion, and collaboration. Testing helped us simplify certain mechanics, improve interaction reliability, and create a more playful and engaging experience.

---

## Challenges and Solutions

One of the biggest challenges during development was deciding how realistic the cooking experience should be. We discovered that highly realistic interactions were not always the most engaging. Instead, we focused on creating playful and physically active tasks that encouraged exploration and communication.

Another challenge was maintaining a strong feeling of cooperation. We did not want the experience to feel like two separate players completing individual tasks. To solve this, we designed interactions that required communication and shared progress toward a common cooking goal.

The colocation setup also presented technical challenges. During early testing, players sometimes saw objects in different positions within the shared environment. Since the experience depends heavily on cooperation, this issue had to be resolved before meaningful multiplayer interactions could take place. Through repeated testing and synchronization improvements, we achieved a more stable shared XR space.

Hand tracking was another challenge throughout development. Some interactions became unreliable when users moved too quickly or performed unexpected gestures. Rather than relying on complex gesture recognition, we simplified interactions to grabbing, touching, carrying, and placing objects. This made the experience easier to understand and significantly improved stability.

Physics interactions also required several iterations. Ingredients sometimes clipped through hands, collided unpredictably, or behaved inconsistently in multiplayer sessions. We addressed these issues by adjusting rigidbody settings, collision handling, and interaction logic until the objects behaved more naturally.

These challenges helped shape the final experience. Many features evolved through testing and refinement, resulting in a project that became simpler, more intuitive, and more collaborative than the original concepts.

---

# Features and Functionalities

The Heart of the Kitchen combines multiplayer cooperation, XR interaction, hand tracking, and immersive cooking mechanics inside an interactive kitchen environment.

## Core Features

### Multiplayer XR Cooking Experience

The Heart of the Kitchen was designed as a shared multiplayer XR experience where players work together toward a common goal. Using Photon Fusion networking and colocation, both players can interact within the same kitchen environment, synchronize actions in real time, and complete cooking tasks collaboratively.

Features:
- shared multiplayer kitchen
- real-time synchronization using Photon Fusion
- collaborative cooking tasks
- colocation-based shared XR environment

---

### Hand Tracking Interaction

Instead of relying on controllers, players interact with the environment using natural hand movements. This makes the experience more accessible for children and creates a stronger feeling of immersion.

Features:
- grab ingredients
- hold objects
- carry bowls and plates
- cut ingredients
- interact naturally with the kitchen environment

---

### Interactive Beginning System

Features:
- players press a button to turn off the lights
- glowing footprints appear
- players follow the footprints
- players discover the recipe book
- touching the recipe book starts the recipe instructions

SCREENSHOT HERE

---

### Recipe and Instruction System

Features:
- recipe book interaction
- recipe page instructions
- world-space XR UI

<div align="center">
  <table>
      <tr>
      <td><img src="https://github.com/user-attachments/assets/289153d0-8fca-4d3a-a7f6-2d45d37ef8ff" height="220" width="200"/></td>
      <td><img src="https://github.com/user-attachments/assets/a8d9737e-239f-4631-8fc3-c78668a9ba49" height="220" width="200"/></td>
    </tr>
  </table>
</div>

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

### Dynamic Audio Feedback

Audio feedback is used throughout the experience to make interactions feel more responsive and immersive. Different sounds help players understand when actions have been completed successfully and provide feedback during cooking activities.

Features:
- cutting sounds
- cooking sounds
- background music

The background music also helps create a playful atmosphere while players work together to complete the recipe.

---

### Demo / Video

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

- https://assetstore.unity.com/packages/3d/environments/kitchen-creation-kit-2854
- https://assetstore.unity.com/packages/3d/props/clothing/ultra-low-poly-animated-angel-wings-157913
- https://assetstore.unity.com/packages/3d/props/food/pandazole-kitchen-food-low-poly-pack-204525
- https://assetstore.unity.com/packages/3d/environments/coffee-shop-environment-217600
- https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-free-109565
- https://sketchfab.com/3d-models/alchemical-book-25ea2f17700e4f1ab9dc38b3fcaaba0b
- https://sketchfab.com/3d-models/bar-5db4a3bc2e7e4150b1eba1a466bcf37c
- https://sketchfab.com/3d-models/flying-magic-book-95ee5c76e08442a5ad00e2b02a8270b9
---

# Contributors

ADD CONTRIBUTORS HERE

