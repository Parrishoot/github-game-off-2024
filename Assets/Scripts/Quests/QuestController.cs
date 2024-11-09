using UnityEngine;

public class QuestController : MonoBehaviour
{
    public enum QuestState {
        READY,
        IN_PROGRESS,
        COMPLETE
    }

    public QuestState State { get; private set; } = QuestState.READY;

    public void StartQuest() {
        if(State == QuestState.READY) {
            State = QuestState.IN_PROGRESS;
        }
    }

    public void FinishQuest() {
        if(State == QuestState.IN_PROGRESS) {
            State = QuestState.COMPLETE;
        }
    }
}
