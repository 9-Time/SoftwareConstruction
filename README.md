# SoftwareConstruction


The game consists of four different scenes, namely:
Home page
Matchmaking lobby
Main game
Game over screen

The home page allows the player to adjust the settings of the game and also to enter to matchmaking lobby of the game.

In the matchmaking lobby, player’s can choose to join an existing server created by their friend or strangers, or to create their own server to play among friends. The server created will be hosted by the server creator’s phone.

The two players also have different views on their screen:
The seeker will have a point light that has limited range, and will have to navigate through the map to try to find the hider. The parts of the map not illuminated by the light, in the seeker’s view, will be in total darkness (This is where the hider can hide in).
The hider will be able to see the entire map, though it would be dimly lit, and the seeker and his light range, for him to hide from the seeker. The hider will have to avoid the seeker by hiding behind walls or out of range of the seeker’s light.

When the seeker finds the hider, the health bar of the hider will decrease until it hits 0 which means that the hider loses. However, if the timer runs out before the seeker finds the hider, the hider wins. Either the hider’s health bar reaching zero or the timer running out will trigger the last scene of the game, after which the players will be returned to the matchmaking lobby for them to create or join another server to play again.

As of the latest presentation, all of our functions have been implemented. However, we were unable to collate it all together by the presentation time due to some github conflict. Thus, we would need to manually add in the game over scene and the game over condition, which we expect will not take too much time, at most an hour or two by next week.

After collating the user’s response from our friends, we also realised that we need to balance the game further. Therefore, we will experiment with giving the seeker a faster movement speed as compared to the hider. We will have to rebalance the game in small steps and continue user studies to prevent the game from leaning too much into the seeker’s favour. 
Features that are not completed
Collectible Items / different speed (to balance the game)
Different maps size for variety (if we have the time)

Stuff we need to add in github
Character (Done but not yet uploaded on github)
Health bar (Done but not yet uploaded on github)
Main menu (Done but not yet uploaded on github)
(To be removed after adding onto github)
