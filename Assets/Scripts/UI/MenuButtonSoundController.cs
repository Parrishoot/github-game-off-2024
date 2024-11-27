using UnityEngine;

public class MenuButtonSoundController : MonoBehaviour
{
    [SerializeField]
    private MenuButtonController menuButtonController;

    [SerializeField]
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuButtonController.OnClick += audioSource.Play;    
    }
}
