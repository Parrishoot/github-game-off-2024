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
    }

    private void PlaySequence() {

        behaviorGraphAgent.enabled = false;

        DialogueManager.Instance.ProcessDialogue(packageSpottedDialogue);
        waitTimer = new Timer(waitTime);
        
        // TODO: Maybe don't restart the scene here?
        waitTimer.OnTimerFinished += SceneTransitionManager.Instance.TransitionOut;
    }

    void Update() {
        waitTimer?.DecreaseTime(Time.deltaTime);
    }
}
