CAVE RUNNER

Endless runner cave exploration game made with Unity. Dodge obstacles, collect coins, and survive in an infinite procedurally generated cave.

 🕹️ Play Now
[Play on Itch.io](https://dzagri.itch.io/dungeon-runner)

 📸 Screenshots
![Gameplay Screenshot]()
![WhatsApp Image 2025-06-21 at 19 03 35_7f1ffd17](https://github.com/user-attachments/assets/5550411a-62d3-4aef-a0a9-7f71b7343a20)
![WhatsApp Image 2025-06-21 at 19 03 39_2420022e](https://github.com/user-attachments/assets/55dc748b-a30c-4591-b25e-b69d30285d09)

 
 🎮 Features![Uploading WhatsApp Image 2025-06-21 at 19.03.39_acc178c0.jpg…]()

- Procedural level generation
- Collectible system with audio feedback
- Flashlight mechanic affecting gameplay visibility
- Mobile input support (tested on iOS and Android)
- Save/Load System
- WebGL compatible build

 🗂️ Project Structure

└── 3D Models/
              └── 2D Design/
              └── Animations/
              └── Materials/
└── Audio/
└── Prefabs/
└── Scenes/
└── Scripts/
└── TextMeshPro/

 📝 Technologies Used

- Unity 3D
- Visual Studio (C#)
- Blender (3D models/Animations)
- GIMP (textures)
- Audacity (Audio)

⚙️ Key Systems

- Shop System
- Health System
- Collectible System (Implemented with `CollectibleBase` abstract class, allowing for flexible collectible types (Coins, PowerUps, etc.))
- Flashlight Mechanic (The flashlight dynamically affects visibility with adjustable RGB color selected by the player. Color selection and purchase are saved using PlayerPrefs)
- Procedural Generation (Barriers spawn ahead of the player at fixed intervals, creating an endless cave runner effect)

 🚧 Known Issues
- Stretching artifacts on certain mobile devices (likely related to WebGL rendering differences).

 📂 How to Run Locally
1. Clone the repository
2. Open in Unity (tested with Unity 2022.3.x LTS and Unity 6 LTS)
3. Open the scene named `Start` and press Play.

 📬 Contact
For collaboration or feedback:
- [**Portfolio**: https://your-carrd-url.com](https://dzagri.carrd.co)
- zaali.unity@gmail.com
