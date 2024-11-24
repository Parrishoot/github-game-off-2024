using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField]
    private PrefabSpawner packageSpawner;

    [SerializeField]
    private QuestGoalController questGoalController;

    [SerializeField]
    private GameObject enemyParent;

    [SerializeField]
    private QuestController dependency;

    private List<EnemyVisionController> enemies;

    public PackageManager Package { get; private set; }

    public Action OnQuestLock { get; set; }

    public Action OnQuestUnlock { get; set; }

    public Action OnQuestStart { get; set; }

    public Action OnQuestComplete { get; set; }

    public enum QuestState {
        LOCKED,
        READY,
        IN_PROGRESS,
        COMPLETE
    }

    public QuestState State { get; private set; } = QuestState.READY;

    void Start() {

        if(dependency != null) {
            State = QuestState.LOCKED;
            OnQuestLock?.Invoke();
            dependency.OnQuestComplete += Unlock;
        }

        enemies = enemyParent.GetComponentsInChildren<EnemyVisionController>().ToList();

        questGoalController.OnPackageSpotted += FinishQuest;

        foreach(EnemyVisionController enemy in enemies) {
            enemy.OnPackageSpotted += FailQuest;
        }
    }

    public void StartQuest() {
        
        if(State != QuestState.READY) {
            return;
        }

        State = QuestState.IN_PROGRESS;
        PackageManager packageManager = packageSpawner.Spawn().GetComponent<PackageManager>();

        SetupWatchers(packageManager);
        OnQuestStart?.Invoke();
    }

    private void SetupWatchers(PackageManager packageManager)
    {
        foreach(EnemyVisionController enemy in enemies) {
            enemy.SetTargetPackage(packageManager);
        }

        questGoalController.SetTargetPackage(packageManager);
    }

    public void Unlock() {
        State = QuestState.READY;
        OnQuestUnlock?.Invoke();
    }

    public void FinishQuest() {
        if(State == QuestState.IN_PROGRESS) {
            State = QuestState.COMPLETE;
            PackageDeliveredTextController.Instance.ShowText();
            OnQuestComplete?.Invoke();
        }
    }

    public void FailQuest() {
        if(State == QuestState.IN_PROGRESS) {
            State = QuestState.READY;
        }
    }
}
