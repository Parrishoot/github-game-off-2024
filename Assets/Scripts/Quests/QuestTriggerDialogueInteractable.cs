using UnityEngine;

public class QuestTriggerDialogueInteractable : DialogueInteractable
{
    [SerializeField]
    private QuestController questController;

    [SerializeField]
    private Dialogue questTriggerDialogue;

    [SerializeField]
    private Dialogue questInProgressDialogue;

    [SerializeField]
    private Dialogue questCompleteDialogue;

    public override Dialogue GetDialogue() {
        // Return the appropriate dialogue depending on the progress of the quest
        return questController.State switch {
            QuestController.QuestState.READY => questTriggerDialogue,
            QuestController.QuestState.IN_PROGRESS => questInProgressDialogue,
            QuestController.QuestState.COMPLETE => questCompleteDialogue,
            _ => questTriggerDialogue
        };
    }

    protected override void FinishDialogue()
    {
        base.FinishDialogue();
        
        // If we've triggered the first dialogue - start the quest
        if(questController.State == QuestController.QuestState.READY) {
            questController.StartQuest();
        }
    }
}
