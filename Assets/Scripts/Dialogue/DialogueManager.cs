using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private DialogueAnimator dialogueAnimator;

    public Action OnDialogueStart;

    public Action OnDialogueFinish;

    private Dialogue currentDialogue;

    private int lineNumber = 0;

    private bool continueDialogue = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueAnimator.OnFinish += CheckDialogueContinue;
        dialoguePanel.SetActive(false);
    }

    public void ProcessDialogue(Dialogue dialogue) {

        if(currentDialogue != null) {
            Debug.LogWarning("Uh oh - starting new dialogue with an active dialogue");
            return;
        }

        currentDialogue = dialogue;
        lineNumber = 0;

        dialogueAnimator.BeginAnimation(dialogue.Lines[lineNumber++]);
        dialoguePanel.SetActive(true);
        
        OnDialogueStart?.Invoke();
        dialogueAnimator.OnFinish += CheckDialogueContinue;
    }

    private void CheckDialogueContinue() {
        
        if(currentDialogue == null) {
            Debug.LogWarning("Uh oh - continuing dialogue without beginning the dialogue");
            return;
        }

        continueDialogue = true;
    }

    public void ContinueDialogue() {

        // If we're not ready to continue - don't
        if(!continueDialogue) {
            return;
        }

        if(lineNumber >= currentDialogue.Lines.Count) {
            dialoguePanel.SetActive(false);
            currentDialogue = null;
            OnDialogueFinish?.Invoke();
            return;
        }

        dialogueAnimator.BeginAnimation(currentDialogue.Lines[lineNumber++]);
        dialogueAnimator.OnFinish += CheckDialogueContinue;

    }
}
