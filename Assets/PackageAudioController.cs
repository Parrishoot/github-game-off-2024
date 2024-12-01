using UnityEngine;

public class PacakgeAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float pitchVariance = .2f;

    [SerializeField]
    private PackageManager packageManager;

    void Start() {
        packageManager.OnBounce += PlaySound;
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
