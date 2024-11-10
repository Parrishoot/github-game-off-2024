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

    private List<EnemyVisionController> enemies;

    public PackageManager Package { get; private set; }

    public enum QuestState {
        READY,
        IN_PROGRESS,
        COMPLETE
    }

    public QuestState State { get; private set; } = QuestState.READY;

    void Start() {

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
    }

    private void SetupWatchers(PackageManager packageManager)
    {
        foreach(EnemyVisionController enemy in enemies) {
            enemy.SetTargetPackage(packageManager);
        }

        questGoalController.SetTargetPackage(packageManager);
    }

    public void FinishQuest() {
        if(State == QuestState.IN_PROGRESS) {
            State = QuestState.COMPLETE;
        }
    }

    public void FailQuest() {
        if(State == QuestState.IN_PROGRESS) {
            State = QuestState.READY;
        }
    }
}
