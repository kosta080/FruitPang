# FruitPang
 
# Fruit Pang Assignment for Communix

## You can find the following in the drive folder

- Documentation pdf
- Android build apk
- Windows build zip
- Game loop screen capture video

[https://drive.google.com/drive/folders/11HbvDsx9Ut_P9Pam2Dhpr5h4CYQYauOE?usp=sharing](https://drive.google.com/drive/folders/11HbvDsx9Ut_P9Pam2Dhpr5h4CYQYauOE?usp=sharing)

## GitHub repo

[https://github.com/kosta080/FruitPang](https://github.com/kosta080/FruitPang)

[https://github.com/kosta080/FruitPang](https://github.com/kosta080/FruitPang)

## Unity version

2021.3.24f1 LTS 

## Assets used

1. ****[Pixel Adventure 1](https://www.notion.so/to-do-may-11-a8127c95c6fb47a59275abb4ac278740) from unity asset store for character, background and elements**
2. [**Fantasy Wooden GUI**](https://assetstore.unity.com/packages/2d/gui/fantasy-wooden-gui-free-103811) **from unity asset store for the GUI elements**

## Game elements

**UI Canvas** - I used canvas to create HUD elements: buttons and timer

**Ground, walls and ceiling** - all are using box collider 2d and are placed on a specific Layer to control the collisions pairs

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/e620f355-0a94-4ea7-9612-275d537d3f27/Untitled.png)

**Character -** uses sprite renderer and animator to visualise the character, uses box collider2d and rigibdody2d to prevent the player from escaping the level boundaries and to collide with the targets. movement is controlled by the PlayerController

**TargetsContainer and ArrowsContainer -** containers that the spawners are using to spawn arrows and targets. GameManager is using those containers to cleanup and restart the level

**TargetSpawner and ArrowSpawner classes-** are responsible for spawning elements in the containers

**PlayerController class -** is responsible for user input realization via the chosen input provider, for the movement of the character and for triggering the shots.

> currently 2 input methods are supported: keyboard and GUI but new input methods can be easily implemented using the IInputProvider interface
> 

**Timer class** - is responsible for the time count and logic

**MenuBtn class** - is a collection of short public methods that are called by the UI buttons via the eventSystem 

**SoundManager** - creates a new sound source each time a sound should be played.
reveals the audioclips as public variables to make it easier to choose which audio to play from outside the class.
SoundManager is a singleton and it is easy to trigger sound effects from anywhere in the script
*footsteps are produced via a dedicated audio source placed on the player object

## Scoring

round score is stored in a scriptable object  PlayerData.

targets and bonuses prefab contains their own scoring value and passes the value to game manager.

## Design decisions

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/65217e38-eae0-4563-8d80-78333f8a1351/Untitled.png)

## Scalability

New bonuses types can be added by creating new prefabs like BonusKiwi and changing its scoring values.

New sounds types can be added by adding new AudioClips to the sound manager and calling the PlaySfx method with the new AudioClips  as an argument.

New levels can be created by duplicating the Level scene and using the floor (with a different sprites) to add platforms and obstacles.

New targets types can be used on other levels by referencing different target prefab in the Spawner script

**Thank you for your time**
