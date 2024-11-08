using System.Collections.Generic;
using UnityEngine;

public class RandomDialogueInteractable : DialogueInteractable
{
    [SerializeField]
    private List<Dialogue> dialogueSelections;

    public override Dialogue GetDialogue()
    {
        return dialogueSelections[Random.Range(0, dialogueSelections.Count)];
    }
}
