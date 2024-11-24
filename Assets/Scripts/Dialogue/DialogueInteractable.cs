using UnityEngine;

public abstract class DialogueInteractable : MonoBehaviour, IInteractable
{
    public abstract Dialogue GetDialogue();

    public Dialogue ActiveDialogue { get; private set; }

    public void Interact()
    {
        // TODO: STOP PLAYER MOVEMENT WHEN DIALOGUE-ING

        if(ActiveDialogue != null) {
            DialogueManager.Instance.ContinueDialogue();
            return;
        }

        ActiveDialogue = GetDialogue();
        DialogueManager.Instance.ProcessDialogue(ActiveDialogue);

        DialogueManager.Instance.OnDialogueFinish += FinishDialogue;
    }

    protected virtual void FinishDialogue() {

        ActiveDialogue = null;
        DialogueManager.Instance.OnDialogueFinish -= FinishDialogue;

    }

    public string GetText() => "Speak";
}
