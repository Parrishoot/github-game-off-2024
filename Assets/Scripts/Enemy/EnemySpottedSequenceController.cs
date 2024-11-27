using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpottedSequenceController : MonoBehaviour
{
    [SerializeField]
    private EnemyVisionController enemyVisionController;

    [SerializeField]
    private Dialogue packageSpottedDialogue;

    [SerializeField]
    private BehaviorGraphAgent behaviorGraphAgent;

    [SerializeField]
    private float waitTime = 1f;

    private Timer waitTimer;

    void Start() {
        enemyVisionController.OnPackageSpotted += PlaySequence;

        if(behaviorGraphAgent != null) {
            SceneTransitionManager.Instance.OnTransitionOutFinished += () => behaviorGraphAgent.enabled = true;
        }
    }

    private void PlaySequence() {

        if(behaviorGraphAgent != null) {
            SceneTransitionManager.Instance.OnTransitionOutFinished += () => behaviorGraphAgent.enabled = true;
        }

        DialogueManager.Instance.ProcessDialogue(packageSpottedDialogue);
        waitTimer = new Timer(waitTime);
        
        // TODO: Maybe don't restart the scene here?
        SceneTransitionManager.Instance.OnTransitionOutFinished += ProcessTransition;
        waitTimer.OnTimerFinished += SceneTransitionManager.Instance.TransitionOut;
    }

    private void ProcessTransition()
    {
        DialogueManager.Instance.ContinueDialogue();
        SceneTransitionManager.Instance.OnTransitionOutFinished -= ProcessTransition;
    }

    void Update() {
        waitTimer?.DecreaseTime(Time.deltaTime);
    }
}
