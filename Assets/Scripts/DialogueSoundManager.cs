using UnityEngine;

public class DialogueSoundManager : MonoBehaviour
{
    [SerializeField]
    private DialogueAnimator dialogueAnimator;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float pitchVariance = .2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueAnimator.OnLetterShown += PlaySound;
    }

    private void PlaySound()
    {
        if(audioSource.isPlaying || !audioSource.isActiveAndEnabled) {
            return;
        }

        audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);
        audioSource.Play();
    }
}
