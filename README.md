# Odyssey Ink

This is an EXTREMELY simple sample project I made to help demonstrate to students how Ink could be used as the "narrative middleware" in a Unity game. The role of Ink in this sample project is:

- Handle multiple-choice interactive fiction stories on request.
- Act as a kind of simple database of those stories.
- Track story-relevant game state (in this case, crew size and gold).

Ink is created by Inkle Studios, and you can learn more about it here:
https://www.inklestudios.com/ink/

## Plugins

For simplicity, this repository includes the Ink-unity plugin. But you should always go download the latest version here:
https://github.com/inkle/ink-unity-integration/

Also see the Ink tutorial:
https://github.com/inkle/ink/blob/master/Documentation/WritingWithInk.md

And the "running your Ink" doc, which explains the ink-unity integration process in detail:
https://github.com/inkle/ink/blob/master/Documentation/RunningYourInk.md

## Scenes

The main scene file is `TheSea.unity`.

`TheEnd.unity` is just a win screen.

## Scripts

Movement is handled by a very simple script called `ShipMovement.cs`. Nothing to see here! Move with arrows, etc. Hold "shift" to, uh, run.

The rest of the interaction is all through Unity UI elements, which are set up in the scene. The buttons' event listeners are connected to their relevant C# methods using the `Button` component inspectors.

`Odyssey.ink` is the very simple Ink story, but take a look at it first to understand the structure. 

`GameController.cs` is the main game logic script. This is where you should focus your attention.
