# The Ascent VR

## Introduction
  _The Ascent_ is a virtual reality horror video game. At the start of the game, the player is dropped at the beginning of a dark maze in front of a wall with instructions to complete the game. A flashlight is connected to the player’s hand and they must turn it on to help them see their surroundings and navigate his or her escape. Throughout the maze, there are point lights that are initially turned off to force the user to explore the maze, and once a light is passed, it is turned on to let the player know that they have been there before. The lights also have a color scheme of blue to white to red with blue representing moving away from the start of the maze to red representing the player nearing the end. While traversing the maze, the player must also collect 3 out of the 6 glowing keys placed randomly throughout the maze to unlock the exit gate. If the exit is reached before collecting 3 keys, the door will stay locked and the player is still stuck inside until they acquire 3 keys. 
	The project is interesting because we had started brainstorming ideas around Halloween, and we thought it would be really fun to create a spooky game. The darkness of our maze gives an ominous feeling, and to further enhance this feeling, a whisper plays at the start of the game saying “Come back alive.” Initially, when we created the game, we did not have the light system indicating where the player had been, and it resulted in the user taking much longer to complete the maze as the keys were collected quickly but it was difficult to remember where in the virtual maze the player had explored. With this system, it helps the user mentally create a map of the maze as they explore and can further plan and strategize how to go about solving the maze, instead of walking through the same hallway multiple times without recognizing it. 
	We decided to restrict the user’s field of view by forcing the user to explore with only the flashlight instead of their entire field of view. While restricting the field of view may increase vection, we hope it causes the user to look around the maze more closely, and with their mind occupied looking for keys and the correct path to the end, their restricted field of view will not be noticed and instead make the game more of a challenge. 
	Furthermore, we hope that with VR, the player can enjoy the classic maze game we used to solve as kids, and immerse themselves into a dark and eerie version of the game. Now, you have to hit dead ends, instead of having the bird's eye view to easily see the path to the exit.

## Design

The game begins with you on one end of the maze, and with some instructions written on a wall straight ahead from you.

#### Figure 1: Game instructions
![fig1](Images/Fig1.png)

The flashlight can be toggled on and off, and each time a clicking sound plays. The first time the player turns on the flashlight, the whisper mentioned in the Introduction is triggered. 
As soon as the game starts, the player is able to inspect their left hand, which has information about how many keys the player has collected in order to escape. The count is updated as the player traverses the game and picks up more keys. If the player restarts the game, the key count is obviously reset as well.

#### Figure 2: In-game key-count displayed on player’s left hand
![fig2](Images/Fig2.png)

The keys around the maze have a green light attached to them in order to make them easier to notice, and to grab the player’s attention. 

#### Figure 3: Key object, with green light to highlight its presence
![fig3](Images/Fig3.png)

As the player traverses the game, lights will illuminate places you’ve passed through. As the player gets closer to the exit, the lights will begin to turn red, otherwise they begin to turn blue. This “hot and cold” system is supposed to help guide the player towards the exit.

#### Figure 4: Lights illuminating maze gradually turning red as you near the exit
![fig4](Images/Fig4.png)
When the player reaches the exit gate after having collected all the keys, the entire maze will light up, and a message is displayed to the player that they beat the game.

#### Figure 5: Exit gate and celebratory end-game message
![fig5](Images/Fig5.png)

  For our game, _The Ascent_, we chose the user interface to be the Oculus Touch controllers. We decided on this because it was the most intuitive, as well as the most immersive, option for our game. The Touch controllers allowed us to map the flashlight to the player’s right hand, which let the player point it in whichever direction they desired. In addition, the trigger and the weight of the controller simulated holding and clicking a flashlight pretty well, increasing player immersion in the game world. If we had used a keyboard and/or mouse, the player would be more aware of those objects, since they are not as intuitive and they don’t allow a free range of motion like the Touch controllers.
  To control player movement, we used the joystick on the left Touch controller. By moving the joystick, the player can control and move the character in the 3D space. The right joystick was used to shift the player’s view so they wouldn’t have to physically turn around when traversing the game. When the player slides the right joystick to either side (left or right), the player’s camera view will rotate about 30 degrees in that respective direction. This allows the player to turn the character in any direction in-game, without needing to move their physical body around. 
  As stated before, the left Touch controller represents the player’s left hand in-game. The Touch controller can be moved around, and the player can see the hand model follow this same movement in game. The same is true for the right Touch controller, except that instead of a hand, it is the flashlight model. Wherever the player points the right Touch controller, the flashlight will point in that direction, allowing the player to illuminate whichever area they desire.
  All other actions are mapped to the buttons and triggers in the Touch controllers. For the right Touch, pressing the A button will restart the game, pressing the B button will quit the game, and the main trigger will toggle the flashlight. For the left Touch, pressing the X button will teleport you the exit, which was a feature we had purely for testing purposes. 
  We followed the VR developer tips discussed in lecture by having mostly simple models in our game. Our entire game world is composed of simple 3D cube objects, with textures applied to them. The only complex models would be the ones we imported, those being the flashlight, the key, and the exit gate. The simplicity of our world made our game not as demanding for the hardware, thus improving the rendering and frame rate.
  Furthermore, for all text we displayed, we made sure it was attached to objects in the virtual world, as opposed to floating on the screen. The best example of this would be the key count on the hand. We spent some time thinking how to display this information, since the player must be able to access it at all times. We found that attaching this text to the hand model worked really well, as it was really only visible when you raised up and looked at it, and since the text is right on top, it seemed natural, as if you were reading a watch. 
  As mentioned above, our game is not super demanding on the hardware, so as long as the Oculus can run on the hardware being used, then technical performance should not be a problem. For the best user experience however, it would be best if both speakers on the headset are in working condition and with the volume turned up, in order to immerse more into the game’s atmosphere. The user experience would also be improved if the player has plenty of space to turn and look around. 

## Implementation

The game uses a few scripts and functions to manage the lighting (World light, wall lights, and flashlight), objects (player, keys, and text), audio, and game status (restart, endgame, and quit).
