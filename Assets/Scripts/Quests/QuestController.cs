using System;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField]
    private PrefabSpawner packageSpawner;

    [SerializeField]
    private QuestGoalController questGoalController;

    public enum QuestState {
        READY,
        IN_PROGRESS,
        COMPLETE
    }

    public QuestState State { get; private set; } = QuestState.READY;

    void Start() {
        questGoalController.PackageDelivered += FinishQuest;
    }

    public void StartQuest() {
        
        if(State != QuestState.READY) {
            return;
        }

        State = QuestState.IN_PROGRESS;
        PackageManager packageManager = packageSpawner.Spawn().GetComponent<PackageManager>();
        questGoalController.SetTargetPackage(packageManager);
    }

    public void FinishQuest() {
        if(State == QuestState.IN_PROGRESS) {
            State = QuestState.COMPLETE;
        }
    }
}
