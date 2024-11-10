# Tips

## To Create New Dialogue
- **Right Click > Create > ScriptableObjects > Dialogue**
- Edit the `Lines` property with the dialogue text. Each line will be a separate dialogue section  

## To Create a New Talkable NPC
- Click and Drag new `DialogueNPC` Prefab from **Assets > Prefabs** into the scene
- Find the `Random Dialogue Interactable` component on the top-level game object
- Click +/- and drag in the dialogue entries (See "To Create New Dialogue" section above for creation tips)
- The NPC will now be interactable and will speak a random dialogue from that list as you talk to them

## To Create a New Quest

### Set up
- Click and Drag new `QuestContainer` Prefab from **Assets > Prefabs** into the scene

### Quest Dialogue
- Find the `Quest Trigger Dialogue Interactable` component under `QuestDialogueNPC`
- Drag the different quest trigger dialogues into their respective slots (See "To Create New Dialogue" section above for creation tips)
    - _Quest Trigger Dialogue:_ Dialogue for when you first trigger the quest (i.e. the quest info)
    - _Quest In Progress Dialogue:_ Dialogue for when you go talk to the NPC while the quest is active
    - _Quest Complete Dialogue_: Dialogue for when the quest is completed and you return to the trigger NPC

### Enemies
- Click and drag a new enemy from **Assets > Prefabs > Enemy** under the `Enemies` parent object in the `QuestContainer`
- To set up a patrolling route, add waypoint GameObjects (Just empty game objects are fine - only the locations will matter) for each "stop" along the patrolling path
- Click +/- to set the number of list entries and drag each of the waypoints in order to the `Waypoints (Override)` component under the top level `Enemy` GameObject
    - You can adjust the characters walk speed and wait time under their respective fields in this component as well
- If everything is set up correctly, you should see a red line path in the `Scene` view of the editor when you click on the quest or enemy
### Quest Delivery Location
- Find the `QuestGoalPivot` GameObject and drag it to where the package should get delivered in the world. There should be a small yellow diamond on the ground where this location is in the `Scene` view
