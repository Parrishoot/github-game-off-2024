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

        // foreach(EnemyVisionController enemy in enemies) {
        //     enemy.OnPackageSpotted += FailQuest;
        // }

        SceneTransitionManager.Instance.OnTransitionOutFinished += CheckSpawnPackage;
    }

    public void StartQuest() {
        
        if(State != QuestState.READY) {
            return;
        }

        SpawnPackage();

        State = QuestState.IN_PROGRESS;
        OnQuestStart?.Invoke();
    }

    private void SpawnPackage() {

        if(Package != null) {
            Destroy(Package.gameObject);
        }

        PackageManager packageManager = packageSpawner.Spawn().GetComponent<PackageManager>();
        packageManager.OnLost += SpawnPackage;

        SetupWatchers(packageManager);

        Package = packageManager;
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
    
    public void CheckSpawnPackage() {

        if(State != QuestState.IN_PROGRESS) {
            return;
        }

        SpawnPackage();
    }
}
