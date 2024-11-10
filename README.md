# Tips
## To Create New Dialogue
- Right Click > Create > ScriptableObjects > Dialogue
- Edit the "Lines" property with the dialogue text. Each line will be a separate dialogue section  

## To Create a New Talkable NPC
- Click and Drag new `DialogueNPC` Prefab from Assets > Prefabs into the scene
- Find the `Random Dialogue Interactable` component on the top-level game object
- Click +/- and drag in the dialogue entries (See "To Create New Dialogue" section above for creation tips)
- The NPC will now be interactable and will speak a random dialogue from that list as you talk to them

## To Create a New Quest
- Click and Drag new `QuestContainer` Prefab from Assets > Prefabs into the scene
- Find the `Quest Trigger Dialogue Interactable` component under `QuestDialogueNPC`
- Drag the different quest trigger dialogues into their respective slots (See "To Create New Dialogue" section above for creation tips)
    - Quest Trigger Dialogue > Dialogue for when you first trigger the quest (i.e. the quest info)
    - Quest In Progress Dialogue > Dialogue for when you go talk to the NPC while the quest is active
    - Quest Complete Dialogue > Dialogue for when the quest is completed and you return to the trigger NPC
- _TODO: Add NPCs that will intercept your package, not yet implemented_ 
- Find the `QuestGoalPivot` GameObject and drag it to where the package should get delivered in the world.
