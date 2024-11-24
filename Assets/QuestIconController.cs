using UnityEngine;

public class QuestIconController : MonoBehaviour
{
    [SerializeField]
    private QuestController questController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questController.OnQuestLock += () => gameObject.SetActive(false);
        questController.OnQuestUnlock += () => gameObject.SetActive(true);
        questController.OnQuestStart += () => gameObject.SetActive(false);
    }
}
