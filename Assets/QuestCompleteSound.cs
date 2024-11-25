using UnityEngine;

public class QuestCompleteSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private QuestController questController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questController.OnQuestComplete += audioSource.Play;    
    }
}
